/*
				   File: type_SdtDVB_SDTDropDownOptionsData_Item
			Description: DVB_SDTDropDownOptionsData
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
	[XmlType(TypeName="Item" , Namespace="" )]
	[Serializable]
	public class SdtDVB_SDTDropDownOptionsData_Item : GxUserType
	{
		public SdtDVB_SDTDropDownOptionsData_Item( )
		{
			/* Constructor for serialization */
			gxTv_SdtDVB_SDTDropDownOptionsData_Item_Icon = "";
			gxTv_SdtDVB_SDTDropDownOptionsData_Item_Icon_gxi = "";
			gxTv_SdtDVB_SDTDropDownOptionsData_Item_Fonticon = "";

			gxTv_SdtDVB_SDTDropDownOptionsData_Item_Title = "";

			gxTv_SdtDVB_SDTDropDownOptionsData_Item_Tooltip = "";

			gxTv_SdtDVB_SDTDropDownOptionsData_Item_Link = "";

			gxTv_SdtDVB_SDTDropDownOptionsData_Item_Eventkey = "";

			gxTv_SdtDVB_SDTDropDownOptionsData_Item_Jsonclickevent = "";

			gxTv_SdtDVB_SDTDropDownOptionsData_Item_Themeclass = "";

		}

		public SdtDVB_SDTDropDownOptionsData_Item(IGxContext context)
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
			AddObjectProperty("Icon", gxTpr_Icon, false);
			AddObjectProperty("Icon_GXI", gxTpr_Icon_gxi, false);



			AddObjectProperty("FontIcon", gxTpr_Fonticon, false);


			AddObjectProperty("Title", gxTpr_Title, false);


			AddObjectProperty("Tooltip", gxTpr_Tooltip, false);


			AddObjectProperty("Link", gxTpr_Link, false);


			AddObjectProperty("EventKey", gxTpr_Eventkey, false);


			AddObjectProperty("IsDivider", gxTpr_Isdivider, false);


			AddObjectProperty("JSonclickEvent", gxTpr_Jsonclickevent, false);


			AddObjectProperty("ThemeClass", gxTpr_Themeclass, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Icon")]
		[XmlElement(ElementName="Icon")]
		[GxUpload()]

		public string gxTpr_Icon
		{
			get { 
				return gxTv_SdtDVB_SDTDropDownOptionsData_Item_Icon; 
			}
			set { 
				gxTv_SdtDVB_SDTDropDownOptionsData_Item_Icon = value;
				SetDirty("Icon");
			}
		}


		[SoapElement(ElementName="Icon_GXI" )]
		[XmlElement(ElementName="Icon_GXI" )]
		public string gxTpr_Icon_gxi
		{
			get {
				return gxTv_SdtDVB_SDTDropDownOptionsData_Item_Icon_gxi ;
			}
			set {
				gxTv_SdtDVB_SDTDropDownOptionsData_Item_Icon_gxi = value;
				SetDirty("Icon_gxi");
			}
		}

		[SoapElement(ElementName="FontIcon")]
		[XmlElement(ElementName="FontIcon")]
		public string gxTpr_Fonticon
		{
			get { 
				return gxTv_SdtDVB_SDTDropDownOptionsData_Item_Fonticon; 
			}
			set { 
				gxTv_SdtDVB_SDTDropDownOptionsData_Item_Fonticon = value;
				SetDirty("Fonticon");
			}
		}




		[SoapElement(ElementName="Title")]
		[XmlElement(ElementName="Title")]
		public string gxTpr_Title
		{
			get { 
				return gxTv_SdtDVB_SDTDropDownOptionsData_Item_Title; 
			}
			set { 
				gxTv_SdtDVB_SDTDropDownOptionsData_Item_Title = value;
				SetDirty("Title");
			}
		}




		[SoapElement(ElementName="Tooltip")]
		[XmlElement(ElementName="Tooltip")]
		public string gxTpr_Tooltip
		{
			get { 
				return gxTv_SdtDVB_SDTDropDownOptionsData_Item_Tooltip; 
			}
			set { 
				gxTv_SdtDVB_SDTDropDownOptionsData_Item_Tooltip = value;
				SetDirty("Tooltip");
			}
		}




		[SoapElement(ElementName="Link")]
		[XmlElement(ElementName="Link")]
		public string gxTpr_Link
		{
			get { 
				return gxTv_SdtDVB_SDTDropDownOptionsData_Item_Link; 
			}
			set { 
				gxTv_SdtDVB_SDTDropDownOptionsData_Item_Link = value;
				SetDirty("Link");
			}
		}




		[SoapElement(ElementName="EventKey")]
		[XmlElement(ElementName="EventKey")]
		public string gxTpr_Eventkey
		{
			get { 
				return gxTv_SdtDVB_SDTDropDownOptionsData_Item_Eventkey; 
			}
			set { 
				gxTv_SdtDVB_SDTDropDownOptionsData_Item_Eventkey = value;
				SetDirty("Eventkey");
			}
		}




		[SoapElement(ElementName="IsDivider")]
		[XmlElement(ElementName="IsDivider")]
		public bool gxTpr_Isdivider
		{
			get { 
				return gxTv_SdtDVB_SDTDropDownOptionsData_Item_Isdivider; 
			}
			set { 
				gxTv_SdtDVB_SDTDropDownOptionsData_Item_Isdivider = value;
				SetDirty("Isdivider");
			}
		}




		[SoapElement(ElementName="JSonclickEvent")]
		[XmlElement(ElementName="JSonclickEvent")]
		public string gxTpr_Jsonclickevent
		{
			get { 
				return gxTv_SdtDVB_SDTDropDownOptionsData_Item_Jsonclickevent; 
			}
			set { 
				gxTv_SdtDVB_SDTDropDownOptionsData_Item_Jsonclickevent = value;
				SetDirty("Jsonclickevent");
			}
		}




		[SoapElement(ElementName="ThemeClass")]
		[XmlElement(ElementName="ThemeClass")]
		public string gxTpr_Themeclass
		{
			get { 
				return gxTv_SdtDVB_SDTDropDownOptionsData_Item_Themeclass; 
			}
			set { 
				gxTv_SdtDVB_SDTDropDownOptionsData_Item_Themeclass = value;
				SetDirty("Themeclass");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtDVB_SDTDropDownOptionsData_Item_Icon = "";gxTv_SdtDVB_SDTDropDownOptionsData_Item_Icon_gxi = "";
			gxTv_SdtDVB_SDTDropDownOptionsData_Item_Fonticon = "";
			gxTv_SdtDVB_SDTDropDownOptionsData_Item_Title = "";
			gxTv_SdtDVB_SDTDropDownOptionsData_Item_Tooltip = "";
			gxTv_SdtDVB_SDTDropDownOptionsData_Item_Link = "";
			gxTv_SdtDVB_SDTDropDownOptionsData_Item_Eventkey = "";

			gxTv_SdtDVB_SDTDropDownOptionsData_Item_Jsonclickevent = "";
			gxTv_SdtDVB_SDTDropDownOptionsData_Item_Themeclass = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtDVB_SDTDropDownOptionsData_Item_Icon_gxi;
		protected string gxTv_SdtDVB_SDTDropDownOptionsData_Item_Icon;
		 

		protected string gxTv_SdtDVB_SDTDropDownOptionsData_Item_Fonticon;
		 

		protected string gxTv_SdtDVB_SDTDropDownOptionsData_Item_Title;
		 

		protected string gxTv_SdtDVB_SDTDropDownOptionsData_Item_Tooltip;
		 

		protected string gxTv_SdtDVB_SDTDropDownOptionsData_Item_Link;
		 

		protected string gxTv_SdtDVB_SDTDropDownOptionsData_Item_Eventkey;
		 

		protected bool gxTv_SdtDVB_SDTDropDownOptionsData_Item_Isdivider;
		 

		protected string gxTv_SdtDVB_SDTDropDownOptionsData_Item_Jsonclickevent;
		 

		protected string gxTv_SdtDVB_SDTDropDownOptionsData_Item_Themeclass;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"Item", Namespace="")]
	public class SdtDVB_SDTDropDownOptionsData_Item_RESTInterface : GxGenericCollectionItem<SdtDVB_SDTDropDownOptionsData_Item>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtDVB_SDTDropDownOptionsData_Item_RESTInterface( ) : base()
		{
		}

		public SdtDVB_SDTDropDownOptionsData_Item_RESTInterface( SdtDVB_SDTDropDownOptionsData_Item psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="Icon", Order=0)]
		[GxUpload()]
		public  string gxTpr_Icon
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Icon)) ? PathUtil.RelativePath( sdt.gxTpr_Icon) : StringUtil.RTrim( sdt.gxTpr_Icon_gxi));

			}
			set { 
				 sdt.gxTpr_Icon = value;
			}
		}

		[DataMember(Name="FontIcon", Order=1)]
		public  string gxTpr_Fonticon
		{
			get { 
				return sdt.gxTpr_Fonticon;

			}
			set { 
				 sdt.gxTpr_Fonticon = value;
			}
		}

		[DataMember(Name="Title", Order=2)]
		public  string gxTpr_Title
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Title);

			}
			set { 
				 sdt.gxTpr_Title = value;
			}
		}

		[DataMember(Name="Tooltip", Order=3)]
		public  string gxTpr_Tooltip
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tooltip);

			}
			set { 
				 sdt.gxTpr_Tooltip = value;
			}
		}

		[DataMember(Name="Link", Order=4)]
		public  string gxTpr_Link
		{
			get { 
				return sdt.gxTpr_Link;

			}
			set { 
				 sdt.gxTpr_Link = value;
			}
		}

		[DataMember(Name="EventKey", Order=5)]
		public  string gxTpr_Eventkey
		{
			get { 
				return sdt.gxTpr_Eventkey;

			}
			set { 
				 sdt.gxTpr_Eventkey = value;
			}
		}

		[DataMember(Name="IsDivider", Order=6)]
		public bool gxTpr_Isdivider
		{
			get { 
				return sdt.gxTpr_Isdivider;

			}
			set { 
				sdt.gxTpr_Isdivider = value;
			}
		}

		[DataMember(Name="JSonclickEvent", Order=7)]
		public  string gxTpr_Jsonclickevent
		{
			get { 
				return sdt.gxTpr_Jsonclickevent;

			}
			set { 
				 sdt.gxTpr_Jsonclickevent = value;
			}
		}

		[DataMember(Name="ThemeClass", Order=8)]
		public  string gxTpr_Themeclass
		{
			get { 
				return sdt.gxTpr_Themeclass;

			}
			set { 
				 sdt.gxTpr_Themeclass = value;
			}
		}


		#endregion

		public SdtDVB_SDTDropDownOptionsData_Item sdt
		{
			get { 
				return (SdtDVB_SDTDropDownOptionsData_Item)Sdt;
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
				sdt = new SdtDVB_SDTDropDownOptionsData_Item() ;
			}
		}
	}
	#endregion
}