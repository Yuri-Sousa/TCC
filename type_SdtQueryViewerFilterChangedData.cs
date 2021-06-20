/*
				   File: type_SdtQueryViewerFilterChangedData
			Description: QueryViewerFilterChangedData
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
	[XmlRoot(ElementName="QueryViewerFilterChangedData")]
	[XmlType(TypeName="QueryViewerFilterChangedData" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtQueryViewerFilterChangedData : GxUserType
	{
		public SdtQueryViewerFilterChangedData( )
		{
			/* Constructor for serialization */
			gxTv_SdtQueryViewerFilterChangedData_Name = "";

		}

		public SdtQueryViewerFilterChangedData(IGxContext context)
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

			if (gxTv_SdtQueryViewerFilterChangedData_Selectedvalues != null)
			{
				AddObjectProperty("SelectedValues", gxTv_SdtQueryViewerFilterChangedData_Selectedvalues, false);  
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
				return gxTv_SdtQueryViewerFilterChangedData_Name; 
			}
			set { 
				gxTv_SdtQueryViewerFilterChangedData_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="SelectedValues" )]
		[XmlArray(ElementName="SelectedValues"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GxSimpleCollection<string> gxTpr_Selectedvalues_GxSimpleCollection
		{
			get {
				if ( gxTv_SdtQueryViewerFilterChangedData_Selectedvalues == null )
				{
					gxTv_SdtQueryViewerFilterChangedData_Selectedvalues = new GxSimpleCollection<string>( );
				}
				return gxTv_SdtQueryViewerFilterChangedData_Selectedvalues;
			}
			set {
				if ( gxTv_SdtQueryViewerFilterChangedData_Selectedvalues == null )
				{
					gxTv_SdtQueryViewerFilterChangedData_Selectedvalues = new GxSimpleCollection<string>( );
				}
				gxTv_SdtQueryViewerFilterChangedData_Selectedvalues_N = 0;

				gxTv_SdtQueryViewerFilterChangedData_Selectedvalues = value;
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public GxSimpleCollection<string> gxTpr_Selectedvalues
		{
			get {
				if ( gxTv_SdtQueryViewerFilterChangedData_Selectedvalues == null )
				{
					gxTv_SdtQueryViewerFilterChangedData_Selectedvalues = new GxSimpleCollection<string>();
				}
				gxTv_SdtQueryViewerFilterChangedData_Selectedvalues_N = 0;

				return gxTv_SdtQueryViewerFilterChangedData_Selectedvalues ;
			}
			set {
				gxTv_SdtQueryViewerFilterChangedData_Selectedvalues_N = 0;

				gxTv_SdtQueryViewerFilterChangedData_Selectedvalues = value;
				SetDirty("Selectedvalues");
			}
		}

		public void gxTv_SdtQueryViewerFilterChangedData_Selectedvalues_SetNull()
		{
			gxTv_SdtQueryViewerFilterChangedData_Selectedvalues_N = 1;

			gxTv_SdtQueryViewerFilterChangedData_Selectedvalues = null;
			return  ;
		}

		public bool gxTv_SdtQueryViewerFilterChangedData_Selectedvalues_IsNull()
		{
			if (gxTv_SdtQueryViewerFilterChangedData_Selectedvalues == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Selectedvalues_GxSimpleCollection_Json()
		{
				return gxTv_SdtQueryViewerFilterChangedData_Selectedvalues != null && gxTv_SdtQueryViewerFilterChangedData_Selectedvalues.Count > 0;

		}


		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtQueryViewerFilterChangedData_Name = "";

			gxTv_SdtQueryViewerFilterChangedData_Selectedvalues_N = 1;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtQueryViewerFilterChangedData_Name;
		 
		protected short gxTv_SdtQueryViewerFilterChangedData_Selectedvalues_N;
		protected GxSimpleCollection<string> gxTv_SdtQueryViewerFilterChangedData_Selectedvalues = null;  


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"QueryViewerFilterChangedData", Namespace="RastreamentoTCC")]
	public class SdtQueryViewerFilterChangedData_RESTInterface : GxGenericCollectionItem<SdtQueryViewerFilterChangedData>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtQueryViewerFilterChangedData_RESTInterface( ) : base()
		{
		}

		public SdtQueryViewerFilterChangedData_RESTInterface( SdtQueryViewerFilterChangedData psdt ) : base(psdt)
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

		[DataMember(Name="SelectedValues", Order=1, EmitDefaultValue=false)]
		public  GxSimpleCollection<string> gxTpr_Selectedvalues
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Selectedvalues_GxSimpleCollection_Json())
					return sdt.gxTpr_Selectedvalues;
				else
					return null;

			}
			set { 
				sdt.gxTpr_Selectedvalues = value ;
			}
		}


		#endregion

		public SdtQueryViewerFilterChangedData sdt
		{
			get { 
				return (SdtQueryViewerFilterChangedData)Sdt;
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
				sdt = new SdtQueryViewerFilterChangedData() ;
			}
		}
	}
	#endregion
}