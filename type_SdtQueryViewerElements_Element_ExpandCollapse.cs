/*
				   File: type_SdtQueryViewerElements_Element_ExpandCollapse
			Description: ExpandCollapse
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
	[XmlRoot(ElementName="QueryViewerElements.Element.ExpandCollapse")]
	[XmlType(TypeName="QueryViewerElements.Element.ExpandCollapse" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtQueryViewerElements_Element_ExpandCollapse : GxUserType
	{
		public SdtQueryViewerElements_Element_ExpandCollapse( )
		{
			/* Constructor for serialization */
			gxTv_SdtQueryViewerElements_Element_ExpandCollapse_Type = "";

		}

		public SdtQueryViewerElements_Element_ExpandCollapse(IGxContext context)
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
			AddObjectProperty("Type", gxTpr_Type, false);

			if (gxTv_SdtQueryViewerElements_Element_ExpandCollapse_Values != null)
			{
				AddObjectProperty("Values", gxTv_SdtQueryViewerElements_Element_ExpandCollapse_Values, false);  
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Type")]
		[XmlElement(ElementName="Type")]
		public string gxTpr_Type
		{
			get { 
				return gxTv_SdtQueryViewerElements_Element_ExpandCollapse_Type; 
			}
			set { 
				gxTv_SdtQueryViewerElements_Element_ExpandCollapse_Type = value;
				SetDirty("Type");
			}
		}




		[SoapElement(ElementName="Values" )]
		[XmlArray(ElementName="Values"  )]
		[XmlArrayItemAttribute(ElementName="Value" , IsNullable=false )]
		public GxSimpleCollection<string> gxTpr_Values_GxSimpleCollection
		{
			get {
				if ( gxTv_SdtQueryViewerElements_Element_ExpandCollapse_Values == null )
				{
					gxTv_SdtQueryViewerElements_Element_ExpandCollapse_Values = new GxSimpleCollection<string>( );
				}
				return gxTv_SdtQueryViewerElements_Element_ExpandCollapse_Values;
			}
			set {
				if ( gxTv_SdtQueryViewerElements_Element_ExpandCollapse_Values == null )
				{
					gxTv_SdtQueryViewerElements_Element_ExpandCollapse_Values = new GxSimpleCollection<string>( );
				}
				gxTv_SdtQueryViewerElements_Element_ExpandCollapse_Values_N = 0;

				gxTv_SdtQueryViewerElements_Element_ExpandCollapse_Values = value;
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public GxSimpleCollection<string> gxTpr_Values
		{
			get {
				if ( gxTv_SdtQueryViewerElements_Element_ExpandCollapse_Values == null )
				{
					gxTv_SdtQueryViewerElements_Element_ExpandCollapse_Values = new GxSimpleCollection<string>();
				}
				gxTv_SdtQueryViewerElements_Element_ExpandCollapse_Values_N = 0;

				return gxTv_SdtQueryViewerElements_Element_ExpandCollapse_Values ;
			}
			set {
				gxTv_SdtQueryViewerElements_Element_ExpandCollapse_Values_N = 0;

				gxTv_SdtQueryViewerElements_Element_ExpandCollapse_Values = value;
				SetDirty("Values");
			}
		}

		public void gxTv_SdtQueryViewerElements_Element_ExpandCollapse_Values_SetNull()
		{
			gxTv_SdtQueryViewerElements_Element_ExpandCollapse_Values_N = 1;

			gxTv_SdtQueryViewerElements_Element_ExpandCollapse_Values = null;
			return  ;
		}

		public bool gxTv_SdtQueryViewerElements_Element_ExpandCollapse_Values_IsNull()
		{
			if (gxTv_SdtQueryViewerElements_Element_ExpandCollapse_Values == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Values_GxSimpleCollection_Json()
		{
				return gxTv_SdtQueryViewerElements_Element_ExpandCollapse_Values != null && gxTv_SdtQueryViewerElements_Element_ExpandCollapse_Values.Count > 0;

		}


		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtQueryViewerElements_Element_ExpandCollapse_Type = "";

			gxTv_SdtQueryViewerElements_Element_ExpandCollapse_Values_N = 1;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtQueryViewerElements_Element_ExpandCollapse_Type;
		 
		protected short gxTv_SdtQueryViewerElements_Element_ExpandCollapse_Values_N;
		protected GxSimpleCollection<string> gxTv_SdtQueryViewerElements_Element_ExpandCollapse_Values = null;  


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"QueryViewerElements.Element.ExpandCollapse", Namespace="RastreamentoTCC")]
	public class SdtQueryViewerElements_Element_ExpandCollapse_RESTInterface : GxGenericCollectionItem<SdtQueryViewerElements_Element_ExpandCollapse>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtQueryViewerElements_Element_ExpandCollapse_RESTInterface( ) : base()
		{
		}

		public SdtQueryViewerElements_Element_ExpandCollapse_RESTInterface( SdtQueryViewerElements_Element_ExpandCollapse psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="Type", Order=0)]
		public  string gxTpr_Type
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Type);

			}
			set { 
				 sdt.gxTpr_Type = value;
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

		public SdtQueryViewerElements_Element_ExpandCollapse sdt
		{
			get { 
				return (SdtQueryViewerElements_Element_ExpandCollapse)Sdt;
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
				sdt = new SdtQueryViewerElements_Element_ExpandCollapse() ;
			}
		}
	}
	#endregion
}