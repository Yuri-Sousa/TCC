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
   [XmlRoot(ElementName = "ComandoEnviado.Comando" )]
   [XmlType(TypeName =  "ComandoEnviado.Comando" , Namespace = "RastreamentoTCC" )]
   [Serializable]
   public class SdtComandoEnviado_Comando : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtComandoEnviado_Comando( )
      {
      }

      public SdtComandoEnviado_Comando( IGxContext context )
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

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ComandoEnviadoComandoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Comando");
         metadata.Set("BT", "ComandoEnviadoComando");
         metadata.Set("PK", "[ \"ComandoEnviadoComandoId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ComandoEnviadoId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Modified");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Comandoenviadocomandoid_Z");
         state.Add("gxTpr_Comandoenviadocomandocomando_Z");
         state.Add("gxTpr_Comandoenviadocomandovalor_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtComandoEnviado_Comando sdt;
         sdt = (SdtComandoEnviado_Comando)(source);
         gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandoid = sdt.gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandoid ;
         gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandocomando = sdt.gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandocomando ;
         gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandovalor = sdt.gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandovalor ;
         gxTv_SdtComandoEnviado_Comando_Mode = sdt.gxTv_SdtComandoEnviado_Comando_Mode ;
         gxTv_SdtComandoEnviado_Comando_Modified = sdt.gxTv_SdtComandoEnviado_Comando_Modified ;
         gxTv_SdtComandoEnviado_Comando_Initialized = sdt.gxTv_SdtComandoEnviado_Comando_Initialized ;
         gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandoid_Z = sdt.gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandoid_Z ;
         gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandocomando_Z = sdt.gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandocomando_Z ;
         gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandovalor_Z = sdt.gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandovalor_Z ;
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
         AddObjectProperty("ComandoEnviadoComandoId", gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandoid, false, includeNonInitialized);
         AddObjectProperty("ComandoEnviadoComandoComando", gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandocomando, false, includeNonInitialized);
         AddObjectProperty("ComandoEnviadoComandoValor", gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandovalor, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtComandoEnviado_Comando_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtComandoEnviado_Comando_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtComandoEnviado_Comando_Initialized, false, includeNonInitialized);
            AddObjectProperty("ComandoEnviadoComandoId_Z", gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandoid_Z, false, includeNonInitialized);
            AddObjectProperty("ComandoEnviadoComandoComando_Z", gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandocomando_Z, false, includeNonInitialized);
            AddObjectProperty("ComandoEnviadoComandoValor_Z", gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandovalor_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtComandoEnviado_Comando sdt )
      {
         if ( sdt.IsDirty("ComandoEnviadoComandoId") )
         {
            gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandoid = sdt.gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandoid ;
         }
         if ( sdt.IsDirty("ComandoEnviadoComandoComando") )
         {
            gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandocomando = sdt.gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandocomando ;
         }
         if ( sdt.IsDirty("ComandoEnviadoComandoValor") )
         {
            gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandovalor = sdt.gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandovalor ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ComandoEnviadoComandoId" )]
      [  XmlElement( ElementName = "ComandoEnviadoComandoId"   )]
      public int gxTpr_Comandoenviadocomandoid
      {
         get {
            return gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandoid ;
         }

         set {
            gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandoid = value;
            gxTv_SdtComandoEnviado_Comando_Modified = 1;
            SetDirty("Comandoenviadocomandoid");
         }

      }

      [  SoapElement( ElementName = "ComandoEnviadoComandoComando" )]
      [  XmlElement( ElementName = "ComandoEnviadoComandoComando"   )]
      public string gxTpr_Comandoenviadocomandocomando
      {
         get {
            return gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandocomando ;
         }

         set {
            gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandocomando = value;
            gxTv_SdtComandoEnviado_Comando_Modified = 1;
            SetDirty("Comandoenviadocomandocomando");
         }

      }

      [  SoapElement( ElementName = "ComandoEnviadoComandoValor" )]
      [  XmlElement( ElementName = "ComandoEnviadoComandoValor"   )]
      public string gxTpr_Comandoenviadocomandovalor
      {
         get {
            return gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandovalor ;
         }

         set {
            gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandovalor = value;
            gxTv_SdtComandoEnviado_Comando_Modified = 1;
            SetDirty("Comandoenviadocomandovalor");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtComandoEnviado_Comando_Mode ;
         }

         set {
            gxTv_SdtComandoEnviado_Comando_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtComandoEnviado_Comando_Mode_SetNull( )
      {
         gxTv_SdtComandoEnviado_Comando_Mode = "";
         return  ;
      }

      public bool gxTv_SdtComandoEnviado_Comando_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtComandoEnviado_Comando_Modified ;
         }

         set {
            gxTv_SdtComandoEnviado_Comando_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtComandoEnviado_Comando_Modified_SetNull( )
      {
         gxTv_SdtComandoEnviado_Comando_Modified = 0;
         return  ;
      }

      public bool gxTv_SdtComandoEnviado_Comando_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtComandoEnviado_Comando_Initialized ;
         }

         set {
            gxTv_SdtComandoEnviado_Comando_Initialized = value;
            gxTv_SdtComandoEnviado_Comando_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtComandoEnviado_Comando_Initialized_SetNull( )
      {
         gxTv_SdtComandoEnviado_Comando_Initialized = 0;
         return  ;
      }

      public bool gxTv_SdtComandoEnviado_Comando_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ComandoEnviadoComandoId_Z" )]
      [  XmlElement( ElementName = "ComandoEnviadoComandoId_Z"   )]
      public int gxTpr_Comandoenviadocomandoid_Z
      {
         get {
            return gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandoid_Z ;
         }

         set {
            gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandoid_Z = value;
            gxTv_SdtComandoEnviado_Comando_Modified = 1;
            SetDirty("Comandoenviadocomandoid_Z");
         }

      }

      public void gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandoid_Z_SetNull( )
      {
         gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandoid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ComandoEnviadoComandoComando_Z" )]
      [  XmlElement( ElementName = "ComandoEnviadoComandoComando_Z"   )]
      public string gxTpr_Comandoenviadocomandocomando_Z
      {
         get {
            return gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandocomando_Z ;
         }

         set {
            gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandocomando_Z = value;
            gxTv_SdtComandoEnviado_Comando_Modified = 1;
            SetDirty("Comandoenviadocomandocomando_Z");
         }

      }

      public void gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandocomando_Z_SetNull( )
      {
         gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandocomando_Z = "";
         return  ;
      }

      public bool gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandocomando_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ComandoEnviadoComandoValor_Z" )]
      [  XmlElement( ElementName = "ComandoEnviadoComandoValor_Z"   )]
      public string gxTpr_Comandoenviadocomandovalor_Z
      {
         get {
            return gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandovalor_Z ;
         }

         set {
            gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandovalor_Z = value;
            gxTv_SdtComandoEnviado_Comando_Modified = 1;
            SetDirty("Comandoenviadocomandovalor_Z");
         }

      }

      public void gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandovalor_Z_SetNull( )
      {
         gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandovalor_Z = "";
         return  ;
      }

      public bool gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandovalor_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandocomando = "";
         gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandovalor = "";
         gxTv_SdtComandoEnviado_Comando_Mode = "";
         gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandocomando_Z = "";
         gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandovalor_Z = "";
         return  ;
      }

      private short gxTv_SdtComandoEnviado_Comando_Modified ;
      private short gxTv_SdtComandoEnviado_Comando_Initialized ;
      private int gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandoid ;
      private int gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandoid_Z ;
      private string gxTv_SdtComandoEnviado_Comando_Mode ;
      private string gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandocomando ;
      private string gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandovalor ;
      private string gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandocomando_Z ;
      private string gxTv_SdtComandoEnviado_Comando_Comandoenviadocomandovalor_Z ;
   }

   [DataContract(Name = @"ComandoEnviado.Comando", Namespace = "RastreamentoTCC")]
   public class SdtComandoEnviado_Comando_RESTInterface : GxGenericCollectionItem<SdtComandoEnviado_Comando>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtComandoEnviado_Comando_RESTInterface( ) : base()
      {
      }

      public SdtComandoEnviado_Comando_RESTInterface( SdtComandoEnviado_Comando psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ComandoEnviadoComandoId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Comandoenviadocomandoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Comandoenviadocomandoid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Comandoenviadocomandoid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "ComandoEnviadoComandoComando" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Comandoenviadocomandocomando
      {
         get {
            return sdt.gxTpr_Comandoenviadocomandocomando ;
         }

         set {
            sdt.gxTpr_Comandoenviadocomandocomando = value;
         }

      }

      [DataMember( Name = "ComandoEnviadoComandoValor" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Comandoenviadocomandovalor
      {
         get {
            return sdt.gxTpr_Comandoenviadocomandovalor ;
         }

         set {
            sdt.gxTpr_Comandoenviadocomandovalor = value;
         }

      }

      public SdtComandoEnviado_Comando sdt
      {
         get {
            return (SdtComandoEnviado_Comando)Sdt ;
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
            sdt = new SdtComandoEnviado_Comando() ;
         }
      }

   }

   [DataContract(Name = @"ComandoEnviado.Comando", Namespace = "RastreamentoTCC")]
   public class SdtComandoEnviado_Comando_RESTLInterface : GxGenericCollectionItem<SdtComandoEnviado_Comando>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtComandoEnviado_Comando_RESTLInterface( ) : base()
      {
      }

      public SdtComandoEnviado_Comando_RESTLInterface( SdtComandoEnviado_Comando psdt ) : base(psdt)
      {
      }

      public SdtComandoEnviado_Comando sdt
      {
         get {
            return (SdtComandoEnviado_Comando)Sdt ;
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
            sdt = new SdtComandoEnviado_Comando() ;
         }
      }

   }

}
