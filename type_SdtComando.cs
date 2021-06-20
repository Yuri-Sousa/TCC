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
   [XmlRoot(ElementName = "Comando" )]
   [XmlType(TypeName =  "Comando" , Namespace = "RastreamentoTCC" )]
   [Serializable]
   public class SdtComando : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtComando( )
      {
      }

      public SdtComando( IGxContext context )
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

      public void Load( int AV137ComandoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV137ComandoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ComandoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Comando");
         metadata.Set("BT", "Comando");
         metadata.Set("PK", "[ \"ComandoId\" ]");
         metadata.Set("PKAssigned", "[ \"ComandoId\" ]");
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
         state.Add("gxTpr_Comandoid_Z");
         state.Add("gxTpr_Comandonome_Z");
         state.Add("gxTpr_Comandodescricao_Z");
         state.Add("gxTpr_Comandofabricantemodulo_Z");
         state.Add("gxTpr_Comandomodelomodulo_Z");
         state.Add("gxTpr_Comandoparameter_id_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtComando sdt;
         sdt = (SdtComando)(source);
         gxTv_SdtComando_Comandoid = sdt.gxTv_SdtComando_Comandoid ;
         gxTv_SdtComando_Comandonome = sdt.gxTv_SdtComando_Comandonome ;
         gxTv_SdtComando_Comandodescricao = sdt.gxTv_SdtComando_Comandodescricao ;
         gxTv_SdtComando_Comandofabricantemodulo = sdt.gxTv_SdtComando_Comandofabricantemodulo ;
         gxTv_SdtComando_Comandomodelomodulo = sdt.gxTv_SdtComando_Comandomodelomodulo ;
         gxTv_SdtComando_Comandopayload = sdt.gxTv_SdtComando_Comandopayload ;
         gxTv_SdtComando_Comandoparameter_id = sdt.gxTv_SdtComando_Comandoparameter_id ;
         gxTv_SdtComando_Mode = sdt.gxTv_SdtComando_Mode ;
         gxTv_SdtComando_Initialized = sdt.gxTv_SdtComando_Initialized ;
         gxTv_SdtComando_Comandoid_Z = sdt.gxTv_SdtComando_Comandoid_Z ;
         gxTv_SdtComando_Comandonome_Z = sdt.gxTv_SdtComando_Comandonome_Z ;
         gxTv_SdtComando_Comandodescricao_Z = sdt.gxTv_SdtComando_Comandodescricao_Z ;
         gxTv_SdtComando_Comandofabricantemodulo_Z = sdt.gxTv_SdtComando_Comandofabricantemodulo_Z ;
         gxTv_SdtComando_Comandomodelomodulo_Z = sdt.gxTv_SdtComando_Comandomodelomodulo_Z ;
         gxTv_SdtComando_Comandoparameter_id_Z = sdt.gxTv_SdtComando_Comandoparameter_id_Z ;
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
         AddObjectProperty("ComandoId", gxTv_SdtComando_Comandoid, false, includeNonInitialized);
         AddObjectProperty("ComandoNome", gxTv_SdtComando_Comandonome, false, includeNonInitialized);
         AddObjectProperty("ComandoDescricao", gxTv_SdtComando_Comandodescricao, false, includeNonInitialized);
         AddObjectProperty("ComandoFabricanteModulo", gxTv_SdtComando_Comandofabricantemodulo, false, includeNonInitialized);
         AddObjectProperty("ComandoModeloModulo", gxTv_SdtComando_Comandomodelomodulo, false, includeNonInitialized);
         AddObjectProperty("ComandoPayload", gxTv_SdtComando_Comandopayload, false, includeNonInitialized);
         AddObjectProperty("ComandoParameter_Id", gxTv_SdtComando_Comandoparameter_id, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtComando_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtComando_Initialized, false, includeNonInitialized);
            AddObjectProperty("ComandoId_Z", gxTv_SdtComando_Comandoid_Z, false, includeNonInitialized);
            AddObjectProperty("ComandoNome_Z", gxTv_SdtComando_Comandonome_Z, false, includeNonInitialized);
            AddObjectProperty("ComandoDescricao_Z", gxTv_SdtComando_Comandodescricao_Z, false, includeNonInitialized);
            AddObjectProperty("ComandoFabricanteModulo_Z", gxTv_SdtComando_Comandofabricantemodulo_Z, false, includeNonInitialized);
            AddObjectProperty("ComandoModeloModulo_Z", gxTv_SdtComando_Comandomodelomodulo_Z, false, includeNonInitialized);
            AddObjectProperty("ComandoParameter_Id_Z", gxTv_SdtComando_Comandoparameter_id_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtComando sdt )
      {
         if ( sdt.IsDirty("ComandoId") )
         {
            gxTv_SdtComando_Comandoid = sdt.gxTv_SdtComando_Comandoid ;
         }
         if ( sdt.IsDirty("ComandoNome") )
         {
            gxTv_SdtComando_Comandonome = sdt.gxTv_SdtComando_Comandonome ;
         }
         if ( sdt.IsDirty("ComandoDescricao") )
         {
            gxTv_SdtComando_Comandodescricao = sdt.gxTv_SdtComando_Comandodescricao ;
         }
         if ( sdt.IsDirty("ComandoFabricanteModulo") )
         {
            gxTv_SdtComando_Comandofabricantemodulo = sdt.gxTv_SdtComando_Comandofabricantemodulo ;
         }
         if ( sdt.IsDirty("ComandoModeloModulo") )
         {
            gxTv_SdtComando_Comandomodelomodulo = sdt.gxTv_SdtComando_Comandomodelomodulo ;
         }
         if ( sdt.IsDirty("ComandoPayload") )
         {
            gxTv_SdtComando_Comandopayload = sdt.gxTv_SdtComando_Comandopayload ;
         }
         if ( sdt.IsDirty("ComandoParameter_Id") )
         {
            gxTv_SdtComando_Comandoparameter_id = sdt.gxTv_SdtComando_Comandoparameter_id ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ComandoId" )]
      [  XmlElement( ElementName = "ComandoId"   )]
      public int gxTpr_Comandoid
      {
         get {
            return gxTv_SdtComando_Comandoid ;
         }

         set {
            if ( gxTv_SdtComando_Comandoid != value )
            {
               gxTv_SdtComando_Mode = "INS";
               this.gxTv_SdtComando_Comandoid_Z_SetNull( );
               this.gxTv_SdtComando_Comandonome_Z_SetNull( );
               this.gxTv_SdtComando_Comandodescricao_Z_SetNull( );
               this.gxTv_SdtComando_Comandofabricantemodulo_Z_SetNull( );
               this.gxTv_SdtComando_Comandomodelomodulo_Z_SetNull( );
               this.gxTv_SdtComando_Comandoparameter_id_Z_SetNull( );
            }
            gxTv_SdtComando_Comandoid = value;
            SetDirty("Comandoid");
         }

      }

      [  SoapElement( ElementName = "ComandoNome" )]
      [  XmlElement( ElementName = "ComandoNome"   )]
      public string gxTpr_Comandonome
      {
         get {
            return gxTv_SdtComando_Comandonome ;
         }

         set {
            gxTv_SdtComando_Comandonome = value;
            SetDirty("Comandonome");
         }

      }

      [  SoapElement( ElementName = "ComandoDescricao" )]
      [  XmlElement( ElementName = "ComandoDescricao"   )]
      public string gxTpr_Comandodescricao
      {
         get {
            return gxTv_SdtComando_Comandodescricao ;
         }

         set {
            gxTv_SdtComando_Comandodescricao = value;
            SetDirty("Comandodescricao");
         }

      }

      [  SoapElement( ElementName = "ComandoFabricanteModulo" )]
      [  XmlElement( ElementName = "ComandoFabricanteModulo"   )]
      public string gxTpr_Comandofabricantemodulo
      {
         get {
            return gxTv_SdtComando_Comandofabricantemodulo ;
         }

         set {
            gxTv_SdtComando_Comandofabricantemodulo = value;
            SetDirty("Comandofabricantemodulo");
         }

      }

      [  SoapElement( ElementName = "ComandoModeloModulo" )]
      [  XmlElement( ElementName = "ComandoModeloModulo"   )]
      public string gxTpr_Comandomodelomodulo
      {
         get {
            return gxTv_SdtComando_Comandomodelomodulo ;
         }

         set {
            gxTv_SdtComando_Comandomodelomodulo = value;
            SetDirty("Comandomodelomodulo");
         }

      }

      [  SoapElement( ElementName = "ComandoPayload" )]
      [  XmlElement( ElementName = "ComandoPayload"   )]
      public string gxTpr_Comandopayload
      {
         get {
            return gxTv_SdtComando_Comandopayload ;
         }

         set {
            gxTv_SdtComando_Comandopayload = value;
            SetDirty("Comandopayload");
         }

      }

      [  SoapElement( ElementName = "ComandoParameter_Id" )]
      [  XmlElement( ElementName = "ComandoParameter_Id"   )]
      public string gxTpr_Comandoparameter_id
      {
         get {
            return gxTv_SdtComando_Comandoparameter_id ;
         }

         set {
            gxTv_SdtComando_Comandoparameter_id = value;
            SetDirty("Comandoparameter_id");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtComando_Mode ;
         }

         set {
            gxTv_SdtComando_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtComando_Mode_SetNull( )
      {
         gxTv_SdtComando_Mode = "";
         return  ;
      }

      public bool gxTv_SdtComando_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtComando_Initialized ;
         }

         set {
            gxTv_SdtComando_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtComando_Initialized_SetNull( )
      {
         gxTv_SdtComando_Initialized = 0;
         return  ;
      }

      public bool gxTv_SdtComando_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ComandoId_Z" )]
      [  XmlElement( ElementName = "ComandoId_Z"   )]
      public int gxTpr_Comandoid_Z
      {
         get {
            return gxTv_SdtComando_Comandoid_Z ;
         }

         set {
            gxTv_SdtComando_Comandoid_Z = value;
            SetDirty("Comandoid_Z");
         }

      }

      public void gxTv_SdtComando_Comandoid_Z_SetNull( )
      {
         gxTv_SdtComando_Comandoid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtComando_Comandoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ComandoNome_Z" )]
      [  XmlElement( ElementName = "ComandoNome_Z"   )]
      public string gxTpr_Comandonome_Z
      {
         get {
            return gxTv_SdtComando_Comandonome_Z ;
         }

         set {
            gxTv_SdtComando_Comandonome_Z = value;
            SetDirty("Comandonome_Z");
         }

      }

      public void gxTv_SdtComando_Comandonome_Z_SetNull( )
      {
         gxTv_SdtComando_Comandonome_Z = "";
         return  ;
      }

      public bool gxTv_SdtComando_Comandonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ComandoDescricao_Z" )]
      [  XmlElement( ElementName = "ComandoDescricao_Z"   )]
      public string gxTpr_Comandodescricao_Z
      {
         get {
            return gxTv_SdtComando_Comandodescricao_Z ;
         }

         set {
            gxTv_SdtComando_Comandodescricao_Z = value;
            SetDirty("Comandodescricao_Z");
         }

      }

      public void gxTv_SdtComando_Comandodescricao_Z_SetNull( )
      {
         gxTv_SdtComando_Comandodescricao_Z = "";
         return  ;
      }

      public bool gxTv_SdtComando_Comandodescricao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ComandoFabricanteModulo_Z" )]
      [  XmlElement( ElementName = "ComandoFabricanteModulo_Z"   )]
      public string gxTpr_Comandofabricantemodulo_Z
      {
         get {
            return gxTv_SdtComando_Comandofabricantemodulo_Z ;
         }

         set {
            gxTv_SdtComando_Comandofabricantemodulo_Z = value;
            SetDirty("Comandofabricantemodulo_Z");
         }

      }

      public void gxTv_SdtComando_Comandofabricantemodulo_Z_SetNull( )
      {
         gxTv_SdtComando_Comandofabricantemodulo_Z = "";
         return  ;
      }

      public bool gxTv_SdtComando_Comandofabricantemodulo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ComandoModeloModulo_Z" )]
      [  XmlElement( ElementName = "ComandoModeloModulo_Z"   )]
      public string gxTpr_Comandomodelomodulo_Z
      {
         get {
            return gxTv_SdtComando_Comandomodelomodulo_Z ;
         }

         set {
            gxTv_SdtComando_Comandomodelomodulo_Z = value;
            SetDirty("Comandomodelomodulo_Z");
         }

      }

      public void gxTv_SdtComando_Comandomodelomodulo_Z_SetNull( )
      {
         gxTv_SdtComando_Comandomodelomodulo_Z = "";
         return  ;
      }

      public bool gxTv_SdtComando_Comandomodelomodulo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ComandoParameter_Id_Z" )]
      [  XmlElement( ElementName = "ComandoParameter_Id_Z"   )]
      public string gxTpr_Comandoparameter_id_Z
      {
         get {
            return gxTv_SdtComando_Comandoparameter_id_Z ;
         }

         set {
            gxTv_SdtComando_Comandoparameter_id_Z = value;
            SetDirty("Comandoparameter_id_Z");
         }

      }

      public void gxTv_SdtComando_Comandoparameter_id_Z_SetNull( )
      {
         gxTv_SdtComando_Comandoparameter_id_Z = "";
         return  ;
      }

      public bool gxTv_SdtComando_Comandoparameter_id_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtComando_Comandonome = "";
         gxTv_SdtComando_Comandodescricao = "";
         gxTv_SdtComando_Comandofabricantemodulo = "";
         gxTv_SdtComando_Comandomodelomodulo = "";
         gxTv_SdtComando_Comandopayload = "";
         gxTv_SdtComando_Comandoparameter_id = "";
         gxTv_SdtComando_Mode = "";
         gxTv_SdtComando_Comandonome_Z = "";
         gxTv_SdtComando_Comandodescricao_Z = "";
         gxTv_SdtComando_Comandofabricantemodulo_Z = "";
         gxTv_SdtComando_Comandomodelomodulo_Z = "";
         gxTv_SdtComando_Comandoparameter_id_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "comando", "GeneXus.Programs.comando_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      private short gxTv_SdtComando_Initialized ;
      private int gxTv_SdtComando_Comandoid ;
      private int gxTv_SdtComando_Comandoid_Z ;
      private string gxTv_SdtComando_Mode ;
      private string gxTv_SdtComando_Comandopayload ;
      private string gxTv_SdtComando_Comandonome ;
      private string gxTv_SdtComando_Comandodescricao ;
      private string gxTv_SdtComando_Comandofabricantemodulo ;
      private string gxTv_SdtComando_Comandomodelomodulo ;
      private string gxTv_SdtComando_Comandoparameter_id ;
      private string gxTv_SdtComando_Comandonome_Z ;
      private string gxTv_SdtComando_Comandodescricao_Z ;
      private string gxTv_SdtComando_Comandofabricantemodulo_Z ;
      private string gxTv_SdtComando_Comandomodelomodulo_Z ;
      private string gxTv_SdtComando_Comandoparameter_id_Z ;
   }

   [DataContract(Name = @"Comando", Namespace = "RastreamentoTCC")]
   public class SdtComando_RESTInterface : GxGenericCollectionItem<SdtComando>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtComando_RESTInterface( ) : base()
      {
      }

      public SdtComando_RESTInterface( SdtComando psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ComandoId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Comandoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Comandoid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Comandoid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "ComandoNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Comandonome
      {
         get {
            return sdt.gxTpr_Comandonome ;
         }

         set {
            sdt.gxTpr_Comandonome = value;
         }

      }

      [DataMember( Name = "ComandoDescricao" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Comandodescricao
      {
         get {
            return sdt.gxTpr_Comandodescricao ;
         }

         set {
            sdt.gxTpr_Comandodescricao = value;
         }

      }

      [DataMember( Name = "ComandoFabricanteModulo" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Comandofabricantemodulo
      {
         get {
            return sdt.gxTpr_Comandofabricantemodulo ;
         }

         set {
            sdt.gxTpr_Comandofabricantemodulo = value;
         }

      }

      [DataMember( Name = "ComandoModeloModulo" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Comandomodelomodulo
      {
         get {
            return sdt.gxTpr_Comandomodelomodulo ;
         }

         set {
            sdt.gxTpr_Comandomodelomodulo = value;
         }

      }

      [DataMember( Name = "ComandoPayload" , Order = 5 )]
      public string gxTpr_Comandopayload
      {
         get {
            return sdt.gxTpr_Comandopayload ;
         }

         set {
            sdt.gxTpr_Comandopayload = value;
         }

      }

      [DataMember( Name = "ComandoParameter_Id" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Comandoparameter_id
      {
         get {
            return sdt.gxTpr_Comandoparameter_id ;
         }

         set {
            sdt.gxTpr_Comandoparameter_id = value;
         }

      }

      public SdtComando sdt
      {
         get {
            return (SdtComando)Sdt ;
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
            sdt = new SdtComando() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 7 )]
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

   [DataContract(Name = @"Comando", Namespace = "RastreamentoTCC")]
   public class SdtComando_RESTLInterface : GxGenericCollectionItem<SdtComando>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtComando_RESTLInterface( ) : base()
      {
      }

      public SdtComando_RESTLInterface( SdtComando psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ComandoNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Comandonome
      {
         get {
            return sdt.gxTpr_Comandonome ;
         }

         set {
            sdt.gxTpr_Comandonome = value;
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

      public SdtComando sdt
      {
         get {
            return (SdtComando)Sdt ;
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
            sdt = new SdtComando() ;
         }
      }

   }

}
