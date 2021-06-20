/*
				   File: type_SdtGxMap_Polygon
			Description: Polygons
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
	[XmlRoot(ElementName="GxMap.Polygon")]
	[XmlType(TypeName="GxMap.Polygon" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtGxMap_Polygon : GxUserType
	{
		public SdtGxMap_Polygon( )
		{
			/* Constructor for serialization */
			gxTv_SdtGxMap_Polygon_Polygonfill = "";

			gxTv_SdtGxMap_Polygon_Polygonstroke = "";

			gxTv_SdtGxMap_Polygon_Polygoninfowinhtml = "";

		}

		public SdtGxMap_Polygon(IGxContext context)
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
			AddObjectProperty("PolygonFill", gxTpr_Polygonfill, false);


			AddObjectProperty("PolygonFillOpacity", gxTpr_Polygonfillopacity, false);


			AddObjectProperty("PolygonStroke", gxTpr_Polygonstroke, false);


			AddObjectProperty("PolygonStrokeOpacity", gxTpr_Polygonstrokeopacity, false);


			AddObjectProperty("PolygonStrokeWeight", gxTpr_Polygonstrokeweight, false);


			AddObjectProperty("PolygonInfowinHtml", gxTpr_Polygoninfowinhtml, false);

			if (gxTv_SdtGxMap_Polygon_Paths != null)
			{
				AddObjectProperty("Paths", gxTv_SdtGxMap_Polygon_Paths, false);  
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PolygonFill")]
		[XmlElement(ElementName="PolygonFill")]
		public string gxTpr_Polygonfill
		{
			get { 
				return gxTv_SdtGxMap_Polygon_Polygonfill; 
			}
			set { 
				gxTv_SdtGxMap_Polygon_Polygonfill = value;
				SetDirty("Polygonfill");
			}
		}



		[SoapElement(ElementName="PolygonFillOpacity")]
		[XmlElement(ElementName="PolygonFillOpacity")]
		public string gxTpr_Polygonfillopacity_double
		{
			get {
				return Convert.ToString(gxTv_SdtGxMap_Polygon_Polygonfillopacity, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtGxMap_Polygon_Polygonfillopacity = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Polygonfillopacity
		{
			get { 
				return gxTv_SdtGxMap_Polygon_Polygonfillopacity; 
			}
			set { 
				gxTv_SdtGxMap_Polygon_Polygonfillopacity = value;
				SetDirty("Polygonfillopacity");
			}
		}




		[SoapElement(ElementName="PolygonStroke")]
		[XmlElement(ElementName="PolygonStroke")]
		public string gxTpr_Polygonstroke
		{
			get { 
				return gxTv_SdtGxMap_Polygon_Polygonstroke; 
			}
			set { 
				gxTv_SdtGxMap_Polygon_Polygonstroke = value;
				SetDirty("Polygonstroke");
			}
		}



		[SoapElement(ElementName="PolygonStrokeOpacity")]
		[XmlElement(ElementName="PolygonStrokeOpacity")]
		public string gxTpr_Polygonstrokeopacity_double
		{
			get {
				return Convert.ToString(gxTv_SdtGxMap_Polygon_Polygonstrokeopacity, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtGxMap_Polygon_Polygonstrokeopacity = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Polygonstrokeopacity
		{
			get { 
				return gxTv_SdtGxMap_Polygon_Polygonstrokeopacity; 
			}
			set { 
				gxTv_SdtGxMap_Polygon_Polygonstrokeopacity = value;
				SetDirty("Polygonstrokeopacity");
			}
		}




		[SoapElement(ElementName="PolygonStrokeWeight")]
		[XmlElement(ElementName="PolygonStrokeWeight")]
		public short gxTpr_Polygonstrokeweight
		{
			get { 
				return gxTv_SdtGxMap_Polygon_Polygonstrokeweight; 
			}
			set { 
				gxTv_SdtGxMap_Polygon_Polygonstrokeweight = value;
				SetDirty("Polygonstrokeweight");
			}
		}




		[SoapElement(ElementName="PolygonInfowinHtml")]
		[XmlElement(ElementName="PolygonInfowinHtml")]
		public string gxTpr_Polygoninfowinhtml
		{
			get { 
				return gxTv_SdtGxMap_Polygon_Polygoninfowinhtml; 
			}
			set { 
				gxTv_SdtGxMap_Polygon_Polygoninfowinhtml = value;
				SetDirty("Polygoninfowinhtml");
			}
		}




		[SoapElement(ElementName="Paths" )]
		[XmlArray(ElementName="Paths"  )]
		[XmlArrayItemAttribute(ElementName="Path" , IsNullable=false )]
		public GXBaseCollection<SdtGxMap_Polygon_Path> gxTpr_Paths
		{
			get {
				if ( gxTv_SdtGxMap_Polygon_Paths == null )
				{
					gxTv_SdtGxMap_Polygon_Paths = new GXBaseCollection<SdtGxMap_Polygon_Path>( context, "GxMap.Polygon.Path", "");
				}
				return gxTv_SdtGxMap_Polygon_Paths;
			}
			set {
				if ( gxTv_SdtGxMap_Polygon_Paths == null )
				{
					gxTv_SdtGxMap_Polygon_Paths = new GXBaseCollection<SdtGxMap_Polygon_Path>( context, "GxMap.Polygon.Path", "");
				}
				gxTv_SdtGxMap_Polygon_Paths_N = 0;

				gxTv_SdtGxMap_Polygon_Paths = value;
				SetDirty("Paths");
			}
		}

		public void gxTv_SdtGxMap_Polygon_Paths_SetNull()
		{
			gxTv_SdtGxMap_Polygon_Paths_N = 1;

			gxTv_SdtGxMap_Polygon_Paths = null;
			return  ;
		}

		public bool gxTv_SdtGxMap_Polygon_Paths_IsNull()
		{
			if (gxTv_SdtGxMap_Polygon_Paths == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Paths_GxSimpleCollection_Json()
		{
				return gxTv_SdtGxMap_Polygon_Paths != null && gxTv_SdtGxMap_Polygon_Paths.Count > 0;

		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtGxMap_Polygon_Polygonfill = "";

			gxTv_SdtGxMap_Polygon_Polygonstroke = "";


			gxTv_SdtGxMap_Polygon_Polygoninfowinhtml = "";

			gxTv_SdtGxMap_Polygon_Paths_N = 1;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtGxMap_Polygon_Polygonfill;
		 

		protected decimal gxTv_SdtGxMap_Polygon_Polygonfillopacity;
		 

		protected string gxTv_SdtGxMap_Polygon_Polygonstroke;
		 

		protected decimal gxTv_SdtGxMap_Polygon_Polygonstrokeopacity;
		 

		protected short gxTv_SdtGxMap_Polygon_Polygonstrokeweight;
		 

		protected string gxTv_SdtGxMap_Polygon_Polygoninfowinhtml;
		 
		protected short gxTv_SdtGxMap_Polygon_Paths_N;
		protected GXBaseCollection<SdtGxMap_Polygon_Path> gxTv_SdtGxMap_Polygon_Paths = null; 



		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"GxMap.Polygon", Namespace="RastreamentoTCC")]
	public class SdtGxMap_Polygon_RESTInterface : GxGenericCollectionItem<SdtGxMap_Polygon>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtGxMap_Polygon_RESTInterface( ) : base()
		{
		}

		public SdtGxMap_Polygon_RESTInterface( SdtGxMap_Polygon psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="PolygonFill", Order=0)]
		public  string gxTpr_Polygonfill
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Polygonfill);

			}
			set { 
				 sdt.gxTpr_Polygonfill = value;
			}
		}

		[DataMember(Name="PolygonFillOpacity", Order=1)]
		public decimal gxTpr_Polygonfillopacity
		{
			get { 
				return sdt.gxTpr_Polygonfillopacity;

			}
			set { 
				sdt.gxTpr_Polygonfillopacity = value;
			}
		}

		[DataMember(Name="PolygonStroke", Order=2)]
		public  string gxTpr_Polygonstroke
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Polygonstroke);

			}
			set { 
				 sdt.gxTpr_Polygonstroke = value;
			}
		}

		[DataMember(Name="PolygonStrokeOpacity", Order=3)]
		public decimal gxTpr_Polygonstrokeopacity
		{
			get { 
				return sdt.gxTpr_Polygonstrokeopacity;

			}
			set { 
				sdt.gxTpr_Polygonstrokeopacity = value;
			}
		}

		[DataMember(Name="PolygonStrokeWeight", Order=4)]
		public short gxTpr_Polygonstrokeweight
		{
			get { 
				return sdt.gxTpr_Polygonstrokeweight;

			}
			set { 
				sdt.gxTpr_Polygonstrokeweight = value;
			}
		}

		[DataMember(Name="PolygonInfowinHtml", Order=5)]
		public  string gxTpr_Polygoninfowinhtml
		{
			get { 
				return sdt.gxTpr_Polygoninfowinhtml;

			}
			set { 
				 sdt.gxTpr_Polygoninfowinhtml = value;
			}
		}

		[DataMember(Name="Paths", Order=6, EmitDefaultValue=false)]
		public GxGenericCollection<SdtGxMap_Polygon_Path_RESTInterface> gxTpr_Paths
		{
			get {
				if (sdt.ShouldSerializegxTpr_Paths_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtGxMap_Polygon_Path_RESTInterface>(sdt.gxTpr_Paths);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Paths);
			}
		}


		#endregion

		public SdtGxMap_Polygon sdt
		{
			get { 
				return (SdtGxMap_Polygon)Sdt;
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
				sdt = new SdtGxMap_Polygon() ;
			}
		}
	}
	#endregion
}