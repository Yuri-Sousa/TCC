/*
				   File: type_SdtPolyline_PolylineItem_Pontos
			Description: Pontos
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
	[XmlRoot(ElementName="Polyline.PolylineItem.Pontos")]
	[XmlType(TypeName="Polyline.PolylineItem.Pontos" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtPolyline_PolylineItem_Pontos : GxUserType
	{
		public SdtPolyline_PolylineItem_Pontos( )
		{
			/* Constructor for serialization */
			gxTv_SdtPolyline_PolylineItem_Pontos_Ignicao = "";

			gxTv_SdtPolyline_PolylineItem_Pontos_Velocidade = "";

			gxTv_SdtPolyline_PolylineItem_Pontos_Datahoraposicao = "";

		}

		public SdtPolyline_PolylineItem_Pontos(IGxContext context)
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
			AddObjectProperty("PontoId", gxTpr_Pontoid, false);


			AddObjectProperty("lat", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Lat, 16, 6)), false);


			AddObjectProperty("lng", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Lng, 16, 6)), false);


			AddObjectProperty("Ignicao", gxTpr_Ignicao, false);


			AddObjectProperty("Velocidade", gxTpr_Velocidade, false);


			AddObjectProperty("DataHoraPosicao", gxTpr_Datahoraposicao, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PontoId")]
		[XmlElement(ElementName="PontoId")]
		public long gxTpr_Pontoid
		{
			get { 
				return gxTv_SdtPolyline_PolylineItem_Pontos_Pontoid; 
			}
			set { 
				gxTv_SdtPolyline_PolylineItem_Pontos_Pontoid = value;
				SetDirty("Pontoid");
			}
		}



		[SoapElement(ElementName="lat")]
		[XmlElement(ElementName="lat")]
		public string gxTpr_Lat_double
		{
			get {
				return Convert.ToString(gxTv_SdtPolyline_PolylineItem_Pontos_Lat, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtPolyline_PolylineItem_Pontos_Lat = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Lat
		{
			get { 
				return gxTv_SdtPolyline_PolylineItem_Pontos_Lat; 
			}
			set { 
				gxTv_SdtPolyline_PolylineItem_Pontos_Lat = value;
				SetDirty("Lat");
			}
		}



		[SoapElement(ElementName="lng")]
		[XmlElement(ElementName="lng")]
		public string gxTpr_Lng_double
		{
			get {
				return Convert.ToString(gxTv_SdtPolyline_PolylineItem_Pontos_Lng, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtPolyline_PolylineItem_Pontos_Lng = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Lng
		{
			get { 
				return gxTv_SdtPolyline_PolylineItem_Pontos_Lng; 
			}
			set { 
				gxTv_SdtPolyline_PolylineItem_Pontos_Lng = value;
				SetDirty("Lng");
			}
		}




		[SoapElement(ElementName="Ignicao")]
		[XmlElement(ElementName="Ignicao")]
		public string gxTpr_Ignicao
		{
			get { 
				return gxTv_SdtPolyline_PolylineItem_Pontos_Ignicao; 
			}
			set { 
				gxTv_SdtPolyline_PolylineItem_Pontos_Ignicao = value;
				SetDirty("Ignicao");
			}
		}




		[SoapElement(ElementName="Velocidade")]
		[XmlElement(ElementName="Velocidade")]
		public string gxTpr_Velocidade
		{
			get { 
				return gxTv_SdtPolyline_PolylineItem_Pontos_Velocidade; 
			}
			set { 
				gxTv_SdtPolyline_PolylineItem_Pontos_Velocidade = value;
				SetDirty("Velocidade");
			}
		}




		[SoapElement(ElementName="DataHoraPosicao")]
		[XmlElement(ElementName="DataHoraPosicao")]
		public string gxTpr_Datahoraposicao
		{
			get { 
				return gxTv_SdtPolyline_PolylineItem_Pontos_Datahoraposicao; 
			}
			set { 
				gxTv_SdtPolyline_PolylineItem_Pontos_Datahoraposicao = value;
				SetDirty("Datahoraposicao");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtPolyline_PolylineItem_Pontos_Ignicao = "";
			gxTv_SdtPolyline_PolylineItem_Pontos_Velocidade = "";
			gxTv_SdtPolyline_PolylineItem_Pontos_Datahoraposicao = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtPolyline_PolylineItem_Pontos_Pontoid;
		 

		protected decimal gxTv_SdtPolyline_PolylineItem_Pontos_Lat;
		 

		protected decimal gxTv_SdtPolyline_PolylineItem_Pontos_Lng;
		 

		protected string gxTv_SdtPolyline_PolylineItem_Pontos_Ignicao;
		 

		protected string gxTv_SdtPolyline_PolylineItem_Pontos_Velocidade;
		 

		protected string gxTv_SdtPolyline_PolylineItem_Pontos_Datahoraposicao;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"Polyline.PolylineItem.Pontos", Namespace="RastreamentoTCC")]
	public class SdtPolyline_PolylineItem_Pontos_RESTInterface : GxGenericCollectionItem<SdtPolyline_PolylineItem_Pontos>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtPolyline_PolylineItem_Pontos_RESTInterface( ) : base()
		{
		}

		public SdtPolyline_PolylineItem_Pontos_RESTInterface( SdtPolyline_PolylineItem_Pontos psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="PontoId", Order=0)]
		public  string gxTpr_Pontoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Pontoid, 10, 0));

			}
			set { 
				sdt.gxTpr_Pontoid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="lat", Order=1)]
		public  string gxTpr_Lat
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Lat, 16, 6));

			}
			set { 
				sdt.gxTpr_Lat =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="lng", Order=2)]
		public  string gxTpr_Lng
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Lng, 16, 6));

			}
			set { 
				sdt.gxTpr_Lng =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Ignicao", Order=3)]
		public  string gxTpr_Ignicao
		{
			get { 
				return sdt.gxTpr_Ignicao;

			}
			set { 
				 sdt.gxTpr_Ignicao = value;
			}
		}

		[DataMember(Name="Velocidade", Order=4)]
		public  string gxTpr_Velocidade
		{
			get { 
				return sdt.gxTpr_Velocidade;

			}
			set { 
				 sdt.gxTpr_Velocidade = value;
			}
		}

		[DataMember(Name="DataHoraPosicao", Order=5)]
		public  string gxTpr_Datahoraposicao
		{
			get { 
				return sdt.gxTpr_Datahoraposicao;

			}
			set { 
				 sdt.gxTpr_Datahoraposicao = value;
			}
		}


		#endregion

		public SdtPolyline_PolylineItem_Pontos sdt
		{
			get { 
				return (SdtPolyline_PolylineItem_Pontos)Sdt;
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
				sdt = new SdtPolyline_PolylineItem_Pontos() ;
			}
		}
	}
	#endregion
}