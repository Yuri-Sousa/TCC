using System;
using GeneXus.Builder;
using System.IO;
public class bldaexportrelatorioposicaopdf : GxBaseBuilder
{
   string cs_path = "." ;
   public bldaexportrelatorioposicaopdf( ) : base()
   {
   }

   public override int BeforeCompile( )
   {
      return 0 ;
   }

   public override int AfterCompile( )
   {
      int ErrCode;
      ErrCode = 0;
      return ErrCode ;
   }

   static public int Main( string[] args )
   {
      bldaexportrelatorioposicaopdf x = new bldaexportrelatorioposicaopdf() ;
      x.SetMainSourceFile( "aexportrelatorioposicaopdf.cs");
      x.LoadVariables( args);
      return x.CompileAll( );
   }

   public override ItemCollection GetSortedBuildList( )
   {
      ItemCollection sc = new ItemCollection() ;
      sc.Add( @"bin\GeneXus.Programs.Common.dll", cs_path + @"\genexus.programs.common.rsp");
      return sc ;
   }

   public override TargetCollection GetRuntimeBuildList( )
   {
      TargetCollection sc = new TargetCollection() ;
      sc.Add( @"aexportrelatorioposicaopdf", "dll");
      return sc ;
   }

   public override ItemCollection GetResBuildList( )
   {
      ItemCollection sc = new ItemCollection() ;
      sc.Add( @"bin\messages.por.dll", cs_path + @"\messages.por.txt");
      return sc ;
   }

   public override bool ToBuild( string obj )
   {
      if (checkTime(obj, cs_path + @"\bin\GxClasses.dll" ))
         return true;
      if ( obj == @"bin\GeneXus.Programs.Common.dll" )
      {
         if (checkTime(obj, cs_path + @"\GxWebStd.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\SoapParm.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\GxObjectCollection.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\GxFullTextSearchReindexer.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\GxModelInfoProvider.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\genexus.programs.sdt.rsp" ))
            return true;
         if (checkTime(obj, cs_path + @"\wwpbaseobjects\type_SdtWWP_UserExtended.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\wwpbaseobjects\type_SdtWWP_Entity.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\wwpbaseobjects\subscriptions\type_SdtWWP_Subscription.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\wwpbaseobjects\notifications\web\type_SdtWWP_WebClient.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\wwpbaseobjects\sms\type_SdtWWP_SMS.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\wwpbaseobjects\notifications\web\type_SdtWWP_WebNotification.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\wwpbaseobjects\notifications\common\type_SdtWWP_NotificationDefinition.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\wwpbaseobjects\mail\type_SdtWWP_MailTemplate.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\wwpbaseobjects\notifications\common\type_SdtWWP_Notification.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\wwpbaseobjects\discussions\type_SdtWWP_DiscussionMessage.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\wwpbaseobjects\discussions\type_SdtWWP_DiscussionMessageMention.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\wwpbaseobjects\mail\type_SdtWWP_Mail.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\wwpbaseobjects\mail\type_SdtWWP_Mail_Attachments.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtFrotaVeiculo.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtVeiculo.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtFrota.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtVeiculoRastreador.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtUltimoDadoLido.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtRastreador.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtComando.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtComandoEnviado.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtComandoEnviado_Comando.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtMQTT.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtMqttConfig.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtMqttStatus.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtUtil.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\gxdomainwwpdomains.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\gxdomainpage.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\gxdomainexporttype.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\wwpbaseobjects\gxdomainsplitscreen_action.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\gxdomainhomesampledatastatus.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\gxdomainwwpcardsmenusize.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\wwpbaseobjects\gxdomainwwpcardsmenuoptiontype.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\wwpbaseobjects\gxdomaindvmessageboolean.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\wwpbaseobjects\gxdomaindvmessageeffect.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\wwpbaseobjects\gxdomaindvmessagestyling.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\wwpbaseobjects\gxdomaindvmessagetype.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\gxdomainwwpdaterangepickerlocation.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\gxdomainwwpdaterangepickertype.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\gxdomainactiontexts.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\wwpbaseobjects\notifications\gxdomainwwp_notificationappliesto.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\wwpbaseobjects\sms\gxdomainwwp_statussms.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\wwpbaseobjects\notifications\web\gxdomainwwp_statuswebnotification.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\wwpbaseobjects\mail\gxdomainwwp_statusmail.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\gxdomainmqttdefault.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\gxdomainmqttqos.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\gxdomaindomfabricanterastreador.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\gxdomaindommodelorastreador.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\gxdomaindomoperadorachipgsm.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\gxdomaindomignicao.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\gxdomainqueryviewerxaxislabels.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\gxdomainqueryviewervisible.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\gxdomainqueryviewertrendperiod.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\gxdomainqueryviewersubtotals.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\gxdomainqueryviewershowdatalabelsin.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\gxdomainqueryviewershowdataas.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\gxdomainqueryviewerplotseries.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\gxdomainqueryvieweroutputtype.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\gxdomainqueryviewerorientation.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\gxdomainqueryvieweraxisordertype.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\gxdomainqueryviewerobjecttype.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\gxdomainqueryviewerfiltertype.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\gxdomainqueryviewerexpandcollapse.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\gxdomainqueryviewerelementtype.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\gxdomainqueryviewerconditionoperator.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\gxdomainqueryviewercharttype.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\gxdomainqueryvieweraxistype.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\gxdomainqueryvieweraggregationtype.cs" ))
            return true;
      }
      if ( obj == @"bin\messages.por.dll" )
      {
         if (checkTime(obj, cs_path + @"\messages.por.txt" ))
            return true;
      }
      return false ;
   }

}

