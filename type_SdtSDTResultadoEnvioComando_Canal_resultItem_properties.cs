/*
				   File: type_SdtSDTResultadoEnvioComando_Canal_resultItem_properties
			Description: properties
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
	[XmlRoot(ElementName="SDTResultadoEnvioComando_Canal.resultItem.properties")]
	[XmlType(TypeName="SDTResultadoEnvioComando_Canal.resultItem.properties" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtSDTResultadoEnvioComando_Canal_resultItem_properties : GxUserType
	{
		public SdtSDTResultadoEnvioComando_Canal_resultItem_properties( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_properties_Parameter_id = "";

			gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_properties_Payload = "";

			gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_properties_Cmd = "";

			gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_properties_Password = "";

		}

		public SdtSDTResultadoEnvioComando_Canal_resultItem_properties(IGxContext context)
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
			AddObjectProperty("parameter_id", gxTpr_Parameter_id, false);


			AddObjectProperty("payload", gxTpr_Payload, false);


			AddObjectProperty("cmd", gxTpr_Cmd, false);


			AddObjectProperty("password", gxTpr_Password, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="parameter_id")]
		[XmlElement(ElementName="parameter_id")]
		public string gxTpr_Parameter_id
		{
			get { 
				return gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_properties_Parameter_id; 
			}
			set { 
				gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_properties_Parameter_id = value;
				SetDirty("Parameter_id");
			}
		}




		[SoapElement(ElementName="payload")]
		[XmlElement(ElementName="payload")]
		public string gxTpr_Payload
		{
			get { 
				return gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_properties_Payload; 
			}
			set { 
				gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_properties_Payload = value;
				SetDirty("Payload");
			}
		}




		[SoapElement(ElementName="cmd")]
		[XmlElement(ElementName="cmd")]
		public string gxTpr_Cmd
		{
			get { 
				return gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_properties_Cmd; 
			}
			set { 
				gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_properties_Cmd = value;
				SetDirty("Cmd");
			}
		}




		[SoapElement(ElementName="password")]
		[XmlElement(ElementName="password")]
		public string gxTpr_Password
		{
			get { 
				return gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_properties_Password; 
			}
			set { 
				gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_properties_Password = value;
				SetDirty("Password");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_properties_Parameter_id = "";
			gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_properties_Payload = "";
			gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_properties_Cmd = "";
			gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_properties_Password = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_properties_Parameter_id;
		 

		protected string gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_properties_Payload;
		 

		protected string gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_properties_Cmd;
		 

		protected string gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_properties_Password;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SDTResultadoEnvioComando_Canal.resultItem.properties", Namespace="RastreamentoTCC")]
	public class SdtSDTResultadoEnvioComando_Canal_resultItem_properties_RESTInterface : GxGenericCollectionItem<SdtSDTResultadoEnvioComando_Canal_resultItem_properties>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTResultadoEnvioComando_Canal_resultItem_properties_RESTInterface( ) : base()
		{
		}

		public SdtSDTResultadoEnvioComando_Canal_resultItem_properties_RESTInterface( SdtSDTResultadoEnvioComando_Canal_resultItem_properties psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="parameter_id", Order=0)]
		public  string gxTpr_Parameter_id
		{
			get { 
				return sdt.gxTpr_Parameter_id;

			}
			set { 
				 sdt.gxTpr_Parameter_id = value;
			}
		}

		[DataMember(Name="payload", Order=1)]
		public  string gxTpr_Payload
		{
			get { 
				return sdt.gxTpr_Payload;

			}
			set { 
				 sdt.gxTpr_Payload = value;
			}
		}

		[DataMember(Name="cmd", Order=2)]
		public  string gxTpr_Cmd
		{
			get { 
				return sdt.gxTpr_Cmd;

			}
			set { 
				 sdt.gxTpr_Cmd = value;
			}
		}

		[DataMember(Name="password", Order=3)]
		public  string gxTpr_Password
		{
			get { 
				return sdt.gxTpr_Password;

			}
			set { 
				 sdt.gxTpr_Password = value;
			}
		}


		#endregion

		public SdtSDTResultadoEnvioComando_Canal_resultItem_properties sdt
		{
			get { 
				return (SdtSDTResultadoEnvioComando_Canal_resultItem_properties)Sdt;
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
				sdt = new SdtSDTResultadoEnvioComando_Canal_resultItem_properties() ;
			}
		}
	}
	#endregion
}