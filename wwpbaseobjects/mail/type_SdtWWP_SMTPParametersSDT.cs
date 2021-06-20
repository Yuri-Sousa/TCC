/*
				   File: type_SdtWWP_SMTPParametersSDT
			Description: WWP_SMTPParametersSDT
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

using GeneXus.Programs;
using GeneXus.Programs.wwpbaseobjects;
namespace GeneXus.Programs.wwpbaseobjects.mail
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="WWP_SMTPParametersSDT")]
	[XmlType(TypeName="WWP_SMTPParametersSDT" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtWWP_SMTPParametersSDT : GxUserType
	{
		public SdtWWP_SMTPParametersSDT( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWP_SMTPParametersSDT_Host = "";

			gxTv_SdtWWP_SMTPParametersSDT_Username = "";

			gxTv_SdtWWP_SMTPParametersSDT_Password = "";

		}

		public SdtWWP_SMTPParametersSDT(IGxContext context)
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
			AddObjectProperty("Host", gxTpr_Host, false);


			AddObjectProperty("Port", gxTpr_Port, false);


			AddObjectProperty("Username", gxTpr_Username, false);


			AddObjectProperty("Password", gxTpr_Password, false);


			AddObjectProperty("Authentication", gxTpr_Authentication, false);


			AddObjectProperty("Secure", gxTpr_Secure, false);


			AddObjectProperty("Timeout", gxTpr_Timeout, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Host")]
		[XmlElement(ElementName="Host")]
		public string gxTpr_Host
		{
			get { 
				return gxTv_SdtWWP_SMTPParametersSDT_Host; 
			}
			set { 
				gxTv_SdtWWP_SMTPParametersSDT_Host = value;
				SetDirty("Host");
			}
		}




		[SoapElement(ElementName="Port")]
		[XmlElement(ElementName="Port")]
		public short gxTpr_Port
		{
			get { 
				return gxTv_SdtWWP_SMTPParametersSDT_Port; 
			}
			set { 
				gxTv_SdtWWP_SMTPParametersSDT_Port = value;
				SetDirty("Port");
			}
		}




		[SoapElement(ElementName="Username")]
		[XmlElement(ElementName="Username")]
		public string gxTpr_Username
		{
			get { 
				return gxTv_SdtWWP_SMTPParametersSDT_Username; 
			}
			set { 
				gxTv_SdtWWP_SMTPParametersSDT_Username = value;
				SetDirty("Username");
			}
		}




		[SoapElement(ElementName="Password")]
		[XmlElement(ElementName="Password")]
		public string gxTpr_Password
		{
			get { 
				return gxTv_SdtWWP_SMTPParametersSDT_Password; 
			}
			set { 
				gxTv_SdtWWP_SMTPParametersSDT_Password = value;
				SetDirty("Password");
			}
		}




		[SoapElement(ElementName="Authentication")]
		[XmlElement(ElementName="Authentication")]
		public short gxTpr_Authentication
		{
			get { 
				return gxTv_SdtWWP_SMTPParametersSDT_Authentication; 
			}
			set { 
				gxTv_SdtWWP_SMTPParametersSDT_Authentication = value;
				SetDirty("Authentication");
			}
		}




		[SoapElement(ElementName="Secure")]
		[XmlElement(ElementName="Secure")]
		public short gxTpr_Secure
		{
			get { 
				return gxTv_SdtWWP_SMTPParametersSDT_Secure; 
			}
			set { 
				gxTv_SdtWWP_SMTPParametersSDT_Secure = value;
				SetDirty("Secure");
			}
		}




		[SoapElement(ElementName="Timeout")]
		[XmlElement(ElementName="Timeout")]
		public short gxTpr_Timeout
		{
			get { 
				return gxTv_SdtWWP_SMTPParametersSDT_Timeout; 
			}
			set { 
				gxTv_SdtWWP_SMTPParametersSDT_Timeout = value;
				SetDirty("Timeout");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtWWP_SMTPParametersSDT_Host = "";

			gxTv_SdtWWP_SMTPParametersSDT_Username = "";
			gxTv_SdtWWP_SMTPParametersSDT_Password = "";



			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWWP_SMTPParametersSDT_Host;
		 

		protected short gxTv_SdtWWP_SMTPParametersSDT_Port;
		 

		protected string gxTv_SdtWWP_SMTPParametersSDT_Username;
		 

		protected string gxTv_SdtWWP_SMTPParametersSDT_Password;
		 

		protected short gxTv_SdtWWP_SMTPParametersSDT_Authentication;
		 

		protected short gxTv_SdtWWP_SMTPParametersSDT_Secure;
		 

		protected short gxTv_SdtWWP_SMTPParametersSDT_Timeout;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"WWP_SMTPParametersSDT", Namespace="RastreamentoTCC")]
	public class SdtWWP_SMTPParametersSDT_RESTInterface : GxGenericCollectionItem<SdtWWP_SMTPParametersSDT>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWP_SMTPParametersSDT_RESTInterface( ) : base()
		{
		}

		public SdtWWP_SMTPParametersSDT_RESTInterface( SdtWWP_SMTPParametersSDT psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="Host", Order=0)]
		public  string gxTpr_Host
		{
			get { 
				return sdt.gxTpr_Host;

			}
			set { 
				 sdt.gxTpr_Host = value;
			}
		}

		[DataMember(Name="Port", Order=1)]
		public short gxTpr_Port
		{
			get { 
				return sdt.gxTpr_Port;

			}
			set { 
				sdt.gxTpr_Port = value;
			}
		}

		[DataMember(Name="Username", Order=2)]
		public  string gxTpr_Username
		{
			get { 
				return sdt.gxTpr_Username;

			}
			set { 
				 sdt.gxTpr_Username = value;
			}
		}

		[DataMember(Name="Password", Order=3)]
		public  string gxTpr_Password
		{
			get { 
				return sdt.gxTpr_Password;

			}
			set { 
				 sdt.gxTpr_Password = value;
			}
		}

		[DataMember(Name="Authentication", Order=4)]
		public short gxTpr_Authentication
		{
			get { 
				return sdt.gxTpr_Authentication;

			}
			set { 
				sdt.gxTpr_Authentication = value;
			}
		}

		[DataMember(Name="Secure", Order=5)]
		public short gxTpr_Secure
		{
			get { 
				return sdt.gxTpr_Secure;

			}
			set { 
				sdt.gxTpr_Secure = value;
			}
		}

		[DataMember(Name="Timeout", Order=6)]
		public short gxTpr_Timeout
		{
			get { 
				return sdt.gxTpr_Timeout;

			}
			set { 
				sdt.gxTpr_Timeout = value;
			}
		}


		#endregion

		public SdtWWP_SMTPParametersSDT sdt
		{
			get { 
				return (SdtWWP_SMTPParametersSDT)Sdt;
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
				sdt = new SdtWWP_SMTPParametersSDT() ;
			}
		}
	}
	#endregion
}