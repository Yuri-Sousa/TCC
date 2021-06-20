/*
				   File: type_SdtQueryViewerParameters_Parameter
			Description: QueryViewerParameters
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
	[XmlRoot(ElementName="Parameter")]
	[XmlType(TypeName="Parameter" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtQueryViewerParameters_Parameter : GxUserType
	{
		public SdtQueryViewerParameters_Parameter( )
		{
			/* Constructor for serialization */
			gxTv_SdtQueryViewerParameters_Parameter_Name = "";

			gxTv_SdtQueryViewerParameters_Parameter_Value = "";

		}

		public SdtQueryViewerParameters_Parameter(IGxContext context)
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

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public string gxTpr_Name
		{
			get { 
				return gxTv_SdtQueryViewerParameters_Parameter_Name; 
			}
			set { 
				gxTv_SdtQueryViewerParameters_Parameter_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="Value")]
		[XmlElement(ElementName="Value")]
		public string gxTpr_Value
		{
			get { 
				return gxTv_SdtQueryViewerParameters_Parameter_Value; 
			}
			set { 
				gxTv_SdtQueryViewerParameters_Parameter_Value = value;
				SetDirty("Value");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtQueryViewerParameters_Parameter_Name = "";
			gxTv_SdtQueryViewerParameters_Parameter_Value = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtQueryViewerParameters_Parameter_Name;
		 

		protected string gxTv_SdtQueryViewerParameters_Parameter_Value;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"Parameter", Namespace="RastreamentoTCC")]
	public class SdtQueryViewerParameters_Parameter_RESTInterface : GxGenericCollectionItem<SdtQueryViewerParameters_Parameter>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtQueryViewerParameters_Parameter_RESTInterface( ) : base()
		{
		}

		public SdtQueryViewerParameters_Parameter_RESTInterface( SdtQueryViewerParameters_Parameter psdt ) : base(psdt)
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


		#endregion

		public SdtQueryViewerParameters_Parameter sdt
		{
			get { 
				return (SdtQueryViewerParameters_Parameter)Sdt;
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
				sdt = new SdtQueryViewerParameters_Parameter() ;
			}
		}
	}
	#endregion
}