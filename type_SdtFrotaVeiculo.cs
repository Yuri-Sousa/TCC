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
   [XmlRoot(ElementName = "FrotaVeiculo" )]
   [XmlType(TypeName =  "FrotaVeiculo" , Namespace = "RastreamentoTCC" )]
   [Serializable]
   public class SdtFrotaVeiculo : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtFrotaVeiculo( )
      {
      }

      public SdtFrotaVeiculo( IGxContext context )
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

      public void Load( int AV93FrotaId ,
                        int AV98VeiculoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV93FrotaId,(int)AV98VeiculoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"FrotaId", typeof(int)}, new Object[]{"VeiculoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "FrotaVeiculo");
         metadata.Set("BT", "FrotaVeiculo");
         metadata.Set("PK", "[ \"FrotaId\",\"VeiculoId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"FrotaId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"VeiculoId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Frotaid_Z");
         state.Add("gxTpr_Veiculoid_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtFrotaVeiculo sdt;
         sdt = (SdtFrotaVeiculo)(source);
         gxTv_SdtFrotaVeiculo_Frotaid = sdt.gxTv_SdtFrotaVeiculo_Frotaid ;
         gxTv_SdtFrotaVeiculo_Veiculoid = sdt.gxTv_SdtFrotaVeiculo_Veiculoid ;
         gxTv_SdtFrotaVeiculo_Mode = sdt.gxTv_SdtFrotaVeiculo_Mode ;
         gxTv_SdtFrotaVeiculo_Initialized = sdt.gxTv_SdtFrotaVeiculo_Initialized ;
         gxTv_SdtFrotaVeiculo_Frotaid_Z = sdt.gxTv_SdtFrotaVeiculo_Frotaid_Z ;
         gxTv_SdtFrotaVeiculo_Veiculoid_Z = sdt.gxTv_SdtFrotaVeiculo_Veiculoid_Z ;
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
         AddObjectProperty("FrotaId", gxTv_SdtFrotaVeiculo_Frotaid, false, includeNonInitialized);
         AddObjectProperty("VeiculoId", gxTv_SdtFrotaVeiculo_Veiculoid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtFrotaVeiculo_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtFrotaVeiculo_Initialized, false, includeNonInitialized);
            AddObjectProperty("FrotaId_Z", gxTv_SdtFrotaVeiculo_Frotaid_Z, false, includeNonInitialized);
            AddObjectProperty("VeiculoId_Z", gxTv_SdtFrotaVeiculo_Veiculoid_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtFrotaVeiculo sdt )
      {
         if ( sdt.IsDirty("FrotaId") )
         {
            gxTv_SdtFrotaVeiculo_Frotaid = sdt.gxTv_SdtFrotaVeiculo_Frotaid ;
         }
         if ( sdt.IsDirty("VeiculoId") )
         {
            gxTv_SdtFrotaVeiculo_Veiculoid = sdt.gxTv_SdtFrotaVeiculo_Veiculoid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "FrotaId" )]
      [  XmlElement( ElementName = "FrotaId"   )]
      public int gxTpr_Frotaid
      {
         get {
            return gxTv_SdtFrotaVeiculo_Frotaid ;
         }

         set {
            if ( gxTv_SdtFrotaVeiculo_Frotaid != value )
            {
               gxTv_SdtFrotaVeiculo_Mode = "INS";
               this.gxTv_SdtFrotaVeiculo_Frotaid_Z_SetNull( );
               this.gxTv_SdtFrotaVeiculo_Veiculoid_Z_SetNull( );
            }
            gxTv_SdtFrotaVeiculo_Frotaid = value;
            SetDirty("Frotaid");
         }

      }

      [  SoapElement( ElementName = "VeiculoId" )]
      [  XmlElement( ElementName = "VeiculoId"   )]
      public int gxTpr_Veiculoid
      {
         get {
            return gxTv_SdtFrotaVeiculo_Veiculoid ;
         }

         set {
            if ( gxTv_SdtFrotaVeiculo_Veiculoid != value )
            {
               gxTv_SdtFrotaVeiculo_Mode = "INS";
               this.gxTv_SdtFrotaVeiculo_Frotaid_Z_SetNull( );
               this.gxTv_SdtFrotaVeiculo_Veiculoid_Z_SetNull( );
            }
            gxTv_SdtFrotaVeiculo_Veiculoid = value;
            SetDirty("Veiculoid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtFrotaVeiculo_Mode ;
         }

         set {
            gxTv_SdtFrotaVeiculo_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtFrotaVeiculo_Mode_SetNull( )
      {
         gxTv_SdtFrotaVeiculo_Mode = "";
         return  ;
      }

      public bool gxTv_SdtFrotaVeiculo_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtFrotaVeiculo_Initialized ;
         }

         set {
            gxTv_SdtFrotaVeiculo_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtFrotaVeiculo_Initialized_SetNull( )
      {
         gxTv_SdtFrotaVeiculo_Initialized = 0;
         return  ;
      }

      public bool gxTv_SdtFrotaVeiculo_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FrotaId_Z" )]
      [  XmlElement( ElementName = "FrotaId_Z"   )]
      public int gxTpr_Frotaid_Z
      {
         get {
            return gxTv_SdtFrotaVeiculo_Frotaid_Z ;
         }

         set {
            gxTv_SdtFrotaVeiculo_Frotaid_Z = value;
            SetDirty("Frotaid_Z");
         }

      }

      public void gxTv_SdtFrotaVeiculo_Frotaid_Z_SetNull( )
      {
         gxTv_SdtFrotaVeiculo_Frotaid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtFrotaVeiculo_Frotaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VeiculoId_Z" )]
      [  XmlElement( ElementName = "VeiculoId_Z"   )]
      public int gxTpr_Veiculoid_Z
      {
         get {
            return gxTv_SdtFrotaVeiculo_Veiculoid_Z ;
         }

         set {
            gxTv_SdtFrotaVeiculo_Veiculoid_Z = value;
            SetDirty("Veiculoid_Z");
         }

      }

      public void gxTv_SdtFrotaVeiculo_Veiculoid_Z_SetNull( )
      {
         gxTv_SdtFrotaVeiculo_Veiculoid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtFrotaVeiculo_Veiculoid_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtFrotaVeiculo_Mode = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "frotaveiculo", "GeneXus.Programs.frotaveiculo_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      private short gxTv_SdtFrotaVeiculo_Initialized ;
      private int gxTv_SdtFrotaVeiculo_Frotaid ;
      private int gxTv_SdtFrotaVeiculo_Veiculoid ;
      private int gxTv_SdtFrotaVeiculo_Frotaid_Z ;
      private int gxTv_SdtFrotaVeiculo_Veiculoid_Z ;
      private string gxTv_SdtFrotaVeiculo_Mode ;
   }

   [DataContract(Name = @"FrotaVeiculo", Namespace = "RastreamentoTCC")]
   public class SdtFrotaVeiculo_RESTInterface : GxGenericCollectionItem<SdtFrotaVeiculo>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtFrotaVeiculo_RESTInterface( ) : base()
      {
      }

      public SdtFrotaVeiculo_RESTInterface( SdtFrotaVeiculo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "FrotaId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Frotaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Frotaid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Frotaid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "VeiculoId" , Order = 1 )]
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

      public SdtFrotaVeiculo sdt
      {
         get {
            return (SdtFrotaVeiculo)Sdt ;
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
            sdt = new SdtFrotaVeiculo() ;
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

   [DataContract(Name = @"FrotaVeiculo", Namespace = "RastreamentoTCC")]
   public class SdtFrotaVeiculo_RESTLInterface : GxGenericCollectionItem<SdtFrotaVeiculo>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtFrotaVeiculo_RESTLInterface( ) : base()
      {
      }

      public SdtFrotaVeiculo_RESTLInterface( SdtFrotaVeiculo psdt ) : base(psdt)
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

      public SdtFrotaVeiculo sdt
      {
         get {
            return (SdtFrotaVeiculo)Sdt ;
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
            sdt = new SdtFrotaVeiculo() ;
         }
      }

   }

}
