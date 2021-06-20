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
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   [XmlSerializerFormat]
   [XmlRoot(ElementName = "WWP_Notification" )]
   [XmlType(TypeName =  "WWP_Notification" , Namespace = "RastreamentoTCC" )]
   [Serializable]
   public class SdtWWP_Notification : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWWP_Notification( )
      {
      }

      public SdtWWP_Notification( IGxContext context )
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

      public void Load( long AV16WWPNotificationId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(long)AV16WWPNotificationId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"WWPNotificationId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "WWPBaseObjects\\Notifications\\Common\\WWP_Notification");
         metadata.Set("BT", "WWP_Notification");
         metadata.Set("PK", "[ \"WWPNotificationId\" ]");
         metadata.Set("PKAssigned", "[ \"WWPNotificationId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"WWPNotificationDefinitionId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"WWPUserExtendedId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Wwpnotificationid_Z");
         state.Add("gxTpr_Wwpnotificationdefinitionid_Z");
         state.Add("gxTpr_Wwpnotificationdefinitionname_Z");
         state.Add("gxTpr_Wwpnotificationcreated_Z_Nullable");
         state.Add("gxTpr_Wwpnotificationicon_Z");
         state.Add("gxTpr_Wwpnotificationtitle_Z");
         state.Add("gxTpr_Wwpnotificationshortdescription_Z");
         state.Add("gxTpr_Wwpnotificationlink_Z");
         state.Add("gxTpr_Wwpnotificationisread_Z");
         state.Add("gxTpr_Wwpuserextendedid_Z");
         state.Add("gxTpr_Wwpuserextendedfullname_Z");
         state.Add("gxTpr_Wwpnotificationid_N");
         state.Add("gxTpr_Wwpuserextendedid_N");
         state.Add("gxTpr_Wwpnotificationmetadata_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification sdt;
         sdt = (GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification)(source);
         gxTv_SdtWWP_Notification_Wwpnotificationid = sdt.gxTv_SdtWWP_Notification_Wwpnotificationid ;
         gxTv_SdtWWP_Notification_Wwpnotificationdefinitionid = sdt.gxTv_SdtWWP_Notification_Wwpnotificationdefinitionid ;
         gxTv_SdtWWP_Notification_Wwpnotificationdefinitionname = sdt.gxTv_SdtWWP_Notification_Wwpnotificationdefinitionname ;
         gxTv_SdtWWP_Notification_Wwpnotificationcreated = sdt.gxTv_SdtWWP_Notification_Wwpnotificationcreated ;
         gxTv_SdtWWP_Notification_Wwpnotificationicon = sdt.gxTv_SdtWWP_Notification_Wwpnotificationicon ;
         gxTv_SdtWWP_Notification_Wwpnotificationtitle = sdt.gxTv_SdtWWP_Notification_Wwpnotificationtitle ;
         gxTv_SdtWWP_Notification_Wwpnotificationshortdescription = sdt.gxTv_SdtWWP_Notification_Wwpnotificationshortdescription ;
         gxTv_SdtWWP_Notification_Wwpnotificationlink = sdt.gxTv_SdtWWP_Notification_Wwpnotificationlink ;
         gxTv_SdtWWP_Notification_Wwpnotificationisread = sdt.gxTv_SdtWWP_Notification_Wwpnotificationisread ;
         gxTv_SdtWWP_Notification_Wwpuserextendedid = sdt.gxTv_SdtWWP_Notification_Wwpuserextendedid ;
         gxTv_SdtWWP_Notification_Wwpuserextendedfullname = sdt.gxTv_SdtWWP_Notification_Wwpuserextendedfullname ;
         gxTv_SdtWWP_Notification_Wwpnotificationmetadata = sdt.gxTv_SdtWWP_Notification_Wwpnotificationmetadata ;
         gxTv_SdtWWP_Notification_Mode = sdt.gxTv_SdtWWP_Notification_Mode ;
         gxTv_SdtWWP_Notification_Initialized = sdt.gxTv_SdtWWP_Notification_Initialized ;
         gxTv_SdtWWP_Notification_Wwpnotificationid_Z = sdt.gxTv_SdtWWP_Notification_Wwpnotificationid_Z ;
         gxTv_SdtWWP_Notification_Wwpnotificationdefinitionid_Z = sdt.gxTv_SdtWWP_Notification_Wwpnotificationdefinitionid_Z ;
         gxTv_SdtWWP_Notification_Wwpnotificationdefinitionname_Z = sdt.gxTv_SdtWWP_Notification_Wwpnotificationdefinitionname_Z ;
         gxTv_SdtWWP_Notification_Wwpnotificationcreated_Z = sdt.gxTv_SdtWWP_Notification_Wwpnotificationcreated_Z ;
         gxTv_SdtWWP_Notification_Wwpnotificationicon_Z = sdt.gxTv_SdtWWP_Notification_Wwpnotificationicon_Z ;
         gxTv_SdtWWP_Notification_Wwpnotificationtitle_Z = sdt.gxTv_SdtWWP_Notification_Wwpnotificationtitle_Z ;
         gxTv_SdtWWP_Notification_Wwpnotificationshortdescription_Z = sdt.gxTv_SdtWWP_Notification_Wwpnotificationshortdescription_Z ;
         gxTv_SdtWWP_Notification_Wwpnotificationlink_Z = sdt.gxTv_SdtWWP_Notification_Wwpnotificationlink_Z ;
         gxTv_SdtWWP_Notification_Wwpnotificationisread_Z = sdt.gxTv_SdtWWP_Notification_Wwpnotificationisread_Z ;
         gxTv_SdtWWP_Notification_Wwpuserextendedid_Z = sdt.gxTv_SdtWWP_Notification_Wwpuserextendedid_Z ;
         gxTv_SdtWWP_Notification_Wwpuserextendedfullname_Z = sdt.gxTv_SdtWWP_Notification_Wwpuserextendedfullname_Z ;
         gxTv_SdtWWP_Notification_Wwpnotificationid_N = sdt.gxTv_SdtWWP_Notification_Wwpnotificationid_N ;
         gxTv_SdtWWP_Notification_Wwpuserextendedid_N = sdt.gxTv_SdtWWP_Notification_Wwpuserextendedid_N ;
         gxTv_SdtWWP_Notification_Wwpnotificationmetadata_N = sdt.gxTv_SdtWWP_Notification_Wwpnotificationmetadata_N ;
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
         AddObjectProperty("WWPNotificationId", gxTv_SdtWWP_Notification_Wwpnotificationid, false, includeNonInitialized);
         AddObjectProperty("WWPNotificationId_N", gxTv_SdtWWP_Notification_Wwpnotificationid_N, false, includeNonInitialized);
         AddObjectProperty("WWPNotificationDefinitionId", gxTv_SdtWWP_Notification_Wwpnotificationdefinitionid, false, includeNonInitialized);
         AddObjectProperty("WWPNotificationDefinitionName", gxTv_SdtWWP_Notification_Wwpnotificationdefinitionname, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtWWP_Notification_Wwpnotificationcreated;
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
         AddObjectProperty("WWPNotificationCreated", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("WWPNotificationIcon", gxTv_SdtWWP_Notification_Wwpnotificationicon, false, includeNonInitialized);
         AddObjectProperty("WWPNotificationTitle", gxTv_SdtWWP_Notification_Wwpnotificationtitle, false, includeNonInitialized);
         AddObjectProperty("WWPNotificationShortDescription", gxTv_SdtWWP_Notification_Wwpnotificationshortdescription, false, includeNonInitialized);
         AddObjectProperty("WWPNotificationLink", gxTv_SdtWWP_Notification_Wwpnotificationlink, false, includeNonInitialized);
         AddObjectProperty("WWPNotificationIsRead", gxTv_SdtWWP_Notification_Wwpnotificationisread, false, includeNonInitialized);
         AddObjectProperty("WWPUserExtendedId", gxTv_SdtWWP_Notification_Wwpuserextendedid, false, includeNonInitialized);
         AddObjectProperty("WWPUserExtendedId_N", gxTv_SdtWWP_Notification_Wwpuserextendedid_N, false, includeNonInitialized);
         AddObjectProperty("WWPUserExtendedFullName", gxTv_SdtWWP_Notification_Wwpuserextendedfullname, false, includeNonInitialized);
         AddObjectProperty("WWPNotificationMetadata", gxTv_SdtWWP_Notification_Wwpnotificationmetadata, false, includeNonInitialized);
         AddObjectProperty("WWPNotificationMetadata_N", gxTv_SdtWWP_Notification_Wwpnotificationmetadata_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtWWP_Notification_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtWWP_Notification_Initialized, false, includeNonInitialized);
            AddObjectProperty("WWPNotificationId_Z", gxTv_SdtWWP_Notification_Wwpnotificationid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPNotificationDefinitionId_Z", gxTv_SdtWWP_Notification_Wwpnotificationdefinitionid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPNotificationDefinitionName_Z", gxTv_SdtWWP_Notification_Wwpnotificationdefinitionname_Z, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtWWP_Notification_Wwpnotificationcreated_Z;
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
            AddObjectProperty("WWPNotificationCreated_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("WWPNotificationIcon_Z", gxTv_SdtWWP_Notification_Wwpnotificationicon_Z, false, includeNonInitialized);
            AddObjectProperty("WWPNotificationTitle_Z", gxTv_SdtWWP_Notification_Wwpnotificationtitle_Z, false, includeNonInitialized);
            AddObjectProperty("WWPNotificationShortDescription_Z", gxTv_SdtWWP_Notification_Wwpnotificationshortdescription_Z, false, includeNonInitialized);
            AddObjectProperty("WWPNotificationLink_Z", gxTv_SdtWWP_Notification_Wwpnotificationlink_Z, false, includeNonInitialized);
            AddObjectProperty("WWPNotificationIsRead_Z", gxTv_SdtWWP_Notification_Wwpnotificationisread_Z, false, includeNonInitialized);
            AddObjectProperty("WWPUserExtendedId_Z", gxTv_SdtWWP_Notification_Wwpuserextendedid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPUserExtendedFullName_Z", gxTv_SdtWWP_Notification_Wwpuserextendedfullname_Z, false, includeNonInitialized);
            AddObjectProperty("WWPNotificationId_N", gxTv_SdtWWP_Notification_Wwpnotificationid_N, false, includeNonInitialized);
            AddObjectProperty("WWPUserExtendedId_N", gxTv_SdtWWP_Notification_Wwpuserextendedid_N, false, includeNonInitialized);
            AddObjectProperty("WWPNotificationMetadata_N", gxTv_SdtWWP_Notification_Wwpnotificationmetadata_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification sdt )
      {
         if ( sdt.IsDirty("WWPNotificationId") )
         {
            gxTv_SdtWWP_Notification_Wwpnotificationid = sdt.gxTv_SdtWWP_Notification_Wwpnotificationid ;
         }
         if ( sdt.IsDirty("WWPNotificationDefinitionId") )
         {
            gxTv_SdtWWP_Notification_Wwpnotificationdefinitionid = sdt.gxTv_SdtWWP_Notification_Wwpnotificationdefinitionid ;
         }
         if ( sdt.IsDirty("WWPNotificationDefinitionName") )
         {
            gxTv_SdtWWP_Notification_Wwpnotificationdefinitionname = sdt.gxTv_SdtWWP_Notification_Wwpnotificationdefinitionname ;
         }
         if ( sdt.IsDirty("WWPNotificationCreated") )
         {
            gxTv_SdtWWP_Notification_Wwpnotificationcreated = sdt.gxTv_SdtWWP_Notification_Wwpnotificationcreated ;
         }
         if ( sdt.IsDirty("WWPNotificationIcon") )
         {
            gxTv_SdtWWP_Notification_Wwpnotificationicon = sdt.gxTv_SdtWWP_Notification_Wwpnotificationicon ;
         }
         if ( sdt.IsDirty("WWPNotificationTitle") )
         {
            gxTv_SdtWWP_Notification_Wwpnotificationtitle = sdt.gxTv_SdtWWP_Notification_Wwpnotificationtitle ;
         }
         if ( sdt.IsDirty("WWPNotificationShortDescription") )
         {
            gxTv_SdtWWP_Notification_Wwpnotificationshortdescription = sdt.gxTv_SdtWWP_Notification_Wwpnotificationshortdescription ;
         }
         if ( sdt.IsDirty("WWPNotificationLink") )
         {
            gxTv_SdtWWP_Notification_Wwpnotificationlink = sdt.gxTv_SdtWWP_Notification_Wwpnotificationlink ;
         }
         if ( sdt.IsDirty("WWPNotificationIsRead") )
         {
            gxTv_SdtWWP_Notification_Wwpnotificationisread = sdt.gxTv_SdtWWP_Notification_Wwpnotificationisread ;
         }
         if ( sdt.IsDirty("WWPUserExtendedId") )
         {
            gxTv_SdtWWP_Notification_Wwpuserextendedid_N = 0;
            gxTv_SdtWWP_Notification_Wwpuserextendedid = sdt.gxTv_SdtWWP_Notification_Wwpuserextendedid ;
         }
         if ( sdt.IsDirty("WWPUserExtendedFullName") )
         {
            gxTv_SdtWWP_Notification_Wwpuserextendedfullname = sdt.gxTv_SdtWWP_Notification_Wwpuserextendedfullname ;
         }
         if ( sdt.IsDirty("WWPNotificationMetadata") )
         {
            gxTv_SdtWWP_Notification_Wwpnotificationmetadata_N = 0;
            gxTv_SdtWWP_Notification_Wwpnotificationmetadata = sdt.gxTv_SdtWWP_Notification_Wwpnotificationmetadata ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "WWPNotificationId" )]
      [  XmlElement( ElementName = "WWPNotificationId"   )]
      public long gxTpr_Wwpnotificationid
      {
         get {
            return gxTv_SdtWWP_Notification_Wwpnotificationid ;
         }

         set {
            if ( gxTv_SdtWWP_Notification_Wwpnotificationid != value )
            {
               gxTv_SdtWWP_Notification_Mode = "INS";
               this.gxTv_SdtWWP_Notification_Wwpnotificationid_Z_SetNull( );
               this.gxTv_SdtWWP_Notification_Wwpnotificationdefinitionid_Z_SetNull( );
               this.gxTv_SdtWWP_Notification_Wwpnotificationdefinitionname_Z_SetNull( );
               this.gxTv_SdtWWP_Notification_Wwpnotificationcreated_Z_SetNull( );
               this.gxTv_SdtWWP_Notification_Wwpnotificationicon_Z_SetNull( );
               this.gxTv_SdtWWP_Notification_Wwpnotificationtitle_Z_SetNull( );
               this.gxTv_SdtWWP_Notification_Wwpnotificationshortdescription_Z_SetNull( );
               this.gxTv_SdtWWP_Notification_Wwpnotificationlink_Z_SetNull( );
               this.gxTv_SdtWWP_Notification_Wwpnotificationisread_Z_SetNull( );
               this.gxTv_SdtWWP_Notification_Wwpuserextendedid_Z_SetNull( );
               this.gxTv_SdtWWP_Notification_Wwpuserextendedfullname_Z_SetNull( );
            }
            gxTv_SdtWWP_Notification_Wwpnotificationid = value;
            SetDirty("Wwpnotificationid");
         }

      }

      [  SoapElement( ElementName = "WWPNotificationDefinitionId" )]
      [  XmlElement( ElementName = "WWPNotificationDefinitionId"   )]
      public long gxTpr_Wwpnotificationdefinitionid
      {
         get {
            return gxTv_SdtWWP_Notification_Wwpnotificationdefinitionid ;
         }

         set {
            gxTv_SdtWWP_Notification_Wwpnotificationdefinitionid = value;
            SetDirty("Wwpnotificationdefinitionid");
         }

      }

      [  SoapElement( ElementName = "WWPNotificationDefinitionName" )]
      [  XmlElement( ElementName = "WWPNotificationDefinitionName"   )]
      public string gxTpr_Wwpnotificationdefinitionname
      {
         get {
            return gxTv_SdtWWP_Notification_Wwpnotificationdefinitionname ;
         }

         set {
            gxTv_SdtWWP_Notification_Wwpnotificationdefinitionname = value;
            SetDirty("Wwpnotificationdefinitionname");
         }

      }

      [  SoapElement( ElementName = "WWPNotificationCreated" )]
      [  XmlElement( ElementName = "WWPNotificationCreated"  , IsNullable=true )]
      public string gxTpr_Wwpnotificationcreated_Nullable
      {
         get {
            if ( gxTv_SdtWWP_Notification_Wwpnotificationcreated == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_Notification_Wwpnotificationcreated, null, true).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_Notification_Wwpnotificationcreated = DateTime.MinValue;
            else
               gxTv_SdtWWP_Notification_Wwpnotificationcreated = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Wwpnotificationcreated
      {
         get {
            return gxTv_SdtWWP_Notification_Wwpnotificationcreated ;
         }

         set {
            gxTv_SdtWWP_Notification_Wwpnotificationcreated = value;
            SetDirty("Wwpnotificationcreated");
         }

      }

      [  SoapElement( ElementName = "WWPNotificationIcon" )]
      [  XmlElement( ElementName = "WWPNotificationIcon"   )]
      public string gxTpr_Wwpnotificationicon
      {
         get {
            return gxTv_SdtWWP_Notification_Wwpnotificationicon ;
         }

         set {
            gxTv_SdtWWP_Notification_Wwpnotificationicon = value;
            SetDirty("Wwpnotificationicon");
         }

      }

      [  SoapElement( ElementName = "WWPNotificationTitle" )]
      [  XmlElement( ElementName = "WWPNotificationTitle"   )]
      public string gxTpr_Wwpnotificationtitle
      {
         get {
            return gxTv_SdtWWP_Notification_Wwpnotificationtitle ;
         }

         set {
            gxTv_SdtWWP_Notification_Wwpnotificationtitle = value;
            SetDirty("Wwpnotificationtitle");
         }

      }

      [  SoapElement( ElementName = "WWPNotificationShortDescription" )]
      [  XmlElement( ElementName = "WWPNotificationShortDescription"   )]
      public string gxTpr_Wwpnotificationshortdescription
      {
         get {
            return gxTv_SdtWWP_Notification_Wwpnotificationshortdescription ;
         }

         set {
            gxTv_SdtWWP_Notification_Wwpnotificationshortdescription = value;
            SetDirty("Wwpnotificationshortdescription");
         }

      }

      [  SoapElement( ElementName = "WWPNotificationLink" )]
      [  XmlElement( ElementName = "WWPNotificationLink"   )]
      public string gxTpr_Wwpnotificationlink
      {
         get {
            return gxTv_SdtWWP_Notification_Wwpnotificationlink ;
         }

         set {
            gxTv_SdtWWP_Notification_Wwpnotificationlink = value;
            SetDirty("Wwpnotificationlink");
         }

      }

      [  SoapElement( ElementName = "WWPNotificationIsRead" )]
      [  XmlElement( ElementName = "WWPNotificationIsRead"   )]
      public bool gxTpr_Wwpnotificationisread
      {
         get {
            return gxTv_SdtWWP_Notification_Wwpnotificationisread ;
         }

         set {
            gxTv_SdtWWP_Notification_Wwpnotificationisread = value;
            SetDirty("Wwpnotificationisread");
         }

      }

      [  SoapElement( ElementName = "WWPUserExtendedId" )]
      [  XmlElement( ElementName = "WWPUserExtendedId"   )]
      public string gxTpr_Wwpuserextendedid
      {
         get {
            return gxTv_SdtWWP_Notification_Wwpuserextendedid ;
         }

         set {
            gxTv_SdtWWP_Notification_Wwpuserextendedid_N = 0;
            gxTv_SdtWWP_Notification_Wwpuserextendedid = value;
            SetDirty("Wwpuserextendedid");
         }

      }

      public void gxTv_SdtWWP_Notification_Wwpuserextendedid_SetNull( )
      {
         gxTv_SdtWWP_Notification_Wwpuserextendedid_N = 1;
         gxTv_SdtWWP_Notification_Wwpuserextendedid = "";
         return  ;
      }

      public bool gxTv_SdtWWP_Notification_Wwpuserextendedid_IsNull( )
      {
         return (gxTv_SdtWWP_Notification_Wwpuserextendedid_N==1) ;
      }

      [  SoapElement( ElementName = "WWPUserExtendedFullName" )]
      [  XmlElement( ElementName = "WWPUserExtendedFullName"   )]
      public string gxTpr_Wwpuserextendedfullname
      {
         get {
            return gxTv_SdtWWP_Notification_Wwpuserextendedfullname ;
         }

         set {
            gxTv_SdtWWP_Notification_Wwpuserextendedfullname = value;
            SetDirty("Wwpuserextendedfullname");
         }

      }

      public void gxTv_SdtWWP_Notification_Wwpuserextendedfullname_SetNull( )
      {
         gxTv_SdtWWP_Notification_Wwpuserextendedfullname = "";
         return  ;
      }

      public bool gxTv_SdtWWP_Notification_Wwpuserextendedfullname_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationMetadata" )]
      [  XmlElement( ElementName = "WWPNotificationMetadata"   )]
      public string gxTpr_Wwpnotificationmetadata
      {
         get {
            return gxTv_SdtWWP_Notification_Wwpnotificationmetadata ;
         }

         set {
            gxTv_SdtWWP_Notification_Wwpnotificationmetadata_N = 0;
            gxTv_SdtWWP_Notification_Wwpnotificationmetadata = value;
            SetDirty("Wwpnotificationmetadata");
         }

      }

      public void gxTv_SdtWWP_Notification_Wwpnotificationmetadata_SetNull( )
      {
         gxTv_SdtWWP_Notification_Wwpnotificationmetadata_N = 1;
         gxTv_SdtWWP_Notification_Wwpnotificationmetadata = "";
         return  ;
      }

      public bool gxTv_SdtWWP_Notification_Wwpnotificationmetadata_IsNull( )
      {
         return (gxTv_SdtWWP_Notification_Wwpnotificationmetadata_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtWWP_Notification_Mode ;
         }

         set {
            gxTv_SdtWWP_Notification_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtWWP_Notification_Mode_SetNull( )
      {
         gxTv_SdtWWP_Notification_Mode = "";
         return  ;
      }

      public bool gxTv_SdtWWP_Notification_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtWWP_Notification_Initialized ;
         }

         set {
            gxTv_SdtWWP_Notification_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtWWP_Notification_Initialized_SetNull( )
      {
         gxTv_SdtWWP_Notification_Initialized = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_Notification_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationId_Z" )]
      [  XmlElement( ElementName = "WWPNotificationId_Z"   )]
      public long gxTpr_Wwpnotificationid_Z
      {
         get {
            return gxTv_SdtWWP_Notification_Wwpnotificationid_Z ;
         }

         set {
            gxTv_SdtWWP_Notification_Wwpnotificationid_Z = value;
            SetDirty("Wwpnotificationid_Z");
         }

      }

      public void gxTv_SdtWWP_Notification_Wwpnotificationid_Z_SetNull( )
      {
         gxTv_SdtWWP_Notification_Wwpnotificationid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_Notification_Wwpnotificationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationDefinitionId_Z" )]
      [  XmlElement( ElementName = "WWPNotificationDefinitionId_Z"   )]
      public long gxTpr_Wwpnotificationdefinitionid_Z
      {
         get {
            return gxTv_SdtWWP_Notification_Wwpnotificationdefinitionid_Z ;
         }

         set {
            gxTv_SdtWWP_Notification_Wwpnotificationdefinitionid_Z = value;
            SetDirty("Wwpnotificationdefinitionid_Z");
         }

      }

      public void gxTv_SdtWWP_Notification_Wwpnotificationdefinitionid_Z_SetNull( )
      {
         gxTv_SdtWWP_Notification_Wwpnotificationdefinitionid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_Notification_Wwpnotificationdefinitionid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationDefinitionName_Z" )]
      [  XmlElement( ElementName = "WWPNotificationDefinitionName_Z"   )]
      public string gxTpr_Wwpnotificationdefinitionname_Z
      {
         get {
            return gxTv_SdtWWP_Notification_Wwpnotificationdefinitionname_Z ;
         }

         set {
            gxTv_SdtWWP_Notification_Wwpnotificationdefinitionname_Z = value;
            SetDirty("Wwpnotificationdefinitionname_Z");
         }

      }

      public void gxTv_SdtWWP_Notification_Wwpnotificationdefinitionname_Z_SetNull( )
      {
         gxTv_SdtWWP_Notification_Wwpnotificationdefinitionname_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_Notification_Wwpnotificationdefinitionname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationCreated_Z" )]
      [  XmlElement( ElementName = "WWPNotificationCreated_Z"  , IsNullable=true )]
      public string gxTpr_Wwpnotificationcreated_Z_Nullable
      {
         get {
            if ( gxTv_SdtWWP_Notification_Wwpnotificationcreated_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_Notification_Wwpnotificationcreated_Z, null, true).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_Notification_Wwpnotificationcreated_Z = DateTime.MinValue;
            else
               gxTv_SdtWWP_Notification_Wwpnotificationcreated_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Wwpnotificationcreated_Z
      {
         get {
            return gxTv_SdtWWP_Notification_Wwpnotificationcreated_Z ;
         }

         set {
            gxTv_SdtWWP_Notification_Wwpnotificationcreated_Z = value;
            SetDirty("Wwpnotificationcreated_Z");
         }

      }

      public void gxTv_SdtWWP_Notification_Wwpnotificationcreated_Z_SetNull( )
      {
         gxTv_SdtWWP_Notification_Wwpnotificationcreated_Z = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtWWP_Notification_Wwpnotificationcreated_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationIcon_Z" )]
      [  XmlElement( ElementName = "WWPNotificationIcon_Z"   )]
      public string gxTpr_Wwpnotificationicon_Z
      {
         get {
            return gxTv_SdtWWP_Notification_Wwpnotificationicon_Z ;
         }

         set {
            gxTv_SdtWWP_Notification_Wwpnotificationicon_Z = value;
            SetDirty("Wwpnotificationicon_Z");
         }

      }

      public void gxTv_SdtWWP_Notification_Wwpnotificationicon_Z_SetNull( )
      {
         gxTv_SdtWWP_Notification_Wwpnotificationicon_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_Notification_Wwpnotificationicon_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationTitle_Z" )]
      [  XmlElement( ElementName = "WWPNotificationTitle_Z"   )]
      public string gxTpr_Wwpnotificationtitle_Z
      {
         get {
            return gxTv_SdtWWP_Notification_Wwpnotificationtitle_Z ;
         }

         set {
            gxTv_SdtWWP_Notification_Wwpnotificationtitle_Z = value;
            SetDirty("Wwpnotificationtitle_Z");
         }

      }

      public void gxTv_SdtWWP_Notification_Wwpnotificationtitle_Z_SetNull( )
      {
         gxTv_SdtWWP_Notification_Wwpnotificationtitle_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_Notification_Wwpnotificationtitle_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationShortDescription_Z" )]
      [  XmlElement( ElementName = "WWPNotificationShortDescription_Z"   )]
      public string gxTpr_Wwpnotificationshortdescription_Z
      {
         get {
            return gxTv_SdtWWP_Notification_Wwpnotificationshortdescription_Z ;
         }

         set {
            gxTv_SdtWWP_Notification_Wwpnotificationshortdescription_Z = value;
            SetDirty("Wwpnotificationshortdescription_Z");
         }

      }

      public void gxTv_SdtWWP_Notification_Wwpnotificationshortdescription_Z_SetNull( )
      {
         gxTv_SdtWWP_Notification_Wwpnotificationshortdescription_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_Notification_Wwpnotificationshortdescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationLink_Z" )]
      [  XmlElement( ElementName = "WWPNotificationLink_Z"   )]
      public string gxTpr_Wwpnotificationlink_Z
      {
         get {
            return gxTv_SdtWWP_Notification_Wwpnotificationlink_Z ;
         }

         set {
            gxTv_SdtWWP_Notification_Wwpnotificationlink_Z = value;
            SetDirty("Wwpnotificationlink_Z");
         }

      }

      public void gxTv_SdtWWP_Notification_Wwpnotificationlink_Z_SetNull( )
      {
         gxTv_SdtWWP_Notification_Wwpnotificationlink_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_Notification_Wwpnotificationlink_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationIsRead_Z" )]
      [  XmlElement( ElementName = "WWPNotificationIsRead_Z"   )]
      public bool gxTpr_Wwpnotificationisread_Z
      {
         get {
            return gxTv_SdtWWP_Notification_Wwpnotificationisread_Z ;
         }

         set {
            gxTv_SdtWWP_Notification_Wwpnotificationisread_Z = value;
            SetDirty("Wwpnotificationisread_Z");
         }

      }

      public void gxTv_SdtWWP_Notification_Wwpnotificationisread_Z_SetNull( )
      {
         gxTv_SdtWWP_Notification_Wwpnotificationisread_Z = false;
         return  ;
      }

      public bool gxTv_SdtWWP_Notification_Wwpnotificationisread_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPUserExtendedId_Z" )]
      [  XmlElement( ElementName = "WWPUserExtendedId_Z"   )]
      public string gxTpr_Wwpuserextendedid_Z
      {
         get {
            return gxTv_SdtWWP_Notification_Wwpuserextendedid_Z ;
         }

         set {
            gxTv_SdtWWP_Notification_Wwpuserextendedid_Z = value;
            SetDirty("Wwpuserextendedid_Z");
         }

      }

      public void gxTv_SdtWWP_Notification_Wwpuserextendedid_Z_SetNull( )
      {
         gxTv_SdtWWP_Notification_Wwpuserextendedid_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_Notification_Wwpuserextendedid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPUserExtendedFullName_Z" )]
      [  XmlElement( ElementName = "WWPUserExtendedFullName_Z"   )]
      public string gxTpr_Wwpuserextendedfullname_Z
      {
         get {
            return gxTv_SdtWWP_Notification_Wwpuserextendedfullname_Z ;
         }

         set {
            gxTv_SdtWWP_Notification_Wwpuserextendedfullname_Z = value;
            SetDirty("Wwpuserextendedfullname_Z");
         }

      }

      public void gxTv_SdtWWP_Notification_Wwpuserextendedfullname_Z_SetNull( )
      {
         gxTv_SdtWWP_Notification_Wwpuserextendedfullname_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_Notification_Wwpuserextendedfullname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationId_N" )]
      [  XmlElement( ElementName = "WWPNotificationId_N"   )]
      public short gxTpr_Wwpnotificationid_N
      {
         get {
            return gxTv_SdtWWP_Notification_Wwpnotificationid_N ;
         }

         set {
            gxTv_SdtWWP_Notification_Wwpnotificationid_N = value;
            SetDirty("Wwpnotificationid_N");
         }

      }

      public void gxTv_SdtWWP_Notification_Wwpnotificationid_N_SetNull( )
      {
         gxTv_SdtWWP_Notification_Wwpnotificationid_N = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_Notification_Wwpnotificationid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPUserExtendedId_N" )]
      [  XmlElement( ElementName = "WWPUserExtendedId_N"   )]
      public short gxTpr_Wwpuserextendedid_N
      {
         get {
            return gxTv_SdtWWP_Notification_Wwpuserextendedid_N ;
         }

         set {
            gxTv_SdtWWP_Notification_Wwpuserextendedid_N = value;
            SetDirty("Wwpuserextendedid_N");
         }

      }

      public void gxTv_SdtWWP_Notification_Wwpuserextendedid_N_SetNull( )
      {
         gxTv_SdtWWP_Notification_Wwpuserextendedid_N = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_Notification_Wwpuserextendedid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationMetadata_N" )]
      [  XmlElement( ElementName = "WWPNotificationMetadata_N"   )]
      public short gxTpr_Wwpnotificationmetadata_N
      {
         get {
            return gxTv_SdtWWP_Notification_Wwpnotificationmetadata_N ;
         }

         set {
            gxTv_SdtWWP_Notification_Wwpnotificationmetadata_N = value;
            SetDirty("Wwpnotificationmetadata_N");
         }

      }

      public void gxTv_SdtWWP_Notification_Wwpnotificationmetadata_N_SetNull( )
      {
         gxTv_SdtWWP_Notification_Wwpnotificationmetadata_N = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_Notification_Wwpnotificationmetadata_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtWWP_Notification_Wwpnotificationdefinitionname = "";
         gxTv_SdtWWP_Notification_Wwpnotificationcreated = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_Notification_Wwpnotificationicon = "";
         gxTv_SdtWWP_Notification_Wwpnotificationtitle = "";
         gxTv_SdtWWP_Notification_Wwpnotificationshortdescription = "";
         gxTv_SdtWWP_Notification_Wwpnotificationlink = "";
         gxTv_SdtWWP_Notification_Wwpuserextendedid = "";
         gxTv_SdtWWP_Notification_Wwpuserextendedfullname = "";
         gxTv_SdtWWP_Notification_Wwpnotificationmetadata = "";
         gxTv_SdtWWP_Notification_Mode = "";
         gxTv_SdtWWP_Notification_Wwpnotificationdefinitionname_Z = "";
         gxTv_SdtWWP_Notification_Wwpnotificationcreated_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_Notification_Wwpnotificationicon_Z = "";
         gxTv_SdtWWP_Notification_Wwpnotificationtitle_Z = "";
         gxTv_SdtWWP_Notification_Wwpnotificationshortdescription_Z = "";
         gxTv_SdtWWP_Notification_Wwpnotificationlink_Z = "";
         gxTv_SdtWWP_Notification_Wwpuserextendedid_Z = "";
         gxTv_SdtWWP_Notification_Wwpuserextendedfullname_Z = "";
         datetimemil_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "wwpbaseobjects.notifications.common.wwp_notification", "GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notification_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      private short gxTv_SdtWWP_Notification_Initialized ;
      private short gxTv_SdtWWP_Notification_Wwpnotificationid_N ;
      private short gxTv_SdtWWP_Notification_Wwpuserextendedid_N ;
      private short gxTv_SdtWWP_Notification_Wwpnotificationmetadata_N ;
      private long gxTv_SdtWWP_Notification_Wwpnotificationid ;
      private long gxTv_SdtWWP_Notification_Wwpnotificationdefinitionid ;
      private long gxTv_SdtWWP_Notification_Wwpnotificationid_Z ;
      private long gxTv_SdtWWP_Notification_Wwpnotificationdefinitionid_Z ;
      private string gxTv_SdtWWP_Notification_Wwpuserextendedid ;
      private string gxTv_SdtWWP_Notification_Mode ;
      private string gxTv_SdtWWP_Notification_Wwpuserextendedid_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtWWP_Notification_Wwpnotificationcreated ;
      private DateTime gxTv_SdtWWP_Notification_Wwpnotificationcreated_Z ;
      private DateTime datetimemil_STZ ;
      private bool gxTv_SdtWWP_Notification_Wwpnotificationisread ;
      private bool gxTv_SdtWWP_Notification_Wwpnotificationisread_Z ;
      private string gxTv_SdtWWP_Notification_Wwpnotificationmetadata ;
      private string gxTv_SdtWWP_Notification_Wwpnotificationdefinitionname ;
      private string gxTv_SdtWWP_Notification_Wwpnotificationicon ;
      private string gxTv_SdtWWP_Notification_Wwpnotificationtitle ;
      private string gxTv_SdtWWP_Notification_Wwpnotificationshortdescription ;
      private string gxTv_SdtWWP_Notification_Wwpnotificationlink ;
      private string gxTv_SdtWWP_Notification_Wwpuserextendedfullname ;
      private string gxTv_SdtWWP_Notification_Wwpnotificationdefinitionname_Z ;
      private string gxTv_SdtWWP_Notification_Wwpnotificationicon_Z ;
      private string gxTv_SdtWWP_Notification_Wwpnotificationtitle_Z ;
      private string gxTv_SdtWWP_Notification_Wwpnotificationshortdescription_Z ;
      private string gxTv_SdtWWP_Notification_Wwpnotificationlink_Z ;
      private string gxTv_SdtWWP_Notification_Wwpuserextendedfullname_Z ;
   }

   [DataContract(Name = @"WWPBaseObjects\Notifications\Common\WWP_Notification", Namespace = "RastreamentoTCC")]
   public class SdtWWP_Notification_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWWP_Notification_RESTInterface( ) : base()
      {
      }

      public SdtWWP_Notification_RESTInterface( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WWPNotificationId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Wwpnotificationid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Wwpnotificationid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Wwpnotificationid = (long)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "WWPNotificationDefinitionId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Wwpnotificationdefinitionid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Wwpnotificationdefinitionid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Wwpnotificationdefinitionid = (long)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "WWPNotificationDefinitionName" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Wwpnotificationdefinitionname
      {
         get {
            return sdt.gxTpr_Wwpnotificationdefinitionname ;
         }

         set {
            sdt.gxTpr_Wwpnotificationdefinitionname = value;
         }

      }

      [DataMember( Name = "WWPNotificationCreated" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Wwpnotificationcreated
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Wwpnotificationcreated) ;
         }

         set {
            sdt.gxTpr_Wwpnotificationcreated = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "WWPNotificationIcon" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Wwpnotificationicon
      {
         get {
            return sdt.gxTpr_Wwpnotificationicon ;
         }

         set {
            sdt.gxTpr_Wwpnotificationicon = value;
         }

      }

      [DataMember( Name = "WWPNotificationTitle" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Wwpnotificationtitle
      {
         get {
            return sdt.gxTpr_Wwpnotificationtitle ;
         }

         set {
            sdt.gxTpr_Wwpnotificationtitle = value;
         }

      }

      [DataMember( Name = "WWPNotificationShortDescription" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Wwpnotificationshortdescription
      {
         get {
            return sdt.gxTpr_Wwpnotificationshortdescription ;
         }

         set {
            sdt.gxTpr_Wwpnotificationshortdescription = value;
         }

      }

      [DataMember( Name = "WWPNotificationLink" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Wwpnotificationlink
      {
         get {
            return sdt.gxTpr_Wwpnotificationlink ;
         }

         set {
            sdt.gxTpr_Wwpnotificationlink = value;
         }

      }

      [DataMember( Name = "WWPNotificationIsRead" , Order = 8 )]
      [GxSeudo()]
      public bool gxTpr_Wwpnotificationisread
      {
         get {
            return sdt.gxTpr_Wwpnotificationisread ;
         }

         set {
            sdt.gxTpr_Wwpnotificationisread = value;
         }

      }

      [DataMember( Name = "WWPUserExtendedId" , Order = 9 )]
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

      [DataMember( Name = "WWPUserExtendedFullName" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Wwpuserextendedfullname
      {
         get {
            return sdt.gxTpr_Wwpuserextendedfullname ;
         }

         set {
            sdt.gxTpr_Wwpuserextendedfullname = value;
         }

      }

      [DataMember( Name = "WWPNotificationMetadata" , Order = 11 )]
      public string gxTpr_Wwpnotificationmetadata
      {
         get {
            return sdt.gxTpr_Wwpnotificationmetadata ;
         }

         set {
            sdt.gxTpr_Wwpnotificationmetadata = value;
         }

      }

      public GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 12 )]
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

   [DataContract(Name = @"WWPBaseObjects\Notifications\Common\WWP_Notification", Namespace = "RastreamentoTCC")]
   public class SdtWWP_Notification_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWWP_Notification_RESTLInterface( ) : base()
      {
      }

      public SdtWWP_Notification_RESTLInterface( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WWPNotificationCreated" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Wwpnotificationcreated
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Wwpnotificationcreated) ;
         }

         set {
            sdt.gxTpr_Wwpnotificationcreated = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification() ;
         }
      }

   }

}
