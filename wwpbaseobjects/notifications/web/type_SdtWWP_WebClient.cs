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
namespace GeneXus.Programs.wwpbaseobjects.notifications.web {
   [XmlSerializerFormat]
   [XmlRoot(ElementName = "WWP_WebClient" )]
   [XmlType(TypeName =  "WWP_WebClient" , Namespace = "RastreamentoTCC" )]
   [Serializable]
   public class SdtWWP_WebClient : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWWP_WebClient( )
      {
      }

      public SdtWWP_WebClient( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetCallingAssembly();
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

      public void Load( string AV18WWPWebClientId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(string)AV18WWPWebClientId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"WWPWebClientId", typeof(string)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "WWPBaseObjects\\Notifications\\Web\\WWP_WebClient");
         metadata.Set("BT", "WWP_WebClient");
         metadata.Set("PK", "[ \"WWPWebClientId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"WWPUserExtendedId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Wwpwebclientid_Z");
         state.Add("gxTpr_Wwpwebclientbrowserid_Z");
         state.Add("gxTpr_Wwpwebclientfirstregistered_Z_Nullable");
         state.Add("gxTpr_Wwpwebclientlastregistered_Z_Nullable");
         state.Add("gxTpr_Wwpuserextendedid_Z");
         state.Add("gxTpr_Wwpuserextendedid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient sdt;
         sdt = (GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient)(source);
         gxTv_SdtWWP_WebClient_Wwpwebclientid = sdt.gxTv_SdtWWP_WebClient_Wwpwebclientid ;
         gxTv_SdtWWP_WebClient_Wwpwebclientbrowserid = sdt.gxTv_SdtWWP_WebClient_Wwpwebclientbrowserid ;
         gxTv_SdtWWP_WebClient_Wwpwebclientbrowserversion = sdt.gxTv_SdtWWP_WebClient_Wwpwebclientbrowserversion ;
         gxTv_SdtWWP_WebClient_Wwpwebclientfirstregistered = sdt.gxTv_SdtWWP_WebClient_Wwpwebclientfirstregistered ;
         gxTv_SdtWWP_WebClient_Wwpwebclientlastregistered = sdt.gxTv_SdtWWP_WebClient_Wwpwebclientlastregistered ;
         gxTv_SdtWWP_WebClient_Wwpuserextendedid = sdt.gxTv_SdtWWP_WebClient_Wwpuserextendedid ;
         gxTv_SdtWWP_WebClient_Mode = sdt.gxTv_SdtWWP_WebClient_Mode ;
         gxTv_SdtWWP_WebClient_Initialized = sdt.gxTv_SdtWWP_WebClient_Initialized ;
         gxTv_SdtWWP_WebClient_Wwpwebclientid_Z = sdt.gxTv_SdtWWP_WebClient_Wwpwebclientid_Z ;
         gxTv_SdtWWP_WebClient_Wwpwebclientbrowserid_Z = sdt.gxTv_SdtWWP_WebClient_Wwpwebclientbrowserid_Z ;
         gxTv_SdtWWP_WebClient_Wwpwebclientfirstregistered_Z = sdt.gxTv_SdtWWP_WebClient_Wwpwebclientfirstregistered_Z ;
         gxTv_SdtWWP_WebClient_Wwpwebclientlastregistered_Z = sdt.gxTv_SdtWWP_WebClient_Wwpwebclientlastregistered_Z ;
         gxTv_SdtWWP_WebClient_Wwpuserextendedid_Z = sdt.gxTv_SdtWWP_WebClient_Wwpuserextendedid_Z ;
         gxTv_SdtWWP_WebClient_Wwpuserextendedid_N = sdt.gxTv_SdtWWP_WebClient_Wwpuserextendedid_N ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("WWPWebClientId", gxTv_SdtWWP_WebClient_Wwpwebclientid, false, includeNonInitialized);
         AddObjectProperty("WWPWebClientBrowserId", gxTv_SdtWWP_WebClient_Wwpwebclientbrowserid, false, includeNonInitialized);
         AddObjectProperty("WWPWebClientBrowserVersion", gxTv_SdtWWP_WebClient_Wwpwebclientbrowserversion, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtWWP_WebClient_Wwpwebclientfirstregistered;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ".";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.MilliSecond( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "000", 1, 3-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("WWPWebClientFirstRegistered", sDateCnv, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtWWP_WebClient_Wwpwebclientlastregistered;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ".";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.MilliSecond( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "000", 1, 3-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("WWPWebClientLastRegistered", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("WWPUserExtendedId", gxTv_SdtWWP_WebClient_Wwpuserextendedid, false, includeNonInitialized);
         AddObjectProperty("WWPUserExtendedId_N", gxTv_SdtWWP_WebClient_Wwpuserextendedid_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtWWP_WebClient_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtWWP_WebClient_Initialized, false, includeNonInitialized);
            AddObjectProperty("WWPWebClientId_Z", gxTv_SdtWWP_WebClient_Wwpwebclientid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPWebClientBrowserId_Z", gxTv_SdtWWP_WebClient_Wwpwebclientbrowserid_Z, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtWWP_WebClient_Wwpwebclientfirstregistered_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ".";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.MilliSecond( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "000", 1, 3-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("WWPWebClientFirstRegistered_Z", sDateCnv, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtWWP_WebClient_Wwpwebclientlastregistered_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ".";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.MilliSecond( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "000", 1, 3-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("WWPWebClientLastRegistered_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("WWPUserExtendedId_Z", gxTv_SdtWWP_WebClient_Wwpuserextendedid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPUserExtendedId_N", gxTv_SdtWWP_WebClient_Wwpuserextendedid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient sdt )
      {
         if ( sdt.IsDirty("WWPWebClientId") )
         {
            gxTv_SdtWWP_WebClient_Wwpwebclientid = sdt.gxTv_SdtWWP_WebClient_Wwpwebclientid ;
         }
         if ( sdt.IsDirty("WWPWebClientBrowserId") )
         {
            gxTv_SdtWWP_WebClient_Wwpwebclientbrowserid = sdt.gxTv_SdtWWP_WebClient_Wwpwebclientbrowserid ;
         }
         if ( sdt.IsDirty("WWPWebClientBrowserVersion") )
         {
            gxTv_SdtWWP_WebClient_Wwpwebclientbrowserversion = sdt.gxTv_SdtWWP_WebClient_Wwpwebclientbrowserversion ;
         }
         if ( sdt.IsDirty("WWPWebClientFirstRegistered") )
         {
            gxTv_SdtWWP_WebClient_Wwpwebclientfirstregistered = sdt.gxTv_SdtWWP_WebClient_Wwpwebclientfirstregistered ;
         }
         if ( sdt.IsDirty("WWPWebClientLastRegistered") )
         {
            gxTv_SdtWWP_WebClient_Wwpwebclientlastregistered = sdt.gxTv_SdtWWP_WebClient_Wwpwebclientlastregistered ;
         }
         if ( sdt.IsDirty("WWPUserExtendedId") )
         {
            gxTv_SdtWWP_WebClient_Wwpuserextendedid_N = 0;
            gxTv_SdtWWP_WebClient_Wwpuserextendedid = sdt.gxTv_SdtWWP_WebClient_Wwpuserextendedid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "WWPWebClientId" )]
      [  XmlElement( ElementName = "WWPWebClientId"   )]
      public string gxTpr_Wwpwebclientid
      {
         get {
            return gxTv_SdtWWP_WebClient_Wwpwebclientid ;
         }

         set {
            if ( StringUtil.StrCmp(gxTv_SdtWWP_WebClient_Wwpwebclientid, value) != 0 )
            {
               gxTv_SdtWWP_WebClient_Mode = "INS";
               this.gxTv_SdtWWP_WebClient_Wwpwebclientid_Z_SetNull( );
               this.gxTv_SdtWWP_WebClient_Wwpwebclientbrowserid_Z_SetNull( );
               this.gxTv_SdtWWP_WebClient_Wwpwebclientfirstregistered_Z_SetNull( );
               this.gxTv_SdtWWP_WebClient_Wwpwebclientlastregistered_Z_SetNull( );
               this.gxTv_SdtWWP_WebClient_Wwpuserextendedid_Z_SetNull( );
            }
            gxTv_SdtWWP_WebClient_Wwpwebclientid = value;
            SetDirty("Wwpwebclientid");
         }

      }

      [  SoapElement( ElementName = "WWPWebClientBrowserId" )]
      [  XmlElement( ElementName = "WWPWebClientBrowserId"   )]
      public short gxTpr_Wwpwebclientbrowserid
      {
         get {
            return gxTv_SdtWWP_WebClient_Wwpwebclientbrowserid ;
         }

         set {
            gxTv_SdtWWP_WebClient_Wwpwebclientbrowserid = value;
            SetDirty("Wwpwebclientbrowserid");
         }

      }

      [  SoapElement( ElementName = "WWPWebClientBrowserVersion" )]
      [  XmlElement( ElementName = "WWPWebClientBrowserVersion"   )]
      public string gxTpr_Wwpwebclientbrowserversion
      {
         get {
            return gxTv_SdtWWP_WebClient_Wwpwebclientbrowserversion ;
         }

         set {
            gxTv_SdtWWP_WebClient_Wwpwebclientbrowserversion = value;
            SetDirty("Wwpwebclientbrowserversion");
         }

      }

      [  SoapElement( ElementName = "WWPWebClientFirstRegistered" )]
      [  XmlElement( ElementName = "WWPWebClientFirstRegistered"  , IsNullable=true )]
      public string gxTpr_Wwpwebclientfirstregistered_Nullable
      {
         get {
            if ( gxTv_SdtWWP_WebClient_Wwpwebclientfirstregistered == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_WebClient_Wwpwebclientfirstregistered, null, true).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_WebClient_Wwpwebclientfirstregistered = DateTime.MinValue;
            else
               gxTv_SdtWWP_WebClient_Wwpwebclientfirstregistered = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Wwpwebclientfirstregistered
      {
         get {
            return gxTv_SdtWWP_WebClient_Wwpwebclientfirstregistered ;
         }

         set {
            gxTv_SdtWWP_WebClient_Wwpwebclientfirstregistered = value;
            SetDirty("Wwpwebclientfirstregistered");
         }

      }

      [  SoapElement( ElementName = "WWPWebClientLastRegistered" )]
      [  XmlElement( ElementName = "WWPWebClientLastRegistered"  , IsNullable=true )]
      public string gxTpr_Wwpwebclientlastregistered_Nullable
      {
         get {
            if ( gxTv_SdtWWP_WebClient_Wwpwebclientlastregistered == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_WebClient_Wwpwebclientlastregistered, null, true).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_WebClient_Wwpwebclientlastregistered = DateTime.MinValue;
            else
               gxTv_SdtWWP_WebClient_Wwpwebclientlastregistered = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Wwpwebclientlastregistered
      {
         get {
            return gxTv_SdtWWP_WebClient_Wwpwebclientlastregistered ;
         }

         set {
            gxTv_SdtWWP_WebClient_Wwpwebclientlastregistered = value;
            SetDirty("Wwpwebclientlastregistered");
         }

      }

      [  SoapElement( ElementName = "WWPUserExtendedId" )]
      [  XmlElement( ElementName = "WWPUserExtendedId"   )]
      public string gxTpr_Wwpuserextendedid
      {
         get {
            return gxTv_SdtWWP_WebClient_Wwpuserextendedid ;
         }

         set {
            gxTv_SdtWWP_WebClient_Wwpuserextendedid_N = 0;
            gxTv_SdtWWP_WebClient_Wwpuserextendedid = value;
            SetDirty("Wwpuserextendedid");
         }

      }

      public void gxTv_SdtWWP_WebClient_Wwpuserextendedid_SetNull( )
      {
         gxTv_SdtWWP_WebClient_Wwpuserextendedid_N = 1;
         gxTv_SdtWWP_WebClient_Wwpuserextendedid = "";
         return  ;
      }

      public bool gxTv_SdtWWP_WebClient_Wwpuserextendedid_IsNull( )
      {
         return (gxTv_SdtWWP_WebClient_Wwpuserextendedid_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtWWP_WebClient_Mode ;
         }

         set {
            gxTv_SdtWWP_WebClient_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtWWP_WebClient_Mode_SetNull( )
      {
         gxTv_SdtWWP_WebClient_Mode = "";
         return  ;
      }

      public bool gxTv_SdtWWP_WebClient_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtWWP_WebClient_Initialized ;
         }

         set {
            gxTv_SdtWWP_WebClient_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtWWP_WebClient_Initialized_SetNull( )
      {
         gxTv_SdtWWP_WebClient_Initialized = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_WebClient_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPWebClientId_Z" )]
      [  XmlElement( ElementName = "WWPWebClientId_Z"   )]
      public string gxTpr_Wwpwebclientid_Z
      {
         get {
            return gxTv_SdtWWP_WebClient_Wwpwebclientid_Z ;
         }

         set {
            gxTv_SdtWWP_WebClient_Wwpwebclientid_Z = value;
            SetDirty("Wwpwebclientid_Z");
         }

      }

      public void gxTv_SdtWWP_WebClient_Wwpwebclientid_Z_SetNull( )
      {
         gxTv_SdtWWP_WebClient_Wwpwebclientid_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_WebClient_Wwpwebclientid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPWebClientBrowserId_Z" )]
      [  XmlElement( ElementName = "WWPWebClientBrowserId_Z"   )]
      public short gxTpr_Wwpwebclientbrowserid_Z
      {
         get {
            return gxTv_SdtWWP_WebClient_Wwpwebclientbrowserid_Z ;
         }

         set {
            gxTv_SdtWWP_WebClient_Wwpwebclientbrowserid_Z = value;
            SetDirty("Wwpwebclientbrowserid_Z");
         }

      }

      public void gxTv_SdtWWP_WebClient_Wwpwebclientbrowserid_Z_SetNull( )
      {
         gxTv_SdtWWP_WebClient_Wwpwebclientbrowserid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_WebClient_Wwpwebclientbrowserid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPWebClientFirstRegistered_Z" )]
      [  XmlElement( ElementName = "WWPWebClientFirstRegistered_Z"  , IsNullable=true )]
      public string gxTpr_Wwpwebclientfirstregistered_Z_Nullable
      {
         get {
            if ( gxTv_SdtWWP_WebClient_Wwpwebclientfirstregistered_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_WebClient_Wwpwebclientfirstregistered_Z, null, true).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_WebClient_Wwpwebclientfirstregistered_Z = DateTime.MinValue;
            else
               gxTv_SdtWWP_WebClient_Wwpwebclientfirstregistered_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Wwpwebclientfirstregistered_Z
      {
         get {
            return gxTv_SdtWWP_WebClient_Wwpwebclientfirstregistered_Z ;
         }

         set {
            gxTv_SdtWWP_WebClient_Wwpwebclientfirstregistered_Z = value;
            SetDirty("Wwpwebclientfirstregistered_Z");
         }

      }

      public void gxTv_SdtWWP_WebClient_Wwpwebclientfirstregistered_Z_SetNull( )
      {
         gxTv_SdtWWP_WebClient_Wwpwebclientfirstregistered_Z = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtWWP_WebClient_Wwpwebclientfirstregistered_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPWebClientLastRegistered_Z" )]
      [  XmlElement( ElementName = "WWPWebClientLastRegistered_Z"  , IsNullable=true )]
      public string gxTpr_Wwpwebclientlastregistered_Z_Nullable
      {
         get {
            if ( gxTv_SdtWWP_WebClient_Wwpwebclientlastregistered_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_WebClient_Wwpwebclientlastregistered_Z, null, true).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_WebClient_Wwpwebclientlastregistered_Z = DateTime.MinValue;
            else
               gxTv_SdtWWP_WebClient_Wwpwebclientlastregistered_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Wwpwebclientlastregistered_Z
      {
         get {
            return gxTv_SdtWWP_WebClient_Wwpwebclientlastregistered_Z ;
         }

         set {
            gxTv_SdtWWP_WebClient_Wwpwebclientlastregistered_Z = value;
            SetDirty("Wwpwebclientlastregistered_Z");
         }

      }

      public void gxTv_SdtWWP_WebClient_Wwpwebclientlastregistered_Z_SetNull( )
      {
         gxTv_SdtWWP_WebClient_Wwpwebclientlastregistered_Z = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtWWP_WebClient_Wwpwebclientlastregistered_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPUserExtendedId_Z" )]
      [  XmlElement( ElementName = "WWPUserExtendedId_Z"   )]
      public string gxTpr_Wwpuserextendedid_Z
      {
         get {
            return gxTv_SdtWWP_WebClient_Wwpuserextendedid_Z ;
         }

         set {
            gxTv_SdtWWP_WebClient_Wwpuserextendedid_Z = value;
            SetDirty("Wwpuserextendedid_Z");
         }

      }

      public void gxTv_SdtWWP_WebClient_Wwpuserextendedid_Z_SetNull( )
      {
         gxTv_SdtWWP_WebClient_Wwpuserextendedid_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_WebClient_Wwpuserextendedid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPUserExtendedId_N" )]
      [  XmlElement( ElementName = "WWPUserExtendedId_N"   )]
      public short gxTpr_Wwpuserextendedid_N
      {
         get {
            return gxTv_SdtWWP_WebClient_Wwpuserextendedid_N ;
         }

         set {
            gxTv_SdtWWP_WebClient_Wwpuserextendedid_N = value;
            SetDirty("Wwpuserextendedid_N");
         }

      }

      public void gxTv_SdtWWP_WebClient_Wwpuserextendedid_N_SetNull( )
      {
         gxTv_SdtWWP_WebClient_Wwpuserextendedid_N = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_WebClient_Wwpuserextendedid_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtWWP_WebClient_Wwpwebclientid = "";
         gxTv_SdtWWP_WebClient_Wwpwebclientbrowserversion = "";
         gxTv_SdtWWP_WebClient_Wwpwebclientfirstregistered = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_WebClient_Wwpwebclientlastregistered = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_WebClient_Wwpuserextendedid = "";
         gxTv_SdtWWP_WebClient_Mode = "";
         gxTv_SdtWWP_WebClient_Wwpwebclientid_Z = "";
         gxTv_SdtWWP_WebClient_Wwpwebclientfirstregistered_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_WebClient_Wwpwebclientlastregistered_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_WebClient_Wwpuserextendedid_Z = "";
         datetimemil_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "wwpbaseobjects.notifications.web.wwp_webclient", "GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webclient_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      private short gxTv_SdtWWP_WebClient_Wwpwebclientbrowserid ;
      private short gxTv_SdtWWP_WebClient_Initialized ;
      private short gxTv_SdtWWP_WebClient_Wwpwebclientbrowserid_Z ;
      private short gxTv_SdtWWP_WebClient_Wwpuserextendedid_N ;
      private string gxTv_SdtWWP_WebClient_Wwpwebclientid ;
      private string gxTv_SdtWWP_WebClient_Wwpuserextendedid ;
      private string gxTv_SdtWWP_WebClient_Mode ;
      private string gxTv_SdtWWP_WebClient_Wwpwebclientid_Z ;
      private string gxTv_SdtWWP_WebClient_Wwpuserextendedid_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtWWP_WebClient_Wwpwebclientfirstregistered ;
      private DateTime gxTv_SdtWWP_WebClient_Wwpwebclientlastregistered ;
      private DateTime gxTv_SdtWWP_WebClient_Wwpwebclientfirstregistered_Z ;
      private DateTime gxTv_SdtWWP_WebClient_Wwpwebclientlastregistered_Z ;
      private DateTime datetimemil_STZ ;
      private string gxTv_SdtWWP_WebClient_Wwpwebclientbrowserversion ;
   }

   [DataContract(Name = @"WWPBaseObjects\Notifications\Web\WWP_WebClient", Namespace = "RastreamentoTCC")]
   public class SdtWWP_WebClient_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWWP_WebClient_RESTInterface( ) : base()
      {
      }

      public SdtWWP_WebClient_RESTInterface( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WWPWebClientId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Wwpwebclientid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Wwpwebclientid) ;
         }

         set {
            sdt.gxTpr_Wwpwebclientid = value;
         }

      }

      [DataMember( Name = "WWPWebClientBrowserId" , Order = 1 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Wwpwebclientbrowserid
      {
         get {
            return sdt.gxTpr_Wwpwebclientbrowserid ;
         }

         set {
            sdt.gxTpr_Wwpwebclientbrowserid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPWebClientBrowserVersion" , Order = 2 )]
      public string gxTpr_Wwpwebclientbrowserversion
      {
         get {
            return sdt.gxTpr_Wwpwebclientbrowserversion ;
         }

         set {
            sdt.gxTpr_Wwpwebclientbrowserversion = value;
         }

      }

      [DataMember( Name = "WWPWebClientFirstRegistered" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Wwpwebclientfirstregistered
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Wwpwebclientfirstregistered) ;
         }

         set {
            sdt.gxTpr_Wwpwebclientfirstregistered = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "WWPWebClientLastRegistered" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Wwpwebclientlastregistered
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Wwpwebclientlastregistered) ;
         }

         set {
            sdt.gxTpr_Wwpwebclientlastregistered = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "WWPUserExtendedId" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Wwpuserextendedid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Wwpuserextendedid) ;
         }

         set {
            sdt.gxTpr_Wwpuserextendedid = value;
         }

      }

      public GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 6 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"WWPBaseObjects\Notifications\Web\WWP_WebClient", Namespace = "RastreamentoTCC")]
   public class SdtWWP_WebClient_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWWP_WebClient_RESTLInterface( ) : base()
      {
      }

      public SdtWWP_WebClient_RESTLInterface( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WWPWebClientId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Wwpwebclientid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Wwpwebclientid) ;
         }

         set {
            sdt.gxTpr_Wwpwebclientid = value;
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            string gxuri = "/rest/WWPBaseObjects\\Notifications\\Web\\WWP_WebClient/{0}";
            gxuri = String.Format(gxuri,gxTpr_Wwpwebclientid) ;
            return gxuri ;
         }

         set {
         }

      }

      public GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient() ;
         }
      }

      private string gxuri ;
   }

}
