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
   [XmlRoot(ElementName = "Veiculo" )]
   [XmlType(TypeName =  "Veiculo" , Namespace = "RastreamentoTCC" )]
   [Serializable]
   public class SdtVeiculo : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtVeiculo( )
      {
      }

      public SdtVeiculo( IGxContext context )
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

      public void Load( int AV98VeiculoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV98VeiculoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"VeiculoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Veiculo");
         metadata.Set("BT", "Veiculo");
         metadata.Set("PK", "[ \"VeiculoId\" ]");
         metadata.Set("PKAssigned", "[ \"VeiculoId\" ]");
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
         state.Add("gxTpr_Veiculodatahoracadastro_Z_Nullable");
         state.Add("gxTpr_Veiculogamguid_Z");
         state.Add("gxTpr_Veiculoplaca_Z");
         state.Add("gxTpr_Veiculocor_Z");
         state.Add("gxTpr_Veiculotipo_Z");
         state.Add("gxTpr_Veiculomarca_Z");
         state.Add("gxTpr_Veiculomodelo_Z");
         state.Add("gxTpr_Veiculoano_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtVeiculo sdt;
         sdt = (SdtVeiculo)(source);
         gxTv_SdtVeiculo_Veiculoid = sdt.gxTv_SdtVeiculo_Veiculoid ;
         gxTv_SdtVeiculo_Veiculodatahoracadastro = sdt.gxTv_SdtVeiculo_Veiculodatahoracadastro ;
         gxTv_SdtVeiculo_Veiculogamguid = sdt.gxTv_SdtVeiculo_Veiculogamguid ;
         gxTv_SdtVeiculo_Veiculoplaca = sdt.gxTv_SdtVeiculo_Veiculoplaca ;
         gxTv_SdtVeiculo_Veiculocor = sdt.gxTv_SdtVeiculo_Veiculocor ;
         gxTv_SdtVeiculo_Veiculotipo = sdt.gxTv_SdtVeiculo_Veiculotipo ;
         gxTv_SdtVeiculo_Veiculomarca = sdt.gxTv_SdtVeiculo_Veiculomarca ;
         gxTv_SdtVeiculo_Veiculomodelo = sdt.gxTv_SdtVeiculo_Veiculomodelo ;
         gxTv_SdtVeiculo_Veiculoano = sdt.gxTv_SdtVeiculo_Veiculoano ;
         gxTv_SdtVeiculo_Mode = sdt.gxTv_SdtVeiculo_Mode ;
         gxTv_SdtVeiculo_Initialized = sdt.gxTv_SdtVeiculo_Initialized ;
         gxTv_SdtVeiculo_Veiculoid_Z = sdt.gxTv_SdtVeiculo_Veiculoid_Z ;
         gxTv_SdtVeiculo_Veiculodatahoracadastro_Z = sdt.gxTv_SdtVeiculo_Veiculodatahoracadastro_Z ;
         gxTv_SdtVeiculo_Veiculogamguid_Z = sdt.gxTv_SdtVeiculo_Veiculogamguid_Z ;
         gxTv_SdtVeiculo_Veiculoplaca_Z = sdt.gxTv_SdtVeiculo_Veiculoplaca_Z ;
         gxTv_SdtVeiculo_Veiculocor_Z = sdt.gxTv_SdtVeiculo_Veiculocor_Z ;
         gxTv_SdtVeiculo_Veiculotipo_Z = sdt.gxTv_SdtVeiculo_Veiculotipo_Z ;
         gxTv_SdtVeiculo_Veiculomarca_Z = sdt.gxTv_SdtVeiculo_Veiculomarca_Z ;
         gxTv_SdtVeiculo_Veiculomodelo_Z = sdt.gxTv_SdtVeiculo_Veiculomodelo_Z ;
         gxTv_SdtVeiculo_Veiculoano_Z = sdt.gxTv_SdtVeiculo_Veiculoano_Z ;
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
         AddObjectProperty("VeiculoId", gxTv_SdtVeiculo_Veiculoid, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtVeiculo_Veiculodatahoracadastro;
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
         AddObjectProperty("VeiculoDataHoraCadastro", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("VeiculoGAMGUID", gxTv_SdtVeiculo_Veiculogamguid, false, includeNonInitialized);
         AddObjectProperty("VeiculoPlaca", gxTv_SdtVeiculo_Veiculoplaca, false, includeNonInitialized);
         AddObjectProperty("VeiculoCor", gxTv_SdtVeiculo_Veiculocor, false, includeNonInitialized);
         AddObjectProperty("VeiculoTipo", gxTv_SdtVeiculo_Veiculotipo, false, includeNonInitialized);
         AddObjectProperty("VeiculoMarca", gxTv_SdtVeiculo_Veiculomarca, false, includeNonInitialized);
         AddObjectProperty("VeiculoModelo", gxTv_SdtVeiculo_Veiculomodelo, false, includeNonInitialized);
         AddObjectProperty("VeiculoAno", gxTv_SdtVeiculo_Veiculoano, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtVeiculo_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtVeiculo_Initialized, false, includeNonInitialized);
            AddObjectProperty("VeiculoId_Z", gxTv_SdtVeiculo_Veiculoid_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtVeiculo_Veiculodatahoracadastro_Z;
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
            AddObjectProperty("VeiculoDataHoraCadastro_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("VeiculoGAMGUID_Z", gxTv_SdtVeiculo_Veiculogamguid_Z, false, includeNonInitialized);
            AddObjectProperty("VeiculoPlaca_Z", gxTv_SdtVeiculo_Veiculoplaca_Z, false, includeNonInitialized);
            AddObjectProperty("VeiculoCor_Z", gxTv_SdtVeiculo_Veiculocor_Z, false, includeNonInitialized);
            AddObjectProperty("VeiculoTipo_Z", gxTv_SdtVeiculo_Veiculotipo_Z, false, includeNonInitialized);
            AddObjectProperty("VeiculoMarca_Z", gxTv_SdtVeiculo_Veiculomarca_Z, false, includeNonInitialized);
            AddObjectProperty("VeiculoModelo_Z", gxTv_SdtVeiculo_Veiculomodelo_Z, false, includeNonInitialized);
            AddObjectProperty("VeiculoAno_Z", gxTv_SdtVeiculo_Veiculoano_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtVeiculo sdt )
      {
         if ( sdt.IsDirty("VeiculoId") )
         {
            gxTv_SdtVeiculo_Veiculoid = sdt.gxTv_SdtVeiculo_Veiculoid ;
         }
         if ( sdt.IsDirty("VeiculoDataHoraCadastro") )
         {
            gxTv_SdtVeiculo_Veiculodatahoracadastro = sdt.gxTv_SdtVeiculo_Veiculodatahoracadastro ;
         }
         if ( sdt.IsDirty("VeiculoGAMGUID") )
         {
            gxTv_SdtVeiculo_Veiculogamguid = sdt.gxTv_SdtVeiculo_Veiculogamguid ;
         }
         if ( sdt.IsDirty("VeiculoPlaca") )
         {
            gxTv_SdtVeiculo_Veiculoplaca = sdt.gxTv_SdtVeiculo_Veiculoplaca ;
         }
         if ( sdt.IsDirty("VeiculoCor") )
         {
            gxTv_SdtVeiculo_Veiculocor = sdt.gxTv_SdtVeiculo_Veiculocor ;
         }
         if ( sdt.IsDirty("VeiculoTipo") )
         {
            gxTv_SdtVeiculo_Veiculotipo = sdt.gxTv_SdtVeiculo_Veiculotipo ;
         }
         if ( sdt.IsDirty("VeiculoMarca") )
         {
            gxTv_SdtVeiculo_Veiculomarca = sdt.gxTv_SdtVeiculo_Veiculomarca ;
         }
         if ( sdt.IsDirty("VeiculoModelo") )
         {
            gxTv_SdtVeiculo_Veiculomodelo = sdt.gxTv_SdtVeiculo_Veiculomodelo ;
         }
         if ( sdt.IsDirty("VeiculoAno") )
         {
            gxTv_SdtVeiculo_Veiculoano = sdt.gxTv_SdtVeiculo_Veiculoano ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "VeiculoId" )]
      [  XmlElement( ElementName = "VeiculoId"   )]
      public int gxTpr_Veiculoid
      {
         get {
            return gxTv_SdtVeiculo_Veiculoid ;
         }

         set {
            if ( gxTv_SdtVeiculo_Veiculoid != value )
            {
               gxTv_SdtVeiculo_Mode = "INS";
               this.gxTv_SdtVeiculo_Veiculoid_Z_SetNull( );
               this.gxTv_SdtVeiculo_Veiculodatahoracadastro_Z_SetNull( );
               this.gxTv_SdtVeiculo_Veiculogamguid_Z_SetNull( );
               this.gxTv_SdtVeiculo_Veiculoplaca_Z_SetNull( );
               this.gxTv_SdtVeiculo_Veiculocor_Z_SetNull( );
               this.gxTv_SdtVeiculo_Veiculotipo_Z_SetNull( );
               this.gxTv_SdtVeiculo_Veiculomarca_Z_SetNull( );
               this.gxTv_SdtVeiculo_Veiculomodelo_Z_SetNull( );
               this.gxTv_SdtVeiculo_Veiculoano_Z_SetNull( );
            }
            gxTv_SdtVeiculo_Veiculoid = value;
            SetDirty("Veiculoid");
         }

      }

      [  SoapElement( ElementName = "VeiculoDataHoraCadastro" )]
      [  XmlElement( ElementName = "VeiculoDataHoraCadastro"  , IsNullable=true )]
      public string gxTpr_Veiculodatahoracadastro_Nullable
      {
         get {
            if ( gxTv_SdtVeiculo_Veiculodatahoracadastro == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVeiculo_Veiculodatahoracadastro).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVeiculo_Veiculodatahoracadastro = DateTime.MinValue;
            else
               gxTv_SdtVeiculo_Veiculodatahoracadastro = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Veiculodatahoracadastro
      {
         get {
            return gxTv_SdtVeiculo_Veiculodatahoracadastro ;
         }

         set {
            gxTv_SdtVeiculo_Veiculodatahoracadastro = value;
            SetDirty("Veiculodatahoracadastro");
         }

      }

      [  SoapElement( ElementName = "VeiculoGAMGUID" )]
      [  XmlElement( ElementName = "VeiculoGAMGUID"   )]
      public string gxTpr_Veiculogamguid
      {
         get {
            return gxTv_SdtVeiculo_Veiculogamguid ;
         }

         set {
            gxTv_SdtVeiculo_Veiculogamguid = value;
            SetDirty("Veiculogamguid");
         }

      }

      [  SoapElement( ElementName = "VeiculoPlaca" )]
      [  XmlElement( ElementName = "VeiculoPlaca"   )]
      public string gxTpr_Veiculoplaca
      {
         get {
            return gxTv_SdtVeiculo_Veiculoplaca ;
         }

         set {
            gxTv_SdtVeiculo_Veiculoplaca = value;
            SetDirty("Veiculoplaca");
         }

      }

      [  SoapElement( ElementName = "VeiculoCor" )]
      [  XmlElement( ElementName = "VeiculoCor"   )]
      public string gxTpr_Veiculocor
      {
         get {
            return gxTv_SdtVeiculo_Veiculocor ;
         }

         set {
            gxTv_SdtVeiculo_Veiculocor = value;
            SetDirty("Veiculocor");
         }

      }

      [  SoapElement( ElementName = "VeiculoTipo" )]
      [  XmlElement( ElementName = "VeiculoTipo"   )]
      public string gxTpr_Veiculotipo
      {
         get {
            return gxTv_SdtVeiculo_Veiculotipo ;
         }

         set {
            gxTv_SdtVeiculo_Veiculotipo = value;
            SetDirty("Veiculotipo");
         }

      }

      [  SoapElement( ElementName = "VeiculoMarca" )]
      [  XmlElement( ElementName = "VeiculoMarca"   )]
      public string gxTpr_Veiculomarca
      {
         get {
            return gxTv_SdtVeiculo_Veiculomarca ;
         }

         set {
            gxTv_SdtVeiculo_Veiculomarca = value;
            SetDirty("Veiculomarca");
         }

      }

      [  SoapElement( ElementName = "VeiculoModelo" )]
      [  XmlElement( ElementName = "VeiculoModelo"   )]
      public string gxTpr_Veiculomodelo
      {
         get {
            return gxTv_SdtVeiculo_Veiculomodelo ;
         }

         set {
            gxTv_SdtVeiculo_Veiculomodelo = value;
            SetDirty("Veiculomodelo");
         }

      }

      [  SoapElement( ElementName = "VeiculoAno" )]
      [  XmlElement( ElementName = "VeiculoAno"   )]
      public string gxTpr_Veiculoano
      {
         get {
            return gxTv_SdtVeiculo_Veiculoano ;
         }

         set {
            gxTv_SdtVeiculo_Veiculoano = value;
            SetDirty("Veiculoano");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtVeiculo_Mode ;
         }

         set {
            gxTv_SdtVeiculo_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtVeiculo_Mode_SetNull( )
      {
         gxTv_SdtVeiculo_Mode = "";
         return  ;
      }

      public bool gxTv_SdtVeiculo_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtVeiculo_Initialized ;
         }

         set {
            gxTv_SdtVeiculo_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtVeiculo_Initialized_SetNull( )
      {
         gxTv_SdtVeiculo_Initialized = 0;
         return  ;
      }

      public bool gxTv_SdtVeiculo_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VeiculoId_Z" )]
      [  XmlElement( ElementName = "VeiculoId_Z"   )]
      public int gxTpr_Veiculoid_Z
      {
         get {
            return gxTv_SdtVeiculo_Veiculoid_Z ;
         }

         set {
            gxTv_SdtVeiculo_Veiculoid_Z = value;
            SetDirty("Veiculoid_Z");
         }

      }

      public void gxTv_SdtVeiculo_Veiculoid_Z_SetNull( )
      {
         gxTv_SdtVeiculo_Veiculoid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtVeiculo_Veiculoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VeiculoDataHoraCadastro_Z" )]
      [  XmlElement( ElementName = "VeiculoDataHoraCadastro_Z"  , IsNullable=true )]
      public string gxTpr_Veiculodatahoracadastro_Z_Nullable
      {
         get {
            if ( gxTv_SdtVeiculo_Veiculodatahoracadastro_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVeiculo_Veiculodatahoracadastro_Z).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVeiculo_Veiculodatahoracadastro_Z = DateTime.MinValue;
            else
               gxTv_SdtVeiculo_Veiculodatahoracadastro_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Veiculodatahoracadastro_Z
      {
         get {
            return gxTv_SdtVeiculo_Veiculodatahoracadastro_Z ;
         }

         set {
            gxTv_SdtVeiculo_Veiculodatahoracadastro_Z = value;
            SetDirty("Veiculodatahoracadastro_Z");
         }

      }

      public void gxTv_SdtVeiculo_Veiculodatahoracadastro_Z_SetNull( )
      {
         gxTv_SdtVeiculo_Veiculodatahoracadastro_Z = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtVeiculo_Veiculodatahoracadastro_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VeiculoGAMGUID_Z" )]
      [  XmlElement( ElementName = "VeiculoGAMGUID_Z"   )]
      public string gxTpr_Veiculogamguid_Z
      {
         get {
            return gxTv_SdtVeiculo_Veiculogamguid_Z ;
         }

         set {
            gxTv_SdtVeiculo_Veiculogamguid_Z = value;
            SetDirty("Veiculogamguid_Z");
         }

      }

      public void gxTv_SdtVeiculo_Veiculogamguid_Z_SetNull( )
      {
         gxTv_SdtVeiculo_Veiculogamguid_Z = "";
         return  ;
      }

      public bool gxTv_SdtVeiculo_Veiculogamguid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VeiculoPlaca_Z" )]
      [  XmlElement( ElementName = "VeiculoPlaca_Z"   )]
      public string gxTpr_Veiculoplaca_Z
      {
         get {
            return gxTv_SdtVeiculo_Veiculoplaca_Z ;
         }

         set {
            gxTv_SdtVeiculo_Veiculoplaca_Z = value;
            SetDirty("Veiculoplaca_Z");
         }

      }

      public void gxTv_SdtVeiculo_Veiculoplaca_Z_SetNull( )
      {
         gxTv_SdtVeiculo_Veiculoplaca_Z = "";
         return  ;
      }

      public bool gxTv_SdtVeiculo_Veiculoplaca_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VeiculoCor_Z" )]
      [  XmlElement( ElementName = "VeiculoCor_Z"   )]
      public string gxTpr_Veiculocor_Z
      {
         get {
            return gxTv_SdtVeiculo_Veiculocor_Z ;
         }

         set {
            gxTv_SdtVeiculo_Veiculocor_Z = value;
            SetDirty("Veiculocor_Z");
         }

      }

      public void gxTv_SdtVeiculo_Veiculocor_Z_SetNull( )
      {
         gxTv_SdtVeiculo_Veiculocor_Z = "";
         return  ;
      }

      public bool gxTv_SdtVeiculo_Veiculocor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VeiculoTipo_Z" )]
      [  XmlElement( ElementName = "VeiculoTipo_Z"   )]
      public string gxTpr_Veiculotipo_Z
      {
         get {
            return gxTv_SdtVeiculo_Veiculotipo_Z ;
         }

         set {
            gxTv_SdtVeiculo_Veiculotipo_Z = value;
            SetDirty("Veiculotipo_Z");
         }

      }

      public void gxTv_SdtVeiculo_Veiculotipo_Z_SetNull( )
      {
         gxTv_SdtVeiculo_Veiculotipo_Z = "";
         return  ;
      }

      public bool gxTv_SdtVeiculo_Veiculotipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VeiculoMarca_Z" )]
      [  XmlElement( ElementName = "VeiculoMarca_Z"   )]
      public string gxTpr_Veiculomarca_Z
      {
         get {
            return gxTv_SdtVeiculo_Veiculomarca_Z ;
         }

         set {
            gxTv_SdtVeiculo_Veiculomarca_Z = value;
            SetDirty("Veiculomarca_Z");
         }

      }

      public void gxTv_SdtVeiculo_Veiculomarca_Z_SetNull( )
      {
         gxTv_SdtVeiculo_Veiculomarca_Z = "";
         return  ;
      }

      public bool gxTv_SdtVeiculo_Veiculomarca_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VeiculoModelo_Z" )]
      [  XmlElement( ElementName = "VeiculoModelo_Z"   )]
      public string gxTpr_Veiculomodelo_Z
      {
         get {
            return gxTv_SdtVeiculo_Veiculomodelo_Z ;
         }

         set {
            gxTv_SdtVeiculo_Veiculomodelo_Z = value;
            SetDirty("Veiculomodelo_Z");
         }

      }

      public void gxTv_SdtVeiculo_Veiculomodelo_Z_SetNull( )
      {
         gxTv_SdtVeiculo_Veiculomodelo_Z = "";
         return  ;
      }

      public bool gxTv_SdtVeiculo_Veiculomodelo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VeiculoAno_Z" )]
      [  XmlElement( ElementName = "VeiculoAno_Z"   )]
      public string gxTpr_Veiculoano_Z
      {
         get {
            return gxTv_SdtVeiculo_Veiculoano_Z ;
         }

         set {
            gxTv_SdtVeiculo_Veiculoano_Z = value;
            SetDirty("Veiculoano_Z");
         }

      }

      public void gxTv_SdtVeiculo_Veiculoano_Z_SetNull( )
      {
         gxTv_SdtVeiculo_Veiculoano_Z = "";
         return  ;
      }

      public bool gxTv_SdtVeiculo_Veiculoano_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtVeiculo_Veiculodatahoracadastro = (DateTime)(DateTime.MinValue);
         gxTv_SdtVeiculo_Veiculogamguid = "";
         gxTv_SdtVeiculo_Veiculoplaca = "";
         gxTv_SdtVeiculo_Veiculocor = "";
         gxTv_SdtVeiculo_Veiculotipo = "";
         gxTv_SdtVeiculo_Veiculomarca = "";
         gxTv_SdtVeiculo_Veiculomodelo = "";
         gxTv_SdtVeiculo_Veiculoano = "";
         gxTv_SdtVeiculo_Mode = "";
         gxTv_SdtVeiculo_Veiculodatahoracadastro_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtVeiculo_Veiculogamguid_Z = "";
         gxTv_SdtVeiculo_Veiculoplaca_Z = "";
         gxTv_SdtVeiculo_Veiculocor_Z = "";
         gxTv_SdtVeiculo_Veiculotipo_Z = "";
         gxTv_SdtVeiculo_Veiculomarca_Z = "";
         gxTv_SdtVeiculo_Veiculomodelo_Z = "";
         gxTv_SdtVeiculo_Veiculoano_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "veiculo", "GeneXus.Programs.veiculo_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      private short gxTv_SdtVeiculo_Initialized ;
      private int gxTv_SdtVeiculo_Veiculoid ;
      private int gxTv_SdtVeiculo_Veiculoid_Z ;
      private string gxTv_SdtVeiculo_Veiculogamguid ;
      private string gxTv_SdtVeiculo_Veiculocor ;
      private string gxTv_SdtVeiculo_Mode ;
      private string gxTv_SdtVeiculo_Veiculogamguid_Z ;
      private string gxTv_SdtVeiculo_Veiculocor_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtVeiculo_Veiculodatahoracadastro ;
      private DateTime gxTv_SdtVeiculo_Veiculodatahoracadastro_Z ;
      private DateTime datetime_STZ ;
      private string gxTv_SdtVeiculo_Veiculoplaca ;
      private string gxTv_SdtVeiculo_Veiculotipo ;
      private string gxTv_SdtVeiculo_Veiculomarca ;
      private string gxTv_SdtVeiculo_Veiculomodelo ;
      private string gxTv_SdtVeiculo_Veiculoano ;
      private string gxTv_SdtVeiculo_Veiculoplaca_Z ;
      private string gxTv_SdtVeiculo_Veiculotipo_Z ;
      private string gxTv_SdtVeiculo_Veiculomarca_Z ;
      private string gxTv_SdtVeiculo_Veiculomodelo_Z ;
      private string gxTv_SdtVeiculo_Veiculoano_Z ;
   }

   [DataContract(Name = @"Veiculo", Namespace = "RastreamentoTCC")]
   public class SdtVeiculo_RESTInterface : GxGenericCollectionItem<SdtVeiculo>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtVeiculo_RESTInterface( ) : base()
      {
      }

      public SdtVeiculo_RESTInterface( SdtVeiculo psdt ) : base(psdt)
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

      [DataMember( Name = "VeiculoDataHoraCadastro" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Veiculodatahoracadastro
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Veiculodatahoracadastro) ;
         }

         set {
            sdt.gxTpr_Veiculodatahoracadastro = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "VeiculoGAMGUID" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Veiculogamguid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Veiculogamguid) ;
         }

         set {
            sdt.gxTpr_Veiculogamguid = value;
         }

      }

      [DataMember( Name = "VeiculoPlaca" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Veiculoplaca
      {
         get {
            return sdt.gxTpr_Veiculoplaca ;
         }

         set {
            sdt.gxTpr_Veiculoplaca = value;
         }

      }

      [DataMember( Name = "VeiculoCor" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Veiculocor
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Veiculocor) ;
         }

         set {
            sdt.gxTpr_Veiculocor = value;
         }

      }

      [DataMember( Name = "VeiculoTipo" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Veiculotipo
      {
         get {
            return sdt.gxTpr_Veiculotipo ;
         }

         set {
            sdt.gxTpr_Veiculotipo = value;
         }

      }

      [DataMember( Name = "VeiculoMarca" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Veiculomarca
      {
         get {
            return sdt.gxTpr_Veiculomarca ;
         }

         set {
            sdt.gxTpr_Veiculomarca = value;
         }

      }

      [DataMember( Name = "VeiculoModelo" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Veiculomodelo
      {
         get {
            return sdt.gxTpr_Veiculomodelo ;
         }

         set {
            sdt.gxTpr_Veiculomodelo = value;
         }

      }

      [DataMember( Name = "VeiculoAno" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Veiculoano
      {
         get {
            return sdt.gxTpr_Veiculoano ;
         }

         set {
            sdt.gxTpr_Veiculoano = value;
         }

      }

      public SdtVeiculo sdt
      {
         get {
            return (SdtVeiculo)Sdt ;
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
            sdt = new SdtVeiculo() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 9 )]
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

   [DataContract(Name = @"Veiculo", Namespace = "RastreamentoTCC")]
   public class SdtVeiculo_RESTLInterface : GxGenericCollectionItem<SdtVeiculo>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtVeiculo_RESTLInterface( ) : base()
      {
      }

      public SdtVeiculo_RESTLInterface( SdtVeiculo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "VeiculoDataHoraCadastro" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Veiculodatahoracadastro
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Veiculodatahoracadastro) ;
         }

         set {
            sdt.gxTpr_Veiculodatahoracadastro = DateTimeUtil.CToT2( value);
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

      public SdtVeiculo sdt
      {
         get {
            return (SdtVeiculo)Sdt ;
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
            sdt = new SdtVeiculo() ;
         }
      }

   }

}
