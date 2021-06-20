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
   [XmlRoot(ElementName = "UltimoDadoLido" )]
   [XmlType(TypeName =  "UltimoDadoLido" , Namespace = "RastreamentoTCC" )]
   [Serializable]
   public class SdtUltimoDadoLido : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtUltimoDadoLido( )
      {
      }

      public SdtUltimoDadoLido( IGxContext context )
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

      public void Load( int AV118UltimoDadoLidoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV118UltimoDadoLidoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"UltimoDadoLidoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "UltimoDadoLido");
         metadata.Set("BT", "UltimoDadoLido");
         metadata.Set("PK", "[ \"UltimoDadoLidoId\" ]");
         metadata.Set("PKAssigned", "[ \"UltimoDadoLidoId\" ]");
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
         state.Add("gxTpr_Ultimodadolidoid_Z");
         state.Add("gxTpr_Ultimodadolidogamguidproprietario_Z");
         state.Add("gxTpr_Ultimodadolidodatahoraservidor_Z_Nullable");
         state.Add("gxTpr_Ultimodadolidodatahorarastreador_Z_Nullable");
         state.Add("gxTpr_Ultimodadolidoplaca_Z");
         state.Add("gxTpr_Ultimodadolidoident_Z");
         state.Add("gxTpr_Ultimodadolidoignicao_Z");
         state.Add("gxTpr_Ultimodadolidovelocidade_Z");
         state.Add("gxTpr_Ultimodadolidolatitude_Z");
         state.Add("gxTpr_Ultimodadolidolongitude_Z");
         state.Add("gxTpr_Ultimodadolidogeolocalizacao_Z");
         state.Add("gxTpr_Ultimodadolidogamguidproprietario_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtUltimoDadoLido sdt;
         sdt = (SdtUltimoDadoLido)(source);
         gxTv_SdtUltimoDadoLido_Ultimodadolidoid = sdt.gxTv_SdtUltimoDadoLido_Ultimodadolidoid ;
         gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario = sdt.gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario ;
         gxTv_SdtUltimoDadoLido_Ultimodadolidodatahoraservidor = sdt.gxTv_SdtUltimoDadoLido_Ultimodadolidodatahoraservidor ;
         gxTv_SdtUltimoDadoLido_Ultimodadolidodatahorarastreador = sdt.gxTv_SdtUltimoDadoLido_Ultimodadolidodatahorarastreador ;
         gxTv_SdtUltimoDadoLido_Ultimodadolidoplaca = sdt.gxTv_SdtUltimoDadoLido_Ultimodadolidoplaca ;
         gxTv_SdtUltimoDadoLido_Ultimodadolidoident = sdt.gxTv_SdtUltimoDadoLido_Ultimodadolidoident ;
         gxTv_SdtUltimoDadoLido_Ultimodadolidoignicao = sdt.gxTv_SdtUltimoDadoLido_Ultimodadolidoignicao ;
         gxTv_SdtUltimoDadoLido_Ultimodadolidovelocidade = sdt.gxTv_SdtUltimoDadoLido_Ultimodadolidovelocidade ;
         gxTv_SdtUltimoDadoLido_Ultimodadolidolatitude = sdt.gxTv_SdtUltimoDadoLido_Ultimodadolidolatitude ;
         gxTv_SdtUltimoDadoLido_Ultimodadolidolongitude = sdt.gxTv_SdtUltimoDadoLido_Ultimodadolidolongitude ;
         gxTv_SdtUltimoDadoLido_Ultimodadolidogeolocalizacao = sdt.gxTv_SdtUltimoDadoLido_Ultimodadolidogeolocalizacao ;
         gxTv_SdtUltimoDadoLido_Mode = sdt.gxTv_SdtUltimoDadoLido_Mode ;
         gxTv_SdtUltimoDadoLido_Initialized = sdt.gxTv_SdtUltimoDadoLido_Initialized ;
         gxTv_SdtUltimoDadoLido_Ultimodadolidoid_Z = sdt.gxTv_SdtUltimoDadoLido_Ultimodadolidoid_Z ;
         gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario_Z = sdt.gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario_Z ;
         gxTv_SdtUltimoDadoLido_Ultimodadolidodatahoraservidor_Z = sdt.gxTv_SdtUltimoDadoLido_Ultimodadolidodatahoraservidor_Z ;
         gxTv_SdtUltimoDadoLido_Ultimodadolidodatahorarastreador_Z = sdt.gxTv_SdtUltimoDadoLido_Ultimodadolidodatahorarastreador_Z ;
         gxTv_SdtUltimoDadoLido_Ultimodadolidoplaca_Z = sdt.gxTv_SdtUltimoDadoLido_Ultimodadolidoplaca_Z ;
         gxTv_SdtUltimoDadoLido_Ultimodadolidoident_Z = sdt.gxTv_SdtUltimoDadoLido_Ultimodadolidoident_Z ;
         gxTv_SdtUltimoDadoLido_Ultimodadolidoignicao_Z = sdt.gxTv_SdtUltimoDadoLido_Ultimodadolidoignicao_Z ;
         gxTv_SdtUltimoDadoLido_Ultimodadolidovelocidade_Z = sdt.gxTv_SdtUltimoDadoLido_Ultimodadolidovelocidade_Z ;
         gxTv_SdtUltimoDadoLido_Ultimodadolidolatitude_Z = sdt.gxTv_SdtUltimoDadoLido_Ultimodadolidolatitude_Z ;
         gxTv_SdtUltimoDadoLido_Ultimodadolidolongitude_Z = sdt.gxTv_SdtUltimoDadoLido_Ultimodadolidolongitude_Z ;
         gxTv_SdtUltimoDadoLido_Ultimodadolidogeolocalizacao_Z = sdt.gxTv_SdtUltimoDadoLido_Ultimodadolidogeolocalizacao_Z ;
         gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario_N = sdt.gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario_N ;
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
         AddObjectProperty("UltimoDadoLidoId", gxTv_SdtUltimoDadoLido_Ultimodadolidoid, false, includeNonInitialized);
         AddObjectProperty("UltimoDadoLidoGAMGUIDProprietario", gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario, false, includeNonInitialized);
         AddObjectProperty("UltimoDadoLidoGAMGUIDProprietario_N", gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtUltimoDadoLido_Ultimodadolidodatahoraservidor;
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
         AddObjectProperty("UltimoDadoLidoDataHoraServidor", sDateCnv, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtUltimoDadoLido_Ultimodadolidodatahorarastreador;
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
         AddObjectProperty("UltimoDadoLidoDataHoraRastreador", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("UltimoDadoLidoPlaca", gxTv_SdtUltimoDadoLido_Ultimodadolidoplaca, false, includeNonInitialized);
         AddObjectProperty("UltimoDadoLidoIdent", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtUltimoDadoLido_Ultimodadolidoident), 16, 0)), false, includeNonInitialized);
         AddObjectProperty("UltimoDadoLidoIgnicao", gxTv_SdtUltimoDadoLido_Ultimodadolidoignicao, false, includeNonInitialized);
         AddObjectProperty("UltimoDadoLidoVelocidade", gxTv_SdtUltimoDadoLido_Ultimodadolidovelocidade, false, includeNonInitialized);
         AddObjectProperty("UltimoDadoLidoLatitude", gxTv_SdtUltimoDadoLido_Ultimodadolidolatitude, false, includeNonInitialized);
         AddObjectProperty("UltimoDadoLidoLongitude", gxTv_SdtUltimoDadoLido_Ultimodadolidolongitude, false, includeNonInitialized);
         AddObjectProperty("UltimoDadoLidoGeolocalizacao", gxTv_SdtUltimoDadoLido_Ultimodadolidogeolocalizacao, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtUltimoDadoLido_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtUltimoDadoLido_Initialized, false, includeNonInitialized);
            AddObjectProperty("UltimoDadoLidoId_Z", gxTv_SdtUltimoDadoLido_Ultimodadolidoid_Z, false, includeNonInitialized);
            AddObjectProperty("UltimoDadoLidoGAMGUIDProprietario_Z", gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtUltimoDadoLido_Ultimodadolidodatahoraservidor_Z;
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
            AddObjectProperty("UltimoDadoLidoDataHoraServidor_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtUltimoDadoLido_Ultimodadolidodatahorarastreador_Z;
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
            AddObjectProperty("UltimoDadoLidoDataHoraRastreador_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("UltimoDadoLidoPlaca_Z", gxTv_SdtUltimoDadoLido_Ultimodadolidoplaca_Z, false, includeNonInitialized);
            AddObjectProperty("UltimoDadoLidoIdent_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtUltimoDadoLido_Ultimodadolidoident_Z), 16, 0)), false, includeNonInitialized);
            AddObjectProperty("UltimoDadoLidoIgnicao_Z", gxTv_SdtUltimoDadoLido_Ultimodadolidoignicao_Z, false, includeNonInitialized);
            AddObjectProperty("UltimoDadoLidoVelocidade_Z", gxTv_SdtUltimoDadoLido_Ultimodadolidovelocidade_Z, false, includeNonInitialized);
            AddObjectProperty("UltimoDadoLidoLatitude_Z", gxTv_SdtUltimoDadoLido_Ultimodadolidolatitude_Z, false, includeNonInitialized);
            AddObjectProperty("UltimoDadoLidoLongitude_Z", gxTv_SdtUltimoDadoLido_Ultimodadolidolongitude_Z, false, includeNonInitialized);
            AddObjectProperty("UltimoDadoLidoGeolocalizacao_Z", gxTv_SdtUltimoDadoLido_Ultimodadolidogeolocalizacao_Z, false, includeNonInitialized);
            AddObjectProperty("UltimoDadoLidoGAMGUIDProprietario_N", gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtUltimoDadoLido sdt )
      {
         if ( sdt.IsDirty("UltimoDadoLidoId") )
         {
            gxTv_SdtUltimoDadoLido_Ultimodadolidoid = sdt.gxTv_SdtUltimoDadoLido_Ultimodadolidoid ;
         }
         if ( sdt.IsDirty("UltimoDadoLidoGAMGUIDProprietario") )
         {
            gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario_N = 0;
            gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario = sdt.gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario ;
         }
         if ( sdt.IsDirty("UltimoDadoLidoDataHoraServidor") )
         {
            gxTv_SdtUltimoDadoLido_Ultimodadolidodatahoraservidor = sdt.gxTv_SdtUltimoDadoLido_Ultimodadolidodatahoraservidor ;
         }
         if ( sdt.IsDirty("UltimoDadoLidoDataHoraRastreador") )
         {
            gxTv_SdtUltimoDadoLido_Ultimodadolidodatahorarastreador = sdt.gxTv_SdtUltimoDadoLido_Ultimodadolidodatahorarastreador ;
         }
         if ( sdt.IsDirty("UltimoDadoLidoPlaca") )
         {
            gxTv_SdtUltimoDadoLido_Ultimodadolidoplaca = sdt.gxTv_SdtUltimoDadoLido_Ultimodadolidoplaca ;
         }
         if ( sdt.IsDirty("UltimoDadoLidoIdent") )
         {
            gxTv_SdtUltimoDadoLido_Ultimodadolidoident = sdt.gxTv_SdtUltimoDadoLido_Ultimodadolidoident ;
         }
         if ( sdt.IsDirty("UltimoDadoLidoIgnicao") )
         {
            gxTv_SdtUltimoDadoLido_Ultimodadolidoignicao = sdt.gxTv_SdtUltimoDadoLido_Ultimodadolidoignicao ;
         }
         if ( sdt.IsDirty("UltimoDadoLidoVelocidade") )
         {
            gxTv_SdtUltimoDadoLido_Ultimodadolidovelocidade = sdt.gxTv_SdtUltimoDadoLido_Ultimodadolidovelocidade ;
         }
         if ( sdt.IsDirty("UltimoDadoLidoLatitude") )
         {
            gxTv_SdtUltimoDadoLido_Ultimodadolidolatitude = sdt.gxTv_SdtUltimoDadoLido_Ultimodadolidolatitude ;
         }
         if ( sdt.IsDirty("UltimoDadoLidoLongitude") )
         {
            gxTv_SdtUltimoDadoLido_Ultimodadolidolongitude = sdt.gxTv_SdtUltimoDadoLido_Ultimodadolidolongitude ;
         }
         if ( sdt.IsDirty("UltimoDadoLidoGeolocalizacao") )
         {
            gxTv_SdtUltimoDadoLido_Ultimodadolidogeolocalizacao = sdt.gxTv_SdtUltimoDadoLido_Ultimodadolidogeolocalizacao ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "UltimoDadoLidoId" )]
      [  XmlElement( ElementName = "UltimoDadoLidoId"   )]
      public int gxTpr_Ultimodadolidoid
      {
         get {
            return gxTv_SdtUltimoDadoLido_Ultimodadolidoid ;
         }

         set {
            if ( gxTv_SdtUltimoDadoLido_Ultimodadolidoid != value )
            {
               gxTv_SdtUltimoDadoLido_Mode = "INS";
               this.gxTv_SdtUltimoDadoLido_Ultimodadolidoid_Z_SetNull( );
               this.gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario_Z_SetNull( );
               this.gxTv_SdtUltimoDadoLido_Ultimodadolidodatahoraservidor_Z_SetNull( );
               this.gxTv_SdtUltimoDadoLido_Ultimodadolidodatahorarastreador_Z_SetNull( );
               this.gxTv_SdtUltimoDadoLido_Ultimodadolidoplaca_Z_SetNull( );
               this.gxTv_SdtUltimoDadoLido_Ultimodadolidoident_Z_SetNull( );
               this.gxTv_SdtUltimoDadoLido_Ultimodadolidoignicao_Z_SetNull( );
               this.gxTv_SdtUltimoDadoLido_Ultimodadolidovelocidade_Z_SetNull( );
               this.gxTv_SdtUltimoDadoLido_Ultimodadolidolatitude_Z_SetNull( );
               this.gxTv_SdtUltimoDadoLido_Ultimodadolidolongitude_Z_SetNull( );
               this.gxTv_SdtUltimoDadoLido_Ultimodadolidogeolocalizacao_Z_SetNull( );
            }
            gxTv_SdtUltimoDadoLido_Ultimodadolidoid = value;
            SetDirty("Ultimodadolidoid");
         }

      }

      [  SoapElement( ElementName = "UltimoDadoLidoGAMGUIDProprietario" )]
      [  XmlElement( ElementName = "UltimoDadoLidoGAMGUIDProprietario"   )]
      public string gxTpr_Ultimodadolidogamguidproprietario
      {
         get {
            return gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario ;
         }

         set {
            gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario_N = 0;
            gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario = value;
            SetDirty("Ultimodadolidogamguidproprietario");
         }

      }

      public void gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario_SetNull( )
      {
         gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario_N = 1;
         gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario = "";
         return  ;
      }

      public bool gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario_IsNull( )
      {
         return (gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario_N==1) ;
      }

      [  SoapElement( ElementName = "UltimoDadoLidoDataHoraServidor" )]
      [  XmlElement( ElementName = "UltimoDadoLidoDataHoraServidor"  , IsNullable=true )]
      public string gxTpr_Ultimodadolidodatahoraservidor_Nullable
      {
         get {
            if ( gxTv_SdtUltimoDadoLido_Ultimodadolidodatahoraservidor == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtUltimoDadoLido_Ultimodadolidodatahoraservidor).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtUltimoDadoLido_Ultimodadolidodatahoraservidor = DateTime.MinValue;
            else
               gxTv_SdtUltimoDadoLido_Ultimodadolidodatahoraservidor = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Ultimodadolidodatahoraservidor
      {
         get {
            return gxTv_SdtUltimoDadoLido_Ultimodadolidodatahoraservidor ;
         }

         set {
            gxTv_SdtUltimoDadoLido_Ultimodadolidodatahoraservidor = value;
            SetDirty("Ultimodadolidodatahoraservidor");
         }

      }

      [  SoapElement( ElementName = "UltimoDadoLidoDataHoraRastreador" )]
      [  XmlElement( ElementName = "UltimoDadoLidoDataHoraRastreador"  , IsNullable=true )]
      public string gxTpr_Ultimodadolidodatahorarastreador_Nullable
      {
         get {
            if ( gxTv_SdtUltimoDadoLido_Ultimodadolidodatahorarastreador == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtUltimoDadoLido_Ultimodadolidodatahorarastreador).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtUltimoDadoLido_Ultimodadolidodatahorarastreador = DateTime.MinValue;
            else
               gxTv_SdtUltimoDadoLido_Ultimodadolidodatahorarastreador = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Ultimodadolidodatahorarastreador
      {
         get {
            return gxTv_SdtUltimoDadoLido_Ultimodadolidodatahorarastreador ;
         }

         set {
            gxTv_SdtUltimoDadoLido_Ultimodadolidodatahorarastreador = value;
            SetDirty("Ultimodadolidodatahorarastreador");
         }

      }

      [  SoapElement( ElementName = "UltimoDadoLidoPlaca" )]
      [  XmlElement( ElementName = "UltimoDadoLidoPlaca"   )]
      public string gxTpr_Ultimodadolidoplaca
      {
         get {
            return gxTv_SdtUltimoDadoLido_Ultimodadolidoplaca ;
         }

         set {
            gxTv_SdtUltimoDadoLido_Ultimodadolidoplaca = value;
            SetDirty("Ultimodadolidoplaca");
         }

      }

      [  SoapElement( ElementName = "UltimoDadoLidoIdent" )]
      [  XmlElement( ElementName = "UltimoDadoLidoIdent"   )]
      public long gxTpr_Ultimodadolidoident
      {
         get {
            return gxTv_SdtUltimoDadoLido_Ultimodadolidoident ;
         }

         set {
            gxTv_SdtUltimoDadoLido_Ultimodadolidoident = value;
            SetDirty("Ultimodadolidoident");
         }

      }

      [  SoapElement( ElementName = "UltimoDadoLidoIgnicao" )]
      [  XmlElement( ElementName = "UltimoDadoLidoIgnicao"   )]
      public short gxTpr_Ultimodadolidoignicao
      {
         get {
            return gxTv_SdtUltimoDadoLido_Ultimodadolidoignicao ;
         }

         set {
            gxTv_SdtUltimoDadoLido_Ultimodadolidoignicao = value;
            SetDirty("Ultimodadolidoignicao");
         }

      }

      [  SoapElement( ElementName = "UltimoDadoLidoVelocidade" )]
      [  XmlElement( ElementName = "UltimoDadoLidoVelocidade"   )]
      public short gxTpr_Ultimodadolidovelocidade
      {
         get {
            return gxTv_SdtUltimoDadoLido_Ultimodadolidovelocidade ;
         }

         set {
            gxTv_SdtUltimoDadoLido_Ultimodadolidovelocidade = value;
            SetDirty("Ultimodadolidovelocidade");
         }

      }

      [  SoapElement( ElementName = "UltimoDadoLidoLatitude" )]
      [  XmlElement( ElementName = "UltimoDadoLidoLatitude"   )]
      public string gxTpr_Ultimodadolidolatitude
      {
         get {
            return gxTv_SdtUltimoDadoLido_Ultimodadolidolatitude ;
         }

         set {
            gxTv_SdtUltimoDadoLido_Ultimodadolidolatitude = value;
            SetDirty("Ultimodadolidolatitude");
         }

      }

      [  SoapElement( ElementName = "UltimoDadoLidoLongitude" )]
      [  XmlElement( ElementName = "UltimoDadoLidoLongitude"   )]
      public string gxTpr_Ultimodadolidolongitude
      {
         get {
            return gxTv_SdtUltimoDadoLido_Ultimodadolidolongitude ;
         }

         set {
            gxTv_SdtUltimoDadoLido_Ultimodadolidolongitude = value;
            SetDirty("Ultimodadolidolongitude");
         }

      }

      [  SoapElement( ElementName = "UltimoDadoLidoGeolocalizacao" )]
      [  XmlElement( ElementName = "UltimoDadoLidoGeolocalizacao"   )]
      public string gxTpr_Ultimodadolidogeolocalizacao
      {
         get {
            return gxTv_SdtUltimoDadoLido_Ultimodadolidogeolocalizacao ;
         }

         set {
            gxTv_SdtUltimoDadoLido_Ultimodadolidogeolocalizacao = value;
            SetDirty("Ultimodadolidogeolocalizacao");
         }

      }

      public void gxTv_SdtUltimoDadoLido_Ultimodadolidogeolocalizacao_SetNull( )
      {
         gxTv_SdtUltimoDadoLido_Ultimodadolidogeolocalizacao = "";
         return  ;
      }

      public bool gxTv_SdtUltimoDadoLido_Ultimodadolidogeolocalizacao_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtUltimoDadoLido_Mode ;
         }

         set {
            gxTv_SdtUltimoDadoLido_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtUltimoDadoLido_Mode_SetNull( )
      {
         gxTv_SdtUltimoDadoLido_Mode = "";
         return  ;
      }

      public bool gxTv_SdtUltimoDadoLido_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtUltimoDadoLido_Initialized ;
         }

         set {
            gxTv_SdtUltimoDadoLido_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtUltimoDadoLido_Initialized_SetNull( )
      {
         gxTv_SdtUltimoDadoLido_Initialized = 0;
         return  ;
      }

      public bool gxTv_SdtUltimoDadoLido_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UltimoDadoLidoId_Z" )]
      [  XmlElement( ElementName = "UltimoDadoLidoId_Z"   )]
      public int gxTpr_Ultimodadolidoid_Z
      {
         get {
            return gxTv_SdtUltimoDadoLido_Ultimodadolidoid_Z ;
         }

         set {
            gxTv_SdtUltimoDadoLido_Ultimodadolidoid_Z = value;
            SetDirty("Ultimodadolidoid_Z");
         }

      }

      public void gxTv_SdtUltimoDadoLido_Ultimodadolidoid_Z_SetNull( )
      {
         gxTv_SdtUltimoDadoLido_Ultimodadolidoid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtUltimoDadoLido_Ultimodadolidoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UltimoDadoLidoGAMGUIDProprietario_Z" )]
      [  XmlElement( ElementName = "UltimoDadoLidoGAMGUIDProprietario_Z"   )]
      public string gxTpr_Ultimodadolidogamguidproprietario_Z
      {
         get {
            return gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario_Z ;
         }

         set {
            gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario_Z = value;
            SetDirty("Ultimodadolidogamguidproprietario_Z");
         }

      }

      public void gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario_Z_SetNull( )
      {
         gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario_Z = "";
         return  ;
      }

      public bool gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UltimoDadoLidoDataHoraServidor_Z" )]
      [  XmlElement( ElementName = "UltimoDadoLidoDataHoraServidor_Z"  , IsNullable=true )]
      public string gxTpr_Ultimodadolidodatahoraservidor_Z_Nullable
      {
         get {
            if ( gxTv_SdtUltimoDadoLido_Ultimodadolidodatahoraservidor_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtUltimoDadoLido_Ultimodadolidodatahoraservidor_Z).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtUltimoDadoLido_Ultimodadolidodatahoraservidor_Z = DateTime.MinValue;
            else
               gxTv_SdtUltimoDadoLido_Ultimodadolidodatahoraservidor_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Ultimodadolidodatahoraservidor_Z
      {
         get {
            return gxTv_SdtUltimoDadoLido_Ultimodadolidodatahoraservidor_Z ;
         }

         set {
            gxTv_SdtUltimoDadoLido_Ultimodadolidodatahoraservidor_Z = value;
            SetDirty("Ultimodadolidodatahoraservidor_Z");
         }

      }

      public void gxTv_SdtUltimoDadoLido_Ultimodadolidodatahoraservidor_Z_SetNull( )
      {
         gxTv_SdtUltimoDadoLido_Ultimodadolidodatahoraservidor_Z = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtUltimoDadoLido_Ultimodadolidodatahoraservidor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UltimoDadoLidoDataHoraRastreador_Z" )]
      [  XmlElement( ElementName = "UltimoDadoLidoDataHoraRastreador_Z"  , IsNullable=true )]
      public string gxTpr_Ultimodadolidodatahorarastreador_Z_Nullable
      {
         get {
            if ( gxTv_SdtUltimoDadoLido_Ultimodadolidodatahorarastreador_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtUltimoDadoLido_Ultimodadolidodatahorarastreador_Z).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtUltimoDadoLido_Ultimodadolidodatahorarastreador_Z = DateTime.MinValue;
            else
               gxTv_SdtUltimoDadoLido_Ultimodadolidodatahorarastreador_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Ultimodadolidodatahorarastreador_Z
      {
         get {
            return gxTv_SdtUltimoDadoLido_Ultimodadolidodatahorarastreador_Z ;
         }

         set {
            gxTv_SdtUltimoDadoLido_Ultimodadolidodatahorarastreador_Z = value;
            SetDirty("Ultimodadolidodatahorarastreador_Z");
         }

      }

      public void gxTv_SdtUltimoDadoLido_Ultimodadolidodatahorarastreador_Z_SetNull( )
      {
         gxTv_SdtUltimoDadoLido_Ultimodadolidodatahorarastreador_Z = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtUltimoDadoLido_Ultimodadolidodatahorarastreador_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UltimoDadoLidoPlaca_Z" )]
      [  XmlElement( ElementName = "UltimoDadoLidoPlaca_Z"   )]
      public string gxTpr_Ultimodadolidoplaca_Z
      {
         get {
            return gxTv_SdtUltimoDadoLido_Ultimodadolidoplaca_Z ;
         }

         set {
            gxTv_SdtUltimoDadoLido_Ultimodadolidoplaca_Z = value;
            SetDirty("Ultimodadolidoplaca_Z");
         }

      }

      public void gxTv_SdtUltimoDadoLido_Ultimodadolidoplaca_Z_SetNull( )
      {
         gxTv_SdtUltimoDadoLido_Ultimodadolidoplaca_Z = "";
         return  ;
      }

      public bool gxTv_SdtUltimoDadoLido_Ultimodadolidoplaca_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UltimoDadoLidoIdent_Z" )]
      [  XmlElement( ElementName = "UltimoDadoLidoIdent_Z"   )]
      public long gxTpr_Ultimodadolidoident_Z
      {
         get {
            return gxTv_SdtUltimoDadoLido_Ultimodadolidoident_Z ;
         }

         set {
            gxTv_SdtUltimoDadoLido_Ultimodadolidoident_Z = value;
            SetDirty("Ultimodadolidoident_Z");
         }

      }

      public void gxTv_SdtUltimoDadoLido_Ultimodadolidoident_Z_SetNull( )
      {
         gxTv_SdtUltimoDadoLido_Ultimodadolidoident_Z = 0;
         return  ;
      }

      public bool gxTv_SdtUltimoDadoLido_Ultimodadolidoident_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UltimoDadoLidoIgnicao_Z" )]
      [  XmlElement( ElementName = "UltimoDadoLidoIgnicao_Z"   )]
      public short gxTpr_Ultimodadolidoignicao_Z
      {
         get {
            return gxTv_SdtUltimoDadoLido_Ultimodadolidoignicao_Z ;
         }

         set {
            gxTv_SdtUltimoDadoLido_Ultimodadolidoignicao_Z = value;
            SetDirty("Ultimodadolidoignicao_Z");
         }

      }

      public void gxTv_SdtUltimoDadoLido_Ultimodadolidoignicao_Z_SetNull( )
      {
         gxTv_SdtUltimoDadoLido_Ultimodadolidoignicao_Z = 0;
         return  ;
      }

      public bool gxTv_SdtUltimoDadoLido_Ultimodadolidoignicao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UltimoDadoLidoVelocidade_Z" )]
      [  XmlElement( ElementName = "UltimoDadoLidoVelocidade_Z"   )]
      public short gxTpr_Ultimodadolidovelocidade_Z
      {
         get {
            return gxTv_SdtUltimoDadoLido_Ultimodadolidovelocidade_Z ;
         }

         set {
            gxTv_SdtUltimoDadoLido_Ultimodadolidovelocidade_Z = value;
            SetDirty("Ultimodadolidovelocidade_Z");
         }

      }

      public void gxTv_SdtUltimoDadoLido_Ultimodadolidovelocidade_Z_SetNull( )
      {
         gxTv_SdtUltimoDadoLido_Ultimodadolidovelocidade_Z = 0;
         return  ;
      }

      public bool gxTv_SdtUltimoDadoLido_Ultimodadolidovelocidade_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UltimoDadoLidoLatitude_Z" )]
      [  XmlElement( ElementName = "UltimoDadoLidoLatitude_Z"   )]
      public string gxTpr_Ultimodadolidolatitude_Z
      {
         get {
            return gxTv_SdtUltimoDadoLido_Ultimodadolidolatitude_Z ;
         }

         set {
            gxTv_SdtUltimoDadoLido_Ultimodadolidolatitude_Z = value;
            SetDirty("Ultimodadolidolatitude_Z");
         }

      }

      public void gxTv_SdtUltimoDadoLido_Ultimodadolidolatitude_Z_SetNull( )
      {
         gxTv_SdtUltimoDadoLido_Ultimodadolidolatitude_Z = "";
         return  ;
      }

      public bool gxTv_SdtUltimoDadoLido_Ultimodadolidolatitude_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UltimoDadoLidoLongitude_Z" )]
      [  XmlElement( ElementName = "UltimoDadoLidoLongitude_Z"   )]
      public string gxTpr_Ultimodadolidolongitude_Z
      {
         get {
            return gxTv_SdtUltimoDadoLido_Ultimodadolidolongitude_Z ;
         }

         set {
            gxTv_SdtUltimoDadoLido_Ultimodadolidolongitude_Z = value;
            SetDirty("Ultimodadolidolongitude_Z");
         }

      }

      public void gxTv_SdtUltimoDadoLido_Ultimodadolidolongitude_Z_SetNull( )
      {
         gxTv_SdtUltimoDadoLido_Ultimodadolidolongitude_Z = "";
         return  ;
      }

      public bool gxTv_SdtUltimoDadoLido_Ultimodadolidolongitude_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UltimoDadoLidoGeolocalizacao_Z" )]
      [  XmlElement( ElementName = "UltimoDadoLidoGeolocalizacao_Z"   )]
      public string gxTpr_Ultimodadolidogeolocalizacao_Z
      {
         get {
            return gxTv_SdtUltimoDadoLido_Ultimodadolidogeolocalizacao_Z ;
         }

         set {
            gxTv_SdtUltimoDadoLido_Ultimodadolidogeolocalizacao_Z = value;
            SetDirty("Ultimodadolidogeolocalizacao_Z");
         }

      }

      public void gxTv_SdtUltimoDadoLido_Ultimodadolidogeolocalizacao_Z_SetNull( )
      {
         gxTv_SdtUltimoDadoLido_Ultimodadolidogeolocalizacao_Z = "";
         return  ;
      }

      public bool gxTv_SdtUltimoDadoLido_Ultimodadolidogeolocalizacao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UltimoDadoLidoGAMGUIDProprietario_N" )]
      [  XmlElement( ElementName = "UltimoDadoLidoGAMGUIDProprietario_N"   )]
      public short gxTpr_Ultimodadolidogamguidproprietario_N
      {
         get {
            return gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario_N ;
         }

         set {
            gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario_N = value;
            SetDirty("Ultimodadolidogamguidproprietario_N");
         }

      }

      public void gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario_N_SetNull( )
      {
         gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario_N = 0;
         return  ;
      }

      public bool gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario = "";
         gxTv_SdtUltimoDadoLido_Ultimodadolidodatahoraservidor = (DateTime)(DateTime.MinValue);
         gxTv_SdtUltimoDadoLido_Ultimodadolidodatahorarastreador = (DateTime)(DateTime.MinValue);
         gxTv_SdtUltimoDadoLido_Ultimodadolidoplaca = "";
         gxTv_SdtUltimoDadoLido_Ultimodadolidolatitude = "";
         gxTv_SdtUltimoDadoLido_Ultimodadolidolongitude = "";
         gxTv_SdtUltimoDadoLido_Ultimodadolidogeolocalizacao = "";
         gxTv_SdtUltimoDadoLido_Mode = "";
         gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario_Z = "";
         gxTv_SdtUltimoDadoLido_Ultimodadolidodatahoraservidor_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtUltimoDadoLido_Ultimodadolidodatahorarastreador_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtUltimoDadoLido_Ultimodadolidoplaca_Z = "";
         gxTv_SdtUltimoDadoLido_Ultimodadolidolatitude_Z = "";
         gxTv_SdtUltimoDadoLido_Ultimodadolidolongitude_Z = "";
         gxTv_SdtUltimoDadoLido_Ultimodadolidogeolocalizacao_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "ultimodadolido", "GeneXus.Programs.ultimodadolido_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      private short gxTv_SdtUltimoDadoLido_Ultimodadolidoignicao ;
      private short gxTv_SdtUltimoDadoLido_Ultimodadolidovelocidade ;
      private short gxTv_SdtUltimoDadoLido_Initialized ;
      private short gxTv_SdtUltimoDadoLido_Ultimodadolidoignicao_Z ;
      private short gxTv_SdtUltimoDadoLido_Ultimodadolidovelocidade_Z ;
      private short gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario_N ;
      private int gxTv_SdtUltimoDadoLido_Ultimodadolidoid ;
      private int gxTv_SdtUltimoDadoLido_Ultimodadolidoid_Z ;
      private long gxTv_SdtUltimoDadoLido_Ultimodadolidoident ;
      private long gxTv_SdtUltimoDadoLido_Ultimodadolidoident_Z ;
      private string gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario ;
      private string gxTv_SdtUltimoDadoLido_Mode ;
      private string gxTv_SdtUltimoDadoLido_Ultimodadolidogamguidproprietario_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtUltimoDadoLido_Ultimodadolidodatahoraservidor ;
      private DateTime gxTv_SdtUltimoDadoLido_Ultimodadolidodatahorarastreador ;
      private DateTime gxTv_SdtUltimoDadoLido_Ultimodadolidodatahoraservidor_Z ;
      private DateTime gxTv_SdtUltimoDadoLido_Ultimodadolidodatahorarastreador_Z ;
      private DateTime datetime_STZ ;
      private string gxTv_SdtUltimoDadoLido_Ultimodadolidoplaca ;
      private string gxTv_SdtUltimoDadoLido_Ultimodadolidolatitude ;
      private string gxTv_SdtUltimoDadoLido_Ultimodadolidolongitude ;
      private string gxTv_SdtUltimoDadoLido_Ultimodadolidogeolocalizacao ;
      private string gxTv_SdtUltimoDadoLido_Ultimodadolidoplaca_Z ;
      private string gxTv_SdtUltimoDadoLido_Ultimodadolidolatitude_Z ;
      private string gxTv_SdtUltimoDadoLido_Ultimodadolidolongitude_Z ;
      private string gxTv_SdtUltimoDadoLido_Ultimodadolidogeolocalizacao_Z ;
   }

   [DataContract(Name = @"UltimoDadoLido", Namespace = "RastreamentoTCC")]
   public class SdtUltimoDadoLido_RESTInterface : GxGenericCollectionItem<SdtUltimoDadoLido>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtUltimoDadoLido_RESTInterface( ) : base()
      {
      }

      public SdtUltimoDadoLido_RESTInterface( SdtUltimoDadoLido psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "UltimoDadoLidoId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Ultimodadolidoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Ultimodadolidoid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Ultimodadolidoid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "UltimoDadoLidoGAMGUIDProprietario" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Ultimodadolidogamguidproprietario
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Ultimodadolidogamguidproprietario) ;
         }

         set {
            sdt.gxTpr_Ultimodadolidogamguidproprietario = value;
         }

      }

      [DataMember( Name = "UltimoDadoLidoDataHoraServidor" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Ultimodadolidodatahoraservidor
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Ultimodadolidodatahoraservidor) ;
         }

         set {
            sdt.gxTpr_Ultimodadolidodatahoraservidor = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "UltimoDadoLidoDataHoraRastreador" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Ultimodadolidodatahorarastreador
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Ultimodadolidodatahorarastreador) ;
         }

         set {
            sdt.gxTpr_Ultimodadolidodatahorarastreador = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "UltimoDadoLidoPlaca" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Ultimodadolidoplaca
      {
         get {
            return sdt.gxTpr_Ultimodadolidoplaca ;
         }

         set {
            sdt.gxTpr_Ultimodadolidoplaca = value;
         }

      }

      [DataMember( Name = "UltimoDadoLidoIdent" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Ultimodadolidoident
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Ultimodadolidoident), 16, 0)) ;
         }

         set {
            sdt.gxTpr_Ultimodadolidoident = (long)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "UltimoDadoLidoIgnicao" , Order = 6 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Ultimodadolidoignicao
      {
         get {
            return sdt.gxTpr_Ultimodadolidoignicao ;
         }

         set {
            sdt.gxTpr_Ultimodadolidoignicao = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "UltimoDadoLidoVelocidade" , Order = 7 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Ultimodadolidovelocidade
      {
         get {
            return sdt.gxTpr_Ultimodadolidovelocidade ;
         }

         set {
            sdt.gxTpr_Ultimodadolidovelocidade = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "UltimoDadoLidoLatitude" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Ultimodadolidolatitude
      {
         get {
            return sdt.gxTpr_Ultimodadolidolatitude ;
         }

         set {
            sdt.gxTpr_Ultimodadolidolatitude = value;
         }

      }

      [DataMember( Name = "UltimoDadoLidoLongitude" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Ultimodadolidolongitude
      {
         get {
            return sdt.gxTpr_Ultimodadolidolongitude ;
         }

         set {
            sdt.gxTpr_Ultimodadolidolongitude = value;
         }

      }

      [DataMember( Name = "UltimoDadoLidoGeolocalizacao" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Ultimodadolidogeolocalizacao
      {
         get {
            return sdt.gxTpr_Ultimodadolidogeolocalizacao ;
         }

         set {
            sdt.gxTpr_Ultimodadolidogeolocalizacao = value;
         }

      }

      public SdtUltimoDadoLido sdt
      {
         get {
            return (SdtUltimoDadoLido)Sdt ;
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
            sdt = new SdtUltimoDadoLido() ;
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

   [DataContract(Name = @"UltimoDadoLido", Namespace = "RastreamentoTCC")]
   public class SdtUltimoDadoLido_RESTLInterface : GxGenericCollectionItem<SdtUltimoDadoLido>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtUltimoDadoLido_RESTLInterface( ) : base()
      {
      }

      public SdtUltimoDadoLido_RESTLInterface( SdtUltimoDadoLido psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "UltimoDadoLidoPlaca" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Ultimodadolidoplaca
      {
         get {
            return sdt.gxTpr_Ultimodadolidoplaca ;
         }

         set {
            sdt.gxTpr_Ultimodadolidoplaca = value;
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

      public SdtUltimoDadoLido sdt
      {
         get {
            return (SdtUltimoDadoLido)Sdt ;
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
            sdt = new SdtUltimoDadoLido() ;
         }
      }

   }

}
