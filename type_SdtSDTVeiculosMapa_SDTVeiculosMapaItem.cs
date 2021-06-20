/*
				   File: type_SdtSDTVeiculosMapa_SDTVeiculosMapaItem
			Description: SDTVeiculosMapa
				 Author: Nemo 🐠 for C# version 17.0.2.148565
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web.Services.Protocols;


namespace GeneXus.Programs
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="SDTVeiculosMapaItem")]
	[XmlType(TypeName="SDTVeiculosMapaItem" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtSDTVeiculosMapa_SDTVeiculosMapaItem : GxUserType
	{
		public SdtSDTVeiculosMapa_SDTVeiculosMapaItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Ignicao = "";

			gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Placa = "";

			gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Marcamodelo = "";

			gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Latlong = "";

			gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Latitude = "";

			gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Longitude = "";

			gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Veiculotipo = "";

			gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Iconvisible = "";

			gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Horagps = (DateTime)(DateTime.MinValue);

		}

		public SdtSDTVeiculosMapa_SDTVeiculosMapaItem(IGxContext context)
		{
			this.context = context;
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("VeiculoId", gxTpr_Veiculoid, false);


			AddObjectProperty("Ignicao", gxTpr_Ignicao, false);


			AddObjectProperty("Placa", gxTpr_Placa, false);


			AddObjectProperty("MarcaModelo", gxTpr_Marcamodelo, false);


			AddObjectProperty("LatLong", gxTpr_Latlong, false);


			AddObjectProperty("Latitude", gxTpr_Latitude, false);


			AddObjectProperty("Longitude", gxTpr_Longitude, false);


			AddObjectProperty("VeiculoTipo", gxTpr_Veiculotipo, false);


			AddObjectProperty("IconVisible", gxTpr_Iconvisible, false);


			AddObjectProperty("IsVisible", gxTpr_Isvisible, false);


			AddObjectProperty("UltimoDadoLidoId", gxTpr_Ultimodadolidoid, false);


			datetime_STZ = gxTpr_Horagps;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("HoraGPS", sDateCnv, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="VeiculoId")]
		[XmlElement(ElementName="VeiculoId")]
		public int gxTpr_Veiculoid
		{
			get { 
				return gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Veiculoid; 
			}
			set { 
				gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Veiculoid = value;
				SetDirty("Veiculoid");
			}
		}




		[SoapElement(ElementName="Ignicao")]
		[XmlElement(ElementName="Ignicao")]
		public string gxTpr_Ignicao
		{
			get { 
				return gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Ignicao; 
			}
			set { 
				gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Ignicao = value;
				SetDirty("Ignicao");
			}
		}




		[SoapElement(ElementName="Placa")]
		[XmlElement(ElementName="Placa")]
		public string gxTpr_Placa
		{
			get { 
				return gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Placa; 
			}
			set { 
				gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Placa = value;
				SetDirty("Placa");
			}
		}




		[SoapElement(ElementName="MarcaModelo")]
		[XmlElement(ElementName="MarcaModelo")]
		public string gxTpr_Marcamodelo
		{
			get { 
				return gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Marcamodelo; 
			}
			set { 
				gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Marcamodelo = value;
				SetDirty("Marcamodelo");
			}
		}




		[SoapElement(ElementName="LatLong")]
		[XmlElement(ElementName="LatLong")]
		public string gxTpr_Latlong
		{
			get { 
				return gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Latlong; 
			}
			set { 
				gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Latlong = value;
				SetDirty("Latlong");
			}
		}




		[SoapElement(ElementName="Latitude")]
		[XmlElement(ElementName="Latitude")]
		public string gxTpr_Latitude
		{
			get { 
				return gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Latitude; 
			}
			set { 
				gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Latitude = value;
				SetDirty("Latitude");
			}
		}




		[SoapElement(ElementName="Longitude")]
		[XmlElement(ElementName="Longitude")]
		public string gxTpr_Longitude
		{
			get { 
				return gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Longitude; 
			}
			set { 
				gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Longitude = value;
				SetDirty("Longitude");
			}
		}




		[SoapElement(ElementName="VeiculoTipo")]
		[XmlElement(ElementName="VeiculoTipo")]
		public string gxTpr_Veiculotipo
		{
			get { 
				return gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Veiculotipo; 
			}
			set { 
				gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Veiculotipo = value;
				SetDirty("Veiculotipo");
			}
		}




		[SoapElement(ElementName="IconVisible")]
		[XmlElement(ElementName="IconVisible")]
		public string gxTpr_Iconvisible
		{
			get { 
				return gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Iconvisible; 
			}
			set { 
				gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Iconvisible = value;
				SetDirty("Iconvisible");
			}
		}




		[SoapElement(ElementName="IsVisible")]
		[XmlElement(ElementName="IsVisible")]
		public bool gxTpr_Isvisible
		{
			get { 
				return gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Isvisible; 
			}
			set { 
				gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Isvisible = value;
				SetDirty("Isvisible");
			}
		}




		[SoapElement(ElementName="UltimoDadoLidoId")]
		[XmlElement(ElementName="UltimoDadoLidoId")]
		public int gxTpr_Ultimodadolidoid
		{
			get { 
				return gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Ultimodadolidoid; 
			}
			set { 
				gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Ultimodadolidoid = value;
				SetDirty("Ultimodadolidoid");
			}
		}



		[SoapElement(ElementName="HoraGPS")]
		[XmlElement(ElementName="HoraGPS" , IsNullable=true)]
		public string gxTpr_Horagps_Nullable
		{
			get {
				if ( gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Horagps == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Horagps).value ;
			}
			set {
				gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Horagps = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Horagps
		{
			get { 
				return gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Horagps; 
			}
			set { 
				gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Horagps = value;
				SetDirty("Horagps");
			}
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Ignicao = "";
			gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Placa = "";
			gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Marcamodelo = "";
			gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Latlong = "";
			gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Latitude = "";
			gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Longitude = "";
			gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Veiculotipo = "";
			gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Iconvisible = "";


			gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Horagps = (DateTime)(DateTime.MinValue);
			datetime_STZ = (DateTime)(DateTime.MinValue);
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected DateTime datetime_STZ ;

		protected int gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Veiculoid;
		 

		protected string gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Ignicao;
		 

		protected string gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Placa;
		 

		protected string gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Marcamodelo;
		 

		protected string gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Latlong;
		 

		protected string gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Latitude;
		 

		protected string gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Longitude;
		 

		protected string gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Veiculotipo;
		 

		protected string gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Iconvisible;
		 

		protected bool gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Isvisible;
		 

		protected int gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Ultimodadolidoid;
		 

		protected DateTime gxTv_SdtSDTVeiculosMapa_SDTVeiculosMapaItem_Horagps;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SDTVeiculosMapaItem", Namespace="RastreamentoTCC")]
	public class SdtSDTVeiculosMapa_SDTVeiculosMapaItem_RESTInterface : GxGenericCollectionItem<SdtSDTVeiculosMapa_SDTVeiculosMapaItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTVeiculosMapa_SDTVeiculosMapaItem_RESTInterface( ) : base()
		{
		}

		public SdtSDTVeiculosMapa_SDTVeiculosMapaItem_RESTInterface( SdtSDTVeiculosMapa_SDTVeiculosMapaItem psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="VeiculoId", Order=0)]
		public  string gxTpr_Veiculoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Veiculoid, 8, 0));

			}
			set { 
				sdt.gxTpr_Veiculoid = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Ignicao", Order=1)]
		public  string gxTpr_Ignicao
		{
			get { 
				return sdt.gxTpr_Ignicao;

			}
			set { 
				 sdt.gxTpr_Ignicao = value;
			}
		}

		[DataMember(Name="Placa", Order=2)]
		public  string gxTpr_Placa
		{
			get { 
				return sdt.gxTpr_Placa;

			}
			set { 
				 sdt.gxTpr_Placa = value;
			}
		}

		[DataMember(Name="MarcaModelo", Order=3)]
		public  string gxTpr_Marcamodelo
		{
			get { 
				return sdt.gxTpr_Marcamodelo;

			}
			set { 
				 sdt.gxTpr_Marcamodelo = value;
			}
		}

		[DataMember(Name="LatLong", Order=4)]
		public  string gxTpr_Latlong
		{
			get { 
				return sdt.gxTpr_Latlong;

			}
			set { 
				 sdt.gxTpr_Latlong = value;
			}
		}

		[DataMember(Name="Latitude", Order=5)]
		public  string gxTpr_Latitude
		{
			get { 
				return sdt.gxTpr_Latitude;

			}
			set { 
				 sdt.gxTpr_Latitude = value;
			}
		}

		[DataMember(Name="Longitude", Order=6)]
		public  string gxTpr_Longitude
		{
			get { 
				return sdt.gxTpr_Longitude;

			}
			set { 
				 sdt.gxTpr_Longitude = value;
			}
		}

		[DataMember(Name="VeiculoTipo", Order=7)]
		public  string gxTpr_Veiculotipo
		{
			get { 
				return sdt.gxTpr_Veiculotipo;

			}
			set { 
				 sdt.gxTpr_Veiculotipo = value;
			}
		}

		[DataMember(Name="IconVisible", Order=8)]
		public  string gxTpr_Iconvisible
		{
			get { 
				return sdt.gxTpr_Iconvisible;

			}
			set { 
				 sdt.gxTpr_Iconvisible = value;
			}
		}

		[DataMember(Name="IsVisible", Order=9)]
		public bool gxTpr_Isvisible
		{
			get { 
				return sdt.gxTpr_Isvisible;

			}
			set { 
				sdt.gxTpr_Isvisible = value;
			}
		}

		[DataMember(Name="UltimoDadoLidoId", Order=10)]
		public  string gxTpr_Ultimodadolidoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Ultimodadolidoid, 8, 0));

			}
			set { 
				sdt.gxTpr_Ultimodadolidoid = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="HoraGPS", Order=11)]
		public  string gxTpr_Horagps
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Horagps);

			}
			set { 
				sdt.gxTpr_Horagps = DateTimeUtil.CToT2(value);
			}
		}


		#endregion

		public SdtSDTVeiculosMapa_SDTVeiculosMapaItem sdt
		{
			get { 
				return (SdtSDTVeiculosMapa_SDTVeiculosMapaItem)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtSDTVeiculosMapa_SDTVeiculosMapaItem() ;
			}
		}
	}
	#endregion
}