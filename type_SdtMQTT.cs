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
   public class SdtMQTT : GxUserType, IGxExternalObject
   {
      public SdtMQTT( )
      {
         /* Constructor for serialization */
      }

      public SdtMQTT( IGxContext context )
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

      public SdtMqttStatus connect( string gxTp_url ,
                                    SdtMqttConfig gxTp_config )
      {
         SdtMqttStatus returnconnect;
         returnconnect = new SdtMqttStatus(context);
         MQTTLib.MqttStatus externalParm0;
         MQTTLib.MqttConfig externalParm1;
         externalParm1 = (MQTTLib.MqttConfig)(gxTp_config.ExternalInstance);
         externalParm0 = MQTTLib.MqttClient.Connect(gxTp_url, externalParm1);
         returnconnect.ExternalInstance = externalParm0;
         return returnconnect ;
      }

      public SdtMqttStatus subscribe( Guid gxTp_key ,
                                      string gxTp_topic ,
                                      string gxTp_gxprocname ,
                                      int gxTp_qos )
      {
         SdtMqttStatus returnsubscribe;
         returnsubscribe = new SdtMqttStatus(context);
         MQTTLib.MqttStatus externalParm0;
         externalParm0 = MQTTLib.MqttClient.Subscribe(gxTp_key, gxTp_topic, gxTp_gxprocname, gxTp_qos);
         returnsubscribe.ExternalInstance = externalParm0;
         return returnsubscribe ;
      }

      public SdtMqttStatus publish( Guid gxTp_key ,
                                    string gxTp_topic ,
                                    string gxTp_payload ,
                                    int gxTp_qos ,
                                    bool gxTp_retain ,
                                    int gxTp_messageExpiryInterval )
      {
         SdtMqttStatus returnpublish;
         returnpublish = new SdtMqttStatus(context);
         MQTTLib.MqttStatus externalParm0;
         externalParm0 = MQTTLib.MqttClient.Publish(gxTp_key, gxTp_topic, gxTp_payload, gxTp_qos, gxTp_retain, gxTp_messageExpiryInterval);
         returnpublish.ExternalInstance = externalParm0;
         return returnpublish ;
      }

      public SdtMqttStatus disconnect( Guid gxTp_key )
      {
         SdtMqttStatus returndisconnect;
         returndisconnect = new SdtMqttStatus(context);
         MQTTLib.MqttStatus externalParm0;
         externalParm0 = MQTTLib.MqttClient.Disconnect(gxTp_key);
         returndisconnect.ExternalInstance = externalParm0;
         return returndisconnect ;
      }

      public SdtMqttStatus unsubscribe( Guid gxTp_key ,
                                        string gxTp_topic )
      {
         SdtMqttStatus returnunsubscribe;
         returnunsubscribe = new SdtMqttStatus(context);
         MQTTLib.MqttStatus externalParm0;
         externalParm0 = MQTTLib.MqttClient.Unsubscribe(gxTp_key, gxTp_topic);
         returnunsubscribe.ExternalInstance = externalParm0;
         return returnunsubscribe ;
      }

      public SdtMqttStatus isconnected( Guid gxTp_key ,
                                        out bool gxTp_connected )
      {
         SdtMqttStatus returnisconnected;
         gxTp_connected = false;
         returnisconnected = new SdtMqttStatus(context);
         MQTTLib.MqttStatus externalParm0;
         externalParm0 = MQTTLib.MqttClient.IsConnected(gxTp_key, out gxTp_connected);
         returnisconnected.ExternalInstance = externalParm0;
         return returnisconnected ;
      }

      public Object ExternalInstance
      {
         get {
            if ( MQTT_externalReference == null )
            {
               MQTT_externalReference = new MQTTLib.MqttClient();
            }
            return MQTT_externalReference ;
         }

         set {
            MQTT_externalReference = (MQTTLib.MqttClient)(value);
         }

      }

      public void initialize( )
      {
         return  ;
      }

      protected MQTTLib.MqttClient MQTT_externalReference=null ;
   }

}
