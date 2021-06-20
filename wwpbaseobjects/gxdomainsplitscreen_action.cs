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
namespace GeneXus.Programs.wwpbaseobjects {
   public class gxdomainsplitscreen_action
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainsplitscreen_action ()
      {
         domain[(short)1] = "Go To";
         domain[(short)2] = "Go Back";
         domain[(short)3] = "Record Created";
         domain[(short)4] = "Record Deleted";
         domain[(short)5] = "Record Updated";
         domain[(short)6] = "Record Creation Canceled";
      }

      public static string getDescription( IGxContext context ,
                                           short key )
      {
         string value;
         value = (string)(domain[key]==null?"":domain[key]);
         return value ;
      }

      public static GxSimpleCollection<short> getValues( )
      {
         GxSimpleCollection<short> value = new GxSimpleCollection<short>();
         ArrayList aKeys = new ArrayList(domain.Keys);
         aKeys.Sort();
         foreach (short key in aKeys)
         {
            value.Add(key);
         }
         return value;
      }

      [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
      public static short getValue( string key )
      {
         if(domainMap == null)
         {
            domainMap = new Hashtable();
            domainMap["GoTo"] = (short)1;
            domainMap["GoBack"] = (short)2;
            domainMap["RecordCreated"] = (short)3;
            domainMap["RecordDeleted"] = (short)4;
            domainMap["RecordUpdated"] = (short)5;
            domainMap["RecordCreationCanceled"] = (short)6;
         }
         return (short)domainMap[key] ;
      }

   }

}
