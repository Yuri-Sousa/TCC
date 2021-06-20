/*
				   File: type_SdtSecGAMFunctionalitiesToLoad
			Description: SecGAMFunctionalitiesToLoad
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
namespace GeneXus.Programs.wwpbaseobjects
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="SecGAMFunctionalitiesToLoad")]
	[XmlType(TypeName="SecGAMFunctionalitiesToLoad" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtSecGAMFunctionalitiesToLoad : GxUserType
	{
		public SdtSecGAMFunctionalitiesToLoad( )
		{
			/* Constructor for serialization */
			gxTv_SdtSecGAMFunctionalitiesToLoad_Secgamfunctionalitykey = "";

			gxTv_SdtSecGAMFunctionalitiesToLoad_Secgamfunctionalitydsc = "";

		}

		public SdtSecGAMFunctionalitiesToLoad(IGxContext context)
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
			AddObjectProperty("SecGAMFunctionalityKey", gxTpr_Secgamfunctionalitykey, false);


			AddObjectProperty("SecGAMFunctionalityDsc", gxTpr_Secgamfunctionalitydsc, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="SecGAMFunctionalityKey")]
		[XmlElement(ElementName="SecGAMFunctionalityKey")]
		public string gxTpr_Secgamfunctionalitykey
		{
			get { 
				return gxTv_SdtSecGAMFunctionalitiesToLoad_Secgamfunctionalitykey; 
			}
			set { 
				gxTv_SdtSecGAMFunctionalitiesToLoad_Secgamfunctionalitykey = value;
				SetDirty("Secgamfunctionalitykey");
			}
		}




		[SoapElement(ElementName="SecGAMFunctionalityDsc")]
		[XmlElement(ElementName="SecGAMFunctionalityDsc")]
		public string gxTpr_Secgamfunctionalitydsc
		{
			get { 
				return gxTv_SdtSecGAMFunctionalitiesToLoad_Secgamfunctionalitydsc; 
			}
			set { 
				gxTv_SdtSecGAMFunctionalitiesToLoad_Secgamfunctionalitydsc = value;
				SetDirty("Secgamfunctionalitydsc");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSecGAMFunctionalitiesToLoad_Secgamfunctionalitykey = "";
			gxTv_SdtSecGAMFunctionalitiesToLoad_Secgamfunctionalitydsc = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSecGAMFunctionalitiesToLoad_Secgamfunctionalitykey;
		 

		protected string gxTv_SdtSecGAMFunctionalitiesToLoad_Secgamfunctionalitydsc;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SecGAMFunctionalitiesToLoad", Namespace="RastreamentoTCC")]
	public class SdtSecGAMFunctionalitiesToLoad_RESTInterface : GxGenericCollectionItem<SdtSecGAMFunctionalitiesToLoad>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSecGAMFunctionalitiesToLoad_RESTInterface( ) : base()
		{
		}

		public SdtSecGAMFunctionalitiesToLoad_RESTInterface( SdtSecGAMFunctionalitiesToLoad psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="SecGAMFunctionalityKey", Order=0)]
		public  string gxTpr_Secgamfunctionalitykey
		{
			get { 
				return sdt.gxTpr_Secgamfunctionalitykey;

			}
			set { 
				 sdt.gxTpr_Secgamfunctionalitykey = value;
			}
		}

		[DataMember(Name="SecGAMFunctionalityDsc", Order=1)]
		public  string gxTpr_Secgamfunctionalitydsc
		{
			get { 
				return sdt.gxTpr_Secgamfunctionalitydsc;

			}
			set { 
				 sdt.gxTpr_Secgamfunctionalitydsc = value;
			}
		}


		#endregion

		public SdtSecGAMFunctionalitiesToLoad sdt
		{
			get { 
				return (SdtSecGAMFunctionalitiesToLoad)Sdt;
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
				sdt = new SdtSecGAMFunctionalitiesToLoad() ;
			}
		}
	}
	#endregion
}