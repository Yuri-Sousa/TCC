/*
				   File: type_SdtSDTComandos_SDTComandosItem_address
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
	[XmlRoot(ElementName="SDTComandos.SDTComandosItem.address")]
	[XmlType(TypeName="SDTComandos.SDTComandosItem.address" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtSDTComandos_SDTComandosItem_address : GxUserType
	{
		public SdtSDTComandos_SDTComandosItem_address( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTComandos_SDTComandosItem_address_Ident = "";

			gxTv_SdtSDTComandos_SDTComandosItem_address_Type = "";

		}

		public SdtSDTComandos_SDTComandosItem_address(IGxContext context)
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
				return gxTv_SdtSDTComandos_SDTComandosItem_address_Ident; 
			}
			set { 
				gxTv_SdtSDTComandos_SDTComandosItem_address_Ident = value;
				SetDirty("Ident");
			}
		}




		[SoapElement(ElementName="type")]
		[XmlElement(ElementName="type")]
		public string gxTpr_Type
		{
			get { 
				return gxTv_SdtSDTComandos_SDTComandosItem_address_Type; 
			}
			set { 
				gxTv_SdtSDTComandos_SDTComandosItem_address_Type = value;
				SetDirty("Type");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSDTComandos_SDTComandosItem_address_Ident = "";
			gxTv_SdtSDTComandos_SDTComandosItem_address_Type = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTComandos_SDTComandosItem_address_Ident;
		 

		protected string gxTv_SdtSDTComandos_SDTComandosItem_address_Type;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SDTComandos.SDTComandosItem.address", Namespace="RastreamentoTCC")]
	public class SdtSDTComandos_SDTComandosItem_address_RESTInterface : GxGenericCollectionItem<SdtSDTComandos_SDTComandosItem_address>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTComandos_SDTComandosItem_address_RESTInterface( ) : base()
		{
		}

		public SdtSDTComandos_SDTComandosItem_address_RESTInterface( SdtSDTComandos_SDTComandosItem_address psdt ) : base(psdt)
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

		public SdtSDTComandos_SDTComandosItem_address sdt
		{
			get { 
				return (SdtSDTComandos_SDTComandosItem_address)Sdt;
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
				sdt = new SdtSDTComandos_SDTComandosItem_address() ;
			}
		}
	}
	#endregion
}