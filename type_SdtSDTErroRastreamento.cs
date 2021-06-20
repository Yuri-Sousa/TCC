/*
				   File: type_SdtSDTErroRastreamento
			Description: SDTErroRastreamento
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
	[XmlRoot(ElementName="SDTErroRastreamento")]
	[XmlType(TypeName="SDTErroRastreamento" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtSDTErroRastreamento : GxUserType
	{
		public SdtSDTErroRastreamento( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTErroRastreamento_Msgerro = "";

		}

		public SdtSDTErroRastreamento(IGxContext context)
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
			AddObjectProperty("MSGErro", gxTpr_Msgerro, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="MSGErro")]
		[XmlElement(ElementName="MSGErro")]
		public string gxTpr_Msgerro
		{
			get { 
				return gxTv_SdtSDTErroRastreamento_Msgerro; 
			}
			set { 
				gxTv_SdtSDTErroRastreamento_Msgerro = value;
				SetDirty("Msgerro");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSDTErroRastreamento_Msgerro = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTErroRastreamento_Msgerro;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SDTErroRastreamento", Namespace="RastreamentoTCC")]
	public class SdtSDTErroRastreamento_RESTInterface : GxGenericCollectionItem<SdtSDTErroRastreamento>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTErroRastreamento_RESTInterface( ) : base()
		{
		}

		public SdtSDTErroRastreamento_RESTInterface( SdtSDTErroRastreamento psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="MSGErro", Order=0)]
		public  string gxTpr_Msgerro
		{
			get { 
				return sdt.gxTpr_Msgerro;

			}
			set { 
				 sdt.gxTpr_Msgerro = value;
			}
		}


		#endregion

		public SdtSDTErroRastreamento sdt
		{
			get { 
				return (SdtSDTErroRastreamento)Sdt;
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
				sdt = new SdtSDTErroRastreamento() ;
			}
		}
	}
	#endregion
}