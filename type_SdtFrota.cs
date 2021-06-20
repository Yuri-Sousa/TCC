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
   [XmlRoot(ElementName = "Frota" )]
   [XmlType(TypeName =  "Frota" , Namespace = "RastreamentoTCC" )]
   [Serializable]
   public class SdtFrota : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtFrota( )
      {
      }

      public SdtFrota( IGxContext context )
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

      public void Load( int AV93FrotaId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV93FrotaId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"FrotaId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Frota");
         metadata.Set("BT", "Frota");
         metadata.Set("PK", "[ \"FrotaId\" ]");
         metadata.Set("PKAssigned", "[ \"FrotaId\" ]");
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
         state.Add("gxTpr_Frotadatahoracriacao_Z_Nullable");
         state.Add("gxTpr_Frotanome_Z");
         state.Add("gxTpr_Frotaproprietariogamguid_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtFrota sdt;
         sdt = (SdtFrota)(source);
         gxTv_SdtFrota_Frotaid = sdt.gxTv_SdtFrota_Frotaid ;
         gxTv_SdtFrota_Frotadatahoracriacao = sdt.gxTv_SdtFrota_Frotadatahoracriacao ;
         gxTv_SdtFrota_Frotanome = sdt.gxTv_SdtFrota_Frotanome ;
         gxTv_SdtFrota_Frotaproprietariogamguid = sdt.gxTv_SdtFrota_Frotaproprietariogamguid ;
         gxTv_SdtFrota_Mode = sdt.gxTv_SdtFrota_Mode ;
         gxTv_SdtFrota_Initialized = sdt.gxTv_SdtFrota_Initialized ;
         gxTv_SdtFrota_Frotaid_Z = sdt.gxTv_SdtFrota_Frotaid_Z ;
         gxTv_SdtFrota_Frotadatahoracriacao_Z = sdt.gxTv_SdtFrota_Frotadatahoracriacao_Z ;
         gxTv_SdtFrota_Frotanome_Z = sdt.gxTv_SdtFrota_Frotanome_Z ;
         gxTv_SdtFrota_Frotaproprietariogamguid_Z = sdt.gxTv_SdtFrota_Frotaproprietariogamguid_Z ;
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
         AddObjectProperty("FrotaId", gxTv_SdtFrota_Frotaid, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtFrota_Frotadatahoracriacao;
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
         AddObjectProperty("FrotaDataHoraCriacao", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("FrotaNome", gxTv_SdtFrota_Frotanome, false, includeNonInitialized);
         AddObjectProperty("FrotaProprietarioGAMGUID", gxTv_SdtFrota_Frotaproprietariogamguid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtFrota_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtFrota_Initialized, false, includeNonInitialized);
            AddObjectProperty("FrotaId_Z", gxTv_SdtFrota_Frotaid_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtFrota_Frotadatahoracriacao_Z;
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
            AddObjectProperty("FrotaDataHoraCriacao_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("FrotaNome_Z", gxTv_SdtFrota_Frotanome_Z, false, includeNonInitialized);
            AddObjectProperty("FrotaProprietarioGAMGUID_Z", gxTv_SdtFrota_Frotaproprietariogamguid_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtFrota sdt )
      {
         if ( sdt.IsDirty("FrotaId") )
         {
            gxTv_SdtFrota_Frotaid = sdt.gxTv_SdtFrota_Frotaid ;
         }
         if ( sdt.IsDirty("FrotaDataHoraCriacao") )
         {
            gxTv_SdtFrota_Frotadatahoracriacao = sdt.gxTv_SdtFrota_Frotadatahoracriacao ;
         }
         if ( sdt.IsDirty("FrotaNome") )
         {
            gxTv_SdtFrota_Frotanome = sdt.gxTv_SdtFrota_Frotanome ;
         }
         if ( sdt.IsDirty("FrotaProprietarioGAMGUID") )
         {
            gxTv_SdtFrota_Frotaproprietariogamguid = sdt.gxTv_SdtFrota_Frotaproprietariogamguid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "FrotaId" )]
      [  XmlElement( ElementName = "FrotaId"   )]
      public int gxTpr_Frotaid
      {
         get {
            return gxTv_SdtFrota_Frotaid ;
         }

         set {
            if ( gxTv_SdtFrota_Frotaid != value )
            {
               gxTv_SdtFrota_Mode = "INS";
               this.gxTv_SdtFrota_Frotaid_Z_SetNull( );
               this.gxTv_SdtFrota_Frotadatahoracriacao_Z_SetNull( );
               this.gxTv_SdtFrota_Frotanome_Z_SetNull( );
               this.gxTv_SdtFrota_Frotaproprietariogamguid_Z_SetNull( );
            }
            gxTv_SdtFrota_Frotaid = value;
            SetDirty("Frotaid");
         }

      }

      [  SoapElement( ElementName = "FrotaDataHoraCriacao" )]
      [  XmlElement( ElementName = "FrotaDataHoraCriacao"  , IsNullable=true )]
      public string gxTpr_Frotadatahoracriacao_Nullable
      {
         get {
            if ( gxTv_SdtFrota_Frotadatahoracriacao == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtFrota_Frotadatahoracriacao).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtFrota_Frotadatahoracriacao = DateTime.MinValue;
            else
               gxTv_SdtFrota_Frotadatahoracriacao = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Frotadatahoracriacao
      {
         get {
            return gxTv_SdtFrota_Frotadatahoracriacao ;
         }

         set {
            gxTv_SdtFrota_Frotadatahoracriacao = value;
            SetDirty("Frotadatahoracriacao");
         }

      }

      [  SoapElement( ElementName = "FrotaNome" )]
      [  XmlElement( ElementName = "FrotaNome"   )]
      public string gxTpr_Frotanome
      {
         get {
            return gxTv_SdtFrota_Frotanome ;
         }

         set {
            gxTv_SdtFrota_Frotanome = value;
            SetDirty("Frotanome");
         }

      }

      [  SoapElement( ElementName = "FrotaProprietarioGAMGUID" )]
      [  XmlElement( ElementName = "FrotaProprietarioGAMGUID"   )]
      public string gxTpr_Frotaproprietariogamguid
      {
         get {
            return gxTv_SdtFrota_Frotaproprietariogamguid ;
         }

         set {
            gxTv_SdtFrota_Frotaproprietariogamguid = value;
            SetDirty("Frotaproprietariogamguid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtFrota_Mode ;
         }

         set {
            gxTv_SdtFrota_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtFrota_Mode_SetNull( )
      {
         gxTv_SdtFrota_Mode = "";
         return  ;
      }

      public bool gxTv_SdtFrota_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtFrota_Initialized ;
         }

         set {
            gxTv_SdtFrota_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtFrota_Initialized_SetNull( )
      {
         gxTv_SdtFrota_Initialized = 0;
         return  ;
      }

      public bool gxTv_SdtFrota_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FrotaId_Z" )]
      [  XmlElement( ElementName = "FrotaId_Z"   )]
      public int gxTpr_Frotaid_Z
      {
         get {
            return gxTv_SdtFrota_Frotaid_Z ;
         }

         set {
            gxTv_SdtFrota_Frotaid_Z = value;
            SetDirty("Frotaid_Z");
         }

      }

      public void gxTv_SdtFrota_Frotaid_Z_SetNull( )
      {
         gxTv_SdtFrota_Frotaid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtFrota_Frotaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FrotaDataHoraCriacao_Z" )]
      [  XmlElement( ElementName = "FrotaDataHoraCriacao_Z"  , IsNullable=true )]
      public string gxTpr_Frotadatahoracriacao_Z_Nullable
      {
         get {
            if ( gxTv_SdtFrota_Frotadatahoracriacao_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtFrota_Frotadatahoracriacao_Z).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtFrota_Frotadatahoracriacao_Z = DateTime.MinValue;
            else
               gxTv_SdtFrota_Frotadatahoracriacao_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Frotadatahoracriacao_Z
      {
         get {
            return gxTv_SdtFrota_Frotadatahoracriacao_Z ;
         }

         set {
            gxTv_SdtFrota_Frotadatahoracriacao_Z = value;
            SetDirty("Frotadatahoracriacao_Z");
         }

      }

      public void gxTv_SdtFrota_Frotadatahoracriacao_Z_SetNull( )
      {
         gxTv_SdtFrota_Frotadatahoracriacao_Z = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtFrota_Frotadatahoracriacao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FrotaNome_Z" )]
      [  XmlElement( ElementName = "FrotaNome_Z"   )]
      public string gxTpr_Frotanome_Z
      {
         get {
            return gxTv_SdtFrota_Frotanome_Z ;
         }

         set {
            gxTv_SdtFrota_Frotanome_Z = value;
            SetDirty("Frotanome_Z");
         }

      }

      public void gxTv_SdtFrota_Frotanome_Z_SetNull( )
      {
         gxTv_SdtFrota_Frotanome_Z = "";
         return  ;
      }

      public bool gxTv_SdtFrota_Frotanome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FrotaProprietarioGAMGUID_Z" )]
      [  XmlElement( ElementName = "FrotaProprietarioGAMGUID_Z"   )]
      public string gxTpr_Frotaproprietariogamguid_Z
      {
         get {
            return gxTv_SdtFrota_Frotaproprietariogamguid_Z ;
         }

         set {
            gxTv_SdtFrota_Frotaproprietariogamguid_Z = value;
            SetDirty("Frotaproprietariogamguid_Z");
         }

      }

      public void gxTv_SdtFrota_Frotaproprietariogamguid_Z_SetNull( )
      {
         gxTv_SdtFrota_Frotaproprietariogamguid_Z = "";
         return  ;
      }

      public bool gxTv_SdtFrota_Frotaproprietariogamguid_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtFrota_Frotadatahoracriacao = (DateTime)(DateTime.MinValue);
         gxTv_SdtFrota_Frotanome = "";
         gxTv_SdtFrota_Frotaproprietariogamguid = "";
         gxTv_SdtFrota_Mode = "";
         gxTv_SdtFrota_Frotadatahoracriacao_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtFrota_Frotanome_Z = "";
         gxTv_SdtFrota_Frotaproprietariogamguid_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "frota", "GeneXus.Programs.frota_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      private short gxTv_SdtFrota_Initialized ;
      private int gxTv_SdtFrota_Frotaid ;
      private int gxTv_SdtFrota_Frotaid_Z ;
      private string gxTv_SdtFrota_Frotaproprietariogamguid ;
      private string gxTv_SdtFrota_Mode ;
      private string gxTv_SdtFrota_Frotaproprietariogamguid_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtFrota_Frotadatahoracriacao ;
      private DateTime gxTv_SdtFrota_Frotadatahoracriacao_Z ;
      private DateTime datetime_STZ ;
      private string gxTv_SdtFrota_Frotanome ;
      private string gxTv_SdtFrota_Frotanome_Z ;
   }

   [DataContract(Name = @"Frota", Namespace = "RastreamentoTCC")]
   public class SdtFrota_RESTInterface : GxGenericCollectionItem<SdtFrota>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtFrota_RESTInterface( ) : base()
      {
      }

      public SdtFrota_RESTInterface( SdtFrota psdt ) : base(psdt)
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

      [DataMember( Name = "FrotaDataHoraCriacao" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Frotadatahoracriacao
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Frotadatahoracriacao) ;
         }

         set {
            sdt.gxTpr_Frotadatahoracriacao = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "FrotaNome" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Frotanome
      {
         get {
            return sdt.gxTpr_Frotanome ;
         }

         set {
            sdt.gxTpr_Frotanome = value;
         }

      }

      [DataMember( Name = "FrotaProprietarioGAMGUID" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Frotaproprietariogamguid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Frotaproprietariogamguid) ;
         }

         set {
            sdt.gxTpr_Frotaproprietariogamguid = value;
         }

      }

      public SdtFrota sdt
      {
         get {
            return (SdtFrota)Sdt ;
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
            sdt = new SdtFrota() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 4 )]
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

   [DataContract(Name = @"Frota", Namespace = "RastreamentoTCC")]
   public class SdtFrota_RESTLInterface : GxGenericCollectionItem<SdtFrota>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtFrota_RESTLInterface( ) : base()
      {
      }

      public SdtFrota_RESTLInterface( SdtFrota psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "FrotaDataHoraCriacao" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Frotadatahoracriacao
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Frotadatahoracriacao) ;
         }

         set {
            sdt.gxTpr_Frotadatahoracriacao = DateTimeUtil.CToT2( value);
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

      public SdtFrota sdt
      {
         get {
            return (SdtFrota)Sdt ;
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
            sdt = new SdtFrota() ;
         }
      }

   }

}
