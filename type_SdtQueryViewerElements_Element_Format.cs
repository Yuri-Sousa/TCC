/*
				   File: type_SdtQueryViewerElements_Element_Format
			Description: Format
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
	[XmlRoot(ElementName="QueryViewerElements.Element.Format")]
	[XmlType(TypeName="QueryViewerElements.Element.Format" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtQueryViewerElements_Element_Format : GxUserType
	{
		public SdtQueryViewerElements_Element_Format( )
		{
			/* Constructor for serialization */
			gxTv_SdtQueryViewerElements_Element_Format_Picture = "";

			gxTv_SdtQueryViewerElements_Element_Format_Subtotals = "";

			gxTv_SdtQueryViewerElements_Element_Format_Style = "";

		}

		public SdtQueryViewerElements_Element_Format(IGxContext context)
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
			AddObjectProperty("Picture", gxTpr_Picture, false);


			AddObjectProperty("Subtotals", gxTpr_Subtotals, false);


			AddObjectProperty("CanDragToPages", gxTpr_Candragtopages, false);


			AddObjectProperty("Style", gxTpr_Style, false);


			AddObjectProperty("TargetValue", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Targetvalue, 18, 2)), false);


			AddObjectProperty("MaximumValue", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Maximumvalue, 18, 2)), false);

			if (gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles != null)
			{
				AddObjectProperty("ValuesStyles", gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles, false);  
			}
			if (gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles != null)
			{
				AddObjectProperty("ConditionalStyles", gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles, false);  
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Picture")]
		[XmlElement(ElementName="Picture")]
		public string gxTpr_Picture
		{
			get { 
				return gxTv_SdtQueryViewerElements_Element_Format_Picture; 
			}
			set { 
				gxTv_SdtQueryViewerElements_Element_Format_Picture = value;
				SetDirty("Picture");
			}
		}




		[SoapElement(ElementName="Subtotals")]
		[XmlElement(ElementName="Subtotals")]
		public string gxTpr_Subtotals
		{
			get { 
				return gxTv_SdtQueryViewerElements_Element_Format_Subtotals; 
			}
			set { 
				gxTv_SdtQueryViewerElements_Element_Format_Subtotals = value;
				SetDirty("Subtotals");
			}
		}




		[SoapElement(ElementName="CanDragToPages")]
		[XmlElement(ElementName="CanDragToPages")]
		public bool gxTpr_Candragtopages
		{
			get { 
				return gxTv_SdtQueryViewerElements_Element_Format_Candragtopages; 
			}
			set { 
				gxTv_SdtQueryViewerElements_Element_Format_Candragtopages = value;
				SetDirty("Candragtopages");
			}
		}




		[SoapElement(ElementName="Style")]
		[XmlElement(ElementName="Style")]
		public string gxTpr_Style
		{
			get { 
				return gxTv_SdtQueryViewerElements_Element_Format_Style; 
			}
			set { 
				gxTv_SdtQueryViewerElements_Element_Format_Style = value;
				SetDirty("Style");
			}
		}



		[SoapElement(ElementName="TargetValue")]
		[XmlElement(ElementName="TargetValue")]
		public string gxTpr_Targetvalue_double
		{
			get {
				return Convert.ToString(gxTv_SdtQueryViewerElements_Element_Format_Targetvalue, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Format_Targetvalue = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Targetvalue
		{
			get { 
				return gxTv_SdtQueryViewerElements_Element_Format_Targetvalue; 
			}
			set { 
				gxTv_SdtQueryViewerElements_Element_Format_Targetvalue = value;
				SetDirty("Targetvalue");
			}
		}



		[SoapElement(ElementName="MaximumValue")]
		[XmlElement(ElementName="MaximumValue")]
		public string gxTpr_Maximumvalue_double
		{
			get {
				return Convert.ToString(gxTv_SdtQueryViewerElements_Element_Format_Maximumvalue, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Format_Maximumvalue = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Maximumvalue
		{
			get { 
				return gxTv_SdtQueryViewerElements_Element_Format_Maximumvalue; 
			}
			set { 
				gxTv_SdtQueryViewerElements_Element_Format_Maximumvalue = value;
				SetDirty("Maximumvalue");
			}
		}




		[SoapElement(ElementName="ValuesStyles" )]
		[XmlArray(ElementName="ValuesStyles"  )]
		[XmlArrayItemAttribute(ElementName="ValueStyle" , IsNullable=false )]
		public GXBaseCollection<SdtQueryViewerElements_Element_Format_ValueStyle> gxTpr_Valuesstyles
		{
			get {
				if ( gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles == null )
				{
					gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles = new GXBaseCollection<SdtQueryViewerElements_Element_Format_ValueStyle>( context, "QueryViewerElements.Element.Format.ValueStyle", "");
				}
				return gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles;
			}
			set {
				if ( gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles == null )
				{
					gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles = new GXBaseCollection<SdtQueryViewerElements_Element_Format_ValueStyle>( context, "QueryViewerElements.Element.Format.ValueStyle", "");
				}
				gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles_N = 0;

				gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles = value;
				SetDirty("Valuesstyles");
			}
		}

		public void gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles_SetNull()
		{
			gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles_N = 1;

			gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles = null;
			return  ;
		}

		public bool gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles_IsNull()
		{
			if (gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Valuesstyles_GxSimpleCollection_Json()
		{
				return gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles != null && gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles.Count > 0;

		}



		[SoapElement(ElementName="ConditionalStyles" )]
		[XmlArray(ElementName="ConditionalStyles"  )]
		[XmlArrayItemAttribute(ElementName="ConditionalStyle" , IsNullable=false )]
		public GXBaseCollection<SdtQueryViewerElements_Element_Format_ConditionalStyle> gxTpr_Conditionalstyles
		{
			get {
				if ( gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles == null )
				{
					gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles = new GXBaseCollection<SdtQueryViewerElements_Element_Format_ConditionalStyle>( context, "QueryViewerElements.Element.Format.ConditionalStyle", "");
				}
				return gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles;
			}
			set {
				if ( gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles == null )
				{
					gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles = new GXBaseCollection<SdtQueryViewerElements_Element_Format_ConditionalStyle>( context, "QueryViewerElements.Element.Format.ConditionalStyle", "");
				}
				gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles_N = 0;

				gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles = value;
				SetDirty("Conditionalstyles");
			}
		}

		public void gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles_SetNull()
		{
			gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles_N = 1;

			gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles = null;
			return  ;
		}

		public bool gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles_IsNull()
		{
			if (gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Conditionalstyles_GxSimpleCollection_Json()
		{
				return gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles != null && gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles.Count > 0;

		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtQueryViewerElements_Element_Format_Picture = "";
			gxTv_SdtQueryViewerElements_Element_Format_Subtotals = "";
			gxTv_SdtQueryViewerElements_Element_Format_Candragtopages = true;
			gxTv_SdtQueryViewerElements_Element_Format_Style = "";



			gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles_N = 1;


			gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles_N = 1;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtQueryViewerElements_Element_Format_Picture;
		 

		protected string gxTv_SdtQueryViewerElements_Element_Format_Subtotals;
		 

		protected bool gxTv_SdtQueryViewerElements_Element_Format_Candragtopages;
		 

		protected string gxTv_SdtQueryViewerElements_Element_Format_Style;
		 

		protected decimal gxTv_SdtQueryViewerElements_Element_Format_Targetvalue;
		 

		protected decimal gxTv_SdtQueryViewerElements_Element_Format_Maximumvalue;
		 
		protected short gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles_N;
		protected GXBaseCollection<SdtQueryViewerElements_Element_Format_ValueStyle> gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles = null; 

		protected short gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles_N;
		protected GXBaseCollection<SdtQueryViewerElements_Element_Format_ConditionalStyle> gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles = null; 



		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"QueryViewerElements.Element.Format", Namespace="RastreamentoTCC")]
	public class SdtQueryViewerElements_Element_Format_RESTInterface : GxGenericCollectionItem<SdtQueryViewerElements_Element_Format>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtQueryViewerElements_Element_Format_RESTInterface( ) : base()
		{
		}

		public SdtQueryViewerElements_Element_Format_RESTInterface( SdtQueryViewerElements_Element_Format psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="Picture", Order=0)]
		public  string gxTpr_Picture
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Picture);

			}
			set { 
				 sdt.gxTpr_Picture = value;
			}
		}

		[DataMember(Name="Subtotals", Order=1)]
		public  string gxTpr_Subtotals
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Subtotals);

			}
			set { 
				 sdt.gxTpr_Subtotals = value;
			}
		}

		[DataMember(Name="CanDragToPages", Order=2)]
		public bool gxTpr_Candragtopages
		{
			get { 
				return sdt.gxTpr_Candragtopages;

			}
			set { 
				sdt.gxTpr_Candragtopages = value;
			}
		}

		[DataMember(Name="Style", Order=3)]
		public  string gxTpr_Style
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Style);

			}
			set { 
				 sdt.gxTpr_Style = value;
			}
		}

		[DataMember(Name="TargetValue", Order=4)]
		public  string gxTpr_Targetvalue
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Targetvalue, 18, 2));

			}
			set { 
				sdt.gxTpr_Targetvalue =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MaximumValue", Order=5)]
		public  string gxTpr_Maximumvalue
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Maximumvalue, 18, 2));

			}
			set { 
				sdt.gxTpr_Maximumvalue =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ValuesStyles", Order=6, EmitDefaultValue=false)]
		public GxGenericCollection<SdtQueryViewerElements_Element_Format_ValueStyle_RESTInterface> gxTpr_Valuesstyles
		{
			get {
				if (sdt.ShouldSerializegxTpr_Valuesstyles_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtQueryViewerElements_Element_Format_ValueStyle_RESTInterface>(sdt.gxTpr_Valuesstyles);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Valuesstyles);
			}
		}

		[DataMember(Name="ConditionalStyles", Order=7, EmitDefaultValue=false)]
		public GxGenericCollection<SdtQueryViewerElements_Element_Format_ConditionalStyle_RESTInterface> gxTpr_Conditionalstyles
		{
			get {
				if (sdt.ShouldSerializegxTpr_Conditionalstyles_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtQueryViewerElements_Element_Format_ConditionalStyle_RESTInterface>(sdt.gxTpr_Conditionalstyles);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Conditionalstyles);
			}
		}


		#endregion

		public SdtQueryViewerElements_Element_Format sdt
		{
			get { 
				return (SdtQueryViewerElements_Element_Format)Sdt;
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
				sdt = new SdtQueryViewerElements_Element_Format() ;
			}
		}
	}
	#endregion
}