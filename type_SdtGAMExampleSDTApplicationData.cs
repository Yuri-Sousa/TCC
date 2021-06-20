/*
				   File: type_SdtGAMExampleSDTApplicationData
			Description: GAMExampleSDTApplicationData
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
	[XmlRoot(ElementName="GAMExampleSDTApplicationData")]
	[XmlType(TypeName="GAMExampleSDTApplicationData" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtGAMExampleSDTApplicationData : GxUserType
	{
		public SdtGAMExampleSDTApplicationData( )
		{
			/* Constructor for serialization */
			gxTv_SdtGAMExampleSDTApplicationData_Application = "";

			gxTv_SdtGAMExampleSDTApplicationData_Operation = "";

		}

		public SdtGAMExampleSDTApplicationData(IGxContext context)
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
			AddObjectProperty("Application", gxTpr_Application, false);


			AddObjectProperty("Operation", gxTpr_Operation, false);


			AddObjectProperty("Other", gxTpr_Other, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Application")]
		[XmlElement(ElementName="Application")]
		public string gxTpr_Application
		{
			get { 
				return gxTv_SdtGAMExampleSDTApplicationData_Application; 
			}
			set { 
				gxTv_SdtGAMExampleSDTApplicationData_Application = value;
				SetDirty("Application");
			}
		}




		[SoapElement(ElementName="Operation")]
		[XmlElement(ElementName="Operation")]
		public string gxTpr_Operation
		{
			get { 
				return gxTv_SdtGAMExampleSDTApplicationData_Operation; 
			}
			set { 
				gxTv_SdtGAMExampleSDTApplicationData_Operation = value;
				SetDirty("Operation");
			}
		}




		[SoapElement(ElementName="Other")]
		[XmlElement(ElementName="Other")]
		public short gxTpr_Other
		{
			get { 
				return gxTv_SdtGAMExampleSDTApplicationData_Other; 
			}
			set { 
				gxTv_SdtGAMExampleSDTApplicationData_Other = value;
				SetDirty("Other");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtGAMExampleSDTApplicationData_Application = "";
			gxTv_SdtGAMExampleSDTApplicationData_Operation = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtGAMExampleSDTApplicationData_Application;
		 

		protected string gxTv_SdtGAMExampleSDTApplicationData_Operation;
		 

		protected short gxTv_SdtGAMExampleSDTApplicationData_Other;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"GAMExampleSDTApplicationData", Namespace="RastreamentoTCC")]
	public class SdtGAMExampleSDTApplicationData_RESTInterface : GxGenericCollectionItem<SdtGAMExampleSDTApplicationData>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtGAMExampleSDTApplicationData_RESTInterface( ) : base()
		{
		}

		public SdtGAMExampleSDTApplicationData_RESTInterface( SdtGAMExampleSDTApplicationData psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="Application", Order=0)]
		public  string gxTpr_Application
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Application);

			}
			set { 
				 sdt.gxTpr_Application = value;
			}
		}

		[DataMember(Name="Operation", Order=1)]
		public  string gxTpr_Operation
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Operation);

			}
			set { 
				 sdt.gxTpr_Operation = value;
			}
		}

		[DataMember(Name="Other", Order=2)]
		public short gxTpr_Other
		{
			get { 
				return sdt.gxTpr_Other;

			}
			set { 
				sdt.gxTpr_Other = value;
			}
		}


		#endregion

		public SdtGAMExampleSDTApplicationData sdt
		{
			get { 
				return (SdtGAMExampleSDTApplicationData)Sdt;
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
				sdt = new SdtGAMExampleSDTApplicationData() ;
			}
		}
	}
	#endregion
}