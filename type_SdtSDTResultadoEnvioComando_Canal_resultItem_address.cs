/*
				   File: type_SdtSDTResultadoEnvioComando_Canal_resultItem_address
			Description: address
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
	[XmlRoot(ElementName="SDTResultadoEnvioComando_Canal.resultItem.address")]
	[XmlType(TypeName="SDTResultadoEnvioComando_Canal.resultItem.address" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtSDTResultadoEnvioComando_Canal_resultItem_address : GxUserType
	{
		public SdtSDTResultadoEnvioComando_Canal_resultItem_address( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_address_Ident = "";

			gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_address_Type = "";

		}

		public SdtSDTResultadoEnvioComando_Canal_resultItem_address(IGxContext context)
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
			AddObjectProperty("ident", gxTpr_Ident, false);


			AddObjectProperty("type", gxTpr_Type, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ident")]
		[XmlElement(ElementName="ident")]
		public string gxTpr_Ident
		{
			get { 
				return gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_address_Ident; 
			}
			set { 
				gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_address_Ident = value;
				SetDirty("Ident");
			}
		}




		[SoapElement(ElementName="type")]
		[XmlElement(ElementName="type")]
		public string gxTpr_Type
		{
			get { 
				return gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_address_Type; 
			}
			set { 
				gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_address_Type = value;
				SetDirty("Type");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_address_Ident = "";
			gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_address_Type = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_address_Ident;
		 

		protected string gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_address_Type;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SDTResultadoEnvioComando_Canal.resultItem.address", Namespace="RastreamentoTCC")]
	public class SdtSDTResultadoEnvioComando_Canal_resultItem_address_RESTInterface : GxGenericCollectionItem<SdtSDTResultadoEnvioComando_Canal_resultItem_address>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTResultadoEnvioComando_Canal_resultItem_address_RESTInterface( ) : base()
		{
		}

		public SdtSDTResultadoEnvioComando_Canal_resultItem_address_RESTInterface( SdtSDTResultadoEnvioComando_Canal_resultItem_address psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="ident", Order=0)]
		public  string gxTpr_Ident
		{
			get { 
				return sdt.gxTpr_Ident;

			}
			set { 
				 sdt.gxTpr_Ident = value;
			}
		}

		[DataMember(Name="type", Order=1)]
		public  string gxTpr_Type
		{
			get { 
				return sdt.gxTpr_Type;

			}
			set { 
				 sdt.gxTpr_Type = value;
			}
		}


		#endregion

		public SdtSDTResultadoEnvioComando_Canal_resultItem_address sdt
		{
			get { 
				return (SdtSDTResultadoEnvioComando_Canal_resultItem_address)Sdt;
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
				sdt = new SdtSDTResultadoEnvioComando_Canal_resultItem_address() ;
			}
		}
	}
	#endregion
}