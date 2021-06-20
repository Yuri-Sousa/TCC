/*
				   File: type_SdtQueryViewerItemExpandData
			Description: QueryViewerItemExpandData
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
	[XmlRoot(ElementName="QueryViewerItemExpandData")]
	[XmlType(TypeName="QueryViewerItemExpandData" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtQueryViewerItemExpandData : GxUserType
	{
		public SdtQueryViewerItemExpandData( )
		{
			/* Constructor for serialization */
			gxTv_SdtQueryViewerItemExpandData_Name = "";

			gxTv_SdtQueryViewerItemExpandData_Value = "";

		}

		public SdtQueryViewerItemExpandData(IGxContext context)
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

			if (gxTv_SdtQueryViewerItemExpandData_Expandedvalues != null)
			{
				AddObjectProperty("ExpandedValues", gxTv_SdtQueryViewerItemExpandData_Expandedvalues, false);  
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
				return gxTv_SdtQueryViewerItemExpandData_Name; 
			}
			set { 
				gxTv_SdtQueryViewerItemExpandData_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="Value")]
		[XmlElement(ElementName="Value")]
		public string gxTpr_Value
		{
			get { 
				return gxTv_SdtQueryViewerItemExpandData_Value; 
			}
			set { 
				gxTv_SdtQueryViewerItemExpandData_Value = value;
				SetDirty("Value");
			}
		}




		[SoapElement(ElementName="ExpandedValues" )]
		[XmlArray(ElementName="ExpandedValues"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GxSimpleCollection<string> gxTpr_Expandedvalues_GxSimpleCollection
		{
			get {
				if ( gxTv_SdtQueryViewerItemExpandData_Expandedvalues == null )
				{
					gxTv_SdtQueryViewerItemExpandData_Expandedvalues = new GxSimpleCollection<string>( );
				}
				return gxTv_SdtQueryViewerItemExpandData_Expandedvalues;
			}
			set {
				if ( gxTv_SdtQueryViewerItemExpandData_Expandedvalues == null )
				{
					gxTv_SdtQueryViewerItemExpandData_Expandedvalues = new GxSimpleCollection<string>( );
				}
				gxTv_SdtQueryViewerItemExpandData_Expandedvalues_N = 0;

				gxTv_SdtQueryViewerItemExpandData_Expandedvalues = value;
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public GxSimpleCollection<string> gxTpr_Expandedvalues
		{
			get {
				if ( gxTv_SdtQueryViewerItemExpandData_Expandedvalues == null )
				{
					gxTv_SdtQueryViewerItemExpandData_Expandedvalues = new GxSimpleCollection<string>();
				}
				gxTv_SdtQueryViewerItemExpandData_Expandedvalues_N = 0;

				return gxTv_SdtQueryViewerItemExpandData_Expandedvalues ;
			}
			set {
				gxTv_SdtQueryViewerItemExpandData_Expandedvalues_N = 0;

				gxTv_SdtQueryViewerItemExpandData_Expandedvalues = value;
				SetDirty("Expandedvalues");
			}
		}

		public void gxTv_SdtQueryViewerItemExpandData_Expandedvalues_SetNull()
		{
			gxTv_SdtQueryViewerItemExpandData_Expandedvalues_N = 1;

			gxTv_SdtQueryViewerItemExpandData_Expandedvalues = null;
			return  ;
		}

		public bool gxTv_SdtQueryViewerItemExpandData_Expandedvalues_IsNull()
		{
			if (gxTv_SdtQueryViewerItemExpandData_Expandedvalues == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Expandedvalues_GxSimpleCollection_Json()
		{
				return gxTv_SdtQueryViewerItemExpandData_Expandedvalues != null && gxTv_SdtQueryViewerItemExpandData_Expandedvalues.Count > 0;

		}


		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtQueryViewerItemExpandData_Name = "";
			gxTv_SdtQueryViewerItemExpandData_Value = "";

			gxTv_SdtQueryViewerItemExpandData_Expandedvalues_N = 1;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtQueryViewerItemExpandData_Name;
		 

		protected string gxTv_SdtQueryViewerItemExpandData_Value;
		 
		protected short gxTv_SdtQueryViewerItemExpandData_Expandedvalues_N;
		protected GxSimpleCollection<string> gxTv_SdtQueryViewerItemExpandData_Expandedvalues = null;  


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"QueryViewerItemExpandData", Namespace="RastreamentoTCC")]
	public class SdtQueryViewerItemExpandData_RESTInterface : GxGenericCollectionItem<SdtQueryViewerItemExpandData>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtQueryViewerItemExpandData_RESTInterface( ) : base()
		{
		}

		public SdtQueryViewerItemExpandData_RESTInterface( SdtQueryViewerItemExpandData psdt ) : base(psdt)
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

		public SdtQueryViewerItemExpandData sdt
		{
			get { 
				return (SdtQueryViewerItemExpandData)Sdt;
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
				sdt = new SdtQueryViewerItemExpandData() ;
			}
		}
	}
	#endregion
}