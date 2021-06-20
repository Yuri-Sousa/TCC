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
namespace GeneXus.Programs.wwpbaseobjects.mail {
   [XmlSerializerFormat]
   [XmlRoot(ElementName = "WWP_Mail" )]
   [XmlType(TypeName =  "WWP_Mail" , Namespace = "RastreamentoTCC" )]
   [Serializable]
   public class SdtWWP_Mail : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWWP_Mail( )
      {
      }

      public SdtWWP_Mail( IGxContext context )
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

      public void Load( long AV20WWPMailId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(long)AV20WWPMailId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"WWPMailId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "WWPBaseObjects\\Mail\\WWP_Mail");
         metadata.Set("BT", "WWP_Mail");
         metadata.Set("PK", "[ \"WWPMailId\" ]");
         metadata.Set("PKAssigned", "[ \"WWPMailId\" ]");
         metadata.Set("Levels", "[ \"Attachments\" ]");
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
         state.Add("gxTpr_Wwpmailid_Z");
         state.Add("gxTpr_Wwpmailsubject_Z");
         state.Add("gxTpr_Wwpmailstatus_Z");
         state.Add("gxTpr_Wwpmailcreated_Z_Nullable");
         state.Add("gxTpr_Wwpmailscheduled_Z_Nullable");
         state.Add("gxTpr_Wwpmailprocessed_Z_Nullable");
         state.Add("gxTpr_Wwpnotificationid_Z");
         state.Add("gxTpr_Wwpnotificationcreated_Z_Nullable");
         state.Add("gxTpr_Wwpmailto_N");
         state.Add("gxTpr_Wwpmailcc_N");
         state.Add("gxTpr_Wwpmailbcc_N");
         state.Add("gxTpr_Wwpmailprocessed_N");
         state.Add("gxTpr_Wwpmaildetail_N");
         state.Add("gxTpr_Wwpnotificationid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail sdt;
         sdt = (GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail)(source);
         gxTv_SdtWWP_Mail_Wwpmailid = sdt.gxTv_SdtWWP_Mail_Wwpmailid ;
         gxTv_SdtWWP_Mail_Wwpmailsubject = sdt.gxTv_SdtWWP_Mail_Wwpmailsubject ;
         gxTv_SdtWWP_Mail_Wwpmailbody = sdt.gxTv_SdtWWP_Mail_Wwpmailbody ;
         gxTv_SdtWWP_Mail_Wwpmailto = sdt.gxTv_SdtWWP_Mail_Wwpmailto ;
         gxTv_SdtWWP_Mail_Wwpmailcc = sdt.gxTv_SdtWWP_Mail_Wwpmailcc ;
         gxTv_SdtWWP_Mail_Wwpmailbcc = sdt.gxTv_SdtWWP_Mail_Wwpmailbcc ;
         gxTv_SdtWWP_Mail_Wwpmailsenderaddress = sdt.gxTv_SdtWWP_Mail_Wwpmailsenderaddress ;
         gxTv_SdtWWP_Mail_Wwpmailsendername = sdt.gxTv_SdtWWP_Mail_Wwpmailsendername ;
         gxTv_SdtWWP_Mail_Wwpmailstatus = sdt.gxTv_SdtWWP_Mail_Wwpmailstatus ;
         gxTv_SdtWWP_Mail_Wwpmailcreated = sdt.gxTv_SdtWWP_Mail_Wwpmailcreated ;
         gxTv_SdtWWP_Mail_Wwpmailscheduled = sdt.gxTv_SdtWWP_Mail_Wwpmailscheduled ;
         gxTv_SdtWWP_Mail_Wwpmailprocessed = sdt.gxTv_SdtWWP_Mail_Wwpmailprocessed ;
         gxTv_SdtWWP_Mail_Wwpmaildetail = sdt.gxTv_SdtWWP_Mail_Wwpmaildetail ;
         gxTv_SdtWWP_Mail_Wwpnotificationid = sdt.gxTv_SdtWWP_Mail_Wwpnotificationid ;
         gxTv_SdtWWP_Mail_Wwpnotificationcreated = sdt.gxTv_SdtWWP_Mail_Wwpnotificationcreated ;
         gxTv_SdtWWP_Mail_Attachments = sdt.gxTv_SdtWWP_Mail_Attachments ;
         gxTv_SdtWWP_Mail_Mode = sdt.gxTv_SdtWWP_Mail_Mode ;
         gxTv_SdtWWP_Mail_Initialized = sdt.gxTv_SdtWWP_Mail_Initialized ;
         gxTv_SdtWWP_Mail_Wwpmailid_Z = sdt.gxTv_SdtWWP_Mail_Wwpmailid_Z ;
         gxTv_SdtWWP_Mail_Wwpmailsubject_Z = sdt.gxTv_SdtWWP_Mail_Wwpmailsubject_Z ;
         gxTv_SdtWWP_Mail_Wwpmailstatus_Z = sdt.gxTv_SdtWWP_Mail_Wwpmailstatus_Z ;
         gxTv_SdtWWP_Mail_Wwpmailcreated_Z = sdt.gxTv_SdtWWP_Mail_Wwpmailcreated_Z ;
         gxTv_SdtWWP_Mail_Wwpmailscheduled_Z = sdt.gxTv_SdtWWP_Mail_Wwpmailscheduled_Z ;
         gxTv_SdtWWP_Mail_Wwpmailprocessed_Z = sdt.gxTv_SdtWWP_Mail_Wwpmailprocessed_Z ;
         gxTv_SdtWWP_Mail_Wwpnotificationid_Z = sdt.gxTv_SdtWWP_Mail_Wwpnotificationid_Z ;
         gxTv_SdtWWP_Mail_Wwpnotificationcreated_Z = sdt.gxTv_SdtWWP_Mail_Wwpnotificationcreated_Z ;
         gxTv_SdtWWP_Mail_Wwpmailto_N = sdt.gxTv_SdtWWP_Mail_Wwpmailto_N ;
         gxTv_SdtWWP_Mail_Wwpmailcc_N = sdt.gxTv_SdtWWP_Mail_Wwpmailcc_N ;
         gxTv_SdtWWP_Mail_Wwpmailbcc_N = sdt.gxTv_SdtWWP_Mail_Wwpmailbcc_N ;
         gxTv_SdtWWP_Mail_Wwpmailprocessed_N = sdt.gxTv_SdtWWP_Mail_Wwpmailprocessed_N ;
         gxTv_SdtWWP_Mail_Wwpmaildetail_N = sdt.gxTv_SdtWWP_Mail_Wwpmaildetail_N ;
         gxTv_SdtWWP_Mail_Wwpnotificationid_N = sdt.gxTv_SdtWWP_Mail_Wwpnotificationid_N ;
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
         AddObjectProperty("WWPMailId", gxTv_SdtWWP_Mail_Wwpmailid, false, includeNonInitialized);
         AddObjectProperty("WWPMailSubject", gxTv_SdtWWP_Mail_Wwpmailsubject, false, includeNonInitialized);
         AddObjectProperty("WWPMailBody", gxTv_SdtWWP_Mail_Wwpmailbody, false, includeNonInitialized);
         AddObjectProperty("WWPMailTo", gxTv_SdtWWP_Mail_Wwpmailto, false, includeNonInitialized);
         AddObjectProperty("WWPMailTo_N", gxTv_SdtWWP_Mail_Wwpmailto_N, false, includeNonInitialized);
         AddObjectProperty("WWPMailCC", gxTv_SdtWWP_Mail_Wwpmailcc, false, includeNonInitialized);
         AddObjectProperty("WWPMailCC_N", gxTv_SdtWWP_Mail_Wwpmailcc_N, false, includeNonInitialized);
         AddObjectProperty("WWPMailBCC", gxTv_SdtWWP_Mail_Wwpmailbcc, false, includeNonInitialized);
         AddObjectProperty("WWPMailBCC_N", gxTv_SdtWWP_Mail_Wwpmailbcc_N, false, includeNonInitialized);
         AddObjectProperty("WWPMailSenderAddress", gxTv_SdtWWP_Mail_Wwpmailsenderaddress, false, includeNonInitialized);
         AddObjectProperty("WWPMailSenderName", gxTv_SdtWWP_Mail_Wwpmailsendername, false, includeNonInitialized);
         AddObjectProperty("WWPMailStatus", gxTv_SdtWWP_Mail_Wwpmailstatus, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtWWP_Mail_Wwpmailcreated;
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
         AddObjectProperty("WWPMailCreated", sDateCnv, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtWWP_Mail_Wwpmailscheduled;
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
         AddObjectProperty("WWPMailScheduled", sDateCnv, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtWWP_Mail_Wwpmailprocessed;
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
         AddObjectProperty("WWPMailProcessed", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("WWPMailProcessed_N", gxTv_SdtWWP_Mail_Wwpmailprocessed_N, false, includeNonInitialized);
         AddObjectProperty("WWPMailDetail", gxTv_SdtWWP_Mail_Wwpmaildetail, false, includeNonInitialized);
         AddObjectProperty("WWPMailDetail_N", gxTv_SdtWWP_Mail_Wwpmaildetail_N, false, includeNonInitialized);
         AddObjectProperty("WWPNotificationId", gxTv_SdtWWP_Mail_Wwpnotificationid, false, includeNonInitialized);
         AddObjectProperty("WWPNotificationId_N", gxTv_SdtWWP_Mail_Wwpnotificationid_N, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtWWP_Mail_Wwpnotificationcreated;
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
         if ( gxTv_SdtWWP_Mail_Attachments != null )
         {
            AddObjectProperty("Attachments", gxTv_SdtWWP_Mail_Attachments, includeState, includeNonInitialized);
         }
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtWWP_Mail_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtWWP_Mail_Initialized, false, includeNonInitialized);
            AddObjectProperty("WWPMailId_Z", gxTv_SdtWWP_Mail_Wwpmailid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPMailSubject_Z", gxTv_SdtWWP_Mail_Wwpmailsubject_Z, false, includeNonInitialized);
            AddObjectProperty("WWPMailStatus_Z", gxTv_SdtWWP_Mail_Wwpmailstatus_Z, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtWWP_Mail_Wwpmailcreated_Z;
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
            AddObjectProperty("WWPMailCreated_Z", sDateCnv, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtWWP_Mail_Wwpmailscheduled_Z;
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
            AddObjectProperty("WWPMailScheduled_Z", sDateCnv, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtWWP_Mail_Wwpmailprocessed_Z;
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
            AddObjectProperty("WWPMailProcessed_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("WWPNotificationId_Z", gxTv_SdtWWP_Mail_Wwpnotificationid_Z, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtWWP_Mail_Wwpnotificationcreated_Z;
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
            AddObjectProperty("WWPMailTo_N", gxTv_SdtWWP_Mail_Wwpmailto_N, false, includeNonInitialized);
            AddObjectProperty("WWPMailCC_N", gxTv_SdtWWP_Mail_Wwpmailcc_N, false, includeNonInitialized);
            AddObjectProperty("WWPMailBCC_N", gxTv_SdtWWP_Mail_Wwpmailbcc_N, false, includeNonInitialized);
            AddObjectProperty("WWPMailProcessed_N", gxTv_SdtWWP_Mail_Wwpmailprocessed_N, false, includeNonInitialized);
            AddObjectProperty("WWPMailDetail_N", gxTv_SdtWWP_Mail_Wwpmaildetail_N, false, includeNonInitialized);
            AddObjectProperty("WWPNotificationId_N", gxTv_SdtWWP_Mail_Wwpnotificationid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail sdt )
      {
         if ( sdt.IsDirty("WWPMailId") )
         {
            gxTv_SdtWWP_Mail_Wwpmailid = sdt.gxTv_SdtWWP_Mail_Wwpmailid ;
         }
         if ( sdt.IsDirty("WWPMailSubject") )
         {
            gxTv_SdtWWP_Mail_Wwpmailsubject = sdt.gxTv_SdtWWP_Mail_Wwpmailsubject ;
         }
         if ( sdt.IsDirty("WWPMailBody") )
         {
            gxTv_SdtWWP_Mail_Wwpmailbody = sdt.gxTv_SdtWWP_Mail_Wwpmailbody ;
         }
         if ( sdt.IsDirty("WWPMailTo") )
         {
            gxTv_SdtWWP_Mail_Wwpmailto_N = 0;
            gxTv_SdtWWP_Mail_Wwpmailto = sdt.gxTv_SdtWWP_Mail_Wwpmailto ;
         }
         if ( sdt.IsDirty("WWPMailCC") )
         {
            gxTv_SdtWWP_Mail_Wwpmailcc_N = 0;
            gxTv_SdtWWP_Mail_Wwpmailcc = sdt.gxTv_SdtWWP_Mail_Wwpmailcc ;
         }
         if ( sdt.IsDirty("WWPMailBCC") )
         {
            gxTv_SdtWWP_Mail_Wwpmailbcc_N = 0;
            gxTv_SdtWWP_Mail_Wwpmailbcc = sdt.gxTv_SdtWWP_Mail_Wwpmailbcc ;
         }
         if ( sdt.IsDirty("WWPMailSenderAddress") )
         {
            gxTv_SdtWWP_Mail_Wwpmailsenderaddress = sdt.gxTv_SdtWWP_Mail_Wwpmailsenderaddress ;
         }
         if ( sdt.IsDirty("WWPMailSenderName") )
         {
            gxTv_SdtWWP_Mail_Wwpmailsendername = sdt.gxTv_SdtWWP_Mail_Wwpmailsendername ;
         }
         if ( sdt.IsDirty("WWPMailStatus") )
         {
            gxTv_SdtWWP_Mail_Wwpmailstatus = sdt.gxTv_SdtWWP_Mail_Wwpmailstatus ;
         }
         if ( sdt.IsDirty("WWPMailCreated") )
         {
            gxTv_SdtWWP_Mail_Wwpmailcreated = sdt.gxTv_SdtWWP_Mail_Wwpmailcreated ;
         }
         if ( sdt.IsDirty("WWPMailScheduled") )
         {
            gxTv_SdtWWP_Mail_Wwpmailscheduled = sdt.gxTv_SdtWWP_Mail_Wwpmailscheduled ;
         }
         if ( sdt.IsDirty("WWPMailProcessed") )
         {
            gxTv_SdtWWP_Mail_Wwpmailprocessed_N = 0;
            gxTv_SdtWWP_Mail_Wwpmailprocessed = sdt.gxTv_SdtWWP_Mail_Wwpmailprocessed ;
         }
         if ( sdt.IsDirty("WWPMailDetail") )
         {
            gxTv_SdtWWP_Mail_Wwpmaildetail_N = 0;
            gxTv_SdtWWP_Mail_Wwpmaildetail = sdt.gxTv_SdtWWP_Mail_Wwpmaildetail ;
         }
         if ( sdt.IsDirty("WWPNotificationId") )
         {
            gxTv_SdtWWP_Mail_Wwpnotificationid_N = 0;
            gxTv_SdtWWP_Mail_Wwpnotificationid = sdt.gxTv_SdtWWP_Mail_Wwpnotificationid ;
         }
         if ( sdt.IsDirty("WWPNotificationCreated") )
         {
            gxTv_SdtWWP_Mail_Wwpnotificationcreated = sdt.gxTv_SdtWWP_Mail_Wwpnotificationcreated ;
         }
         if ( gxTv_SdtWWP_Mail_Attachments != null )
         {
            GXBCLevelCollection<GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments> newCollectionAttachments = sdt.gxTpr_Attachments;
            GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments currItemAttachments;
            GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments newItemAttachments;
            short idx = 1;
            while ( idx <= newCollectionAttachments.Count )
            {
               newItemAttachments = ((GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments)newCollectionAttachments.Item(idx));
               currItemAttachments = gxTv_SdtWWP_Mail_Attachments.GetByKey(newItemAttachments.gxTpr_Wwpmailattachmentname);
               if ( StringUtil.StrCmp(currItemAttachments.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemAttachments.UpdateDirties(newItemAttachments);
                  if ( StringUtil.StrCmp(newItemAttachments.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemAttachments.gxTpr_Mode = "DLT";
                  }
                  currItemAttachments.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtWWP_Mail_Attachments.Add(newItemAttachments, 0);
               }
               idx = (short)(idx+1);
            }
         }
         return  ;
      }

      [  SoapElement( ElementName = "WWPMailId" )]
      [  XmlElement( ElementName = "WWPMailId"   )]
      public long gxTpr_Wwpmailid
      {
         get {
            return gxTv_SdtWWP_Mail_Wwpmailid ;
         }

         set {
            if ( gxTv_SdtWWP_Mail_Wwpmailid != value )
            {
               gxTv_SdtWWP_Mail_Mode = "INS";
               this.gxTv_SdtWWP_Mail_Wwpmailid_Z_SetNull( );
               this.gxTv_SdtWWP_Mail_Wwpmailsubject_Z_SetNull( );
               this.gxTv_SdtWWP_Mail_Wwpmailstatus_Z_SetNull( );
               this.gxTv_SdtWWP_Mail_Wwpmailcreated_Z_SetNull( );
               this.gxTv_SdtWWP_Mail_Wwpmailscheduled_Z_SetNull( );
               this.gxTv_SdtWWP_Mail_Wwpmailprocessed_Z_SetNull( );
               this.gxTv_SdtWWP_Mail_Wwpnotificationid_Z_SetNull( );
               this.gxTv_SdtWWP_Mail_Wwpnotificationcreated_Z_SetNull( );
               if ( gxTv_SdtWWP_Mail_Attachments != null )
               {
                  GXBCLevelCollection<GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments> collectionAttachments = gxTv_SdtWWP_Mail_Attachments;
                  GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments currItemAttachments;
                  short idx = 1;
                  while ( idx <= collectionAttachments.Count )
                  {
                     currItemAttachments = ((GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments)collectionAttachments.Item(idx));
                     currItemAttachments.gxTpr_Mode = "INS";
                     currItemAttachments.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtWWP_Mail_Wwpmailid = value;
            SetDirty("Wwpmailid");
         }

      }

      [  SoapElement( ElementName = "WWPMailSubject" )]
      [  XmlElement( ElementName = "WWPMailSubject"   )]
      public string gxTpr_Wwpmailsubject
      {
         get {
            return gxTv_SdtWWP_Mail_Wwpmailsubject ;
         }

         set {
            gxTv_SdtWWP_Mail_Wwpmailsubject = value;
            SetDirty("Wwpmailsubject");
         }

      }

      [  SoapElement( ElementName = "WWPMailBody" )]
      [  XmlElement( ElementName = "WWPMailBody"   )]
      public string gxTpr_Wwpmailbody
      {
         get {
            return gxTv_SdtWWP_Mail_Wwpmailbody ;
         }

         set {
            gxTv_SdtWWP_Mail_Wwpmailbody = value;
            SetDirty("Wwpmailbody");
         }

      }

      [  SoapElement( ElementName = "WWPMailTo" )]
      [  XmlElement( ElementName = "WWPMailTo"   )]
      public string gxTpr_Wwpmailto
      {
         get {
            return gxTv_SdtWWP_Mail_Wwpmailto ;
         }

         set {
            gxTv_SdtWWP_Mail_Wwpmailto_N = 0;
            gxTv_SdtWWP_Mail_Wwpmailto = value;
            SetDirty("Wwpmailto");
         }

      }

      public void gxTv_SdtWWP_Mail_Wwpmailto_SetNull( )
      {
         gxTv_SdtWWP_Mail_Wwpmailto_N = 1;
         gxTv_SdtWWP_Mail_Wwpmailto = "";
         return  ;
      }

      public bool gxTv_SdtWWP_Mail_Wwpmailto_IsNull( )
      {
         return (gxTv_SdtWWP_Mail_Wwpmailto_N==1) ;
      }

      [  SoapElement( ElementName = "WWPMailCC" )]
      [  XmlElement( ElementName = "WWPMailCC"   )]
      public string gxTpr_Wwpmailcc
      {
         get {
            return gxTv_SdtWWP_Mail_Wwpmailcc ;
         }

         set {
            gxTv_SdtWWP_Mail_Wwpmailcc_N = 0;
            gxTv_SdtWWP_Mail_Wwpmailcc = value;
            SetDirty("Wwpmailcc");
         }

      }

      public void gxTv_SdtWWP_Mail_Wwpmailcc_SetNull( )
      {
         gxTv_SdtWWP_Mail_Wwpmailcc_N = 1;
         gxTv_SdtWWP_Mail_Wwpmailcc = "";
         return  ;
      }

      public bool gxTv_SdtWWP_Mail_Wwpmailcc_IsNull( )
      {
         return (gxTv_SdtWWP_Mail_Wwpmailcc_N==1) ;
      }

      [  SoapElement( ElementName = "WWPMailBCC" )]
      [  XmlElement( ElementName = "WWPMailBCC"   )]
      public string gxTpr_Wwpmailbcc
      {
         get {
            return gxTv_SdtWWP_Mail_Wwpmailbcc ;
         }

         set {
            gxTv_SdtWWP_Mail_Wwpmailbcc_N = 0;
            gxTv_SdtWWP_Mail_Wwpmailbcc = value;
            SetDirty("Wwpmailbcc");
         }

      }

      public void gxTv_SdtWWP_Mail_Wwpmailbcc_SetNull( )
      {
         gxTv_SdtWWP_Mail_Wwpmailbcc_N = 1;
         gxTv_SdtWWP_Mail_Wwpmailbcc = "";
         return  ;
      }

      public bool gxTv_SdtWWP_Mail_Wwpmailbcc_IsNull( )
      {
         return (gxTv_SdtWWP_Mail_Wwpmailbcc_N==1) ;
      }

      [  SoapElement( ElementName = "WWPMailSenderAddress" )]
      [  XmlElement( ElementName = "WWPMailSenderAddress"   )]
      public string gxTpr_Wwpmailsenderaddress
      {
         get {
            return gxTv_SdtWWP_Mail_Wwpmailsenderaddress ;
         }

         set {
            gxTv_SdtWWP_Mail_Wwpmailsenderaddress = value;
            SetDirty("Wwpmailsenderaddress");
         }

      }

      [  SoapElement( ElementName = "WWPMailSenderName" )]
      [  XmlElement( ElementName = "WWPMailSenderName"   )]
      public string gxTpr_Wwpmailsendername
      {
         get {
            return gxTv_SdtWWP_Mail_Wwpmailsendername ;
         }

         set {
            gxTv_SdtWWP_Mail_Wwpmailsendername = value;
            SetDirty("Wwpmailsendername");
         }

      }

      [  SoapElement( ElementName = "WWPMailStatus" )]
      [  XmlElement( ElementName = "WWPMailStatus"   )]
      public short gxTpr_Wwpmailstatus
      {
         get {
            return gxTv_SdtWWP_Mail_Wwpmailstatus ;
         }

         set {
            gxTv_SdtWWP_Mail_Wwpmailstatus = value;
            SetDirty("Wwpmailstatus");
         }

      }

      [  SoapElement( ElementName = "WWPMailCreated" )]
      [  XmlElement( ElementName = "WWPMailCreated"  , IsNullable=true )]
      public string gxTpr_Wwpmailcreated_Nullable
      {
         get {
            if ( gxTv_SdtWWP_Mail_Wwpmailcreated == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_Mail_Wwpmailcreated, null, true).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_Mail_Wwpmailcreated = DateTime.MinValue;
            else
               gxTv_SdtWWP_Mail_Wwpmailcreated = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Wwpmailcreated
      {
         get {
            return gxTv_SdtWWP_Mail_Wwpmailcreated ;
         }

         set {
            gxTv_SdtWWP_Mail_Wwpmailcreated = value;
            SetDirty("Wwpmailcreated");
         }

      }

      [  SoapElement( ElementName = "WWPMailScheduled" )]
      [  XmlElement( ElementName = "WWPMailScheduled"  , IsNullable=true )]
      public string gxTpr_Wwpmailscheduled_Nullable
      {
         get {
            if ( gxTv_SdtWWP_Mail_Wwpmailscheduled == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_Mail_Wwpmailscheduled, null, true).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_Mail_Wwpmailscheduled = DateTime.MinValue;
            else
               gxTv_SdtWWP_Mail_Wwpmailscheduled = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Wwpmailscheduled
      {
         get {
            return gxTv_SdtWWP_Mail_Wwpmailscheduled ;
         }

         set {
            gxTv_SdtWWP_Mail_Wwpmailscheduled = value;
            SetDirty("Wwpmailscheduled");
         }

      }

      [  SoapElement( ElementName = "WWPMailProcessed" )]
      [  XmlElement( ElementName = "WWPMailProcessed"  , IsNullable=true )]
      public string gxTpr_Wwpmailprocessed_Nullable
      {
         get {
            if ( gxTv_SdtWWP_Mail_Wwpmailprocessed == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_Mail_Wwpmailprocessed, null, true).value ;
         }

         set {
            gxTv_SdtWWP_Mail_Wwpmailprocessed_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_Mail_Wwpmailprocessed = DateTime.MinValue;
            else
               gxTv_SdtWWP_Mail_Wwpmailprocessed = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Wwpmailprocessed
      {
         get {
            return gxTv_SdtWWP_Mail_Wwpmailprocessed ;
         }

         set {
            gxTv_SdtWWP_Mail_Wwpmailprocessed_N = 0;
            gxTv_SdtWWP_Mail_Wwpmailprocessed = value;
            SetDirty("Wwpmailprocessed");
         }

      }

      public void gxTv_SdtWWP_Mail_Wwpmailprocessed_SetNull( )
      {
         gxTv_SdtWWP_Mail_Wwpmailprocessed_N = 1;
         gxTv_SdtWWP_Mail_Wwpmailprocessed = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtWWP_Mail_Wwpmailprocessed_IsNull( )
      {
         return (gxTv_SdtWWP_Mail_Wwpmailprocessed_N==1) ;
      }

      [  SoapElement( ElementName = "WWPMailDetail" )]
      [  XmlElement( ElementName = "WWPMailDetail"   )]
      public string gxTpr_Wwpmaildetail
      {
         get {
            return gxTv_SdtWWP_Mail_Wwpmaildetail ;
         }

         set {
            gxTv_SdtWWP_Mail_Wwpmaildetail_N = 0;
            gxTv_SdtWWP_Mail_Wwpmaildetail = value;
            SetDirty("Wwpmaildetail");
         }

      }

      public void gxTv_SdtWWP_Mail_Wwpmaildetail_SetNull( )
      {
         gxTv_SdtWWP_Mail_Wwpmaildetail_N = 1;
         gxTv_SdtWWP_Mail_Wwpmaildetail = "";
         return  ;
      }

      public bool gxTv_SdtWWP_Mail_Wwpmaildetail_IsNull( )
      {
         return (gxTv_SdtWWP_Mail_Wwpmaildetail_N==1) ;
      }

      [  SoapElement( ElementName = "WWPNotificationId" )]
      [  XmlElement( ElementName = "WWPNotificationId"   )]
      public long gxTpr_Wwpnotificationid
      {
         get {
            return gxTv_SdtWWP_Mail_Wwpnotificationid ;
         }

         set {
            gxTv_SdtWWP_Mail_Wwpnotificationid_N = 0;
            gxTv_SdtWWP_Mail_Wwpnotificationid = value;
            SetDirty("Wwpnotificationid");
         }

      }

      public void gxTv_SdtWWP_Mail_Wwpnotificationid_SetNull( )
      {
         gxTv_SdtWWP_Mail_Wwpnotificationid_N = 1;
         gxTv_SdtWWP_Mail_Wwpnotificationid = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_Mail_Wwpnotificationid_IsNull( )
      {
         return (gxTv_SdtWWP_Mail_Wwpnotificationid_N==1) ;
      }

      [  SoapElement( ElementName = "WWPNotificationCreated" )]
      [  XmlElement( ElementName = "WWPNotificationCreated"  , IsNullable=true )]
      public string gxTpr_Wwpnotificationcreated_Nullable
      {
         get {
            if ( gxTv_SdtWWP_Mail_Wwpnotificationcreated == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_Mail_Wwpnotificationcreated, null, true).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_Mail_Wwpnotificationcreated = DateTime.MinValue;
            else
               gxTv_SdtWWP_Mail_Wwpnotificationcreated = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Wwpnotificationcreated
      {
         get {
            return gxTv_SdtWWP_Mail_Wwpnotificationcreated ;
         }

         set {
            gxTv_SdtWWP_Mail_Wwpnotificationcreated = value;
            SetDirty("Wwpnotificationcreated");
         }

      }

      [  SoapElement( ElementName = "Attachments" )]
      [  XmlArray( ElementName = "Attachments"  )]
      [  XmlArrayItemAttribute( ElementName= "WWP_Mail.Attachments"  , IsNullable=false)]
      public GXBCLevelCollection<GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments> gxTpr_Attachments_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtWWP_Mail_Attachments == null )
            {
               gxTv_SdtWWP_Mail_Attachments = new GXBCLevelCollection<GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments>( context, "WWP_Mail.Attachments", "RastreamentoTCC");
            }
            return gxTv_SdtWWP_Mail_Attachments ;
         }

         set {
            if ( gxTv_SdtWWP_Mail_Attachments == null )
            {
               gxTv_SdtWWP_Mail_Attachments = new GXBCLevelCollection<GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments>( context, "WWP_Mail.Attachments", "RastreamentoTCC");
            }
            gxTv_SdtWWP_Mail_Attachments = value;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public GXBCLevelCollection<GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments> gxTpr_Attachments
      {
         get {
            if ( gxTv_SdtWWP_Mail_Attachments == null )
            {
               gxTv_SdtWWP_Mail_Attachments = new GXBCLevelCollection<GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments>( context, "WWP_Mail.Attachments", "RastreamentoTCC");
            }
            return gxTv_SdtWWP_Mail_Attachments ;
         }

         set {
            gxTv_SdtWWP_Mail_Attachments = value;
            SetDirty("Attachments");
         }

      }

      public void gxTv_SdtWWP_Mail_Attachments_SetNull( )
      {
         gxTv_SdtWWP_Mail_Attachments = null;
         return  ;
      }

      public bool gxTv_SdtWWP_Mail_Attachments_IsNull( )
      {
         if ( gxTv_SdtWWP_Mail_Attachments == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtWWP_Mail_Mode ;
         }

         set {
            gxTv_SdtWWP_Mail_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtWWP_Mail_Mode_SetNull( )
      {
         gxTv_SdtWWP_Mail_Mode = "";
         return  ;
      }

      public bool gxTv_SdtWWP_Mail_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtWWP_Mail_Initialized ;
         }

         set {
            gxTv_SdtWWP_Mail_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtWWP_Mail_Initialized_SetNull( )
      {
         gxTv_SdtWWP_Mail_Initialized = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_Mail_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPMailId_Z" )]
      [  XmlElement( ElementName = "WWPMailId_Z"   )]
      public long gxTpr_Wwpmailid_Z
      {
         get {
            return gxTv_SdtWWP_Mail_Wwpmailid_Z ;
         }

         set {
            gxTv_SdtWWP_Mail_Wwpmailid_Z = value;
            SetDirty("Wwpmailid_Z");
         }

      }

      public void gxTv_SdtWWP_Mail_Wwpmailid_Z_SetNull( )
      {
         gxTv_SdtWWP_Mail_Wwpmailid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_Mail_Wwpmailid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPMailSubject_Z" )]
      [  XmlElement( ElementName = "WWPMailSubject_Z"   )]
      public string gxTpr_Wwpmailsubject_Z
      {
         get {
            return gxTv_SdtWWP_Mail_Wwpmailsubject_Z ;
         }

         set {
            gxTv_SdtWWP_Mail_Wwpmailsubject_Z = value;
            SetDirty("Wwpmailsubject_Z");
         }

      }

      public void gxTv_SdtWWP_Mail_Wwpmailsubject_Z_SetNull( )
      {
         gxTv_SdtWWP_Mail_Wwpmailsubject_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_Mail_Wwpmailsubject_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPMailStatus_Z" )]
      [  XmlElement( ElementName = "WWPMailStatus_Z"   )]
      public short gxTpr_Wwpmailstatus_Z
      {
         get {
            return gxTv_SdtWWP_Mail_Wwpmailstatus_Z ;
         }

         set {
            gxTv_SdtWWP_Mail_Wwpmailstatus_Z = value;
            SetDirty("Wwpmailstatus_Z");
         }

      }

      public void gxTv_SdtWWP_Mail_Wwpmailstatus_Z_SetNull( )
      {
         gxTv_SdtWWP_Mail_Wwpmailstatus_Z = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_Mail_Wwpmailstatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPMailCreated_Z" )]
      [  XmlElement( ElementName = "WWPMailCreated_Z"  , IsNullable=true )]
      public string gxTpr_Wwpmailcreated_Z_Nullable
      {
         get {
            if ( gxTv_SdtWWP_Mail_Wwpmailcreated_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_Mail_Wwpmailcreated_Z, null, true).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_Mail_Wwpmailcreated_Z = DateTime.MinValue;
            else
               gxTv_SdtWWP_Mail_Wwpmailcreated_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Wwpmailcreated_Z
      {
         get {
            return gxTv_SdtWWP_Mail_Wwpmailcreated_Z ;
         }

         set {
            gxTv_SdtWWP_Mail_Wwpmailcreated_Z = value;
            SetDirty("Wwpmailcreated_Z");
         }

      }

      public void gxTv_SdtWWP_Mail_Wwpmailcreated_Z_SetNull( )
      {
         gxTv_SdtWWP_Mail_Wwpmailcreated_Z = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtWWP_Mail_Wwpmailcreated_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPMailScheduled_Z" )]
      [  XmlElement( ElementName = "WWPMailScheduled_Z"  , IsNullable=true )]
      public string gxTpr_Wwpmailscheduled_Z_Nullable
      {
         get {
            if ( gxTv_SdtWWP_Mail_Wwpmailscheduled_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_Mail_Wwpmailscheduled_Z, null, true).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_Mail_Wwpmailscheduled_Z = DateTime.MinValue;
            else
               gxTv_SdtWWP_Mail_Wwpmailscheduled_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Wwpmailscheduled_Z
      {
         get {
            return gxTv_SdtWWP_Mail_Wwpmailscheduled_Z ;
         }

         set {
            gxTv_SdtWWP_Mail_Wwpmailscheduled_Z = value;
            SetDirty("Wwpmailscheduled_Z");
         }

      }

      public void gxTv_SdtWWP_Mail_Wwpmailscheduled_Z_SetNull( )
      {
         gxTv_SdtWWP_Mail_Wwpmailscheduled_Z = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtWWP_Mail_Wwpmailscheduled_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPMailProcessed_Z" )]
      [  XmlElement( ElementName = "WWPMailProcessed_Z"  , IsNullable=true )]
      public string gxTpr_Wwpmailprocessed_Z_Nullable
      {
         get {
            if ( gxTv_SdtWWP_Mail_Wwpmailprocessed_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_Mail_Wwpmailprocessed_Z, null, true).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_Mail_Wwpmailprocessed_Z = DateTime.MinValue;
            else
               gxTv_SdtWWP_Mail_Wwpmailprocessed_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Wwpmailprocessed_Z
      {
         get {
            return gxTv_SdtWWP_Mail_Wwpmailprocessed_Z ;
         }

         set {
            gxTv_SdtWWP_Mail_Wwpmailprocessed_Z = value;
            SetDirty("Wwpmailprocessed_Z");
         }

      }

      public void gxTv_SdtWWP_Mail_Wwpmailprocessed_Z_SetNull( )
      {
         gxTv_SdtWWP_Mail_Wwpmailprocessed_Z = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtWWP_Mail_Wwpmailprocessed_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationId_Z" )]
      [  XmlElement( ElementName = "WWPNotificationId_Z"   )]
      public long gxTpr_Wwpnotificationid_Z
      {
         get {
            return gxTv_SdtWWP_Mail_Wwpnotificationid_Z ;
         }

         set {
            gxTv_SdtWWP_Mail_Wwpnotificationid_Z = value;
            SetDirty("Wwpnotificationid_Z");
         }

      }

      public void gxTv_SdtWWP_Mail_Wwpnotificationid_Z_SetNull( )
      {
         gxTv_SdtWWP_Mail_Wwpnotificationid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_Mail_Wwpnotificationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationCreated_Z" )]
      [  XmlElement( ElementName = "WWPNotificationCreated_Z"  , IsNullable=true )]
      public string gxTpr_Wwpnotificationcreated_Z_Nullable
      {
         get {
            if ( gxTv_SdtWWP_Mail_Wwpnotificationcreated_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_Mail_Wwpnotificationcreated_Z, null, true).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_Mail_Wwpnotificationcreated_Z = DateTime.MinValue;
            else
               gxTv_SdtWWP_Mail_Wwpnotificationcreated_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Wwpnotificationcreated_Z
      {
         get {
            return gxTv_SdtWWP_Mail_Wwpnotificationcreated_Z ;
         }

         set {
            gxTv_SdtWWP_Mail_Wwpnotificationcreated_Z = value;
            SetDirty("Wwpnotificationcreated_Z");
         }

      }

      public void gxTv_SdtWWP_Mail_Wwpnotificationcreated_Z_SetNull( )
      {
         gxTv_SdtWWP_Mail_Wwpnotificationcreated_Z = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtWWP_Mail_Wwpnotificationcreated_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPMailTo_N" )]
      [  XmlElement( ElementName = "WWPMailTo_N"   )]
      public short gxTpr_Wwpmailto_N
      {
         get {
            return gxTv_SdtWWP_Mail_Wwpmailto_N ;
         }

         set {
            gxTv_SdtWWP_Mail_Wwpmailto_N = value;
            SetDirty("Wwpmailto_N");
         }

      }

      public void gxTv_SdtWWP_Mail_Wwpmailto_N_SetNull( )
      {
         gxTv_SdtWWP_Mail_Wwpmailto_N = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_Mail_Wwpmailto_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPMailCC_N" )]
      [  XmlElement( ElementName = "WWPMailCC_N"   )]
      public short gxTpr_Wwpmailcc_N
      {
         get {
            return gxTv_SdtWWP_Mail_Wwpmailcc_N ;
         }

         set {
            gxTv_SdtWWP_Mail_Wwpmailcc_N = value;
            SetDirty("Wwpmailcc_N");
         }

      }

      public void gxTv_SdtWWP_Mail_Wwpmailcc_N_SetNull( )
      {
         gxTv_SdtWWP_Mail_Wwpmailcc_N = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_Mail_Wwpmailcc_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPMailBCC_N" )]
      [  XmlElement( ElementName = "WWPMailBCC_N"   )]
      public short gxTpr_Wwpmailbcc_N
      {
         get {
            return gxTv_SdtWWP_Mail_Wwpmailbcc_N ;
         }

         set {
            gxTv_SdtWWP_Mail_Wwpmailbcc_N = value;
            SetDirty("Wwpmailbcc_N");
         }

      }

      public void gxTv_SdtWWP_Mail_Wwpmailbcc_N_SetNull( )
      {
         gxTv_SdtWWP_Mail_Wwpmailbcc_N = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_Mail_Wwpmailbcc_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPMailProcessed_N" )]
      [  XmlElement( ElementName = "WWPMailProcessed_N"   )]
      public short gxTpr_Wwpmailprocessed_N
      {
         get {
            return gxTv_SdtWWP_Mail_Wwpmailprocessed_N ;
         }

         set {
            gxTv_SdtWWP_Mail_Wwpmailprocessed_N = value;
            SetDirty("Wwpmailprocessed_N");
         }

      }

      public void gxTv_SdtWWP_Mail_Wwpmailprocessed_N_SetNull( )
      {
         gxTv_SdtWWP_Mail_Wwpmailprocessed_N = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_Mail_Wwpmailprocessed_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPMailDetail_N" )]
      [  XmlElement( ElementName = "WWPMailDetail_N"   )]
      public short gxTpr_Wwpmaildetail_N
      {
         get {
            return gxTv_SdtWWP_Mail_Wwpmaildetail_N ;
         }

         set {
            gxTv_SdtWWP_Mail_Wwpmaildetail_N = value;
            SetDirty("Wwpmaildetail_N");
         }

      }

      public void gxTv_SdtWWP_Mail_Wwpmaildetail_N_SetNull( )
      {
         gxTv_SdtWWP_Mail_Wwpmaildetail_N = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_Mail_Wwpmaildetail_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationId_N" )]
      [  XmlElement( ElementName = "WWPNotificationId_N"   )]
      public short gxTpr_Wwpnotificationid_N
      {
         get {
            return gxTv_SdtWWP_Mail_Wwpnotificationid_N ;
         }

         set {
            gxTv_SdtWWP_Mail_Wwpnotificationid_N = value;
            SetDirty("Wwpnotificationid_N");
         }

      }

      public void gxTv_SdtWWP_Mail_Wwpnotificationid_N_SetNull( )
      {
         gxTv_SdtWWP_Mail_Wwpnotificationid_N = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_Mail_Wwpnotificationid_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtWWP_Mail_Wwpmailsubject = "";
         gxTv_SdtWWP_Mail_Wwpmailbody = "";
         gxTv_SdtWWP_Mail_Wwpmailto = "";
         gxTv_SdtWWP_Mail_Wwpmailcc = "";
         gxTv_SdtWWP_Mail_Wwpmailbcc = "";
         gxTv_SdtWWP_Mail_Wwpmailsenderaddress = "";
         gxTv_SdtWWP_Mail_Wwpmailsendername = "";
         gxTv_SdtWWP_Mail_Wwpmailcreated = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_Mail_Wwpmailscheduled = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_Mail_Wwpmailprocessed = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_Mail_Wwpmaildetail = "";
         gxTv_SdtWWP_Mail_Wwpnotificationcreated = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_Mail_Mode = "";
         gxTv_SdtWWP_Mail_Wwpmailsubject_Z = "";
         gxTv_SdtWWP_Mail_Wwpmailcreated_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_Mail_Wwpmailscheduled_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_Mail_Wwpmailprocessed_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_Mail_Wwpnotificationcreated_Z = (DateTime)(DateTime.MinValue);
         datetimemil_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "wwpbaseobjects.mail.wwp_mail", "GeneXus.Programs.wwpbaseobjects.mail.wwp_mail_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      private short gxTv_SdtWWP_Mail_Wwpmailstatus ;
      private short gxTv_SdtWWP_Mail_Initialized ;
      private short gxTv_SdtWWP_Mail_Wwpmailstatus_Z ;
      private short gxTv_SdtWWP_Mail_Wwpmailto_N ;
      private short gxTv_SdtWWP_Mail_Wwpmailcc_N ;
      private short gxTv_SdtWWP_Mail_Wwpmailbcc_N ;
      private short gxTv_SdtWWP_Mail_Wwpmailprocessed_N ;
      private short gxTv_SdtWWP_Mail_Wwpmaildetail_N ;
      private short gxTv_SdtWWP_Mail_Wwpnotificationid_N ;
      private long gxTv_SdtWWP_Mail_Wwpmailid ;
      private long gxTv_SdtWWP_Mail_Wwpnotificationid ;
      private long gxTv_SdtWWP_Mail_Wwpmailid_Z ;
      private long gxTv_SdtWWP_Mail_Wwpnotificationid_Z ;
      private string gxTv_SdtWWP_Mail_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtWWP_Mail_Wwpmailcreated ;
      private DateTime gxTv_SdtWWP_Mail_Wwpmailscheduled ;
      private DateTime gxTv_SdtWWP_Mail_Wwpmailprocessed ;
      private DateTime gxTv_SdtWWP_Mail_Wwpnotificationcreated ;
      private DateTime gxTv_SdtWWP_Mail_Wwpmailcreated_Z ;
      private DateTime gxTv_SdtWWP_Mail_Wwpmailscheduled_Z ;
      private DateTime gxTv_SdtWWP_Mail_Wwpmailprocessed_Z ;
      private DateTime gxTv_SdtWWP_Mail_Wwpnotificationcreated_Z ;
      private DateTime datetimemil_STZ ;
      private string gxTv_SdtWWP_Mail_Wwpmailbody ;
      private string gxTv_SdtWWP_Mail_Wwpmailto ;
      private string gxTv_SdtWWP_Mail_Wwpmailcc ;
      private string gxTv_SdtWWP_Mail_Wwpmailbcc ;
      private string gxTv_SdtWWP_Mail_Wwpmailsenderaddress ;
      private string gxTv_SdtWWP_Mail_Wwpmailsendername ;
      private string gxTv_SdtWWP_Mail_Wwpmaildetail ;
      private string gxTv_SdtWWP_Mail_Wwpmailsubject ;
      private string gxTv_SdtWWP_Mail_Wwpmailsubject_Z ;
      private GXBCLevelCollection<GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments> gxTv_SdtWWP_Mail_Attachments=null ;
   }

   [DataContract(Name = @"WWPBaseObjects\Mail\WWP_Mail", Namespace = "RastreamentoTCC")]
   public class SdtWWP_Mail_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWWP_Mail_RESTInterface( ) : base()
      {
      }

      public SdtWWP_Mail_RESTInterface( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WWPMailId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Wwpmailid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Wwpmailid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Wwpmailid = (long)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "WWPMailSubject" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Wwpmailsubject
      {
         get {
            return sdt.gxTpr_Wwpmailsubject ;
         }

         set {
            sdt.gxTpr_Wwpmailsubject = value;
         }

      }

      [DataMember( Name = "WWPMailBody" , Order = 2 )]
      public string gxTpr_Wwpmailbody
      {
         get {
            return sdt.gxTpr_Wwpmailbody ;
         }

         set {
            sdt.gxTpr_Wwpmailbody = value;
         }

      }

      [DataMember( Name = "WWPMailTo" , Order = 3 )]
      public string gxTpr_Wwpmailto
      {
         get {
            return sdt.gxTpr_Wwpmailto ;
         }

         set {
            sdt.gxTpr_Wwpmailto = value;
         }

      }

      [DataMember( Name = "WWPMailCC" , Order = 4 )]
      public string gxTpr_Wwpmailcc
      {
         get {
            return sdt.gxTpr_Wwpmailcc ;
         }

         set {
            sdt.gxTpr_Wwpmailcc = value;
         }

      }

      [DataMember( Name = "WWPMailBCC" , Order = 5 )]
      public string gxTpr_Wwpmailbcc
      {
         get {
            return sdt.gxTpr_Wwpmailbcc ;
         }

         set {
            sdt.gxTpr_Wwpmailbcc = value;
         }

      }

      [DataMember( Name = "WWPMailSenderAddress" , Order = 6 )]
      public string gxTpr_Wwpmailsenderaddress
      {
         get {
            return sdt.gxTpr_Wwpmailsenderaddress ;
         }

         set {
            sdt.gxTpr_Wwpmailsenderaddress = value;
         }

      }

      [DataMember( Name = "WWPMailSenderName" , Order = 7 )]
      public string gxTpr_Wwpmailsendername
      {
         get {
            return sdt.gxTpr_Wwpmailsendername ;
         }

         set {
            sdt.gxTpr_Wwpmailsendername = value;
         }

      }

      [DataMember( Name = "WWPMailStatus" , Order = 8 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Wwpmailstatus
      {
         get {
            return sdt.gxTpr_Wwpmailstatus ;
         }

         set {
            sdt.gxTpr_Wwpmailstatus = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPMailCreated" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Wwpmailcreated
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Wwpmailcreated) ;
         }

         set {
            sdt.gxTpr_Wwpmailcreated = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "WWPMailScheduled" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Wwpmailscheduled
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Wwpmailscheduled) ;
         }

         set {
            sdt.gxTpr_Wwpmailscheduled = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "WWPMailProcessed" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Wwpmailprocessed
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Wwpmailprocessed) ;
         }

         set {
            sdt.gxTpr_Wwpmailprocessed = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "WWPMailDetail" , Order = 12 )]
      public string gxTpr_Wwpmaildetail
      {
         get {
            return sdt.gxTpr_Wwpmaildetail ;
         }

         set {
            sdt.gxTpr_Wwpmaildetail = value;
         }

      }

      [DataMember( Name = "WWPNotificationId" , Order = 13 )]
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

      [DataMember( Name = "WWPNotificationCreated" , Order = 14 )]
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

      [DataMember( Name = "Attachments" , Order = 15 )]
      public GxGenericCollection<GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments_RESTInterface> gxTpr_Attachments
      {
         get {
            return new GxGenericCollection<GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments_RESTInterface>(sdt.gxTpr_Attachments) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Attachments);
         }

      }

      public GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail() ;
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

   [DataContract(Name = @"WWPBaseObjects\Mail\WWP_Mail", Namespace = "RastreamentoTCC")]
   public class SdtWWP_Mail_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWWP_Mail_RESTLInterface( ) : base()
      {
      }

      public SdtWWP_Mail_RESTLInterface( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WWPMailSubject" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Wwpmailsubject
      {
         get {
            return sdt.gxTpr_Wwpmailsubject ;
         }

         set {
            sdt.gxTpr_Wwpmailsubject = value;
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

      public GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail() ;
         }
      }

   }

}
