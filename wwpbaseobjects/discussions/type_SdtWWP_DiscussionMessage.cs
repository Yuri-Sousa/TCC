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
namespace GeneXus.Programs.wwpbaseobjects.discussions {
   [XmlSerializerFormat]
   [XmlRoot(ElementName = "WWP_DiscussionMessage" )]
   [XmlType(TypeName =  "WWP_DiscussionMessage" , Namespace = "RastreamentoTCC" )]
   [Serializable]
   public class SdtWWP_DiscussionMessage : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWWP_DiscussionMessage( )
      {
      }

      public SdtWWP_DiscussionMessage( IGxContext context )
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

      public void Load( long AV83WWPDiscussionMessageId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(long)AV83WWPDiscussionMessageId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"WWPDiscussionMessageId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "WWPBaseObjects\\Discussions\\WWP_DiscussionMessage");
         metadata.Set("BT", "WWP_DiscussionMessage");
         metadata.Set("PK", "[ \"WWPDiscussionMessageId\" ]");
         metadata.Set("PKAssigned", "[ \"WWPDiscussionMessageId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"WWPDiscussionMessageId\" ],\"FKMap\":[ \"WWPDiscussionMessageThreadId-WWPDiscussionMessageId\" ] },{ \"FK\":[ \"WWPEntityId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"WWPUserExtendedId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Wwpuserextendedphoto_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Wwpdiscussionmessageid_Z");
         state.Add("gxTpr_Wwpdiscussionmessagedate_Z_Nullable");
         state.Add("gxTpr_Wwpdiscussionmessagethreadid_Z");
         state.Add("gxTpr_Wwpdiscussionmessagemessage_Z");
         state.Add("gxTpr_Wwpuserextendedid_Z");
         state.Add("gxTpr_Wwpuserextendedfullname_Z");
         state.Add("gxTpr_Wwpentityid_Z");
         state.Add("gxTpr_Wwpentityname_Z");
         state.Add("gxTpr_Wwpdiscussionmessageentityrecordid_Z");
         state.Add("gxTpr_Wwpuserextendedphoto_gxi_Z");
         state.Add("gxTpr_Wwpdiscussionmessagethreadid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage sdt;
         sdt = (GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage)(source);
         gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageid = sdt.gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageid ;
         gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagedate = sdt.gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagedate ;
         gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid = sdt.gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid ;
         gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagemessage = sdt.gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagemessage ;
         gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedid = sdt.gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedid ;
         gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedphoto = sdt.gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedphoto ;
         gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedphoto_gxi = sdt.gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedphoto_gxi ;
         gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedfullname = sdt.gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedfullname ;
         gxTv_SdtWWP_DiscussionMessage_Wwpentityid = sdt.gxTv_SdtWWP_DiscussionMessage_Wwpentityid ;
         gxTv_SdtWWP_DiscussionMessage_Wwpentityname = sdt.gxTv_SdtWWP_DiscussionMessage_Wwpentityname ;
         gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageentityrecordid = sdt.gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageentityrecordid ;
         gxTv_SdtWWP_DiscussionMessage_Mode = sdt.gxTv_SdtWWP_DiscussionMessage_Mode ;
         gxTv_SdtWWP_DiscussionMessage_Initialized = sdt.gxTv_SdtWWP_DiscussionMessage_Initialized ;
         gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageid_Z = sdt.gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageid_Z ;
         gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagedate_Z = sdt.gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagedate_Z ;
         gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid_Z = sdt.gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid_Z ;
         gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagemessage_Z = sdt.gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagemessage_Z ;
         gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedid_Z = sdt.gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedid_Z ;
         gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedfullname_Z = sdt.gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedfullname_Z ;
         gxTv_SdtWWP_DiscussionMessage_Wwpentityid_Z = sdt.gxTv_SdtWWP_DiscussionMessage_Wwpentityid_Z ;
         gxTv_SdtWWP_DiscussionMessage_Wwpentityname_Z = sdt.gxTv_SdtWWP_DiscussionMessage_Wwpentityname_Z ;
         gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageentityrecordid_Z = sdt.gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageentityrecordid_Z ;
         gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedphoto_gxi_Z = sdt.gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedphoto_gxi_Z ;
         gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid_N = sdt.gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid_N ;
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
         AddObjectProperty("WWPDiscussionMessageId", gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageid, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagedate;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("WWPDiscussionMessageDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("WWPDiscussionMessageThreadId", gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid, false, includeNonInitialized);
         AddObjectProperty("WWPDiscussionMessageThreadId_N", gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid_N, false, includeNonInitialized);
         AddObjectProperty("WWPDiscussionMessageMessage", gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagemessage, false, includeNonInitialized);
         AddObjectProperty("WWPUserExtendedId", gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedid, false, includeNonInitialized);
         AddObjectProperty("WWPUserExtendedPhoto", gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedphoto, false, includeNonInitialized);
         AddObjectProperty("WWPUserExtendedFullName", gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedfullname, false, includeNonInitialized);
         AddObjectProperty("WWPEntityId", gxTv_SdtWWP_DiscussionMessage_Wwpentityid, false, includeNonInitialized);
         AddObjectProperty("WWPEntityName", gxTv_SdtWWP_DiscussionMessage_Wwpentityname, false, includeNonInitialized);
         AddObjectProperty("WWPDiscussionMessageEntityRecordId", gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageentityrecordid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("WWPUserExtendedPhoto_GXI", gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedphoto_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtWWP_DiscussionMessage_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtWWP_DiscussionMessage_Initialized, false, includeNonInitialized);
            AddObjectProperty("WWPDiscussionMessageId_Z", gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageid_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagedate_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("WWPDiscussionMessageDate_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("WWPDiscussionMessageThreadId_Z", gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPDiscussionMessageMessage_Z", gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagemessage_Z, false, includeNonInitialized);
            AddObjectProperty("WWPUserExtendedId_Z", gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPUserExtendedFullName_Z", gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedfullname_Z, false, includeNonInitialized);
            AddObjectProperty("WWPEntityId_Z", gxTv_SdtWWP_DiscussionMessage_Wwpentityid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPEntityName_Z", gxTv_SdtWWP_DiscussionMessage_Wwpentityname_Z, false, includeNonInitialized);
            AddObjectProperty("WWPDiscussionMessageEntityRecordId_Z", gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageentityrecordid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPUserExtendedPhoto_GXI_Z", gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedphoto_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("WWPDiscussionMessageThreadId_N", gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage sdt )
      {
         if ( sdt.IsDirty("WWPDiscussionMessageId") )
         {
            gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageid = sdt.gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageid ;
         }
         if ( sdt.IsDirty("WWPDiscussionMessageDate") )
         {
            gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagedate = sdt.gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagedate ;
         }
         if ( sdt.IsDirty("WWPDiscussionMessageThreadId") )
         {
            gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid_N = 0;
            gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid = sdt.gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid ;
         }
         if ( sdt.IsDirty("WWPDiscussionMessageMessage") )
         {
            gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagemessage = sdt.gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagemessage ;
         }
         if ( sdt.IsDirty("WWPUserExtendedId") )
         {
            gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedid = sdt.gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedid ;
         }
         if ( sdt.IsDirty("WWPUserExtendedPhoto") )
         {
            gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedphoto = sdt.gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedphoto ;
         }
         if ( sdt.IsDirty("WWPUserExtendedPhoto") )
         {
            gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedphoto_gxi = sdt.gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedphoto_gxi ;
         }
         if ( sdt.IsDirty("WWPUserExtendedFullName") )
         {
            gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedfullname = sdt.gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedfullname ;
         }
         if ( sdt.IsDirty("WWPEntityId") )
         {
            gxTv_SdtWWP_DiscussionMessage_Wwpentityid = sdt.gxTv_SdtWWP_DiscussionMessage_Wwpentityid ;
         }
         if ( sdt.IsDirty("WWPEntityName") )
         {
            gxTv_SdtWWP_DiscussionMessage_Wwpentityname = sdt.gxTv_SdtWWP_DiscussionMessage_Wwpentityname ;
         }
         if ( sdt.IsDirty("WWPDiscussionMessageEntityRecordId") )
         {
            gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageentityrecordid = sdt.gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageentityrecordid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "WWPDiscussionMessageId" )]
      [  XmlElement( ElementName = "WWPDiscussionMessageId"   )]
      public long gxTpr_Wwpdiscussionmessageid
      {
         get {
            return gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageid ;
         }

         set {
            if ( gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageid != value )
            {
               gxTv_SdtWWP_DiscussionMessage_Mode = "INS";
               this.gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageid_Z_SetNull( );
               this.gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagedate_Z_SetNull( );
               this.gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid_Z_SetNull( );
               this.gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagemessage_Z_SetNull( );
               this.gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedid_Z_SetNull( );
               this.gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedfullname_Z_SetNull( );
               this.gxTv_SdtWWP_DiscussionMessage_Wwpentityid_Z_SetNull( );
               this.gxTv_SdtWWP_DiscussionMessage_Wwpentityname_Z_SetNull( );
               this.gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageentityrecordid_Z_SetNull( );
               this.gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedphoto_gxi_Z_SetNull( );
            }
            gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageid = value;
            SetDirty("Wwpdiscussionmessageid");
         }

      }

      [  SoapElement( ElementName = "WWPDiscussionMessageDate" )]
      [  XmlElement( ElementName = "WWPDiscussionMessageDate"  , IsNullable=true )]
      public string gxTpr_Wwpdiscussionmessagedate_Nullable
      {
         get {
            if ( gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagedate == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagedate).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagedate = DateTime.MinValue;
            else
               gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagedate = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Wwpdiscussionmessagedate
      {
         get {
            return gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagedate ;
         }

         set {
            gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagedate = value;
            SetDirty("Wwpdiscussionmessagedate");
         }

      }

      [  SoapElement( ElementName = "WWPDiscussionMessageThreadId" )]
      [  XmlElement( ElementName = "WWPDiscussionMessageThreadId"   )]
      public long gxTpr_Wwpdiscussionmessagethreadid
      {
         get {
            return gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid ;
         }

         set {
            gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid_N = 0;
            gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid = value;
            SetDirty("Wwpdiscussionmessagethreadid");
         }

      }

      public void gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid_SetNull( )
      {
         gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid_N = 1;
         gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid_IsNull( )
      {
         return (gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid_N==1) ;
      }

      [  SoapElement( ElementName = "WWPDiscussionMessageMessage" )]
      [  XmlElement( ElementName = "WWPDiscussionMessageMessage"   )]
      public string gxTpr_Wwpdiscussionmessagemessage
      {
         get {
            return gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagemessage ;
         }

         set {
            gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagemessage = value;
            SetDirty("Wwpdiscussionmessagemessage");
         }

      }

      [  SoapElement( ElementName = "WWPUserExtendedId" )]
      [  XmlElement( ElementName = "WWPUserExtendedId"   )]
      public string gxTpr_Wwpuserextendedid
      {
         get {
            return gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedid ;
         }

         set {
            gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedid = value;
            SetDirty("Wwpuserextendedid");
         }

      }

      [  SoapElement( ElementName = "WWPUserExtendedPhoto" )]
      [  XmlElement( ElementName = "WWPUserExtendedPhoto"   )]
      [GxUpload()]
      public string gxTpr_Wwpuserextendedphoto
      {
         get {
            return gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedphoto ;
         }

         set {
            gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedphoto = value;
            SetDirty("Wwpuserextendedphoto");
         }

      }

      [  SoapElement( ElementName = "WWPUserExtendedPhoto_GXI" )]
      [  XmlElement( ElementName = "WWPUserExtendedPhoto_GXI"   )]
      public string gxTpr_Wwpuserextendedphoto_gxi
      {
         get {
            return gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedphoto_gxi ;
         }

         set {
            gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedphoto_gxi = value;
            SetDirty("Wwpuserextendedphoto_gxi");
         }

      }

      [  SoapElement( ElementName = "WWPUserExtendedFullName" )]
      [  XmlElement( ElementName = "WWPUserExtendedFullName"   )]
      public string gxTpr_Wwpuserextendedfullname
      {
         get {
            return gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedfullname ;
         }

         set {
            gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedfullname = value;
            SetDirty("Wwpuserextendedfullname");
         }

      }

      public void gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedfullname_SetNull( )
      {
         gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedfullname = "";
         return  ;
      }

      public bool gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedfullname_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPEntityId" )]
      [  XmlElement( ElementName = "WWPEntityId"   )]
      public long gxTpr_Wwpentityid
      {
         get {
            return gxTv_SdtWWP_DiscussionMessage_Wwpentityid ;
         }

         set {
            gxTv_SdtWWP_DiscussionMessage_Wwpentityid = value;
            SetDirty("Wwpentityid");
         }

      }

      [  SoapElement( ElementName = "WWPEntityName" )]
      [  XmlElement( ElementName = "WWPEntityName"   )]
      public string gxTpr_Wwpentityname
      {
         get {
            return gxTv_SdtWWP_DiscussionMessage_Wwpentityname ;
         }

         set {
            gxTv_SdtWWP_DiscussionMessage_Wwpentityname = value;
            SetDirty("Wwpentityname");
         }

      }

      [  SoapElement( ElementName = "WWPDiscussionMessageEntityRecordId" )]
      [  XmlElement( ElementName = "WWPDiscussionMessageEntityRecordId"   )]
      public string gxTpr_Wwpdiscussionmessageentityrecordid
      {
         get {
            return gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageentityrecordid ;
         }

         set {
            gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageentityrecordid = value;
            SetDirty("Wwpdiscussionmessageentityrecordid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtWWP_DiscussionMessage_Mode ;
         }

         set {
            gxTv_SdtWWP_DiscussionMessage_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtWWP_DiscussionMessage_Mode_SetNull( )
      {
         gxTv_SdtWWP_DiscussionMessage_Mode = "";
         return  ;
      }

      public bool gxTv_SdtWWP_DiscussionMessage_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtWWP_DiscussionMessage_Initialized ;
         }

         set {
            gxTv_SdtWWP_DiscussionMessage_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtWWP_DiscussionMessage_Initialized_SetNull( )
      {
         gxTv_SdtWWP_DiscussionMessage_Initialized = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_DiscussionMessage_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPDiscussionMessageId_Z" )]
      [  XmlElement( ElementName = "WWPDiscussionMessageId_Z"   )]
      public long gxTpr_Wwpdiscussionmessageid_Z
      {
         get {
            return gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageid_Z ;
         }

         set {
            gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageid_Z = value;
            SetDirty("Wwpdiscussionmessageid_Z");
         }

      }

      public void gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageid_Z_SetNull( )
      {
         gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPDiscussionMessageDate_Z" )]
      [  XmlElement( ElementName = "WWPDiscussionMessageDate_Z"  , IsNullable=true )]
      public string gxTpr_Wwpdiscussionmessagedate_Z_Nullable
      {
         get {
            if ( gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagedate_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagedate_Z).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagedate_Z = DateTime.MinValue;
            else
               gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagedate_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Wwpdiscussionmessagedate_Z
      {
         get {
            return gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagedate_Z ;
         }

         set {
            gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagedate_Z = value;
            SetDirty("Wwpdiscussionmessagedate_Z");
         }

      }

      public void gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagedate_Z_SetNull( )
      {
         gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagedate_Z = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagedate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPDiscussionMessageThreadId_Z" )]
      [  XmlElement( ElementName = "WWPDiscussionMessageThreadId_Z"   )]
      public long gxTpr_Wwpdiscussionmessagethreadid_Z
      {
         get {
            return gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid_Z ;
         }

         set {
            gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid_Z = value;
            SetDirty("Wwpdiscussionmessagethreadid_Z");
         }

      }

      public void gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid_Z_SetNull( )
      {
         gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPDiscussionMessageMessage_Z" )]
      [  XmlElement( ElementName = "WWPDiscussionMessageMessage_Z"   )]
      public string gxTpr_Wwpdiscussionmessagemessage_Z
      {
         get {
            return gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagemessage_Z ;
         }

         set {
            gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagemessage_Z = value;
            SetDirty("Wwpdiscussionmessagemessage_Z");
         }

      }

      public void gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagemessage_Z_SetNull( )
      {
         gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagemessage_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagemessage_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPUserExtendedId_Z" )]
      [  XmlElement( ElementName = "WWPUserExtendedId_Z"   )]
      public string gxTpr_Wwpuserextendedid_Z
      {
         get {
            return gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedid_Z ;
         }

         set {
            gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedid_Z = value;
            SetDirty("Wwpuserextendedid_Z");
         }

      }

      public void gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedid_Z_SetNull( )
      {
         gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedid_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPUserExtendedFullName_Z" )]
      [  XmlElement( ElementName = "WWPUserExtendedFullName_Z"   )]
      public string gxTpr_Wwpuserextendedfullname_Z
      {
         get {
            return gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedfullname_Z ;
         }

         set {
            gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedfullname_Z = value;
            SetDirty("Wwpuserextendedfullname_Z");
         }

      }

      public void gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedfullname_Z_SetNull( )
      {
         gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedfullname_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedfullname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPEntityId_Z" )]
      [  XmlElement( ElementName = "WWPEntityId_Z"   )]
      public long gxTpr_Wwpentityid_Z
      {
         get {
            return gxTv_SdtWWP_DiscussionMessage_Wwpentityid_Z ;
         }

         set {
            gxTv_SdtWWP_DiscussionMessage_Wwpentityid_Z = value;
            SetDirty("Wwpentityid_Z");
         }

      }

      public void gxTv_SdtWWP_DiscussionMessage_Wwpentityid_Z_SetNull( )
      {
         gxTv_SdtWWP_DiscussionMessage_Wwpentityid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_DiscussionMessage_Wwpentityid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPEntityName_Z" )]
      [  XmlElement( ElementName = "WWPEntityName_Z"   )]
      public string gxTpr_Wwpentityname_Z
      {
         get {
            return gxTv_SdtWWP_DiscussionMessage_Wwpentityname_Z ;
         }

         set {
            gxTv_SdtWWP_DiscussionMessage_Wwpentityname_Z = value;
            SetDirty("Wwpentityname_Z");
         }

      }

      public void gxTv_SdtWWP_DiscussionMessage_Wwpentityname_Z_SetNull( )
      {
         gxTv_SdtWWP_DiscussionMessage_Wwpentityname_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_DiscussionMessage_Wwpentityname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPDiscussionMessageEntityRecordId_Z" )]
      [  XmlElement( ElementName = "WWPDiscussionMessageEntityRecordId_Z"   )]
      public string gxTpr_Wwpdiscussionmessageentityrecordid_Z
      {
         get {
            return gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageentityrecordid_Z ;
         }

         set {
            gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageentityrecordid_Z = value;
            SetDirty("Wwpdiscussionmessageentityrecordid_Z");
         }

      }

      public void gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageentityrecordid_Z_SetNull( )
      {
         gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageentityrecordid_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageentityrecordid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPUserExtendedPhoto_GXI_Z" )]
      [  XmlElement( ElementName = "WWPUserExtendedPhoto_GXI_Z"   )]
      public string gxTpr_Wwpuserextendedphoto_gxi_Z
      {
         get {
            return gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedphoto_gxi_Z ;
         }

         set {
            gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedphoto_gxi_Z = value;
            SetDirty("Wwpuserextendedphoto_gxi_Z");
         }

      }

      public void gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedphoto_gxi_Z_SetNull( )
      {
         gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedphoto_gxi_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedphoto_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPDiscussionMessageThreadId_N" )]
      [  XmlElement( ElementName = "WWPDiscussionMessageThreadId_N"   )]
      public short gxTpr_Wwpdiscussionmessagethreadid_N
      {
         get {
            return gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid_N ;
         }

         set {
            gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid_N = value;
            SetDirty("Wwpdiscussionmessagethreadid_N");
         }

      }

      public void gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid_N_SetNull( )
      {
         gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid_N = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagedate = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagemessage = "";
         gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedid = "";
         gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedphoto = "";
         gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedphoto_gxi = "";
         gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedfullname = "";
         gxTv_SdtWWP_DiscussionMessage_Wwpentityname = "";
         gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageentityrecordid = "";
         gxTv_SdtWWP_DiscussionMessage_Mode = "";
         gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagedate_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagemessage_Z = "";
         gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedid_Z = "";
         gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedfullname_Z = "";
         gxTv_SdtWWP_DiscussionMessage_Wwpentityname_Z = "";
         gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageentityrecordid_Z = "";
         gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedphoto_gxi_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "wwpbaseobjects.discussions.wwp_discussionmessage", "GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionmessage_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      private short gxTv_SdtWWP_DiscussionMessage_Initialized ;
      private short gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid_N ;
      private long gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageid ;
      private long gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid ;
      private long gxTv_SdtWWP_DiscussionMessage_Wwpentityid ;
      private long gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageid_Z ;
      private long gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagethreadid_Z ;
      private long gxTv_SdtWWP_DiscussionMessage_Wwpentityid_Z ;
      private string gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedid ;
      private string gxTv_SdtWWP_DiscussionMessage_Mode ;
      private string gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedid_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagedate ;
      private DateTime gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagedate_Z ;
      private DateTime datetime_STZ ;
      private string gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagemessage ;
      private string gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedphoto_gxi ;
      private string gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedfullname ;
      private string gxTv_SdtWWP_DiscussionMessage_Wwpentityname ;
      private string gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageentityrecordid ;
      private string gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessagemessage_Z ;
      private string gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedfullname_Z ;
      private string gxTv_SdtWWP_DiscussionMessage_Wwpentityname_Z ;
      private string gxTv_SdtWWP_DiscussionMessage_Wwpdiscussionmessageentityrecordid_Z ;
      private string gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedphoto_gxi_Z ;
      private string gxTv_SdtWWP_DiscussionMessage_Wwpuserextendedphoto ;
   }

   [DataContract(Name = @"WWPBaseObjects\Discussions\WWP_DiscussionMessage", Namespace = "RastreamentoTCC")]
   public class SdtWWP_DiscussionMessage_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWWP_DiscussionMessage_RESTInterface( ) : base()
      {
      }

      public SdtWWP_DiscussionMessage_RESTInterface( GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WWPDiscussionMessageId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Wwpdiscussionmessageid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Wwpdiscussionmessageid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Wwpdiscussionmessageid = (long)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "WWPDiscussionMessageDate" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Wwpdiscussionmessagedate
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Wwpdiscussionmessagedate) ;
         }

         set {
            sdt.gxTpr_Wwpdiscussionmessagedate = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "WWPDiscussionMessageThreadId" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Wwpdiscussionmessagethreadid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Wwpdiscussionmessagethreadid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Wwpdiscussionmessagethreadid = (long)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "WWPDiscussionMessageMessage" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Wwpdiscussionmessagemessage
      {
         get {
            return sdt.gxTpr_Wwpdiscussionmessagemessage ;
         }

         set {
            sdt.gxTpr_Wwpdiscussionmessagemessage = value;
         }

      }

      [DataMember( Name = "WWPUserExtendedId" , Order = 4 )]
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

      [DataMember( Name = "WWPUserExtendedPhoto" , Order = 5 )]
      [GxUpload()]
      public string gxTpr_Wwpuserextendedphoto
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Wwpuserextendedphoto)) ? PathUtil.RelativeURL( sdt.gxTpr_Wwpuserextendedphoto) : StringUtil.RTrim( sdt.gxTpr_Wwpuserextendedphoto_gxi)) ;
         }

         set {
            sdt.gxTpr_Wwpuserextendedphoto = value;
         }

      }

      [DataMember( Name = "WWPUserExtendedFullName" , Order = 6 )]
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

      [DataMember( Name = "WWPEntityId" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Wwpentityid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Wwpentityid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Wwpentityid = (long)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "WWPEntityName" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Wwpentityname
      {
         get {
            return sdt.gxTpr_Wwpentityname ;
         }

         set {
            sdt.gxTpr_Wwpentityname = value;
         }

      }

      [DataMember( Name = "WWPDiscussionMessageEntityRecordId" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Wwpdiscussionmessageentityrecordid
      {
         get {
            return sdt.gxTpr_Wwpdiscussionmessageentityrecordid ;
         }

         set {
            sdt.gxTpr_Wwpdiscussionmessageentityrecordid = value;
         }

      }

      public GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 10 )]
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

   [DataContract(Name = @"WWPBaseObjects\Discussions\WWP_DiscussionMessage", Namespace = "RastreamentoTCC")]
   public class SdtWWP_DiscussionMessage_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWWP_DiscussionMessage_RESTLInterface( ) : base()
      {
      }

      public SdtWWP_DiscussionMessage_RESTLInterface( GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WWPDiscussionMessageDate" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Wwpdiscussionmessagedate
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Wwpdiscussionmessagedate) ;
         }

         set {
            sdt.gxTpr_Wwpdiscussionmessagedate = DateTimeUtil.CToT2( value);
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

      public GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage() ;
         }
      }

   }

}
