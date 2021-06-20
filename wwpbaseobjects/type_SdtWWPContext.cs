/*
				   File: type_SdtWWPContext
			Description: WWPContext
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
	[XmlRoot(ElementName="WWPContext")]
	[XmlType(TypeName="WWPContext" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtWWPContext : GxUserType
	{
		public SdtWWPContext( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWPContext_Username = "";

		}

		public SdtWWPContext(IGxContext context)
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
			AddObjectProperty("UserId", gxTpr_Userid, false);


			AddObjectProperty("UserName", gxTpr_Username, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="UserId")]
		[XmlElement(ElementName="UserId")]
		public short gxTpr_Userid
		{
			get { 
				return gxTv_SdtWWPContext_Userid; 
			}
			set { 
				gxTv_SdtWWPContext_Userid = value;
				SetDirty("Userid");
			}
		}




		[SoapElement(ElementName="UserName")]
		[XmlElement(ElementName="UserName")]
		public string gxTpr_Username
		{
			get { 
				return gxTv_SdtWWPContext_Username; 
			}
			set { 
				gxTv_SdtWWPContext_Username = value;
				SetDirty("Username");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtWWPContext_Username = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtWWPContext_Userid;
		 

		protected string gxTv_SdtWWPContext_Username;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"WWPContext", Namespace="RastreamentoTCC")]
	public class SdtWWPContext_RESTInterface : GxGenericCollectionItem<SdtWWPContext>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWPContext_RESTInterface( ) : base()
		{
		}

		public SdtWWPContext_RESTInterface( SdtWWPContext psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="UserId", Order=0)]
		public short gxTpr_Userid
		{
			get { 
				return sdt.gxTpr_Userid;

			}
			set { 
				sdt.gxTpr_Userid = value;
			}
		}

		[DataMember(Name="UserName", Order=1)]
		public  string gxTpr_Username
		{
			get { 
				return sdt.gxTpr_Username;

			}
			set { 
				 sdt.gxTpr_Username = value;
			}
		}


		#endregion

		public SdtWWPContext sdt
		{
			get { 
				return (SdtWWPContext)Sdt;
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
				sdt = new SdtWWPContext() ;
			}
		}
	}
	#endregion
}