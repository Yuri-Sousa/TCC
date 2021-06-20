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
namespace GeneXus.Programs.wwpbaseobjects.subscriptions {
   [XmlSerializerFormat]
   [XmlRoot(ElementName = "WWP_Subscription" )]
   [XmlType(TypeName =  "WWP_Subscription" , Namespace = "RastreamentoTCC" )]
   [Serializable]
   public class SdtWWP_Subscription : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWWP_Subscription( )
      {
      }

      public SdtWWP_Subscription( IGxContext context )
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

      public void Load( long AV13WWPSubscriptionId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(long)AV13WWPSubscriptionId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"WWPSubscriptionId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "WWPBaseObjects\\Subscriptions\\WWP_Subscription");
         metadata.Set("BT", "WWP_Subscription");
         metadata.Set("PK", "[ \"WWPSubscriptionId\" ]");
         metadata.Set("PKAssigned", "[ \"WWPSubscriptionId\" ]");
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
         state.Add("gxTpr_Wwpsubscriptionid_Z");
         state.Add("gxTpr_Wwpnotificationdefinitionid_Z");
         state.Add("gxTpr_Wwpnotificationdefinitiondescription_Z");
         state.Add("gxTpr_Wwpentityname_Z");
         state.Add("gxTpr_Wwpuserextendedid_Z");
         state.Add("gxTpr_Wwpuserextendedfullname_Z");
         state.Add("gxTpr_Wwpsubscriptionentityrecordid_Z");
         state.Add("gxTpr_Wwpsubscriptionentityrecorddescription_Z");
         state.Add("gxTpr_Wwpsubscriptionroleid_Z");
         state.Add("gxTpr_Wwpsubscriptionsubscribed_Z");
         state.Add("gxTpr_Wwpuserextendedid_N");
         state.Add("gxTpr_Wwpsubscriptionroleid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription sdt;
         sdt = (GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription)(source);
         gxTv_SdtWWP_Subscription_Wwpsubscriptionid = sdt.gxTv_SdtWWP_Subscription_Wwpsubscriptionid ;
         gxTv_SdtWWP_Subscription_Wwpnotificationdefinitionid = sdt.gxTv_SdtWWP_Subscription_Wwpnotificationdefinitionid ;
         gxTv_SdtWWP_Subscription_Wwpnotificationdefinitiondescription = sdt.gxTv_SdtWWP_Subscription_Wwpnotificationdefinitiondescription ;
         gxTv_SdtWWP_Subscription_Wwpentityname = sdt.gxTv_SdtWWP_Subscription_Wwpentityname ;
         gxTv_SdtWWP_Subscription_Wwpuserextendedid = sdt.gxTv_SdtWWP_Subscription_Wwpuserextendedid ;
         gxTv_SdtWWP_Subscription_Wwpuserextendedfullname = sdt.gxTv_SdtWWP_Subscription_Wwpuserextendedfullname ;
         gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecordid = sdt.gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecordid ;
         gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecorddescription = sdt.gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecorddescription ;
         gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid = sdt.gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid ;
         gxTv_SdtWWP_Subscription_Wwpsubscriptionsubscribed = sdt.gxTv_SdtWWP_Subscription_Wwpsubscriptionsubscribed ;
         gxTv_SdtWWP_Subscription_Mode = sdt.gxTv_SdtWWP_Subscription_Mode ;
         gxTv_SdtWWP_Subscription_Initialized = sdt.gxTv_SdtWWP_Subscription_Initialized ;
         gxTv_SdtWWP_Subscription_Wwpsubscriptionid_Z = sdt.gxTv_SdtWWP_Subscription_Wwpsubscriptionid_Z ;
         gxTv_SdtWWP_Subscription_Wwpnotificationdefinitionid_Z = sdt.gxTv_SdtWWP_Subscription_Wwpnotificationdefinitionid_Z ;
         gxTv_SdtWWP_Subscription_Wwpnotificationdefinitiondescription_Z = sdt.gxTv_SdtWWP_Subscription_Wwpnotificationdefinitiondescription_Z ;
         gxTv_SdtWWP_Subscription_Wwpentityname_Z = sdt.gxTv_SdtWWP_Subscription_Wwpentityname_Z ;
         gxTv_SdtWWP_Subscription_Wwpuserextendedid_Z = sdt.gxTv_SdtWWP_Subscription_Wwpuserextendedid_Z ;
         gxTv_SdtWWP_Subscription_Wwpuserextendedfullname_Z = sdt.gxTv_SdtWWP_Subscription_Wwpuserextendedfullname_Z ;
         gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecordid_Z = sdt.gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecordid_Z ;
         gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecorddescription_Z = sdt.gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecorddescription_Z ;
         gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid_Z = sdt.gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid_Z ;
         gxTv_SdtWWP_Subscription_Wwpsubscriptionsubscribed_Z = sdt.gxTv_SdtWWP_Subscription_Wwpsubscriptionsubscribed_Z ;
         gxTv_SdtWWP_Subscription_Wwpuserextendedid_N = sdt.gxTv_SdtWWP_Subscription_Wwpuserextendedid_N ;
         gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid_N = sdt.gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid_N ;
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
         AddObjectProperty("WWPSubscriptionId", gxTv_SdtWWP_Subscription_Wwpsubscriptionid, false, includeNonInitialized);
         AddObjectProperty("WWPNotificationDefinitionId", gxTv_SdtWWP_Subscription_Wwpnotificationdefinitionid, false, includeNonInitialized);
         AddObjectProperty("WWPNotificationDefinitionDescription", gxTv_SdtWWP_Subscription_Wwpnotificationdefinitiondescription, false, includeNonInitialized);
         AddObjectProperty("WWPEntityName", gxTv_SdtWWP_Subscription_Wwpentityname, false, includeNonInitialized);
         AddObjectProperty("WWPUserExtendedId", gxTv_SdtWWP_Subscription_Wwpuserextendedid, false, includeNonInitialized);
         AddObjectProperty("WWPUserExtendedId_N", gxTv_SdtWWP_Subscription_Wwpuserextendedid_N, false, includeNonInitialized);
         AddObjectProperty("WWPUserExtendedFullName", gxTv_SdtWWP_Subscription_Wwpuserextendedfullname, false, includeNonInitialized);
         AddObjectProperty("WWPSubscriptionEntityRecordId", gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecordid, false, includeNonInitialized);
         AddObjectProperty("WWPSubscriptionEntityRecordDescription", gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecorddescription, false, includeNonInitialized);
         AddObjectProperty("WWPSubscriptionRoleId", gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid, false, includeNonInitialized);
         AddObjectProperty("WWPSubscriptionRoleId_N", gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid_N, false, includeNonInitialized);
         AddObjectProperty("WWPSubscriptionSubscribed", gxTv_SdtWWP_Subscription_Wwpsubscriptionsubscribed, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtWWP_Subscription_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtWWP_Subscription_Initialized, false, includeNonInitialized);
            AddObjectProperty("WWPSubscriptionId_Z", gxTv_SdtWWP_Subscription_Wwpsubscriptionid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPNotificationDefinitionId_Z", gxTv_SdtWWP_Subscription_Wwpnotificationdefinitionid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPNotificationDefinitionDescription_Z", gxTv_SdtWWP_Subscription_Wwpnotificationdefinitiondescription_Z, false, includeNonInitialized);
            AddObjectProperty("WWPEntityName_Z", gxTv_SdtWWP_Subscription_Wwpentityname_Z, false, includeNonInitialized);
            AddObjectProperty("WWPUserExtendedId_Z", gxTv_SdtWWP_Subscription_Wwpuserextendedid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPUserExtendedFullName_Z", gxTv_SdtWWP_Subscription_Wwpuserextendedfullname_Z, false, includeNonInitialized);
            AddObjectProperty("WWPSubscriptionEntityRecordId_Z", gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecordid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPSubscriptionEntityRecordDescription_Z", gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecorddescription_Z, false, includeNonInitialized);
            AddObjectProperty("WWPSubscriptionRoleId_Z", gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPSubscriptionSubscribed_Z", gxTv_SdtWWP_Subscription_Wwpsubscriptionsubscribed_Z, false, includeNonInitialized);
            AddObjectProperty("WWPUserExtendedId_N", gxTv_SdtWWP_Subscription_Wwpuserextendedid_N, false, includeNonInitialized);
            AddObjectProperty("WWPSubscriptionRoleId_N", gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription sdt )
      {
         if ( sdt.IsDirty("WWPSubscriptionId") )
         {
            gxTv_SdtWWP_Subscription_Wwpsubscriptionid = sdt.gxTv_SdtWWP_Subscription_Wwpsubscriptionid ;
         }
         if ( sdt.IsDirty("WWPNotificationDefinitionId") )
         {
            gxTv_SdtWWP_Subscription_Wwpnotificationdefinitionid = sdt.gxTv_SdtWWP_Subscription_Wwpnotificationdefinitionid ;
         }
         if ( sdt.IsDirty("WWPNotificationDefinitionDescription") )
         {
            gxTv_SdtWWP_Subscription_Wwpnotificationdefinitiondescription = sdt.gxTv_SdtWWP_Subscription_Wwpnotificationdefinitiondescription ;
         }
         if ( sdt.IsDirty("WWPEntityName") )
         {
            gxTv_SdtWWP_Subscription_Wwpentityname = sdt.gxTv_SdtWWP_Subscription_Wwpentityname ;
         }
         if ( sdt.IsDirty("WWPUserExtendedId") )
         {
            gxTv_SdtWWP_Subscription_Wwpuserextendedid_N = 0;
            gxTv_SdtWWP_Subscription_Wwpuserextendedid = sdt.gxTv_SdtWWP_Subscription_Wwpuserextendedid ;
         }
         if ( sdt.IsDirty("WWPUserExtendedFullName") )
         {
            gxTv_SdtWWP_Subscription_Wwpuserextendedfullname = sdt.gxTv_SdtWWP_Subscription_Wwpuserextendedfullname ;
         }
         if ( sdt.IsDirty("WWPSubscriptionEntityRecordId") )
         {
            gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecordid = sdt.gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecordid ;
         }
         if ( sdt.IsDirty("WWPSubscriptionEntityRecordDescription") )
         {
            gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecorddescription = sdt.gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecorddescription ;
         }
         if ( sdt.IsDirty("WWPSubscriptionRoleId") )
         {
            gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid_N = 0;
            gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid = sdt.gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid ;
         }
         if ( sdt.IsDirty("WWPSubscriptionSubscribed") )
         {
            gxTv_SdtWWP_Subscription_Wwpsubscriptionsubscribed = sdt.gxTv_SdtWWP_Subscription_Wwpsubscriptionsubscribed ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "WWPSubscriptionId" )]
      [  XmlElement( ElementName = "WWPSubscriptionId"   )]
      public long gxTpr_Wwpsubscriptionid
      {
         get {
            return gxTv_SdtWWP_Subscription_Wwpsubscriptionid ;
         }

         set {
            if ( gxTv_SdtWWP_Subscription_Wwpsubscriptionid != value )
            {
               gxTv_SdtWWP_Subscription_Mode = "INS";
               this.gxTv_SdtWWP_Subscription_Wwpsubscriptionid_Z_SetNull( );
               this.gxTv_SdtWWP_Subscription_Wwpnotificationdefinitionid_Z_SetNull( );
               this.gxTv_SdtWWP_Subscription_Wwpnotificationdefinitiondescription_Z_SetNull( );
               this.gxTv_SdtWWP_Subscription_Wwpentityname_Z_SetNull( );
               this.gxTv_SdtWWP_Subscription_Wwpuserextendedid_Z_SetNull( );
               this.gxTv_SdtWWP_Subscription_Wwpuserextendedfullname_Z_SetNull( );
               this.gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecordid_Z_SetNull( );
               this.gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecorddescription_Z_SetNull( );
               this.gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid_Z_SetNull( );
               this.gxTv_SdtWWP_Subscription_Wwpsubscriptionsubscribed_Z_SetNull( );
            }
            gxTv_SdtWWP_Subscription_Wwpsubscriptionid = value;
            SetDirty("Wwpsubscriptionid");
         }

      }

      [  SoapElement( ElementName = "WWPNotificationDefinitionId" )]
      [  XmlElement( ElementName = "WWPNotificationDefinitionId"   )]
      public long gxTpr_Wwpnotificationdefinitionid
      {
         get {
            return gxTv_SdtWWP_Subscription_Wwpnotificationdefinitionid ;
         }

         set {
            gxTv_SdtWWP_Subscription_Wwpnotificationdefinitionid = value;
            SetDirty("Wwpnotificationdefinitionid");
         }

      }

      [  SoapElement( ElementName = "WWPNotificationDefinitionDescription" )]
      [  XmlElement( ElementName = "WWPNotificationDefinitionDescription"   )]
      public string gxTpr_Wwpnotificationdefinitiondescription
      {
         get {
            return gxTv_SdtWWP_Subscription_Wwpnotificationdefinitiondescription ;
         }

         set {
            gxTv_SdtWWP_Subscription_Wwpnotificationdefinitiondescription = value;
            SetDirty("Wwpnotificationdefinitiondescription");
         }

      }

      [  SoapElement( ElementName = "WWPEntityName" )]
      [  XmlElement( ElementName = "WWPEntityName"   )]
      public string gxTpr_Wwpentityname
      {
         get {
            return gxTv_SdtWWP_Subscription_Wwpentityname ;
         }

         set {
            gxTv_SdtWWP_Subscription_Wwpentityname = value;
            SetDirty("Wwpentityname");
         }

      }

      [  SoapElement( ElementName = "WWPUserExtendedId" )]
      [  XmlElement( ElementName = "WWPUserExtendedId"   )]
      public string gxTpr_Wwpuserextendedid
      {
         get {
            return gxTv_SdtWWP_Subscription_Wwpuserextendedid ;
         }

         set {
            gxTv_SdtWWP_Subscription_Wwpuserextendedid_N = 0;
            gxTv_SdtWWP_Subscription_Wwpuserextendedid = value;
            SetDirty("Wwpuserextendedid");
         }

      }

      public void gxTv_SdtWWP_Subscription_Wwpuserextendedid_SetNull( )
      {
         gxTv_SdtWWP_Subscription_Wwpuserextendedid_N = 1;
         gxTv_SdtWWP_Subscription_Wwpuserextendedid = "";
         return  ;
      }

      public bool gxTv_SdtWWP_Subscription_Wwpuserextendedid_IsNull( )
      {
         return (gxTv_SdtWWP_Subscription_Wwpuserextendedid_N==1) ;
      }

      [  SoapElement( ElementName = "WWPUserExtendedFullName" )]
      [  XmlElement( ElementName = "WWPUserExtendedFullName"   )]
      public string gxTpr_Wwpuserextendedfullname
      {
         get {
            return gxTv_SdtWWP_Subscription_Wwpuserextendedfullname ;
         }

         set {
            gxTv_SdtWWP_Subscription_Wwpuserextendedfullname = value;
            SetDirty("Wwpuserextendedfullname");
         }

      }

      public void gxTv_SdtWWP_Subscription_Wwpuserextendedfullname_SetNull( )
      {
         gxTv_SdtWWP_Subscription_Wwpuserextendedfullname = "";
         return  ;
      }

      public bool gxTv_SdtWWP_Subscription_Wwpuserextendedfullname_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPSubscriptionEntityRecordId" )]
      [  XmlElement( ElementName = "WWPSubscriptionEntityRecordId"   )]
      public string gxTpr_Wwpsubscriptionentityrecordid
      {
         get {
            return gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecordid ;
         }

         set {
            gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecordid = value;
            SetDirty("Wwpsubscriptionentityrecordid");
         }

      }

      [  SoapElement( ElementName = "WWPSubscriptionEntityRecordDescription" )]
      [  XmlElement( ElementName = "WWPSubscriptionEntityRecordDescription"   )]
      public string gxTpr_Wwpsubscriptionentityrecorddescription
      {
         get {
            return gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecorddescription ;
         }

         set {
            gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecorddescription = value;
            SetDirty("Wwpsubscriptionentityrecorddescription");
         }

      }

      [  SoapElement( ElementName = "WWPSubscriptionRoleId" )]
      [  XmlElement( ElementName = "WWPSubscriptionRoleId"   )]
      public string gxTpr_Wwpsubscriptionroleid
      {
         get {
            return gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid ;
         }

         set {
            gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid_N = 0;
            gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid = value;
            SetDirty("Wwpsubscriptionroleid");
         }

      }

      public void gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid_SetNull( )
      {
         gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid_N = 1;
         gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid = "";
         return  ;
      }

      public bool gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid_IsNull( )
      {
         return (gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid_N==1) ;
      }

      [  SoapElement( ElementName = "WWPSubscriptionSubscribed" )]
      [  XmlElement( ElementName = "WWPSubscriptionSubscribed"   )]
      public bool gxTpr_Wwpsubscriptionsubscribed
      {
         get {
            return gxTv_SdtWWP_Subscription_Wwpsubscriptionsubscribed ;
         }

         set {
            gxTv_SdtWWP_Subscription_Wwpsubscriptionsubscribed = value;
            SetDirty("Wwpsubscriptionsubscribed");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtWWP_Subscription_Mode ;
         }

         set {
            gxTv_SdtWWP_Subscription_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtWWP_Subscription_Mode_SetNull( )
      {
         gxTv_SdtWWP_Subscription_Mode = "";
         return  ;
      }

      public bool gxTv_SdtWWP_Subscription_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtWWP_Subscription_Initialized ;
         }

         set {
            gxTv_SdtWWP_Subscription_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtWWP_Subscription_Initialized_SetNull( )
      {
         gxTv_SdtWWP_Subscription_Initialized = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_Subscription_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPSubscriptionId_Z" )]
      [  XmlElement( ElementName = "WWPSubscriptionId_Z"   )]
      public long gxTpr_Wwpsubscriptionid_Z
      {
         get {
            return gxTv_SdtWWP_Subscription_Wwpsubscriptionid_Z ;
         }

         set {
            gxTv_SdtWWP_Subscription_Wwpsubscriptionid_Z = value;
            SetDirty("Wwpsubscriptionid_Z");
         }

      }

      public void gxTv_SdtWWP_Subscription_Wwpsubscriptionid_Z_SetNull( )
      {
         gxTv_SdtWWP_Subscription_Wwpsubscriptionid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_Subscription_Wwpsubscriptionid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationDefinitionId_Z" )]
      [  XmlElement( ElementName = "WWPNotificationDefinitionId_Z"   )]
      public long gxTpr_Wwpnotificationdefinitionid_Z
      {
         get {
            return gxTv_SdtWWP_Subscription_Wwpnotificationdefinitionid_Z ;
         }

         set {
            gxTv_SdtWWP_Subscription_Wwpnotificationdefinitionid_Z = value;
            SetDirty("Wwpnotificationdefinitionid_Z");
         }

      }

      public void gxTv_SdtWWP_Subscription_Wwpnotificationdefinitionid_Z_SetNull( )
      {
         gxTv_SdtWWP_Subscription_Wwpnotificationdefinitionid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_Subscription_Wwpnotificationdefinitionid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationDefinitionDescription_Z" )]
      [  XmlElement( ElementName = "WWPNotificationDefinitionDescription_Z"   )]
      public string gxTpr_Wwpnotificationdefinitiondescription_Z
      {
         get {
            return gxTv_SdtWWP_Subscription_Wwpnotificationdefinitiondescription_Z ;
         }

         set {
            gxTv_SdtWWP_Subscription_Wwpnotificationdefinitiondescription_Z = value;
            SetDirty("Wwpnotificationdefinitiondescription_Z");
         }

      }

      public void gxTv_SdtWWP_Subscription_Wwpnotificationdefinitiondescription_Z_SetNull( )
      {
         gxTv_SdtWWP_Subscription_Wwpnotificationdefinitiondescription_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_Subscription_Wwpnotificationdefinitiondescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPEntityName_Z" )]
      [  XmlElement( ElementName = "WWPEntityName_Z"   )]
      public string gxTpr_Wwpentityname_Z
      {
         get {
            return gxTv_SdtWWP_Subscription_Wwpentityname_Z ;
         }

         set {
            gxTv_SdtWWP_Subscription_Wwpentityname_Z = value;
            SetDirty("Wwpentityname_Z");
         }

      }

      public void gxTv_SdtWWP_Subscription_Wwpentityname_Z_SetNull( )
      {
         gxTv_SdtWWP_Subscription_Wwpentityname_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_Subscription_Wwpentityname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPUserExtendedId_Z" )]
      [  XmlElement( ElementName = "WWPUserExtendedId_Z"   )]
      public string gxTpr_Wwpuserextendedid_Z
      {
         get {
            return gxTv_SdtWWP_Subscription_Wwpuserextendedid_Z ;
         }

         set {
            gxTv_SdtWWP_Subscription_Wwpuserextendedid_Z = value;
            SetDirty("Wwpuserextendedid_Z");
         }

      }

      public void gxTv_SdtWWP_Subscription_Wwpuserextendedid_Z_SetNull( )
      {
         gxTv_SdtWWP_Subscription_Wwpuserextendedid_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_Subscription_Wwpuserextendedid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPUserExtendedFullName_Z" )]
      [  XmlElement( ElementName = "WWPUserExtendedFullName_Z"   )]
      public string gxTpr_Wwpuserextendedfullname_Z
      {
         get {
            return gxTv_SdtWWP_Subscription_Wwpuserextendedfullname_Z ;
         }

         set {
            gxTv_SdtWWP_Subscription_Wwpuserextendedfullname_Z = value;
            SetDirty("Wwpuserextendedfullname_Z");
         }

      }

      public void gxTv_SdtWWP_Subscription_Wwpuserextendedfullname_Z_SetNull( )
      {
         gxTv_SdtWWP_Subscription_Wwpuserextendedfullname_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_Subscription_Wwpuserextendedfullname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPSubscriptionEntityRecordId_Z" )]
      [  XmlElement( ElementName = "WWPSubscriptionEntityRecordId_Z"   )]
      public string gxTpr_Wwpsubscriptionentityrecordid_Z
      {
         get {
            return gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecordid_Z ;
         }

         set {
            gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecordid_Z = value;
            SetDirty("Wwpsubscriptionentityrecordid_Z");
         }

      }

      public void gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecordid_Z_SetNull( )
      {
         gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecordid_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecordid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPSubscriptionEntityRecordDescription_Z" )]
      [  XmlElement( ElementName = "WWPSubscriptionEntityRecordDescription_Z"   )]
      public string gxTpr_Wwpsubscriptionentityrecorddescription_Z
      {
         get {
            return gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecorddescription_Z ;
         }

         set {
            gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecorddescription_Z = value;
            SetDirty("Wwpsubscriptionentityrecorddescription_Z");
         }

      }

      public void gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecorddescription_Z_SetNull( )
      {
         gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecorddescription_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecorddescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPSubscriptionRoleId_Z" )]
      [  XmlElement( ElementName = "WWPSubscriptionRoleId_Z"   )]
      public string gxTpr_Wwpsubscriptionroleid_Z
      {
         get {
            return gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid_Z ;
         }

         set {
            gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid_Z = value;
            SetDirty("Wwpsubscriptionroleid_Z");
         }

      }

      public void gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid_Z_SetNull( )
      {
         gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPSubscriptionSubscribed_Z" )]
      [  XmlElement( ElementName = "WWPSubscriptionSubscribed_Z"   )]
      public bool gxTpr_Wwpsubscriptionsubscribed_Z
      {
         get {
            return gxTv_SdtWWP_Subscription_Wwpsubscriptionsubscribed_Z ;
         }

         set {
            gxTv_SdtWWP_Subscription_Wwpsubscriptionsubscribed_Z = value;
            SetDirty("Wwpsubscriptionsubscribed_Z");
         }

      }

      public void gxTv_SdtWWP_Subscription_Wwpsubscriptionsubscribed_Z_SetNull( )
      {
         gxTv_SdtWWP_Subscription_Wwpsubscriptionsubscribed_Z = false;
         return  ;
      }

      public bool gxTv_SdtWWP_Subscription_Wwpsubscriptionsubscribed_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPUserExtendedId_N" )]
      [  XmlElement( ElementName = "WWPUserExtendedId_N"   )]
      public short gxTpr_Wwpuserextendedid_N
      {
         get {
            return gxTv_SdtWWP_Subscription_Wwpuserextendedid_N ;
         }

         set {
            gxTv_SdtWWP_Subscription_Wwpuserextendedid_N = value;
            SetDirty("Wwpuserextendedid_N");
         }

      }

      public void gxTv_SdtWWP_Subscription_Wwpuserextendedid_N_SetNull( )
      {
         gxTv_SdtWWP_Subscription_Wwpuserextendedid_N = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_Subscription_Wwpuserextendedid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPSubscriptionRoleId_N" )]
      [  XmlElement( ElementName = "WWPSubscriptionRoleId_N"   )]
      public short gxTpr_Wwpsubscriptionroleid_N
      {
         get {
            return gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid_N ;
         }

         set {
            gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid_N = value;
            SetDirty("Wwpsubscriptionroleid_N");
         }

      }

      public void gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid_N_SetNull( )
      {
         gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid_N = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtWWP_Subscription_Wwpnotificationdefinitiondescription = "";
         gxTv_SdtWWP_Subscription_Wwpentityname = "";
         gxTv_SdtWWP_Subscription_Wwpuserextendedid = "";
         gxTv_SdtWWP_Subscription_Wwpuserextendedfullname = "";
         gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecordid = "";
         gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecorddescription = "";
         gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid = "";
         gxTv_SdtWWP_Subscription_Mode = "";
         gxTv_SdtWWP_Subscription_Wwpnotificationdefinitiondescription_Z = "";
         gxTv_SdtWWP_Subscription_Wwpentityname_Z = "";
         gxTv_SdtWWP_Subscription_Wwpuserextendedid_Z = "";
         gxTv_SdtWWP_Subscription_Wwpuserextendedfullname_Z = "";
         gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecordid_Z = "";
         gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecorddescription_Z = "";
         gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "wwpbaseobjects.subscriptions.wwp_subscription", "GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_subscription_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      private short gxTv_SdtWWP_Subscription_Initialized ;
      private short gxTv_SdtWWP_Subscription_Wwpuserextendedid_N ;
      private short gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid_N ;
      private long gxTv_SdtWWP_Subscription_Wwpsubscriptionid ;
      private long gxTv_SdtWWP_Subscription_Wwpnotificationdefinitionid ;
      private long gxTv_SdtWWP_Subscription_Wwpsubscriptionid_Z ;
      private long gxTv_SdtWWP_Subscription_Wwpnotificationdefinitionid_Z ;
      private string gxTv_SdtWWP_Subscription_Wwpuserextendedid ;
      private string gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid ;
      private string gxTv_SdtWWP_Subscription_Mode ;
      private string gxTv_SdtWWP_Subscription_Wwpuserextendedid_Z ;
      private string gxTv_SdtWWP_Subscription_Wwpsubscriptionroleid_Z ;
      private bool gxTv_SdtWWP_Subscription_Wwpsubscriptionsubscribed ;
      private bool gxTv_SdtWWP_Subscription_Wwpsubscriptionsubscribed_Z ;
      private string gxTv_SdtWWP_Subscription_Wwpnotificationdefinitiondescription ;
      private string gxTv_SdtWWP_Subscription_Wwpentityname ;
      private string gxTv_SdtWWP_Subscription_Wwpuserextendedfullname ;
      private string gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecordid ;
      private string gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecorddescription ;
      private string gxTv_SdtWWP_Subscription_Wwpnotificationdefinitiondescription_Z ;
      private string gxTv_SdtWWP_Subscription_Wwpentityname_Z ;
      private string gxTv_SdtWWP_Subscription_Wwpuserextendedfullname_Z ;
      private string gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecordid_Z ;
      private string gxTv_SdtWWP_Subscription_Wwpsubscriptionentityrecorddescription_Z ;
   }

   [DataContract(Name = @"WWPBaseObjects\Subscriptions\WWP_Subscription", Namespace = "RastreamentoTCC")]
   public class SdtWWP_Subscription_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWWP_Subscription_RESTInterface( ) : base()
      {
      }

      public SdtWWP_Subscription_RESTInterface( GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WWPSubscriptionId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Wwpsubscriptionid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Wwpsubscriptionid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Wwpsubscriptionid = (long)(NumberUtil.Val( value, "."));
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

      [DataMember( Name = "WWPNotificationDefinitionDescription" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Wwpnotificationdefinitiondescription
      {
         get {
            return sdt.gxTpr_Wwpnotificationdefinitiondescription ;
         }

         set {
            sdt.gxTpr_Wwpnotificationdefinitiondescription = value;
         }

      }

      [DataMember( Name = "WWPEntityName" , Order = 3 )]
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

      [DataMember( Name = "WWPUserExtendedFullName" , Order = 5 )]
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

      [DataMember( Name = "WWPSubscriptionEntityRecordId" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Wwpsubscriptionentityrecordid
      {
         get {
            return sdt.gxTpr_Wwpsubscriptionentityrecordid ;
         }

         set {
            sdt.gxTpr_Wwpsubscriptionentityrecordid = value;
         }

      }

      [DataMember( Name = "WWPSubscriptionEntityRecordDescription" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Wwpsubscriptionentityrecorddescription
      {
         get {
            return sdt.gxTpr_Wwpsubscriptionentityrecorddescription ;
         }

         set {
            sdt.gxTpr_Wwpsubscriptionentityrecorddescription = value;
         }

      }

      [DataMember( Name = "WWPSubscriptionRoleId" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Wwpsubscriptionroleid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Wwpsubscriptionroleid) ;
         }

         set {
            sdt.gxTpr_Wwpsubscriptionroleid = value;
         }

      }

      [DataMember( Name = "WWPSubscriptionSubscribed" , Order = 9 )]
      [GxSeudo()]
      public bool gxTpr_Wwpsubscriptionsubscribed
      {
         get {
            return sdt.gxTpr_Wwpsubscriptionsubscribed ;
         }

         set {
            sdt.gxTpr_Wwpsubscriptionsubscribed = value;
         }

      }

      public GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription() ;
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

   [DataContract(Name = @"WWPBaseObjects\Subscriptions\WWP_Subscription", Namespace = "RastreamentoTCC")]
   public class SdtWWP_Subscription_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWWP_Subscription_RESTLInterface( ) : base()
      {
      }

      public SdtWWP_Subscription_RESTLInterface( GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WWPSubscriptionEntityRecordId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Wwpsubscriptionentityrecordid
      {
         get {
            return sdt.gxTpr_Wwpsubscriptionentityrecordid ;
         }

         set {
            sdt.gxTpr_Wwpsubscriptionentityrecordid = value;
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

      public GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription() ;
         }
      }

   }

}
