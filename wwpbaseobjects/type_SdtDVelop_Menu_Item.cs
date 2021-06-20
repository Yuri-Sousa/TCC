/*
				   File: type_SdtDVelop_Menu_Item
			Description: DVelop_Menu
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
	[XmlRoot(ElementName="Item")]
	[XmlType(TypeName="Item" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtDVelop_Menu_Item : GxUserType
	{
		public SdtDVelop_Menu_Item( )
		{
			/* Constructor for serialization */
			gxTv_SdtDVelop_Menu_Item_Id = "";

			gxTv_SdtDVelop_Menu_Item_Tooltip = "";

			gxTv_SdtDVelop_Menu_Item_Link = "";

			gxTv_SdtDVelop_Menu_Item_Linktarget = "";

			gxTv_SdtDVelop_Menu_Item_Iconclass = "";

			gxTv_SdtDVelop_Menu_Item_Caption = "";

			gxTv_SdtDVelop_Menu_Item_Authorizationkey = "";

			gxTv_SdtDVelop_Menu_Item_Additionaldata = "";

			gxTv_SdtDVelop_Menu_Item_Submenuimage = "";
			gxTv_SdtDVelop_Menu_Item_Submenuimage_gxi = "";
		}

		public SdtDVelop_Menu_Item(IGxContext context)
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
			AddObjectProperty("id", gxTpr_Id, false);


			AddObjectProperty("tooltip", gxTpr_Tooltip, false);


			AddObjectProperty("link", gxTpr_Link, false);


			AddObjectProperty("linkTarget", gxTpr_Linktarget, false);


			AddObjectProperty("iconClass", gxTpr_Iconclass, false);


			AddObjectProperty("caption", gxTpr_Caption, false);


			AddObjectProperty("authorizationKey", gxTpr_Authorizationkey, false);


			AddObjectProperty("additionalData", gxTpr_Additionaldata, false);


			AddObjectProperty("submenuImage", gxTpr_Submenuimage, false);
			AddObjectProperty("submenuImage_GXI", gxTpr_Submenuimage_gxi, false);


			if (gxTv_SdtDVelop_Menu_Item_Subitems != null)
			{
				AddObjectProperty("subItems", gxTv_SdtDVelop_Menu_Item_Subitems, false);  
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="id")]
		[XmlElement(ElementName="id")]
		public string gxTpr_Id
		{
			get { 
				return gxTv_SdtDVelop_Menu_Item_Id; 
			}
			set { 
				gxTv_SdtDVelop_Menu_Item_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="tooltip")]
		[XmlElement(ElementName="tooltip")]
		public string gxTpr_Tooltip
		{
			get { 
				return gxTv_SdtDVelop_Menu_Item_Tooltip; 
			}
			set { 
				gxTv_SdtDVelop_Menu_Item_Tooltip = value;
				SetDirty("Tooltip");
			}
		}




		[SoapElement(ElementName="link")]
		[XmlElement(ElementName="link")]
		public string gxTpr_Link
		{
			get { 
				return gxTv_SdtDVelop_Menu_Item_Link; 
			}
			set { 
				gxTv_SdtDVelop_Menu_Item_Link = value;
				SetDirty("Link");
			}
		}




		[SoapElement(ElementName="linkTarget")]
		[XmlElement(ElementName="linkTarget")]
		public string gxTpr_Linktarget
		{
			get { 
				return gxTv_SdtDVelop_Menu_Item_Linktarget; 
			}
			set { 
				gxTv_SdtDVelop_Menu_Item_Linktarget = value;
				SetDirty("Linktarget");
			}
		}




		[SoapElement(ElementName="iconClass")]
		[XmlElement(ElementName="iconClass")]
		public string gxTpr_Iconclass
		{
			get { 
				return gxTv_SdtDVelop_Menu_Item_Iconclass; 
			}
			set { 
				gxTv_SdtDVelop_Menu_Item_Iconclass = value;
				SetDirty("Iconclass");
			}
		}




		[SoapElement(ElementName="caption")]
		[XmlElement(ElementName="caption")]
		public string gxTpr_Caption
		{
			get { 
				return gxTv_SdtDVelop_Menu_Item_Caption; 
			}
			set { 
				gxTv_SdtDVelop_Menu_Item_Caption = value;
				SetDirty("Caption");
			}
		}




		[SoapElement(ElementName="authorizationKey")]
		[XmlElement(ElementName="authorizationKey")]
		public string gxTpr_Authorizationkey
		{
			get { 
				return gxTv_SdtDVelop_Menu_Item_Authorizationkey; 
			}
			set { 
				gxTv_SdtDVelop_Menu_Item_Authorizationkey = value;
				SetDirty("Authorizationkey");
			}
		}




		[SoapElement(ElementName="additionalData")]
		[XmlElement(ElementName="additionalData")]
		public string gxTpr_Additionaldata
		{
			get { 
				return gxTv_SdtDVelop_Menu_Item_Additionaldata; 
			}
			set { 
				gxTv_SdtDVelop_Menu_Item_Additionaldata = value;
				SetDirty("Additionaldata");
			}
		}




		[SoapElement(ElementName="submenuImage")]
		[XmlElement(ElementName="submenuImage")]
		[GxUpload()]

		public string gxTpr_Submenuimage
		{
			get { 
				return gxTv_SdtDVelop_Menu_Item_Submenuimage; 
			}
			set { 
				gxTv_SdtDVelop_Menu_Item_Submenuimage = value;
				SetDirty("Submenuimage");
			}
		}


		[SoapElement(ElementName="submenuImage_GXI" )]
		[XmlElement(ElementName="submenuImage_GXI" )]
		public string gxTpr_Submenuimage_gxi
		{
			get {
				return gxTv_SdtDVelop_Menu_Item_Submenuimage_gxi ;
			}
			set {
				gxTv_SdtDVelop_Menu_Item_Submenuimage_gxi = value;
				SetDirty("Submenuimage_gxi");
			}
		}

		[SoapElement(ElementName="subItems" )]
		[XmlArray(ElementName="subItems"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> gxTpr_Subitems_GXBaseCollection
		{
			get {
				if ( gxTv_SdtDVelop_Menu_Item_Subitems == null )
				{
					gxTv_SdtDVelop_Menu_Item_Subitems = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "DVelop_Menu", "");
				}
				return gxTv_SdtDVelop_Menu_Item_Subitems;
			}
			set {
				if ( gxTv_SdtDVelop_Menu_Item_Subitems == null )
				{
					gxTv_SdtDVelop_Menu_Item_Subitems = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "DVelop_Menu", "");
				}
				gxTv_SdtDVelop_Menu_Item_Subitems_N = 0;

				gxTv_SdtDVelop_Menu_Item_Subitems = value;
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> gxTpr_Subitems
		{
			get {
				if ( gxTv_SdtDVelop_Menu_Item_Subitems == null )
				{
					gxTv_SdtDVelop_Menu_Item_Subitems = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "DVelop_Menu", "");
				}
				gxTv_SdtDVelop_Menu_Item_Subitems_N = 0;

				return gxTv_SdtDVelop_Menu_Item_Subitems ;
			}
			set {
				gxTv_SdtDVelop_Menu_Item_Subitems_N = 0;

				gxTv_SdtDVelop_Menu_Item_Subitems = value;
				SetDirty("Subitems");
			}
		}

		public void gxTv_SdtDVelop_Menu_Item_Subitems_SetNull()
		{
			gxTv_SdtDVelop_Menu_Item_Subitems_N = 1;

			gxTv_SdtDVelop_Menu_Item_Subitems = null;
			return  ;
		}

		public bool gxTv_SdtDVelop_Menu_Item_Subitems_IsNull()
		{
			if (gxTv_SdtDVelop_Menu_Item_Subitems == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Subitems_GXBaseCollection_Json()
		{
				return gxTv_SdtDVelop_Menu_Item_Subitems != null && gxTv_SdtDVelop_Menu_Item_Subitems.Count > 0;

		}


		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtDVelop_Menu_Item_Id = "";
			gxTv_SdtDVelop_Menu_Item_Tooltip = "";
			gxTv_SdtDVelop_Menu_Item_Link = "";
			gxTv_SdtDVelop_Menu_Item_Linktarget = "";
			gxTv_SdtDVelop_Menu_Item_Iconclass = "";
			gxTv_SdtDVelop_Menu_Item_Caption = "";
			gxTv_SdtDVelop_Menu_Item_Authorizationkey = "";
			gxTv_SdtDVelop_Menu_Item_Additionaldata = "";
			gxTv_SdtDVelop_Menu_Item_Submenuimage = "";gxTv_SdtDVelop_Menu_Item_Submenuimage_gxi = "";

			gxTv_SdtDVelop_Menu_Item_Subitems_N = 1;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtDVelop_Menu_Item_Id;
		 

		protected string gxTv_SdtDVelop_Menu_Item_Tooltip;
		 

		protected string gxTv_SdtDVelop_Menu_Item_Link;
		 

		protected string gxTv_SdtDVelop_Menu_Item_Linktarget;
		 

		protected string gxTv_SdtDVelop_Menu_Item_Iconclass;
		 

		protected string gxTv_SdtDVelop_Menu_Item_Caption;
		 

		protected string gxTv_SdtDVelop_Menu_Item_Authorizationkey;
		 

		protected string gxTv_SdtDVelop_Menu_Item_Additionaldata;
		 
		protected string gxTv_SdtDVelop_Menu_Item_Submenuimage_gxi;
		protected string gxTv_SdtDVelop_Menu_Item_Submenuimage;
		 
		protected short gxTv_SdtDVelop_Menu_Item_Subitems_N;
		protected GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> gxTv_SdtDVelop_Menu_Item_Subitems = null;  


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"Item", Namespace="RastreamentoTCC")]
	public class SdtDVelop_Menu_Item_RESTInterface : GxGenericCollectionItem<SdtDVelop_Menu_Item>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtDVelop_Menu_Item_RESTInterface( ) : base()
		{
		}

		public SdtDVelop_Menu_Item_RESTInterface( SdtDVelop_Menu_Item psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="id", Order=0)]
		public  string gxTpr_Id
		{
			get { 
				return sdt.gxTpr_Id;

			}
			set { 
				 sdt.gxTpr_Id = value;
			}
		}

		[DataMember(Name="tooltip", Order=1)]
		public  string gxTpr_Tooltip
		{
			get { 
				return sdt.gxTpr_Tooltip;

			}
			set { 
				 sdt.gxTpr_Tooltip = value;
			}
		}

		[DataMember(Name="link", Order=2)]
		public  string gxTpr_Link
		{
			get { 
				return sdt.gxTpr_Link;

			}
			set { 
				 sdt.gxTpr_Link = value;
			}
		}

		[DataMember(Name="linkTarget", Order=3)]
		public  string gxTpr_Linktarget
		{
			get { 
				return sdt.gxTpr_Linktarget;

			}
			set { 
				 sdt.gxTpr_Linktarget = value;
			}
		}

		[DataMember(Name="iconClass", Order=4)]
		public  string gxTpr_Iconclass
		{
			get { 
				return sdt.gxTpr_Iconclass;

			}
			set { 
				 sdt.gxTpr_Iconclass = value;
			}
		}

		[DataMember(Name="caption", Order=5)]
		public  string gxTpr_Caption
		{
			get { 
				return sdt.gxTpr_Caption;

			}
			set { 
				 sdt.gxTpr_Caption = value;
			}
		}

		[DataMember(Name="authorizationKey", Order=6)]
		public  string gxTpr_Authorizationkey
		{
			get { 
				return sdt.gxTpr_Authorizationkey;

			}
			set { 
				 sdt.gxTpr_Authorizationkey = value;
			}
		}

		[DataMember(Name="additionalData", Order=7)]
		public  string gxTpr_Additionaldata
		{
			get { 
				return sdt.gxTpr_Additionaldata;

			}
			set { 
				 sdt.gxTpr_Additionaldata = value;
			}
		}

		[DataMember(Name="submenuImage", Order=8)]
		[GxUpload()]
		public  string gxTpr_Submenuimage
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Submenuimage)) ? PathUtil.RelativePath( sdt.gxTpr_Submenuimage) : StringUtil.RTrim( sdt.gxTpr_Submenuimage_gxi));

			}
			set { 
				 sdt.gxTpr_Submenuimage = value;
			}
		}

		[DataMember(Name="subItems", Order=9, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item_RESTInterface> gxTpr_Subitems
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Subitems_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item_RESTInterface>(sdt.gxTpr_Subitems);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Subitems);
			}
		}


		#endregion

		public SdtDVelop_Menu_Item sdt
		{
			get { 
				return (SdtDVelop_Menu_Item)Sdt;
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
				sdt = new SdtDVelop_Menu_Item() ;
			}
		}
	}
	#endregion
}