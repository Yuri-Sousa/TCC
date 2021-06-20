/*
				   File: type_SdtQueryViewerItemClickData
			Description: QueryViewerItemClickData
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
	[XmlRoot(ElementName="QueryViewerItemClickData")]
	[XmlType(TypeName="QueryViewerItemClickData" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtQueryViewerItemClickData : GxUserType
	{
		public SdtQueryViewerItemClickData( )
		{
			/* Constructor for serialization */
			gxTv_SdtQueryViewerItemClickData_Name = "";

			gxTv_SdtQueryViewerItemClickData_Type = "";

			gxTv_SdtQueryViewerItemClickData_Axis = "";

			gxTv_SdtQueryViewerItemClickData_Value = "";

		}

		public SdtQueryViewerItemClickData(IGxContext context)
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


			AddObjectProperty("Type", gxTpr_Type, false);


			AddObjectProperty("Axis", gxTpr_Axis, false);


			AddObjectProperty("Value", gxTpr_Value, false);


			AddObjectProperty("Selected", gxTpr_Selected, false);

			if (gxTv_SdtQueryViewerItemClickData_Context != null)
			{
				AddObjectProperty("Context", gxTv_SdtQueryViewerItemClickData_Context, false);  
			}
			if (gxTv_SdtQueryViewerItemClickData_Filters != null)
			{
				AddObjectProperty("Filters", gxTv_SdtQueryViewerItemClickData_Filters, false);  
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
				return gxTv_SdtQueryViewerItemClickData_Name; 
			}
			set { 
				gxTv_SdtQueryViewerItemClickData_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="Type")]
		[XmlElement(ElementName="Type")]
		public string gxTpr_Type
		{
			get { 
				return gxTv_SdtQueryViewerItemClickData_Type; 
			}
			set { 
				gxTv_SdtQueryViewerItemClickData_Type = value;
				SetDirty("Type");
			}
		}




		[SoapElement(ElementName="Axis")]
		[XmlElement(ElementName="Axis")]
		public string gxTpr_Axis
		{
			get { 
				return gxTv_SdtQueryViewerItemClickData_Axis; 
			}
			set { 
				gxTv_SdtQueryViewerItemClickData_Axis = value;
				SetDirty("Axis");
			}
		}




		[SoapElement(ElementName="Value")]
		[XmlElement(ElementName="Value")]
		public string gxTpr_Value
		{
			get { 
				return gxTv_SdtQueryViewerItemClickData_Value; 
			}
			set { 
				gxTv_SdtQueryViewerItemClickData_Value = value;
				SetDirty("Value");
			}
		}




		[SoapElement(ElementName="Selected")]
		[XmlElement(ElementName="Selected")]
		public bool gxTpr_Selected
		{
			get { 
				return gxTv_SdtQueryViewerItemClickData_Selected; 
			}
			set { 
				gxTv_SdtQueryViewerItemClickData_Selected = value;
				SetDirty("Selected");
			}
		}




		[SoapElement(ElementName="Context" )]
		[XmlArray(ElementName="Context"  )]
		[XmlArrayItemAttribute(ElementName="Element" , IsNullable=false )]
		public GXBaseCollection<SdtQueryViewerItemClickData_Element> gxTpr_Context
		{
			get {
				if ( gxTv_SdtQueryViewerItemClickData_Context == null )
				{
					gxTv_SdtQueryViewerItemClickData_Context = new GXBaseCollection<SdtQueryViewerItemClickData_Element>( context, "QueryViewerItemClickData.Element", "");
				}
				return gxTv_SdtQueryViewerItemClickData_Context;
			}
			set {
				if ( gxTv_SdtQueryViewerItemClickData_Context == null )
				{
					gxTv_SdtQueryViewerItemClickData_Context = new GXBaseCollection<SdtQueryViewerItemClickData_Element>( context, "QueryViewerItemClickData.Element", "");
				}
				gxTv_SdtQueryViewerItemClickData_Context_N = 0;

				gxTv_SdtQueryViewerItemClickData_Context = value;
				SetDirty("Context");
			}
		}

		public void gxTv_SdtQueryViewerItemClickData_Context_SetNull()
		{
			gxTv_SdtQueryViewerItemClickData_Context_N = 1;

			gxTv_SdtQueryViewerItemClickData_Context = null;
			return  ;
		}

		public bool gxTv_SdtQueryViewerItemClickData_Context_IsNull()
		{
			if (gxTv_SdtQueryViewerItemClickData_Context == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Context_GxSimpleCollection_Json()
		{
				return gxTv_SdtQueryViewerItemClickData_Context != null && gxTv_SdtQueryViewerItemClickData_Context.Count > 0;

		}



		[SoapElement(ElementName="Filters" )]
		[XmlArray(ElementName="Filters"  )]
		[XmlArrayItemAttribute(ElementName="Filter" , IsNullable=false )]
		public GXBaseCollection<SdtQueryViewerItemClickData_Filter> gxTpr_Filters
		{
			get {
				if ( gxTv_SdtQueryViewerItemClickData_Filters == null )
				{
					gxTv_SdtQueryViewerItemClickData_Filters = new GXBaseCollection<SdtQueryViewerItemClickData_Filter>( context, "QueryViewerItemClickData.Filter", "");
				}
				return gxTv_SdtQueryViewerItemClickData_Filters;
			}
			set {
				if ( gxTv_SdtQueryViewerItemClickData_Filters == null )
				{
					gxTv_SdtQueryViewerItemClickData_Filters = new GXBaseCollection<SdtQueryViewerItemClickData_Filter>( context, "QueryViewerItemClickData.Filter", "");
				}
				gxTv_SdtQueryViewerItemClickData_Filters_N = 0;

				gxTv_SdtQueryViewerItemClickData_Filters = value;
				SetDirty("Filters");
			}
		}

		public void gxTv_SdtQueryViewerItemClickData_Filters_SetNull()
		{
			gxTv_SdtQueryViewerItemClickData_Filters_N = 1;

			gxTv_SdtQueryViewerItemClickData_Filters = null;
			return  ;
		}

		public bool gxTv_SdtQueryViewerItemClickData_Filters_IsNull()
		{
			if (gxTv_SdtQueryViewerItemClickData_Filters == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Filters_GxSimpleCollection_Json()
		{
				return gxTv_SdtQueryViewerItemClickData_Filters != null && gxTv_SdtQueryViewerItemClickData_Filters.Count > 0;

		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtQueryViewerItemClickData_Name = "";
			gxTv_SdtQueryViewerItemClickData_Type = "";
			gxTv_SdtQueryViewerItemClickData_Axis = "";
			gxTv_SdtQueryViewerItemClickData_Value = "";


			gxTv_SdtQueryViewerItemClickData_Context_N = 1;


			gxTv_SdtQueryViewerItemClickData_Filters_N = 1;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtQueryViewerItemClickData_Name;
		 

		protected string gxTv_SdtQueryViewerItemClickData_Type;
		 

		protected string gxTv_SdtQueryViewerItemClickData_Axis;
		 

		protected string gxTv_SdtQueryViewerItemClickData_Value;
		 

		protected bool gxTv_SdtQueryViewerItemClickData_Selected;
		 
		protected short gxTv_SdtQueryViewerItemClickData_Context_N;
		protected GXBaseCollection<SdtQueryViewerItemClickData_Element> gxTv_SdtQueryViewerItemClickData_Context = null; 

		protected short gxTv_SdtQueryViewerItemClickData_Filters_N;
		protected GXBaseCollection<SdtQueryViewerItemClickData_Filter> gxTv_SdtQueryViewerItemClickData_Filters = null; 



		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"QueryViewerItemClickData", Namespace="RastreamentoTCC")]
	public class SdtQueryViewerItemClickData_RESTInterface : GxGenericCollectionItem<SdtQueryViewerItemClickData>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtQueryViewerItemClickData_RESTInterface( ) : base()
		{
		}

		public SdtQueryViewerItemClickData_RESTInterface( SdtQueryViewerItemClickData psdt ) : base(psdt)
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

		[DataMember(Name="Type", Order=1)]
		public  string gxTpr_Type
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Type);

			}
			set { 
				 sdt.gxTpr_Type = value;
			}
		}

		[DataMember(Name="Axis", Order=2)]
		public  string gxTpr_Axis
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Axis);

			}
			set { 
				 sdt.gxTpr_Axis = value;
			}
		}

		[DataMember(Name="Value", Order=3)]
		public  string gxTpr_Value
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Value);

			}
			set { 
				 sdt.gxTpr_Value = value;
			}
		}

		[DataMember(Name="Selected", Order=4)]
		public bool gxTpr_Selected
		{
			get { 
				return sdt.gxTpr_Selected;

			}
			set { 
				sdt.gxTpr_Selected = value;
			}
		}

		[DataMember(Name="Context", Order=5, EmitDefaultValue=false)]
		public GxGenericCollection<SdtQueryViewerItemClickData_Element_RESTInterface> gxTpr_Context
		{
			get {
				if (sdt.ShouldSerializegxTpr_Context_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtQueryViewerItemClickData_Element_RESTInterface>(sdt.gxTpr_Context);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Context);
			}
		}

		[DataMember(Name="Filters", Order=6, EmitDefaultValue=false)]
		public GxGenericCollection<SdtQueryViewerItemClickData_Filter_RESTInterface> gxTpr_Filters
		{
			get {
				if (sdt.ShouldSerializegxTpr_Filters_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtQueryViewerItemClickData_Filter_RESTInterface>(sdt.gxTpr_Filters);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Filters);
			}
		}


		#endregion

		public SdtQueryViewerItemClickData sdt
		{
			get { 
				return (SdtQueryViewerItemClickData)Sdt;
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
				sdt = new SdtQueryViewerItemClickData() ;
			}
		}
	}
	#endregion
}