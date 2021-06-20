/*
				   File: type_SdtGxMap_Circle
			Description: Circles
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
	[XmlRoot(ElementName="GxMap.Circle")]
	[XmlType(TypeName="GxMap.Circle" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtGxMap_Circle : GxUserType
	{
		public SdtGxMap_Circle( )
		{
			/* Constructor for serialization */
			gxTv_SdtGxMap_Circle_Latitude = "";

			gxTv_SdtGxMap_Circle_Longitude = "";

			gxTv_SdtGxMap_Circle_Circlefill = "";

			gxTv_SdtGxMap_Circle_Circlestroke = "";

		}

		public SdtGxMap_Circle(IGxContext context)
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
			AddObjectProperty("Latitude", gxTpr_Latitude, false);


			AddObjectProperty("Longitude", gxTpr_Longitude, false);


			AddObjectProperty("Radius", gxTpr_Radius, false);


			AddObjectProperty("CircleFill", gxTpr_Circlefill, false);


			AddObjectProperty("CircleFillOpacity", gxTpr_Circlefillopacity, false);


			AddObjectProperty("CircleStroke", gxTpr_Circlestroke, false);


			AddObjectProperty("CircleStrokeOpacity", gxTpr_Circlestrokeopacity, false);


			AddObjectProperty("CirclestrokeWeight", gxTpr_Circlestrokeweight, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Latitude")]
		[XmlElement(ElementName="Latitude")]
		public string gxTpr_Latitude
		{
			get { 
				return gxTv_SdtGxMap_Circle_Latitude; 
			}
			set { 
				gxTv_SdtGxMap_Circle_Latitude = value;
				SetDirty("Latitude");
			}
		}




		[SoapElement(ElementName="Longitude")]
		[XmlElement(ElementName="Longitude")]
		public string gxTpr_Longitude
		{
			get { 
				return gxTv_SdtGxMap_Circle_Longitude; 
			}
			set { 
				gxTv_SdtGxMap_Circle_Longitude = value;
				SetDirty("Longitude");
			}
		}




		[SoapElement(ElementName="Radius")]
		[XmlElement(ElementName="Radius")]
		public long gxTpr_Radius
		{
			get { 
				return gxTv_SdtGxMap_Circle_Radius; 
			}
			set { 
				gxTv_SdtGxMap_Circle_Radius = value;
				SetDirty("Radius");
			}
		}




		[SoapElement(ElementName="CircleFill")]
		[XmlElement(ElementName="CircleFill")]
		public string gxTpr_Circlefill
		{
			get { 
				return gxTv_SdtGxMap_Circle_Circlefill; 
			}
			set { 
				gxTv_SdtGxMap_Circle_Circlefill = value;
				SetDirty("Circlefill");
			}
		}



		[SoapElement(ElementName="CircleFillOpacity")]
		[XmlElement(ElementName="CircleFillOpacity")]
		public string gxTpr_Circlefillopacity_double
		{
			get {
				return Convert.ToString(gxTv_SdtGxMap_Circle_Circlefillopacity, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtGxMap_Circle_Circlefillopacity = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Circlefillopacity
		{
			get { 
				return gxTv_SdtGxMap_Circle_Circlefillopacity; 
			}
			set { 
				gxTv_SdtGxMap_Circle_Circlefillopacity = value;
				SetDirty("Circlefillopacity");
			}
		}




		[SoapElement(ElementName="CircleStroke")]
		[XmlElement(ElementName="CircleStroke")]
		public string gxTpr_Circlestroke
		{
			get { 
				return gxTv_SdtGxMap_Circle_Circlestroke; 
			}
			set { 
				gxTv_SdtGxMap_Circle_Circlestroke = value;
				SetDirty("Circlestroke");
			}
		}



		[SoapElement(ElementName="CircleStrokeOpacity")]
		[XmlElement(ElementName="CircleStrokeOpacity")]
		public string gxTpr_Circlestrokeopacity_double
		{
			get {
				return Convert.ToString(gxTv_SdtGxMap_Circle_Circlestrokeopacity, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtGxMap_Circle_Circlestrokeopacity = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Circlestrokeopacity
		{
			get { 
				return gxTv_SdtGxMap_Circle_Circlestrokeopacity; 
			}
			set { 
				gxTv_SdtGxMap_Circle_Circlestrokeopacity = value;
				SetDirty("Circlestrokeopacity");
			}
		}




		[SoapElement(ElementName="CirclestrokeWeight")]
		[XmlElement(ElementName="CirclestrokeWeight")]
		public short gxTpr_Circlestrokeweight
		{
			get { 
				return gxTv_SdtGxMap_Circle_Circlestrokeweight; 
			}
			set { 
				gxTv_SdtGxMap_Circle_Circlestrokeweight = value;
				SetDirty("Circlestrokeweight");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtGxMap_Circle_Latitude = "";
			gxTv_SdtGxMap_Circle_Longitude = "";

			gxTv_SdtGxMap_Circle_Circlefill = "";

			gxTv_SdtGxMap_Circle_Circlestroke = "";


			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtGxMap_Circle_Latitude;
		 

		protected string gxTv_SdtGxMap_Circle_Longitude;
		 

		protected long gxTv_SdtGxMap_Circle_Radius;
		 

		protected string gxTv_SdtGxMap_Circle_Circlefill;
		 

		protected decimal gxTv_SdtGxMap_Circle_Circlefillopacity;
		 

		protected string gxTv_SdtGxMap_Circle_Circlestroke;
		 

		protected decimal gxTv_SdtGxMap_Circle_Circlestrokeopacity;
		 

		protected short gxTv_SdtGxMap_Circle_Circlestrokeweight;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"GxMap.Circle", Namespace="RastreamentoTCC")]
	public class SdtGxMap_Circle_RESTInterface : GxGenericCollectionItem<SdtGxMap_Circle>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtGxMap_Circle_RESTInterface( ) : base()
		{
		}

		public SdtGxMap_Circle_RESTInterface( SdtGxMap_Circle psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="Latitude", Order=0)]
		public  string gxTpr_Latitude
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Latitude);

			}
			set { 
				 sdt.gxTpr_Latitude = value;
			}
		}

		[DataMember(Name="Longitude", Order=1)]
		public  string gxTpr_Longitude
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Longitude);

			}
			set { 
				 sdt.gxTpr_Longitude = value;
			}
		}

		[DataMember(Name="Radius", Order=2)]
		public  string gxTpr_Radius
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Radius, 10, 0));

			}
			set { 
				sdt.gxTpr_Radius = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="CircleFill", Order=3)]
		public  string gxTpr_Circlefill
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Circlefill);

			}
			set { 
				 sdt.gxTpr_Circlefill = value;
			}
		}

		[DataMember(Name="CircleFillOpacity", Order=4)]
		public decimal gxTpr_Circlefillopacity
		{
			get { 
				return sdt.gxTpr_Circlefillopacity;

			}
			set { 
				sdt.gxTpr_Circlefillopacity = value;
			}
		}

		[DataMember(Name="CircleStroke", Order=5)]
		public  string gxTpr_Circlestroke
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Circlestroke);

			}
			set { 
				 sdt.gxTpr_Circlestroke = value;
			}
		}

		[DataMember(Name="CircleStrokeOpacity", Order=6)]
		public decimal gxTpr_Circlestrokeopacity
		{
			get { 
				return sdt.gxTpr_Circlestrokeopacity;

			}
			set { 
				sdt.gxTpr_Circlestrokeopacity = value;
			}
		}

		[DataMember(Name="CirclestrokeWeight", Order=7)]
		public short gxTpr_Circlestrokeweight
		{
			get { 
				return sdt.gxTpr_Circlestrokeweight;

			}
			set { 
				sdt.gxTpr_Circlestrokeweight = value;
			}
		}


		#endregion

		public SdtGxMap_Circle sdt
		{
			get { 
				return (SdtGxMap_Circle)Sdt;
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
				sdt = new SdtGxMap_Circle() ;
			}
		}
	}
	#endregion
}