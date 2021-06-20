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
   public class gxdomainactiontexts
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainactiontexts ()
      {
         domain["Edit"] = "Update";
         domain["Delete"] = "Delete";
         domain["Add"] = "Add";
         domain["Back"] = "Back";
         domain["Show filters"] = "Show Filters";
         domain["Hide filters"] = "Hide Filters";
         domain["Children"] = "Children";
         domain["Permission"] = "Permission";
         domain["Roles"] = "Roles";
         domain["Login"] = "Login";
         domain["Register"] = "Register";
         domain["Logout"] = "Logout";
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
            domainMap["Update"] = "Edit";
            domainMap["Delete"] = "Delete";
            domainMap["Add"] = "Add";
            domainMap["Back"] = "Back";
            domainMap["ShowFilters"] = "Show filters";
            domainMap["HideFilters"] = "Hide filters";
            domainMap["Children"] = "Children";
            domainMap["Permission"] = "Permission";
            domainMap["Roles"] = "Roles";
            domainMap["Login"] = "Login";
            domainMap["Register"] = "Register";
            domainMap["Logout"] = "Logout";
         }
         return (string)domainMap[key] ;
      }

   }

}
