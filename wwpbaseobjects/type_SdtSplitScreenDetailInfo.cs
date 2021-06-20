/*
				   File: type_SdtSplitScreenDetailInfo
			Description: SplitScreenDetailInfo
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
	[XmlRoot(ElementName="SplitScreenDetailInfo")]
	[XmlType(TypeName="SplitScreenDetailInfo" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtSplitScreenDetailInfo : GxUserType
	{
		public SdtSplitScreenDetailInfo( )
		{
			/* Constructor for serialization */
			gxTv_SdtSplitScreenDetailInfo_Link = "";

			gxTv_SdtSplitScreenDetailInfo_Title = "";

			gxTv_SdtSplitScreenDetailInfo_Keys = "";

		}

		public SdtSplitScreenDetailInfo(IGxContext context)
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
			AddObjectProperty("Link", gxTpr_Link, false);


			AddObjectProperty("Title", gxTpr_Title, false);


			AddObjectProperty("Keys", gxTpr_Keys, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Link")]
		[XmlElement(ElementName="Link")]
		public string gxTpr_Link
		{
			get { 
				return gxTv_SdtSplitScreenDetailInfo_Link; 
			}
			set { 
				gxTv_SdtSplitScreenDetailInfo_Link = value;
				SetDirty("Link");
			}
		}




		[SoapElement(ElementName="Title")]
		[XmlElement(ElementName="Title")]
		public string gxTpr_Title
		{
			get { 
				return gxTv_SdtSplitScreenDetailInfo_Title; 
			}
			set { 
				gxTv_SdtSplitScreenDetailInfo_Title = value;
				SetDirty("Title");
			}
		}




		[SoapElement(ElementName="Keys")]
		[XmlElement(ElementName="Keys")]
		public string gxTpr_Keys
		{
			get { 
				return gxTv_SdtSplitScreenDetailInfo_Keys; 
			}
			set { 
				gxTv_SdtSplitScreenDetailInfo_Keys = value;
				SetDirty("Keys");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSplitScreenDetailInfo_Link = "";
			gxTv_SdtSplitScreenDetailInfo_Title = "";
			gxTv_SdtSplitScreenDetailInfo_Keys = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSplitScreenDetailInfo_Link;
		 

		protected string gxTv_SdtSplitScreenDetailInfo_Title;
		 

		protected string gxTv_SdtSplitScreenDetailInfo_Keys;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SplitScreenDetailInfo", Namespace="RastreamentoTCC")]
	public class SdtSplitScreenDetailInfo_RESTInterface : GxGenericCollectionItem<SdtSplitScreenDetailInfo>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSplitScreenDetailInfo_RESTInterface( ) : base()
		{
		}

		public SdtSplitScreenDetailInfo_RESTInterface( SdtSplitScreenDetailInfo psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="Link", Order=0)]
		public  string gxTpr_Link
		{
			get { 
				return sdt.gxTpr_Link;

			}
			set { 
				 sdt.gxTpr_Link = value;
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

		[DataMember(Name="Keys", Order=2)]
		public  string gxTpr_Keys
		{
			get { 
				return sdt.gxTpr_Keys;

			}
			set { 
				 sdt.gxTpr_Keys = value;
			}
		}


		#endregion

		public SdtSplitScreenDetailInfo sdt
		{
			get { 
				return (SdtSplitScreenDetailInfo)Sdt;
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
				sdt = new SdtSplitScreenDetailInfo() ;
			}
		}
	}
	#endregion
}