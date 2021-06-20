/*
				   File: type_SdtSDTComandos_SDTComandosItem_properties
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
	[XmlRoot(ElementName="SDTComandos.SDTComandosItem.properties")]
	[XmlType(TypeName="SDTComandos.SDTComandosItem.properties" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtSDTComandos_SDTComandosItem_properties : GxUserType
	{
		public SdtSDTComandos_SDTComandosItem_properties( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTComandos_SDTComandosItem_properties_Payload = "";

			gxTv_SdtSDTComandos_SDTComandosItem_properties_Parameter_id = "";

		}

		public SdtSDTComandos_SDTComandosItem_properties(IGxContext context)
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
			AddObjectProperty("payload", gxTpr_Payload, false);


			AddObjectProperty("parameter_id", gxTpr_Parameter_id, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="payload")]
		[XmlElement(ElementName="payload")]
		public string gxTpr_Payload
		{
			get { 
				return gxTv_SdtSDTComandos_SDTComandosItem_properties_Payload; 
			}
			set { 
				gxTv_SdtSDTComandos_SDTComandosItem_properties_Payload = value;
				SetDirty("Payload");
			}
		}




		[SoapElement(ElementName="parameter_id")]
		[XmlElement(ElementName="parameter_id")]
		public string gxTpr_Parameter_id
		{
			get { 
				return gxTv_SdtSDTComandos_SDTComandosItem_properties_Parameter_id; 
			}
			set { 
				gxTv_SdtSDTComandos_SDTComandosItem_properties_Parameter_id = value;
				SetDirty("Parameter_id");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSDTComandos_SDTComandosItem_properties_Payload = "";
			gxTv_SdtSDTComandos_SDTComandosItem_properties_Parameter_id = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTComandos_SDTComandosItem_properties_Payload;
		 

		protected string gxTv_SdtSDTComandos_SDTComandosItem_properties_Parameter_id;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SDTComandos.SDTComandosItem.properties", Namespace="RastreamentoTCC")]
	public class SdtSDTComandos_SDTComandosItem_properties_RESTInterface : GxGenericCollectionItem<SdtSDTComandos_SDTComandosItem_properties>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTComandos_SDTComandosItem_properties_RESTInterface( ) : base()
		{
		}

		public SdtSDTComandos_SDTComandosItem_properties_RESTInterface( SdtSDTComandos_SDTComandosItem_properties psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="payload", Order=0)]
		public  string gxTpr_Payload
		{
			get { 
				return sdt.gxTpr_Payload;

			}
			set { 
				 sdt.gxTpr_Payload = value;
			}
		}

		[DataMember(Name="parameter_id", Order=1)]
		public  string gxTpr_Parameter_id
		{
			get { 
				return sdt.gxTpr_Parameter_id;

			}
			set { 
				 sdt.gxTpr_Parameter_id = value;
			}
		}


		#endregion

		public SdtSDTComandos_SDTComandosItem_properties sdt
		{
			get { 
				return (SdtSDTComandos_SDTComandosItem_properties)Sdt;
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
				sdt = new SdtSDTComandos_SDTComandosItem_properties() ;
			}
		}
	}
	#endregion
}