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
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class SoapParm
   {
      static public string read_section( IGxContext context ,
                                         GXXMLReader oReader ,
                                         GxLocation oLocation )
      {
         string sSection;
         sSection = "";
         if ( oReader.NodeType == 1 )
         {
            sSection = oReader.Name;
            oReader.Read();
            while ( ! ( ( StringUtil.StrCmp(oReader.Name, sSection) == 0 ) && ( oReader.NodeType == 2 ) ) )
            {
               if ( StringUtil.StrCmp(StringUtil.Lower( oReader.Name), "host") == 0 )
               {
                  oLocation.Host = oReader.Value;
               }
               else if ( StringUtil.StrCmp(StringUtil.Lower( oReader.Name), "port") == 0 )
               {
                  oLocation.Port = (int)(NumberUtil.Val( oReader.Value, "."));
               }
               else if ( StringUtil.StrCmp(StringUtil.Lower( oReader.Name), "baseurl") == 0 )
               {
                  oLocation.BaseUrl = oReader.Value;
               }
               else if ( StringUtil.StrCmp(StringUtil.Lower( oReader.Name), "resourcename") == 0 )
               {
                  oLocation.ResourceName = oReader.Value;
               }
               else if ( StringUtil.StrCmp(StringUtil.Lower( oReader.Name), "secure") == 0 )
               {
                  oLocation.Secure = (short)(NumberUtil.Val( oReader.Value, "."));
               }
               else if ( StringUtil.StrCmp(StringUtil.Lower( oReader.Name), "proxyserverhost") == 0 )
               {
                  oLocation.ProxyServerHost = oReader.Value;
               }
               else if ( StringUtil.StrCmp(StringUtil.Lower( oReader.Name), "proxyserverport") == 0 )
               {
                  oLocation.ProxyServerPort = (int)(NumberUtil.Val( oReader.Value, "."));
               }
               else if ( StringUtil.StrCmp(StringUtil.Lower( oReader.Name), "timeout") == 0 )
               {
                  oLocation.Timeout = (short)(NumberUtil.Val( oReader.Value, "."));
               }
               else if ( StringUtil.StrCmp(StringUtil.Lower( oReader.Name), "cancelonerror") == 0 )
               {
                  oLocation.CancelOnError = (short)(NumberUtil.Val( oReader.Value, "."));
               }
               else if ( StringUtil.StrCmp(oReader.Name, "Authentication") == 0 )
               {
                  oLocation.Authentication = 1;
                  oLocation.AuthenticationMethod = (short)(NumberUtil.Val( StringUtil.Str( (decimal)(0), 1, 0), "."));
                  oReader.Read();
                  while ( ! ( ( StringUtil.StrCmp(oReader.Name, "Authentication") == 0 ) && ( oReader.NodeType == 2 ) ) )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( oReader.Name), "authenticationmethod") == 0 )
                     {
                        oLocation.AuthenticationMethod = (short)(NumberUtil.Val( oReader.Value, "."));
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Lower( oReader.Name), "authenticationuser") == 0 )
                     {
                        oLocation.AuthenticationUser = oReader.Value;
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Lower( oReader.Name), "authenticationrealm") == 0 )
                     {
                        oLocation.AuthenticationRealm = oReader.Value;
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Lower( oReader.Name), "authenticationpassword") == 0 )
                     {
                        oLocation.AuthenticationPassword = oReader.Value;
                     }
                     oReader.Read();
                  }
               }
               else if ( StringUtil.StrCmp(oReader.Name, "Proxyauthentication") == 0 )
               {
                  oLocation.ProxyAuthenticationMethod = (short)(NumberUtil.Val( StringUtil.Str( (decimal)(0), 1, 0), "."));
                  oReader.Read();
                  while ( ! ( ( StringUtil.StrCmp(oReader.Name, "Proxyauthentication") == 0 ) && ( oReader.NodeType == 2 ) ) )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( oReader.Name), "proxyauthenticationmethod") == 0 )
                     {
                        oLocation.ProxyAuthenticationMethod = (short)(NumberUtil.Val( oReader.Value, "."));
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Lower( oReader.Name), "proxyauthenticationuser") == 0 )
                     {
                        oLocation.ProxyAuthenticationUser = oReader.Value;
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Lower( oReader.Name), "proxyauthenticationrealm") == 0 )
                     {
                        oLocation.ProxyAuthenticationRealm = oReader.Value;
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Lower( oReader.Name), "proxyauthenticationpassword") == 0 )
                     {
                        oLocation.ProxyAuthenticationPassword = oReader.Value;
                     }
                     oReader.Read();
                  }
               }
               oReader.Read();
            }
         }
         return sSection ;
      }

      static public void initLocations( IGxContext context ,
                                        GXXMLReader oReader )
      {
         string sSection;
         string sName;
         short nFirstRead;
         GxLocation oLocation;
         context.nLocRead = 1;
         context.colLocations = new GxLocationCollection();
         if ( oReader.ErrCode == 0 )
         {
            if ( oReader.ReadType(1, "GXLocations") > 0 )
            {
               oReader.Read();
               while ( ! ( ( StringUtil.StrCmp(oReader.Name, "GXLocations") == 0 ) && ( oReader.NodeType == 2 ) ) )
               {
                  if ( ( StringUtil.StrCmp(oReader.Name, "GXLocation") == 0 ) && ( oReader.NodeType == 1 ) )
                  {
                     sName = oReader.GetAttributeByName("name");
                     oLocation = context.colLocations.GetItem(sName);
                     context.nSOAPErr = 0;
                     if ( oLocation == null )
                     {
                        context.nSOAPErr = 1;
                     }
                     if ( context.nSOAPErr != 0 )
                     {
                        /* Error while reading XML. Code:  4 . Message:  Input error . */
                        oLocation = new GxLocation();
                        oLocation.Name = sName;
                        oLocation.Host = "localhost";
                        oLocation.Port = 80;
                        oLocation.BaseUrl = "/";
                        oLocation.Secure = 0;
                        oLocation.ProxyServerHost = "";
                        oLocation.ProxyServerPort = 0;
                        oLocation.Timeout = 0;
                        oLocation.CancelOnError = 0;
                        oLocation.Authentication = 0;
                        oLocation.AuthenticationMethod = 0;
                        oLocation.AuthenticationRealm = "";
                        oLocation.AuthenticationUser = "";
                        oLocation.AuthenticationPassword = "";
                        oLocation.GroupLocation = "";
                        context.colLocations.Add(oLocation, sName);
                     }
                     oLocation.GroupLocation = "";
                     nFirstRead = 1;
                     oReader.Read();
                     while ( ! ( ( StringUtil.StrCmp(oReader.Name, "GXLocation") == 0 ) && ( oReader.NodeType == 2 ) ) )
                     {
                        sSection = read_section( context, oReader, oLocation);
                        if ( ( ( StringUtil.StrCmp(sSection, "Common") == 0 ) && ( nFirstRead == 1 ) ) || ( StringUtil.StrCmp(sSection, "HTTP") == 0 ) )
                        {
                           nFirstRead = 0;
                        }
                        oReader.Read();
                     }
                  }
                  oReader.Read();
               }
            }
         }
      }

      static public void assigngroupproperties( IGxContext context ,
                                                GxLocation oLocation )
      {
         string sLocation;
         GxLocation oGroupLocation;
         int nOldSOAPErr;
         if ( oLocation != null )
         {
            sLocation = oLocation.GroupLocation;
            if ( StringUtil.StrCmp(sLocation, "") != 0 )
            {
               nOldSOAPErr = context.nSOAPErr;
               oGroupLocation = context.colLocations.GetItem(sLocation);
               context.nSOAPErr = 0;
               if ( oGroupLocation == null )
               {
                  context.nSOAPErr = 1;
               }
               if ( context.nSOAPErr == 0 )
               {
                  oLocation.Host = oGroupLocation.Host;
                  oLocation.Port = oGroupLocation.Port;
                  oLocation.Wsdlurl = oGroupLocation.Wsdlurl;
                  oLocation.BaseUrl = oGroupLocation.BaseUrl;
                  oLocation.Secure = oGroupLocation.Secure;
                  oLocation.ProxyServerHost = oGroupLocation.ProxyServerHost;
                  oLocation.ProxyServerPort = oGroupLocation.ProxyServerPort;
                  oLocation.Timeout = oGroupLocation.Timeout;
                  oLocation.CancelOnError = oGroupLocation.CancelOnError;
                  oLocation.Authentication = oGroupLocation.Authentication;
                  oLocation.AuthenticationMethod = oGroupLocation.AuthenticationMethod;
                  oLocation.AuthenticationRealm = oGroupLocation.AuthenticationRealm;
                  oLocation.AuthenticationUser = oGroupLocation.AuthenticationUser;
                  oLocation.AuthenticationPassword = oGroupLocation.AuthenticationPassword;
                  oLocation.ProxyAuthentication = oGroupLocation.ProxyAuthentication;
                  oLocation.ProxyAuthenticationMethod = oGroupLocation.ProxyAuthenticationMethod;
                  oLocation.ProxyAuthenticationRealm = oGroupLocation.ProxyAuthenticationRealm;
                  oLocation.ProxyAuthenticationUser = oGroupLocation.ProxyAuthenticationUser;
                  oLocation.ProxyAuthenticationPassword = oGroupLocation.ProxyAuthenticationPassword;
               }
               context.nSOAPErr = (short)(nOldSOAPErr);
            }
         }
      }

      static public GxLocation getlocation( IGxContext context ,
                                            string sLocation )
      {
         GXXMLReader oReader;
         GxLocation oLocation;
         if ( context.nLocRead == 0 )
         {
            oReader = new GXXMLReader(context.GetPhysicalPath());
            oReader.Open(context.GetPhysicalPath( )+"location.xml");
            initLocations( context, oReader) ;
            if ( oReader.ErrCode == 0 )
            {
               oReader.Close();
            }
         }
         context.nSOAPErr = 0;
         oLocation = context.colLocations.GetItem(sLocation);
         context.nSOAPErr = 0;
         if ( oLocation == null )
         {
            context.nSOAPErr = 1;
         }
         assigngroupproperties( context, oLocation) ;
         if ( context.nSOAPErr != 0 )
         {
            context.nSOAPErr = (short)(-20007);
            context.sSOAPErrMsg = "Invalid location name.";
            oLocation = new GxLocation();
            oLocation.Name = sLocation;
            oLocation.Host = "";
            oLocation.Port = -1;
            oLocation.BaseUrl = "";
            oLocation.Secure = -1;
            oLocation.ProxyServerHost = "";
            oLocation.ProxyServerPort = -1;
            oLocation.Timeout = -1;
            oLocation.CancelOnError = 0;
            oLocation.Authentication = 0;
            oLocation.AuthenticationMethod = 0;
            oLocation.AuthenticationRealm = "";
            oLocation.AuthenticationUser = "";
            oLocation.AuthenticationPassword = "";
            oLocation.GroupLocation = "";
            context.colLocations.Add(oLocation, sLocation);
         }
         else
         {
            context.nSOAPErr = 0;
            context.sSOAPErrMsg = "";
         }
         return oLocation ;
      }

      static public void AssignLocationProperties( IGxContext context ,
                                                   string sLocation ,
                                                   GxHttpClient oClient )
      {
         GxLocation oLocation;
         GxLocation oGroupLocation;
         string sGroupLocation;
         short nGroupErr;
         oLocation = SoapParm.getlocation( context, sLocation);
         if ( context.nSOAPErr != 0 )
         {
            sGroupLocation = "LOC:" + oClient.Host + oClient.BaseURL;
            oGroupLocation = context.colLocations.GetItem(sGroupLocation);
            nGroupErr = 0;
            if ( oGroupLocation == null )
            {
               nGroupErr = 1;
            }
            if ( nGroupErr == 0 )
            {
               context.nSOAPErr = 0;
               oLocation.GroupLocation = sGroupLocation;
               assigngroupproperties( context, oLocation) ;
            }
         }
         if ( context.nSOAPErr == 0 )
         {
            if ( StringUtil.StrCmp(oLocation.Host, "") != 0 )
            {
               oClient.Host = oLocation.Host;
            }
            if ( oLocation.Port != -1 )
            {
               oClient.Port = oLocation.Port;
            }
            if ( StringUtil.StrCmp(oLocation.ProxyServerHost, "") != 0 )
            {
               oClient.ProxyServerHost = oLocation.ProxyServerHost;
            }
            if ( oLocation.ProxyServerPort != -1 )
            {
               oClient.ProxyServerPort = (short)(oLocation.ProxyServerPort);
            }
            if ( StringUtil.StrCmp(oLocation.Wsdlurl, "") != 0 )
            {
               oClient.WSDLURL = oLocation.Wsdlurl;
            }
            if ( StringUtil.StrCmp(oLocation.BaseUrl, "") != 0 )
            {
               oClient.BaseURL = oLocation.BaseUrl;
            }
            if ( oLocation.Secure != -1 )
            {
               oClient.Secure = (BooleanUtil.Val( StringUtil.Str( (decimal)(oLocation.Secure), 1, 0)) ? 1 : 0);
            }
            if ( oLocation.Timeout != -1 )
            {
               oClient.Timeout = oLocation.Timeout;
            }
            if ( StringUtil.StrCmp(oLocation.ProxyAuthenticationUser, "") != 0 )
            {
               oClient.AddProxyAuthentication(oLocation.ProxyAuthenticationMethod, oLocation.ProxyAuthenticationRealm, oLocation.ProxyAuthenticationUser, oLocation.ProxyAuthenticationPassword);
            }
            if ( StringUtil.StrCmp(oLocation.Certificate, "") != 0 )
            {
               oClient.AddCertificate(oLocation.Certificate);
            }
            if ( oLocation.Authentication == 1 )
            {
               oClient.AddAuthentication(oLocation.AuthenticationMethod, oLocation.AuthenticationRealm, oLocation.AuthenticationUser, oLocation.AuthenticationPassword);
            }
         }
      }

      static public string GetResourceName( IGxContext context ,
                                            string sLocation )
      {
         GxLocation oLocation;
         oLocation = SoapParm.getlocation( context, sLocation);
         if ( context.nSOAPErr == 0 )
         {
            sLocation = oLocation.ResourceName;
         }
         else
         {
            sLocation = "";
         }
         return sLocation ;
      }

   }
}

