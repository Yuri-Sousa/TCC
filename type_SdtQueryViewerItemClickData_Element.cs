/*
				   File: type_SdtQueryViewerItemClickData_Element
			Description: Context
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
	[XmlRoot(ElementName="QueryViewerItemClickData.Element")]
	[XmlType(TypeName="QueryViewerItemClickData.Element" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtQueryViewerItemClickData_Element : GxUserType
	{
		public SdtQueryViewerItemClickData_Element( )
		{
			/* Constructor for serialization */
			gxTv_SdtQueryViewerItemClickData_Element_Name = "";

		}

		public SdtQueryViewerItemClickData_Element(IGxContext context)
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

			if (gxTv_SdtQueryViewerItemClickData_Element_Values != null)
			{
				AddObjectProperty("Values", gxTv_SdtQueryViewerItemClickData_Element_Values, false);  
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
				return gxTv_SdtQueryViewerItemClickData_Element_Name; 
			}
			set { 
				gxTv_SdtQueryViewerItemClickData_Element_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="Values" )]
		[XmlArray(ElementName="Values"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GxSimpleCollection<string> gxTpr_Values_GxSimpleCollection
		{
			get {
				if ( gxTv_SdtQueryViewerItemClickData_Element_Values == null )
				{
					gxTv_SdtQueryViewerItemClickData_Element_Values = new GxSimpleCollection<string>( );
				}
				return gxTv_SdtQueryViewerItemClickData_Element_Values;
			}
			set {
				if ( gxTv_SdtQueryViewerItemClickData_Element_Values == null )
				{
					gxTv_SdtQueryViewerItemClickData_Element_Values = new GxSimpleCollection<string>( );
				}
				gxTv_SdtQueryViewerItemClickData_Element_Values_N = 0;

				gxTv_SdtQueryViewerItemClickData_Element_Values = value;
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public GxSimpleCollection<string> gxTpr_Values
		{
			get {
				if ( gxTv_SdtQueryViewerItemClickData_Element_Values == null )
				{
					gxTv_SdtQueryViewerItemClickData_Element_Values = new GxSimpleCollection<string>();
				}
				gxTv_SdtQueryViewerItemClickData_Element_Values_N = 0;

				return gxTv_SdtQueryViewerItemClickData_Element_Values ;
			}
			set {
				gxTv_SdtQueryViewerItemClickData_Element_Values_N = 0;

				gxTv_SdtQueryViewerItemClickData_Element_Values = value;
				SetDirty("Values");
			}
		}

		public void gxTv_SdtQueryViewerItemClickData_Element_Values_SetNull()
		{
			gxTv_SdtQueryViewerItemClickData_Element_Values_N = 1;

			gxTv_SdtQueryViewerItemClickData_Element_Values = null;
			return  ;
		}

		public bool gxTv_SdtQueryViewerItemClickData_Element_Values_IsNull()
		{
			if (gxTv_SdtQueryViewerItemClickData_Element_Values == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Values_GxSimpleCollection_Json()
		{
				return gxTv_SdtQueryViewerItemClickData_Element_Values != null && gxTv_SdtQueryViewerItemClickData_Element_Values.Count > 0;

		}


		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtQueryViewerItemClickData_Element_Name = "";

			gxTv_SdtQueryViewerItemClickData_Element_Values_N = 1;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtQueryViewerItemClickData_Element_Name;
		 
		protected short gxTv_SdtQueryViewerItemClickData_Element_Values_N;
		protected GxSimpleCollection<string> gxTv_SdtQueryViewerItemClickData_Element_Values = null;  


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"QueryViewerItemClickData.Element", Namespace="RastreamentoTCC")]
	public class SdtQueryViewerItemClickData_Element_RESTInterface : GxGenericCollectionItem<SdtQueryViewerItemClickData_Element>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtQueryViewerItemClickData_Element_RESTInterface( ) : base()
		{
		}

		public SdtQueryViewerItemClickData_Element_RESTInterface( SdtQueryViewerItemClickData_Element psdt ) : base(psdt)
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

		[DataMember(Name="Values", Order=1, EmitDefaultValue=false)]
		public  GxSimpleCollection<string> gxTpr_Values
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Values_GxSimpleCollection_Json())
					return sdt.gxTpr_Values;
				else
					return null;

			}
			set { 
				sdt.gxTpr_Values = value ;
			}
		}


		#endregion

		public SdtQueryViewerItemClickData_Element sdt
		{
			get { 
				return (SdtQueryViewerItemClickData_Element)Sdt;
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
				sdt = new SdtQueryViewerItemClickData_Element() ;
			}
		}
	}
	#endregion
}