using System;
using GeneXus.Builder;
using System.IO;
public class bldDevelopermenu : GxBaseBuilder
{
   string cs_path = "." ;
   public bldDevelopermenu( ) : base()
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
      if ( ! File.Exists(@"bin\client.exe.config") || checkTime(@"bin\client.exe.config",cs_path + @"\client.exe.config") )
      {
         File.Copy( cs_path + @"\client.exe.config", @"bin\client.exe.config", true);
      }
      return ErrCode ;
   }

   static public int Main( string[] args )
   {
      bldDevelopermenu x = new bldDevelopermenu() ;
      x.SetMainSourceFile( "bldDevelopermenu.cs");
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
      sc.Add( @"wwpbaseobjects\awwp_impactmetadata", "exe");
      sc.Add( @"asecgamupdatepermissions", "exe");
      sc.Add( @"wwpbaseobjects\discussions\wwp_getusersfordiscussionmentions", "dll");
      sc.Add( @"asalvarultimodadolidodistribui", "dll");
      sc.Add( @"relatorioposicaoloaddvcombo", "dll");
      sc.Add( @"aexportrelatorioposicaopdf", "dll");
      sc.Add( @"aexportrelatorioposicaopdf", "dll");
      sc.Add( @"relatoriohorastrabalhadasloaddvcombo", "dll");
      sc.Add( @"aexportrelatoriodehorastrabalhadaspdf", "dll");
      sc.Add( @"aexportrelatoriodehorastrabalhadaspdf", "dll");
      sc.Add( @"debugtotext", "dll");
      sc.Add( @"debugtotext", "dll");
      sc.Add( @"relatorioutilizacaoloaddvcombo", "dll");
      sc.Add( @"aexportrelatoriodeutilizacaopdf", "dll");
      sc.Add( @"aexportrelatoriodeutilizacaopdf", "dll");
      sc.Add( @"wcenviarcomandoloaddvcombo", "dll");
      sc.Add( @"comandoenviadoloaddvcombo", "dll");
      sc.Add( @"enviarnotificacaowebsocket", "dll");
      sc.Add( @"mapaloaddvcombo", "dll");
      sc.Add( @"appmasterpage", "dll");
      sc.Add( @"recentlinks", "dll");
      sc.Add( @"promptmasterpage", "dll");
      sc.Add( @"rwdmasterpage", "dll");
      sc.Add( @"rwdrecentlinks", "dll");
      sc.Add( @"rwdpromptmasterpage", "dll");
      sc.Add( @"gamhome", "dll");
      sc.Add( @"gamhome", "dll");
      sc.Add( @"gamexamplelogin", "dll");
      sc.Add( @"gamchangepassword", "dll");
      sc.Add( @"gamupdateregisteruser", "dll");
      sc.Add( @"gamrecoverpasswordstep1", "dll");
      sc.Add( @"gamregisteruser", "dll");
      sc.Add( @"gamrecoverpasswordstep2", "dll");
      sc.Add( @"gamrecoverpasswordstep2", "dll");
      sc.Add( @"gamexamplenotauthorized", "dll");
      sc.Add( @"gamremotelogin", "dll");
      sc.Add( @"gamssologin", "dll");
      sc.Add( @"wwpbaseobjects\workwithplusmasterpageprompt", "dll");
      sc.Add( @"wwpbaseobjects\exportoptions", "dll");
      sc.Add( @"wwpbaseobjects\exportoptions", "dll");
      sc.Add( @"wwpbaseobjects\home", "dll");
      sc.Add( @"wwpbaseobjects\home", "dll");
      sc.Add( @"wwpbaseobjects\wizardstepsarrowwc", "dll");
      sc.Add( @"wwpbaseobjects\wizardstepsbulletwc", "dll");
      sc.Add( @"wwpbaseobjects\addressdisplay", "dll");
      sc.Add( @"wwpbaseobjects\managefilters", "dll");
      sc.Add( @"wwpbaseobjects\promptgeolocation", "dll");
      sc.Add( @"wwpbaseobjects\savefilteras", "dll");
      sc.Add( @"wwpbaseobjects\wwptabbedview", "dll");
      sc.Add( @"wwpbaseobjects\notauthorized", "dll");
      sc.Add( @"wwpbaseobjects\homeprogressbarcirclewc", "dll");
      sc.Add( @"wwpbaseobjects\homeprogressbarwc", "dll");
      sc.Add( @"wwpbaseobjects\wwp_selectimportfile", "dll");
      sc.Add( @"gamapplicationentry", "dll");
      sc.Add( @"gamwwapplications", "dll");
      sc.Add( @"gamapppermissionchildren", "dll");
      sc.Add( @"gamwwapppermissions", "dll");
      sc.Add( @"gamapppermissionentry", "dll");
      sc.Add( @"gamapppermissionselect", "dll");
      sc.Add( @"gamwcauthenticationtypeentryoauth20", "dll");
      sc.Add( @"gamwcauthenticationtypeentrygeneral", "dll");
      sc.Add( @"gamauthenticationtypeentry", "dll");
      sc.Add( @"gamwcauthenticationtypeentrysaml20", "dll");
      sc.Add( @"gamchangerepository", "dll");
      sc.Add( @"gamchangeyourpassword", "dll");
      sc.Add( @"gamconnectionentry", "dll");
      sc.Add( @"gamrepositoryconfiguration", "dll");
      sc.Add( @"gamrepositoryentry", "dll");
      sc.Add( @"gamroleentry", "dll");
      sc.Add( @"gamrolepermissionselect", "dll");
      sc.Add( @"gamwwrolepermissions", "dll");
      sc.Add( @"gamroleselect", "dll");
      sc.Add( @"gamsecuritypolicyentry", "dll");
      sc.Add( @"gamsetpassword", "dll");
      sc.Add( @"gamtestexternallogin", "dll");
      sc.Add( @"gamuserentry", "dll");
      sc.Add( @"gamuserroleselect", "dll");
      sc.Add( @"gamwwauthtypes", "dll");
      sc.Add( @"gamwwconnections", "dll");
      sc.Add( @"gamwwrepositories", "dll");
      sc.Add( @"gamwwroleroles", "dll");
      sc.Add( @"gamwwroles", "dll");
      sc.Add( @"gamwwsecuritypolicy", "dll");
      sc.Add( @"gamwwuserroles", "dll");
      sc.Add( @"gamwwusers", "dll");
      sc.Add( @"gamwwusers", "dll");
      sc.Add( @"gamwwuserpermissions", "dll");
      sc.Add( @"gamuserpermissionselect", "dll");
      sc.Add( @"gamwweventsubscriptions", "dll");
      sc.Add( @"gameventsubscriptionentry", "dll");
      sc.Add( @"gamappmenuentry", "dll");
      sc.Add( @"gamappmenuoptionentry", "dll");
      sc.Add( @"gamwwappmenus", "dll");
      sc.Add( @"gamwwappmenuoptions", "dll");
      sc.Add( @"wwpbaseobjects\notifications\common\wwp_visualizenotification", "dll");
      sc.Add( @"wwpbaseobjects\notifications\common\wwp_visualizenotification", "dll");
      sc.Add( @"wwpbaseobjects\subscriptions\wwp_subscriptionssettings", "dll");
      sc.Add( @"wwpbaseobjects\subscriptions\wwp_subscriptionssettingswc", "dll");
      sc.Add( @"wwpbaseobjects\subscriptions\wwp_subscriptionssettingsbyrole", "dll");
      sc.Add( @"wwpbaseobjects\subscriptions\wwp_subscriptionssettingsbyrolewc", "dll");
      sc.Add( @"wwpbaseobjects\notifications\common\wwp_visualizeallnotifications", "dll");
      sc.Add( @"wwpbaseobjects\subscriptions\wwp_subscriptionspanel", "dll");
      sc.Add( @"wwpbaseobjects\notifications\common\wwp_masterpagenotificationswc", "dll");
      sc.Add( @"wwpbaseobjects\discussions\wwp_discussionswc", "dll");
      sc.Add( @"wwpbaseobjects\discussions\wwp_discussionsonethreadcollapsedwc", "dll");
      sc.Add( @"wwpbaseobjects\discussions\wwp_discussionsonethreadwc", "dll");
      sc.Add( @"wwpbaseobjects\discussions\wwp_wcdummy", "dll");
      sc.Add( @"wwpbaseobjects\editbookmark", "dll");
      sc.Add( @"wwpbaseobjects\workwithplusmasterpage", "dll");
      sc.Add( @"mapa", "dll");
      sc.Add( @"mapa", "dll");
      sc.Add( @"homeiot", "dll");
      sc.Add( @"homeiot", "dll");
      sc.Add( @"mqttconnectionww", "dll");
      sc.Add( @"frotaww", "dll");
      sc.Add( @"veiculoww", "dll");
      sc.Add( @"associationfrotaveiculo", "dll");
      sc.Add( @"chipgsmww", "dll");
      sc.Add( @"rastreadorww", "dll");
      sc.Add( @"chipgsmprompt", "dll");
      sc.Add( @"ultimodadolidoww", "dll");
      sc.Add( @"associationveiculorastreador", "dll");
      sc.Add( @"mqttparametrosww", "dll");
      sc.Add( @"relatorioposicao", "dll");
      sc.Add( @"relatoriohorastrabalhadas", "dll");
      sc.Add( @"relatorioutilizacao", "dll");
      sc.Add( @"comandoww", "dll");
      sc.Add( @"wcenviarcomando", "dll");
      sc.Add( @"comandoenviadoww", "dll");
      sc.Add( @"wwpbaseobjects\masterpageframe", "dll");
      sc.Add( @"wwpbaseobjects\wwp_masterpagetopactionswc", "dll");
      sc.Add( @"wwpbaseobjects\wwp_userextended", "dll");
      sc.Add( @"wwpbaseobjects\wwp_entity", "dll");
      sc.Add( @"wwpbaseobjects\subscriptions\wwp_subscription", "dll");
      sc.Add( @"wwpbaseobjects\sms\wwp_sms", "dll");
      sc.Add( @"wwpbaseobjects\notifications\web\wwp_webnotification", "dll");
      sc.Add( @"wwpbaseobjects\notifications\web\wwp_webclient", "dll");
      sc.Add( @"wwpbaseobjects\notifications\common\wwp_notificationdefinition", "dll");
      sc.Add( @"wwpbaseobjects\notifications\common\wwp_notification", "dll");
      sc.Add( @"wwpbaseobjects\mail\wwp_mailtemplate", "dll");
      sc.Add( @"wwpbaseobjects\mail\wwp_mail", "dll");
      sc.Add( @"wwpbaseobjects\discussions\wwp_discussionmessage", "dll");
      sc.Add( @"wwpbaseobjects\discussions\wwp_discussionmessagemention", "dll");
      sc.Add( @"mqttconnection", "dll");
      sc.Add( @"frota", "dll");
      sc.Add( @"veiculo", "dll");
      sc.Add( @"frotaveiculo", "dll");
      sc.Add( @"rastreador", "dll");
      sc.Add( @"chipgsm", "dll");
      sc.Add( @"ultimodadolido", "dll");
      sc.Add( @"veiculorastreador", "dll");
      sc.Add( @"mqttparametros", "dll");
      sc.Add( @"comando", "dll");
      sc.Add( @"comandoenviado", "dll");
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
         if (checkTime(obj, cs_path + @"\type_SdtFrota.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtComando.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtVeiculoRastreador.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtUltimoDadoLido.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtVeiculo.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtRastreador.cs" ))
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

