/*
				   File: type_SdtLinkList_LinkItem
			Description: LinkList
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
	[XmlRoot(ElementName="LinkItem")]
	[XmlType(TypeName="LinkItem" , Namespace="GeneXus" )]
	[Serializable]
	public class SdtLinkList_LinkItem : GxUserType
	{
		public SdtLinkList_LinkItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtLinkList_LinkItem_Caption = "";

			gxTv_SdtLinkList_LinkItem_Url = "";

		}

		public SdtLinkList_LinkItem(IGxContext context)
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
			AddObjectProperty("Caption", gxTpr_Caption, false);


			AddObjectProperty("URL", gxTpr_Url, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Caption")]
		[XmlElement(ElementName="Caption")]
		public string gxTpr_Caption
		{
			get { 
				return gxTv_SdtLinkList_LinkItem_Caption; 
			}
			set { 
				gxTv_SdtLinkList_LinkItem_Caption = value;
				SetDirty("Caption");
			}
		}




		[SoapElement(ElementName="URL")]
		[XmlElement(ElementName="URL")]
		public string gxTpr_Url
		{
			get { 
				return gxTv_SdtLinkList_LinkItem_Url; 
			}
			set { 
				gxTv_SdtLinkList_LinkItem_Url = value;
				SetDirty("Url");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtLinkList_LinkItem_Caption = "";
			gxTv_SdtLinkList_LinkItem_Url = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtLinkList_LinkItem_Caption;
		 

		protected string gxTv_SdtLinkList_LinkItem_Url;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"LinkItem", Namespace="GeneXus")]
	public class SdtLinkList_LinkItem_RESTInterface : GxGenericCollectionItem<SdtLinkList_LinkItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtLinkList_LinkItem_RESTInterface( ) : base()
		{
		}

		public SdtLinkList_LinkItem_RESTInterface( SdtLinkList_LinkItem psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="Caption", Order=0)]
		public  string gxTpr_Caption
		{
			get { 
				return sdt.gxTpr_Caption;

			}
			set { 
				 sdt.gxTpr_Caption = value;
			}
		}

		[DataMember(Name="URL", Order=1)]
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

		public SdtLinkList_LinkItem sdt
		{
			get { 
				return (SdtLinkList_LinkItem)Sdt;
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
				sdt = new SdtLinkList_LinkItem() ;
			}
		}
	}
	#endregion
}