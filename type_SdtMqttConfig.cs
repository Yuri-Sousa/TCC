using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Web.Services.Protocols;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [Serializable]
   public class SdtMqttConfig : GxUserType, IGxExternalObject
   {
      public SdtMqttConfig( )
      {
         /* Constructor for serialization */
      }

      public SdtMqttConfig( IGxContext context )
      {
         this.context = context;
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public string exportmqttconfig( )
      {
         string returnexportmqttconfig;
         if ( MqttConfig_externalReference == null )
         {
            MqttConfig_externalReference = new MQTTLib.MqttConfig();
         }
         returnexportmqttconfig = "";
         returnexportmqttconfig = (string)(MqttConfig_externalReference.ExportMqttConfig());
         return returnexportmqttconfig ;
      }

      public SdtMqttConfig importmqttconfig( string gxTp_json )
      {
         SdtMqttConfig returnimportmqttconfig;
         returnimportmqttconfig = new SdtMqttConfig(context);
         MQTTLib.MqttConfig externalParm0;
         externalParm0 = MQTTLib.MqttConfig.ImportMqttConfig(gxTp_json);
         returnimportmqttconfig.ExternalInstance = externalParm0;
         return returnimportmqttconfig ;
      }

      public int gxTpr_Port
      {
         get {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            return MqttConfig_externalReference.Port ;
         }

         set {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            MqttConfig_externalReference.Port = value;
            SetDirty("Port");
         }

      }

      public int gxTpr_Buffersize
      {
         get {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            return MqttConfig_externalReference.BufferSize ;
         }

         set {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            MqttConfig_externalReference.BufferSize = value;
            SetDirty("Buffersize");
         }

      }

      public int gxTpr_Keepalive
      {
         get {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            return MqttConfig_externalReference.KeepAlive ;
         }

         set {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            MqttConfig_externalReference.KeepAlive = value;
            SetDirty("Keepalive");
         }

      }

      public int gxTpr_Connectiontimeout
      {
         get {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            return MqttConfig_externalReference.ConnectionTimeout ;
         }

         set {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            MqttConfig_externalReference.ConnectionTimeout = value;
            SetDirty("Connectiontimeout");
         }

      }

      public string gxTpr_Username
      {
         get {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            return MqttConfig_externalReference.UserName ;
         }

         set {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            MqttConfig_externalReference.UserName = value;
            SetDirty("Username");
         }

      }

      public string gxTpr_Password
      {
         get {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            return MqttConfig_externalReference.Password ;
         }

         set {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            MqttConfig_externalReference.Password = value;
            SetDirty("Password");
         }

      }

      public string gxTpr_Mqttconnectionname
      {
         get {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            return MqttConfig_externalReference.MQTTConnectionName ;
         }

         set {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            MqttConfig_externalReference.MQTTConnectionName = value;
            SetDirty("Mqttconnectionname");
         }

      }

      public string gxTpr_Clientid
      {
         get {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            return MqttConfig_externalReference.ClientId ;
         }

         set {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            MqttConfig_externalReference.ClientId = value;
            SetDirty("Clientid");
         }

      }

      public bool gxTpr_Sslconnection
      {
         get {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            return MqttConfig_externalReference.SSLConnection ;
         }

         set {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            MqttConfig_externalReference.SSLConnection = value;
            SetDirty("Sslconnection");
         }

      }

      public string gxTpr_Cacertificate
      {
         get {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            return MqttConfig_externalReference.CAcertificate ;
         }

         set {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            MqttConfig_externalReference.CAcertificate = value;
            SetDirty("Cacertificate");
         }

      }

      public string gxTpr_Clientcertificate
      {
         get {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            return MqttConfig_externalReference.ClientCertificate ;
         }

         set {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            MqttConfig_externalReference.ClientCertificate = value;
            SetDirty("Clientcertificate");
         }

      }

      public string gxTpr_Clientcerificatepassphrase
      {
         get {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            return MqttConfig_externalReference.ClientCerificatePassphrase ;
         }

         set {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            MqttConfig_externalReference.ClientCerificatePassphrase = value;
            SetDirty("Clientcerificatepassphrase");
         }

      }

      public int gxTpr_Protocolversion
      {
         get {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            return MqttConfig_externalReference.ProtocolVersion ;
         }

         set {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            MqttConfig_externalReference.ProtocolVersion = value;
            SetDirty("Protocolversion");
         }

      }

      public string gxTpr_Privatekey
      {
         get {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            return MqttConfig_externalReference.PrivateKey ;
         }

         set {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            MqttConfig_externalReference.PrivateKey = value;
            SetDirty("Privatekey");
         }

      }

      public bool gxTpr_Allowwildcardsintopicfilters
      {
         get {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            return MqttConfig_externalReference.AllowWildcardsInTopicFilters ;
         }

         set {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            MqttConfig_externalReference.AllowWildcardsInTopicFilters = value;
            SetDirty("Allowwildcardsintopicfilters");
         }

      }

      public bool gxTpr_Cleansession
      {
         get {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            return MqttConfig_externalReference.CleanSession ;
         }

         set {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            MqttConfig_externalReference.CleanSession = value;
            SetDirty("Cleansession");
         }

      }

      public int gxTpr_Autoreconnectdelay
      {
         get {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            return MqttConfig_externalReference.AutoReconnectDelay ;
         }

         set {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            MqttConfig_externalReference.AutoReconnectDelay = value;
            SetDirty("Autoreconnectdelay");
         }

      }

      public int gxTpr_Sessionexpiryinterval
      {
         get {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            return MqttConfig_externalReference.SessionExpiryInterval ;
         }

         set {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            MqttConfig_externalReference.SessionExpiryInterval = value;
            SetDirty("Sessionexpiryinterval");
         }

      }

      public Object ExternalInstance
      {
         get {
            if ( MqttConfig_externalReference == null )
            {
               MqttConfig_externalReference = new MQTTLib.MqttConfig();
            }
            return MqttConfig_externalReference ;
         }

         set {
            MqttConfig_externalReference = (MQTTLib.MqttConfig)(value);
         }

      }

      public void initialize( )
      {
         return  ;
      }

      protected MQTTLib.MqttConfig MqttConfig_externalReference=null ;
   }

}
