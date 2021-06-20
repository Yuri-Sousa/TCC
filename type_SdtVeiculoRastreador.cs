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
namespace GeneXus.Programs {
   [XmlSerializerFormat]
   [XmlRoot(ElementName = "VeiculoRastreador" )]
   [XmlType(TypeName =  "VeiculoRastreador" , Namespace = "RastreamentoTCC" )]
   [Serializable]
   public class SdtVeiculoRastreador : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtVeiculoRastreador( )
      {
      }

      public SdtVeiculoRastreador( IGxContext context )
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

      public void Load( int AV98VeiculoId ,
                        int AV106RastreadorId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV98VeiculoId,(int)AV106RastreadorId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"VeiculoId", typeof(int)}, new Object[]{"RastreadorId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "VeiculoRastreador");
         metadata.Set("BT", "VeiculoRastreador");
         metadata.Set("PK", "[ \"VeiculoId\",\"RastreadorId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"RastreadorId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"VeiculoId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Veiculoid_Z");
         state.Add("gxTpr_Rastreadorid_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtVeiculoRastreador sdt;
         sdt = (SdtVeiculoRastreador)(source);
         gxTv_SdtVeiculoRastreador_Veiculoid = sdt.gxTv_SdtVeiculoRastreador_Veiculoid ;
         gxTv_SdtVeiculoRastreador_Rastreadorid = sdt.gxTv_SdtVeiculoRastreador_Rastreadorid ;
         gxTv_SdtVeiculoRastreador_Mode = sdt.gxTv_SdtVeiculoRastreador_Mode ;
         gxTv_SdtVeiculoRastreador_Initialized = sdt.gxTv_SdtVeiculoRastreador_Initialized ;
         gxTv_SdtVeiculoRastreador_Veiculoid_Z = sdt.gxTv_SdtVeiculoRastreador_Veiculoid_Z ;
         gxTv_SdtVeiculoRastreador_Rastreadorid_Z = sdt.gxTv_SdtVeiculoRastreador_Rastreadorid_Z ;
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
         AddObjectProperty("VeiculoId", gxTv_SdtVeiculoRastreador_Veiculoid, false, includeNonInitialized);
         AddObjectProperty("RastreadorId", gxTv_SdtVeiculoRastreador_Rastreadorid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtVeiculoRastreador_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtVeiculoRastreador_Initialized, false, includeNonInitialized);
            AddObjectProperty("VeiculoId_Z", gxTv_SdtVeiculoRastreador_Veiculoid_Z, false, includeNonInitialized);
            AddObjectProperty("RastreadorId_Z", gxTv_SdtVeiculoRastreador_Rastreadorid_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtVeiculoRastreador sdt )
      {
         if ( sdt.IsDirty("VeiculoId") )
         {
            gxTv_SdtVeiculoRastreador_Veiculoid = sdt.gxTv_SdtVeiculoRastreador_Veiculoid ;
         }
         if ( sdt.IsDirty("RastreadorId") )
         {
            gxTv_SdtVeiculoRastreador_Rastreadorid = sdt.gxTv_SdtVeiculoRastreador_Rastreadorid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "VeiculoId" )]
      [  XmlElement( ElementName = "VeiculoId"   )]
      public int gxTpr_Veiculoid
      {
         get {
            return gxTv_SdtVeiculoRastreador_Veiculoid ;
         }

         set {
            if ( gxTv_SdtVeiculoRastreador_Veiculoid != value )
            {
               gxTv_SdtVeiculoRastreador_Mode = "INS";
               this.gxTv_SdtVeiculoRastreador_Veiculoid_Z_SetNull( );
               this.gxTv_SdtVeiculoRastreador_Rastreadorid_Z_SetNull( );
            }
            gxTv_SdtVeiculoRastreador_Veiculoid = value;
            SetDirty("Veiculoid");
         }

      }

      [  SoapElement( ElementName = "RastreadorId" )]
      [  XmlElement( ElementName = "RastreadorId"   )]
      public int gxTpr_Rastreadorid
      {
         get {
            return gxTv_SdtVeiculoRastreador_Rastreadorid ;
         }

         set {
            if ( gxTv_SdtVeiculoRastreador_Rastreadorid != value )
            {
               gxTv_SdtVeiculoRastreador_Mode = "INS";
               this.gxTv_SdtVeiculoRastreador_Veiculoid_Z_SetNull( );
               this.gxTv_SdtVeiculoRastreador_Rastreadorid_Z_SetNull( );
            }
            gxTv_SdtVeiculoRastreador_Rastreadorid = value;
            SetDirty("Rastreadorid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtVeiculoRastreador_Mode ;
         }

         set {
            gxTv_SdtVeiculoRastreador_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtVeiculoRastreador_Mode_SetNull( )
      {
         gxTv_SdtVeiculoRastreador_Mode = "";
         return  ;
      }

      public bool gxTv_SdtVeiculoRastreador_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtVeiculoRastreador_Initialized ;
         }

         set {
            gxTv_SdtVeiculoRastreador_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtVeiculoRastreador_Initialized_SetNull( )
      {
         gxTv_SdtVeiculoRastreador_Initialized = 0;
         return  ;
      }

      public bool gxTv_SdtVeiculoRastreador_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VeiculoId_Z" )]
      [  XmlElement( ElementName = "VeiculoId_Z"   )]
      public int gxTpr_Veiculoid_Z
      {
         get {
            return gxTv_SdtVeiculoRastreador_Veiculoid_Z ;
         }

         set {
            gxTv_SdtVeiculoRastreador_Veiculoid_Z = value;
            SetDirty("Veiculoid_Z");
         }

      }

      public void gxTv_SdtVeiculoRastreador_Veiculoid_Z_SetNull( )
      {
         gxTv_SdtVeiculoRastreador_Veiculoid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtVeiculoRastreador_Veiculoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RastreadorId_Z" )]
      [  XmlElement( ElementName = "RastreadorId_Z"   )]
      public int gxTpr_Rastreadorid_Z
      {
         get {
            return gxTv_SdtVeiculoRastreador_Rastreadorid_Z ;
         }

         set {
            gxTv_SdtVeiculoRastreador_Rastreadorid_Z = value;
            SetDirty("Rastreadorid_Z");
         }

      }

      public void gxTv_SdtVeiculoRastreador_Rastreadorid_Z_SetNull( )
      {
         gxTv_SdtVeiculoRastreador_Rastreadorid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtVeiculoRastreador_Rastreadorid_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtVeiculoRastreador_Mode = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "veiculorastreador", "GeneXus.Programs.veiculorastreador_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      private short gxTv_SdtVeiculoRastreador_Initialized ;
      private int gxTv_SdtVeiculoRastreador_Veiculoid ;
      private int gxTv_SdtVeiculoRastreador_Rastreadorid ;
      private int gxTv_SdtVeiculoRastreador_Veiculoid_Z ;
      private int gxTv_SdtVeiculoRastreador_Rastreadorid_Z ;
      private string gxTv_SdtVeiculoRastreador_Mode ;
   }

   [DataContract(Name = @"VeiculoRastreador", Namespace = "RastreamentoTCC")]
   public class SdtVeiculoRastreador_RESTInterface : GxGenericCollectionItem<SdtVeiculoRastreador>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtVeiculoRastreador_RESTInterface( ) : base()
      {
      }

      public SdtVeiculoRastreador_RESTInterface( SdtVeiculoRastreador psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "VeiculoId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Veiculoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Veiculoid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Veiculoid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "RastreadorId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Rastreadorid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Rastreadorid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Rastreadorid = (int)(NumberUtil.Val( value, "."));
         }

      }

      public SdtVeiculoRastreador sdt
      {
         get {
            return (SdtVeiculoRastreador)Sdt ;
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
            sdt = new SdtVeiculoRastreador() ;
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

   [DataContract(Name = @"VeiculoRastreador", Namespace = "RastreamentoTCC")]
   public class SdtVeiculoRastreador_RESTLInterface : GxGenericCollectionItem<SdtVeiculoRastreador>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtVeiculoRastreador_RESTLInterface( ) : base()
      {
      }

      public SdtVeiculoRastreador_RESTLInterface( SdtVeiculoRastreador psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "uri", Order = 0 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtVeiculoRastreador sdt
      {
         get {
            return (SdtVeiculoRastreador)Sdt ;
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
            sdt = new SdtVeiculoRastreador() ;
         }
      }

   }

}
