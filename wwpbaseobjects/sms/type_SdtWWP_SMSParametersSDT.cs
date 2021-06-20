/*
				   File: type_SdtWWP_SMSParametersSDT
			Description: WWP_SMSParametersSDT
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
namespace GeneXus.Programs.wwpbaseobjects.sms
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="WWP_SMSParametersSDT")]
	[XmlType(TypeName="WWP_SMSParametersSDT" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtWWP_SMSParametersSDT : GxUserType
	{
		public SdtWWP_SMSParametersSDT( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWP_SMSParametersSDT_Serviceplanid = "";

			gxTv_SdtWWP_SMSParametersSDT_Token = "";

			gxTv_SdtWWP_SMSParametersSDT_Applicationkey = "";

			gxTv_SdtWWP_SMSParametersSDT_Applicationsecret = "";

			gxTv_SdtWWP_SMSParametersSDT_Defaultsender = "";

		}

		public SdtWWP_SMSParametersSDT(IGxContext context)
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
			AddObjectProperty("ServicePlanId", gxTpr_Serviceplanid, false);


			AddObjectProperty("Token", gxTpr_Token, false);


			AddObjectProperty("ApplicationKey", gxTpr_Applicationkey, false);


			AddObjectProperty("ApplicationSecret", gxTpr_Applicationsecret, false);


			AddObjectProperty("DefaultSender", gxTpr_Defaultsender, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ServicePlanId")]
		[XmlElement(ElementName="ServicePlanId")]
		public string gxTpr_Serviceplanid
		{
			get { 
				return gxTv_SdtWWP_SMSParametersSDT_Serviceplanid; 
			}
			set { 
				gxTv_SdtWWP_SMSParametersSDT_Serviceplanid = value;
				SetDirty("Serviceplanid");
			}
		}




		[SoapElement(ElementName="Token")]
		[XmlElement(ElementName="Token")]
		public string gxTpr_Token
		{
			get { 
				return gxTv_SdtWWP_SMSParametersSDT_Token; 
			}
			set { 
				gxTv_SdtWWP_SMSParametersSDT_Token = value;
				SetDirty("Token");
			}
		}




		[SoapElement(ElementName="ApplicationKey")]
		[XmlElement(ElementName="ApplicationKey")]
		public string gxTpr_Applicationkey
		{
			get { 
				return gxTv_SdtWWP_SMSParametersSDT_Applicationkey; 
			}
			set { 
				gxTv_SdtWWP_SMSParametersSDT_Applicationkey = value;
				SetDirty("Applicationkey");
			}
		}




		[SoapElement(ElementName="ApplicationSecret")]
		[XmlElement(ElementName="ApplicationSecret")]
		public string gxTpr_Applicationsecret
		{
			get { 
				return gxTv_SdtWWP_SMSParametersSDT_Applicationsecret; 
			}
			set { 
				gxTv_SdtWWP_SMSParametersSDT_Applicationsecret = value;
				SetDirty("Applicationsecret");
			}
		}




		[SoapElement(ElementName="DefaultSender")]
		[XmlElement(ElementName="DefaultSender")]
		public string gxTpr_Defaultsender
		{
			get { 
				return gxTv_SdtWWP_SMSParametersSDT_Defaultsender; 
			}
			set { 
				gxTv_SdtWWP_SMSParametersSDT_Defaultsender = value;
				SetDirty("Defaultsender");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtWWP_SMSParametersSDT_Serviceplanid = "";
			gxTv_SdtWWP_SMSParametersSDT_Token = "";
			gxTv_SdtWWP_SMSParametersSDT_Applicationkey = "";
			gxTv_SdtWWP_SMSParametersSDT_Applicationsecret = "";
			gxTv_SdtWWP_SMSParametersSDT_Defaultsender = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWWP_SMSParametersSDT_Serviceplanid;
		 

		protected string gxTv_SdtWWP_SMSParametersSDT_Token;
		 

		protected string gxTv_SdtWWP_SMSParametersSDT_Applicationkey;
		 

		protected string gxTv_SdtWWP_SMSParametersSDT_Applicationsecret;
		 

		protected string gxTv_SdtWWP_SMSParametersSDT_Defaultsender;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"WWP_SMSParametersSDT", Namespace="RastreamentoTCC")]
	public class SdtWWP_SMSParametersSDT_RESTInterface : GxGenericCollectionItem<SdtWWP_SMSParametersSDT>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWP_SMSParametersSDT_RESTInterface( ) : base()
		{
		}

		public SdtWWP_SMSParametersSDT_RESTInterface( SdtWWP_SMSParametersSDT psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="ServicePlanId", Order=0)]
		public  string gxTpr_Serviceplanid
		{
			get { 
				return sdt.gxTpr_Serviceplanid;

			}
			set { 
				 sdt.gxTpr_Serviceplanid = value;
			}
		}

		[DataMember(Name="Token", Order=1)]
		public  string gxTpr_Token
		{
			get { 
				return sdt.gxTpr_Token;

			}
			set { 
				 sdt.gxTpr_Token = value;
			}
		}

		[DataMember(Name="ApplicationKey", Order=2)]
		public  string gxTpr_Applicationkey
		{
			get { 
				return sdt.gxTpr_Applicationkey;

			}
			set { 
				 sdt.gxTpr_Applicationkey = value;
			}
		}

		[DataMember(Name="ApplicationSecret", Order=3)]
		public  string gxTpr_Applicationsecret
		{
			get { 
				return sdt.gxTpr_Applicationsecret;

			}
			set { 
				 sdt.gxTpr_Applicationsecret = value;
			}
		}

		[DataMember(Name="DefaultSender", Order=4)]
		public  string gxTpr_Defaultsender
		{
			get { 
				return sdt.gxTpr_Defaultsender;

			}
			set { 
				 sdt.gxTpr_Defaultsender = value;
			}
		}


		#endregion

		public SdtWWP_SMSParametersSDT sdt
		{
			get { 
				return (SdtWWP_SMSParametersSDT)Sdt;
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
				sdt = new SdtWWP_SMSParametersSDT() ;
			}
		}
	}
	#endregion
}