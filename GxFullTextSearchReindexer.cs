using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class GxFullTextSearchReindexer
   {
      public static int Reindex( IGxContext context )
      {
         GxSilentTrnSdt obj;
         IGxSilentTrn trn;
         bool result;
         obj = new GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtFrotaVeiculo(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtFrota(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtComando(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtVeiculoRastreador(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtComandoEnviado(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtUltimoDadoLido(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtVeiculo(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtRastreador(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         return 1 ;
      }

   }

}
