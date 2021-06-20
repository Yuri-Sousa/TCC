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
   public class gxdomainqueryviewertrendperiod
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainqueryviewertrendperiod ()
      {
         domain["SinceTheBeginning"] = "Since the beginning";
         domain["LastYear"] = "Last year";
         domain["LastSemester"] = "Last semester";
         domain["LastQuarter"] = "Last quarter";
         domain["LastMonth"] = "Last month";
         domain["LastWeek"] = "Last week";
         domain["LastDay"] = "Last day";
         domain["LastHour"] = "Last hour";
         domain["LastMinute"] = "Last minute";
         domain["LastSecond"] = "Last second";
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
            domainMap["SinceTheBeginning"] = "SinceTheBeginning";
            domainMap["LastYear"] = "LastYear";
            domainMap["LastSemester"] = "LastSemester";
            domainMap["LastQuarter"] = "LastQuarter";
            domainMap["LastMonth"] = "LastMonth";
            domainMap["LastWeek"] = "LastWeek";
            domainMap["LastDay"] = "LastDay";
            domainMap["LastHour"] = "LastHour";
            domainMap["LastMinute"] = "LastMinute";
            domainMap["LastSecond"] = "LastSecond";
         }
         return (string)domainMap[key] ;
      }

   }

}
