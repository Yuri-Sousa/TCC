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
   public class gxdomainmqttdefault
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainmqttdefault ()
      {
         domain["mqtt.flespi.io"] = "Url";
         domain["gaecalat@gmail.com"] = "User";
         domain["1XjlP72Ud6endmH9Z7AXFilrd0Fzerc6fmhSh8Bk2Fy5P53C2tnxByMCoh2rx4nA"] = "Password";
         domain["/foo/bar/topic1"] = "Topic";
      }

      public static string getDescription( IGxContext context ,
                                           string key )
      {
         string rtkey;
         string value;
         rtkey = ((key==null) ? "" : StringUtil.Trim( (string)(key)));
         value = (string)(domain[rtkey]==null?"":domain[rtkey]);
         return value ;
      }

      public static GxSimpleCollection<string> getValues( )
      {
         GxSimpleCollection<string> value = new GxSimpleCollection<string>();
         ArrayList aKeys = new ArrayList(domain.Keys);
         aKeys.Sort();
         foreach (string key in aKeys)
         {
            value.Add(key);
         }
         return value;
      }

      [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
      public static string getValue( string key )
      {
         if(domainMap == null)
         {
            domainMap = new Hashtable();
            domainMap["Url"] = "mqtt.flespi.io";
            domainMap["User"] = "gaecalat@gmail.com";
            domainMap["Password"] = "1XjlP72Ud6endmH9Z7AXFilrd0Fzerc6fmhSh8Bk2Fy5P53C2tnxByMCoh2rx4nA";
            domainMap["Topic"] = "/foo/bar/topic1";
         }
         return (string)domainMap[key] ;
      }

   }

}
