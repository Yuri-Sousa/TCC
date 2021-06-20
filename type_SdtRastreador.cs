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
   [XmlRoot(ElementName = "Rastreador" )]
   [XmlType(TypeName =  "Rastreador" , Namespace = "RastreamentoTCC" )]
   [Serializable]
   public class SdtRastreador : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtRastreador( )
      {
      }

      public SdtRastreador( IGxContext context )
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

      public void Load( int AV106RastreadorId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV106RastreadorId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"RastreadorId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Rastreador");
         metadata.Set("BT", "Rastreador");
         metadata.Set("PK", "[ \"RastreadorId\" ]");
         metadata.Set("PKAssigned", "[ \"RastreadorId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ChipGSMId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Rastreadorid_Z");
         state.Add("gxTpr_Rastreadordatahoracriacao_Z_Nullable");
         state.Add("gxTpr_Rastreadorgamguidproprietario_Z");
         state.Add("gxTpr_Rastreadorfabricante_Z");
         state.Add("gxTpr_Rastreadormodelo_Z");
         state.Add("gxTpr_Rastreadorsnumber_Z");
         state.Add("gxTpr_Rastreadordeviceidflespi_Z");
         state.Add("gxTpr_Rastreadoratrelado_Z");
         state.Add("gxTpr_Chipgsmid_Z");
         state.Add("gxTpr_Chipgsmoperadora_Z");
         state.Add("gxTpr_Chipgsmnumero_Z");
         state.Add("gxTpr_Rastreadorfabricante_N");
         state.Add("gxTpr_Rastreadormodelo_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtRastreador sdt;
         sdt = (SdtRastreador)(source);
         gxTv_SdtRastreador_Rastreadorid = sdt.gxTv_SdtRastreador_Rastreadorid ;
         gxTv_SdtRastreador_Rastreadordatahoracriacao = sdt.gxTv_SdtRastreador_Rastreadordatahoracriacao ;
         gxTv_SdtRastreador_Rastreadorgamguidproprietario = sdt.gxTv_SdtRastreador_Rastreadorgamguidproprietario ;
         gxTv_SdtRastreador_Rastreadorfabricante = sdt.gxTv_SdtRastreador_Rastreadorfabricante ;
         gxTv_SdtRastreador_Rastreadormodelo = sdt.gxTv_SdtRastreador_Rastreadormodelo ;
         gxTv_SdtRastreador_Rastreadorsnumber = sdt.gxTv_SdtRastreador_Rastreadorsnumber ;
         gxTv_SdtRastreador_Rastreadordeviceidflespi = sdt.gxTv_SdtRastreador_Rastreadordeviceidflespi ;
         gxTv_SdtRastreador_Rastreadoratrelado = sdt.gxTv_SdtRastreador_Rastreadoratrelado ;
         gxTv_SdtRastreador_Chipgsmid = sdt.gxTv_SdtRastreador_Chipgsmid ;
         gxTv_SdtRastreador_Chipgsmoperadora = sdt.gxTv_SdtRastreador_Chipgsmoperadora ;
         gxTv_SdtRastreador_Chipgsmnumero = sdt.gxTv_SdtRastreador_Chipgsmnumero ;
         gxTv_SdtRastreador_Mode = sdt.gxTv_SdtRastreador_Mode ;
         gxTv_SdtRastreador_Initialized = sdt.gxTv_SdtRastreador_Initialized ;
         gxTv_SdtRastreador_Rastreadorid_Z = sdt.gxTv_SdtRastreador_Rastreadorid_Z ;
         gxTv_SdtRastreador_Rastreadordatahoracriacao_Z = sdt.gxTv_SdtRastreador_Rastreadordatahoracriacao_Z ;
         gxTv_SdtRastreador_Rastreadorgamguidproprietario_Z = sdt.gxTv_SdtRastreador_Rastreadorgamguidproprietario_Z ;
         gxTv_SdtRastreador_Rastreadorfabricante_Z = sdt.gxTv_SdtRastreador_Rastreadorfabricante_Z ;
         gxTv_SdtRastreador_Rastreadormodelo_Z = sdt.gxTv_SdtRastreador_Rastreadormodelo_Z ;
         gxTv_SdtRastreador_Rastreadorsnumber_Z = sdt.gxTv_SdtRastreador_Rastreadorsnumber_Z ;
         gxTv_SdtRastreador_Rastreadordeviceidflespi_Z = sdt.gxTv_SdtRastreador_Rastreadordeviceidflespi_Z ;
         gxTv_SdtRastreador_Rastreadoratrelado_Z = sdt.gxTv_SdtRastreador_Rastreadoratrelado_Z ;
         gxTv_SdtRastreador_Chipgsmid_Z = sdt.gxTv_SdtRastreador_Chipgsmid_Z ;
         gxTv_SdtRastreador_Chipgsmoperadora_Z = sdt.gxTv_SdtRastreador_Chipgsmoperadora_Z ;
         gxTv_SdtRastreador_Chipgsmnumero_Z = sdt.gxTv_SdtRastreador_Chipgsmnumero_Z ;
         gxTv_SdtRastreador_Rastreadorfabricante_N = sdt.gxTv_SdtRastreador_Rastreadorfabricante_N ;
         gxTv_SdtRastreador_Rastreadormodelo_N = sdt.gxTv_SdtRastreador_Rastreadormodelo_N ;
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
         AddObjectProperty("RastreadorId", gxTv_SdtRastreador_Rastreadorid, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtRastreador_Rastreadordatahoracriacao;
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
         AddObjectProperty("RastreadorDataHoraCriacao", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("RastreadorGAMGUIDProprietario", gxTv_SdtRastreador_Rastreadorgamguidproprietario, false, includeNonInitialized);
         AddObjectProperty("RastreadorFabricante", gxTv_SdtRastreador_Rastreadorfabricante, false, includeNonInitialized);
         AddObjectProperty("RastreadorFabricante_N", gxTv_SdtRastreador_Rastreadorfabricante_N, false, includeNonInitialized);
         AddObjectProperty("RastreadorModelo", gxTv_SdtRastreador_Rastreadormodelo, false, includeNonInitialized);
         AddObjectProperty("RastreadorModelo_N", gxTv_SdtRastreador_Rastreadormodelo_N, false, includeNonInitialized);
         AddObjectProperty("RastreadorSNumber", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtRastreador_Rastreadorsnumber), 16, 0)), false, includeNonInitialized);
         AddObjectProperty("RastreadorDeviceIdFlespi", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtRastreador_Rastreadordeviceidflespi), 16, 0)), false, includeNonInitialized);
         AddObjectProperty("RastreadorAtrelado", gxTv_SdtRastreador_Rastreadoratrelado, false, includeNonInitialized);
         AddObjectProperty("ChipGSMId", gxTv_SdtRastreador_Chipgsmid, false, includeNonInitialized);
         AddObjectProperty("ChipGSMOperadora", gxTv_SdtRastreador_Chipgsmoperadora, false, includeNonInitialized);
         AddObjectProperty("ChipGSMNumero", gxTv_SdtRastreador_Chipgsmnumero, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtRastreador_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtRastreador_Initialized, false, includeNonInitialized);
            AddObjectProperty("RastreadorId_Z", gxTv_SdtRastreador_Rastreadorid_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtRastreador_Rastreadordatahoracriacao_Z;
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
            AddObjectProperty("RastreadorDataHoraCriacao_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("RastreadorGAMGUIDProprietario_Z", gxTv_SdtRastreador_Rastreadorgamguidproprietario_Z, false, includeNonInitialized);
            AddObjectProperty("RastreadorFabricante_Z", gxTv_SdtRastreador_Rastreadorfabricante_Z, false, includeNonInitialized);
            AddObjectProperty("RastreadorModelo_Z", gxTv_SdtRastreador_Rastreadormodelo_Z, false, includeNonInitialized);
            AddObjectProperty("RastreadorSNumber_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtRastreador_Rastreadorsnumber_Z), 16, 0)), false, includeNonInitialized);
            AddObjectProperty("RastreadorDeviceIdFlespi_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtRastreador_Rastreadordeviceidflespi_Z), 16, 0)), false, includeNonInitialized);
            AddObjectProperty("RastreadorAtrelado_Z", gxTv_SdtRastreador_Rastreadoratrelado_Z, false, includeNonInitialized);
            AddObjectProperty("ChipGSMId_Z", gxTv_SdtRastreador_Chipgsmid_Z, false, includeNonInitialized);
            AddObjectProperty("ChipGSMOperadora_Z", gxTv_SdtRastreador_Chipgsmoperadora_Z, false, includeNonInitialized);
            AddObjectProperty("ChipGSMNumero_Z", gxTv_SdtRastreador_Chipgsmnumero_Z, false, includeNonInitialized);
            AddObjectProperty("RastreadorFabricante_N", gxTv_SdtRastreador_Rastreadorfabricante_N, false, includeNonInitialized);
            AddObjectProperty("RastreadorModelo_N", gxTv_SdtRastreador_Rastreadormodelo_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtRastreador sdt )
      {
         if ( sdt.IsDirty("RastreadorId") )
         {
            gxTv_SdtRastreador_Rastreadorid = sdt.gxTv_SdtRastreador_Rastreadorid ;
         }
         if ( sdt.IsDirty("RastreadorDataHoraCriacao") )
         {
            gxTv_SdtRastreador_Rastreadordatahoracriacao = sdt.gxTv_SdtRastreador_Rastreadordatahoracriacao ;
         }
         if ( sdt.IsDirty("RastreadorGAMGUIDProprietario") )
         {
            gxTv_SdtRastreador_Rastreadorgamguidproprietario = sdt.gxTv_SdtRastreador_Rastreadorgamguidproprietario ;
         }
         if ( sdt.IsDirty("RastreadorFabricante") )
         {
            gxTv_SdtRastreador_Rastreadorfabricante_N = 0;
            gxTv_SdtRastreador_Rastreadorfabricante = sdt.gxTv_SdtRastreador_Rastreadorfabricante ;
         }
         if ( sdt.IsDirty("RastreadorModelo") )
         {
            gxTv_SdtRastreador_Rastreadormodelo_N = 0;
            gxTv_SdtRastreador_Rastreadormodelo = sdt.gxTv_SdtRastreador_Rastreadormodelo ;
         }
         if ( sdt.IsDirty("RastreadorSNumber") )
         {
            gxTv_SdtRastreador_Rastreadorsnumber = sdt.gxTv_SdtRastreador_Rastreadorsnumber ;
         }
         if ( sdt.IsDirty("RastreadorDeviceIdFlespi") )
         {
            gxTv_SdtRastreador_Rastreadordeviceidflespi = sdt.gxTv_SdtRastreador_Rastreadordeviceidflespi ;
         }
         if ( sdt.IsDirty("RastreadorAtrelado") )
         {
            gxTv_SdtRastreador_Rastreadoratrelado = sdt.gxTv_SdtRastreador_Rastreadoratrelado ;
         }
         if ( sdt.IsDirty("ChipGSMId") )
         {
            gxTv_SdtRastreador_Chipgsmid = sdt.gxTv_SdtRastreador_Chipgsmid ;
         }
         if ( sdt.IsDirty("ChipGSMOperadora") )
         {
            gxTv_SdtRastreador_Chipgsmoperadora = sdt.gxTv_SdtRastreador_Chipgsmoperadora ;
         }
         if ( sdt.IsDirty("ChipGSMNumero") )
         {
            gxTv_SdtRastreador_Chipgsmnumero = sdt.gxTv_SdtRastreador_Chipgsmnumero ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "RastreadorId" )]
      [  XmlElement( ElementName = "RastreadorId"   )]
      public int gxTpr_Rastreadorid
      {
         get {
            return gxTv_SdtRastreador_Rastreadorid ;
         }

         set {
            if ( gxTv_SdtRastreador_Rastreadorid != value )
            {
               gxTv_SdtRastreador_Mode = "INS";
               this.gxTv_SdtRastreador_Rastreadorid_Z_SetNull( );
               this.gxTv_SdtRastreador_Rastreadordatahoracriacao_Z_SetNull( );
               this.gxTv_SdtRastreador_Rastreadorgamguidproprietario_Z_SetNull( );
               this.gxTv_SdtRastreador_Rastreadorfabricante_Z_SetNull( );
               this.gxTv_SdtRastreador_Rastreadormodelo_Z_SetNull( );
               this.gxTv_SdtRastreador_Rastreadorsnumber_Z_SetNull( );
               this.gxTv_SdtRastreador_Rastreadordeviceidflespi_Z_SetNull( );
               this.gxTv_SdtRastreador_Rastreadoratrelado_Z_SetNull( );
               this.gxTv_SdtRastreador_Chipgsmid_Z_SetNull( );
               this.gxTv_SdtRastreador_Chipgsmoperadora_Z_SetNull( );
               this.gxTv_SdtRastreador_Chipgsmnumero_Z_SetNull( );
            }
            gxTv_SdtRastreador_Rastreadorid = value;
            SetDirty("Rastreadorid");
         }

      }

      [  SoapElement( ElementName = "RastreadorDataHoraCriacao" )]
      [  XmlElement( ElementName = "RastreadorDataHoraCriacao"  , IsNullable=true )]
      public string gxTpr_Rastreadordatahoracriacao_Nullable
      {
         get {
            if ( gxTv_SdtRastreador_Rastreadordatahoracriacao == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtRastreador_Rastreadordatahoracriacao).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtRastreador_Rastreadordatahoracriacao = DateTime.MinValue;
            else
               gxTv_SdtRastreador_Rastreadordatahoracriacao = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Rastreadordatahoracriacao
      {
         get {
            return gxTv_SdtRastreador_Rastreadordatahoracriacao ;
         }

         set {
            gxTv_SdtRastreador_Rastreadordatahoracriacao = value;
            SetDirty("Rastreadordatahoracriacao");
         }

      }

      [  SoapElement( ElementName = "RastreadorGAMGUIDProprietario" )]
      [  XmlElement( ElementName = "RastreadorGAMGUIDProprietario"   )]
      public string gxTpr_Rastreadorgamguidproprietario
      {
         get {
            return gxTv_SdtRastreador_Rastreadorgamguidproprietario ;
         }

         set {
            gxTv_SdtRastreador_Rastreadorgamguidproprietario = value;
            SetDirty("Rastreadorgamguidproprietario");
         }

      }

      [  SoapElement( ElementName = "RastreadorFabricante" )]
      [  XmlElement( ElementName = "RastreadorFabricante"   )]
      public string gxTpr_Rastreadorfabricante
      {
         get {
            return gxTv_SdtRastreador_Rastreadorfabricante ;
         }

         set {
            gxTv_SdtRastreador_Rastreadorfabricante_N = 0;
            gxTv_SdtRastreador_Rastreadorfabricante = value;
            SetDirty("Rastreadorfabricante");
         }

      }

      public void gxTv_SdtRastreador_Rastreadorfabricante_SetNull( )
      {
         gxTv_SdtRastreador_Rastreadorfabricante_N = 1;
         gxTv_SdtRastreador_Rastreadorfabricante = "";
         return  ;
      }

      public bool gxTv_SdtRastreador_Rastreadorfabricante_IsNull( )
      {
         return (gxTv_SdtRastreador_Rastreadorfabricante_N==1) ;
      }

      [  SoapElement( ElementName = "RastreadorModelo" )]
      [  XmlElement( ElementName = "RastreadorModelo"   )]
      public string gxTpr_Rastreadormodelo
      {
         get {
            return gxTv_SdtRastreador_Rastreadormodelo ;
         }

         set {
            gxTv_SdtRastreador_Rastreadormodelo_N = 0;
            gxTv_SdtRastreador_Rastreadormodelo = value;
            SetDirty("Rastreadormodelo");
         }

      }

      public void gxTv_SdtRastreador_Rastreadormodelo_SetNull( )
      {
         gxTv_SdtRastreador_Rastreadormodelo_N = 1;
         gxTv_SdtRastreador_Rastreadormodelo = "";
         return  ;
      }

      public bool gxTv_SdtRastreador_Rastreadormodelo_IsNull( )
      {
         return (gxTv_SdtRastreador_Rastreadormodelo_N==1) ;
      }

      [  SoapElement( ElementName = "RastreadorSNumber" )]
      [  XmlElement( ElementName = "RastreadorSNumber"   )]
      public long gxTpr_Rastreadorsnumber
      {
         get {
            return gxTv_SdtRastreador_Rastreadorsnumber ;
         }

         set {
            gxTv_SdtRastreador_Rastreadorsnumber = value;
            SetDirty("Rastreadorsnumber");
         }

      }

      [  SoapElement( ElementName = "RastreadorDeviceIdFlespi" )]
      [  XmlElement( ElementName = "RastreadorDeviceIdFlespi"   )]
      public long gxTpr_Rastreadordeviceidflespi
      {
         get {
            return gxTv_SdtRastreador_Rastreadordeviceidflespi ;
         }

         set {
            gxTv_SdtRastreador_Rastreadordeviceidflespi = value;
            SetDirty("Rastreadordeviceidflespi");
         }

      }

      [  SoapElement( ElementName = "RastreadorAtrelado" )]
      [  XmlElement( ElementName = "RastreadorAtrelado"   )]
      public bool gxTpr_Rastreadoratrelado
      {
         get {
            return gxTv_SdtRastreador_Rastreadoratrelado ;
         }

         set {
            gxTv_SdtRastreador_Rastreadoratrelado = value;
            SetDirty("Rastreadoratrelado");
         }

      }

      [  SoapElement( ElementName = "ChipGSMId" )]
      [  XmlElement( ElementName = "ChipGSMId"   )]
      public int gxTpr_Chipgsmid
      {
         get {
            return gxTv_SdtRastreador_Chipgsmid ;
         }

         set {
            gxTv_SdtRastreador_Chipgsmid = value;
            SetDirty("Chipgsmid");
         }

      }

      [  SoapElement( ElementName = "ChipGSMOperadora" )]
      [  XmlElement( ElementName = "ChipGSMOperadora"   )]
      public string gxTpr_Chipgsmoperadora
      {
         get {
            return gxTv_SdtRastreador_Chipgsmoperadora ;
         }

         set {
            gxTv_SdtRastreador_Chipgsmoperadora = value;
            SetDirty("Chipgsmoperadora");
         }

      }

      [  SoapElement( ElementName = "ChipGSMNumero" )]
      [  XmlElement( ElementName = "ChipGSMNumero"   )]
      public string gxTpr_Chipgsmnumero
      {
         get {
            return gxTv_SdtRastreador_Chipgsmnumero ;
         }

         set {
            gxTv_SdtRastreador_Chipgsmnumero = value;
            SetDirty("Chipgsmnumero");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtRastreador_Mode ;
         }

         set {
            gxTv_SdtRastreador_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtRastreador_Mode_SetNull( )
      {
         gxTv_SdtRastreador_Mode = "";
         return  ;
      }

      public bool gxTv_SdtRastreador_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtRastreador_Initialized ;
         }

         set {
            gxTv_SdtRastreador_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtRastreador_Initialized_SetNull( )
      {
         gxTv_SdtRastreador_Initialized = 0;
         return  ;
      }

      public bool gxTv_SdtRastreador_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RastreadorId_Z" )]
      [  XmlElement( ElementName = "RastreadorId_Z"   )]
      public int gxTpr_Rastreadorid_Z
      {
         get {
            return gxTv_SdtRastreador_Rastreadorid_Z ;
         }

         set {
            gxTv_SdtRastreador_Rastreadorid_Z = value;
            SetDirty("Rastreadorid_Z");
         }

      }

      public void gxTv_SdtRastreador_Rastreadorid_Z_SetNull( )
      {
         gxTv_SdtRastreador_Rastreadorid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtRastreador_Rastreadorid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RastreadorDataHoraCriacao_Z" )]
      [  XmlElement( ElementName = "RastreadorDataHoraCriacao_Z"  , IsNullable=true )]
      public string gxTpr_Rastreadordatahoracriacao_Z_Nullable
      {
         get {
            if ( gxTv_SdtRastreador_Rastreadordatahoracriacao_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtRastreador_Rastreadordatahoracriacao_Z).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtRastreador_Rastreadordatahoracriacao_Z = DateTime.MinValue;
            else
               gxTv_SdtRastreador_Rastreadordatahoracriacao_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Rastreadordatahoracriacao_Z
      {
         get {
            return gxTv_SdtRastreador_Rastreadordatahoracriacao_Z ;
         }

         set {
            gxTv_SdtRastreador_Rastreadordatahoracriacao_Z = value;
            SetDirty("Rastreadordatahoracriacao_Z");
         }

      }

      public void gxTv_SdtRastreador_Rastreadordatahoracriacao_Z_SetNull( )
      {
         gxTv_SdtRastreador_Rastreadordatahoracriacao_Z = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtRastreador_Rastreadordatahoracriacao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RastreadorGAMGUIDProprietario_Z" )]
      [  XmlElement( ElementName = "RastreadorGAMGUIDProprietario_Z"   )]
      public string gxTpr_Rastreadorgamguidproprietario_Z
      {
         get {
            return gxTv_SdtRastreador_Rastreadorgamguidproprietario_Z ;
         }

         set {
            gxTv_SdtRastreador_Rastreadorgamguidproprietario_Z = value;
            SetDirty("Rastreadorgamguidproprietario_Z");
         }

      }

      public void gxTv_SdtRastreador_Rastreadorgamguidproprietario_Z_SetNull( )
      {
         gxTv_SdtRastreador_Rastreadorgamguidproprietario_Z = "";
         return  ;
      }

      public bool gxTv_SdtRastreador_Rastreadorgamguidproprietario_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RastreadorFabricante_Z" )]
      [  XmlElement( ElementName = "RastreadorFabricante_Z"   )]
      public string gxTpr_Rastreadorfabricante_Z
      {
         get {
            return gxTv_SdtRastreador_Rastreadorfabricante_Z ;
         }

         set {
            gxTv_SdtRastreador_Rastreadorfabricante_Z = value;
            SetDirty("Rastreadorfabricante_Z");
         }

      }

      public void gxTv_SdtRastreador_Rastreadorfabricante_Z_SetNull( )
      {
         gxTv_SdtRastreador_Rastreadorfabricante_Z = "";
         return  ;
      }

      public bool gxTv_SdtRastreador_Rastreadorfabricante_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RastreadorModelo_Z" )]
      [  XmlElement( ElementName = "RastreadorModelo_Z"   )]
      public string gxTpr_Rastreadormodelo_Z
      {
         get {
            return gxTv_SdtRastreador_Rastreadormodelo_Z ;
         }

         set {
            gxTv_SdtRastreador_Rastreadormodelo_Z = value;
            SetDirty("Rastreadormodelo_Z");
         }

      }

      public void gxTv_SdtRastreador_Rastreadormodelo_Z_SetNull( )
      {
         gxTv_SdtRastreador_Rastreadormodelo_Z = "";
         return  ;
      }

      public bool gxTv_SdtRastreador_Rastreadormodelo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RastreadorSNumber_Z" )]
      [  XmlElement( ElementName = "RastreadorSNumber_Z"   )]
      public long gxTpr_Rastreadorsnumber_Z
      {
         get {
            return gxTv_SdtRastreador_Rastreadorsnumber_Z ;
         }

         set {
            gxTv_SdtRastreador_Rastreadorsnumber_Z = value;
            SetDirty("Rastreadorsnumber_Z");
         }

      }

      public void gxTv_SdtRastreador_Rastreadorsnumber_Z_SetNull( )
      {
         gxTv_SdtRastreador_Rastreadorsnumber_Z = 0;
         return  ;
      }

      public bool gxTv_SdtRastreador_Rastreadorsnumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RastreadorDeviceIdFlespi_Z" )]
      [  XmlElement( ElementName = "RastreadorDeviceIdFlespi_Z"   )]
      public long gxTpr_Rastreadordeviceidflespi_Z
      {
         get {
            return gxTv_SdtRastreador_Rastreadordeviceidflespi_Z ;
         }

         set {
            gxTv_SdtRastreador_Rastreadordeviceidflespi_Z = value;
            SetDirty("Rastreadordeviceidflespi_Z");
         }

      }

      public void gxTv_SdtRastreador_Rastreadordeviceidflespi_Z_SetNull( )
      {
         gxTv_SdtRastreador_Rastreadordeviceidflespi_Z = 0;
         return  ;
      }

      public bool gxTv_SdtRastreador_Rastreadordeviceidflespi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RastreadorAtrelado_Z" )]
      [  XmlElement( ElementName = "RastreadorAtrelado_Z"   )]
      public bool gxTpr_Rastreadoratrelado_Z
      {
         get {
            return gxTv_SdtRastreador_Rastreadoratrelado_Z ;
         }

         set {
            gxTv_SdtRastreador_Rastreadoratrelado_Z = value;
            SetDirty("Rastreadoratrelado_Z");
         }

      }

      public void gxTv_SdtRastreador_Rastreadoratrelado_Z_SetNull( )
      {
         gxTv_SdtRastreador_Rastreadoratrelado_Z = false;
         return  ;
      }

      public bool gxTv_SdtRastreador_Rastreadoratrelado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ChipGSMId_Z" )]
      [  XmlElement( ElementName = "ChipGSMId_Z"   )]
      public int gxTpr_Chipgsmid_Z
      {
         get {
            return gxTv_SdtRastreador_Chipgsmid_Z ;
         }

         set {
            gxTv_SdtRastreador_Chipgsmid_Z = value;
            SetDirty("Chipgsmid_Z");
         }

      }

      public void gxTv_SdtRastreador_Chipgsmid_Z_SetNull( )
      {
         gxTv_SdtRastreador_Chipgsmid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtRastreador_Chipgsmid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ChipGSMOperadora_Z" )]
      [  XmlElement( ElementName = "ChipGSMOperadora_Z"   )]
      public string gxTpr_Chipgsmoperadora_Z
      {
         get {
            return gxTv_SdtRastreador_Chipgsmoperadora_Z ;
         }

         set {
            gxTv_SdtRastreador_Chipgsmoperadora_Z = value;
            SetDirty("Chipgsmoperadora_Z");
         }

      }

      public void gxTv_SdtRastreador_Chipgsmoperadora_Z_SetNull( )
      {
         gxTv_SdtRastreador_Chipgsmoperadora_Z = "";
         return  ;
      }

      public bool gxTv_SdtRastreador_Chipgsmoperadora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ChipGSMNumero_Z" )]
      [  XmlElement( ElementName = "ChipGSMNumero_Z"   )]
      public string gxTpr_Chipgsmnumero_Z
      {
         get {
            return gxTv_SdtRastreador_Chipgsmnumero_Z ;
         }

         set {
            gxTv_SdtRastreador_Chipgsmnumero_Z = value;
            SetDirty("Chipgsmnumero_Z");
         }

      }

      public void gxTv_SdtRastreador_Chipgsmnumero_Z_SetNull( )
      {
         gxTv_SdtRastreador_Chipgsmnumero_Z = "";
         return  ;
      }

      public bool gxTv_SdtRastreador_Chipgsmnumero_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RastreadorFabricante_N" )]
      [  XmlElement( ElementName = "RastreadorFabricante_N"   )]
      public short gxTpr_Rastreadorfabricante_N
      {
         get {
            return gxTv_SdtRastreador_Rastreadorfabricante_N ;
         }

         set {
            gxTv_SdtRastreador_Rastreadorfabricante_N = value;
            SetDirty("Rastreadorfabricante_N");
         }

      }

      public void gxTv_SdtRastreador_Rastreadorfabricante_N_SetNull( )
      {
         gxTv_SdtRastreador_Rastreadorfabricante_N = 0;
         return  ;
      }

      public bool gxTv_SdtRastreador_Rastreadorfabricante_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RastreadorModelo_N" )]
      [  XmlElement( ElementName = "RastreadorModelo_N"   )]
      public short gxTpr_Rastreadormodelo_N
      {
         get {
            return gxTv_SdtRastreador_Rastreadormodelo_N ;
         }

         set {
            gxTv_SdtRastreador_Rastreadormodelo_N = value;
            SetDirty("Rastreadormodelo_N");
         }

      }

      public void gxTv_SdtRastreador_Rastreadormodelo_N_SetNull( )
      {
         gxTv_SdtRastreador_Rastreadormodelo_N = 0;
         return  ;
      }

      public bool gxTv_SdtRastreador_Rastreadormodelo_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtRastreador_Rastreadordatahoracriacao = (DateTime)(DateTime.MinValue);
         gxTv_SdtRastreador_Rastreadorgamguidproprietario = "";
         gxTv_SdtRastreador_Rastreadorfabricante = "";
         gxTv_SdtRastreador_Rastreadormodelo = "";
         gxTv_SdtRastreador_Chipgsmoperadora = "";
         gxTv_SdtRastreador_Chipgsmnumero = "";
         gxTv_SdtRastreador_Mode = "";
         gxTv_SdtRastreador_Rastreadordatahoracriacao_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtRastreador_Rastreadorgamguidproprietario_Z = "";
         gxTv_SdtRastreador_Rastreadorfabricante_Z = "";
         gxTv_SdtRastreador_Rastreadormodelo_Z = "";
         gxTv_SdtRastreador_Chipgsmoperadora_Z = "";
         gxTv_SdtRastreador_Chipgsmnumero_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "rastreador", "GeneXus.Programs.rastreador_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      private short gxTv_SdtRastreador_Initialized ;
      private short gxTv_SdtRastreador_Rastreadorfabricante_N ;
      private short gxTv_SdtRastreador_Rastreadormodelo_N ;
      private int gxTv_SdtRastreador_Rastreadorid ;
      private int gxTv_SdtRastreador_Chipgsmid ;
      private int gxTv_SdtRastreador_Rastreadorid_Z ;
      private int gxTv_SdtRastreador_Chipgsmid_Z ;
      private long gxTv_SdtRastreador_Rastreadorsnumber ;
      private long gxTv_SdtRastreador_Rastreadordeviceidflespi ;
      private long gxTv_SdtRastreador_Rastreadorsnumber_Z ;
      private long gxTv_SdtRastreador_Rastreadordeviceidflespi_Z ;
      private string gxTv_SdtRastreador_Rastreadorgamguidproprietario ;
      private string gxTv_SdtRastreador_Mode ;
      private string gxTv_SdtRastreador_Rastreadorgamguidproprietario_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtRastreador_Rastreadordatahoracriacao ;
      private DateTime gxTv_SdtRastreador_Rastreadordatahoracriacao_Z ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtRastreador_Rastreadoratrelado ;
      private bool gxTv_SdtRastreador_Rastreadoratrelado_Z ;
      private string gxTv_SdtRastreador_Rastreadorfabricante ;
      private string gxTv_SdtRastreador_Rastreadormodelo ;
      private string gxTv_SdtRastreador_Chipgsmoperadora ;
      private string gxTv_SdtRastreador_Chipgsmnumero ;
      private string gxTv_SdtRastreador_Rastreadorfabricante_Z ;
      private string gxTv_SdtRastreador_Rastreadormodelo_Z ;
      private string gxTv_SdtRastreador_Chipgsmoperadora_Z ;
      private string gxTv_SdtRastreador_Chipgsmnumero_Z ;
   }

   [DataContract(Name = @"Rastreador", Namespace = "RastreamentoTCC")]
   public class SdtRastreador_RESTInterface : GxGenericCollectionItem<SdtRastreador>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtRastreador_RESTInterface( ) : base()
      {
      }

      public SdtRastreador_RESTInterface( SdtRastreador psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "RastreadorId" , Order = 0 )]
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

      [DataMember( Name = "RastreadorDataHoraCriacao" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Rastreadordatahoracriacao
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Rastreadordatahoracriacao) ;
         }

         set {
            sdt.gxTpr_Rastreadordatahoracriacao = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "RastreadorGAMGUIDProprietario" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Rastreadorgamguidproprietario
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Rastreadorgamguidproprietario) ;
         }

         set {
            sdt.gxTpr_Rastreadorgamguidproprietario = value;
         }

      }

      [DataMember( Name = "RastreadorFabricante" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Rastreadorfabricante
      {
         get {
            return sdt.gxTpr_Rastreadorfabricante ;
         }

         set {
            sdt.gxTpr_Rastreadorfabricante = value;
         }

      }

      [DataMember( Name = "RastreadorModelo" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Rastreadormodelo
      {
         get {
            return sdt.gxTpr_Rastreadormodelo ;
         }

         set {
            sdt.gxTpr_Rastreadormodelo = value;
         }

      }

      [DataMember( Name = "RastreadorSNumber" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Rastreadorsnumber
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Rastreadorsnumber), 16, 0)) ;
         }

         set {
            sdt.gxTpr_Rastreadorsnumber = (long)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "RastreadorDeviceIdFlespi" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Rastreadordeviceidflespi
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Rastreadordeviceidflespi), 16, 0)) ;
         }

         set {
            sdt.gxTpr_Rastreadordeviceidflespi = (long)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "RastreadorAtrelado" , Order = 7 )]
      [GxSeudo()]
      public bool gxTpr_Rastreadoratrelado
      {
         get {
            return sdt.gxTpr_Rastreadoratrelado ;
         }

         set {
            sdt.gxTpr_Rastreadoratrelado = value;
         }

      }

      [DataMember( Name = "ChipGSMId" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Chipgsmid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Chipgsmid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Chipgsmid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "ChipGSMOperadora" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Chipgsmoperadora
      {
         get {
            return sdt.gxTpr_Chipgsmoperadora ;
         }

         set {
            sdt.gxTpr_Chipgsmoperadora = value;
         }

      }

      [DataMember( Name = "ChipGSMNumero" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Chipgsmnumero
      {
         get {
            return sdt.gxTpr_Chipgsmnumero ;
         }

         set {
            sdt.gxTpr_Chipgsmnumero = value;
         }

      }

      public SdtRastreador sdt
      {
         get {
            return (SdtRastreador)Sdt ;
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
            sdt = new SdtRastreador() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 11 )]
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

   [DataContract(Name = @"Rastreador", Namespace = "RastreamentoTCC")]
   public class SdtRastreador_RESTLInterface : GxGenericCollectionItem<SdtRastreador>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtRastreador_RESTLInterface( ) : base()
      {
      }

      public SdtRastreador_RESTLInterface( SdtRastreador psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "RastreadorSNumber" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Rastreadorsnumber
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Rastreadorsnumber), 16, 0)) ;
         }

         set {
            sdt.gxTpr_Rastreadorsnumber = (long)(NumberUtil.Val( value, "."));
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

      public SdtRastreador sdt
      {
         get {
            return (SdtRastreador)Sdt ;
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
            sdt = new SdtRastreador() ;
         }
      }

   }

}
