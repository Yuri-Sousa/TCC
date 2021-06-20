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
   public class SdtMqttStatus : GxUserType, IGxExternalObject
   {
      public SdtMqttStatus( )
      {
         /* Constructor for serialization */
      }

      public SdtMqttStatus( IGxContext context )
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

      public Guid gxTpr_Key
      {
         get {
            if ( MqttStatus_externalReference == null )
            {
               MqttStatus_externalReference = new MQTTLib.MqttStatus();
            }
            return MqttStatus_externalReference.Key ;
         }

      }

      public bool gxTpr_Error
      {
         get {
            if ( MqttStatus_externalReference == null )
            {
               MqttStatus_externalReference = new MQTTLib.MqttStatus();
            }
            return MqttStatus_externalReference.Error ;
         }

      }

      public string gxTpr_Errormessage
      {
         get {
            if ( MqttStatus_externalReference == null )
            {
               MqttStatus_externalReference = new MQTTLib.MqttStatus();
            }
            return MqttStatus_externalReference.ErrorMessage ;
         }

      }

      public Object ExternalInstance
      {
         get {
            if ( MqttStatus_externalReference == null )
            {
               MqttStatus_externalReference = new MQTTLib.MqttStatus();
            }
            return MqttStatus_externalReference ;
         }

         set {
            MqttStatus_externalReference = (MQTTLib.MqttStatus)(value);
         }

      }

      public void initialize( )
      {
         return  ;
      }

      protected MQTTLib.MqttStatus MqttStatus_externalReference=null ;
   }

}
