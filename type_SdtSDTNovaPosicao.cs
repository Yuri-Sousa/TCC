/*
				   File: type_SdtSDTNovaPosicao
			Description: SDTNovaPosicao
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
	[XmlRoot(ElementName="SDTNovaPosicao")]
	[XmlType(TypeName="SDTNovaPosicao" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtSDTNovaPosicao : GxUserType
	{
		public SdtSDTNovaPosicao( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTNovaPosicao_Ignicao = "";

			gxTv_SdtSDTNovaPosicao_Placa = "";

			gxTv_SdtSDTNovaPosicao_Latlong = "";

			gxTv_SdtSDTNovaPosicao_Latitude = "";

			gxTv_SdtSDTNovaPosicao_Longitude = "";

			gxTv_SdtSDTNovaPosicao_Horagps = (DateTime)(DateTime.MinValue);

		}

		public SdtSDTNovaPosicao(IGxContext context)
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
			AddObjectProperty("Ignicao", gxTpr_Ignicao, false);


			AddObjectProperty("Placa", gxTpr_Placa, false);


			AddObjectProperty("LatLong", gxTpr_Latlong, false);


			AddObjectProperty("Latitude", gxTpr_Latitude, false);


			AddObjectProperty("Longitude", gxTpr_Longitude, false);


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

		[SoapElement(ElementName="Ignicao")]
		[XmlElement(ElementName="Ignicao")]
		public string gxTpr_Ignicao
		{
			get { 
				return gxTv_SdtSDTNovaPosicao_Ignicao; 
			}
			set { 
				gxTv_SdtSDTNovaPosicao_Ignicao = value;
				SetDirty("Ignicao");
			}
		}




		[SoapElement(ElementName="Placa")]
		[XmlElement(ElementName="Placa")]
		public string gxTpr_Placa
		{
			get { 
				return gxTv_SdtSDTNovaPosicao_Placa; 
			}
			set { 
				gxTv_SdtSDTNovaPosicao_Placa = value;
				SetDirty("Placa");
			}
		}




		[SoapElement(ElementName="LatLong")]
		[XmlElement(ElementName="LatLong")]
		public string gxTpr_Latlong
		{
			get { 
				return gxTv_SdtSDTNovaPosicao_Latlong; 
			}
			set { 
				gxTv_SdtSDTNovaPosicao_Latlong = value;
				SetDirty("Latlong");
			}
		}




		[SoapElement(ElementName="Latitude")]
		[XmlElement(ElementName="Latitude")]
		public string gxTpr_Latitude
		{
			get { 
				return gxTv_SdtSDTNovaPosicao_Latitude; 
			}
			set { 
				gxTv_SdtSDTNovaPosicao_Latitude = value;
				SetDirty("Latitude");
			}
		}




		[SoapElement(ElementName="Longitude")]
		[XmlElement(ElementName="Longitude")]
		public string gxTpr_Longitude
		{
			get { 
				return gxTv_SdtSDTNovaPosicao_Longitude; 
			}
			set { 
				gxTv_SdtSDTNovaPosicao_Longitude = value;
				SetDirty("Longitude");
			}
		}




		[SoapElement(ElementName="UltimoDadoLidoId")]
		[XmlElement(ElementName="UltimoDadoLidoId")]
		public int gxTpr_Ultimodadolidoid
		{
			get { 
				return gxTv_SdtSDTNovaPosicao_Ultimodadolidoid; 
			}
			set { 
				gxTv_SdtSDTNovaPosicao_Ultimodadolidoid = value;
				SetDirty("Ultimodadolidoid");
			}
		}



		[SoapElement(ElementName="HoraGPS")]
		[XmlElement(ElementName="HoraGPS" , IsNullable=true)]
		public string gxTpr_Horagps_Nullable
		{
			get {
				if ( gxTv_SdtSDTNovaPosicao_Horagps == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDTNovaPosicao_Horagps).value ;
			}
			set {
				gxTv_SdtSDTNovaPosicao_Horagps = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Horagps
		{
			get { 
				return gxTv_SdtSDTNovaPosicao_Horagps; 
			}
			set { 
				gxTv_SdtSDTNovaPosicao_Horagps = value;
				SetDirty("Horagps");
			}
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSDTNovaPosicao_Ignicao = "";
			gxTv_SdtSDTNovaPosicao_Placa = "";
			gxTv_SdtSDTNovaPosicao_Latlong = "";
			gxTv_SdtSDTNovaPosicao_Latitude = "";
			gxTv_SdtSDTNovaPosicao_Longitude = "";

			gxTv_SdtSDTNovaPosicao_Horagps = (DateTime)(DateTime.MinValue);
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

		protected string gxTv_SdtSDTNovaPosicao_Ignicao;
		 

		protected string gxTv_SdtSDTNovaPosicao_Placa;
		 

		protected string gxTv_SdtSDTNovaPosicao_Latlong;
		 

		protected string gxTv_SdtSDTNovaPosicao_Latitude;
		 

		protected string gxTv_SdtSDTNovaPosicao_Longitude;
		 

		protected int gxTv_SdtSDTNovaPosicao_Ultimodadolidoid;
		 

		protected DateTime gxTv_SdtSDTNovaPosicao_Horagps;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SDTNovaPosicao", Namespace="RastreamentoTCC")]
	public class SdtSDTNovaPosicao_RESTInterface : GxGenericCollectionItem<SdtSDTNovaPosicao>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTNovaPosicao_RESTInterface( ) : base()
		{
		}

		public SdtSDTNovaPosicao_RESTInterface( SdtSDTNovaPosicao psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="Ignicao", Order=0)]
		public  string gxTpr_Ignicao
		{
			get { 
				return sdt.gxTpr_Ignicao;

			}
			set { 
				 sdt.gxTpr_Ignicao = value;
			}
		}

		[DataMember(Name="Placa", Order=1)]
		public  string gxTpr_Placa
		{
			get { 
				return sdt.gxTpr_Placa;

			}
			set { 
				 sdt.gxTpr_Placa = value;
			}
		}

		[DataMember(Name="LatLong", Order=2)]
		public  string gxTpr_Latlong
		{
			get { 
				return sdt.gxTpr_Latlong;

			}
			set { 
				 sdt.gxTpr_Latlong = value;
			}
		}

		[DataMember(Name="Latitude", Order=3)]
		public  string gxTpr_Latitude
		{
			get { 
				return sdt.gxTpr_Latitude;

			}
			set { 
				 sdt.gxTpr_Latitude = value;
			}
		}

		[DataMember(Name="Longitude", Order=4)]
		public  string gxTpr_Longitude
		{
			get { 
				return sdt.gxTpr_Longitude;

			}
			set { 
				 sdt.gxTpr_Longitude = value;
			}
		}

		[DataMember(Name="UltimoDadoLidoId", Order=5)]
		public  string gxTpr_Ultimodadolidoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Ultimodadolidoid, 8, 0));

			}
			set { 
				sdt.gxTpr_Ultimodadolidoid = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="HoraGPS", Order=6)]
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

		public SdtSDTNovaPosicao sdt
		{
			get { 
				return (SdtSDTNovaPosicao)Sdt;
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
				sdt = new SdtSDTNovaPosicao() ;
			}
		}
	}
	#endregion
}