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
namespace GeneXus.Programs.wwpbaseobjects.sms {
   [XmlSerializerFormat]
   [XmlRoot(ElementName = "WWP_SMS" )]
   [XmlType(TypeName =  "WWP_SMS" , Namespace = "RastreamentoTCC" )]
   [Serializable]
   public class SdtWWP_SMS : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWWP_SMS( )
      {
      }

      public SdtWWP_SMS( IGxContext context )
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

      public void Load( long AV15WWPSMSId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(long)AV15WWPSMSId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"WWPSMSId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "WWPBaseObjects\\SMS\\WWP_SMS");
         metadata.Set("BT", "WWP_SMS");
         metadata.Set("PK", "[ \"WWPSMSId\" ]");
         metadata.Set("PKAssigned", "[ \"WWPSMSId\" ]");
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
         state.Add("gxTpr_Wwpsmsid_Z");
         state.Add("gxTpr_Wwpsmsstatus_Z");
         state.Add("gxTpr_Wwpsmscreated_Z_Nullable");
         state.Add("gxTpr_Wwpsmsscheduled_Z_Nullable");
         state.Add("gxTpr_Wwpsmsprocessed_Z_Nullable");
         state.Add("gxTpr_Wwpnotificationid_Z");
         state.Add("gxTpr_Wwpnotificationcreated_Z_Nullable");
         state.Add("gxTpr_Wwpsmsprocessed_N");
         state.Add("gxTpr_Wwpsmsdetail_N");
         state.Add("gxTpr_Wwpnotificationid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS sdt;
         sdt = (GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS)(source);
         gxTv_SdtWWP_SMS_Wwpsmsid = sdt.gxTv_SdtWWP_SMS_Wwpsmsid ;
         gxTv_SdtWWP_SMS_Wwpsmsmessage = sdt.gxTv_SdtWWP_SMS_Wwpsmsmessage ;
         gxTv_SdtWWP_SMS_Wwpsmssendernumber = sdt.gxTv_SdtWWP_SMS_Wwpsmssendernumber ;
         gxTv_SdtWWP_SMS_Wwpsmsrecipientnumbers = sdt.gxTv_SdtWWP_SMS_Wwpsmsrecipientnumbers ;
         gxTv_SdtWWP_SMS_Wwpsmsstatus = sdt.gxTv_SdtWWP_SMS_Wwpsmsstatus ;
         gxTv_SdtWWP_SMS_Wwpsmscreated = sdt.gxTv_SdtWWP_SMS_Wwpsmscreated ;
         gxTv_SdtWWP_SMS_Wwpsmsscheduled = sdt.gxTv_SdtWWP_SMS_Wwpsmsscheduled ;
         gxTv_SdtWWP_SMS_Wwpsmsprocessed = sdt.gxTv_SdtWWP_SMS_Wwpsmsprocessed ;
         gxTv_SdtWWP_SMS_Wwpsmsdetail = sdt.gxTv_SdtWWP_SMS_Wwpsmsdetail ;
         gxTv_SdtWWP_SMS_Wwpnotificationid = sdt.gxTv_SdtWWP_SMS_Wwpnotificationid ;
         gxTv_SdtWWP_SMS_Wwpnotificationcreated = sdt.gxTv_SdtWWP_SMS_Wwpnotificationcreated ;
         gxTv_SdtWWP_SMS_Mode = sdt.gxTv_SdtWWP_SMS_Mode ;
         gxTv_SdtWWP_SMS_Initialized = sdt.gxTv_SdtWWP_SMS_Initialized ;
         gxTv_SdtWWP_SMS_Wwpsmsid_Z = sdt.gxTv_SdtWWP_SMS_Wwpsmsid_Z ;
         gxTv_SdtWWP_SMS_Wwpsmsstatus_Z = sdt.gxTv_SdtWWP_SMS_Wwpsmsstatus_Z ;
         gxTv_SdtWWP_SMS_Wwpsmscreated_Z = sdt.gxTv_SdtWWP_SMS_Wwpsmscreated_Z ;
         gxTv_SdtWWP_SMS_Wwpsmsscheduled_Z = sdt.gxTv_SdtWWP_SMS_Wwpsmsscheduled_Z ;
         gxTv_SdtWWP_SMS_Wwpsmsprocessed_Z = sdt.gxTv_SdtWWP_SMS_Wwpsmsprocessed_Z ;
         gxTv_SdtWWP_SMS_Wwpnotificationid_Z = sdt.gxTv_SdtWWP_SMS_Wwpnotificationid_Z ;
         gxTv_SdtWWP_SMS_Wwpnotificationcreated_Z = sdt.gxTv_SdtWWP_SMS_Wwpnotificationcreated_Z ;
         gxTv_SdtWWP_SMS_Wwpsmsprocessed_N = sdt.gxTv_SdtWWP_SMS_Wwpsmsprocessed_N ;
         gxTv_SdtWWP_SMS_Wwpsmsdetail_N = sdt.gxTv_SdtWWP_SMS_Wwpsmsdetail_N ;
         gxTv_SdtWWP_SMS_Wwpnotificationid_N = sdt.gxTv_SdtWWP_SMS_Wwpnotificationid_N ;
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
         AddObjectProperty("WWPSMSId", gxTv_SdtWWP_SMS_Wwpsmsid, false, includeNonInitialized);
         AddObjectProperty("WWPSMSMessage", gxTv_SdtWWP_SMS_Wwpsmsmessage, false, includeNonInitialized);
         AddObjectProperty("WWPSMSSenderNumber", gxTv_SdtWWP_SMS_Wwpsmssendernumber, false, includeNonInitialized);
         AddObjectProperty("WWPSMSRecipientNumbers", gxTv_SdtWWP_SMS_Wwpsmsrecipientnumbers, false, includeNonInitialized);
         AddObjectProperty("WWPSMSStatus", gxTv_SdtWWP_SMS_Wwpsmsstatus, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtWWP_SMS_Wwpsmscreated;
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
         AddObjectProperty("WWPSMSCreated", sDateCnv, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtWWP_SMS_Wwpsmsscheduled;
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
         AddObjectProperty("WWPSMSScheduled", sDateCnv, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtWWP_SMS_Wwpsmsprocessed;
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
         AddObjectProperty("WWPSMSProcessed", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("WWPSMSProcessed_N", gxTv_SdtWWP_SMS_Wwpsmsprocessed_N, false, includeNonInitialized);
         AddObjectProperty("WWPSMSDetail", gxTv_SdtWWP_SMS_Wwpsmsdetail, false, includeNonInitialized);
         AddObjectProperty("WWPSMSDetail_N", gxTv_SdtWWP_SMS_Wwpsmsdetail_N, false, includeNonInitialized);
         AddObjectProperty("WWPNotificationId", gxTv_SdtWWP_SMS_Wwpnotificationid, false, includeNonInitialized);
         AddObjectProperty("WWPNotificationId_N", gxTv_SdtWWP_SMS_Wwpnotificationid_N, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtWWP_SMS_Wwpnotificationcreated;
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
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtWWP_SMS_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtWWP_SMS_Initialized, false, includeNonInitialized);
            AddObjectProperty("WWPSMSId_Z", gxTv_SdtWWP_SMS_Wwpsmsid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPSMSStatus_Z", gxTv_SdtWWP_SMS_Wwpsmsstatus_Z, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtWWP_SMS_Wwpsmscreated_Z;
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
            AddObjectProperty("WWPSMSCreated_Z", sDateCnv, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtWWP_SMS_Wwpsmsscheduled_Z;
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
            AddObjectProperty("WWPSMSScheduled_Z", sDateCnv, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtWWP_SMS_Wwpsmsprocessed_Z;
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
            AddObjectProperty("WWPSMSProcessed_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("WWPNotificationId_Z", gxTv_SdtWWP_SMS_Wwpnotificationid_Z, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtWWP_SMS_Wwpnotificationcreated_Z;
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
            AddObjectProperty("WWPSMSProcessed_N", gxTv_SdtWWP_SMS_Wwpsmsprocessed_N, false, includeNonInitialized);
            AddObjectProperty("WWPSMSDetail_N", gxTv_SdtWWP_SMS_Wwpsmsdetail_N, false, includeNonInitialized);
            AddObjectProperty("WWPNotificationId_N", gxTv_SdtWWP_SMS_Wwpnotificationid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS sdt )
      {
         if ( sdt.IsDirty("WWPSMSId") )
         {
            gxTv_SdtWWP_SMS_Wwpsmsid = sdt.gxTv_SdtWWP_SMS_Wwpsmsid ;
         }
         if ( sdt.IsDirty("WWPSMSMessage") )
         {
            gxTv_SdtWWP_SMS_Wwpsmsmessage = sdt.gxTv_SdtWWP_SMS_Wwpsmsmessage ;
         }
         if ( sdt.IsDirty("WWPSMSSenderNumber") )
         {
            gxTv_SdtWWP_SMS_Wwpsmssendernumber = sdt.gxTv_SdtWWP_SMS_Wwpsmssendernumber ;
         }
         if ( sdt.IsDirty("WWPSMSRecipientNumbers") )
         {
            gxTv_SdtWWP_SMS_Wwpsmsrecipientnumbers = sdt.gxTv_SdtWWP_SMS_Wwpsmsrecipientnumbers ;
         }
         if ( sdt.IsDirty("WWPSMSStatus") )
         {
            gxTv_SdtWWP_SMS_Wwpsmsstatus = sdt.gxTv_SdtWWP_SMS_Wwpsmsstatus ;
         }
         if ( sdt.IsDirty("WWPSMSCreated") )
         {
            gxTv_SdtWWP_SMS_Wwpsmscreated = sdt.gxTv_SdtWWP_SMS_Wwpsmscreated ;
         }
         if ( sdt.IsDirty("WWPSMSScheduled") )
         {
            gxTv_SdtWWP_SMS_Wwpsmsscheduled = sdt.gxTv_SdtWWP_SMS_Wwpsmsscheduled ;
         }
         if ( sdt.IsDirty("WWPSMSProcessed") )
         {
            gxTv_SdtWWP_SMS_Wwpsmsprocessed_N = 0;
            gxTv_SdtWWP_SMS_Wwpsmsprocessed = sdt.gxTv_SdtWWP_SMS_Wwpsmsprocessed ;
         }
         if ( sdt.IsDirty("WWPSMSDetail") )
         {
            gxTv_SdtWWP_SMS_Wwpsmsdetail_N = 0;
            gxTv_SdtWWP_SMS_Wwpsmsdetail = sdt.gxTv_SdtWWP_SMS_Wwpsmsdetail ;
         }
         if ( sdt.IsDirty("WWPNotificationId") )
         {
            gxTv_SdtWWP_SMS_Wwpnotificationid_N = 0;
            gxTv_SdtWWP_SMS_Wwpnotificationid = sdt.gxTv_SdtWWP_SMS_Wwpnotificationid ;
         }
         if ( sdt.IsDirty("WWPNotificationCreated") )
         {
            gxTv_SdtWWP_SMS_Wwpnotificationcreated = sdt.gxTv_SdtWWP_SMS_Wwpnotificationcreated ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "WWPSMSId" )]
      [  XmlElement( ElementName = "WWPSMSId"   )]
      public long gxTpr_Wwpsmsid
      {
         get {
            return gxTv_SdtWWP_SMS_Wwpsmsid ;
         }

         set {
            if ( gxTv_SdtWWP_SMS_Wwpsmsid != value )
            {
               gxTv_SdtWWP_SMS_Mode = "INS";
               this.gxTv_SdtWWP_SMS_Wwpsmsid_Z_SetNull( );
               this.gxTv_SdtWWP_SMS_Wwpsmsstatus_Z_SetNull( );
               this.gxTv_SdtWWP_SMS_Wwpsmscreated_Z_SetNull( );
               this.gxTv_SdtWWP_SMS_Wwpsmsscheduled_Z_SetNull( );
               this.gxTv_SdtWWP_SMS_Wwpsmsprocessed_Z_SetNull( );
               this.gxTv_SdtWWP_SMS_Wwpnotificationid_Z_SetNull( );
               this.gxTv_SdtWWP_SMS_Wwpnotificationcreated_Z_SetNull( );
            }
            gxTv_SdtWWP_SMS_Wwpsmsid = value;
            SetDirty("Wwpsmsid");
         }

      }

      [  SoapElement( ElementName = "WWPSMSMessage" )]
      [  XmlElement( ElementName = "WWPSMSMessage"   )]
      public string gxTpr_Wwpsmsmessage
      {
         get {
            return gxTv_SdtWWP_SMS_Wwpsmsmessage ;
         }

         set {
            gxTv_SdtWWP_SMS_Wwpsmsmessage = value;
            SetDirty("Wwpsmsmessage");
         }

      }

      [  SoapElement( ElementName = "WWPSMSSenderNumber" )]
      [  XmlElement( ElementName = "WWPSMSSenderNumber"   )]
      public string gxTpr_Wwpsmssendernumber
      {
         get {
            return gxTv_SdtWWP_SMS_Wwpsmssendernumber ;
         }

         set {
            gxTv_SdtWWP_SMS_Wwpsmssendernumber = value;
            SetDirty("Wwpsmssendernumber");
         }

      }

      [  SoapElement( ElementName = "WWPSMSRecipientNumbers" )]
      [  XmlElement( ElementName = "WWPSMSRecipientNumbers"   )]
      public string gxTpr_Wwpsmsrecipientnumbers
      {
         get {
            return gxTv_SdtWWP_SMS_Wwpsmsrecipientnumbers ;
         }

         set {
            gxTv_SdtWWP_SMS_Wwpsmsrecipientnumbers = value;
            SetDirty("Wwpsmsrecipientnumbers");
         }

      }

      [  SoapElement( ElementName = "WWPSMSStatus" )]
      [  XmlElement( ElementName = "WWPSMSStatus"   )]
      public short gxTpr_Wwpsmsstatus
      {
         get {
            return gxTv_SdtWWP_SMS_Wwpsmsstatus ;
         }

         set {
            gxTv_SdtWWP_SMS_Wwpsmsstatus = value;
            SetDirty("Wwpsmsstatus");
         }

      }

      [  SoapElement( ElementName = "WWPSMSCreated" )]
      [  XmlElement( ElementName = "WWPSMSCreated"  , IsNullable=true )]
      public string gxTpr_Wwpsmscreated_Nullable
      {
         get {
            if ( gxTv_SdtWWP_SMS_Wwpsmscreated == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_SMS_Wwpsmscreated, null, true).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_SMS_Wwpsmscreated = DateTime.MinValue;
            else
               gxTv_SdtWWP_SMS_Wwpsmscreated = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Wwpsmscreated
      {
         get {
            return gxTv_SdtWWP_SMS_Wwpsmscreated ;
         }

         set {
            gxTv_SdtWWP_SMS_Wwpsmscreated = value;
            SetDirty("Wwpsmscreated");
         }

      }

      [  SoapElement( ElementName = "WWPSMSScheduled" )]
      [  XmlElement( ElementName = "WWPSMSScheduled"  , IsNullable=true )]
      public string gxTpr_Wwpsmsscheduled_Nullable
      {
         get {
            if ( gxTv_SdtWWP_SMS_Wwpsmsscheduled == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_SMS_Wwpsmsscheduled, null, true).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_SMS_Wwpsmsscheduled = DateTime.MinValue;
            else
               gxTv_SdtWWP_SMS_Wwpsmsscheduled = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Wwpsmsscheduled
      {
         get {
            return gxTv_SdtWWP_SMS_Wwpsmsscheduled ;
         }

         set {
            gxTv_SdtWWP_SMS_Wwpsmsscheduled = value;
            SetDirty("Wwpsmsscheduled");
         }

      }

      [  SoapElement( ElementName = "WWPSMSProcessed" )]
      [  XmlElement( ElementName = "WWPSMSProcessed"  , IsNullable=true )]
      public string gxTpr_Wwpsmsprocessed_Nullable
      {
         get {
            if ( gxTv_SdtWWP_SMS_Wwpsmsprocessed == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_SMS_Wwpsmsprocessed, null, true).value ;
         }

         set {
            gxTv_SdtWWP_SMS_Wwpsmsprocessed_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_SMS_Wwpsmsprocessed = DateTime.MinValue;
            else
               gxTv_SdtWWP_SMS_Wwpsmsprocessed = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Wwpsmsprocessed
      {
         get {
            return gxTv_SdtWWP_SMS_Wwpsmsprocessed ;
         }

         set {
            gxTv_SdtWWP_SMS_Wwpsmsprocessed_N = 0;
            gxTv_SdtWWP_SMS_Wwpsmsprocessed = value;
            SetDirty("Wwpsmsprocessed");
         }

      }

      public void gxTv_SdtWWP_SMS_Wwpsmsprocessed_SetNull( )
      {
         gxTv_SdtWWP_SMS_Wwpsmsprocessed_N = 1;
         gxTv_SdtWWP_SMS_Wwpsmsprocessed = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtWWP_SMS_Wwpsmsprocessed_IsNull( )
      {
         return (gxTv_SdtWWP_SMS_Wwpsmsprocessed_N==1) ;
      }

      [  SoapElement( ElementName = "WWPSMSDetail" )]
      [  XmlElement( ElementName = "WWPSMSDetail"   )]
      public string gxTpr_Wwpsmsdetail
      {
         get {
            return gxTv_SdtWWP_SMS_Wwpsmsdetail ;
         }

         set {
            gxTv_SdtWWP_SMS_Wwpsmsdetail_N = 0;
            gxTv_SdtWWP_SMS_Wwpsmsdetail = value;
            SetDirty("Wwpsmsdetail");
         }

      }

      public void gxTv_SdtWWP_SMS_Wwpsmsdetail_SetNull( )
      {
         gxTv_SdtWWP_SMS_Wwpsmsdetail_N = 1;
         gxTv_SdtWWP_SMS_Wwpsmsdetail = "";
         return  ;
      }

      public bool gxTv_SdtWWP_SMS_Wwpsmsdetail_IsNull( )
      {
         return (gxTv_SdtWWP_SMS_Wwpsmsdetail_N==1) ;
      }

      [  SoapElement( ElementName = "WWPNotificationId" )]
      [  XmlElement( ElementName = "WWPNotificationId"   )]
      public long gxTpr_Wwpnotificationid
      {
         get {
            return gxTv_SdtWWP_SMS_Wwpnotificationid ;
         }

         set {
            gxTv_SdtWWP_SMS_Wwpnotificationid_N = 0;
            gxTv_SdtWWP_SMS_Wwpnotificationid = value;
            SetDirty("Wwpnotificationid");
         }

      }

      public void gxTv_SdtWWP_SMS_Wwpnotificationid_SetNull( )
      {
         gxTv_SdtWWP_SMS_Wwpnotificationid_N = 1;
         gxTv_SdtWWP_SMS_Wwpnotificationid = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_SMS_Wwpnotificationid_IsNull( )
      {
         return (gxTv_SdtWWP_SMS_Wwpnotificationid_N==1) ;
      }

      [  SoapElement( ElementName = "WWPNotificationCreated" )]
      [  XmlElement( ElementName = "WWPNotificationCreated"  , IsNullable=true )]
      public string gxTpr_Wwpnotificationcreated_Nullable
      {
         get {
            if ( gxTv_SdtWWP_SMS_Wwpnotificationcreated == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_SMS_Wwpnotificationcreated, null, true).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_SMS_Wwpnotificationcreated = DateTime.MinValue;
            else
               gxTv_SdtWWP_SMS_Wwpnotificationcreated = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Wwpnotificationcreated
      {
         get {
            return gxTv_SdtWWP_SMS_Wwpnotificationcreated ;
         }

         set {
            gxTv_SdtWWP_SMS_Wwpnotificationcreated = value;
            SetDirty("Wwpnotificationcreated");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtWWP_SMS_Mode ;
         }

         set {
            gxTv_SdtWWP_SMS_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtWWP_SMS_Mode_SetNull( )
      {
         gxTv_SdtWWP_SMS_Mode = "";
         return  ;
      }

      public bool gxTv_SdtWWP_SMS_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtWWP_SMS_Initialized ;
         }

         set {
            gxTv_SdtWWP_SMS_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtWWP_SMS_Initialized_SetNull( )
      {
         gxTv_SdtWWP_SMS_Initialized = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_SMS_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPSMSId_Z" )]
      [  XmlElement( ElementName = "WWPSMSId_Z"   )]
      public long gxTpr_Wwpsmsid_Z
      {
         get {
            return gxTv_SdtWWP_SMS_Wwpsmsid_Z ;
         }

         set {
            gxTv_SdtWWP_SMS_Wwpsmsid_Z = value;
            SetDirty("Wwpsmsid_Z");
         }

      }

      public void gxTv_SdtWWP_SMS_Wwpsmsid_Z_SetNull( )
      {
         gxTv_SdtWWP_SMS_Wwpsmsid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_SMS_Wwpsmsid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPSMSStatus_Z" )]
      [  XmlElement( ElementName = "WWPSMSStatus_Z"   )]
      public short gxTpr_Wwpsmsstatus_Z
      {
         get {
            return gxTv_SdtWWP_SMS_Wwpsmsstatus_Z ;
         }

         set {
            gxTv_SdtWWP_SMS_Wwpsmsstatus_Z = value;
            SetDirty("Wwpsmsstatus_Z");
         }

      }

      public void gxTv_SdtWWP_SMS_Wwpsmsstatus_Z_SetNull( )
      {
         gxTv_SdtWWP_SMS_Wwpsmsstatus_Z = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_SMS_Wwpsmsstatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPSMSCreated_Z" )]
      [  XmlElement( ElementName = "WWPSMSCreated_Z"  , IsNullable=true )]
      public string gxTpr_Wwpsmscreated_Z_Nullable
      {
         get {
            if ( gxTv_SdtWWP_SMS_Wwpsmscreated_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_SMS_Wwpsmscreated_Z, null, true).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_SMS_Wwpsmscreated_Z = DateTime.MinValue;
            else
               gxTv_SdtWWP_SMS_Wwpsmscreated_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Wwpsmscreated_Z
      {
         get {
            return gxTv_SdtWWP_SMS_Wwpsmscreated_Z ;
         }

         set {
            gxTv_SdtWWP_SMS_Wwpsmscreated_Z = value;
            SetDirty("Wwpsmscreated_Z");
         }

      }

      public void gxTv_SdtWWP_SMS_Wwpsmscreated_Z_SetNull( )
      {
         gxTv_SdtWWP_SMS_Wwpsmscreated_Z = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtWWP_SMS_Wwpsmscreated_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPSMSScheduled_Z" )]
      [  XmlElement( ElementName = "WWPSMSScheduled_Z"  , IsNullable=true )]
      public string gxTpr_Wwpsmsscheduled_Z_Nullable
      {
         get {
            if ( gxTv_SdtWWP_SMS_Wwpsmsscheduled_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_SMS_Wwpsmsscheduled_Z, null, true).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_SMS_Wwpsmsscheduled_Z = DateTime.MinValue;
            else
               gxTv_SdtWWP_SMS_Wwpsmsscheduled_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Wwpsmsscheduled_Z
      {
         get {
            return gxTv_SdtWWP_SMS_Wwpsmsscheduled_Z ;
         }

         set {
            gxTv_SdtWWP_SMS_Wwpsmsscheduled_Z = value;
            SetDirty("Wwpsmsscheduled_Z");
         }

      }

      public void gxTv_SdtWWP_SMS_Wwpsmsscheduled_Z_SetNull( )
      {
         gxTv_SdtWWP_SMS_Wwpsmsscheduled_Z = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtWWP_SMS_Wwpsmsscheduled_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPSMSProcessed_Z" )]
      [  XmlElement( ElementName = "WWPSMSProcessed_Z"  , IsNullable=true )]
      public string gxTpr_Wwpsmsprocessed_Z_Nullable
      {
         get {
            if ( gxTv_SdtWWP_SMS_Wwpsmsprocessed_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_SMS_Wwpsmsprocessed_Z, null, true).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_SMS_Wwpsmsprocessed_Z = DateTime.MinValue;
            else
               gxTv_SdtWWP_SMS_Wwpsmsprocessed_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Wwpsmsprocessed_Z
      {
         get {
            return gxTv_SdtWWP_SMS_Wwpsmsprocessed_Z ;
         }

         set {
            gxTv_SdtWWP_SMS_Wwpsmsprocessed_Z = value;
            SetDirty("Wwpsmsprocessed_Z");
         }

      }

      public void gxTv_SdtWWP_SMS_Wwpsmsprocessed_Z_SetNull( )
      {
         gxTv_SdtWWP_SMS_Wwpsmsprocessed_Z = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtWWP_SMS_Wwpsmsprocessed_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationId_Z" )]
      [  XmlElement( ElementName = "WWPNotificationId_Z"   )]
      public long gxTpr_Wwpnotificationid_Z
      {
         get {
            return gxTv_SdtWWP_SMS_Wwpnotificationid_Z ;
         }

         set {
            gxTv_SdtWWP_SMS_Wwpnotificationid_Z = value;
            SetDirty("Wwpnotificationid_Z");
         }

      }

      public void gxTv_SdtWWP_SMS_Wwpnotificationid_Z_SetNull( )
      {
         gxTv_SdtWWP_SMS_Wwpnotificationid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_SMS_Wwpnotificationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationCreated_Z" )]
      [  XmlElement( ElementName = "WWPNotificationCreated_Z"  , IsNullable=true )]
      public string gxTpr_Wwpnotificationcreated_Z_Nullable
      {
         get {
            if ( gxTv_SdtWWP_SMS_Wwpnotificationcreated_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_SMS_Wwpnotificationcreated_Z, null, true).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_SMS_Wwpnotificationcreated_Z = DateTime.MinValue;
            else
               gxTv_SdtWWP_SMS_Wwpnotificationcreated_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Wwpnotificationcreated_Z
      {
         get {
            return gxTv_SdtWWP_SMS_Wwpnotificationcreated_Z ;
         }

         set {
            gxTv_SdtWWP_SMS_Wwpnotificationcreated_Z = value;
            SetDirty("Wwpnotificationcreated_Z");
         }

      }

      public void gxTv_SdtWWP_SMS_Wwpnotificationcreated_Z_SetNull( )
      {
         gxTv_SdtWWP_SMS_Wwpnotificationcreated_Z = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtWWP_SMS_Wwpnotificationcreated_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPSMSProcessed_N" )]
      [  XmlElement( ElementName = "WWPSMSProcessed_N"   )]
      public short gxTpr_Wwpsmsprocessed_N
      {
         get {
            return gxTv_SdtWWP_SMS_Wwpsmsprocessed_N ;
         }

         set {
            gxTv_SdtWWP_SMS_Wwpsmsprocessed_N = value;
            SetDirty("Wwpsmsprocessed_N");
         }

      }

      public void gxTv_SdtWWP_SMS_Wwpsmsprocessed_N_SetNull( )
      {
         gxTv_SdtWWP_SMS_Wwpsmsprocessed_N = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_SMS_Wwpsmsprocessed_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPSMSDetail_N" )]
      [  XmlElement( ElementName = "WWPSMSDetail_N"   )]
      public short gxTpr_Wwpsmsdetail_N
      {
         get {
            return gxTv_SdtWWP_SMS_Wwpsmsdetail_N ;
         }

         set {
            gxTv_SdtWWP_SMS_Wwpsmsdetail_N = value;
            SetDirty("Wwpsmsdetail_N");
         }

      }

      public void gxTv_SdtWWP_SMS_Wwpsmsdetail_N_SetNull( )
      {
         gxTv_SdtWWP_SMS_Wwpsmsdetail_N = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_SMS_Wwpsmsdetail_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationId_N" )]
      [  XmlElement( ElementName = "WWPNotificationId_N"   )]
      public short gxTpr_Wwpnotificationid_N
      {
         get {
            return gxTv_SdtWWP_SMS_Wwpnotificationid_N ;
         }

         set {
            gxTv_SdtWWP_SMS_Wwpnotificationid_N = value;
            SetDirty("Wwpnotificationid_N");
         }

      }

      public void gxTv_SdtWWP_SMS_Wwpnotificationid_N_SetNull( )
      {
         gxTv_SdtWWP_SMS_Wwpnotificationid_N = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_SMS_Wwpnotificationid_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtWWP_SMS_Wwpsmsmessage = "";
         gxTv_SdtWWP_SMS_Wwpsmssendernumber = "";
         gxTv_SdtWWP_SMS_Wwpsmsrecipientnumbers = "";
         gxTv_SdtWWP_SMS_Wwpsmscreated = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_SMS_Wwpsmsscheduled = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_SMS_Wwpsmsprocessed = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_SMS_Wwpsmsdetail = "";
         gxTv_SdtWWP_SMS_Wwpnotificationcreated = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_SMS_Mode = "";
         gxTv_SdtWWP_SMS_Wwpsmscreated_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_SMS_Wwpsmsscheduled_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_SMS_Wwpsmsprocessed_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_SMS_Wwpnotificationcreated_Z = (DateTime)(DateTime.MinValue);
         datetimemil_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "wwpbaseobjects.sms.wwp_sms", "GeneXus.Programs.wwpbaseobjects.sms.wwp_sms_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      private short gxTv_SdtWWP_SMS_Wwpsmsstatus ;
      private short gxTv_SdtWWP_SMS_Initialized ;
      private short gxTv_SdtWWP_SMS_Wwpsmsstatus_Z ;
      private short gxTv_SdtWWP_SMS_Wwpsmsprocessed_N ;
      private short gxTv_SdtWWP_SMS_Wwpsmsdetail_N ;
      private short gxTv_SdtWWP_SMS_Wwpnotificationid_N ;
      private long gxTv_SdtWWP_SMS_Wwpsmsid ;
      private long gxTv_SdtWWP_SMS_Wwpnotificationid ;
      private long gxTv_SdtWWP_SMS_Wwpsmsid_Z ;
      private long gxTv_SdtWWP_SMS_Wwpnotificationid_Z ;
      private string gxTv_SdtWWP_SMS_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtWWP_SMS_Wwpsmscreated ;
      private DateTime gxTv_SdtWWP_SMS_Wwpsmsscheduled ;
      private DateTime gxTv_SdtWWP_SMS_Wwpsmsprocessed ;
      private DateTime gxTv_SdtWWP_SMS_Wwpnotificationcreated ;
      private DateTime gxTv_SdtWWP_SMS_Wwpsmscreated_Z ;
      private DateTime gxTv_SdtWWP_SMS_Wwpsmsscheduled_Z ;
      private DateTime gxTv_SdtWWP_SMS_Wwpsmsprocessed_Z ;
      private DateTime gxTv_SdtWWP_SMS_Wwpnotificationcreated_Z ;
      private DateTime datetimemil_STZ ;
      private string gxTv_SdtWWP_SMS_Wwpsmsmessage ;
      private string gxTv_SdtWWP_SMS_Wwpsmssendernumber ;
      private string gxTv_SdtWWP_SMS_Wwpsmsrecipientnumbers ;
      private string gxTv_SdtWWP_SMS_Wwpsmsdetail ;
   }

   [DataContract(Name = @"WWPBaseObjects\SMS\WWP_SMS", Namespace = "RastreamentoTCC")]
   public class SdtWWP_SMS_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWWP_SMS_RESTInterface( ) : base()
      {
      }

      public SdtWWP_SMS_RESTInterface( GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WWPSMSId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Wwpsmsid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Wwpsmsid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Wwpsmsid = (long)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "WWPSMSMessage" , Order = 1 )]
      public string gxTpr_Wwpsmsmessage
      {
         get {
            return sdt.gxTpr_Wwpsmsmessage ;
         }

         set {
            sdt.gxTpr_Wwpsmsmessage = value;
         }

      }

      [DataMember( Name = "WWPSMSSenderNumber" , Order = 2 )]
      public string gxTpr_Wwpsmssendernumber
      {
         get {
            return sdt.gxTpr_Wwpsmssendernumber ;
         }

         set {
            sdt.gxTpr_Wwpsmssendernumber = value;
         }

      }

      [DataMember( Name = "WWPSMSRecipientNumbers" , Order = 3 )]
      public string gxTpr_Wwpsmsrecipientnumbers
      {
         get {
            return sdt.gxTpr_Wwpsmsrecipientnumbers ;
         }

         set {
            sdt.gxTpr_Wwpsmsrecipientnumbers = value;
         }

      }

      [DataMember( Name = "WWPSMSStatus" , Order = 4 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Wwpsmsstatus
      {
         get {
            return sdt.gxTpr_Wwpsmsstatus ;
         }

         set {
            sdt.gxTpr_Wwpsmsstatus = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPSMSCreated" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Wwpsmscreated
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Wwpsmscreated) ;
         }

         set {
            sdt.gxTpr_Wwpsmscreated = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "WWPSMSScheduled" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Wwpsmsscheduled
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Wwpsmsscheduled) ;
         }

         set {
            sdt.gxTpr_Wwpsmsscheduled = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "WWPSMSProcessed" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Wwpsmsprocessed
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Wwpsmsprocessed) ;
         }

         set {
            sdt.gxTpr_Wwpsmsprocessed = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "WWPSMSDetail" , Order = 8 )]
      public string gxTpr_Wwpsmsdetail
      {
         get {
            return sdt.gxTpr_Wwpsmsdetail ;
         }

         set {
            sdt.gxTpr_Wwpsmsdetail = value;
         }

      }

      [DataMember( Name = "WWPNotificationId" , Order = 9 )]
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

      [DataMember( Name = "WWPNotificationCreated" , Order = 10 )]
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

      public GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 11 )]
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

   [DataContract(Name = @"WWPBaseObjects\SMS\WWP_SMS", Namespace = "RastreamentoTCC")]
   public class SdtWWP_SMS_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWWP_SMS_RESTLInterface( ) : base()
      {
      }

      public SdtWWP_SMS_RESTLInterface( GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WWPSMSMessage" , Order = 0 )]
      public string gxTpr_Wwpsmsmessage
      {
         get {
            return sdt.gxTpr_Wwpsmsmessage ;
         }

         set {
            sdt.gxTpr_Wwpsmsmessage = value;
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

      public GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS() ;
         }
      }

   }

}
