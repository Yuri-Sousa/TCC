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
   [XmlRoot(ElementName = "WWP_NotificationDefinition" )]
   [XmlType(TypeName =  "WWP_NotificationDefinition" , Namespace = "RastreamentoTCC" )]
   [Serializable]
   public class SdtWWP_NotificationDefinition : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWWP_NotificationDefinition( )
      {
      }

      public SdtWWP_NotificationDefinition( IGxContext context )
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

      public void Load( long AV14WWPNotificationDefinitionId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(long)AV14WWPNotificationDefinitionId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"WWPNotificationDefinitionId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "WWPBaseObjects\\Notifications\\Common\\WWP_NotificationDefinition");
         metadata.Set("BT", "WWP_NotificationDefinition");
         metadata.Set("PK", "[ \"WWPNotificationDefinitionId\" ]");
         metadata.Set("PKAssigned", "[ \"WWPNotificationDefinitionId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"WWPEntityId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Wwpnotificationdefinitionid_Z");
         state.Add("gxTpr_Wwpnotificationdefinitionname_Z");
         state.Add("gxTpr_Wwpnotificationdefinitionappliesto_Z");
         state.Add("gxTpr_Wwpnotificationdefinitionallowusersubscription_Z");
         state.Add("gxTpr_Wwpnotificationdefinitiondescription_Z");
         state.Add("gxTpr_Wwpnotificationdefinitionicon_Z");
         state.Add("gxTpr_Wwpnotificationdefinitiontitle_Z");
         state.Add("gxTpr_Wwpnotificationdefinitionshortdescription_Z");
         state.Add("gxTpr_Wwpnotificationdefinitionlongdescription_Z");
         state.Add("gxTpr_Wwpnotificationdefinitionlink_Z");
         state.Add("gxTpr_Wwpentityid_Z");
         state.Add("gxTpr_Wwpentityname_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition sdt;
         sdt = (GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition)(source);
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionid = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionid ;
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionname = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionname ;
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionappliesto = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionappliesto ;
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionallowusersubscription = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionallowusersubscription ;
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiondescription = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiondescription ;
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionicon = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionicon ;
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiontitle = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiontitle ;
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionshortdescription = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionshortdescription ;
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlongdescription = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlongdescription ;
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlink = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlink ;
         gxTv_SdtWWP_NotificationDefinition_Wwpentityid = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpentityid ;
         gxTv_SdtWWP_NotificationDefinition_Wwpentityname = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpentityname ;
         gxTv_SdtWWP_NotificationDefinition_Mode = sdt.gxTv_SdtWWP_NotificationDefinition_Mode ;
         gxTv_SdtWWP_NotificationDefinition_Initialized = sdt.gxTv_SdtWWP_NotificationDefinition_Initialized ;
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionid_Z = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionid_Z ;
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionname_Z = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionname_Z ;
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionappliesto_Z = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionappliesto_Z ;
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionallowusersubscription_Z = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionallowusersubscription_Z ;
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiondescription_Z = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiondescription_Z ;
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionicon_Z = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionicon_Z ;
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiontitle_Z = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiontitle_Z ;
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionshortdescription_Z = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionshortdescription_Z ;
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlongdescription_Z = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlongdescription_Z ;
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlink_Z = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlink_Z ;
         gxTv_SdtWWP_NotificationDefinition_Wwpentityid_Z = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpentityid_Z ;
         gxTv_SdtWWP_NotificationDefinition_Wwpentityname_Z = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpentityname_Z ;
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
         AddObjectProperty("WWPNotificationDefinitionId", gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionid, false, includeNonInitialized);
         AddObjectProperty("WWPNotificationDefinitionName", gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionname, false, includeNonInitialized);
         AddObjectProperty("WWPNotificationDefinitionAppliesTo", gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionappliesto, false, includeNonInitialized);
         AddObjectProperty("WWPNotificationDefinitionAllowUserSubscription", gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionallowusersubscription, false, includeNonInitialized);
         AddObjectProperty("WWPNotificationDefinitionDescription", gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiondescription, false, includeNonInitialized);
         AddObjectProperty("WWPNotificationDefinitionIcon", gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionicon, false, includeNonInitialized);
         AddObjectProperty("WWPNotificationDefinitionTitle", gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiontitle, false, includeNonInitialized);
         AddObjectProperty("WWPNotificationDefinitionShortDescription", gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionshortdescription, false, includeNonInitialized);
         AddObjectProperty("WWPNotificationDefinitionLongDescription", gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlongdescription, false, includeNonInitialized);
         AddObjectProperty("WWPNotificationDefinitionLink", gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlink, false, includeNonInitialized);
         AddObjectProperty("WWPEntityId", gxTv_SdtWWP_NotificationDefinition_Wwpentityid, false, includeNonInitialized);
         AddObjectProperty("WWPEntityName", gxTv_SdtWWP_NotificationDefinition_Wwpentityname, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtWWP_NotificationDefinition_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtWWP_NotificationDefinition_Initialized, false, includeNonInitialized);
            AddObjectProperty("WWPNotificationDefinitionId_Z", gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPNotificationDefinitionName_Z", gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionname_Z, false, includeNonInitialized);
            AddObjectProperty("WWPNotificationDefinitionAppliesTo_Z", gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionappliesto_Z, false, includeNonInitialized);
            AddObjectProperty("WWPNotificationDefinitionAllowUserSubscription_Z", gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionallowusersubscription_Z, false, includeNonInitialized);
            AddObjectProperty("WWPNotificationDefinitionDescription_Z", gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiondescription_Z, false, includeNonInitialized);
            AddObjectProperty("WWPNotificationDefinitionIcon_Z", gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionicon_Z, false, includeNonInitialized);
            AddObjectProperty("WWPNotificationDefinitionTitle_Z", gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiontitle_Z, false, includeNonInitialized);
            AddObjectProperty("WWPNotificationDefinitionShortDescription_Z", gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionshortdescription_Z, false, includeNonInitialized);
            AddObjectProperty("WWPNotificationDefinitionLongDescription_Z", gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlongdescription_Z, false, includeNonInitialized);
            AddObjectProperty("WWPNotificationDefinitionLink_Z", gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlink_Z, false, includeNonInitialized);
            AddObjectProperty("WWPEntityId_Z", gxTv_SdtWWP_NotificationDefinition_Wwpentityid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPEntityName_Z", gxTv_SdtWWP_NotificationDefinition_Wwpentityname_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition sdt )
      {
         if ( sdt.IsDirty("WWPNotificationDefinitionId") )
         {
            gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionid = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionid ;
         }
         if ( sdt.IsDirty("WWPNotificationDefinitionName") )
         {
            gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionname = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionname ;
         }
         if ( sdt.IsDirty("WWPNotificationDefinitionAppliesTo") )
         {
            gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionappliesto = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionappliesto ;
         }
         if ( sdt.IsDirty("WWPNotificationDefinitionAllowUserSubscription") )
         {
            gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionallowusersubscription = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionallowusersubscription ;
         }
         if ( sdt.IsDirty("WWPNotificationDefinitionDescription") )
         {
            gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiondescription = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiondescription ;
         }
         if ( sdt.IsDirty("WWPNotificationDefinitionIcon") )
         {
            gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionicon = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionicon ;
         }
         if ( sdt.IsDirty("WWPNotificationDefinitionTitle") )
         {
            gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiontitle = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiontitle ;
         }
         if ( sdt.IsDirty("WWPNotificationDefinitionShortDescription") )
         {
            gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionshortdescription = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionshortdescription ;
         }
         if ( sdt.IsDirty("WWPNotificationDefinitionLongDescription") )
         {
            gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlongdescription = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlongdescription ;
         }
         if ( sdt.IsDirty("WWPNotificationDefinitionLink") )
         {
            gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlink = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlink ;
         }
         if ( sdt.IsDirty("WWPEntityId") )
         {
            gxTv_SdtWWP_NotificationDefinition_Wwpentityid = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpentityid ;
         }
         if ( sdt.IsDirty("WWPEntityName") )
         {
            gxTv_SdtWWP_NotificationDefinition_Wwpentityname = sdt.gxTv_SdtWWP_NotificationDefinition_Wwpentityname ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "WWPNotificationDefinitionId" )]
      [  XmlElement( ElementName = "WWPNotificationDefinitionId"   )]
      public long gxTpr_Wwpnotificationdefinitionid
      {
         get {
            return gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionid ;
         }

         set {
            if ( gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionid != value )
            {
               gxTv_SdtWWP_NotificationDefinition_Mode = "INS";
               this.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionid_Z_SetNull( );
               this.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionname_Z_SetNull( );
               this.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionappliesto_Z_SetNull( );
               this.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionallowusersubscription_Z_SetNull( );
               this.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiondescription_Z_SetNull( );
               this.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionicon_Z_SetNull( );
               this.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiontitle_Z_SetNull( );
               this.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionshortdescription_Z_SetNull( );
               this.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlongdescription_Z_SetNull( );
               this.gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlink_Z_SetNull( );
               this.gxTv_SdtWWP_NotificationDefinition_Wwpentityid_Z_SetNull( );
               this.gxTv_SdtWWP_NotificationDefinition_Wwpentityname_Z_SetNull( );
            }
            gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionid = value;
            SetDirty("Wwpnotificationdefinitionid");
         }

      }

      [  SoapElement( ElementName = "WWPNotificationDefinitionName" )]
      [  XmlElement( ElementName = "WWPNotificationDefinitionName"   )]
      public string gxTpr_Wwpnotificationdefinitionname
      {
         get {
            return gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionname ;
         }

         set {
            gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionname = value;
            SetDirty("Wwpnotificationdefinitionname");
         }

      }

      [  SoapElement( ElementName = "WWPNotificationDefinitionAppliesTo" )]
      [  XmlElement( ElementName = "WWPNotificationDefinitionAppliesTo"   )]
      public short gxTpr_Wwpnotificationdefinitionappliesto
      {
         get {
            return gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionappliesto ;
         }

         set {
            gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionappliesto = value;
            SetDirty("Wwpnotificationdefinitionappliesto");
         }

      }

      [  SoapElement( ElementName = "WWPNotificationDefinitionAllowUserSubscription" )]
      [  XmlElement( ElementName = "WWPNotificationDefinitionAllowUserSubscription"   )]
      public bool gxTpr_Wwpnotificationdefinitionallowusersubscription
      {
         get {
            return gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionallowusersubscription ;
         }

         set {
            gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionallowusersubscription = value;
            SetDirty("Wwpnotificationdefinitionallowusersubscription");
         }

      }

      [  SoapElement( ElementName = "WWPNotificationDefinitionDescription" )]
      [  XmlElement( ElementName = "WWPNotificationDefinitionDescription"   )]
      public string gxTpr_Wwpnotificationdefinitiondescription
      {
         get {
            return gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiondescription ;
         }

         set {
            gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiondescription = value;
            SetDirty("Wwpnotificationdefinitiondescription");
         }

      }

      [  SoapElement( ElementName = "WWPNotificationDefinitionIcon" )]
      [  XmlElement( ElementName = "WWPNotificationDefinitionIcon"   )]
      public string gxTpr_Wwpnotificationdefinitionicon
      {
         get {
            return gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionicon ;
         }

         set {
            gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionicon = value;
            SetDirty("Wwpnotificationdefinitionicon");
         }

      }

      [  SoapElement( ElementName = "WWPNotificationDefinitionTitle" )]
      [  XmlElement( ElementName = "WWPNotificationDefinitionTitle"   )]
      public string gxTpr_Wwpnotificationdefinitiontitle
      {
         get {
            return gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiontitle ;
         }

         set {
            gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiontitle = value;
            SetDirty("Wwpnotificationdefinitiontitle");
         }

      }

      [  SoapElement( ElementName = "WWPNotificationDefinitionShortDescription" )]
      [  XmlElement( ElementName = "WWPNotificationDefinitionShortDescription"   )]
      public string gxTpr_Wwpnotificationdefinitionshortdescription
      {
         get {
            return gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionshortdescription ;
         }

         set {
            gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionshortdescription = value;
            SetDirty("Wwpnotificationdefinitionshortdescription");
         }

      }

      [  SoapElement( ElementName = "WWPNotificationDefinitionLongDescription" )]
      [  XmlElement( ElementName = "WWPNotificationDefinitionLongDescription"   )]
      public string gxTpr_Wwpnotificationdefinitionlongdescription
      {
         get {
            return gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlongdescription ;
         }

         set {
            gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlongdescription = value;
            SetDirty("Wwpnotificationdefinitionlongdescription");
         }

      }

      [  SoapElement( ElementName = "WWPNotificationDefinitionLink" )]
      [  XmlElement( ElementName = "WWPNotificationDefinitionLink"   )]
      public string gxTpr_Wwpnotificationdefinitionlink
      {
         get {
            return gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlink ;
         }

         set {
            gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlink = value;
            SetDirty("Wwpnotificationdefinitionlink");
         }

      }

      [  SoapElement( ElementName = "WWPEntityId" )]
      [  XmlElement( ElementName = "WWPEntityId"   )]
      public long gxTpr_Wwpentityid
      {
         get {
            return gxTv_SdtWWP_NotificationDefinition_Wwpentityid ;
         }

         set {
            gxTv_SdtWWP_NotificationDefinition_Wwpentityid = value;
            SetDirty("Wwpentityid");
         }

      }

      [  SoapElement( ElementName = "WWPEntityName" )]
      [  XmlElement( ElementName = "WWPEntityName"   )]
      public string gxTpr_Wwpentityname
      {
         get {
            return gxTv_SdtWWP_NotificationDefinition_Wwpentityname ;
         }

         set {
            gxTv_SdtWWP_NotificationDefinition_Wwpentityname = value;
            SetDirty("Wwpentityname");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtWWP_NotificationDefinition_Mode ;
         }

         set {
            gxTv_SdtWWP_NotificationDefinition_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtWWP_NotificationDefinition_Mode_SetNull( )
      {
         gxTv_SdtWWP_NotificationDefinition_Mode = "";
         return  ;
      }

      public bool gxTv_SdtWWP_NotificationDefinition_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtWWP_NotificationDefinition_Initialized ;
         }

         set {
            gxTv_SdtWWP_NotificationDefinition_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtWWP_NotificationDefinition_Initialized_SetNull( )
      {
         gxTv_SdtWWP_NotificationDefinition_Initialized = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_NotificationDefinition_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationDefinitionId_Z" )]
      [  XmlElement( ElementName = "WWPNotificationDefinitionId_Z"   )]
      public long gxTpr_Wwpnotificationdefinitionid_Z
      {
         get {
            return gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionid_Z ;
         }

         set {
            gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionid_Z = value;
            SetDirty("Wwpnotificationdefinitionid_Z");
         }

      }

      public void gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionid_Z_SetNull( )
      {
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationDefinitionName_Z" )]
      [  XmlElement( ElementName = "WWPNotificationDefinitionName_Z"   )]
      public string gxTpr_Wwpnotificationdefinitionname_Z
      {
         get {
            return gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionname_Z ;
         }

         set {
            gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionname_Z = value;
            SetDirty("Wwpnotificationdefinitionname_Z");
         }

      }

      public void gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionname_Z_SetNull( )
      {
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionname_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationDefinitionAppliesTo_Z" )]
      [  XmlElement( ElementName = "WWPNotificationDefinitionAppliesTo_Z"   )]
      public short gxTpr_Wwpnotificationdefinitionappliesto_Z
      {
         get {
            return gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionappliesto_Z ;
         }

         set {
            gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionappliesto_Z = value;
            SetDirty("Wwpnotificationdefinitionappliesto_Z");
         }

      }

      public void gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionappliesto_Z_SetNull( )
      {
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionappliesto_Z = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionappliesto_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationDefinitionAllowUserSubscription_Z" )]
      [  XmlElement( ElementName = "WWPNotificationDefinitionAllowUserSubscription_Z"   )]
      public bool gxTpr_Wwpnotificationdefinitionallowusersubscription_Z
      {
         get {
            return gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionallowusersubscription_Z ;
         }

         set {
            gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionallowusersubscription_Z = value;
            SetDirty("Wwpnotificationdefinitionallowusersubscription_Z");
         }

      }

      public void gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionallowusersubscription_Z_SetNull( )
      {
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionallowusersubscription_Z = false;
         return  ;
      }

      public bool gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionallowusersubscription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationDefinitionDescription_Z" )]
      [  XmlElement( ElementName = "WWPNotificationDefinitionDescription_Z"   )]
      public string gxTpr_Wwpnotificationdefinitiondescription_Z
      {
         get {
            return gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiondescription_Z ;
         }

         set {
            gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiondescription_Z = value;
            SetDirty("Wwpnotificationdefinitiondescription_Z");
         }

      }

      public void gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiondescription_Z_SetNull( )
      {
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiondescription_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiondescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationDefinitionIcon_Z" )]
      [  XmlElement( ElementName = "WWPNotificationDefinitionIcon_Z"   )]
      public string gxTpr_Wwpnotificationdefinitionicon_Z
      {
         get {
            return gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionicon_Z ;
         }

         set {
            gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionicon_Z = value;
            SetDirty("Wwpnotificationdefinitionicon_Z");
         }

      }

      public void gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionicon_Z_SetNull( )
      {
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionicon_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionicon_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationDefinitionTitle_Z" )]
      [  XmlElement( ElementName = "WWPNotificationDefinitionTitle_Z"   )]
      public string gxTpr_Wwpnotificationdefinitiontitle_Z
      {
         get {
            return gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiontitle_Z ;
         }

         set {
            gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiontitle_Z = value;
            SetDirty("Wwpnotificationdefinitiontitle_Z");
         }

      }

      public void gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiontitle_Z_SetNull( )
      {
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiontitle_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiontitle_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationDefinitionShortDescription_Z" )]
      [  XmlElement( ElementName = "WWPNotificationDefinitionShortDescription_Z"   )]
      public string gxTpr_Wwpnotificationdefinitionshortdescription_Z
      {
         get {
            return gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionshortdescription_Z ;
         }

         set {
            gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionshortdescription_Z = value;
            SetDirty("Wwpnotificationdefinitionshortdescription_Z");
         }

      }

      public void gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionshortdescription_Z_SetNull( )
      {
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionshortdescription_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionshortdescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationDefinitionLongDescription_Z" )]
      [  XmlElement( ElementName = "WWPNotificationDefinitionLongDescription_Z"   )]
      public string gxTpr_Wwpnotificationdefinitionlongdescription_Z
      {
         get {
            return gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlongdescription_Z ;
         }

         set {
            gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlongdescription_Z = value;
            SetDirty("Wwpnotificationdefinitionlongdescription_Z");
         }

      }

      public void gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlongdescription_Z_SetNull( )
      {
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlongdescription_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlongdescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPNotificationDefinitionLink_Z" )]
      [  XmlElement( ElementName = "WWPNotificationDefinitionLink_Z"   )]
      public string gxTpr_Wwpnotificationdefinitionlink_Z
      {
         get {
            return gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlink_Z ;
         }

         set {
            gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlink_Z = value;
            SetDirty("Wwpnotificationdefinitionlink_Z");
         }

      }

      public void gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlink_Z_SetNull( )
      {
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlink_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlink_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPEntityId_Z" )]
      [  XmlElement( ElementName = "WWPEntityId_Z"   )]
      public long gxTpr_Wwpentityid_Z
      {
         get {
            return gxTv_SdtWWP_NotificationDefinition_Wwpentityid_Z ;
         }

         set {
            gxTv_SdtWWP_NotificationDefinition_Wwpentityid_Z = value;
            SetDirty("Wwpentityid_Z");
         }

      }

      public void gxTv_SdtWWP_NotificationDefinition_Wwpentityid_Z_SetNull( )
      {
         gxTv_SdtWWP_NotificationDefinition_Wwpentityid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_NotificationDefinition_Wwpentityid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPEntityName_Z" )]
      [  XmlElement( ElementName = "WWPEntityName_Z"   )]
      public string gxTpr_Wwpentityname_Z
      {
         get {
            return gxTv_SdtWWP_NotificationDefinition_Wwpentityname_Z ;
         }

         set {
            gxTv_SdtWWP_NotificationDefinition_Wwpentityname_Z = value;
            SetDirty("Wwpentityname_Z");
         }

      }

      public void gxTv_SdtWWP_NotificationDefinition_Wwpentityname_Z_SetNull( )
      {
         gxTv_SdtWWP_NotificationDefinition_Wwpentityname_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_NotificationDefinition_Wwpentityname_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionname = "";
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiondescription = "";
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionicon = "";
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiontitle = "";
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionshortdescription = "";
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlongdescription = "";
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlink = "";
         gxTv_SdtWWP_NotificationDefinition_Wwpentityname = "";
         gxTv_SdtWWP_NotificationDefinition_Mode = "";
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionname_Z = "";
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiondescription_Z = "";
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionicon_Z = "";
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiontitle_Z = "";
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionshortdescription_Z = "";
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlongdescription_Z = "";
         gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlink_Z = "";
         gxTv_SdtWWP_NotificationDefinition_Wwpentityname_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "wwpbaseobjects.notifications.common.wwp_notificationdefinition", "GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notificationdefinition_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      private short gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionappliesto ;
      private short gxTv_SdtWWP_NotificationDefinition_Initialized ;
      private short gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionappliesto_Z ;
      private long gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionid ;
      private long gxTv_SdtWWP_NotificationDefinition_Wwpentityid ;
      private long gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionid_Z ;
      private long gxTv_SdtWWP_NotificationDefinition_Wwpentityid_Z ;
      private string gxTv_SdtWWP_NotificationDefinition_Mode ;
      private bool gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionallowusersubscription ;
      private bool gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionallowusersubscription_Z ;
      private string gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionname ;
      private string gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiondescription ;
      private string gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionicon ;
      private string gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiontitle ;
      private string gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionshortdescription ;
      private string gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlongdescription ;
      private string gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlink ;
      private string gxTv_SdtWWP_NotificationDefinition_Wwpentityname ;
      private string gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionname_Z ;
      private string gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiondescription_Z ;
      private string gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionicon_Z ;
      private string gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitiontitle_Z ;
      private string gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionshortdescription_Z ;
      private string gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlongdescription_Z ;
      private string gxTv_SdtWWP_NotificationDefinition_Wwpnotificationdefinitionlink_Z ;
      private string gxTv_SdtWWP_NotificationDefinition_Wwpentityname_Z ;
   }

   [DataContract(Name = @"WWPBaseObjects\Notifications\Common\WWP_NotificationDefinition", Namespace = "RastreamentoTCC")]
   public class SdtWWP_NotificationDefinition_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWWP_NotificationDefinition_RESTInterface( ) : base()
      {
      }

      public SdtWWP_NotificationDefinition_RESTInterface( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WWPNotificationDefinitionId" , Order = 0 )]
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

      [DataMember( Name = "WWPNotificationDefinitionName" , Order = 1 )]
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

      [DataMember( Name = "WWPNotificationDefinitionAppliesTo" , Order = 2 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Wwpnotificationdefinitionappliesto
      {
         get {
            return sdt.gxTpr_Wwpnotificationdefinitionappliesto ;
         }

         set {
            sdt.gxTpr_Wwpnotificationdefinitionappliesto = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPNotificationDefinitionAllowUserSubscription" , Order = 3 )]
      [GxSeudo()]
      public bool gxTpr_Wwpnotificationdefinitionallowusersubscription
      {
         get {
            return sdt.gxTpr_Wwpnotificationdefinitionallowusersubscription ;
         }

         set {
            sdt.gxTpr_Wwpnotificationdefinitionallowusersubscription = value;
         }

      }

      [DataMember( Name = "WWPNotificationDefinitionDescription" , Order = 4 )]
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

      [DataMember( Name = "WWPNotificationDefinitionIcon" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Wwpnotificationdefinitionicon
      {
         get {
            return sdt.gxTpr_Wwpnotificationdefinitionicon ;
         }

         set {
            sdt.gxTpr_Wwpnotificationdefinitionicon = value;
         }

      }

      [DataMember( Name = "WWPNotificationDefinitionTitle" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Wwpnotificationdefinitiontitle
      {
         get {
            return sdt.gxTpr_Wwpnotificationdefinitiontitle ;
         }

         set {
            sdt.gxTpr_Wwpnotificationdefinitiontitle = value;
         }

      }

      [DataMember( Name = "WWPNotificationDefinitionShortDescription" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Wwpnotificationdefinitionshortdescription
      {
         get {
            return sdt.gxTpr_Wwpnotificationdefinitionshortdescription ;
         }

         set {
            sdt.gxTpr_Wwpnotificationdefinitionshortdescription = value;
         }

      }

      [DataMember( Name = "WWPNotificationDefinitionLongDescription" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Wwpnotificationdefinitionlongdescription
      {
         get {
            return sdt.gxTpr_Wwpnotificationdefinitionlongdescription ;
         }

         set {
            sdt.gxTpr_Wwpnotificationdefinitionlongdescription = value;
         }

      }

      [DataMember( Name = "WWPNotificationDefinitionLink" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Wwpnotificationdefinitionlink
      {
         get {
            return sdt.gxTpr_Wwpnotificationdefinitionlink ;
         }

         set {
            sdt.gxTpr_Wwpnotificationdefinitionlink = value;
         }

      }

      [DataMember( Name = "WWPEntityId" , Order = 10 )]
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

      [DataMember( Name = "WWPEntityName" , Order = 11 )]
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

      public GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition() ;
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

   [DataContract(Name = @"WWPBaseObjects\Notifications\Common\WWP_NotificationDefinition", Namespace = "RastreamentoTCC")]
   public class SdtWWP_NotificationDefinition_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWWP_NotificationDefinition_RESTLInterface( ) : base()
      {
      }

      public SdtWWP_NotificationDefinition_RESTLInterface( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WWPNotificationDefinitionName" , Order = 0 )]
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

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition() ;
         }
      }

   }

}
