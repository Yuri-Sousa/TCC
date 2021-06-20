/*
				   File: type_SdtWWPGridState
			Description: WWPGridState
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

using GeneXus.Programs;
namespace GeneXus.Programs.wwpbaseobjects
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="WWPGridState")]
	[XmlType(TypeName="WWPGridState" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtWWPGridState : GxUserType
	{
		public SdtWWPGridState( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWPGridState_Pagesize = "";

			gxTv_SdtWWPGridState_Collapsedrecords = "";

			gxTv_SdtWWPGridState_Groupby = "";

		}

		public SdtWWPGridState(IGxContext context)
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
			AddObjectProperty("CurrentPage", gxTpr_Currentpage, false);


			AddObjectProperty("OrderedBy", gxTpr_Orderedby, false);


			AddObjectProperty("OrderedDsc", gxTpr_Ordereddsc, false);


			AddObjectProperty("HidingSearch", gxTpr_Hidingsearch, false);


			AddObjectProperty("PageSize", gxTpr_Pagesize, false);


			AddObjectProperty("CollapsedRecords", gxTpr_Collapsedrecords, false);


			AddObjectProperty("GroupBy", gxTpr_Groupby, false);

			if (gxTv_SdtWWPGridState_Filtervalues != null)
			{
				AddObjectProperty("FilterValues", gxTv_SdtWWPGridState_Filtervalues, false);  
			}
			if (gxTv_SdtWWPGridState_Dynamicfilters != null)
			{
				AddObjectProperty("DynamicFilters", gxTv_SdtWWPGridState_Dynamicfilters, false);  
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CurrentPage")]
		[XmlElement(ElementName="CurrentPage")]
		public short gxTpr_Currentpage
		{
			get { 
				return gxTv_SdtWWPGridState_Currentpage; 
			}
			set { 
				gxTv_SdtWWPGridState_Currentpage = value;
				SetDirty("Currentpage");
			}
		}




		[SoapElement(ElementName="OrderedBy")]
		[XmlElement(ElementName="OrderedBy")]
		public short gxTpr_Orderedby
		{
			get { 
				return gxTv_SdtWWPGridState_Orderedby; 
			}
			set { 
				gxTv_SdtWWPGridState_Orderedby = value;
				SetDirty("Orderedby");
			}
		}




		[SoapElement(ElementName="OrderedDsc")]
		[XmlElement(ElementName="OrderedDsc")]
		public bool gxTpr_Ordereddsc
		{
			get { 
				return gxTv_SdtWWPGridState_Ordereddsc; 
			}
			set { 
				gxTv_SdtWWPGridState_Ordereddsc = value;
				SetDirty("Ordereddsc");
			}
		}




		[SoapElement(ElementName="HidingSearch")]
		[XmlElement(ElementName="HidingSearch")]
		public short gxTpr_Hidingsearch
		{
			get { 
				return gxTv_SdtWWPGridState_Hidingsearch; 
			}
			set { 
				gxTv_SdtWWPGridState_Hidingsearch = value;
				SetDirty("Hidingsearch");
			}
		}




		[SoapElement(ElementName="PageSize")]
		[XmlElement(ElementName="PageSize")]
		public string gxTpr_Pagesize
		{
			get { 
				return gxTv_SdtWWPGridState_Pagesize; 
			}
			set { 
				gxTv_SdtWWPGridState_Pagesize = value;
				SetDirty("Pagesize");
			}
		}




		[SoapElement(ElementName="CollapsedRecords")]
		[XmlElement(ElementName="CollapsedRecords")]
		public string gxTpr_Collapsedrecords
		{
			get { 
				return gxTv_SdtWWPGridState_Collapsedrecords; 
			}
			set { 
				gxTv_SdtWWPGridState_Collapsedrecords = value;
				SetDirty("Collapsedrecords");
			}
		}




		[SoapElement(ElementName="GroupBy")]
		[XmlElement(ElementName="GroupBy")]
		public string gxTpr_Groupby
		{
			get { 
				return gxTv_SdtWWPGridState_Groupby; 
			}
			set { 
				gxTv_SdtWWPGridState_Groupby = value;
				SetDirty("Groupby");
			}
		}




		[SoapElement(ElementName="FilterValues" )]
		[XmlArray(ElementName="FilterValues"  )]
		[XmlArrayItemAttribute(ElementName="FilterValue" , IsNullable=false )]
		public GXBaseCollection<SdtWWPGridState_FilterValue> gxTpr_Filtervalues
		{
			get {
				if ( gxTv_SdtWWPGridState_Filtervalues == null )
				{
					gxTv_SdtWWPGridState_Filtervalues = new GXBaseCollection<SdtWWPGridState_FilterValue>( context, "WWPGridState.FilterValue", "");
				}
				return gxTv_SdtWWPGridState_Filtervalues;
			}
			set {
				if ( gxTv_SdtWWPGridState_Filtervalues == null )
				{
					gxTv_SdtWWPGridState_Filtervalues = new GXBaseCollection<SdtWWPGridState_FilterValue>( context, "WWPGridState.FilterValue", "");
				}
				gxTv_SdtWWPGridState_Filtervalues_N = 0;

				gxTv_SdtWWPGridState_Filtervalues = value;
				SetDirty("Filtervalues");
			}
		}

		public void gxTv_SdtWWPGridState_Filtervalues_SetNull()
		{
			gxTv_SdtWWPGridState_Filtervalues_N = 1;

			gxTv_SdtWWPGridState_Filtervalues = null;
			return  ;
		}

		public bool gxTv_SdtWWPGridState_Filtervalues_IsNull()
		{
			if (gxTv_SdtWWPGridState_Filtervalues == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Filtervalues_GxSimpleCollection_Json()
		{
				return gxTv_SdtWWPGridState_Filtervalues != null && gxTv_SdtWWPGridState_Filtervalues.Count > 0;

		}



		[SoapElement(ElementName="DynamicFilters" )]
		[XmlArray(ElementName="DynamicFilters"  )]
		[XmlArrayItemAttribute(ElementName="DynamicFilter" , IsNullable=false )]
		public GXBaseCollection<SdtWWPGridState_DynamicFilter> gxTpr_Dynamicfilters
		{
			get {
				if ( gxTv_SdtWWPGridState_Dynamicfilters == null )
				{
					gxTv_SdtWWPGridState_Dynamicfilters = new GXBaseCollection<SdtWWPGridState_DynamicFilter>( context, "WWPGridState.DynamicFilter", "");
				}
				return gxTv_SdtWWPGridState_Dynamicfilters;
			}
			set {
				if ( gxTv_SdtWWPGridState_Dynamicfilters == null )
				{
					gxTv_SdtWWPGridState_Dynamicfilters = new GXBaseCollection<SdtWWPGridState_DynamicFilter>( context, "WWPGridState.DynamicFilter", "");
				}
				gxTv_SdtWWPGridState_Dynamicfilters_N = 0;

				gxTv_SdtWWPGridState_Dynamicfilters = value;
				SetDirty("Dynamicfilters");
			}
		}

		public void gxTv_SdtWWPGridState_Dynamicfilters_SetNull()
		{
			gxTv_SdtWWPGridState_Dynamicfilters_N = 1;

			gxTv_SdtWWPGridState_Dynamicfilters = null;
			return  ;
		}

		public bool gxTv_SdtWWPGridState_Dynamicfilters_IsNull()
		{
			if (gxTv_SdtWWPGridState_Dynamicfilters == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Dynamicfilters_GxSimpleCollection_Json()
		{
				return gxTv_SdtWWPGridState_Dynamicfilters != null && gxTv_SdtWWPGridState_Dynamicfilters.Count > 0;

		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtWWPGridState_Pagesize = "";
			gxTv_SdtWWPGridState_Collapsedrecords = "";
			gxTv_SdtWWPGridState_Groupby = "";

			gxTv_SdtWWPGridState_Filtervalues_N = 1;


			gxTv_SdtWWPGridState_Dynamicfilters_N = 1;

			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtWWPGridState_Currentpage;
		 

		protected short gxTv_SdtWWPGridState_Orderedby;
		 

		protected bool gxTv_SdtWWPGridState_Ordereddsc;
		 

		protected short gxTv_SdtWWPGridState_Hidingsearch;
		 

		protected string gxTv_SdtWWPGridState_Pagesize;
		 

		protected string gxTv_SdtWWPGridState_Collapsedrecords;
		 

		protected string gxTv_SdtWWPGridState_Groupby;
		 
		protected short gxTv_SdtWWPGridState_Filtervalues_N;
		protected GXBaseCollection<SdtWWPGridState_FilterValue> gxTv_SdtWWPGridState_Filtervalues = null; 

		protected short gxTv_SdtWWPGridState_Dynamicfilters_N;
		protected GXBaseCollection<SdtWWPGridState_DynamicFilter> gxTv_SdtWWPGridState_Dynamicfilters = null; 



		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"WWPGridState", Namespace="RastreamentoTCC")]
	public class SdtWWPGridState_RESTInterface : GxGenericCollectionItem<SdtWWPGridState>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWPGridState_RESTInterface( ) : base()
		{
		}

		public SdtWWPGridState_RESTInterface( SdtWWPGridState psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="CurrentPage", Order=0)]
		public short gxTpr_Currentpage
		{
			get { 
				return sdt.gxTpr_Currentpage;

			}
			set { 
				sdt.gxTpr_Currentpage = value;
			}
		}

		[DataMember(Name="OrderedBy", Order=1)]
		public short gxTpr_Orderedby
		{
			get { 
				return sdt.gxTpr_Orderedby;

			}
			set { 
				sdt.gxTpr_Orderedby = value;
			}
		}

		[DataMember(Name="OrderedDsc", Order=2)]
		public bool gxTpr_Ordereddsc
		{
			get { 
				return sdt.gxTpr_Ordereddsc;

			}
			set { 
				sdt.gxTpr_Ordereddsc = value;
			}
		}

		[DataMember(Name="HidingSearch", Order=3)]
		public short gxTpr_Hidingsearch
		{
			get { 
				return sdt.gxTpr_Hidingsearch;

			}
			set { 
				sdt.gxTpr_Hidingsearch = value;
			}
		}

		[DataMember(Name="PageSize", Order=4)]
		public  string gxTpr_Pagesize
		{
			get { 
				return sdt.gxTpr_Pagesize;

			}
			set { 
				 sdt.gxTpr_Pagesize = value;
			}
		}

		[DataMember(Name="CollapsedRecords", Order=5)]
		public  string gxTpr_Collapsedrecords
		{
			get { 
				return sdt.gxTpr_Collapsedrecords;

			}
			set { 
				 sdt.gxTpr_Collapsedrecords = value;
			}
		}

		[DataMember(Name="GroupBy", Order=6)]
		public  string gxTpr_Groupby
		{
			get { 
				return sdt.gxTpr_Groupby;

			}
			set { 
				 sdt.gxTpr_Groupby = value;
			}
		}

		[DataMember(Name="FilterValues", Order=7, EmitDefaultValue=false)]
		public GxGenericCollection<SdtWWPGridState_FilterValue_RESTInterface> gxTpr_Filtervalues
		{
			get {
				if (sdt.ShouldSerializegxTpr_Filtervalues_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtWWPGridState_FilterValue_RESTInterface>(sdt.gxTpr_Filtervalues);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Filtervalues);
			}
		}

		[DataMember(Name="DynamicFilters", Order=8, EmitDefaultValue=false)]
		public GxGenericCollection<SdtWWPGridState_DynamicFilter_RESTInterface> gxTpr_Dynamicfilters
		{
			get {
				if (sdt.ShouldSerializegxTpr_Dynamicfilters_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtWWPGridState_DynamicFilter_RESTInterface>(sdt.gxTpr_Dynamicfilters);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Dynamicfilters);
			}
		}


		#endregion

		public SdtWWPGridState sdt
		{
			get { 
				return (SdtWWPGridState)Sdt;
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
				sdt = new SdtWWPGridState() ;
			}
		}
	}
	#endregion
}