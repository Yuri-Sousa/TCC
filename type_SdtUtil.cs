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
   public class SdtUtil : GxUserType, IGxExternalObject
   {
      public SdtUtil( )
      {
         /* Constructor for serialization */
      }

      public SdtUtil( IGxContext context )
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

      public int hex4bytestodecimal( string gxTp_Hex4bytes )
      {
         int returnhex4bytestodecimal;
         returnhex4bytestodecimal = 0;
         returnhex4bytestodecimal = (int)(DwithUtil.DwithUtil.Hex4bytesToDecimal(gxTp_Hex4bytes));
         return returnhex4bytestodecimal ;
      }

      public string decimaltohex4bytes( int gxTp_Decimal )
      {
         string returndecimaltohex4bytes;
         returndecimaltohex4bytes = "";
         returndecimaltohex4bytes = (string)(DwithUtil.DwithUtil.DecimalToHex4bytes(gxTp_Decimal));
         return returndecimaltohex4bytes ;
      }

      public string datetimetotimestamp( DateTime gxTp_datahora )
      {
         string returndatetimetotimestamp;
         returndatetimetotimestamp = "";
         returndatetimetotimestamp = (string)(DwithUtil.DwithUtil.DateTimeToTimeStamp(gxTp_datahora));
         return returndatetimetotimestamp ;
      }

      public DateTime timestamptodatetime( decimal gxTp_timestamp )
      {
         DateTime returntimestamptodatetime;
         returntimestamptodatetime = (DateTime)(DateTime.MinValue);
         System.Double externalParm0;
         externalParm0 = (System.Double)(gxTp_timestamp);
         returntimestamptodatetime = (DateTime)(DwithUtil.DwithUtil.TimeStampToDateTime(externalParm0));
         return returntimestamptodatetime ;
      }

      public Object ExternalInstance
      {
         get {
            if ( Util_externalReference == null )
            {
               Util_externalReference = new DwithUtil.DwithUtil();
            }
            return Util_externalReference ;
         }

         set {
            Util_externalReference = (DwithUtil.DwithUtil)(value);
         }

      }

      public void initialize( )
      {
         return  ;
      }

      protected DwithUtil.DwithUtil Util_externalReference=null ;
   }

}
