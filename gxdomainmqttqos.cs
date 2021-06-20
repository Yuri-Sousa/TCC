using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Web.Services;
using System.Data;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class gxdomainmqttqos
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainmqttqos ()
      {
         domain[(int)0] = "At Most Once";
         domain[(int)1] = "At Least Once";
         domain[(int)2] = "Exaclty Once";
      }

      public static string getDescription( IGxContext context ,
                                           int key )
      {
         string value;
         value = (string)(domain[key]==null?"":domain[key]);
         return value ;
      }

      public static GxSimpleCollection<int> getValues( )
      {
         GxSimpleCollection<int> value = new GxSimpleCollection<int>();
         ArrayList aKeys = new ArrayList(domain.Keys);
         aKeys.Sort();
         foreach (int key in aKeys)
         {
            value.Add(key);
         }
         return value;
      }

      [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
      public static int getValue( string key )
      {
         if(domainMap == null)
         {
            domainMap = new Hashtable();
            domainMap["AtMostOnce"] = (int)0;
            domainMap["AtLeastOnce"] = (int)1;
            domainMap["ExacltyOnce"] = (int)2;
         }
         return (int)domainMap[key] ;
      }

   }

}
