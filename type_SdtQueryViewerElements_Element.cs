/*
				   File: type_SdtQueryViewerElements_Element
			Description: QueryViewerElements
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
	[XmlRoot(ElementName="Element")]
	[XmlType(TypeName="Element" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtQueryViewerElements_Element : GxUserType
	{
		public SdtQueryViewerElements_Element( )
		{
			/* Constructor for serialization */
			gxTv_SdtQueryViewerElements_Element_Name = "";

			gxTv_SdtQueryViewerElements_Element_Title = "";

			gxTv_SdtQueryViewerElements_Element_Visible = "";

			gxTv_SdtQueryViewerElements_Element_Type = "";

			gxTv_SdtQueryViewerElements_Element_Axis = "";

			gxTv_SdtQueryViewerElements_Element_Aggregation = "";

			gxTv_SdtQueryViewerElements_Element_Datafield = "";

		}

		public SdtQueryViewerElements_Element(IGxContext context)
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
			AddObjectProperty("Name", gxTpr_Name, false);


			AddObjectProperty("Title", gxTpr_Title, false);


			AddObjectProperty("Visible", gxTpr_Visible, false);


			AddObjectProperty("Type", gxTpr_Type, false);


			AddObjectProperty("Axis", gxTpr_Axis, false);


			AddObjectProperty("Aggregation", gxTpr_Aggregation, false);


			AddObjectProperty("DataField", gxTpr_Datafield, false);

			if (gxTv_SdtQueryViewerElements_Element_Filter != null)
			{
				AddObjectProperty("Filter", gxTv_SdtQueryViewerElements_Element_Filter, false);  
			}
			if (gxTv_SdtQueryViewerElements_Element_Expandcollapse != null)
			{
				AddObjectProperty("ExpandCollapse", gxTv_SdtQueryViewerElements_Element_Expandcollapse, false);  
			}
			if (gxTv_SdtQueryViewerElements_Element_Axisorder != null)
			{
				AddObjectProperty("AxisOrder", gxTv_SdtQueryViewerElements_Element_Axisorder, false);  
			}
			if (gxTv_SdtQueryViewerElements_Element_Format != null)
			{
				AddObjectProperty("Format", gxTv_SdtQueryViewerElements_Element_Format, false);  
			}
			if (gxTv_SdtQueryViewerElements_Element_Grouping != null)
			{
				AddObjectProperty("Grouping", gxTv_SdtQueryViewerElements_Element_Grouping, false);  
			}
			if (gxTv_SdtQueryViewerElements_Element_Actions != null)
			{
				AddObjectProperty("Actions", gxTv_SdtQueryViewerElements_Element_Actions, false);  
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public string gxTpr_Name
		{
			get { 
				return gxTv_SdtQueryViewerElements_Element_Name; 
			}
			set { 
				gxTv_SdtQueryViewerElements_Element_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="Title")]
		[XmlElement(ElementName="Title")]
		public string gxTpr_Title
		{
			get { 
				return gxTv_SdtQueryViewerElements_Element_Title; 
			}
			set { 
				gxTv_SdtQueryViewerElements_Element_Title = value;
				SetDirty("Title");
			}
		}




		[SoapElement(ElementName="Visible")]
		[XmlElement(ElementName="Visible")]
		public string gxTpr_Visible
		{
			get { 
				return gxTv_SdtQueryViewerElements_Element_Visible; 
			}
			set { 
				gxTv_SdtQueryViewerElements_Element_Visible = value;
				SetDirty("Visible");
			}
		}




		[SoapElement(ElementName="Type")]
		[XmlElement(ElementName="Type")]
		public string gxTpr_Type
		{
			get { 
				return gxTv_SdtQueryViewerElements_Element_Type; 
			}
			set { 
				gxTv_SdtQueryViewerElements_Element_Type = value;
				SetDirty("Type");
			}
		}




		[SoapElement(ElementName="Axis")]
		[XmlElement(ElementName="Axis")]
		public string gxTpr_Axis
		{
			get { 
				return gxTv_SdtQueryViewerElements_Element_Axis; 
			}
			set { 
				gxTv_SdtQueryViewerElements_Element_Axis = value;
				SetDirty("Axis");
			}
		}




		[SoapElement(ElementName="Aggregation")]
		[XmlElement(ElementName="Aggregation")]
		public string gxTpr_Aggregation
		{
			get { 
				return gxTv_SdtQueryViewerElements_Element_Aggregation; 
			}
			set { 
				gxTv_SdtQueryViewerElements_Element_Aggregation = value;
				SetDirty("Aggregation");
			}
		}




		[SoapElement(ElementName="DataField")]
		[XmlElement(ElementName="DataField")]
		public string gxTpr_Datafield
		{
			get { 
				return gxTv_SdtQueryViewerElements_Element_Datafield; 
			}
			set { 
				gxTv_SdtQueryViewerElements_Element_Datafield = value;
				SetDirty("Datafield");
			}
		}



		[SoapElement(ElementName="Filter" )]
		[XmlElement(ElementName="Filter" )]
		public SdtQueryViewerElements_Element_Filter gxTpr_Filter
		{
			get {
				if ( gxTv_SdtQueryViewerElements_Element_Filter == null )
				{
					gxTv_SdtQueryViewerElements_Element_Filter = new SdtQueryViewerElements_Element_Filter(context);
				}
				gxTv_SdtQueryViewerElements_Element_Filter_N = 0;

				return gxTv_SdtQueryViewerElements_Element_Filter;
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Filter_N = 0;

				gxTv_SdtQueryViewerElements_Element_Filter = value;
				SetDirty("Filter");
			}

		}

		public void gxTv_SdtQueryViewerElements_Element_Filter_SetNull()
		{
			gxTv_SdtQueryViewerElements_Element_Filter_N = 1;

			gxTv_SdtQueryViewerElements_Element_Filter = null;
			return  ;
		}

		public bool gxTv_SdtQueryViewerElements_Element_Filter_IsNull()
		{
			if (gxTv_SdtQueryViewerElements_Element_Filter == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Filter_Json()
		{
					return gxTv_SdtQueryViewerElements_Element_Filter != null;

		}


		[SoapElement(ElementName="ExpandCollapse" )]
		[XmlElement(ElementName="ExpandCollapse" )]
		public SdtQueryViewerElements_Element_ExpandCollapse gxTpr_Expandcollapse
		{
			get {
				if ( gxTv_SdtQueryViewerElements_Element_Expandcollapse == null )
				{
					gxTv_SdtQueryViewerElements_Element_Expandcollapse = new SdtQueryViewerElements_Element_ExpandCollapse(context);
				}
				gxTv_SdtQueryViewerElements_Element_Expandcollapse_N = 0;

				return gxTv_SdtQueryViewerElements_Element_Expandcollapse;
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Expandcollapse_N = 0;

				gxTv_SdtQueryViewerElements_Element_Expandcollapse = value;
				SetDirty("Expandcollapse");
			}

		}

		public void gxTv_SdtQueryViewerElements_Element_Expandcollapse_SetNull()
		{
			gxTv_SdtQueryViewerElements_Element_Expandcollapse_N = 1;

			gxTv_SdtQueryViewerElements_Element_Expandcollapse = null;
			return  ;
		}

		public bool gxTv_SdtQueryViewerElements_Element_Expandcollapse_IsNull()
		{
			if (gxTv_SdtQueryViewerElements_Element_Expandcollapse == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Expandcollapse_Json()
		{
					return gxTv_SdtQueryViewerElements_Element_Expandcollapse != null;

		}


		[SoapElement(ElementName="AxisOrder" )]
		[XmlElement(ElementName="AxisOrder" )]
		public SdtQueryViewerElements_Element_AxisOrder gxTpr_Axisorder
		{
			get {
				if ( gxTv_SdtQueryViewerElements_Element_Axisorder == null )
				{
					gxTv_SdtQueryViewerElements_Element_Axisorder = new SdtQueryViewerElements_Element_AxisOrder(context);
				}
				gxTv_SdtQueryViewerElements_Element_Axisorder_N = 0;

				return gxTv_SdtQueryViewerElements_Element_Axisorder;
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Axisorder_N = 0;

				gxTv_SdtQueryViewerElements_Element_Axisorder = value;
				SetDirty("Axisorder");
			}

		}

		public void gxTv_SdtQueryViewerElements_Element_Axisorder_SetNull()
		{
			gxTv_SdtQueryViewerElements_Element_Axisorder_N = 1;

			gxTv_SdtQueryViewerElements_Element_Axisorder = null;
			return  ;
		}

		public bool gxTv_SdtQueryViewerElements_Element_Axisorder_IsNull()
		{
			if (gxTv_SdtQueryViewerElements_Element_Axisorder == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Axisorder_Json()
		{
					return gxTv_SdtQueryViewerElements_Element_Axisorder != null;

		}


		[SoapElement(ElementName="Format" )]
		[XmlElement(ElementName="Format" )]
		public SdtQueryViewerElements_Element_Format gxTpr_Format
		{
			get {
				if ( gxTv_SdtQueryViewerElements_Element_Format == null )
				{
					gxTv_SdtQueryViewerElements_Element_Format = new SdtQueryViewerElements_Element_Format(context);
				}
				gxTv_SdtQueryViewerElements_Element_Format_N = 0;

				return gxTv_SdtQueryViewerElements_Element_Format;
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Format_N = 0;

				gxTv_SdtQueryViewerElements_Element_Format = value;
				SetDirty("Format");
			}

		}

		public void gxTv_SdtQueryViewerElements_Element_Format_SetNull()
		{
			gxTv_SdtQueryViewerElements_Element_Format_N = 1;

			gxTv_SdtQueryViewerElements_Element_Format = null;
			return  ;
		}

		public bool gxTv_SdtQueryViewerElements_Element_Format_IsNull()
		{
			if (gxTv_SdtQueryViewerElements_Element_Format == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Format_Json()
		{
					return gxTv_SdtQueryViewerElements_Element_Format != null;

		}


		[SoapElement(ElementName="Grouping" )]
		[XmlElement(ElementName="Grouping" )]
		public SdtQueryViewerElements_Element_Grouping gxTpr_Grouping
		{
			get {
				if ( gxTv_SdtQueryViewerElements_Element_Grouping == null )
				{
					gxTv_SdtQueryViewerElements_Element_Grouping = new SdtQueryViewerElements_Element_Grouping(context);
				}
				gxTv_SdtQueryViewerElements_Element_Grouping_N = 0;

				return gxTv_SdtQueryViewerElements_Element_Grouping;
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Grouping_N = 0;

				gxTv_SdtQueryViewerElements_Element_Grouping = value;
				SetDirty("Grouping");
			}

		}

		public void gxTv_SdtQueryViewerElements_Element_Grouping_SetNull()
		{
			gxTv_SdtQueryViewerElements_Element_Grouping_N = 1;

			gxTv_SdtQueryViewerElements_Element_Grouping = null;
			return  ;
		}

		public bool gxTv_SdtQueryViewerElements_Element_Grouping_IsNull()
		{
			if (gxTv_SdtQueryViewerElements_Element_Grouping == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Grouping_Json()
		{
					return gxTv_SdtQueryViewerElements_Element_Grouping != null;

		}


		[SoapElement(ElementName="Actions" )]
		[XmlElement(ElementName="Actions" )]
		public SdtQueryViewerElements_Element_Actions gxTpr_Actions
		{
			get {
				if ( gxTv_SdtQueryViewerElements_Element_Actions == null )
				{
					gxTv_SdtQueryViewerElements_Element_Actions = new SdtQueryViewerElements_Element_Actions(context);
				}
				gxTv_SdtQueryViewerElements_Element_Actions_N = 0;

				return gxTv_SdtQueryViewerElements_Element_Actions;
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Actions_N = 0;

				gxTv_SdtQueryViewerElements_Element_Actions = value;
				SetDirty("Actions");
			}

		}

		public void gxTv_SdtQueryViewerElements_Element_Actions_SetNull()
		{
			gxTv_SdtQueryViewerElements_Element_Actions_N = 1;

			gxTv_SdtQueryViewerElements_Element_Actions = null;
			return  ;
		}

		public bool gxTv_SdtQueryViewerElements_Element_Actions_IsNull()
		{
			if (gxTv_SdtQueryViewerElements_Element_Actions == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Actions_Json()
		{
					return gxTv_SdtQueryViewerElements_Element_Actions != null;

		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtQueryViewerElements_Element_Name = "";
			gxTv_SdtQueryViewerElements_Element_Title = "";
			gxTv_SdtQueryViewerElements_Element_Visible = "";
			gxTv_SdtQueryViewerElements_Element_Type = "";
			gxTv_SdtQueryViewerElements_Element_Axis = "";
			gxTv_SdtQueryViewerElements_Element_Aggregation = "";
			gxTv_SdtQueryViewerElements_Element_Datafield = "";

			gxTv_SdtQueryViewerElements_Element_Filter_N = 1;


			gxTv_SdtQueryViewerElements_Element_Expandcollapse_N = 1;


			gxTv_SdtQueryViewerElements_Element_Axisorder_N = 1;


			gxTv_SdtQueryViewerElements_Element_Format_N = 1;


			gxTv_SdtQueryViewerElements_Element_Grouping_N = 1;


			gxTv_SdtQueryViewerElements_Element_Actions_N = 1;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtQueryViewerElements_Element_Name;
		 

		protected string gxTv_SdtQueryViewerElements_Element_Title;
		 

		protected string gxTv_SdtQueryViewerElements_Element_Visible;
		 

		protected string gxTv_SdtQueryViewerElements_Element_Type;
		 

		protected string gxTv_SdtQueryViewerElements_Element_Axis;
		 

		protected string gxTv_SdtQueryViewerElements_Element_Aggregation;
		 

		protected string gxTv_SdtQueryViewerElements_Element_Datafield;
		 
		protected short gxTv_SdtQueryViewerElements_Element_Filter_N;
		protected SdtQueryViewerElements_Element_Filter gxTv_SdtQueryViewerElements_Element_Filter = null; 

		protected short gxTv_SdtQueryViewerElements_Element_Expandcollapse_N;
		protected SdtQueryViewerElements_Element_ExpandCollapse gxTv_SdtQueryViewerElements_Element_Expandcollapse = null; 

		protected short gxTv_SdtQueryViewerElements_Element_Axisorder_N;
		protected SdtQueryViewerElements_Element_AxisOrder gxTv_SdtQueryViewerElements_Element_Axisorder = null; 

		protected short gxTv_SdtQueryViewerElements_Element_Format_N;
		protected SdtQueryViewerElements_Element_Format gxTv_SdtQueryViewerElements_Element_Format = null; 

		protected short gxTv_SdtQueryViewerElements_Element_Grouping_N;
		protected SdtQueryViewerElements_Element_Grouping gxTv_SdtQueryViewerElements_Element_Grouping = null; 

		protected short gxTv_SdtQueryViewerElements_Element_Actions_N;
		protected SdtQueryViewerElements_Element_Actions gxTv_SdtQueryViewerElements_Element_Actions = null; 



		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"Element", Namespace="RastreamentoTCC")]
	public class SdtQueryViewerElements_Element_RESTInterface : GxGenericCollectionItem<SdtQueryViewerElements_Element>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtQueryViewerElements_Element_RESTInterface( ) : base()
		{
		}

		public SdtQueryViewerElements_Element_RESTInterface( SdtQueryViewerElements_Element psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="Name", Order=0)]
		public  string gxTpr_Name
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Name);

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[DataMember(Name="Title", Order=1)]
		public  string gxTpr_Title
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Title);

			}
			set { 
				 sdt.gxTpr_Title = value;
			}
		}

		[DataMember(Name="Visible", Order=2)]
		public  string gxTpr_Visible
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Visible);

			}
			set { 
				 sdt.gxTpr_Visible = value;
			}
		}

		[DataMember(Name="Type", Order=3)]
		public  string gxTpr_Type
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Type);

			}
			set { 
				 sdt.gxTpr_Type = value;
			}
		}

		[DataMember(Name="Axis", Order=4)]
		public  string gxTpr_Axis
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Axis);

			}
			set { 
				 sdt.gxTpr_Axis = value;
			}
		}

		[DataMember(Name="Aggregation", Order=5)]
		public  string gxTpr_Aggregation
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Aggregation);

			}
			set { 
				 sdt.gxTpr_Aggregation = value;
			}
		}

		[DataMember(Name="DataField", Order=6)]
		public  string gxTpr_Datafield
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Datafield);

			}
			set { 
				 sdt.gxTpr_Datafield = value;
			}
		}

		[DataMember(Name="Filter", Order=7, EmitDefaultValue=false)]
		public SdtQueryViewerElements_Element_Filter_RESTInterface gxTpr_Filter
		{
			get {
				if (sdt.ShouldSerializegxTpr_Filter_Json())
					return new SdtQueryViewerElements_Element_Filter_RESTInterface(sdt.gxTpr_Filter);
				else
					return null;

			}

			set {
				sdt.gxTpr_Filter = value.sdt;
			}

		}

		[DataMember(Name="ExpandCollapse", Order=8, EmitDefaultValue=false)]
		public SdtQueryViewerElements_Element_ExpandCollapse_RESTInterface gxTpr_Expandcollapse
		{
			get {
				if (sdt.ShouldSerializegxTpr_Expandcollapse_Json())
					return new SdtQueryViewerElements_Element_ExpandCollapse_RESTInterface(sdt.gxTpr_Expandcollapse);
				else
					return null;

			}

			set {
				sdt.gxTpr_Expandcollapse = value.sdt;
			}

		}

		[DataMember(Name="AxisOrder", Order=9, EmitDefaultValue=false)]
		public SdtQueryViewerElements_Element_AxisOrder_RESTInterface gxTpr_Axisorder
		{
			get {
				if (sdt.ShouldSerializegxTpr_Axisorder_Json())
					return new SdtQueryViewerElements_Element_AxisOrder_RESTInterface(sdt.gxTpr_Axisorder);
				else
					return null;

			}

			set {
				sdt.gxTpr_Axisorder = value.sdt;
			}

		}

		[DataMember(Name="Format", Order=10, EmitDefaultValue=false)]
		public SdtQueryViewerElements_Element_Format_RESTInterface gxTpr_Format
		{
			get {
				if (sdt.ShouldSerializegxTpr_Format_Json())
					return new SdtQueryViewerElements_Element_Format_RESTInterface(sdt.gxTpr_Format);
				else
					return null;

			}

			set {
				sdt.gxTpr_Format = value.sdt;
			}

		}

		[DataMember(Name="Grouping", Order=11, EmitDefaultValue=false)]
		public SdtQueryViewerElements_Element_Grouping_RESTInterface gxTpr_Grouping
		{
			get {
				if (sdt.ShouldSerializegxTpr_Grouping_Json())
					return new SdtQueryViewerElements_Element_Grouping_RESTInterface(sdt.gxTpr_Grouping);
				else
					return null;

			}

			set {
				sdt.gxTpr_Grouping = value.sdt;
			}

		}

		[DataMember(Name="Actions", Order=12, EmitDefaultValue=false)]
		public SdtQueryViewerElements_Element_Actions_RESTInterface gxTpr_Actions
		{
			get {
				if (sdt.ShouldSerializegxTpr_Actions_Json())
					return new SdtQueryViewerElements_Element_Actions_RESTInterface(sdt.gxTpr_Actions);
				else
					return null;

			}

			set {
				sdt.gxTpr_Actions = value.sdt;
			}

		}


		#endregion

		public SdtQueryViewerElements_Element sdt
		{
			get { 
				return (SdtQueryViewerElements_Element)Sdt;
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
				sdt = new SdtQueryViewerElements_Element() ;
			}
		}
	}
	#endregion
}