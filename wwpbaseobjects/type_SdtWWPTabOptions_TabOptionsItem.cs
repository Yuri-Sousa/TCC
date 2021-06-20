/*
				   File: type_SdtWWPTabOptions_TabOptionsItem
			Description: WWPTabOptions
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
	[XmlRoot(ElementName="TabOptionsItem")]
	[XmlType(TypeName="TabOptionsItem" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtWWPTabOptions_TabOptionsItem : GxUserType
	{
		public SdtWWPTabOptions_TabOptionsItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWPTabOptions_TabOptionsItem_Code = "";

			gxTv_SdtWWPTabOptions_TabOptionsItem_Description = "";

			gxTv_SdtWWPTabOptions_TabOptionsItem_Link = "";

			gxTv_SdtWWPTabOptions_TabOptionsItem_Webcomponent = "";

		}

		public SdtWWPTabOptions_TabOptionsItem(IGxContext context)
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
			AddObjectProperty("Code", gxTpr_Code, false);


			AddObjectProperty("Description", gxTpr_Description, false);


			AddObjectProperty("Link", gxTpr_Link, false);


			AddObjectProperty("WebComponent", gxTpr_Webcomponent, false);


			AddObjectProperty("IncludeInPanel", gxTpr_Includeinpanel, false);


			AddObjectProperty("CollapsedByDefault", gxTpr_Collapsedbydefault, false);


			AddObjectProperty("Collapsable", gxTpr_Collapsable, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Code")]
		[XmlElement(ElementName="Code")]
		public string gxTpr_Code
		{
			get { 
				return gxTv_SdtWWPTabOptions_TabOptionsItem_Code; 
			}
			set { 
				gxTv_SdtWWPTabOptions_TabOptionsItem_Code = value;
				SetDirty("Code");
			}
		}




		[SoapElement(ElementName="Description")]
		[XmlElement(ElementName="Description")]
		public string gxTpr_Description
		{
			get { 
				return gxTv_SdtWWPTabOptions_TabOptionsItem_Description; 
			}
			set { 
				gxTv_SdtWWPTabOptions_TabOptionsItem_Description = value;
				SetDirty("Description");
			}
		}




		[SoapElement(ElementName="Link")]
		[XmlElement(ElementName="Link")]
		public string gxTpr_Link
		{
			get { 
				return gxTv_SdtWWPTabOptions_TabOptionsItem_Link; 
			}
			set { 
				gxTv_SdtWWPTabOptions_TabOptionsItem_Link = value;
				SetDirty("Link");
			}
		}




		[SoapElement(ElementName="WebComponent")]
		[XmlElement(ElementName="WebComponent")]
		public string gxTpr_Webcomponent
		{
			get { 
				return gxTv_SdtWWPTabOptions_TabOptionsItem_Webcomponent; 
			}
			set { 
				gxTv_SdtWWPTabOptions_TabOptionsItem_Webcomponent = value;
				SetDirty("Webcomponent");
			}
		}




		[SoapElement(ElementName="IncludeInPanel")]
		[XmlElement(ElementName="IncludeInPanel")]
		public short gxTpr_Includeinpanel
		{
			get { 
				return gxTv_SdtWWPTabOptions_TabOptionsItem_Includeinpanel; 
			}
			set { 
				gxTv_SdtWWPTabOptions_TabOptionsItem_Includeinpanel = value;
				SetDirty("Includeinpanel");
			}
		}




		[SoapElement(ElementName="CollapsedByDefault")]
		[XmlElement(ElementName="CollapsedByDefault")]
		public bool gxTpr_Collapsedbydefault
		{
			get { 
				return gxTv_SdtWWPTabOptions_TabOptionsItem_Collapsedbydefault; 
			}
			set { 
				gxTv_SdtWWPTabOptions_TabOptionsItem_Collapsedbydefault = value;
				SetDirty("Collapsedbydefault");
			}
		}




		[SoapElement(ElementName="Collapsable")]
		[XmlElement(ElementName="Collapsable")]
		public bool gxTpr_Collapsable
		{
			get { 
				return gxTv_SdtWWPTabOptions_TabOptionsItem_Collapsable; 
			}
			set { 
				gxTv_SdtWWPTabOptions_TabOptionsItem_Collapsable = value;
				SetDirty("Collapsable");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtWWPTabOptions_TabOptionsItem_Code = "";
			gxTv_SdtWWPTabOptions_TabOptionsItem_Description = "";
			gxTv_SdtWWPTabOptions_TabOptionsItem_Link = "";
			gxTv_SdtWWPTabOptions_TabOptionsItem_Webcomponent = "";



			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWWPTabOptions_TabOptionsItem_Code;
		 

		protected string gxTv_SdtWWPTabOptions_TabOptionsItem_Description;
		 

		protected string gxTv_SdtWWPTabOptions_TabOptionsItem_Link;
		 

		protected string gxTv_SdtWWPTabOptions_TabOptionsItem_Webcomponent;
		 

		protected short gxTv_SdtWWPTabOptions_TabOptionsItem_Includeinpanel;
		 

		protected bool gxTv_SdtWWPTabOptions_TabOptionsItem_Collapsedbydefault;
		 

		protected bool gxTv_SdtWWPTabOptions_TabOptionsItem_Collapsable;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"TabOptionsItem", Namespace="RastreamentoTCC")]
	public class SdtWWPTabOptions_TabOptionsItem_RESTInterface : GxGenericCollectionItem<SdtWWPTabOptions_TabOptionsItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWPTabOptions_TabOptionsItem_RESTInterface( ) : base()
		{
		}

		public SdtWWPTabOptions_TabOptionsItem_RESTInterface( SdtWWPTabOptions_TabOptionsItem psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="Code", Order=0)]
		public  string gxTpr_Code
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Code);

			}
			set { 
				 sdt.gxTpr_Code = value;
			}
		}

		[DataMember(Name="Description", Order=1)]
		public  string gxTpr_Description
		{
			get { 
				return sdt.gxTpr_Description;

			}
			set { 
				 sdt.gxTpr_Description = value;
			}
		}

		[DataMember(Name="Link", Order=2)]
		public  string gxTpr_Link
		{
			get { 
				return sdt.gxTpr_Link;

			}
			set { 
				 sdt.gxTpr_Link = value;
			}
		}

		[DataMember(Name="WebComponent", Order=3)]
		public  string gxTpr_Webcomponent
		{
			get { 
				return sdt.gxTpr_Webcomponent;

			}
			set { 
				 sdt.gxTpr_Webcomponent = value;
			}
		}

		[DataMember(Name="IncludeInPanel", Order=4)]
		public short gxTpr_Includeinpanel
		{
			get { 
				return sdt.gxTpr_Includeinpanel;

			}
			set { 
				sdt.gxTpr_Includeinpanel = value;
			}
		}

		[DataMember(Name="CollapsedByDefault", Order=5)]
		public bool gxTpr_Collapsedbydefault
		{
			get { 
				return sdt.gxTpr_Collapsedbydefault;

			}
			set { 
				sdt.gxTpr_Collapsedbydefault = value;
			}
		}

		[DataMember(Name="Collapsable", Order=6)]
		public bool gxTpr_Collapsable
		{
			get { 
				return sdt.gxTpr_Collapsable;

			}
			set { 
				sdt.gxTpr_Collapsable = value;
			}
		}


		#endregion

		public SdtWWPTabOptions_TabOptionsItem sdt
		{
			get { 
				return (SdtWWPTabOptions_TabOptionsItem)Sdt;
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
				sdt = new SdtWWPTabOptions_TabOptionsItem() ;
			}
		}
	}
	#endregion
}