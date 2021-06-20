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
   [XmlRoot(ElementName = "ComandoEnviado" )]
   [XmlType(TypeName =  "ComandoEnviado" , Namespace = "RastreamentoTCC" )]
   [Serializable]
   public class SdtComandoEnviado : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtComandoEnviado( )
      {
      }

      public SdtComandoEnviado( IGxContext context )
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

      public void Load( int AV144ComandoEnviadoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV144ComandoEnviadoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ComandoEnviadoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "ComandoEnviado");
         metadata.Set("BT", "ComandoEnviado");
         metadata.Set("PK", "[ \"ComandoEnviadoId\" ]");
         metadata.Set("PKAssigned", "[ \"ComandoEnviadoId\" ]");
         metadata.Set("Levels", "[ \"Comando\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"RastreadorId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Comandoenviadoid_Z");
         state.Add("gxTpr_Comandoenviadoresponsavelguid_Z");
         state.Add("gxTpr_Comandoenviadodatahora_Z_Nullable");
         state.Add("gxTpr_Rastreadorid_Z");
         state.Add("gxTpr_Rastreadorsnumber_Z");
         state.Add("gxTpr_Comandoenviadoserial_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtComandoEnviado sdt;
         sdt = (SdtComandoEnviado)(source);
         gxTv_SdtComandoEnviado_Comandoenviadoid = sdt.gxTv_SdtComandoEnviado_Comandoenviadoid ;
         gxTv_SdtComandoEnviado_Comandoenviadoresponsavelguid = sdt.gxTv_SdtComandoEnviado_Comandoenviadoresponsavelguid ;
         gxTv_SdtComandoEnviado_Comandoenviadodatahora = sdt.gxTv_SdtComandoEnviado_Comandoenviadodatahora ;
         gxTv_SdtComandoEnviado_Rastreadorid = sdt.gxTv_SdtComandoEnviado_Rastreadorid ;
         gxTv_SdtComandoEnviado_Rastreadorsnumber = sdt.gxTv_SdtComandoEnviado_Rastreadorsnumber ;
         gxTv_SdtComandoEnviado_Comandoenviadoserial = sdt.gxTv_SdtComandoEnviado_Comandoenviadoserial ;
         gxTv_SdtComandoEnviado_Comando = sdt.gxTv_SdtComandoEnviado_Comando ;
         gxTv_SdtComandoEnviado_Mode = sdt.gxTv_SdtComandoEnviado_Mode ;
         gxTv_SdtComandoEnviado_Initialized = sdt.gxTv_SdtComandoEnviado_Initialized ;
         gxTv_SdtComandoEnviado_Comandoenviadoid_Z = sdt.gxTv_SdtComandoEnviado_Comandoenviadoid_Z ;
         gxTv_SdtComandoEnviado_Comandoenviadoresponsavelguid_Z = sdt.gxTv_SdtComandoEnviado_Comandoenviadoresponsavelguid_Z ;
         gxTv_SdtComandoEnviado_Comandoenviadodatahora_Z = sdt.gxTv_SdtComandoEnviado_Comandoenviadodatahora_Z ;
         gxTv_SdtComandoEnviado_Rastreadorid_Z = sdt.gxTv_SdtComandoEnviado_Rastreadorid_Z ;
         gxTv_SdtComandoEnviado_Rastreadorsnumber_Z = sdt.gxTv_SdtComandoEnviado_Rastreadorsnumber_Z ;
         gxTv_SdtComandoEnviado_Comandoenviadoserial_Z = sdt.gxTv_SdtComandoEnviado_Comandoenviadoserial_Z ;
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
         AddObjectProperty("ComandoEnviadoId", gxTv_SdtComandoEnviado_Comandoenviadoid, false, includeNonInitialized);
         AddObjectProperty("ComandoEnviadoResponsavelGUID", gxTv_SdtComandoEnviado_Comandoenviadoresponsavelguid, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtComandoEnviado_Comandoenviadodatahora;
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
         AddObjectProperty("ComandoEnviadoDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("RastreadorId", gxTv_SdtComandoEnviado_Rastreadorid, false, includeNonInitialized);
         AddObjectProperty("RastreadorSNumber", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtComandoEnviado_Rastreadorsnumber), 16, 0)), false, includeNonInitialized);
         AddObjectProperty("ComandoEnviadoSerial", gxTv_SdtComandoEnviado_Comandoenviadoserial, false, includeNonInitialized);
         if ( gxTv_SdtComandoEnviado_Comando != null )
         {
            AddObjectProperty("Comando", gxTv_SdtComandoEnviado_Comando, includeState, includeNonInitialized);
         }
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtComandoEnviado_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtComandoEnviado_Initialized, false, includeNonInitialized);
            AddObjectProperty("ComandoEnviadoId_Z", gxTv_SdtComandoEnviado_Comandoenviadoid_Z, false, includeNonInitialized);
            AddObjectProperty("ComandoEnviadoResponsavelGUID_Z", gxTv_SdtComandoEnviado_Comandoenviadoresponsavelguid_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtComandoEnviado_Comandoenviadodatahora_Z;
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
            AddObjectProperty("ComandoEnviadoDataHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("RastreadorId_Z", gxTv_SdtComandoEnviado_Rastreadorid_Z, false, includeNonInitialized);
            AddObjectProperty("RastreadorSNumber_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtComandoEnviado_Rastreadorsnumber_Z), 16, 0)), false, includeNonInitialized);
            AddObjectProperty("ComandoEnviadoSerial_Z", gxTv_SdtComandoEnviado_Comandoenviadoserial_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtComandoEnviado sdt )
      {
         if ( sdt.IsDirty("ComandoEnviadoId") )
         {
            gxTv_SdtComandoEnviado_Comandoenviadoid = sdt.gxTv_SdtComandoEnviado_Comandoenviadoid ;
         }
         if ( sdt.IsDirty("ComandoEnviadoResponsavelGUID") )
         {
            gxTv_SdtComandoEnviado_Comandoenviadoresponsavelguid = sdt.gxTv_SdtComandoEnviado_Comandoenviadoresponsavelguid ;
         }
         if ( sdt.IsDirty("ComandoEnviadoDataHora") )
         {
            gxTv_SdtComandoEnviado_Comandoenviadodatahora = sdt.gxTv_SdtComandoEnviado_Comandoenviadodatahora ;
         }
         if ( sdt.IsDirty("RastreadorId") )
         {
            gxTv_SdtComandoEnviado_Rastreadorid = sdt.gxTv_SdtComandoEnviado_Rastreadorid ;
         }
         if ( sdt.IsDirty("RastreadorSNumber") )
         {
            gxTv_SdtComandoEnviado_Rastreadorsnumber = sdt.gxTv_SdtComandoEnviado_Rastreadorsnumber ;
         }
         if ( sdt.IsDirty("ComandoEnviadoSerial") )
         {
            gxTv_SdtComandoEnviado_Comandoenviadoserial = sdt.gxTv_SdtComandoEnviado_Comandoenviadoserial ;
         }
         if ( gxTv_SdtComandoEnviado_Comando != null )
         {
            GXBCLevelCollection<SdtComandoEnviado_Comando> newCollectionComando = sdt.gxTpr_Comando;
            SdtComandoEnviado_Comando currItemComando;
            SdtComandoEnviado_Comando newItemComando;
            short idx = 1;
            while ( idx <= newCollectionComando.Count )
            {
               newItemComando = ((SdtComandoEnviado_Comando)newCollectionComando.Item(idx));
               currItemComando = gxTv_SdtComandoEnviado_Comando.GetByKey(newItemComando.gxTpr_Comandoenviadocomandoid);
               if ( StringUtil.StrCmp(currItemComando.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemComando.UpdateDirties(newItemComando);
                  if ( StringUtil.StrCmp(newItemComando.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemComando.gxTpr_Mode = "DLT";
                  }
                  currItemComando.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtComandoEnviado_Comando.Add(newItemComando, 0);
               }
               idx = (short)(idx+1);
            }
         }
         return  ;
      }

      [  SoapElement( ElementName = "ComandoEnviadoId" )]
      [  XmlElement( ElementName = "ComandoEnviadoId"   )]
      public int gxTpr_Comandoenviadoid
      {
         get {
            return gxTv_SdtComandoEnviado_Comandoenviadoid ;
         }

         set {
            if ( gxTv_SdtComandoEnviado_Comandoenviadoid != value )
            {
               gxTv_SdtComandoEnviado_Mode = "INS";
               this.gxTv_SdtComandoEnviado_Comandoenviadoid_Z_SetNull( );
               this.gxTv_SdtComandoEnviado_Comandoenviadoresponsavelguid_Z_SetNull( );
               this.gxTv_SdtComandoEnviado_Comandoenviadodatahora_Z_SetNull( );
               this.gxTv_SdtComandoEnviado_Rastreadorid_Z_SetNull( );
               this.gxTv_SdtComandoEnviado_Rastreadorsnumber_Z_SetNull( );
               this.gxTv_SdtComandoEnviado_Comandoenviadoserial_Z_SetNull( );
               if ( gxTv_SdtComandoEnviado_Comando != null )
               {
                  GXBCLevelCollection<SdtComandoEnviado_Comando> collectionComando = gxTv_SdtComandoEnviado_Comando;
                  SdtComandoEnviado_Comando currItemComando;
                  short idx = 1;
                  while ( idx <= collectionComando.Count )
                  {
                     currItemComando = ((SdtComandoEnviado_Comando)collectionComando.Item(idx));
                     currItemComando.gxTpr_Mode = "INS";
                     currItemComando.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtComandoEnviado_Comandoenviadoid = value;
            SetDirty("Comandoenviadoid");
         }

      }

      [  SoapElement( ElementName = "ComandoEnviadoResponsavelGUID" )]
      [  XmlElement( ElementName = "ComandoEnviadoResponsavelGUID"   )]
      public string gxTpr_Comandoenviadoresponsavelguid
      {
         get {
            return gxTv_SdtComandoEnviado_Comandoenviadoresponsavelguid ;
         }

         set {
            gxTv_SdtComandoEnviado_Comandoenviadoresponsavelguid = value;
            SetDirty("Comandoenviadoresponsavelguid");
         }

      }

      [  SoapElement( ElementName = "ComandoEnviadoDataHora" )]
      [  XmlElement( ElementName = "ComandoEnviadoDataHora"  , IsNullable=true )]
      public string gxTpr_Comandoenviadodatahora_Nullable
      {
         get {
            if ( gxTv_SdtComandoEnviado_Comandoenviadodatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtComandoEnviado_Comandoenviadodatahora).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtComandoEnviado_Comandoenviadodatahora = DateTime.MinValue;
            else
               gxTv_SdtComandoEnviado_Comandoenviadodatahora = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Comandoenviadodatahora
      {
         get {
            return gxTv_SdtComandoEnviado_Comandoenviadodatahora ;
         }

         set {
            gxTv_SdtComandoEnviado_Comandoenviadodatahora = value;
            SetDirty("Comandoenviadodatahora");
         }

      }

      [  SoapElement( ElementName = "RastreadorId" )]
      [  XmlElement( ElementName = "RastreadorId"   )]
      public int gxTpr_Rastreadorid
      {
         get {
            return gxTv_SdtComandoEnviado_Rastreadorid ;
         }

         set {
            gxTv_SdtComandoEnviado_Rastreadorid = value;
            SetDirty("Rastreadorid");
         }

      }

      [  SoapElement( ElementName = "RastreadorSNumber" )]
      [  XmlElement( ElementName = "RastreadorSNumber"   )]
      public long gxTpr_Rastreadorsnumber
      {
         get {
            return gxTv_SdtComandoEnviado_Rastreadorsnumber ;
         }

         set {
            gxTv_SdtComandoEnviado_Rastreadorsnumber = value;
            SetDirty("Rastreadorsnumber");
         }

      }

      [  SoapElement( ElementName = "ComandoEnviadoSerial" )]
      [  XmlElement( ElementName = "ComandoEnviadoSerial"   )]
      public int gxTpr_Comandoenviadoserial
      {
         get {
            return gxTv_SdtComandoEnviado_Comandoenviadoserial ;
         }

         set {
            gxTv_SdtComandoEnviado_Comandoenviadoserial = value;
            SetDirty("Comandoenviadoserial");
         }

      }

      [  SoapElement( ElementName = "Comando" )]
      [  XmlArray( ElementName = "Comando"  )]
      [  XmlArrayItemAttribute( ElementName= "ComandoEnviado.Comando"  , IsNullable=false)]
      public GXBCLevelCollection<SdtComandoEnviado_Comando> gxTpr_Comando_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtComandoEnviado_Comando == null )
            {
               gxTv_SdtComandoEnviado_Comando = new GXBCLevelCollection<SdtComandoEnviado_Comando>( context, "ComandoEnviado.Comando", "RastreamentoTCC");
            }
            return gxTv_SdtComandoEnviado_Comando ;
         }

         set {
            if ( gxTv_SdtComandoEnviado_Comando == null )
            {
               gxTv_SdtComandoEnviado_Comando = new GXBCLevelCollection<SdtComandoEnviado_Comando>( context, "ComandoEnviado.Comando", "RastreamentoTCC");
            }
            gxTv_SdtComandoEnviado_Comando = value;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public GXBCLevelCollection<SdtComandoEnviado_Comando> gxTpr_Comando
      {
         get {
            if ( gxTv_SdtComandoEnviado_Comando == null )
            {
               gxTv_SdtComandoEnviado_Comando = new GXBCLevelCollection<SdtComandoEnviado_Comando>( context, "ComandoEnviado.Comando", "RastreamentoTCC");
            }
            return gxTv_SdtComandoEnviado_Comando ;
         }

         set {
            gxTv_SdtComandoEnviado_Comando = value;
            SetDirty("Comando");
         }

      }

      public void gxTv_SdtComandoEnviado_Comando_SetNull( )
      {
         gxTv_SdtComandoEnviado_Comando = null;
         return  ;
      }

      public bool gxTv_SdtComandoEnviado_Comando_IsNull( )
      {
         if ( gxTv_SdtComandoEnviado_Comando == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtComandoEnviado_Mode ;
         }

         set {
            gxTv_SdtComandoEnviado_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtComandoEnviado_Mode_SetNull( )
      {
         gxTv_SdtComandoEnviado_Mode = "";
         return  ;
      }

      public bool gxTv_SdtComandoEnviado_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtComandoEnviado_Initialized ;
         }

         set {
            gxTv_SdtComandoEnviado_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtComandoEnviado_Initialized_SetNull( )
      {
         gxTv_SdtComandoEnviado_Initialized = 0;
         return  ;
      }

      public bool gxTv_SdtComandoEnviado_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ComandoEnviadoId_Z" )]
      [  XmlElement( ElementName = "ComandoEnviadoId_Z"   )]
      public int gxTpr_Comandoenviadoid_Z
      {
         get {
            return gxTv_SdtComandoEnviado_Comandoenviadoid_Z ;
         }

         set {
            gxTv_SdtComandoEnviado_Comandoenviadoid_Z = value;
            SetDirty("Comandoenviadoid_Z");
         }

      }

      public void gxTv_SdtComandoEnviado_Comandoenviadoid_Z_SetNull( )
      {
         gxTv_SdtComandoEnviado_Comandoenviadoid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtComandoEnviado_Comandoenviadoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ComandoEnviadoResponsavelGUID_Z" )]
      [  XmlElement( ElementName = "ComandoEnviadoResponsavelGUID_Z"   )]
      public string gxTpr_Comandoenviadoresponsavelguid_Z
      {
         get {
            return gxTv_SdtComandoEnviado_Comandoenviadoresponsavelguid_Z ;
         }

         set {
            gxTv_SdtComandoEnviado_Comandoenviadoresponsavelguid_Z = value;
            SetDirty("Comandoenviadoresponsavelguid_Z");
         }

      }

      public void gxTv_SdtComandoEnviado_Comandoenviadoresponsavelguid_Z_SetNull( )
      {
         gxTv_SdtComandoEnviado_Comandoenviadoresponsavelguid_Z = "";
         return  ;
      }

      public bool gxTv_SdtComandoEnviado_Comandoenviadoresponsavelguid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ComandoEnviadoDataHora_Z" )]
      [  XmlElement( ElementName = "ComandoEnviadoDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Comandoenviadodatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtComandoEnviado_Comandoenviadodatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtComandoEnviado_Comandoenviadodatahora_Z).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtComandoEnviado_Comandoenviadodatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtComandoEnviado_Comandoenviadodatahora_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Comandoenviadodatahora_Z
      {
         get {
            return gxTv_SdtComandoEnviado_Comandoenviadodatahora_Z ;
         }

         set {
            gxTv_SdtComandoEnviado_Comandoenviadodatahora_Z = value;
            SetDirty("Comandoenviadodatahora_Z");
         }

      }

      public void gxTv_SdtComandoEnviado_Comandoenviadodatahora_Z_SetNull( )
      {
         gxTv_SdtComandoEnviado_Comandoenviadodatahora_Z = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtComandoEnviado_Comandoenviadodatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RastreadorId_Z" )]
      [  XmlElement( ElementName = "RastreadorId_Z"   )]
      public int gxTpr_Rastreadorid_Z
      {
         get {
            return gxTv_SdtComandoEnviado_Rastreadorid_Z ;
         }

         set {
            gxTv_SdtComandoEnviado_Rastreadorid_Z = value;
            SetDirty("Rastreadorid_Z");
         }

      }

      public void gxTv_SdtComandoEnviado_Rastreadorid_Z_SetNull( )
      {
         gxTv_SdtComandoEnviado_Rastreadorid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtComandoEnviado_Rastreadorid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RastreadorSNumber_Z" )]
      [  XmlElement( ElementName = "RastreadorSNumber_Z"   )]
      public long gxTpr_Rastreadorsnumber_Z
      {
         get {
            return gxTv_SdtComandoEnviado_Rastreadorsnumber_Z ;
         }

         set {
            gxTv_SdtComandoEnviado_Rastreadorsnumber_Z = value;
            SetDirty("Rastreadorsnumber_Z");
         }

      }

      public void gxTv_SdtComandoEnviado_Rastreadorsnumber_Z_SetNull( )
      {
         gxTv_SdtComandoEnviado_Rastreadorsnumber_Z = 0;
         return  ;
      }

      public bool gxTv_SdtComandoEnviado_Rastreadorsnumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ComandoEnviadoSerial_Z" )]
      [  XmlElement( ElementName = "ComandoEnviadoSerial_Z"   )]
      public int gxTpr_Comandoenviadoserial_Z
      {
         get {
            return gxTv_SdtComandoEnviado_Comandoenviadoserial_Z ;
         }

         set {
            gxTv_SdtComandoEnviado_Comandoenviadoserial_Z = value;
            SetDirty("Comandoenviadoserial_Z");
         }

      }

      public void gxTv_SdtComandoEnviado_Comandoenviadoserial_Z_SetNull( )
      {
         gxTv_SdtComandoEnviado_Comandoenviadoserial_Z = 0;
         return  ;
      }

      public bool gxTv_SdtComandoEnviado_Comandoenviadoserial_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtComandoEnviado_Comandoenviadoresponsavelguid = "";
         gxTv_SdtComandoEnviado_Comandoenviadodatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtComandoEnviado_Mode = "";
         gxTv_SdtComandoEnviado_Comandoenviadoresponsavelguid_Z = "";
         gxTv_SdtComandoEnviado_Comandoenviadodatahora_Z = (DateTime)(DateTime.MinValue);
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "comandoenviado", "GeneXus.Programs.comandoenviado_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      private short gxTv_SdtComandoEnviado_Initialized ;
      private int gxTv_SdtComandoEnviado_Comandoenviadoid ;
      private int gxTv_SdtComandoEnviado_Rastreadorid ;
      private int gxTv_SdtComandoEnviado_Comandoenviadoserial ;
      private int gxTv_SdtComandoEnviado_Comandoenviadoid_Z ;
      private int gxTv_SdtComandoEnviado_Rastreadorid_Z ;
      private int gxTv_SdtComandoEnviado_Comandoenviadoserial_Z ;
      private long gxTv_SdtComandoEnviado_Rastreadorsnumber ;
      private long gxTv_SdtComandoEnviado_Rastreadorsnumber_Z ;
      private string gxTv_SdtComandoEnviado_Comandoenviadoresponsavelguid ;
      private string gxTv_SdtComandoEnviado_Mode ;
      private string gxTv_SdtComandoEnviado_Comandoenviadoresponsavelguid_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtComandoEnviado_Comandoenviadodatahora ;
      private DateTime gxTv_SdtComandoEnviado_Comandoenviadodatahora_Z ;
      private DateTime datetime_STZ ;
      private GXBCLevelCollection<SdtComandoEnviado_Comando> gxTv_SdtComandoEnviado_Comando=null ;
   }

   [DataContract(Name = @"ComandoEnviado", Namespace = "RastreamentoTCC")]
   public class SdtComandoEnviado_RESTInterface : GxGenericCollectionItem<SdtComandoEnviado>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtComandoEnviado_RESTInterface( ) : base()
      {
      }

      public SdtComandoEnviado_RESTInterface( SdtComandoEnviado psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ComandoEnviadoId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Comandoenviadoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Comandoenviadoid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Comandoenviadoid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "ComandoEnviadoResponsavelGUID" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Comandoenviadoresponsavelguid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Comandoenviadoresponsavelguid) ;
         }

         set {
            sdt.gxTpr_Comandoenviadoresponsavelguid = value;
         }

      }

      [DataMember( Name = "ComandoEnviadoDataHora" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Comandoenviadodatahora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Comandoenviadodatahora) ;
         }

         set {
            sdt.gxTpr_Comandoenviadodatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "RastreadorId" , Order = 3 )]
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

      [DataMember( Name = "RastreadorSNumber" , Order = 4 )]
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

      [DataMember( Name = "ComandoEnviadoSerial" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Comandoenviadoserial
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Comandoenviadoserial), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Comandoenviadoserial = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "Comando" , Order = 6 )]
      public GxGenericCollection<SdtComandoEnviado_Comando_RESTInterface> gxTpr_Comando
      {
         get {
            return new GxGenericCollection<SdtComandoEnviado_Comando_RESTInterface>(sdt.gxTpr_Comando) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Comando);
         }

      }

      public SdtComandoEnviado sdt
      {
         get {
            return (SdtComandoEnviado)Sdt ;
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
            sdt = new SdtComandoEnviado() ;
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

   [DataContract(Name = @"ComandoEnviado", Namespace = "RastreamentoTCC")]
   public class SdtComandoEnviado_RESTLInterface : GxGenericCollectionItem<SdtComandoEnviado>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtComandoEnviado_RESTLInterface( ) : base()
      {
      }

      public SdtComandoEnviado_RESTLInterface( SdtComandoEnviado psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ComandoEnviadoResponsavelGUID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Comandoenviadoresponsavelguid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Comandoenviadoresponsavelguid) ;
         }

         set {
            sdt.gxTpr_Comandoenviadoresponsavelguid = value;
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

      public SdtComandoEnviado sdt
      {
         get {
            return (SdtComandoEnviado)Sdt ;
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
            sdt = new SdtComandoEnviado() ;
         }
      }

   }

}
