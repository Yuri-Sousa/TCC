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
namespace GeneXus.Programs.wwpbaseobjects.mail {
   public class wwp_mailtemplate_bc : GXHttpHandler, IGxSilentTrn
   {
      public wwp_mailtemplate_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_mailtemplate_bc( IGxContext context )
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
         ReadRow099( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey099( ) ;
         standaloneModal( ) ;
         AddRow099( ) ;
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
            E11092 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z19WWPMailTemplateName = A19WWPMailTemplateName;
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

      protected void CONFIRM_090( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls099( ) ;
            }
            else
            {
               CheckExtendedTable099( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors099( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12092( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11092( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM099( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z79WWPMailTemplateDescription = A79WWPMailTemplateDescription;
            Z80WWPMailTemplateSubject = A80WWPMailTemplateSubject;
         }
         if ( GX_JID == -1 )
         {
            Z19WWPMailTemplateName = A19WWPMailTemplateName;
            Z79WWPMailTemplateDescription = A79WWPMailTemplateDescription;
            Z80WWPMailTemplateSubject = A80WWPMailTemplateSubject;
            Z65WWPMailTemplateBody = A65WWPMailTemplateBody;
            Z66WWPMailTemplateSenderAddress = A66WWPMailTemplateSenderAddress;
            Z67WWPMailTemplateSenderName = A67WWPMailTemplateSenderName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load099( )
      {
         /* Using cursor BC00094 */
         pr_default.execute(2, new Object[] {A19WWPMailTemplateName});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound9 = 1;
            A79WWPMailTemplateDescription = BC00094_A79WWPMailTemplateDescription[0];
            A80WWPMailTemplateSubject = BC00094_A80WWPMailTemplateSubject[0];
            A65WWPMailTemplateBody = BC00094_A65WWPMailTemplateBody[0];
            A66WWPMailTemplateSenderAddress = BC00094_A66WWPMailTemplateSenderAddress[0];
            A67WWPMailTemplateSenderName = BC00094_A67WWPMailTemplateSenderName[0];
            ZM099( -1) ;
         }
         pr_default.close(2);
         OnLoadActions099( ) ;
      }

      protected void OnLoadActions099( )
      {
      }

      protected void CheckExtendedTable099( )
      {
         nIsDirty_9 = 0;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors099( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey099( )
      {
         /* Using cursor BC00095 */
         pr_default.execute(3, new Object[] {A19WWPMailTemplateName});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00093 */
         pr_default.execute(1, new Object[] {A19WWPMailTemplateName});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM099( 1) ;
            RcdFound9 = 1;
            A19WWPMailTemplateName = BC00093_A19WWPMailTemplateName[0];
            A79WWPMailTemplateDescription = BC00093_A79WWPMailTemplateDescription[0];
            A80WWPMailTemplateSubject = BC00093_A80WWPMailTemplateSubject[0];
            A65WWPMailTemplateBody = BC00093_A65WWPMailTemplateBody[0];
            A66WWPMailTemplateSenderAddress = BC00093_A66WWPMailTemplateSenderAddress[0];
            A67WWPMailTemplateSenderName = BC00093_A67WWPMailTemplateSenderName[0];
            Z19WWPMailTemplateName = A19WWPMailTemplateName;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load099( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey099( ) ;
            }
            Gx_mode = sMode9;
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey099( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode9;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey099( ) ;
         if ( RcdFound9 == 0 )
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
         CONFIRM_090( ) ;
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

      protected void CheckOptimisticConcurrency099( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00092 */
            pr_default.execute(0, new Object[] {A19WWPMailTemplateName});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_MailTemplate"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z79WWPMailTemplateDescription, BC00092_A79WWPMailTemplateDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z80WWPMailTemplateSubject, BC00092_A80WWPMailTemplateSubject[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_MailTemplate"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert099( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable099( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM099( 0) ;
            CheckOptimisticConcurrency099( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm099( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert099( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00096 */
                     pr_default.execute(4, new Object[] {A19WWPMailTemplateName, A79WWPMailTemplateDescription, A80WWPMailTemplateSubject, A65WWPMailTemplateBody, A66WWPMailTemplateSenderAddress, A67WWPMailTemplateSenderName});
                     pr_default.close(4);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_MailTemplate");
                     if ( (pr_default.getStatus(4) == 1) )
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
               Load099( ) ;
            }
            EndLevel099( ) ;
         }
         CloseExtendedTableCursors099( ) ;
      }

      protected void Update099( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable099( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency099( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm099( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate099( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00097 */
                     pr_default.execute(5, new Object[] {A79WWPMailTemplateDescription, A80WWPMailTemplateSubject, A65WWPMailTemplateBody, A66WWPMailTemplateSenderAddress, A67WWPMailTemplateSenderName, A19WWPMailTemplateName});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_MailTemplate");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_MailTemplate"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate099( ) ;
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
            EndLevel099( ) ;
         }
         CloseExtendedTableCursors099( ) ;
      }

      protected void DeferredUpdate099( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency099( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls099( ) ;
            AfterConfirm099( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete099( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00098 */
                  pr_default.execute(6, new Object[] {A19WWPMailTemplateName});
                  pr_default.close(6);
                  dsDefault.SmartCacheProvider.SetUpdated("WWP_MailTemplate");
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
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel099( ) ;
         Gx_mode = sMode9;
      }

      protected void OnDeleteControls099( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel099( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete099( ) ;
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

      public void ScanKeyStart099( )
      {
         /* Using cursor BC00099 */
         pr_default.execute(7, new Object[] {A19WWPMailTemplateName});
         RcdFound9 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound9 = 1;
            A19WWPMailTemplateName = BC00099_A19WWPMailTemplateName[0];
            A79WWPMailTemplateDescription = BC00099_A79WWPMailTemplateDescription[0];
            A80WWPMailTemplateSubject = BC00099_A80WWPMailTemplateSubject[0];
            A65WWPMailTemplateBody = BC00099_A65WWPMailTemplateBody[0];
            A66WWPMailTemplateSenderAddress = BC00099_A66WWPMailTemplateSenderAddress[0];
            A67WWPMailTemplateSenderName = BC00099_A67WWPMailTemplateSenderName[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext099( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound9 = 0;
         ScanKeyLoad099( ) ;
      }

      protected void ScanKeyLoad099( )
      {
         sMode9 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound9 = 1;
            A19WWPMailTemplateName = BC00099_A19WWPMailTemplateName[0];
            A79WWPMailTemplateDescription = BC00099_A79WWPMailTemplateDescription[0];
            A80WWPMailTemplateSubject = BC00099_A80WWPMailTemplateSubject[0];
            A65WWPMailTemplateBody = BC00099_A65WWPMailTemplateBody[0];
            A66WWPMailTemplateSenderAddress = BC00099_A66WWPMailTemplateSenderAddress[0];
            A67WWPMailTemplateSenderName = BC00099_A67WWPMailTemplateSenderName[0];
         }
         Gx_mode = sMode9;
      }

      protected void ScanKeyEnd099( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm099( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert099( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate099( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete099( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete099( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate099( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes099( )
      {
      }

      protected void send_integrity_lvl_hashes099( )
      {
      }

      protected void AddRow099( )
      {
         VarsToRow9( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
      }

      protected void ReadRow099( )
      {
         RowToVars9( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
      }

      protected void InitializeNonKey099( )
      {
         A79WWPMailTemplateDescription = "";
         A80WWPMailTemplateSubject = "";
         A65WWPMailTemplateBody = "";
         A66WWPMailTemplateSenderAddress = "";
         A67WWPMailTemplateSenderName = "";
         Z79WWPMailTemplateDescription = "";
         Z80WWPMailTemplateSubject = "";
      }

      protected void InitAll099( )
      {
         A19WWPMailTemplateName = "";
         InitializeNonKey099( ) ;
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

      public void VarsToRow9( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate obj9 )
      {
         obj9.gxTpr_Mode = Gx_mode;
         obj9.gxTpr_Wwpmailtemplatedescription = A79WWPMailTemplateDescription;
         obj9.gxTpr_Wwpmailtemplatesubject = A80WWPMailTemplateSubject;
         obj9.gxTpr_Wwpmailtemplatebody = A65WWPMailTemplateBody;
         obj9.gxTpr_Wwpmailtemplatesenderaddress = A66WWPMailTemplateSenderAddress;
         obj9.gxTpr_Wwpmailtemplatesendername = A67WWPMailTemplateSenderName;
         obj9.gxTpr_Wwpmailtemplatename = A19WWPMailTemplateName;
         obj9.gxTpr_Wwpmailtemplatename_Z = Z19WWPMailTemplateName;
         obj9.gxTpr_Wwpmailtemplatedescription_Z = Z79WWPMailTemplateDescription;
         obj9.gxTpr_Wwpmailtemplatesubject_Z = Z80WWPMailTemplateSubject;
         obj9.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow9( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate obj9 )
      {
         obj9.gxTpr_Wwpmailtemplatename = A19WWPMailTemplateName;
         return  ;
      }

      public void RowToVars9( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate obj9 ,
                              int forceLoad )
      {
         Gx_mode = obj9.gxTpr_Mode;
         A79WWPMailTemplateDescription = obj9.gxTpr_Wwpmailtemplatedescription;
         A80WWPMailTemplateSubject = obj9.gxTpr_Wwpmailtemplatesubject;
         A65WWPMailTemplateBody = obj9.gxTpr_Wwpmailtemplatebody;
         A66WWPMailTemplateSenderAddress = obj9.gxTpr_Wwpmailtemplatesenderaddress;
         A67WWPMailTemplateSenderName = obj9.gxTpr_Wwpmailtemplatesendername;
         A19WWPMailTemplateName = obj9.gxTpr_Wwpmailtemplatename;
         Z19WWPMailTemplateName = obj9.gxTpr_Wwpmailtemplatename_Z;
         Z79WWPMailTemplateDescription = obj9.gxTpr_Wwpmailtemplatedescription_Z;
         Z80WWPMailTemplateSubject = obj9.gxTpr_Wwpmailtemplatesubject_Z;
         Gx_mode = obj9.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A19WWPMailTemplateName = (string)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey099( ) ;
         ScanKeyStart099( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z19WWPMailTemplateName = A19WWPMailTemplateName;
         }
         ZM099( -1) ;
         OnLoadActions099( ) ;
         AddRow099( ) ;
         ScanKeyEnd099( ) ;
         if ( RcdFound9 == 0 )
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
         RowToVars9( bcwwpbaseobjects_mail_WWP_MailTemplate, 0) ;
         ScanKeyStart099( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z19WWPMailTemplateName = A19WWPMailTemplateName;
         }
         ZM099( -1) ;
         OnLoadActions099( ) ;
         AddRow099( ) ;
         ScanKeyEnd099( ) ;
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey099( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert099( ) ;
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( StringUtil.StrCmp(A19WWPMailTemplateName, Z19WWPMailTemplateName) != 0 )
               {
                  A19WWPMailTemplateName = Z19WWPMailTemplateName;
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
                  Update099( ) ;
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
                  if ( StringUtil.StrCmp(A19WWPMailTemplateName, Z19WWPMailTemplateName) != 0 )
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
                        Insert099( ) ;
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
                        Insert099( ) ;
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
         RowToVars9( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
         SaveImpl( ) ;
         VarsToRow9( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
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
         RowToVars9( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert099( ) ;
         AfterTrn( ) ;
         VarsToRow9( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
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
            GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate auxBC = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A19WWPMailTemplateName);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_mail_WWP_MailTemplate);
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
         RowToVars9( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
         UpdateImpl( ) ;
         VarsToRow9( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
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
         RowToVars9( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert099( ) ;
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
         VarsToRow9( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars9( bcwwpbaseobjects_mail_WWP_MailTemplate, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey099( ) ;
         if ( RcdFound9 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( StringUtil.StrCmp(A19WWPMailTemplateName, Z19WWPMailTemplateName) != 0 )
            {
               A19WWPMailTemplateName = Z19WWPMailTemplateName;
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
            if ( StringUtil.StrCmp(A19WWPMailTemplateName, Z19WWPMailTemplateName) != 0 )
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
         context.RollbackDataStores("wwpbaseobjects.mail.wwp_mailtemplate_bc",pr_default);
         VarsToRow9( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
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
         Gx_mode = bcwwpbaseobjects_mail_WWP_MailTemplate.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_mail_WWP_MailTemplate.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_mail_WWP_MailTemplate )
         {
            bcwwpbaseobjects_mail_WWP_MailTemplate = (GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_mail_WWP_MailTemplate.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_mail_WWP_MailTemplate.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow9( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
            }
            else
            {
               RowToVars9( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_mail_WWP_MailTemplate.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_mail_WWP_MailTemplate.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars9( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtWWP_MailTemplate WWP_MailTemplate_BC
      {
         get {
            return bcwwpbaseobjects_mail_WWP_MailTemplate ;
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
            return "wwpmailtemplate_Execute" ;
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
         Z19WWPMailTemplateName = "";
         A19WWPMailTemplateName = "";
         Z79WWPMailTemplateDescription = "";
         A79WWPMailTemplateDescription = "";
         Z80WWPMailTemplateSubject = "";
         A80WWPMailTemplateSubject = "";
         Z65WWPMailTemplateBody = "";
         A65WWPMailTemplateBody = "";
         Z66WWPMailTemplateSenderAddress = "";
         A66WWPMailTemplateSenderAddress = "";
         Z67WWPMailTemplateSenderName = "";
         A67WWPMailTemplateSenderName = "";
         BC00094_A19WWPMailTemplateName = new string[] {""} ;
         BC00094_A79WWPMailTemplateDescription = new string[] {""} ;
         BC00094_A80WWPMailTemplateSubject = new string[] {""} ;
         BC00094_A65WWPMailTemplateBody = new string[] {""} ;
         BC00094_A66WWPMailTemplateSenderAddress = new string[] {""} ;
         BC00094_A67WWPMailTemplateSenderName = new string[] {""} ;
         BC00095_A19WWPMailTemplateName = new string[] {""} ;
         BC00093_A19WWPMailTemplateName = new string[] {""} ;
         BC00093_A79WWPMailTemplateDescription = new string[] {""} ;
         BC00093_A80WWPMailTemplateSubject = new string[] {""} ;
         BC00093_A65WWPMailTemplateBody = new string[] {""} ;
         BC00093_A66WWPMailTemplateSenderAddress = new string[] {""} ;
         BC00093_A67WWPMailTemplateSenderName = new string[] {""} ;
         sMode9 = "";
         BC00092_A19WWPMailTemplateName = new string[] {""} ;
         BC00092_A79WWPMailTemplateDescription = new string[] {""} ;
         BC00092_A80WWPMailTemplateSubject = new string[] {""} ;
         BC00092_A65WWPMailTemplateBody = new string[] {""} ;
         BC00092_A66WWPMailTemplateSenderAddress = new string[] {""} ;
         BC00092_A67WWPMailTemplateSenderName = new string[] {""} ;
         BC00099_A19WWPMailTemplateName = new string[] {""} ;
         BC00099_A79WWPMailTemplateDescription = new string[] {""} ;
         BC00099_A80WWPMailTemplateSubject = new string[] {""} ;
         BC00099_A65WWPMailTemplateBody = new string[] {""} ;
         BC00099_A66WWPMailTemplateSenderAddress = new string[] {""} ;
         BC00099_A67WWPMailTemplateSenderName = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mailtemplate_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mailtemplate_bc__default(),
            new Object[][] {
                new Object[] {
               BC00092_A19WWPMailTemplateName, BC00092_A79WWPMailTemplateDescription, BC00092_A80WWPMailTemplateSubject, BC00092_A65WWPMailTemplateBody, BC00092_A66WWPMailTemplateSenderAddress, BC00092_A67WWPMailTemplateSenderName
               }
               , new Object[] {
               BC00093_A19WWPMailTemplateName, BC00093_A79WWPMailTemplateDescription, BC00093_A80WWPMailTemplateSubject, BC00093_A65WWPMailTemplateBody, BC00093_A66WWPMailTemplateSenderAddress, BC00093_A67WWPMailTemplateSenderName
               }
               , new Object[] {
               BC00094_A19WWPMailTemplateName, BC00094_A79WWPMailTemplateDescription, BC00094_A80WWPMailTemplateSubject, BC00094_A65WWPMailTemplateBody, BC00094_A66WWPMailTemplateSenderAddress, BC00094_A67WWPMailTemplateSenderName
               }
               , new Object[] {
               BC00095_A19WWPMailTemplateName
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC00099_A19WWPMailTemplateName, BC00099_A79WWPMailTemplateDescription, BC00099_A80WWPMailTemplateSubject, BC00099_A65WWPMailTemplateBody, BC00099_A66WWPMailTemplateSenderAddress, BC00099_A67WWPMailTemplateSenderName
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12092 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short RcdFound9 ;
      private short nIsDirty_9 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode9 ;
      private bool returnInSub ;
      private bool mustCommit ;
      private string Z65WWPMailTemplateBody ;
      private string A65WWPMailTemplateBody ;
      private string Z66WWPMailTemplateSenderAddress ;
      private string A66WWPMailTemplateSenderAddress ;
      private string Z67WWPMailTemplateSenderName ;
      private string A67WWPMailTemplateSenderName ;
      private string Z19WWPMailTemplateName ;
      private string A19WWPMailTemplateName ;
      private string Z79WWPMailTemplateDescription ;
      private string A79WWPMailTemplateDescription ;
      private string Z80WWPMailTemplateSubject ;
      private string A80WWPMailTemplateSubject ;
      private GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate bcwwpbaseobjects_mail_WWP_MailTemplate ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC00094_A19WWPMailTemplateName ;
      private string[] BC00094_A79WWPMailTemplateDescription ;
      private string[] BC00094_A80WWPMailTemplateSubject ;
      private string[] BC00094_A65WWPMailTemplateBody ;
      private string[] BC00094_A66WWPMailTemplateSenderAddress ;
      private string[] BC00094_A67WWPMailTemplateSenderName ;
      private string[] BC00095_A19WWPMailTemplateName ;
      private string[] BC00093_A19WWPMailTemplateName ;
      private string[] BC00093_A79WWPMailTemplateDescription ;
      private string[] BC00093_A80WWPMailTemplateSubject ;
      private string[] BC00093_A65WWPMailTemplateBody ;
      private string[] BC00093_A66WWPMailTemplateSenderAddress ;
      private string[] BC00093_A67WWPMailTemplateSenderName ;
      private string[] BC00092_A19WWPMailTemplateName ;
      private string[] BC00092_A79WWPMailTemplateDescription ;
      private string[] BC00092_A80WWPMailTemplateSubject ;
      private string[] BC00092_A65WWPMailTemplateBody ;
      private string[] BC00092_A66WWPMailTemplateSenderAddress ;
      private string[] BC00092_A67WWPMailTemplateSenderName ;
      private string[] BC00099_A19WWPMailTemplateName ;
      private string[] BC00099_A79WWPMailTemplateDescription ;
      private string[] BC00099_A80WWPMailTemplateSubject ;
      private string[] BC00099_A65WWPMailTemplateBody ;
      private string[] BC00099_A66WWPMailTemplateSenderAddress ;
      private string[] BC00099_A67WWPMailTemplateSenderName ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_mailtemplate_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_mailtemplate_bc__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new UpdateCursor(def[4])
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
        Object[] prmBC00094;
        prmBC00094 = new Object[] {
        new Object[] {"@WWPMailTemplateName",SqlDbType.NVarChar,40,0}
        };
        Object[] prmBC00095;
        prmBC00095 = new Object[] {
        new Object[] {"@WWPMailTemplateName",SqlDbType.NVarChar,40,0}
        };
        Object[] prmBC00093;
        prmBC00093 = new Object[] {
        new Object[] {"@WWPMailTemplateName",SqlDbType.NVarChar,40,0}
        };
        Object[] prmBC00092;
        prmBC00092 = new Object[] {
        new Object[] {"@WWPMailTemplateName",SqlDbType.NVarChar,40,0}
        };
        Object[] prmBC00096;
        prmBC00096 = new Object[] {
        new Object[] {"@WWPMailTemplateName",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@WWPMailTemplateDescription",SqlDbType.NVarChar,100,0} ,
        new Object[] {"@WWPMailTemplateSubject",SqlDbType.NVarChar,80,0} ,
        new Object[] {"@WWPMailTemplateBody",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailTemplateSenderAddress",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailTemplateSenderName",SqlDbType.NVarChar,2097152,0}
        };
        Object[] prmBC00097;
        prmBC00097 = new Object[] {
        new Object[] {"@WWPMailTemplateDescription",SqlDbType.NVarChar,100,0} ,
        new Object[] {"@WWPMailTemplateSubject",SqlDbType.NVarChar,80,0} ,
        new Object[] {"@WWPMailTemplateBody",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailTemplateSenderAddress",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailTemplateSenderName",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailTemplateName",SqlDbType.NVarChar,40,0}
        };
        Object[] prmBC00098;
        prmBC00098 = new Object[] {
        new Object[] {"@WWPMailTemplateName",SqlDbType.NVarChar,40,0}
        };
        Object[] prmBC00099;
        prmBC00099 = new Object[] {
        new Object[] {"@WWPMailTemplateName",SqlDbType.NVarChar,40,0}
        };
        def= new CursorDef[] {
            new CursorDef("BC00092", "SELECT [WWPMailTemplateName], [WWPMailTemplateDescription], [WWPMailTemplateSubject], [WWPMailTemplateBody], [WWPMailTemplateSenderAddress], [WWPMailTemplateSenderName] FROM [WWP_MailTemplate] WITH (UPDLOCK) WHERE [WWPMailTemplateName] = @WWPMailTemplateName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00092,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00093", "SELECT [WWPMailTemplateName], [WWPMailTemplateDescription], [WWPMailTemplateSubject], [WWPMailTemplateBody], [WWPMailTemplateSenderAddress], [WWPMailTemplateSenderName] FROM [WWP_MailTemplate] WHERE [WWPMailTemplateName] = @WWPMailTemplateName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00093,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00094", "SELECT TM1.[WWPMailTemplateName], TM1.[WWPMailTemplateDescription], TM1.[WWPMailTemplateSubject], TM1.[WWPMailTemplateBody], TM1.[WWPMailTemplateSenderAddress], TM1.[WWPMailTemplateSenderName] FROM [WWP_MailTemplate] TM1 WHERE TM1.[WWPMailTemplateName] = @WWPMailTemplateName ORDER BY TM1.[WWPMailTemplateName]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00094,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00095", "SELECT [WWPMailTemplateName] FROM [WWP_MailTemplate] WHERE [WWPMailTemplateName] = @WWPMailTemplateName  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00095,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00096", "INSERT INTO [WWP_MailTemplate]([WWPMailTemplateName], [WWPMailTemplateDescription], [WWPMailTemplateSubject], [WWPMailTemplateBody], [WWPMailTemplateSenderAddress], [WWPMailTemplateSenderName]) VALUES(@WWPMailTemplateName, @WWPMailTemplateDescription, @WWPMailTemplateSubject, @WWPMailTemplateBody, @WWPMailTemplateSenderAddress, @WWPMailTemplateSenderName)", GxErrorMask.GX_NOMASK,prmBC00096)
           ,new CursorDef("BC00097", "UPDATE [WWP_MailTemplate] SET [WWPMailTemplateDescription]=@WWPMailTemplateDescription, [WWPMailTemplateSubject]=@WWPMailTemplateSubject, [WWPMailTemplateBody]=@WWPMailTemplateBody, [WWPMailTemplateSenderAddress]=@WWPMailTemplateSenderAddress, [WWPMailTemplateSenderName]=@WWPMailTemplateSenderName  WHERE [WWPMailTemplateName] = @WWPMailTemplateName", GxErrorMask.GX_NOMASK,prmBC00097)
           ,new CursorDef("BC00098", "DELETE FROM [WWP_MailTemplate]  WHERE [WWPMailTemplateName] = @WWPMailTemplateName", GxErrorMask.GX_NOMASK,prmBC00098)
           ,new CursorDef("BC00099", "SELECT TM1.[WWPMailTemplateName], TM1.[WWPMailTemplateDescription], TM1.[WWPMailTemplateSubject], TM1.[WWPMailTemplateBody], TM1.[WWPMailTemplateSenderAddress], TM1.[WWPMailTemplateSenderName] FROM [WWP_MailTemplate] TM1 WHERE TM1.[WWPMailTemplateName] = @WWPMailTemplateName ORDER BY TM1.[WWPMailTemplateName]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00099,100, GxCacheFrequency.OFF ,true,false )
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
              table[0][0] = rslt.getVarchar(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getLongVarchar(4);
              table[4][0] = rslt.getLongVarchar(5);
              table[5][0] = rslt.getLongVarchar(6);
              return;
           case 1 :
              table[0][0] = rslt.getVarchar(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getLongVarchar(4);
              table[4][0] = rslt.getLongVarchar(5);
              table[5][0] = rslt.getLongVarchar(6);
              return;
           case 2 :
              table[0][0] = rslt.getVarchar(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getLongVarchar(4);
              table[4][0] = rslt.getLongVarchar(5);
              table[5][0] = rslt.getLongVarchar(6);
              return;
           case 3 :
              table[0][0] = rslt.getVarchar(1);
              return;
           case 7 :
              table[0][0] = rslt.getVarchar(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getLongVarchar(4);
              table[4][0] = rslt.getLongVarchar(5);
              table[5][0] = rslt.getLongVarchar(6);
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
              stmt.SetParameter(1, (string)parms[0]);
              return;
           case 3 :
              stmt.SetParameter(1, (string)parms[0]);
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
              return;
           case 6 :
              stmt.SetParameter(1, (string)parms[0]);
              return;
           case 7 :
              stmt.SetParameter(1, (string)parms[0]);
              return;
     }
  }

}

}
