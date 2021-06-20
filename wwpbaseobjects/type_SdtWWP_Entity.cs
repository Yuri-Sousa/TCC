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
namespace GeneXus.Programs.wwpbaseobjects {
   [XmlSerializerFormat]
   [XmlRoot(ElementName = "WWP_Entity" )]
   [XmlType(TypeName =  "WWP_Entity" , Namespace = "RastreamentoTCC" )]
   [Serializable]
   public class SdtWWP_Entity : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWWP_Entity( )
      {
      }

      public SdtWWP_Entity( IGxContext context )
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

      public void Load( long AV10WWPEntityId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(long)AV10WWPEntityId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"WWPEntityId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "WWPBaseObjects\\WWP_Entity");
         metadata.Set("BT", "WWP_Entity");
         metadata.Set("PK", "[ \"WWPEntityId\" ]");
         metadata.Set("PKAssigned", "[ \"WWPEntityId\" ]");
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
         state.Add("gxTpr_Wwpentityid_Z");
         state.Add("gxTpr_Wwpentityname_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity sdt;
         sdt = (GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity)(source);
         gxTv_SdtWWP_Entity_Wwpentityid = sdt.gxTv_SdtWWP_Entity_Wwpentityid ;
         gxTv_SdtWWP_Entity_Wwpentityname = sdt.gxTv_SdtWWP_Entity_Wwpentityname ;
         gxTv_SdtWWP_Entity_Mode = sdt.gxTv_SdtWWP_Entity_Mode ;
         gxTv_SdtWWP_Entity_Initialized = sdt.gxTv_SdtWWP_Entity_Initialized ;
         gxTv_SdtWWP_Entity_Wwpentityid_Z = sdt.gxTv_SdtWWP_Entity_Wwpentityid_Z ;
         gxTv_SdtWWP_Entity_Wwpentityname_Z = sdt.gxTv_SdtWWP_Entity_Wwpentityname_Z ;
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
         AddObjectProperty("WWPEntityId", gxTv_SdtWWP_Entity_Wwpentityid, false, includeNonInitialized);
         AddObjectProperty("WWPEntityName", gxTv_SdtWWP_Entity_Wwpentityname, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtWWP_Entity_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtWWP_Entity_Initialized, false, includeNonInitialized);
            AddObjectProperty("WWPEntityId_Z", gxTv_SdtWWP_Entity_Wwpentityid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPEntityName_Z", gxTv_SdtWWP_Entity_Wwpentityname_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity sdt )
      {
         if ( sdt.IsDirty("WWPEntityId") )
         {
            gxTv_SdtWWP_Entity_Wwpentityid = sdt.gxTv_SdtWWP_Entity_Wwpentityid ;
         }
         if ( sdt.IsDirty("WWPEntityName") )
         {
            gxTv_SdtWWP_Entity_Wwpentityname = sdt.gxTv_SdtWWP_Entity_Wwpentityname ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "WWPEntityId" )]
      [  XmlElement( ElementName = "WWPEntityId"   )]
      public long gxTpr_Wwpentityid
      {
         get {
            return gxTv_SdtWWP_Entity_Wwpentityid ;
         }

         set {
            if ( gxTv_SdtWWP_Entity_Wwpentityid != value )
            {
               gxTv_SdtWWP_Entity_Mode = "INS";
               this.gxTv_SdtWWP_Entity_Wwpentityid_Z_SetNull( );
               this.gxTv_SdtWWP_Entity_Wwpentityname_Z_SetNull( );
            }
            gxTv_SdtWWP_Entity_Wwpentityid = value;
            SetDirty("Wwpentityid");
         }

      }

      [  SoapElement( ElementName = "WWPEntityName" )]
      [  XmlElement( ElementName = "WWPEntityName"   )]
      public string gxTpr_Wwpentityname
      {
         get {
            return gxTv_SdtWWP_Entity_Wwpentityname ;
         }

         set {
            gxTv_SdtWWP_Entity_Wwpentityname = value;
            SetDirty("Wwpentityname");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtWWP_Entity_Mode ;
         }

         set {
            gxTv_SdtWWP_Entity_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtWWP_Entity_Mode_SetNull( )
      {
         gxTv_SdtWWP_Entity_Mode = "";
         return  ;
      }

      public bool gxTv_SdtWWP_Entity_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtWWP_Entity_Initialized ;
         }

         set {
            gxTv_SdtWWP_Entity_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtWWP_Entity_Initialized_SetNull( )
      {
         gxTv_SdtWWP_Entity_Initialized = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_Entity_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPEntityId_Z" )]
      [  XmlElement( ElementName = "WWPEntityId_Z"   )]
      public long gxTpr_Wwpentityid_Z
      {
         get {
            return gxTv_SdtWWP_Entity_Wwpentityid_Z ;
         }

         set {
            gxTv_SdtWWP_Entity_Wwpentityid_Z = value;
            SetDirty("Wwpentityid_Z");
         }

      }

      public void gxTv_SdtWWP_Entity_Wwpentityid_Z_SetNull( )
      {
         gxTv_SdtWWP_Entity_Wwpentityid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_Entity_Wwpentityid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPEntityName_Z" )]
      [  XmlElement( ElementName = "WWPEntityName_Z"   )]
      public string gxTpr_Wwpentityname_Z
      {
         get {
            return gxTv_SdtWWP_Entity_Wwpentityname_Z ;
         }

         set {
            gxTv_SdtWWP_Entity_Wwpentityname_Z = value;
            SetDirty("Wwpentityname_Z");
         }

      }

      public void gxTv_SdtWWP_Entity_Wwpentityname_Z_SetNull( )
      {
         gxTv_SdtWWP_Entity_Wwpentityname_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_Entity_Wwpentityname_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtWWP_Entity_Wwpentityname = "";
         gxTv_SdtWWP_Entity_Mode = "";
         gxTv_SdtWWP_Entity_Wwpentityname_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "wwpbaseobjects.wwp_entity", "GeneXus.Programs.wwpbaseobjects.wwp_entity_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      private short gxTv_SdtWWP_Entity_Initialized ;
      private long gxTv_SdtWWP_Entity_Wwpentityid ;
      private long gxTv_SdtWWP_Entity_Wwpentityid_Z ;
      private string gxTv_SdtWWP_Entity_Mode ;
      private string gxTv_SdtWWP_Entity_Wwpentityname ;
      private string gxTv_SdtWWP_Entity_Wwpentityname_Z ;
   }

   [DataContract(Name = @"WWPBaseObjects\WWP_Entity", Namespace = "RastreamentoTCC")]
   public class SdtWWP_Entity_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWWP_Entity_RESTInterface( ) : base()
      {
      }

      public SdtWWP_Entity_RESTInterface( GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WWPEntityId" , Order = 0 )]
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

      [DataMember( Name = "WWPEntityName" , Order = 1 )]
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

      public GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 2 )]
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

   [DataContract(Name = @"WWPBaseObjects\WWP_Entity", Namespace = "RastreamentoTCC")]
   public class SdtWWP_Entity_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWWP_Entity_RESTLInterface( ) : base()
      {
      }

      public SdtWWP_Entity_RESTLInterface( GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WWPEntityName" , Order = 0 )]
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

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity() ;
         }
      }

   }

}
