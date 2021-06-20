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
   public class wwp_notificationdefinition_bc : GXHttpHandler, IGxSilentTrn
   {
      public wwp_notificationdefinition_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_notificationdefinition_bc( IGxContext context )
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
         ReadRow077( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey077( ) ;
         standaloneModal( ) ;
         AddRow077( ) ;
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
               Z14WWPNotificationDefinitionId = A14WWPNotificationDefinitionId;
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

      protected void CONFIRM_070( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls077( ) ;
            }
            else
            {
               CheckExtendedTable077( ) ;
               if ( AnyError == 0 )
               {
                  ZM077( 4) ;
               }
               CloseExtendedTableCursors077( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM077( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z53WWPNotificationDefinitionName = A53WWPNotificationDefinitionName;
            Z26WWPNotificationDefinitionAppliesTo = A26WWPNotificationDefinitionAppliesTo;
            Z27WWPNotificationDefinitionAllowUserSubscription = A27WWPNotificationDefinitionAllowUserSubscription;
            Z25WWPNotificationDefinitionDescription = A25WWPNotificationDefinitionDescription;
            Z56WWPNotificationDefinitionIcon = A56WWPNotificationDefinitionIcon;
            Z57WWPNotificationDefinitionTitle = A57WWPNotificationDefinitionTitle;
            Z58WWPNotificationDefinitionShortDescription = A58WWPNotificationDefinitionShortDescription;
            Z59WWPNotificationDefinitionLongDescription = A59WWPNotificationDefinitionLongDescription;
            Z60WWPNotificationDefinitionLink = A60WWPNotificationDefinitionLink;
            Z10WWPEntityId = A10WWPEntityId;
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z12WWPEntityName = A12WWPEntityName;
         }
         if ( GX_JID == -3 )
         {
            Z14WWPNotificationDefinitionId = A14WWPNotificationDefinitionId;
            Z53WWPNotificationDefinitionName = A53WWPNotificationDefinitionName;
            Z26WWPNotificationDefinitionAppliesTo = A26WWPNotificationDefinitionAppliesTo;
            Z27WWPNotificationDefinitionAllowUserSubscription = A27WWPNotificationDefinitionAllowUserSubscription;
            Z25WWPNotificationDefinitionDescription = A25WWPNotificationDefinitionDescription;
            Z56WWPNotificationDefinitionIcon = A56WWPNotificationDefinitionIcon;
            Z57WWPNotificationDefinitionTitle = A57WWPNotificationDefinitionTitle;
            Z58WWPNotificationDefinitionShortDescription = A58WWPNotificationDefinitionShortDescription;
            Z59WWPNotificationDefinitionLongDescription = A59WWPNotificationDefinitionLongDescription;
            Z60WWPNotificationDefinitionLink = A60WWPNotificationDefinitionLink;
            Z10WWPEntityId = A10WWPEntityId;
            Z12WWPEntityName = A12WWPEntityName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load077( )
      {
         /* Using cursor BC00075 */
         pr_default.execute(3, new Object[] {A14WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound7 = 1;
            A53WWPNotificationDefinitionName = BC00075_A53WWPNotificationDefinitionName[0];
            A26WWPNotificationDefinitionAppliesTo = BC00075_A26WWPNotificationDefinitionAppliesTo[0];
            A27WWPNotificationDefinitionAllowUserSubscription = BC00075_A27WWPNotificationDefinitionAllowUserSubscription[0];
            A25WWPNotificationDefinitionDescription = BC00075_A25WWPNotificationDefinitionDescription[0];
            A56WWPNotificationDefinitionIcon = BC00075_A56WWPNotificationDefinitionIcon[0];
            A57WWPNotificationDefinitionTitle = BC00075_A57WWPNotificationDefinitionTitle[0];
            A58WWPNotificationDefinitionShortDescription = BC00075_A58WWPNotificationDefinitionShortDescription[0];
            A59WWPNotificationDefinitionLongDescription = BC00075_A59WWPNotificationDefinitionLongDescription[0];
            A60WWPNotificationDefinitionLink = BC00075_A60WWPNotificationDefinitionLink[0];
            A12WWPEntityName = BC00075_A12WWPEntityName[0];
            A10WWPEntityId = BC00075_A10WWPEntityId[0];
            ZM077( -3) ;
         }
         pr_default.close(3);
         OnLoadActions077( ) ;
      }

      protected void OnLoadActions077( )
      {
      }

      protected void CheckExtendedTable077( )
      {
         nIsDirty_7 = 0;
         standaloneModal( ) ;
         if ( ! ( ( A26WWPNotificationDefinitionAppliesTo == 1 ) || ( A26WWPNotificationDefinitionAppliesTo == 2 ) ) )
         {
            GX_msglist.addItem("Campo Notification Definition Applies To fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A60WWPNotificationDefinitionLink,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem("O valor de Notification Definition Default Link não coincide com o padrão especificado", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00074 */
         pr_default.execute(2, new Object[] {A10WWPEntityId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Entity for Discussions and Notifications'.", "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
         }
         A12WWPEntityName = BC00074_A12WWPEntityName[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors077( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey077( )
      {
         /* Using cursor BC00076 */
         pr_default.execute(4, new Object[] {A14WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound7 = 1;
         }
         else
         {
            RcdFound7 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00073 */
         pr_default.execute(1, new Object[] {A14WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM077( 3) ;
            RcdFound7 = 1;
            A14WWPNotificationDefinitionId = BC00073_A14WWPNotificationDefinitionId[0];
            A53WWPNotificationDefinitionName = BC00073_A53WWPNotificationDefinitionName[0];
            A26WWPNotificationDefinitionAppliesTo = BC00073_A26WWPNotificationDefinitionAppliesTo[0];
            A27WWPNotificationDefinitionAllowUserSubscription = BC00073_A27WWPNotificationDefinitionAllowUserSubscription[0];
            A25WWPNotificationDefinitionDescription = BC00073_A25WWPNotificationDefinitionDescription[0];
            A56WWPNotificationDefinitionIcon = BC00073_A56WWPNotificationDefinitionIcon[0];
            A57WWPNotificationDefinitionTitle = BC00073_A57WWPNotificationDefinitionTitle[0];
            A58WWPNotificationDefinitionShortDescription = BC00073_A58WWPNotificationDefinitionShortDescription[0];
            A59WWPNotificationDefinitionLongDescription = BC00073_A59WWPNotificationDefinitionLongDescription[0];
            A60WWPNotificationDefinitionLink = BC00073_A60WWPNotificationDefinitionLink[0];
            A10WWPEntityId = BC00073_A10WWPEntityId[0];
            Z14WWPNotificationDefinitionId = A14WWPNotificationDefinitionId;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load077( ) ;
            if ( AnyError == 1 )
            {
               RcdFound7 = 0;
               InitializeNonKey077( ) ;
            }
            Gx_mode = sMode7;
         }
         else
         {
            RcdFound7 = 0;
            InitializeNonKey077( ) ;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode7;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey077( ) ;
         if ( RcdFound7 == 0 )
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
         CONFIRM_070( ) ;
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

      protected void CheckOptimisticConcurrency077( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00072 */
            pr_default.execute(0, new Object[] {A14WWPNotificationDefinitionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_NotificationDefinition"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z53WWPNotificationDefinitionName, BC00072_A53WWPNotificationDefinitionName[0]) != 0 ) || ( Z26WWPNotificationDefinitionAppliesTo != BC00072_A26WWPNotificationDefinitionAppliesTo[0] ) || ( Z27WWPNotificationDefinitionAllowUserSubscription != BC00072_A27WWPNotificationDefinitionAllowUserSubscription[0] ) || ( StringUtil.StrCmp(Z25WWPNotificationDefinitionDescription, BC00072_A25WWPNotificationDefinitionDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z56WWPNotificationDefinitionIcon, BC00072_A56WWPNotificationDefinitionIcon[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z57WWPNotificationDefinitionTitle, BC00072_A57WWPNotificationDefinitionTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z58WWPNotificationDefinitionShortDescription, BC00072_A58WWPNotificationDefinitionShortDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z59WWPNotificationDefinitionLongDescription, BC00072_A59WWPNotificationDefinitionLongDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z60WWPNotificationDefinitionLink, BC00072_A60WWPNotificationDefinitionLink[0]) != 0 ) || ( Z10WWPEntityId != BC00072_A10WWPEntityId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_NotificationDefinition"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert077( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable077( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM077( 0) ;
            CheckOptimisticConcurrency077( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm077( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert077( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00077 */
                     pr_default.execute(5, new Object[] {A53WWPNotificationDefinitionName, A26WWPNotificationDefinitionAppliesTo, A27WWPNotificationDefinitionAllowUserSubscription, A25WWPNotificationDefinitionDescription, A56WWPNotificationDefinitionIcon, A57WWPNotificationDefinitionTitle, A58WWPNotificationDefinitionShortDescription, A59WWPNotificationDefinitionLongDescription, A60WWPNotificationDefinitionLink, A10WWPEntityId});
                     A14WWPNotificationDefinitionId = BC00077_A14WWPNotificationDefinitionId[0];
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_NotificationDefinition");
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
               Load077( ) ;
            }
            EndLevel077( ) ;
         }
         CloseExtendedTableCursors077( ) ;
      }

      protected void Update077( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable077( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency077( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm077( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate077( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00078 */
                     pr_default.execute(6, new Object[] {A53WWPNotificationDefinitionName, A26WWPNotificationDefinitionAppliesTo, A27WWPNotificationDefinitionAllowUserSubscription, A25WWPNotificationDefinitionDescription, A56WWPNotificationDefinitionIcon, A57WWPNotificationDefinitionTitle, A58WWPNotificationDefinitionShortDescription, A59WWPNotificationDefinitionLongDescription, A60WWPNotificationDefinitionLink, A10WWPEntityId, A14WWPNotificationDefinitionId});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_NotificationDefinition");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_NotificationDefinition"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate077( ) ;
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
            EndLevel077( ) ;
         }
         CloseExtendedTableCursors077( ) ;
      }

      protected void DeferredUpdate077( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency077( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls077( ) ;
            AfterConfirm077( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete077( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00079 */
                  pr_default.execute(7, new Object[] {A14WWPNotificationDefinitionId});
                  pr_default.close(7);
                  dsDefault.SmartCacheProvider.SetUpdated("WWP_NotificationDefinition");
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
         sMode7 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel077( ) ;
         Gx_mode = sMode7;
      }

      protected void OnDeleteControls077( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000710 */
            pr_default.execute(8, new Object[] {A10WWPEntityId});
            A12WWPEntityName = BC000710_A12WWPEntityName[0];
            pr_default.close(8);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000711 */
            pr_default.execute(9, new Object[] {A14WWPNotificationDefinitionId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWPNotification"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC000712 */
            pr_default.execute(10, new Object[] {A14WWPNotificationDefinitionId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWPSubscription"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel077( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete077( ) ;
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

      public void ScanKeyStart077( )
      {
         /* Using cursor BC000713 */
         pr_default.execute(11, new Object[] {A14WWPNotificationDefinitionId});
         RcdFound7 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound7 = 1;
            A14WWPNotificationDefinitionId = BC000713_A14WWPNotificationDefinitionId[0];
            A53WWPNotificationDefinitionName = BC000713_A53WWPNotificationDefinitionName[0];
            A26WWPNotificationDefinitionAppliesTo = BC000713_A26WWPNotificationDefinitionAppliesTo[0];
            A27WWPNotificationDefinitionAllowUserSubscription = BC000713_A27WWPNotificationDefinitionAllowUserSubscription[0];
            A25WWPNotificationDefinitionDescription = BC000713_A25WWPNotificationDefinitionDescription[0];
            A56WWPNotificationDefinitionIcon = BC000713_A56WWPNotificationDefinitionIcon[0];
            A57WWPNotificationDefinitionTitle = BC000713_A57WWPNotificationDefinitionTitle[0];
            A58WWPNotificationDefinitionShortDescription = BC000713_A58WWPNotificationDefinitionShortDescription[0];
            A59WWPNotificationDefinitionLongDescription = BC000713_A59WWPNotificationDefinitionLongDescription[0];
            A60WWPNotificationDefinitionLink = BC000713_A60WWPNotificationDefinitionLink[0];
            A12WWPEntityName = BC000713_A12WWPEntityName[0];
            A10WWPEntityId = BC000713_A10WWPEntityId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext077( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound7 = 0;
         ScanKeyLoad077( ) ;
      }

      protected void ScanKeyLoad077( )
      {
         sMode7 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound7 = 1;
            A14WWPNotificationDefinitionId = BC000713_A14WWPNotificationDefinitionId[0];
            A53WWPNotificationDefinitionName = BC000713_A53WWPNotificationDefinitionName[0];
            A26WWPNotificationDefinitionAppliesTo = BC000713_A26WWPNotificationDefinitionAppliesTo[0];
            A27WWPNotificationDefinitionAllowUserSubscription = BC000713_A27WWPNotificationDefinitionAllowUserSubscription[0];
            A25WWPNotificationDefinitionDescription = BC000713_A25WWPNotificationDefinitionDescription[0];
            A56WWPNotificationDefinitionIcon = BC000713_A56WWPNotificationDefinitionIcon[0];
            A57WWPNotificationDefinitionTitle = BC000713_A57WWPNotificationDefinitionTitle[0];
            A58WWPNotificationDefinitionShortDescription = BC000713_A58WWPNotificationDefinitionShortDescription[0];
            A59WWPNotificationDefinitionLongDescription = BC000713_A59WWPNotificationDefinitionLongDescription[0];
            A60WWPNotificationDefinitionLink = BC000713_A60WWPNotificationDefinitionLink[0];
            A12WWPEntityName = BC000713_A12WWPEntityName[0];
            A10WWPEntityId = BC000713_A10WWPEntityId[0];
         }
         Gx_mode = sMode7;
      }

      protected void ScanKeyEnd077( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm077( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert077( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate077( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete077( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete077( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate077( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes077( )
      {
      }

      protected void send_integrity_lvl_hashes077( )
      {
      }

      protected void AddRow077( )
      {
         VarsToRow7( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
      }

      protected void ReadRow077( )
      {
         RowToVars7( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
      }

      protected void InitializeNonKey077( )
      {
         A53WWPNotificationDefinitionName = "";
         A26WWPNotificationDefinitionAppliesTo = 0;
         A27WWPNotificationDefinitionAllowUserSubscription = false;
         A25WWPNotificationDefinitionDescription = "";
         A56WWPNotificationDefinitionIcon = "";
         A57WWPNotificationDefinitionTitle = "";
         A58WWPNotificationDefinitionShortDescription = "";
         A59WWPNotificationDefinitionLongDescription = "";
         A60WWPNotificationDefinitionLink = "";
         A10WWPEntityId = 0;
         A12WWPEntityName = "";
         Z53WWPNotificationDefinitionName = "";
         Z26WWPNotificationDefinitionAppliesTo = 0;
         Z27WWPNotificationDefinitionAllowUserSubscription = false;
         Z25WWPNotificationDefinitionDescription = "";
         Z56WWPNotificationDefinitionIcon = "";
         Z57WWPNotificationDefinitionTitle = "";
         Z58WWPNotificationDefinitionShortDescription = "";
         Z59WWPNotificationDefinitionLongDescription = "";
         Z60WWPNotificationDefinitionLink = "";
         Z10WWPEntityId = 0;
      }

      protected void InitAll077( )
      {
         A14WWPNotificationDefinitionId = 0;
         InitializeNonKey077( ) ;
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

      public void VarsToRow7( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition obj7 )
      {
         obj7.gxTpr_Mode = Gx_mode;
         obj7.gxTpr_Wwpnotificationdefinitionname = A53WWPNotificationDefinitionName;
         obj7.gxTpr_Wwpnotificationdefinitionappliesto = A26WWPNotificationDefinitionAppliesTo;
         obj7.gxTpr_Wwpnotificationdefinitionallowusersubscription = A27WWPNotificationDefinitionAllowUserSubscription;
         obj7.gxTpr_Wwpnotificationdefinitiondescription = A25WWPNotificationDefinitionDescription;
         obj7.gxTpr_Wwpnotificationdefinitionicon = A56WWPNotificationDefinitionIcon;
         obj7.gxTpr_Wwpnotificationdefinitiontitle = A57WWPNotificationDefinitionTitle;
         obj7.gxTpr_Wwpnotificationdefinitionshortdescription = A58WWPNotificationDefinitionShortDescription;
         obj7.gxTpr_Wwpnotificationdefinitionlongdescription = A59WWPNotificationDefinitionLongDescription;
         obj7.gxTpr_Wwpnotificationdefinitionlink = A60WWPNotificationDefinitionLink;
         obj7.gxTpr_Wwpentityid = A10WWPEntityId;
         obj7.gxTpr_Wwpentityname = A12WWPEntityName;
         obj7.gxTpr_Wwpnotificationdefinitionid = A14WWPNotificationDefinitionId;
         obj7.gxTpr_Wwpnotificationdefinitionid_Z = Z14WWPNotificationDefinitionId;
         obj7.gxTpr_Wwpnotificationdefinitionname_Z = Z53WWPNotificationDefinitionName;
         obj7.gxTpr_Wwpnotificationdefinitionappliesto_Z = Z26WWPNotificationDefinitionAppliesTo;
         obj7.gxTpr_Wwpnotificationdefinitionallowusersubscription_Z = Z27WWPNotificationDefinitionAllowUserSubscription;
         obj7.gxTpr_Wwpnotificationdefinitiondescription_Z = Z25WWPNotificationDefinitionDescription;
         obj7.gxTpr_Wwpnotificationdefinitionicon_Z = Z56WWPNotificationDefinitionIcon;
         obj7.gxTpr_Wwpnotificationdefinitiontitle_Z = Z57WWPNotificationDefinitionTitle;
         obj7.gxTpr_Wwpnotificationdefinitionshortdescription_Z = Z58WWPNotificationDefinitionShortDescription;
         obj7.gxTpr_Wwpnotificationdefinitionlongdescription_Z = Z59WWPNotificationDefinitionLongDescription;
         obj7.gxTpr_Wwpnotificationdefinitionlink_Z = Z60WWPNotificationDefinitionLink;
         obj7.gxTpr_Wwpentityid_Z = Z10WWPEntityId;
         obj7.gxTpr_Wwpentityname_Z = Z12WWPEntityName;
         obj7.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow7( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition obj7 )
      {
         obj7.gxTpr_Wwpnotificationdefinitionid = A14WWPNotificationDefinitionId;
         return  ;
      }

      public void RowToVars7( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition obj7 ,
                              int forceLoad )
      {
         Gx_mode = obj7.gxTpr_Mode;
         A53WWPNotificationDefinitionName = obj7.gxTpr_Wwpnotificationdefinitionname;
         A26WWPNotificationDefinitionAppliesTo = obj7.gxTpr_Wwpnotificationdefinitionappliesto;
         A27WWPNotificationDefinitionAllowUserSubscription = obj7.gxTpr_Wwpnotificationdefinitionallowusersubscription;
         A25WWPNotificationDefinitionDescription = obj7.gxTpr_Wwpnotificationdefinitiondescription;
         A56WWPNotificationDefinitionIcon = obj7.gxTpr_Wwpnotificationdefinitionicon;
         A57WWPNotificationDefinitionTitle = obj7.gxTpr_Wwpnotificationdefinitiontitle;
         A58WWPNotificationDefinitionShortDescription = obj7.gxTpr_Wwpnotificationdefinitionshortdescription;
         A59WWPNotificationDefinitionLongDescription = obj7.gxTpr_Wwpnotificationdefinitionlongdescription;
         A60WWPNotificationDefinitionLink = obj7.gxTpr_Wwpnotificationdefinitionlink;
         A10WWPEntityId = obj7.gxTpr_Wwpentityid;
         A12WWPEntityName = obj7.gxTpr_Wwpentityname;
         A14WWPNotificationDefinitionId = obj7.gxTpr_Wwpnotificationdefinitionid;
         Z14WWPNotificationDefinitionId = obj7.gxTpr_Wwpnotificationdefinitionid_Z;
         Z53WWPNotificationDefinitionName = obj7.gxTpr_Wwpnotificationdefinitionname_Z;
         Z26WWPNotificationDefinitionAppliesTo = obj7.gxTpr_Wwpnotificationdefinitionappliesto_Z;
         Z27WWPNotificationDefinitionAllowUserSubscription = obj7.gxTpr_Wwpnotificationdefinitionallowusersubscription_Z;
         Z25WWPNotificationDefinitionDescription = obj7.gxTpr_Wwpnotificationdefinitiondescription_Z;
         Z56WWPNotificationDefinitionIcon = obj7.gxTpr_Wwpnotificationdefinitionicon_Z;
         Z57WWPNotificationDefinitionTitle = obj7.gxTpr_Wwpnotificationdefinitiontitle_Z;
         Z58WWPNotificationDefinitionShortDescription = obj7.gxTpr_Wwpnotificationdefinitionshortdescription_Z;
         Z59WWPNotificationDefinitionLongDescription = obj7.gxTpr_Wwpnotificationdefinitionlongdescription_Z;
         Z60WWPNotificationDefinitionLink = obj7.gxTpr_Wwpnotificationdefinitionlink_Z;
         Z10WWPEntityId = obj7.gxTpr_Wwpentityid_Z;
         Z12WWPEntityName = obj7.gxTpr_Wwpentityname_Z;
         Gx_mode = obj7.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A14WWPNotificationDefinitionId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey077( ) ;
         ScanKeyStart077( ) ;
         if ( RcdFound7 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z14WWPNotificationDefinitionId = A14WWPNotificationDefinitionId;
         }
         ZM077( -3) ;
         OnLoadActions077( ) ;
         AddRow077( ) ;
         ScanKeyEnd077( ) ;
         if ( RcdFound7 == 0 )
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
         RowToVars7( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 0) ;
         ScanKeyStart077( ) ;
         if ( RcdFound7 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z14WWPNotificationDefinitionId = A14WWPNotificationDefinitionId;
         }
         ZM077( -3) ;
         OnLoadActions077( ) ;
         AddRow077( ) ;
         ScanKeyEnd077( ) ;
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey077( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert077( ) ;
         }
         else
         {
            if ( RcdFound7 == 1 )
            {
               if ( A14WWPNotificationDefinitionId != Z14WWPNotificationDefinitionId )
               {
                  A14WWPNotificationDefinitionId = Z14WWPNotificationDefinitionId;
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
                  Update077( ) ;
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
                  if ( A14WWPNotificationDefinitionId != Z14WWPNotificationDefinitionId )
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
                        Insert077( ) ;
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
                        Insert077( ) ;
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
         RowToVars7( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
         SaveImpl( ) ;
         VarsToRow7( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
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
         RowToVars7( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert077( ) ;
         AfterTrn( ) ;
         VarsToRow7( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
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
            GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition auxBC = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A14WWPNotificationDefinitionId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition);
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
         RowToVars7( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
         UpdateImpl( ) ;
         VarsToRow7( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
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
         RowToVars7( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert077( ) ;
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
         VarsToRow7( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars7( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey077( ) ;
         if ( RcdFound7 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A14WWPNotificationDefinitionId != Z14WWPNotificationDefinitionId )
            {
               A14WWPNotificationDefinitionId = Z14WWPNotificationDefinitionId;
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
            if ( A14WWPNotificationDefinitionId != Z14WWPNotificationDefinitionId )
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
         context.RollbackDataStores("wwpbaseobjects.notifications.common.wwp_notificationdefinition_bc",pr_default);
         VarsToRow7( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
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
         Gx_mode = bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition )
         {
            bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition = (GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow7( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
            }
            else
            {
               RowToVars7( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars7( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtWWP_NotificationDefinition WWP_NotificationDefinition_BC
      {
         get {
            return bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition ;
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
            return "wwpnotificationdefinition_Execute" ;
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
         Z53WWPNotificationDefinitionName = "";
         A53WWPNotificationDefinitionName = "";
         Z25WWPNotificationDefinitionDescription = "";
         A25WWPNotificationDefinitionDescription = "";
         Z56WWPNotificationDefinitionIcon = "";
         A56WWPNotificationDefinitionIcon = "";
         Z57WWPNotificationDefinitionTitle = "";
         A57WWPNotificationDefinitionTitle = "";
         Z58WWPNotificationDefinitionShortDescription = "";
         A58WWPNotificationDefinitionShortDescription = "";
         Z59WWPNotificationDefinitionLongDescription = "";
         A59WWPNotificationDefinitionLongDescription = "";
         Z60WWPNotificationDefinitionLink = "";
         A60WWPNotificationDefinitionLink = "";
         Z12WWPEntityName = "";
         A12WWPEntityName = "";
         BC00075_A14WWPNotificationDefinitionId = new long[1] ;
         BC00075_A53WWPNotificationDefinitionName = new string[] {""} ;
         BC00075_A26WWPNotificationDefinitionAppliesTo = new short[1] ;
         BC00075_A27WWPNotificationDefinitionAllowUserSubscription = new bool[] {false} ;
         BC00075_A25WWPNotificationDefinitionDescription = new string[] {""} ;
         BC00075_A56WWPNotificationDefinitionIcon = new string[] {""} ;
         BC00075_A57WWPNotificationDefinitionTitle = new string[] {""} ;
         BC00075_A58WWPNotificationDefinitionShortDescription = new string[] {""} ;
         BC00075_A59WWPNotificationDefinitionLongDescription = new string[] {""} ;
         BC00075_A60WWPNotificationDefinitionLink = new string[] {""} ;
         BC00075_A12WWPEntityName = new string[] {""} ;
         BC00075_A10WWPEntityId = new long[1] ;
         BC00074_A12WWPEntityName = new string[] {""} ;
         BC00076_A14WWPNotificationDefinitionId = new long[1] ;
         BC00073_A14WWPNotificationDefinitionId = new long[1] ;
         BC00073_A53WWPNotificationDefinitionName = new string[] {""} ;
         BC00073_A26WWPNotificationDefinitionAppliesTo = new short[1] ;
         BC00073_A27WWPNotificationDefinitionAllowUserSubscription = new bool[] {false} ;
         BC00073_A25WWPNotificationDefinitionDescription = new string[] {""} ;
         BC00073_A56WWPNotificationDefinitionIcon = new string[] {""} ;
         BC00073_A57WWPNotificationDefinitionTitle = new string[] {""} ;
         BC00073_A58WWPNotificationDefinitionShortDescription = new string[] {""} ;
         BC00073_A59WWPNotificationDefinitionLongDescription = new string[] {""} ;
         BC00073_A60WWPNotificationDefinitionLink = new string[] {""} ;
         BC00073_A10WWPEntityId = new long[1] ;
         sMode7 = "";
         BC00072_A14WWPNotificationDefinitionId = new long[1] ;
         BC00072_A53WWPNotificationDefinitionName = new string[] {""} ;
         BC00072_A26WWPNotificationDefinitionAppliesTo = new short[1] ;
         BC00072_A27WWPNotificationDefinitionAllowUserSubscription = new bool[] {false} ;
         BC00072_A25WWPNotificationDefinitionDescription = new string[] {""} ;
         BC00072_A56WWPNotificationDefinitionIcon = new string[] {""} ;
         BC00072_A57WWPNotificationDefinitionTitle = new string[] {""} ;
         BC00072_A58WWPNotificationDefinitionShortDescription = new string[] {""} ;
         BC00072_A59WWPNotificationDefinitionLongDescription = new string[] {""} ;
         BC00072_A60WWPNotificationDefinitionLink = new string[] {""} ;
         BC00072_A10WWPEntityId = new long[1] ;
         BC00077_A14WWPNotificationDefinitionId = new long[1] ;
         BC000710_A12WWPEntityName = new string[] {""} ;
         BC000711_A16WWPNotificationId = new long[1] ;
         BC000712_A13WWPSubscriptionId = new long[1] ;
         BC000713_A14WWPNotificationDefinitionId = new long[1] ;
         BC000713_A53WWPNotificationDefinitionName = new string[] {""} ;
         BC000713_A26WWPNotificationDefinitionAppliesTo = new short[1] ;
         BC000713_A27WWPNotificationDefinitionAllowUserSubscription = new bool[] {false} ;
         BC000713_A25WWPNotificationDefinitionDescription = new string[] {""} ;
         BC000713_A56WWPNotificationDefinitionIcon = new string[] {""} ;
         BC000713_A57WWPNotificationDefinitionTitle = new string[] {""} ;
         BC000713_A58WWPNotificationDefinitionShortDescription = new string[] {""} ;
         BC000713_A59WWPNotificationDefinitionLongDescription = new string[] {""} ;
         BC000713_A60WWPNotificationDefinitionLink = new string[] {""} ;
         BC000713_A12WWPEntityName = new string[] {""} ;
         BC000713_A10WWPEntityId = new long[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notificationdefinition_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notificationdefinition_bc__default(),
            new Object[][] {
                new Object[] {
               BC00072_A14WWPNotificationDefinitionId, BC00072_A53WWPNotificationDefinitionName, BC00072_A26WWPNotificationDefinitionAppliesTo, BC00072_A27WWPNotificationDefinitionAllowUserSubscription, BC00072_A25WWPNotificationDefinitionDescription, BC00072_A56WWPNotificationDefinitionIcon, BC00072_A57WWPNotificationDefinitionTitle, BC00072_A58WWPNotificationDefinitionShortDescription, BC00072_A59WWPNotificationDefinitionLongDescription, BC00072_A60WWPNotificationDefinitionLink,
               BC00072_A10WWPEntityId
               }
               , new Object[] {
               BC00073_A14WWPNotificationDefinitionId, BC00073_A53WWPNotificationDefinitionName, BC00073_A26WWPNotificationDefinitionAppliesTo, BC00073_A27WWPNotificationDefinitionAllowUserSubscription, BC00073_A25WWPNotificationDefinitionDescription, BC00073_A56WWPNotificationDefinitionIcon, BC00073_A57WWPNotificationDefinitionTitle, BC00073_A58WWPNotificationDefinitionShortDescription, BC00073_A59WWPNotificationDefinitionLongDescription, BC00073_A60WWPNotificationDefinitionLink,
               BC00073_A10WWPEntityId
               }
               , new Object[] {
               BC00074_A12WWPEntityName
               }
               , new Object[] {
               BC00075_A14WWPNotificationDefinitionId, BC00075_A53WWPNotificationDefinitionName, BC00075_A26WWPNotificationDefinitionAppliesTo, BC00075_A27WWPNotificationDefinitionAllowUserSubscription, BC00075_A25WWPNotificationDefinitionDescription, BC00075_A56WWPNotificationDefinitionIcon, BC00075_A57WWPNotificationDefinitionTitle, BC00075_A58WWPNotificationDefinitionShortDescription, BC00075_A59WWPNotificationDefinitionLongDescription, BC00075_A60WWPNotificationDefinitionLink,
               BC00075_A12WWPEntityName, BC00075_A10WWPEntityId
               }
               , new Object[] {
               BC00076_A14WWPNotificationDefinitionId
               }
               , new Object[] {
               BC00077_A14WWPNotificationDefinitionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000710_A12WWPEntityName
               }
               , new Object[] {
               BC000711_A16WWPNotificationId
               }
               , new Object[] {
               BC000712_A13WWPSubscriptionId
               }
               , new Object[] {
               BC000713_A14WWPNotificationDefinitionId, BC000713_A53WWPNotificationDefinitionName, BC000713_A26WWPNotificationDefinitionAppliesTo, BC000713_A27WWPNotificationDefinitionAllowUserSubscription, BC000713_A25WWPNotificationDefinitionDescription, BC000713_A56WWPNotificationDefinitionIcon, BC000713_A57WWPNotificationDefinitionTitle, BC000713_A58WWPNotificationDefinitionShortDescription, BC000713_A59WWPNotificationDefinitionLongDescription, BC000713_A60WWPNotificationDefinitionLink,
               BC000713_A12WWPEntityName, BC000713_A10WWPEntityId
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
      private short Z26WWPNotificationDefinitionAppliesTo ;
      private short A26WWPNotificationDefinitionAppliesTo ;
      private short RcdFound7 ;
      private short nIsDirty_7 ;
      private int trnEnded ;
      private long Z14WWPNotificationDefinitionId ;
      private long A14WWPNotificationDefinitionId ;
      private long Z10WWPEntityId ;
      private long A10WWPEntityId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode7 ;
      private bool Z27WWPNotificationDefinitionAllowUserSubscription ;
      private bool A27WWPNotificationDefinitionAllowUserSubscription ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private string Z53WWPNotificationDefinitionName ;
      private string A53WWPNotificationDefinitionName ;
      private string Z25WWPNotificationDefinitionDescription ;
      private string A25WWPNotificationDefinitionDescription ;
      private string Z56WWPNotificationDefinitionIcon ;
      private string A56WWPNotificationDefinitionIcon ;
      private string Z57WWPNotificationDefinitionTitle ;
      private string A57WWPNotificationDefinitionTitle ;
      private string Z58WWPNotificationDefinitionShortDescription ;
      private string A58WWPNotificationDefinitionShortDescription ;
      private string Z59WWPNotificationDefinitionLongDescription ;
      private string A59WWPNotificationDefinitionLongDescription ;
      private string Z60WWPNotificationDefinitionLink ;
      private string A60WWPNotificationDefinitionLink ;
      private string Z12WWPEntityName ;
      private string A12WWPEntityName ;
      private GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC00075_A14WWPNotificationDefinitionId ;
      private string[] BC00075_A53WWPNotificationDefinitionName ;
      private short[] BC00075_A26WWPNotificationDefinitionAppliesTo ;
      private bool[] BC00075_A27WWPNotificationDefinitionAllowUserSubscription ;
      private string[] BC00075_A25WWPNotificationDefinitionDescription ;
      private string[] BC00075_A56WWPNotificationDefinitionIcon ;
      private string[] BC00075_A57WWPNotificationDefinitionTitle ;
      private string[] BC00075_A58WWPNotificationDefinitionShortDescription ;
      private string[] BC00075_A59WWPNotificationDefinitionLongDescription ;
      private string[] BC00075_A60WWPNotificationDefinitionLink ;
      private string[] BC00075_A12WWPEntityName ;
      private long[] BC00075_A10WWPEntityId ;
      private string[] BC00074_A12WWPEntityName ;
      private long[] BC00076_A14WWPNotificationDefinitionId ;
      private long[] BC00073_A14WWPNotificationDefinitionId ;
      private string[] BC00073_A53WWPNotificationDefinitionName ;
      private short[] BC00073_A26WWPNotificationDefinitionAppliesTo ;
      private bool[] BC00073_A27WWPNotificationDefinitionAllowUserSubscription ;
      private string[] BC00073_A25WWPNotificationDefinitionDescription ;
      private string[] BC00073_A56WWPNotificationDefinitionIcon ;
      private string[] BC00073_A57WWPNotificationDefinitionTitle ;
      private string[] BC00073_A58WWPNotificationDefinitionShortDescription ;
      private string[] BC00073_A59WWPNotificationDefinitionLongDescription ;
      private string[] BC00073_A60WWPNotificationDefinitionLink ;
      private long[] BC00073_A10WWPEntityId ;
      private long[] BC00072_A14WWPNotificationDefinitionId ;
      private string[] BC00072_A53WWPNotificationDefinitionName ;
      private short[] BC00072_A26WWPNotificationDefinitionAppliesTo ;
      private bool[] BC00072_A27WWPNotificationDefinitionAllowUserSubscription ;
      private string[] BC00072_A25WWPNotificationDefinitionDescription ;
      private string[] BC00072_A56WWPNotificationDefinitionIcon ;
      private string[] BC00072_A57WWPNotificationDefinitionTitle ;
      private string[] BC00072_A58WWPNotificationDefinitionShortDescription ;
      private string[] BC00072_A59WWPNotificationDefinitionLongDescription ;
      private string[] BC00072_A60WWPNotificationDefinitionLink ;
      private long[] BC00072_A10WWPEntityId ;
      private long[] BC00077_A14WWPNotificationDefinitionId ;
      private string[] BC000710_A12WWPEntityName ;
      private long[] BC000711_A16WWPNotificationId ;
      private long[] BC000712_A13WWPSubscriptionId ;
      private long[] BC000713_A14WWPNotificationDefinitionId ;
      private string[] BC000713_A53WWPNotificationDefinitionName ;
      private short[] BC000713_A26WWPNotificationDefinitionAppliesTo ;
      private bool[] BC000713_A27WWPNotificationDefinitionAllowUserSubscription ;
      private string[] BC000713_A25WWPNotificationDefinitionDescription ;
      private string[] BC000713_A56WWPNotificationDefinitionIcon ;
      private string[] BC000713_A57WWPNotificationDefinitionTitle ;
      private string[] BC000713_A58WWPNotificationDefinitionShortDescription ;
      private string[] BC000713_A59WWPNotificationDefinitionLongDescription ;
      private string[] BC000713_A60WWPNotificationDefinitionLink ;
      private string[] BC000713_A12WWPEntityName ;
      private long[] BC000713_A10WWPEntityId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_notificationdefinition_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_notificationdefinition_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC00075;
        prmBC00075 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00074;
        prmBC00074 = new Object[] {
        new Object[] {"@WWPEntityId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00076;
        prmBC00076 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00073;
        prmBC00073 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00072;
        prmBC00072 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00077;
        prmBC00077 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionName",SqlDbType.NVarChar,100,0} ,
        new Object[] {"@WWPNotificationDefinitionAppliesTo",SqlDbType.SmallInt,1,0} ,
        new Object[] {"@WWPNotificationDefinitionAllowUserSubscription",SqlDbType.Bit,4,0} ,
        new Object[] {"@WWPNotificationDefinitionDescription",SqlDbType.NVarChar,200,0} ,
        new Object[] {"@WWPNotificationDefinitionIcon",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@WWPNotificationDefinitionTitle",SqlDbType.NVarChar,200,0} ,
        new Object[] {"@WWPNotificationDefinitionShortDescription",SqlDbType.NVarChar,200,0} ,
        new Object[] {"@WWPNotificationDefinitionLongDescription",SqlDbType.NVarChar,1000,0} ,
        new Object[] {"@WWPNotificationDefinitionLink",SqlDbType.NVarChar,1000,0} ,
        new Object[] {"@WWPEntityId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00078;
        prmBC00078 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionName",SqlDbType.NVarChar,100,0} ,
        new Object[] {"@WWPNotificationDefinitionAppliesTo",SqlDbType.SmallInt,1,0} ,
        new Object[] {"@WWPNotificationDefinitionAllowUserSubscription",SqlDbType.Bit,4,0} ,
        new Object[] {"@WWPNotificationDefinitionDescription",SqlDbType.NVarChar,200,0} ,
        new Object[] {"@WWPNotificationDefinitionIcon",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@WWPNotificationDefinitionTitle",SqlDbType.NVarChar,200,0} ,
        new Object[] {"@WWPNotificationDefinitionShortDescription",SqlDbType.NVarChar,200,0} ,
        new Object[] {"@WWPNotificationDefinitionLongDescription",SqlDbType.NVarChar,1000,0} ,
        new Object[] {"@WWPNotificationDefinitionLink",SqlDbType.NVarChar,1000,0} ,
        new Object[] {"@WWPEntityId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00079;
        prmBC00079 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000710;
        prmBC000710 = new Object[] {
        new Object[] {"@WWPEntityId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000711;
        prmBC000711 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000712;
        prmBC000712 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000713;
        prmBC000713 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        def= new CursorDef[] {
            new CursorDef("BC00072", "SELECT [WWPNotificationDefinitionId], [WWPNotificationDefinitionName], [WWPNotificationDefinitionAppliesTo], [WWPNotificationDefinitionAllowUserSubscription], [WWPNotificationDefinitionDescription], [WWPNotificationDefinitionIcon], [WWPNotificationDefinitionTitle], [WWPNotificationDefinitionShortDescription], [WWPNotificationDefinitionLongDescription], [WWPNotificationDefinitionLink], [WWPEntityId] FROM [WWP_NotificationDefinition] WITH (UPDLOCK) WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00072,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00073", "SELECT [WWPNotificationDefinitionId], [WWPNotificationDefinitionName], [WWPNotificationDefinitionAppliesTo], [WWPNotificationDefinitionAllowUserSubscription], [WWPNotificationDefinitionDescription], [WWPNotificationDefinitionIcon], [WWPNotificationDefinitionTitle], [WWPNotificationDefinitionShortDescription], [WWPNotificationDefinitionLongDescription], [WWPNotificationDefinitionLink], [WWPEntityId] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00073,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00074", "SELECT [WWPEntityName] FROM [WWP_Entity] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00074,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00075", "SELECT TM1.[WWPNotificationDefinitionId], TM1.[WWPNotificationDefinitionName], TM1.[WWPNotificationDefinitionAppliesTo], TM1.[WWPNotificationDefinitionAllowUserSubscription], TM1.[WWPNotificationDefinitionDescription], TM1.[WWPNotificationDefinitionIcon], TM1.[WWPNotificationDefinitionTitle], TM1.[WWPNotificationDefinitionShortDescription], TM1.[WWPNotificationDefinitionLongDescription], TM1.[WWPNotificationDefinitionLink], T2.[WWPEntityName], TM1.[WWPEntityId] FROM ([WWP_NotificationDefinition] TM1 INNER JOIN [WWP_Entity] T2 ON T2.[WWPEntityId] = TM1.[WWPEntityId]) WHERE TM1.[WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ORDER BY TM1.[WWPNotificationDefinitionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00075,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00076", "SELECT [WWPNotificationDefinitionId] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00076,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00077", "INSERT INTO [WWP_NotificationDefinition]([WWPNotificationDefinitionName], [WWPNotificationDefinitionAppliesTo], [WWPNotificationDefinitionAllowUserSubscription], [WWPNotificationDefinitionDescription], [WWPNotificationDefinitionIcon], [WWPNotificationDefinitionTitle], [WWPNotificationDefinitionShortDescription], [WWPNotificationDefinitionLongDescription], [WWPNotificationDefinitionLink], [WWPEntityId]) VALUES(@WWPNotificationDefinitionName, @WWPNotificationDefinitionAppliesTo, @WWPNotificationDefinitionAllowUserSubscription, @WWPNotificationDefinitionDescription, @WWPNotificationDefinitionIcon, @WWPNotificationDefinitionTitle, @WWPNotificationDefinitionShortDescription, @WWPNotificationDefinitionLongDescription, @WWPNotificationDefinitionLink, @WWPEntityId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmBC00077)
           ,new CursorDef("BC00078", "UPDATE [WWP_NotificationDefinition] SET [WWPNotificationDefinitionName]=@WWPNotificationDefinitionName, [WWPNotificationDefinitionAppliesTo]=@WWPNotificationDefinitionAppliesTo, [WWPNotificationDefinitionAllowUserSubscription]=@WWPNotificationDefinitionAllowUserSubscription, [WWPNotificationDefinitionDescription]=@WWPNotificationDefinitionDescription, [WWPNotificationDefinitionIcon]=@WWPNotificationDefinitionIcon, [WWPNotificationDefinitionTitle]=@WWPNotificationDefinitionTitle, [WWPNotificationDefinitionShortDescription]=@WWPNotificationDefinitionShortDescription, [WWPNotificationDefinitionLongDescription]=@WWPNotificationDefinitionLongDescription, [WWPNotificationDefinitionLink]=@WWPNotificationDefinitionLink, [WWPEntityId]=@WWPEntityId  WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId", GxErrorMask.GX_NOMASK,prmBC00078)
           ,new CursorDef("BC00079", "DELETE FROM [WWP_NotificationDefinition]  WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId", GxErrorMask.GX_NOMASK,prmBC00079)
           ,new CursorDef("BC000710", "SELECT [WWPEntityName] FROM [WWP_Entity] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000710,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000711", "SELECT TOP 1 [WWPNotificationId] FROM [WWP_Notification] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000711,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000712", "SELECT TOP 1 [WWPSubscriptionId] FROM [WWP_Subscription] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000712,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000713", "SELECT TM1.[WWPNotificationDefinitionId], TM1.[WWPNotificationDefinitionName], TM1.[WWPNotificationDefinitionAppliesTo], TM1.[WWPNotificationDefinitionAllowUserSubscription], TM1.[WWPNotificationDefinitionDescription], TM1.[WWPNotificationDefinitionIcon], TM1.[WWPNotificationDefinitionTitle], TM1.[WWPNotificationDefinitionShortDescription], TM1.[WWPNotificationDefinitionLongDescription], TM1.[WWPNotificationDefinitionLink], T2.[WWPEntityName], TM1.[WWPEntityId] FROM ([WWP_NotificationDefinition] TM1 INNER JOIN [WWP_Entity] T2 ON T2.[WWPEntityId] = TM1.[WWPEntityId]) WHERE TM1.[WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ORDER BY TM1.[WWPNotificationDefinitionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000713,100, GxCacheFrequency.OFF ,true,false )
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
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getShort(3);
              table[3][0] = rslt.getBool(4);
              table[4][0] = rslt.getVarchar(5);
              table[5][0] = rslt.getVarchar(6);
              table[6][0] = rslt.getVarchar(7);
              table[7][0] = rslt.getVarchar(8);
              table[8][0] = rslt.getVarchar(9);
              table[9][0] = rslt.getVarchar(10);
              table[10][0] = rslt.getLong(11);
              return;
           case 1 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getShort(3);
              table[3][0] = rslt.getBool(4);
              table[4][0] = rslt.getVarchar(5);
              table[5][0] = rslt.getVarchar(6);
              table[6][0] = rslt.getVarchar(7);
              table[7][0] = rslt.getVarchar(8);
              table[8][0] = rslt.getVarchar(9);
              table[9][0] = rslt.getVarchar(10);
              table[10][0] = rslt.getLong(11);
              return;
           case 2 :
              table[0][0] = rslt.getVarchar(1);
              return;
           case 3 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getShort(3);
              table[3][0] = rslt.getBool(4);
              table[4][0] = rslt.getVarchar(5);
              table[5][0] = rslt.getVarchar(6);
              table[6][0] = rslt.getVarchar(7);
              table[7][0] = rslt.getVarchar(8);
              table[8][0] = rslt.getVarchar(9);
              table[9][0] = rslt.getVarchar(10);
              table[10][0] = rslt.getVarchar(11);
              table[11][0] = rslt.getLong(12);
              return;
           case 4 :
              table[0][0] = rslt.getLong(1);
              return;
           case 5 :
              table[0][0] = rslt.getLong(1);
              return;
           case 8 :
              table[0][0] = rslt.getVarchar(1);
              return;
           case 9 :
              table[0][0] = rslt.getLong(1);
              return;
           case 10 :
              table[0][0] = rslt.getLong(1);
              return;
           case 11 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getShort(3);
              table[3][0] = rslt.getBool(4);
              table[4][0] = rslt.getVarchar(5);
              table[5][0] = rslt.getVarchar(6);
              table[6][0] = rslt.getVarchar(7);
              table[7][0] = rslt.getVarchar(8);
              table[8][0] = rslt.getVarchar(9);
              table[9][0] = rslt.getVarchar(10);
              table[10][0] = rslt.getVarchar(11);
              table[11][0] = rslt.getLong(12);
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
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 1 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 2 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 3 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 4 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 5 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (short)parms[1]);
              stmt.SetParameter(3, (bool)parms[2]);
              stmt.SetParameter(4, (string)parms[3]);
              stmt.SetParameter(5, (string)parms[4]);
              stmt.SetParameter(6, (string)parms[5]);
              stmt.SetParameter(7, (string)parms[6]);
              stmt.SetParameter(8, (string)parms[7]);
              stmt.SetParameter(9, (string)parms[8]);
              stmt.SetParameter(10, (long)parms[9]);
              return;
           case 6 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (short)parms[1]);
              stmt.SetParameter(3, (bool)parms[2]);
              stmt.SetParameter(4, (string)parms[3]);
              stmt.SetParameter(5, (string)parms[4]);
              stmt.SetParameter(6, (string)parms[5]);
              stmt.SetParameter(7, (string)parms[6]);
              stmt.SetParameter(8, (string)parms[7]);
              stmt.SetParameter(9, (string)parms[8]);
              stmt.SetParameter(10, (long)parms[9]);
              stmt.SetParameter(11, (long)parms[10]);
              return;
           case 7 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 8 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 9 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 10 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 11 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
     }
  }

}

}
