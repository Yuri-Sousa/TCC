using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
[assembly: GeneXusCommonAssemblyAttribute()]
namespace GeneXus.Programs {
   public class GxModelInfoProvider
   {
      static public string GetNamespaceName( )
      {
         return "GeneXus.Programs" ;
      }

   }

}
