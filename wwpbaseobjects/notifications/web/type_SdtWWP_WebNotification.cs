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
   [XmlRoot(ElementName = "WWP_WebNotification" )]
   [XmlType(TypeName =  "WWP_WebNotification" , Namespace = "RastreamentoTCC" )]
   [Serializable]
   public class SdtWWP_WebNotification : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWWP_WebNotification( )
      {
      }

      public SdtWWP_WebNotification( IGxContext context )
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

      public void Load( long AV17WWPWebNotificationId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(long)AV17WWPWebNotificationId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"WWPWebNotificationId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification");
         metadata.Set("BT", "WWP_WebNotification");
         metadata.Set("PK", "[ \"WWPWebNotificationId\" ]");
         metadata.Set("PKAssigned", "[ \"WWPWebNotificationId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"WWPNotificationId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Wwpwebnotificationid_Z");
         state.Add("gxTpr_Wwpwebnotificationtitle_Z");
         state.Add("gxTpr_Wwpnotificationid_Z");
         state.Add("gxTpr_Wwpnotificationcreated_Z_Nullable");
         state.Add("gxTpr_Wwpnotificationdefinitionname_Z");
         state.Add("gxTpr_Wwpwebnotificationtext_Z");
         state.Add("gxTpr_Wwpwebnotificationicon_Z");
         state.Add("gxTpr_Wwpwebnotificationstatus_Z");
         state.Add("gxTpr_Wwpwebnotificationcreated_Z_Nullable");
         state.Add("gxTpr_Wwpwebnotificationscheduled_Z_Nullable");
         state.Add("gxTpr_Wwpwebnotificationprocessed_Z_Nullable");
         state.Add("gxTpr_Wwpwebnotificationread_Z_Nullable");
         state.Add("gxTpr_Wwpwebnotificationreceived_Z");
         state.Add("gxTpr_Wwpnotificationid_N");
         state.Add("gxTpr_Wwpnotificationmetadata_N");
         state.Add("gxTpr_Wwpwebnotificationread_N");
         state.Add("gxTpr_Wwpwebnotificationdetail_N");
         state.Add("gxTpr_Wwpwebnotificationreceived_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification sdt;
         sdt = (GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification)(source);
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationid = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationid ;
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationtitle = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationtitle ;
         gxTv_SdtWWP_WebNotification_Wwpnotificationid = sdt.gxTv_SdtWWP_WebNotification_Wwpnotificationid ;
         gxTv_SdtWWP_WebNotification_Wwpnotificationcreated = sdt.gxTv_SdtWWP_WebNotification_Wwpnotificationcreated ;
         gxTv_SdtWWP_WebNotification_Wwpnotificationmetadata = sdt.gxTv_SdtWWP_WebNotification_Wwpnotificationmetadata ;
         gxTv_SdtWWP_WebNotification_Wwpnotificationdefinitionname = sdt.gxTv_SdtWWP_WebNotification_Wwpnotificationdefinitionname ;
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationtext = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationtext ;
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationicon = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationicon ;
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationclientid = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationclientid ;
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationstatus = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationstatus ;
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationcreated = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationcreated ;
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationscheduled = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationscheduled ;
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationprocessed = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationprocessed ;
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationread = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationread ;
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationdetail = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationdetail ;
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived ;
         gxTv_SdtWWP_WebNotification_Mode = sdt.gxTv_SdtWWP_WebNotification_Mode ;
         gxTv_SdtWWP_WebNotification_Initialized = sdt.gxTv_SdtWWP_WebNotification_Initialized ;
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationid_Z = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationid_Z ;
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationtitle_Z = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationtitle_Z ;
         gxTv_SdtWWP_WebNotification_Wwpnotificationid_Z = sdt.gxTv_SdtWWP_WebNotification_Wwpnotificationid_Z ;
         gxTv_SdtWWP_WebNotification_Wwpnotificationcreated_Z = sdt.gxTv_SdtWWP_WebNotification_Wwpnotificationcreated_Z ;
         gxTv_SdtWWP_WebNotification_Wwpnotificationdefinitionname_Z = sdt.gxTv_SdtWWP_WebNotification_Wwpnotificationdefinitionname_Z ;
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationtext_Z = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationtext_Z ;
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationicon_Z = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationicon_Z ;
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationstatus_Z = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationstatus_Z ;
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationcreated_Z = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationcreated_Z ;
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationscheduled_Z = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationscheduled_Z ;
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationprocessed_Z = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationprocessed_Z ;
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationread_Z = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationread_Z ;
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived_Z = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived_Z ;
         gxTv_SdtWWP_WebNotification_Wwpnotificationid_N = sdt.gxTv_SdtWWP_WebNotification_Wwpnotificationid_N ;
         gxTv_SdtWWP_WebNotification_Wwpnotificationmetadata_N = sdt.gxTv_SdtWWP_WebNotification_Wwpnotificationmetadata_N ;
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationread_N = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationread_N ;
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationdetail_N = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationdetail_N ;
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived_N = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived_N ;
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
         AddObjectProperty("WWPWebNotificationId", gxTv_SdtWWP_WebNotification_Wwpwebnotificationid, false, includeNonInitialized);
         AddObjectProperty("WWPWebNotificationTitle", gxTv_SdtWWP_WebNotification_Wwpwebnotificationtitle, false, includeNonInitialized);
         AddObjectProperty("WWPNotificationId", gxTv_SdtWWP_WebNotification_Wwpnotificationid, false, includeNonInitialized);
         AddObjectProperty("WWPNotificationId_N", gxTv_SdtWWP_WebNotification_Wwpnotificationid_N, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtWWP_WebNotification_Wwpnotificationcreated;
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
         AddObjectProperty("WWPNotificationMetadata", gxTv_SdtWWP_WebNotification_Wwpnotificationmetadata, false, includeNonInitialized);
         AddObjectProperty("WWPNotificationMetadata_N", gxTv_SdtWWP_WebNotification_Wwpnotificationmetadata_N, false, includeNonInitialized);
         AddObjectProperty("WWPNotificationDefinitionName", gxTv_SdtWWP_WebNotification_Wwpnotificationdefinitionname, false, includeNonInitialized);
         AddObjectProperty("WWPWebNotificationText", gxTv_SdtWWP_WebNotification_Wwpwebnotificationtext, false, includeNonInitialized);
         AddObjectProperty("WWPWebNotificationIcon", gxTv_SdtWWP_WebNotification_Wwpwebnotificationicon, false, includeNonInitialized);
         AddObjectProperty("WWPWebNotificationClientId", gxTv_SdtWWP_WebNotification_Wwpwebnotificationclientid, false, includeNonInitialized);
         AddObjectProperty("WWPWebNotificationStatus", gxTv_SdtWWP_WebNotification_Wwpwebnotificationstatus, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtWWP_WebNotification_Wwpwebnotificationcreated;
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
         AddObjectProperty("WWPWebNotificationCreated", sDateCnv, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtWWP_WebNotification_Wwpwebnotificationscheduled;
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
         AddObjectProperty("WWPWebNotificationScheduled", sDateCnv, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtWWP_WebNotification_Wwpwebnotificationprocessed;
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
         AddObjectProperty("WWPWebNotificationProcessed", sDateCnv, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtWWP_WebNotification_Wwpwebnotificationread;
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
         AddObjectProperty("WWPWebNotificationRead", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("WWPWebNotificationRead_N", gxTv_SdtWWP_WebNotification_Wwpwebnotificationread_N, false, includeNonInitialized);
         AddObjectProperty("WWPWebNotificationDetail", gxTv_SdtWWP_WebNotification_Wwpwebnotificationdetail, false, includeNonInitialized);
         AddObjectProperty("WWPWebNotificationDetail_N", gxTv_SdtWWP_WebNotification_Wwpwebnotificationdetail_N, false, includeNonInitialized);
         AddObjectProperty("WWPWebNotificationReceived", gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived, false, includeNonInitialized);
         AddObjectProperty("WWPWebNotificationReceived_N", gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtWWP_WebNotification_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtWWP_WebNotification_Initialized, false, includeNonInitialized);
            AddObjectProperty("WWPWebNotificationId_Z", gxTv_SdtWWP_WebNotification_Wwpwebnotificationid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPWebNotificationTitle_Z", gxTv_SdtWWP_WebNotification_Wwpwebnotificationtitle_Z, false, includeNonInitialized);
            AddObjectProperty("WWPNotificationId_Z", gxTv_SdtWWP_WebNotification_Wwpnotificationid_Z, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtWWP_WebNotification_Wwpnotificationcreated_Z;
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
            AddObjectProperty("WWPNotificationDefinitionName_Z", gxTv_SdtWWP_WebNotification_Wwpnotificationdefinitionname_Z, false, includeNonInitialized);
            AddObjectProperty("WWPWebNotificationText_Z", gxTv_SdtWWP_WebNotification_Wwpwebnotificationtext_Z, false, includeNonInitialized);
            AddObjectProperty("WWPWebNotificationIcon_Z", gxTv_SdtWWP_WebNotification_Wwpwebnotificationicon_Z, false, includeNonInitialized);
            AddObjectProperty("WWPWebNotificationStatus_Z", gxTv_SdtWWP_WebNotification_Wwpwebnotificationstatus_Z, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtWWP_WebNotification_Wwpwebnotificationcreated_Z;
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
            AddObjectProperty("WWPWebNotificationCreated_Z", sDateCnv, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtWWP_WebNotification_Wwpwebnotificationscheduled_Z;
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
            AddObjectProperty("WWPWebNotificationScheduled_Z", sDateCnv, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtWWP_WebNotification_Wwpwebnotificationprocessed_Z;
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
            AddObjectProperty("WWPWebNotificationProcessed_Z", sDateCnv, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtWWP_WebNotification_Wwpwebnotificationread_Z;
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
            AddObjectProperty("WWPWebNotificationRead_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("WWPWebNotificationReceived_Z", gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived_Z, false, includeNonInitialized);
            AddObjectProperty("WWPNotificationId_N", gxTv_SdtWWP_WebNotification_Wwpnotificationid_N, false, includeNonInitialized);
            AddObjectProperty("WWPNotificationMetadata_N", gxTv_SdtWWP_WebNotification_Wwpnotificationmetadata_N, false, includeNonInitialized);
            AddObjectProperty("WWPWebNotificationRead_N", gxTv_SdtWWP_WebNotification_Wwpwebnotificationread_N, false, includeNonInitialized);
            AddObjectProperty("WWPWebNotificationDetail_N", gxTv_SdtWWP_WebNotification_Wwpwebnotificationdetail_N, false, includeNonInitialized);
            AddObjectProperty("WWPWebNotificationReceived_N", gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification sdt )
      {
         if ( sdt.IsDirty("WWPWebNotificationId") )
         {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationid = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationid ;
         }
         if ( sdt.IsDirty("WWPWebNotificationTitle") )
         {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationtitle = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationtitle ;
         }
         if ( sdt.IsDirty("WWPNotificationId") )
         {
            gxTv_SdtWWP_WebNotification_Wwpnotificationid_N = 0;
            gxTv_SdtWWP_WebNotification_Wwpnotificationid = sdt.gxTv_SdtWWP_WebNotification_Wwpnotificationid ;
         }
         if ( sdt.IsDirty("WWPNotificationCreated") )
         {
            gxTv_SdtWWP_WebNotification_Wwpnotificationcreated = sdt.gxTv_SdtWWP_WebNotification_Wwpnotificationcreated ;
         }
         if ( sdt.IsDirty("WWPNotificationMetadata") )
         {
            gxTv_SdtWWP_WebNotification_Wwpnotificationmetadata_N = 0;
            gxTv_SdtWWP_WebNotification_Wwpnotificationmetadata = sdt.gxTv_SdtWWP_WebNotification_Wwpnotificationmetadata ;
         }
         if ( sdt.IsDirty("WWPNotificationDefinitionName") )
         {
            gxTv_SdtWWP_WebNotification_Wwpnotificationdefinitionname = sdt.gxTv_SdtWWP_WebNotification_Wwpnotificationdefinitionname ;
         }
         if ( sdt.IsDirty("WWPWebNotificationText") )
         {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationtext = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationtext ;
         }
         if ( sdt.IsDirty("WWPWebNotificationIcon") )
         {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationicon = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationicon ;
         }
         if ( sdt.IsDirty("WWPWebNotificationClientId") )
         {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationclientid = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationclientid ;
         }
         if ( sdt.IsDirty("WWPWebNotificationStatus") )
         {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationstatus = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationstatus ;
         }
         if ( sdt.IsDirty("WWPWebNotificationCreated") )
         {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationcreated = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationcreated ;
         }
         if ( sdt.IsDirty("WWPWebNotificationScheduled") )
         {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationscheduled = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationscheduled ;
         }
         if ( sdt.IsDirty("WWPWebNotificationProcessed") )
         {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationprocessed = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationprocessed ;
         }
         if ( sdt.IsDirty("WWPWebNotificationRead") )
         {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationread_N = 0;
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationread = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationread ;
         }
         if ( sdt.IsDirty("WWPWebNotificationDetail") )
         {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationdetail_N = 0;
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationdetail = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationdetail ;
         }
         if ( sdt.IsDirty("WWPWebNotificationReceived") )
         {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived_N = 0;
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived = sdt.gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "WWPWebNotificationId" )]
      [  XmlElement( ElementName = "WWPWebNotificationId"   )]
      public long gxTpr_Wwpwebnotificationid
      {
         get {
            return gxTv_SdtWWP_WebNotification_Wwpwebnotificationid ;
         }

         set {
            if ( gxTv_SdtWWP_WebNotification_Wwpwebnotificationid != value )
            {
               gxTv_SdtWWP_WebNotification_Mode = "INS";
               this.gxTv_SdtWWP_WebNotification_Wwpwebnotificationid_Z_SetNull( );
               this.gxTv_SdtWWP_WebNotification_Wwpwebnotificationtitle_Z_SetNull( );
               this.gxTv_SdtWWP_WebNotification_Wwpnotificationid_Z_SetNull( );
               this.gxTv_SdtWWP_WebNotification_Wwpnotificationcreated_Z_SetNull( );
               this.gxTv_SdtWWP_WebNotification_Wwpnotificationdefinitionname_Z_SetNull( );
               this.gxTv_SdtWWP_WebNotification_Wwpwebnotificationtext_Z_SetNull( );
               this.gxTv_SdtWWP_WebNotification_Wwpwebnotificationicon_Z_SetNull( );
               this.gxTv_SdtWWP_WebNotification_Wwpwebnotificationstatus_Z_SetNull( );
               this.gxTv_SdtWWP_WebNotification_Wwpwebnotificationcreated_Z_SetNull( );
               this.gxTv_SdtWWP_WebNotification_Wwpwebnotificationscheduled_Z_SetNull( );
               this.gxTv_SdtWWP_WebNotification_Wwpwebnotificationprocessed_Z_SetNull( );
               this.gxTv_SdtWWP_WebNotification_Wwpwebnotificationread_Z_SetNull( );
               this.gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived_Z_SetNull( );
            }
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationid = value;
            SetDirty("Wwpwebnotificationid");
         }

      }

      [  SoapElement( ElementName = "WWPWebNotificationTitle" )]
      [  XmlElement( ElementName = "WWPWebNotificationTitle"   )]
      public string gxTpr_Wwpwebnotificationtitle
      {
         get {
            return gxTv_SdtWWP_WebNotification_Wwpwebnotificationtitle ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationtitle = value;
            SetDirty("Wwpwebnotificationtitle");
         }

      }

      [  SoapElement( ElementName = "WWPNotificationId" )]
      [  XmlElement( ElementName = "WWPNotificationId"   )]
      public long gxTpr_Wwpnotificationid
      {
         get {
            return gxTv_SdtWWP_WebNotification_Wwpnotificationid ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Wwpnotificationid_N = 0;
            gxTv_SdtWWP_WebNotification_Wwpnotificationid = value;
            SetDirty("Wwpnotificationid");
         }

      }

      public void gxTv_SdtWWP_WebNotification_Wwpnotificationid_SetNull( )
      {
         gxTv_SdtWWP_WebNotification_Wwpnotificationid_N = 1;
         gxTv_SdtWWP_WebNotification_Wwpnotificationid = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_WebNotification_Wwpnotificationid_IsNull( )
      {
         return (gxTv_SdtWWP_WebNotification_Wwpnotificationid_N==1) ;
      }

      [  SoapElement( ElementName = "WWPNotificationCreated" )]
      [  XmlElement( ElementName = "WWPNotificationCreated"  , IsNullable=true )]
      public string gxTpr_Wwpnotificationcreated_Nullable
      {
         get {
            if ( gxTv_SdtWWP_WebNotification_Wwpnotificationcreated == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_WebNotification_Wwpnotificationcreated, null, true).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_WebNotification_Wwpnotificationcreated = DateTime.MinValue;
            else
               gxTv_SdtWWP_WebNotification_Wwpnotificationcreated = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Wwpnotificationcreated
      {
         get {
            return gxTv_SdtWWP_WebNotification_Wwpnotificationcreated ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Wwpnotificationcreated = value;
            SetDirty("Wwpnotificationcreated");
         }

      }

      [  SoapElement( ElementName = "WWPNotificationMetadata" )]
      [  XmlElement( ElementName = "WWPNotificationMetadata"   )]
      public string gxTpr_Wwpnotificationmetadata
      {
         get {
            return gxTv_SdtWWP_WebNotification_Wwpnotificationmetadata ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Wwpnotificationmetadata_N = 0;
            gxTv_SdtWWP_WebNotification_Wwpnotificationmetadata = value;
            SetDirty("Wwpnotificationmetadata");
         }

      }

      public void gxTv_SdtWWP_WebNotification_Wwpnotificationmetadata_SetNull( )
      {
         gxTv_SdtWWP_WebNotification_Wwpnotificationmetadata_N = 1;
         gxTv_SdtWWP_WebNotification_Wwpnotificationmetadata = "";
         return  ;
      }

      public bool gxTv_SdtWWP_WebNotification_Wwpnotificationmetadata_IsNull( )
      {
         return (gxTv_SdtWWP_WebNotification_Wwpnotificationmetadata_N==1) ;
      }

      [  SoapElement( ElementName = "WWPNotificationDefinitionName" )]
      [  XmlElement( ElementName = "WWPNotificationDefinitionName"   )]
      public string gxTpr_Wwpnotificationdefinitionname
      {
         get {
            return gxTv_SdtWWP_WebNotification_Wwpnotificationdefinitionname ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Wwpnotificationdefinitionname = value;
            SetDirty("Wwpnotificationdefinitionname");
         }

      }

      [  SoapElement( ElementName = "WWPWebNotificationText" )]
      [  XmlElement( ElementName = "WWPWebNotificationText"   )]
      public string gxTpr_Wwpwebnotificationtext
      {
         get {
            return gxTv_SdtWWP_WebNotification_Wwpwebnotificationtext ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationtext = value;
            SetDirty("Wwpwebnotificationtext");
         }

      }

      [  SoapElement( ElementName = "WWPWebNotificationIcon" )]
      [  XmlElement( ElementName = "WWPWebNotificationIcon"   )]
      public string gxTpr_Wwpwebnotificationicon
      {
         get {
            return gxTv_SdtWWP_WebNotification_Wwpwebnotificationicon ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationicon = value;
            SetDirty("Wwpwebnotificationicon");
         }

      }

      [  SoapElement( ElementName = "WWPWebNotificationClientId" )]
      [  XmlElement( ElementName = "WWPWebNotificationClientId"   )]
      public string gxTpr_Wwpwebnotificationclientid
      {
         get {
            return gxTv_SdtWWP_WebNotification_Wwpwebnotificationclientid ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationclientid = value;
            SetDirty("Wwpwebnotificationclientid");
         }

      }

      [  SoapElement( ElementName = "WWPWebNotificationStatus" )]
      [  XmlElement( ElementName = "WWPWebNotificationStatus"   )]
      public short gxTpr_Wwpwebnotificationstatus
      {
         get {
            return gxTv_SdtWWP_WebNotification_Wwpwebnotificationstatus ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationstatus = value;
            SetDirty("Wwpwebnotificationstatus");
         }

      }

      [  SoapElement( ElementName = "WWPWebNotificationCreated" )]
      [  XmlElement( ElementName = "WWPWebNotificationCreated"  , IsNullable=true )]
      public string gxTpr_Wwpwebnotificationcreated_Nullable
      {
         get {
            if ( gxTv_SdtWWP_WebNotification_Wwpwebnotificationcreated == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_WebNotification_Wwpwebnotificationcreated, null, true).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_WebNotification_Wwpwebnotificationcreated = DateTime.MinValue;
            else
               gxTv_SdtWWP_WebNotification_Wwpwebnotificationcreated = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Wwpwebnotificationcreated
      {
         get {
            return gxTv_SdtWWP_WebNotification_Wwpwebnotificationcreated ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationcreated = value;
            SetDirty("Wwpwebnotificationcreated");
         }

      }

      [  SoapElement( ElementName = "WWPWebNotificationScheduled" )]
      [  XmlElement( ElementName = "WWPWebNotificationScheduled"  , IsNullable=true )]
      public string gxTpr_Wwpwebnotificationscheduled_Nullable
      {
         get {
            if ( gxTv_SdtWWP_WebNotification_Wwpwebnotificationscheduled == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_WebNotification_Wwpwebnotificationscheduled, null, true).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_WebNotification_Wwpwebnotificationscheduled = DateTime.MinValue;
            else
               gxTv_SdtWWP_WebNotification_Wwpwebnotificationscheduled = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Wwpwebnotificationscheduled
      {
         get {
            return gxTv_SdtWWP_WebNotification_Wwpwebnotificationscheduled ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationscheduled = value;
            SetDirty("Wwpwebnotificationscheduled");
         }

      }

      [  SoapElement( ElementName = "WWPWebNotificationProcessed" )]
      [  XmlElement( ElementName = "WWPWebNotificationProcessed"  , IsNullable=true )]
      public string gxTpr_Wwpwebnotificationprocessed_Nullable
      {
         get {
            if ( gxTv_SdtWWP_WebNotification_Wwpwebnotificationprocessed == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_WebNotification_Wwpwebnotificationprocessed, null, true).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_WebNotification_Wwpwebnotificationprocessed = DateTime.MinValue;
            else
               gxTv_SdtWWP_WebNotification_Wwpwebnotificationprocessed = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Wwpwebnotificationprocessed
      {
         get {
            return gxTv_SdtWWP_WebNotification_Wwpwebnotificationprocessed ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationprocessed = value;
            SetDirty("Wwpwebnotificationprocessed");
         }

      }

      [  SoapElement( ElementName = "WWPWebNotificationRead" )]
      [  XmlElement( ElementName = "WWPWebNotificationRead"  , IsNullable=true )]
      public string gxTpr_Wwpwebnotificationread_Nullable
      {
         get {
            if ( gxTv_SdtWWP_WebNotification_Wwpwebnotificationread == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_WebNotification_Wwpwebnotificationread, null, true).value ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationread_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_WebNotification_Wwpwebnotificationread = DateTime.MinValue;
            else
               gxTv_SdtWWP_WebNotification_Wwpwebnotificationread = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Wwpwebnotificationread
      {
         get {
            return gxTv_SdtWWP_WebNotification_Wwpwebnotificationread ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationread_N = 0;
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationread = value;
            SetDirty("Wwpwebnotificationread");
         }

      }

      public void gxTv_SdtWWP_WebNotification_Wwpwebnotificationread_SetNull( )
      {
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationread_N = 1;
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationread = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtWWP_WebNotification_Wwpwebnotificationread_IsNull( )
      {
         return (gxTv_SdtWWP_WebNotification_Wwpwebnotificationread_N==1) ;
      }

      [  SoapElement( ElementName = "WWPWebNotificationDetail" )]
      [  XmlElement( ElementName = "WWPWebNotificationDetail"   )]
      public string gxTpr_Wwpwebnotificationdetail
      {
         get {
            return gxTv_SdtWWP_WebNotification_Wwpwebnotificationdetail ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationdetail_N = 0;
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationdetail = value;
            SetDirty("Wwpwebnotificationdetail");
         }

      }

      public void gxTv_SdtWWP_WebNotification_Wwpwebnotificationdetail_SetNull( )
      {
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationdetail_N = 1;
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationdetail = "";
         return  ;
      }

      public bool gxTv_SdtWWP_WebNotification_Wwpwebnotificationdetail_IsNull( )
      {
         return (gxTv_SdtWWP_WebNotification_Wwpwebnotificationdetail_N==1) ;
      }

      [  SoapElement( ElementName = "WWPWebNotificationReceived" )]
      [  XmlElement( ElementName = "WWPWebNotificationReceived"   )]
      public bool gxTpr_Wwpwebnotificationreceived
      {
         get {
            return gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived_N = 0;
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived = value;
            SetDirty("Wwpwebnotificationreceived");
         }

      }

      public void gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived_SetNull( )
      {
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived_N = 1;
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived = false;
         return  ;
      }

      public bool gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived_IsNull( )
      {
         return (gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtWWP_WebNotification_Mode ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtWWP_WebNotification_Mode_SetNull( )
      {
         gxTv_SdtWWP_WebNotification_Mode = "";
         return  ;
      }

      public bool gxTv_SdtWWP_WebNotification_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtWWP_WebNotification_Initialized ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtWWP_WebNotification_Initialized_SetNull( )
      {
         gxTv_SdtWWP_WebNotification_Initialized = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_WebNotification_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPWebNotificationId_Z" )]
      [  XmlElement( ElementName = "WWPWebNotificationId_Z"   )]
      public long gxTpr_Wwpwebnotificationid_Z
      {
         get {
            return gxTv_SdtWWP_WebNotification_Wwpwebnotificationid_Z ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationid_Z = value;
            SetDirty("Wwpwebnotificationid_Z");
         }

      }

      public void gxTv_SdtWWP_WebNotification_Wwpwebnotificationid_Z_SetNull( )
      {
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_WebNotification_Wwpwebnotificationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPWebNotificationTitle_Z" )]
      [  XmlElement( ElementName = "WWPWebNotificationTitle_Z"   )]
      public string gxTpr_Wwpwebnotificationtitle_Z
      {
         get {
            return gxTv_SdtWWP_WebNotification_Wwpwebnotificationtitle_Z ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationtitle_Z = value;
            SetDirty("Wwpwebnotificationtitle_Z");
         }

      }

      public void gxTv_SdtWWP_WebNotification_Wwpwebnotificationtitle_Z_SetNull( )
      {
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationtitle_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_WebNotification_Wwpwebnotificationtitle_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationId_Z" )]
      [  XmlElement( ElementName = "WWPNotificationId_Z"   )]
      public long gxTpr_Wwpnotificationid_Z
      {
         get {
            return gxTv_SdtWWP_WebNotification_Wwpnotificationid_Z ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Wwpnotificationid_Z = value;
            SetDirty("Wwpnotificationid_Z");
         }

      }

      public void gxTv_SdtWWP_WebNotification_Wwpnotificationid_Z_SetNull( )
      {
         gxTv_SdtWWP_WebNotification_Wwpnotificationid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_WebNotification_Wwpnotificationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationCreated_Z" )]
      [  XmlElement( ElementName = "WWPNotificationCreated_Z"  , IsNullable=true )]
      public string gxTpr_Wwpnotificationcreated_Z_Nullable
      {
         get {
            if ( gxTv_SdtWWP_WebNotification_Wwpnotificationcreated_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_WebNotification_Wwpnotificationcreated_Z, null, true).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_WebNotification_Wwpnotificationcreated_Z = DateTime.MinValue;
            else
               gxTv_SdtWWP_WebNotification_Wwpnotificationcreated_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Wwpnotificationcreated_Z
      {
         get {
            return gxTv_SdtWWP_WebNotification_Wwpnotificationcreated_Z ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Wwpnotificationcreated_Z = value;
            SetDirty("Wwpnotificationcreated_Z");
         }

      }

      public void gxTv_SdtWWP_WebNotification_Wwpnotificationcreated_Z_SetNull( )
      {
         gxTv_SdtWWP_WebNotification_Wwpnotificationcreated_Z = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtWWP_WebNotification_Wwpnotificationcreated_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationDefinitionName_Z" )]
      [  XmlElement( ElementName = "WWPNotificationDefinitionName_Z"   )]
      public string gxTpr_Wwpnotificationdefinitionname_Z
      {
         get {
            return gxTv_SdtWWP_WebNotification_Wwpnotificationdefinitionname_Z ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Wwpnotificationdefinitionname_Z = value;
            SetDirty("Wwpnotificationdefinitionname_Z");
         }

      }

      public void gxTv_SdtWWP_WebNotification_Wwpnotificationdefinitionname_Z_SetNull( )
      {
         gxTv_SdtWWP_WebNotification_Wwpnotificationdefinitionname_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_WebNotification_Wwpnotificationdefinitionname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPWebNotificationText_Z" )]
      [  XmlElement( ElementName = "WWPWebNotificationText_Z"   )]
      public string gxTpr_Wwpwebnotificationtext_Z
      {
         get {
            return gxTv_SdtWWP_WebNotification_Wwpwebnotificationtext_Z ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationtext_Z = value;
            SetDirty("Wwpwebnotificationtext_Z");
         }

      }

      public void gxTv_SdtWWP_WebNotification_Wwpwebnotificationtext_Z_SetNull( )
      {
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationtext_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_WebNotification_Wwpwebnotificationtext_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPWebNotificationIcon_Z" )]
      [  XmlElement( ElementName = "WWPWebNotificationIcon_Z"   )]
      public string gxTpr_Wwpwebnotificationicon_Z
      {
         get {
            return gxTv_SdtWWP_WebNotification_Wwpwebnotificationicon_Z ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationicon_Z = value;
            SetDirty("Wwpwebnotificationicon_Z");
         }

      }

      public void gxTv_SdtWWP_WebNotification_Wwpwebnotificationicon_Z_SetNull( )
      {
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationicon_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_WebNotification_Wwpwebnotificationicon_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPWebNotificationStatus_Z" )]
      [  XmlElement( ElementName = "WWPWebNotificationStatus_Z"   )]
      public short gxTpr_Wwpwebnotificationstatus_Z
      {
         get {
            return gxTv_SdtWWP_WebNotification_Wwpwebnotificationstatus_Z ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationstatus_Z = value;
            SetDirty("Wwpwebnotificationstatus_Z");
         }

      }

      public void gxTv_SdtWWP_WebNotification_Wwpwebnotificationstatus_Z_SetNull( )
      {
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationstatus_Z = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_WebNotification_Wwpwebnotificationstatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPWebNotificationCreated_Z" )]
      [  XmlElement( ElementName = "WWPWebNotificationCreated_Z"  , IsNullable=true )]
      public string gxTpr_Wwpwebnotificationcreated_Z_Nullable
      {
         get {
            if ( gxTv_SdtWWP_WebNotification_Wwpwebnotificationcreated_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_WebNotification_Wwpwebnotificationcreated_Z, null, true).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_WebNotification_Wwpwebnotificationcreated_Z = DateTime.MinValue;
            else
               gxTv_SdtWWP_WebNotification_Wwpwebnotificationcreated_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Wwpwebnotificationcreated_Z
      {
         get {
            return gxTv_SdtWWP_WebNotification_Wwpwebnotificationcreated_Z ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationcreated_Z = value;
            SetDirty("Wwpwebnotificationcreated_Z");
         }

      }

      public void gxTv_SdtWWP_WebNotification_Wwpwebnotificationcreated_Z_SetNull( )
      {
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationcreated_Z = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtWWP_WebNotification_Wwpwebnotificationcreated_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPWebNotificationScheduled_Z" )]
      [  XmlElement( ElementName = "WWPWebNotificationScheduled_Z"  , IsNullable=true )]
      public string gxTpr_Wwpwebnotificationscheduled_Z_Nullable
      {
         get {
            if ( gxTv_SdtWWP_WebNotification_Wwpwebnotificationscheduled_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_WebNotification_Wwpwebnotificationscheduled_Z, null, true).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_WebNotification_Wwpwebnotificationscheduled_Z = DateTime.MinValue;
            else
               gxTv_SdtWWP_WebNotification_Wwpwebnotificationscheduled_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Wwpwebnotificationscheduled_Z
      {
         get {
            return gxTv_SdtWWP_WebNotification_Wwpwebnotificationscheduled_Z ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationscheduled_Z = value;
            SetDirty("Wwpwebnotificationscheduled_Z");
         }

      }

      public void gxTv_SdtWWP_WebNotification_Wwpwebnotificationscheduled_Z_SetNull( )
      {
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationscheduled_Z = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtWWP_WebNotification_Wwpwebnotificationscheduled_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPWebNotificationProcessed_Z" )]
      [  XmlElement( ElementName = "WWPWebNotificationProcessed_Z"  , IsNullable=true )]
      public string gxTpr_Wwpwebnotificationprocessed_Z_Nullable
      {
         get {
            if ( gxTv_SdtWWP_WebNotification_Wwpwebnotificationprocessed_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_WebNotification_Wwpwebnotificationprocessed_Z, null, true).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_WebNotification_Wwpwebnotificationprocessed_Z = DateTime.MinValue;
            else
               gxTv_SdtWWP_WebNotification_Wwpwebnotificationprocessed_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Wwpwebnotificationprocessed_Z
      {
         get {
            return gxTv_SdtWWP_WebNotification_Wwpwebnotificationprocessed_Z ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationprocessed_Z = value;
            SetDirty("Wwpwebnotificationprocessed_Z");
         }

      }

      public void gxTv_SdtWWP_WebNotification_Wwpwebnotificationprocessed_Z_SetNull( )
      {
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationprocessed_Z = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtWWP_WebNotification_Wwpwebnotificationprocessed_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPWebNotificationRead_Z" )]
      [  XmlElement( ElementName = "WWPWebNotificationRead_Z"  , IsNullable=true )]
      public string gxTpr_Wwpwebnotificationread_Z_Nullable
      {
         get {
            if ( gxTv_SdtWWP_WebNotification_Wwpwebnotificationread_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_WebNotification_Wwpwebnotificationread_Z, null, true).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_WebNotification_Wwpwebnotificationread_Z = DateTime.MinValue;
            else
               gxTv_SdtWWP_WebNotification_Wwpwebnotificationread_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Wwpwebnotificationread_Z
      {
         get {
            return gxTv_SdtWWP_WebNotification_Wwpwebnotificationread_Z ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationread_Z = value;
            SetDirty("Wwpwebnotificationread_Z");
         }

      }

      public void gxTv_SdtWWP_WebNotification_Wwpwebnotificationread_Z_SetNull( )
      {
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationread_Z = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtWWP_WebNotification_Wwpwebnotificationread_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPWebNotificationReceived_Z" )]
      [  XmlElement( ElementName = "WWPWebNotificationReceived_Z"   )]
      public bool gxTpr_Wwpwebnotificationreceived_Z
      {
         get {
            return gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived_Z ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived_Z = value;
            SetDirty("Wwpwebnotificationreceived_Z");
         }

      }

      public void gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived_Z_SetNull( )
      {
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived_Z = false;
         return  ;
      }

      public bool gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationId_N" )]
      [  XmlElement( ElementName = "WWPNotificationId_N"   )]
      public short gxTpr_Wwpnotificationid_N
      {
         get {
            return gxTv_SdtWWP_WebNotification_Wwpnotificationid_N ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Wwpnotificationid_N = value;
            SetDirty("Wwpnotificationid_N");
         }

      }

      public void gxTv_SdtWWP_WebNotification_Wwpnotificationid_N_SetNull( )
      {
         gxTv_SdtWWP_WebNotification_Wwpnotificationid_N = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_WebNotification_Wwpnotificationid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationMetadata_N" )]
      [  XmlElement( ElementName = "WWPNotificationMetadata_N"   )]
      public short gxTpr_Wwpnotificationmetadata_N
      {
         get {
            return gxTv_SdtWWP_WebNotification_Wwpnotificationmetadata_N ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Wwpnotificationmetadata_N = value;
            SetDirty("Wwpnotificationmetadata_N");
         }

      }

      public void gxTv_SdtWWP_WebNotification_Wwpnotificationmetadata_N_SetNull( )
      {
         gxTv_SdtWWP_WebNotification_Wwpnotificationmetadata_N = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_WebNotification_Wwpnotificationmetadata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPWebNotificationRead_N" )]
      [  XmlElement( ElementName = "WWPWebNotificationRead_N"   )]
      public short gxTpr_Wwpwebnotificationread_N
      {
         get {
            return gxTv_SdtWWP_WebNotification_Wwpwebnotificationread_N ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationread_N = value;
            SetDirty("Wwpwebnotificationread_N");
         }

      }

      public void gxTv_SdtWWP_WebNotification_Wwpwebnotificationread_N_SetNull( )
      {
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationread_N = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_WebNotification_Wwpwebnotificationread_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPWebNotificationDetail_N" )]
      [  XmlElement( ElementName = "WWPWebNotificationDetail_N"   )]
      public short gxTpr_Wwpwebnotificationdetail_N
      {
         get {
            return gxTv_SdtWWP_WebNotification_Wwpwebnotificationdetail_N ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationdetail_N = value;
            SetDirty("Wwpwebnotificationdetail_N");
         }

      }

      public void gxTv_SdtWWP_WebNotification_Wwpwebnotificationdetail_N_SetNull( )
      {
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationdetail_N = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_WebNotification_Wwpwebnotificationdetail_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPWebNotificationReceived_N" )]
      [  XmlElement( ElementName = "WWPWebNotificationReceived_N"   )]
      public short gxTpr_Wwpwebnotificationreceived_N
      {
         get {
            return gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived_N ;
         }

         set {
            gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived_N = value;
            SetDirty("Wwpwebnotificationreceived_N");
         }

      }

      public void gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived_N_SetNull( )
      {
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived_N = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationtitle = "";
         gxTv_SdtWWP_WebNotification_Wwpnotificationcreated = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_WebNotification_Wwpnotificationmetadata = "";
         gxTv_SdtWWP_WebNotification_Wwpnotificationdefinitionname = "";
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationtext = "";
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationicon = "";
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationclientid = "";
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationcreated = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationscheduled = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationprocessed = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationread = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationdetail = "";
         gxTv_SdtWWP_WebNotification_Mode = "";
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationtitle_Z = "";
         gxTv_SdtWWP_WebNotification_Wwpnotificationcreated_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_WebNotification_Wwpnotificationdefinitionname_Z = "";
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationtext_Z = "";
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationicon_Z = "";
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationcreated_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationscheduled_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationprocessed_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_WebNotification_Wwpwebnotificationread_Z = (DateTime)(DateTime.MinValue);
         datetimemil_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "wwpbaseobjects.notifications.web.wwp_webnotification", "GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webnotification_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      private short gxTv_SdtWWP_WebNotification_Wwpwebnotificationstatus ;
      private short gxTv_SdtWWP_WebNotification_Initialized ;
      private short gxTv_SdtWWP_WebNotification_Wwpwebnotificationstatus_Z ;
      private short gxTv_SdtWWP_WebNotification_Wwpnotificationid_N ;
      private short gxTv_SdtWWP_WebNotification_Wwpnotificationmetadata_N ;
      private short gxTv_SdtWWP_WebNotification_Wwpwebnotificationread_N ;
      private short gxTv_SdtWWP_WebNotification_Wwpwebnotificationdetail_N ;
      private short gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived_N ;
      private long gxTv_SdtWWP_WebNotification_Wwpwebnotificationid ;
      private long gxTv_SdtWWP_WebNotification_Wwpnotificationid ;
      private long gxTv_SdtWWP_WebNotification_Wwpwebnotificationid_Z ;
      private long gxTv_SdtWWP_WebNotification_Wwpnotificationid_Z ;
      private string gxTv_SdtWWP_WebNotification_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtWWP_WebNotification_Wwpnotificationcreated ;
      private DateTime gxTv_SdtWWP_WebNotification_Wwpwebnotificationcreated ;
      private DateTime gxTv_SdtWWP_WebNotification_Wwpwebnotificationscheduled ;
      private DateTime gxTv_SdtWWP_WebNotification_Wwpwebnotificationprocessed ;
      private DateTime gxTv_SdtWWP_WebNotification_Wwpwebnotificationread ;
      private DateTime gxTv_SdtWWP_WebNotification_Wwpnotificationcreated_Z ;
      private DateTime gxTv_SdtWWP_WebNotification_Wwpwebnotificationcreated_Z ;
      private DateTime gxTv_SdtWWP_WebNotification_Wwpwebnotificationscheduled_Z ;
      private DateTime gxTv_SdtWWP_WebNotification_Wwpwebnotificationprocessed_Z ;
      private DateTime gxTv_SdtWWP_WebNotification_Wwpwebnotificationread_Z ;
      private DateTime datetimemil_STZ ;
      private bool gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived ;
      private bool gxTv_SdtWWP_WebNotification_Wwpwebnotificationreceived_Z ;
      private string gxTv_SdtWWP_WebNotification_Wwpnotificationmetadata ;
      private string gxTv_SdtWWP_WebNotification_Wwpwebnotificationclientid ;
      private string gxTv_SdtWWP_WebNotification_Wwpwebnotificationdetail ;
      private string gxTv_SdtWWP_WebNotification_Wwpwebnotificationtitle ;
      private string gxTv_SdtWWP_WebNotification_Wwpnotificationdefinitionname ;
      private string gxTv_SdtWWP_WebNotification_Wwpwebnotificationtext ;
      private string gxTv_SdtWWP_WebNotification_Wwpwebnotificationicon ;
      private string gxTv_SdtWWP_WebNotification_Wwpwebnotificationtitle_Z ;
      private string gxTv_SdtWWP_WebNotification_Wwpnotificationdefinitionname_Z ;
      private string gxTv_SdtWWP_WebNotification_Wwpwebnotificationtext_Z ;
      private string gxTv_SdtWWP_WebNotification_Wwpwebnotificationicon_Z ;
   }

   [DataContract(Name = @"WWPBaseObjects\Notifications\Web\WWP_WebNotification", Namespace = "RastreamentoTCC")]
   public class SdtWWP_WebNotification_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWWP_WebNotification_RESTInterface( ) : base()
      {
      }

      public SdtWWP_WebNotification_RESTInterface( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WWPWebNotificationId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Wwpwebnotificationid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Wwpwebnotificationid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Wwpwebnotificationid = (long)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "WWPWebNotificationTitle" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Wwpwebnotificationtitle
      {
         get {
            return sdt.gxTpr_Wwpwebnotificationtitle ;
         }

         set {
            sdt.gxTpr_Wwpwebnotificationtitle = value;
         }

      }

      [DataMember( Name = "WWPNotificationId" , Order = 2 )]
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

      [DataMember( Name = "WWPNotificationMetadata" , Order = 4 )]
      public string gxTpr_Wwpnotificationmetadata
      {
         get {
            return sdt.gxTpr_Wwpnotificationmetadata ;
         }

         set {
            sdt.gxTpr_Wwpnotificationmetadata = value;
         }

      }

      [DataMember( Name = "WWPNotificationDefinitionName" , Order = 5 )]
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

      [DataMember( Name = "WWPWebNotificationText" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Wwpwebnotificationtext
      {
         get {
            return sdt.gxTpr_Wwpwebnotificationtext ;
         }

         set {
            sdt.gxTpr_Wwpwebnotificationtext = value;
         }

      }

      [DataMember( Name = "WWPWebNotificationIcon" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Wwpwebnotificationicon
      {
         get {
            return sdt.gxTpr_Wwpwebnotificationicon ;
         }

         set {
            sdt.gxTpr_Wwpwebnotificationicon = value;
         }

      }

      [DataMember( Name = "WWPWebNotificationClientId" , Order = 8 )]
      public string gxTpr_Wwpwebnotificationclientid
      {
         get {
            return sdt.gxTpr_Wwpwebnotificationclientid ;
         }

         set {
            sdt.gxTpr_Wwpwebnotificationclientid = value;
         }

      }

      [DataMember( Name = "WWPWebNotificationStatus" , Order = 9 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Wwpwebnotificationstatus
      {
         get {
            return sdt.gxTpr_Wwpwebnotificationstatus ;
         }

         set {
            sdt.gxTpr_Wwpwebnotificationstatus = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPWebNotificationCreated" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Wwpwebnotificationcreated
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Wwpwebnotificationcreated) ;
         }

         set {
            sdt.gxTpr_Wwpwebnotificationcreated = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "WWPWebNotificationScheduled" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Wwpwebnotificationscheduled
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Wwpwebnotificationscheduled) ;
         }

         set {
            sdt.gxTpr_Wwpwebnotificationscheduled = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "WWPWebNotificationProcessed" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Wwpwebnotificationprocessed
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Wwpwebnotificationprocessed) ;
         }

         set {
            sdt.gxTpr_Wwpwebnotificationprocessed = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "WWPWebNotificationRead" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Wwpwebnotificationread
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Wwpwebnotificationread) ;
         }

         set {
            sdt.gxTpr_Wwpwebnotificationread = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "WWPWebNotificationDetail" , Order = 14 )]
      public string gxTpr_Wwpwebnotificationdetail
      {
         get {
            return sdt.gxTpr_Wwpwebnotificationdetail ;
         }

         set {
            sdt.gxTpr_Wwpwebnotificationdetail = value;
         }

      }

      [DataMember( Name = "WWPWebNotificationReceived" , Order = 15 )]
      [GxSeudo()]
      public bool gxTpr_Wwpwebnotificationreceived
      {
         get {
            return sdt.gxTpr_Wwpwebnotificationreceived ;
         }

         set {
            sdt.gxTpr_Wwpwebnotificationreceived = value;
         }

      }

      public GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 16 )]
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

   [DataContract(Name = @"WWPBaseObjects\Notifications\Web\WWP_WebNotification", Namespace = "RastreamentoTCC")]
   public class SdtWWP_WebNotification_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWWP_WebNotification_RESTLInterface( ) : base()
      {
      }

      public SdtWWP_WebNotification_RESTLInterface( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WWPWebNotificationTitle" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Wwpwebnotificationtitle
      {
         get {
            return sdt.gxTpr_Wwpwebnotificationtitle ;
         }

         set {
            sdt.gxTpr_Wwpwebnotificationtitle = value;
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

      public GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification() ;
         }
      }

   }

}
