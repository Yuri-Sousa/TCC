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
namespace GeneXus.Programs {
   [Serializable]
   public class GxObjectCollection : GxObjectCollectionBase
   {
      [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
      public GxObjectCollection( IGxContext context ,
                                 string containedName ,
                                 string containedXmlNamespace ,
                                 string containedType ,
                                 string containedTypeNamespace ) : base(context, containedName, containedXmlNamespace, containedType, containedTypeNamespace)
      {
      }

      [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
      public GxObjectCollection( )
      {
      }

      public override short readxml( GXXMLReader oReader ,
                                     string sName )
      {
         short currError;
         string arrayType;
         short gxi;
         currError = 1;
         arrayType = "";
         gxi = 0;
         while ( gxi <= oReader.AttributeCount )
         {
            if ( StringUtil.StrCmp(oReader.GetAttributeLocalName(gxi), "arrayType") == 0 )
            {
               arrayType = oReader.GetAttributeByIndex(gxi);
            }
            gxi = (short)(gxi+1);
         }
         if ( StringUtil.StrCmp(arrayType, "") != 0 )
         {
            currError = (short)(readEncodedArray(arrayType,oReader));
         }
         else
         {
            currError = (short)(readxmlcollection(oReader,sName,""));
         }
         return currError ;
      }

      public short readEncodedArray( string arrayType ,
                                     GXXMLReader oReader )
      {
         short currError;
         int arrayLength;
         int arraySizeStartPos;
         int arraySizeLength;
         short gxi;
         arraySizeStartPos = (int)(StringUtil.StringSearch( arrayType, "[", 1)+1);
         arraySizeLength = (int)(StringUtil.Len( arrayType)-arraySizeStartPos);
         if ( ( arraySizeStartPos == 1 ) || ( arraySizeLength == 0 ) )
         {
            throw new Exception( "GxObjectCollectionBase error: Could not read encoded array size\"+\"(\"+StringUtil.LTrim( StringUtil.NToC( (decimal)(0), 6, 0, \".\", \"\"))+\")") ;
         }
         arrayLength = (int)(NumberUtil.Val( StringUtil.Substring( arrayType, arraySizeStartPos, arraySizeLength), "."));
         currError = oReader.Read();
         gxi = 0;
         while ( ( gxi < arrayLength ) && ( currError > 0 ) )
         {
            currError = (short)(AddObjectInstance(oReader));
            oReader.Read();
            gxi = (short)(gxi+1);
         }
         return currError ;
      }

      public override short readxmlcollection( GXXMLReader oReader ,
                                               string sName ,
                                               string itemName )
      {
         short currError;
         string sTagName;
         string itemName1;
         currError = 1;
         itemName1 = (string)(GetContainedName());
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( itemName)) )
         {
            itemName1 = itemName;
         }
         if ( ( StringUtil.StrCmp(oReader.LocalName, itemName1) != 0 ) || ( StringUtil.StrCmp(sName, itemName1) == 0 ) )
         {
            currError = oReader.Read();
         }
         sTagName = oReader.Name;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( sName)) )
         {
            this.ClearCollection();
         }
         while ( ( StringUtil.StrCmp(oReader.Name, sTagName) == 0 ) && ( oReader.NodeType == 1 ) && ( currError > 0 ) )
         {
            if ( IsSimpleCollection() || ( oReader.IsSimple == 0 ) || ( oReader.AttributeCount > 0 ) )
            {
               currError = (short)(AddObjectInstance(oReader));
            }
            oReader.Read();
         }
         return currError ;
      }

      public override Object Clone( )
      {
         GxObjectCollection objCol;
         objCol = new GxObjectCollection( context, _containedName, _containedXmlNamespace, _containedType, _containedTypeNamespace) ;
         return (Object)(objCol) ;
      }

   }

}
