/*
				   File: type_SdtPolyline_PolylineItem
			Description: Polyline
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
	[XmlRoot(ElementName="PolylineItem")]
	[XmlType(TypeName="PolylineItem" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtPolyline_PolylineItem : GxUserType
	{
		public SdtPolyline_PolylineItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtPolyline_PolylineItem_Strokecolor = "";

			gxTv_SdtPolyline_PolylineItem_Placa = "";

			gxTv_SdtPolyline_PolylineItem_Urliconeinicio = "";

			gxTv_SdtPolyline_PolylineItem_Urliconefim = "";

			gxTv_SdtPolyline_PolylineItem_Urliconedurantetrajeto = "";

			gxTv_SdtPolyline_PolylineItem_Urliconanimation = "";

		}

		public SdtPolyline_PolylineItem(IGxContext context)
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
			AddObjectProperty("PolylineId", gxTpr_Polylineid, false);


			AddObjectProperty("stroke", gxTpr_Stroke, false);


			AddObjectProperty("strokeColor", gxTpr_Strokecolor, false);


			AddObjectProperty("strokeOpacity", gxTpr_Strokeopacity, false);


			AddObjectProperty("strokeWeight", gxTpr_Strokeweight, false);


			AddObjectProperty("Placa", gxTpr_Placa, false);


			AddObjectProperty("URLIconeInicio", gxTpr_Urliconeinicio, false);


			AddObjectProperty("URLIconeFim", gxTpr_Urliconefim, false);


			AddObjectProperty("URLIconeDuranteTrajeto", gxTpr_Urliconedurantetrajeto, false);


			AddObjectProperty("MilisegundosAnimacao", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Milisegundosanimacao, 16, 0)), false);


			AddObjectProperty("URLIconAnimation", gxTpr_Urliconanimation, false);

			if (gxTv_SdtPolyline_PolylineItem_Pontos != null)
			{
				AddObjectProperty("Pontos", gxTv_SdtPolyline_PolylineItem_Pontos, false);  
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PolylineId")]
		[XmlElement(ElementName="PolylineId")]
		public long gxTpr_Polylineid
		{
			get { 
				return gxTv_SdtPolyline_PolylineItem_Polylineid; 
			}
			set { 
				gxTv_SdtPolyline_PolylineItem_Polylineid = value;
				SetDirty("Polylineid");
			}
		}




		[SoapElement(ElementName="stroke")]
		[XmlElement(ElementName="stroke")]
		public bool gxTpr_Stroke
		{
			get { 
				return gxTv_SdtPolyline_PolylineItem_Stroke; 
			}
			set { 
				gxTv_SdtPolyline_PolylineItem_Stroke = value;
				SetDirty("Stroke");
			}
		}




		[SoapElement(ElementName="strokeColor")]
		[XmlElement(ElementName="strokeColor")]
		public string gxTpr_Strokecolor
		{
			get { 
				return gxTv_SdtPolyline_PolylineItem_Strokecolor; 
			}
			set { 
				gxTv_SdtPolyline_PolylineItem_Strokecolor = value;
				SetDirty("Strokecolor");
			}
		}



		[SoapElement(ElementName="strokeOpacity")]
		[XmlElement(ElementName="strokeOpacity")]
		public string gxTpr_Strokeopacity_double
		{
			get {
				return Convert.ToString(gxTv_SdtPolyline_PolylineItem_Strokeopacity, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtPolyline_PolylineItem_Strokeopacity = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Strokeopacity
		{
			get { 
				return gxTv_SdtPolyline_PolylineItem_Strokeopacity; 
			}
			set { 
				gxTv_SdtPolyline_PolylineItem_Strokeopacity = value;
				SetDirty("Strokeopacity");
			}
		}




		[SoapElement(ElementName="strokeWeight")]
		[XmlElement(ElementName="strokeWeight")]
		public short gxTpr_Strokeweight
		{
			get { 
				return gxTv_SdtPolyline_PolylineItem_Strokeweight; 
			}
			set { 
				gxTv_SdtPolyline_PolylineItem_Strokeweight = value;
				SetDirty("Strokeweight");
			}
		}




		[SoapElement(ElementName="Placa")]
		[XmlElement(ElementName="Placa")]
		public string gxTpr_Placa
		{
			get { 
				return gxTv_SdtPolyline_PolylineItem_Placa; 
			}
			set { 
				gxTv_SdtPolyline_PolylineItem_Placa = value;
				SetDirty("Placa");
			}
		}




		[SoapElement(ElementName="URLIconeInicio")]
		[XmlElement(ElementName="URLIconeInicio")]
		public string gxTpr_Urliconeinicio
		{
			get { 
				return gxTv_SdtPolyline_PolylineItem_Urliconeinicio; 
			}
			set { 
				gxTv_SdtPolyline_PolylineItem_Urliconeinicio = value;
				SetDirty("Urliconeinicio");
			}
		}




		[SoapElement(ElementName="URLIconeFim")]
		[XmlElement(ElementName="URLIconeFim")]
		public string gxTpr_Urliconefim
		{
			get { 
				return gxTv_SdtPolyline_PolylineItem_Urliconefim; 
			}
			set { 
				gxTv_SdtPolyline_PolylineItem_Urliconefim = value;
				SetDirty("Urliconefim");
			}
		}




		[SoapElement(ElementName="URLIconeDuranteTrajeto")]
		[XmlElement(ElementName="URLIconeDuranteTrajeto")]
		public string gxTpr_Urliconedurantetrajeto
		{
			get { 
				return gxTv_SdtPolyline_PolylineItem_Urliconedurantetrajeto; 
			}
			set { 
				gxTv_SdtPolyline_PolylineItem_Urliconedurantetrajeto = value;
				SetDirty("Urliconedurantetrajeto");
			}
		}




		[SoapElement(ElementName="MilisegundosAnimacao")]
		[XmlElement(ElementName="MilisegundosAnimacao")]
		public long gxTpr_Milisegundosanimacao
		{
			get { 
				return gxTv_SdtPolyline_PolylineItem_Milisegundosanimacao; 
			}
			set { 
				gxTv_SdtPolyline_PolylineItem_Milisegundosanimacao = value;
				SetDirty("Milisegundosanimacao");
			}
		}




		[SoapElement(ElementName="URLIconAnimation")]
		[XmlElement(ElementName="URLIconAnimation")]
		public string gxTpr_Urliconanimation
		{
			get { 
				return gxTv_SdtPolyline_PolylineItem_Urliconanimation; 
			}
			set { 
				gxTv_SdtPolyline_PolylineItem_Urliconanimation = value;
				SetDirty("Urliconanimation");
			}
		}




		[SoapElement(ElementName="Pontos" )]
		[XmlArray(ElementName="Pontos"  )]
		[XmlArrayItemAttribute(ElementName="Pontos" , IsNullable=false )]
		public GXBaseCollection<SdtPolyline_PolylineItem_Pontos> gxTpr_Pontos
		{
			get {
				if ( gxTv_SdtPolyline_PolylineItem_Pontos == null )
				{
					gxTv_SdtPolyline_PolylineItem_Pontos = new GXBaseCollection<SdtPolyline_PolylineItem_Pontos>( context, "Polyline.PolylineItem.Pontos", "");
				}
				return gxTv_SdtPolyline_PolylineItem_Pontos;
			}
			set {
				if ( gxTv_SdtPolyline_PolylineItem_Pontos == null )
				{
					gxTv_SdtPolyline_PolylineItem_Pontos = new GXBaseCollection<SdtPolyline_PolylineItem_Pontos>( context, "Polyline.PolylineItem.Pontos", "");
				}
				gxTv_SdtPolyline_PolylineItem_Pontos_N = 0;

				gxTv_SdtPolyline_PolylineItem_Pontos = value;
				SetDirty("Pontos");
			}
		}

		public void gxTv_SdtPolyline_PolylineItem_Pontos_SetNull()
		{
			gxTv_SdtPolyline_PolylineItem_Pontos_N = 1;

			gxTv_SdtPolyline_PolylineItem_Pontos = null;
			return  ;
		}

		public bool gxTv_SdtPolyline_PolylineItem_Pontos_IsNull()
		{
			if (gxTv_SdtPolyline_PolylineItem_Pontos == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Pontos_GxSimpleCollection_Json()
		{
				return gxTv_SdtPolyline_PolylineItem_Pontos != null && gxTv_SdtPolyline_PolylineItem_Pontos.Count > 0;

		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtPolyline_PolylineItem_Strokecolor = "";


			gxTv_SdtPolyline_PolylineItem_Placa = "";
			gxTv_SdtPolyline_PolylineItem_Urliconeinicio = "";
			gxTv_SdtPolyline_PolylineItem_Urliconefim = "";
			gxTv_SdtPolyline_PolylineItem_Urliconedurantetrajeto = "";

			gxTv_SdtPolyline_PolylineItem_Urliconanimation = "";

			gxTv_SdtPolyline_PolylineItem_Pontos_N = 1;

			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtPolyline_PolylineItem_Polylineid;
		 

		protected bool gxTv_SdtPolyline_PolylineItem_Stroke;
		 

		protected string gxTv_SdtPolyline_PolylineItem_Strokecolor;
		 

		protected decimal gxTv_SdtPolyline_PolylineItem_Strokeopacity;
		 

		protected short gxTv_SdtPolyline_PolylineItem_Strokeweight;
		 

		protected string gxTv_SdtPolyline_PolylineItem_Placa;
		 

		protected string gxTv_SdtPolyline_PolylineItem_Urliconeinicio;
		 

		protected string gxTv_SdtPolyline_PolylineItem_Urliconefim;
		 

		protected string gxTv_SdtPolyline_PolylineItem_Urliconedurantetrajeto;
		 

		protected long gxTv_SdtPolyline_PolylineItem_Milisegundosanimacao;
		 

		protected string gxTv_SdtPolyline_PolylineItem_Urliconanimation;
		 
		protected short gxTv_SdtPolyline_PolylineItem_Pontos_N;
		protected GXBaseCollection<SdtPolyline_PolylineItem_Pontos> gxTv_SdtPolyline_PolylineItem_Pontos = null; 



		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"PolylineItem", Namespace="RastreamentoTCC")]
	public class SdtPolyline_PolylineItem_RESTInterface : GxGenericCollectionItem<SdtPolyline_PolylineItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtPolyline_PolylineItem_RESTInterface( ) : base()
		{
		}

		public SdtPolyline_PolylineItem_RESTInterface( SdtPolyline_PolylineItem psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="PolylineId", Order=0)]
		public  string gxTpr_Polylineid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Polylineid, 10, 0));

			}
			set { 
				sdt.gxTpr_Polylineid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="stroke", Order=1)]
		public bool gxTpr_Stroke
		{
			get { 
				return sdt.gxTpr_Stroke;

			}
			set { 
				sdt.gxTpr_Stroke = value;
			}
		}

		[DataMember(Name="strokeColor", Order=2)]
		public  string gxTpr_Strokecolor
		{
			get { 
				return sdt.gxTpr_Strokecolor;

			}
			set { 
				 sdt.gxTpr_Strokecolor = value;
			}
		}

		[DataMember(Name="strokeOpacity", Order=3)]
		public decimal gxTpr_Strokeopacity
		{
			get { 
				return sdt.gxTpr_Strokeopacity;

			}
			set { 
				sdt.gxTpr_Strokeopacity = value;
			}
		}

		[DataMember(Name="strokeWeight", Order=4)]
		public short gxTpr_Strokeweight
		{
			get { 
				return sdt.gxTpr_Strokeweight;

			}
			set { 
				sdt.gxTpr_Strokeweight = value;
			}
		}

		[DataMember(Name="Placa", Order=5)]
		public  string gxTpr_Placa
		{
			get { 
				return sdt.gxTpr_Placa;

			}
			set { 
				 sdt.gxTpr_Placa = value;
			}
		}

		[DataMember(Name="URLIconeInicio", Order=6)]
		public  string gxTpr_Urliconeinicio
		{
			get { 
				return sdt.gxTpr_Urliconeinicio;

			}
			set { 
				 sdt.gxTpr_Urliconeinicio = value;
			}
		}

		[DataMember(Name="URLIconeFim", Order=7)]
		public  string gxTpr_Urliconefim
		{
			get { 
				return sdt.gxTpr_Urliconefim;

			}
			set { 
				 sdt.gxTpr_Urliconefim = value;
			}
		}

		[DataMember(Name="URLIconeDuranteTrajeto", Order=8)]
		public  string gxTpr_Urliconedurantetrajeto
		{
			get { 
				return sdt.gxTpr_Urliconedurantetrajeto;

			}
			set { 
				 sdt.gxTpr_Urliconedurantetrajeto = value;
			}
		}

		[DataMember(Name="MilisegundosAnimacao", Order=9)]
		public  string gxTpr_Milisegundosanimacao
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Milisegundosanimacao, 16, 0));

			}
			set { 
				sdt.gxTpr_Milisegundosanimacao = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="URLIconAnimation", Order=10)]
		public  string gxTpr_Urliconanimation
		{
			get { 
				return sdt.gxTpr_Urliconanimation;

			}
			set { 
				 sdt.gxTpr_Urliconanimation = value;
			}
		}

		[DataMember(Name="Pontos", Order=11, EmitDefaultValue=false)]
		public GxGenericCollection<SdtPolyline_PolylineItem_Pontos_RESTInterface> gxTpr_Pontos
		{
			get {
				if (sdt.ShouldSerializegxTpr_Pontos_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtPolyline_PolylineItem_Pontos_RESTInterface>(sdt.gxTpr_Pontos);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Pontos);
			}
		}


		#endregion

		public SdtPolyline_PolylineItem sdt
		{
			get { 
				return (SdtPolyline_PolylineItem)Sdt;
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
				sdt = new SdtPolyline_PolylineItem() ;
			}
		}
	}
	#endregion
}