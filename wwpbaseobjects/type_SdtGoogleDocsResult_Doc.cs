/*
				   File: type_SdtGoogleDocsResult_Doc
			Description: Docs
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
	[XmlRoot(ElementName="GoogleDocsResult.Doc")]
	[XmlType(TypeName="GoogleDocsResult.Doc" , Namespace="DVelop.Extensions.GoogleDocs" )]
	[Serializable]
	public class SdtGoogleDocsResult_Doc : GxUserType
	{
		public SdtGoogleDocsResult_Doc( )
		{
			/* Constructor for serialization */
			gxTv_SdtGoogleDocsResult_Doc_Type = "";

			gxTv_SdtGoogleDocsResult_Doc_Title = "";

			gxTv_SdtGoogleDocsResult_Doc_Url = "";

		}

		public SdtGoogleDocsResult_Doc(IGxContext context)
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
			AddObjectProperty("Type", gxTpr_Type, false);


			AddObjectProperty("Title", gxTpr_Title, false);


			AddObjectProperty("URL", gxTpr_Url, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Type")]
		[XmlElement(ElementName="Type")]
		public string gxTpr_Type
		{
			get { 
				return gxTv_SdtGoogleDocsResult_Doc_Type; 
			}
			set { 
				gxTv_SdtGoogleDocsResult_Doc_Type = value;
				SetDirty("Type");
			}
		}




		[SoapElement(ElementName="Title")]
		[XmlElement(ElementName="Title")]
		public string gxTpr_Title
		{
			get { 
				return gxTv_SdtGoogleDocsResult_Doc_Title; 
			}
			set { 
				gxTv_SdtGoogleDocsResult_Doc_Title = value;
				SetDirty("Title");
			}
		}




		[SoapElement(ElementName="URL")]
		[XmlElement(ElementName="URL")]
		public string gxTpr_Url
		{
			get { 
				return gxTv_SdtGoogleDocsResult_Doc_Url; 
			}
			set { 
				gxTv_SdtGoogleDocsResult_Doc_Url = value;
				SetDirty("Url");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtGoogleDocsResult_Doc_Type = "";
			gxTv_SdtGoogleDocsResult_Doc_Title = "";
			gxTv_SdtGoogleDocsResult_Doc_Url = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtGoogleDocsResult_Doc_Type;
		 

		protected string gxTv_SdtGoogleDocsResult_Doc_Title;
		 

		protected string gxTv_SdtGoogleDocsResult_Doc_Url;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"GoogleDocsResult.Doc", Namespace="DVelop.Extensions.GoogleDocs")]
	public class SdtGoogleDocsResult_Doc_RESTInterface : GxGenericCollectionItem<SdtGoogleDocsResult_Doc>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtGoogleDocsResult_Doc_RESTInterface( ) : base()
		{
		}

		public SdtGoogleDocsResult_Doc_RESTInterface( SdtGoogleDocsResult_Doc psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="Type", Order=0)]
		public  string gxTpr_Type
		{
			get { 
				return sdt.gxTpr_Type;

			}
			set { 
				 sdt.gxTpr_Type = value;
			}
		}

		[DataMember(Name="Title", Order=1)]
		public  string gxTpr_Title
		{
			get { 
				return sdt.gxTpr_Title;

			}
			set { 
				 sdt.gxTpr_Title = value;
			}
		}

		[DataMember(Name="URL", Order=2)]
		public  string gxTpr_Url
		{
			get { 
				return sdt.gxTpr_Url;

			}
			set { 
				 sdt.gxTpr_Url = value;
			}
		}


		#endregion

		public SdtGoogleDocsResult_Doc sdt
		{
			get { 
				return (SdtGoogleDocsResult_Doc)Sdt;
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
				sdt = new SdtGoogleDocsResult_Doc() ;
			}
		}
	}
	#endregion
}