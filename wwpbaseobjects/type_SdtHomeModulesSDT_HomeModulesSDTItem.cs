/*
				   File: type_SdtHomeModulesSDT_HomeModulesSDTItem
			Description: HomeModulesSDT
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
	[XmlRoot(ElementName="HomeModulesSDTItem")]
	[XmlType(TypeName="HomeModulesSDTItem" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtHomeModulesSDT_HomeModulesSDTItem : GxUserType
	{
		public SdtHomeModulesSDT_HomeModulesSDTItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optiontitle = "";

			gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optiondescription = "";

			gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optioniconthemeclass = "";

			gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optionbackgroundimage = "";
			gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optionbackgroundimage_gxi = "";
			gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optionwclink = "";

		}

		public SdtHomeModulesSDT_HomeModulesSDTItem(IGxContext context)
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
			AddObjectProperty("OptionTitle", gxTpr_Optiontitle, false);


			AddObjectProperty("OptionDescription", gxTpr_Optiondescription, false);


			AddObjectProperty("OptionIconThemeClass", gxTpr_Optioniconthemeclass, false);


			AddObjectProperty("OptionType", gxTpr_Optiontype, false);


			AddObjectProperty("OptionBackgroundImage", gxTpr_Optionbackgroundimage, false);
			AddObjectProperty("OptionBackgroundImage_GXI", gxTpr_Optionbackgroundimage_gxi, false);



			AddObjectProperty("OptionSize", gxTpr_Optionsize, false);


			AddObjectProperty("OptionProgressValue", gxTpr_Optionprogressvalue, false);


			AddObjectProperty("OptionWCLink", gxTpr_Optionwclink, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="OptionTitle")]
		[XmlElement(ElementName="OptionTitle")]
		public string gxTpr_Optiontitle
		{
			get { 
				return gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optiontitle; 
			}
			set { 
				gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optiontitle = value;
				SetDirty("Optiontitle");
			}
		}




		[SoapElement(ElementName="OptionDescription")]
		[XmlElement(ElementName="OptionDescription")]
		public string gxTpr_Optiondescription
		{
			get { 
				return gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optiondescription; 
			}
			set { 
				gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optiondescription = value;
				SetDirty("Optiondescription");
			}
		}




		[SoapElement(ElementName="OptionIconThemeClass")]
		[XmlElement(ElementName="OptionIconThemeClass")]
		public string gxTpr_Optioniconthemeclass
		{
			get { 
				return gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optioniconthemeclass; 
			}
			set { 
				gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optioniconthemeclass = value;
				SetDirty("Optioniconthemeclass");
			}
		}




		[SoapElement(ElementName="OptionType")]
		[XmlElement(ElementName="OptionType")]
		public short gxTpr_Optiontype
		{
			get { 
				return gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optiontype; 
			}
			set { 
				gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optiontype = value;
				SetDirty("Optiontype");
			}
		}




		[SoapElement(ElementName="OptionBackgroundImage")]
		[XmlElement(ElementName="OptionBackgroundImage")]
		[GxUpload()]

		public string gxTpr_Optionbackgroundimage
		{
			get { 
				return gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optionbackgroundimage; 
			}
			set { 
				gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optionbackgroundimage = value;
				SetDirty("Optionbackgroundimage");
			}
		}


		[SoapElement(ElementName="OptionBackgroundImage_GXI" )]
		[XmlElement(ElementName="OptionBackgroundImage_GXI" )]
		public string gxTpr_Optionbackgroundimage_gxi
		{
			get {
				return gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optionbackgroundimage_gxi ;
			}
			set {
				gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optionbackgroundimage_gxi = value;
				SetDirty("Optionbackgroundimage_gxi");
			}
		}

		[SoapElement(ElementName="OptionSize")]
		[XmlElement(ElementName="OptionSize")]
		public short gxTpr_Optionsize
		{
			get { 
				return gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optionsize; 
			}
			set { 
				gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optionsize = value;
				SetDirty("Optionsize");
			}
		}




		[SoapElement(ElementName="OptionProgressValue")]
		[XmlElement(ElementName="OptionProgressValue")]
		public short gxTpr_Optionprogressvalue
		{
			get { 
				return gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optionprogressvalue; 
			}
			set { 
				gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optionprogressvalue = value;
				SetDirty("Optionprogressvalue");
			}
		}




		[SoapElement(ElementName="OptionWCLink")]
		[XmlElement(ElementName="OptionWCLink")]
		public string gxTpr_Optionwclink
		{
			get { 
				return gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optionwclink; 
			}
			set { 
				gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optionwclink = value;
				SetDirty("Optionwclink");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optiontitle = "";
			gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optiondescription = "";
			gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optioniconthemeclass = "";

			gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optionbackgroundimage = "";gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optionbackgroundimage_gxi = "";


			gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optionwclink = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optiontitle;
		 

		protected string gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optiondescription;
		 

		protected string gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optioniconthemeclass;
		 

		protected short gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optiontype;
		 
		protected string gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optionbackgroundimage_gxi;
		protected string gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optionbackgroundimage;
		 

		protected short gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optionsize;
		 

		protected short gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optionprogressvalue;
		 

		protected string gxTv_SdtHomeModulesSDT_HomeModulesSDTItem_Optionwclink;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"HomeModulesSDTItem", Namespace="RastreamentoTCC")]
	public class SdtHomeModulesSDT_HomeModulesSDTItem_RESTInterface : GxGenericCollectionItem<SdtHomeModulesSDT_HomeModulesSDTItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtHomeModulesSDT_HomeModulesSDTItem_RESTInterface( ) : base()
		{
		}

		public SdtHomeModulesSDT_HomeModulesSDTItem_RESTInterface( SdtHomeModulesSDT_HomeModulesSDTItem psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="OptionTitle", Order=0)]
		public  string gxTpr_Optiontitle
		{
			get { 
				return sdt.gxTpr_Optiontitle;

			}
			set { 
				 sdt.gxTpr_Optiontitle = value;
			}
		}

		[DataMember(Name="OptionDescription", Order=1)]
		public  string gxTpr_Optiondescription
		{
			get { 
				return sdt.gxTpr_Optiondescription;

			}
			set { 
				 sdt.gxTpr_Optiondescription = value;
			}
		}

		[DataMember(Name="OptionIconThemeClass", Order=2)]
		public  string gxTpr_Optioniconthemeclass
		{
			get { 
				return sdt.gxTpr_Optioniconthemeclass;

			}
			set { 
				 sdt.gxTpr_Optioniconthemeclass = value;
			}
		}

		[DataMember(Name="OptionType", Order=3)]
		public short gxTpr_Optiontype
		{
			get { 
				return sdt.gxTpr_Optiontype;

			}
			set { 
				sdt.gxTpr_Optiontype = value;
			}
		}

		[DataMember(Name="OptionBackgroundImage", Order=4)]
		[GxUpload()]
		public  string gxTpr_Optionbackgroundimage
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Optionbackgroundimage)) ? PathUtil.RelativePath( sdt.gxTpr_Optionbackgroundimage) : StringUtil.RTrim( sdt.gxTpr_Optionbackgroundimage_gxi));

			}
			set { 
				 sdt.gxTpr_Optionbackgroundimage = value;
			}
		}

		[DataMember(Name="OptionSize", Order=5)]
		public short gxTpr_Optionsize
		{
			get { 
				return sdt.gxTpr_Optionsize;

			}
			set { 
				sdt.gxTpr_Optionsize = value;
			}
		}

		[DataMember(Name="OptionProgressValue", Order=6)]
		public short gxTpr_Optionprogressvalue
		{
			get { 
				return sdt.gxTpr_Optionprogressvalue;

			}
			set { 
				sdt.gxTpr_Optionprogressvalue = value;
			}
		}

		[DataMember(Name="OptionWCLink", Order=7)]
		public  string gxTpr_Optionwclink
		{
			get { 
				return sdt.gxTpr_Optionwclink;

			}
			set { 
				 sdt.gxTpr_Optionwclink = value;
			}
		}


		#endregion

		public SdtHomeModulesSDT_HomeModulesSDTItem sdt
		{
			get { 
				return (SdtHomeModulesSDT_HomeModulesSDTItem)Sdt;
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
				sdt = new SdtHomeModulesSDT_HomeModulesSDTItem() ;
			}
		}
	}
	#endregion
}