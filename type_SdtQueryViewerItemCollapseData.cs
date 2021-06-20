/*
				   File: type_SdtQueryViewerItemCollapseData
			Description: QueryViewerItemCollapseData
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
	[XmlRoot(ElementName="QueryViewerItemCollapseData")]
	[XmlType(TypeName="QueryViewerItemCollapseData" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtQueryViewerItemCollapseData : GxUserType
	{
		public SdtQueryViewerItemCollapseData( )
		{
			/* Constructor for serialization */
			gxTv_SdtQueryViewerItemCollapseData_Name = "";

			gxTv_SdtQueryViewerItemCollapseData_Value = "";

		}

		public SdtQueryViewerItemCollapseData(IGxContext context)
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


			AddObjectProperty("Value", gxTpr_Value, false);

			if (gxTv_SdtQueryViewerItemCollapseData_Expandedvalues != null)
			{
				AddObjectProperty("ExpandedValues", gxTv_SdtQueryViewerItemCollapseData_Expandedvalues, false);  
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
				return gxTv_SdtQueryViewerItemCollapseData_Name; 
			}
			set { 
				gxTv_SdtQueryViewerItemCollapseData_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="Value")]
		[XmlElement(ElementName="Value")]
		public string gxTpr_Value
		{
			get { 
				return gxTv_SdtQueryViewerItemCollapseData_Value; 
			}
			set { 
				gxTv_SdtQueryViewerItemCollapseData_Value = value;
				SetDirty("Value");
			}
		}




		[SoapElement(ElementName="ExpandedValues" )]
		[XmlArray(ElementName="ExpandedValues"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GxSimpleCollection<string> gxTpr_Expandedvalues_GxSimpleCollection
		{
			get {
				if ( gxTv_SdtQueryViewerItemCollapseData_Expandedvalues == null )
				{
					gxTv_SdtQueryViewerItemCollapseData_Expandedvalues = new GxSimpleCollection<string>( );
				}
				return gxTv_SdtQueryViewerItemCollapseData_Expandedvalues;
			}
			set {
				if ( gxTv_SdtQueryViewerItemCollapseData_Expandedvalues == null )
				{
					gxTv_SdtQueryViewerItemCollapseData_Expandedvalues = new GxSimpleCollection<string>( );
				}
				gxTv_SdtQueryViewerItemCollapseData_Expandedvalues_N = 0;

				gxTv_SdtQueryViewerItemCollapseData_Expandedvalues = value;
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public GxSimpleCollection<string> gxTpr_Expandedvalues
		{
			get {
				if ( gxTv_SdtQueryViewerItemCollapseData_Expandedvalues == null )
				{
					gxTv_SdtQueryViewerItemCollapseData_Expandedvalues = new GxSimpleCollection<string>();
				}
				gxTv_SdtQueryViewerItemCollapseData_Expandedvalues_N = 0;

				return gxTv_SdtQueryViewerItemCollapseData_Expandedvalues ;
			}
			set {
				gxTv_SdtQueryViewerItemCollapseData_Expandedvalues_N = 0;

				gxTv_SdtQueryViewerItemCollapseData_Expandedvalues = value;
				SetDirty("Expandedvalues");
			}
		}

		public void gxTv_SdtQueryViewerItemCollapseData_Expandedvalues_SetNull()
		{
			gxTv_SdtQueryViewerItemCollapseData_Expandedvalues_N = 1;

			gxTv_SdtQueryViewerItemCollapseData_Expandedvalues = null;
			return  ;
		}

		public bool gxTv_SdtQueryViewerItemCollapseData_Expandedvalues_IsNull()
		{
			if (gxTv_SdtQueryViewerItemCollapseData_Expandedvalues == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Expandedvalues_GxSimpleCollection_Json()
		{
				return gxTv_SdtQueryViewerItemCollapseData_Expandedvalues != null && gxTv_SdtQueryViewerItemCollapseData_Expandedvalues.Count > 0;

		}


		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtQueryViewerItemCollapseData_Name = "";
			gxTv_SdtQueryViewerItemCollapseData_Value = "";

			gxTv_SdtQueryViewerItemCollapseData_Expandedvalues_N = 1;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtQueryViewerItemCollapseData_Name;
		 

		protected string gxTv_SdtQueryViewerItemCollapseData_Value;
		 
		protected short gxTv_SdtQueryViewerItemCollapseData_Expandedvalues_N;
		protected GxSimpleCollection<string> gxTv_SdtQueryViewerItemCollapseData_Expandedvalues = null;  


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"QueryViewerItemCollapseData", Namespace="RastreamentoTCC")]
	public class SdtQueryViewerItemCollapseData_RESTInterface : GxGenericCollectionItem<SdtQueryViewerItemCollapseData>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtQueryViewerItemCollapseData_RESTInterface( ) : base()
		{
		}

		public SdtQueryViewerItemCollapseData_RESTInterface( SdtQueryViewerItemCollapseData psdt ) : base(psdt)
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

		[DataMember(Name="Value", Order=1)]
		public  string gxTpr_Value
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Value);

			}
			set { 
				 sdt.gxTpr_Value = value;
			}
		}

		[DataMember(Name="ExpandedValues", Order=2, EmitDefaultValue=false)]
		public  GxSimpleCollection<string> gxTpr_Expandedvalues
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Expandedvalues_GxSimpleCollection_Json())
					return sdt.gxTpr_Expandedvalues;
				else
					return null;

			}
			set { 
				sdt.gxTpr_Expandedvalues = value ;
			}
		}


		#endregion

		public SdtQueryViewerItemCollapseData sdt
		{
			get { 
				return (SdtQueryViewerItemCollapseData)Sdt;
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
				sdt = new SdtQueryViewerItemCollapseData() ;
			}
		}
	}
	#endregion
}