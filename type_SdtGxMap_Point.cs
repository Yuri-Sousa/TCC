/*
				   File: type_SdtGxMap_Point
			Description: Points
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
	[XmlRoot(ElementName="GxMap.Point")]
	[XmlType(TypeName="GxMap.Point" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtGxMap_Point : GxUserType
	{
		public SdtGxMap_Point( )
		{
			/* Constructor for serialization */
			gxTv_SdtGxMap_Point_Pointlat = "";

			gxTv_SdtGxMap_Point_Pointlong = "";

			gxTv_SdtGxMap_Point_Pointicon = "";

			gxTv_SdtGxMap_Point_Pointinfowinhtml = "";

			gxTv_SdtGxMap_Point_Pointstreet = "";

			gxTv_SdtGxMap_Point_Pointstreetnumber = "";

			gxTv_SdtGxMap_Point_Pointcrossstreet = "";

			gxTv_SdtGxMap_Point_Pointinfowintit = "";

			gxTv_SdtGxMap_Point_Pointinfowindesc = "";

			gxTv_SdtGxMap_Point_Pointinfowinlink = "";

			gxTv_SdtGxMap_Point_Pointinfowinlinkdsc = "";

			gxTv_SdtGxMap_Point_Pointinfowinimg = "";

		}

		public SdtGxMap_Point(IGxContext context)
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
			AddObjectProperty("PointLat", gxTpr_Pointlat, false);


			AddObjectProperty("PointLong", gxTpr_Pointlong, false);


			AddObjectProperty("PointIcon", gxTpr_Pointicon, false);


			AddObjectProperty("PointDraggable", gxTpr_Pointdraggable, false);


			AddObjectProperty("PointFlat", gxTpr_Pointflat, false);


			AddObjectProperty("PointClickeable", gxTpr_Pointclickeable, false);


			AddObjectProperty("PointDeletable", gxTpr_Pointdeletable, false);


			AddObjectProperty("PointVisible", gxTpr_Pointvisible, false);


			AddObjectProperty("PointInfowinHtml", gxTpr_Pointinfowinhtml, false);


			AddObjectProperty("PointStreet", gxTpr_Pointstreet, false);


			AddObjectProperty("PointStreetNumber", gxTpr_Pointstreetnumber, false);


			AddObjectProperty("PointCrossStreet", gxTpr_Pointcrossstreet, false);


			AddObjectProperty("PointInfowinTit", gxTpr_Pointinfowintit, false);


			AddObjectProperty("PointInfowinDesc", gxTpr_Pointinfowindesc, false);


			AddObjectProperty("PointInfowinLink", gxTpr_Pointinfowinlink, false);


			AddObjectProperty("PointInfowinLinkDsc", gxTpr_Pointinfowinlinkdsc, false);


			AddObjectProperty("PointInfowinImg", gxTpr_Pointinfowinimg, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PointLat")]
		[XmlElement(ElementName="PointLat")]
		public string gxTpr_Pointlat
		{
			get { 
				return gxTv_SdtGxMap_Point_Pointlat; 
			}
			set { 
				gxTv_SdtGxMap_Point_Pointlat = value;
				SetDirty("Pointlat");
			}
		}




		[SoapElement(ElementName="PointLong")]
		[XmlElement(ElementName="PointLong")]
		public string gxTpr_Pointlong
		{
			get { 
				return gxTv_SdtGxMap_Point_Pointlong; 
			}
			set { 
				gxTv_SdtGxMap_Point_Pointlong = value;
				SetDirty("Pointlong");
			}
		}




		[SoapElement(ElementName="PointIcon")]
		[XmlElement(ElementName="PointIcon")]
		public string gxTpr_Pointicon
		{
			get { 
				return gxTv_SdtGxMap_Point_Pointicon; 
			}
			set { 
				gxTv_SdtGxMap_Point_Pointicon = value;
				SetDirty("Pointicon");
			}
		}




		[SoapElement(ElementName="PointDraggable")]
		[XmlElement(ElementName="PointDraggable")]
		public bool gxTpr_Pointdraggable
		{
			get { 
				return gxTv_SdtGxMap_Point_Pointdraggable; 
			}
			set { 
				gxTv_SdtGxMap_Point_Pointdraggable = value;
				SetDirty("Pointdraggable");
			}
		}




		[SoapElement(ElementName="PointFlat")]
		[XmlElement(ElementName="PointFlat")]
		public bool gxTpr_Pointflat
		{
			get { 
				return gxTv_SdtGxMap_Point_Pointflat; 
			}
			set { 
				gxTv_SdtGxMap_Point_Pointflat = value;
				SetDirty("Pointflat");
			}
		}




		[SoapElement(ElementName="PointClickeable")]
		[XmlElement(ElementName="PointClickeable")]
		public bool gxTpr_Pointclickeable
		{
			get { 
				return gxTv_SdtGxMap_Point_Pointclickeable; 
			}
			set { 
				gxTv_SdtGxMap_Point_Pointclickeable = value;
				SetDirty("Pointclickeable");
			}
		}




		[SoapElement(ElementName="PointDeletable")]
		[XmlElement(ElementName="PointDeletable")]
		public bool gxTpr_Pointdeletable
		{
			get { 
				return gxTv_SdtGxMap_Point_Pointdeletable; 
			}
			set { 
				gxTv_SdtGxMap_Point_Pointdeletable = value;
				SetDirty("Pointdeletable");
			}
		}




		[SoapElement(ElementName="PointVisible")]
		[XmlElement(ElementName="PointVisible")]
		public bool gxTpr_Pointvisible
		{
			get { 
				return gxTv_SdtGxMap_Point_Pointvisible; 
			}
			set { 
				gxTv_SdtGxMap_Point_Pointvisible = value;
				SetDirty("Pointvisible");
			}
		}




		[SoapElement(ElementName="PointInfowinHtml")]
		[XmlElement(ElementName="PointInfowinHtml")]
		public string gxTpr_Pointinfowinhtml
		{
			get { 
				return gxTv_SdtGxMap_Point_Pointinfowinhtml; 
			}
			set { 
				gxTv_SdtGxMap_Point_Pointinfowinhtml = value;
				SetDirty("Pointinfowinhtml");
			}
		}




		[SoapElement(ElementName="PointStreet")]
		[XmlElement(ElementName="PointStreet")]
		public string gxTpr_Pointstreet
		{
			get { 
				return gxTv_SdtGxMap_Point_Pointstreet; 
			}
			set { 
				gxTv_SdtGxMap_Point_Pointstreet = value;
				SetDirty("Pointstreet");
			}
		}




		[SoapElement(ElementName="PointStreetNumber")]
		[XmlElement(ElementName="PointStreetNumber")]
		public string gxTpr_Pointstreetnumber
		{
			get { 
				return gxTv_SdtGxMap_Point_Pointstreetnumber; 
			}
			set { 
				gxTv_SdtGxMap_Point_Pointstreetnumber = value;
				SetDirty("Pointstreetnumber");
			}
		}




		[SoapElement(ElementName="PointCrossStreet")]
		[XmlElement(ElementName="PointCrossStreet")]
		public string gxTpr_Pointcrossstreet
		{
			get { 
				return gxTv_SdtGxMap_Point_Pointcrossstreet; 
			}
			set { 
				gxTv_SdtGxMap_Point_Pointcrossstreet = value;
				SetDirty("Pointcrossstreet");
			}
		}




		[SoapElement(ElementName="PointInfowinTit")]
		[XmlElement(ElementName="PointInfowinTit")]
		public string gxTpr_Pointinfowintit
		{
			get { 
				return gxTv_SdtGxMap_Point_Pointinfowintit; 
			}
			set { 
				gxTv_SdtGxMap_Point_Pointinfowintit = value;
				SetDirty("Pointinfowintit");
			}
		}




		[SoapElement(ElementName="PointInfowinDesc")]
		[XmlElement(ElementName="PointInfowinDesc")]
		public string gxTpr_Pointinfowindesc
		{
			get { 
				return gxTv_SdtGxMap_Point_Pointinfowindesc; 
			}
			set { 
				gxTv_SdtGxMap_Point_Pointinfowindesc = value;
				SetDirty("Pointinfowindesc");
			}
		}




		[SoapElement(ElementName="PointInfowinLink")]
		[XmlElement(ElementName="PointInfowinLink")]
		public string gxTpr_Pointinfowinlink
		{
			get { 
				return gxTv_SdtGxMap_Point_Pointinfowinlink; 
			}
			set { 
				gxTv_SdtGxMap_Point_Pointinfowinlink = value;
				SetDirty("Pointinfowinlink");
			}
		}




		[SoapElement(ElementName="PointInfowinLinkDsc")]
		[XmlElement(ElementName="PointInfowinLinkDsc")]
		public string gxTpr_Pointinfowinlinkdsc
		{
			get { 
				return gxTv_SdtGxMap_Point_Pointinfowinlinkdsc; 
			}
			set { 
				gxTv_SdtGxMap_Point_Pointinfowinlinkdsc = value;
				SetDirty("Pointinfowinlinkdsc");
			}
		}




		[SoapElement(ElementName="PointInfowinImg")]
		[XmlElement(ElementName="PointInfowinImg")]
		public string gxTpr_Pointinfowinimg
		{
			get { 
				return gxTv_SdtGxMap_Point_Pointinfowinimg; 
			}
			set { 
				gxTv_SdtGxMap_Point_Pointinfowinimg = value;
				SetDirty("Pointinfowinimg");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtGxMap_Point_Pointlat = "";
			gxTv_SdtGxMap_Point_Pointlong = "";
			gxTv_SdtGxMap_Point_Pointicon = "";
			gxTv_SdtGxMap_Point_Pointdraggable = false;
			gxTv_SdtGxMap_Point_Pointflat = false;
			gxTv_SdtGxMap_Point_Pointclickeable = true;

			gxTv_SdtGxMap_Point_Pointvisible = true;
			gxTv_SdtGxMap_Point_Pointinfowinhtml = "";
			gxTv_SdtGxMap_Point_Pointstreet = "";
			gxTv_SdtGxMap_Point_Pointstreetnumber = "";
			gxTv_SdtGxMap_Point_Pointcrossstreet = "";
			gxTv_SdtGxMap_Point_Pointinfowintit = "";
			gxTv_SdtGxMap_Point_Pointinfowindesc = "";
			gxTv_SdtGxMap_Point_Pointinfowinlink = "";
			gxTv_SdtGxMap_Point_Pointinfowinlinkdsc = "";
			gxTv_SdtGxMap_Point_Pointinfowinimg = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtGxMap_Point_Pointlat;
		 

		protected string gxTv_SdtGxMap_Point_Pointlong;
		 

		protected string gxTv_SdtGxMap_Point_Pointicon;
		 

		protected bool gxTv_SdtGxMap_Point_Pointdraggable;
		 

		protected bool gxTv_SdtGxMap_Point_Pointflat;
		 

		protected bool gxTv_SdtGxMap_Point_Pointclickeable;
		 

		protected bool gxTv_SdtGxMap_Point_Pointdeletable;
		 

		protected bool gxTv_SdtGxMap_Point_Pointvisible;
		 

		protected string gxTv_SdtGxMap_Point_Pointinfowinhtml;
		 

		protected string gxTv_SdtGxMap_Point_Pointstreet;
		 

		protected string gxTv_SdtGxMap_Point_Pointstreetnumber;
		 

		protected string gxTv_SdtGxMap_Point_Pointcrossstreet;
		 

		protected string gxTv_SdtGxMap_Point_Pointinfowintit;
		 

		protected string gxTv_SdtGxMap_Point_Pointinfowindesc;
		 

		protected string gxTv_SdtGxMap_Point_Pointinfowinlink;
		 

		protected string gxTv_SdtGxMap_Point_Pointinfowinlinkdsc;
		 

		protected string gxTv_SdtGxMap_Point_Pointinfowinimg;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"GxMap.Point", Namespace="RastreamentoTCC")]
	public class SdtGxMap_Point_RESTInterface : GxGenericCollectionItem<SdtGxMap_Point>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtGxMap_Point_RESTInterface( ) : base()
		{
		}

		public SdtGxMap_Point_RESTInterface( SdtGxMap_Point psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="PointLat", Order=0)]
		public  string gxTpr_Pointlat
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Pointlat);

			}
			set { 
				 sdt.gxTpr_Pointlat = value;
			}
		}

		[DataMember(Name="PointLong", Order=1)]
		public  string gxTpr_Pointlong
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Pointlong);

			}
			set { 
				 sdt.gxTpr_Pointlong = value;
			}
		}

		[DataMember(Name="PointIcon", Order=2)]
		public  string gxTpr_Pointicon
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Pointicon);

			}
			set { 
				 sdt.gxTpr_Pointicon = value;
			}
		}

		[DataMember(Name="PointDraggable", Order=3)]
		public bool gxTpr_Pointdraggable
		{
			get { 
				return sdt.gxTpr_Pointdraggable;

			}
			set { 
				sdt.gxTpr_Pointdraggable = value;
			}
		}

		[DataMember(Name="PointFlat", Order=4)]
		public bool gxTpr_Pointflat
		{
			get { 
				return sdt.gxTpr_Pointflat;

			}
			set { 
				sdt.gxTpr_Pointflat = value;
			}
		}

		[DataMember(Name="PointClickeable", Order=5)]
		public bool gxTpr_Pointclickeable
		{
			get { 
				return sdt.gxTpr_Pointclickeable;

			}
			set { 
				sdt.gxTpr_Pointclickeable = value;
			}
		}

		[DataMember(Name="PointDeletable", Order=6)]
		public bool gxTpr_Pointdeletable
		{
			get { 
				return sdt.gxTpr_Pointdeletable;

			}
			set { 
				sdt.gxTpr_Pointdeletable = value;
			}
		}

		[DataMember(Name="PointVisible", Order=7)]
		public bool gxTpr_Pointvisible
		{
			get { 
				return sdt.gxTpr_Pointvisible;

			}
			set { 
				sdt.gxTpr_Pointvisible = value;
			}
		}

		[DataMember(Name="PointInfowinHtml", Order=8)]
		public  string gxTpr_Pointinfowinhtml
		{
			get { 
				return sdt.gxTpr_Pointinfowinhtml;

			}
			set { 
				 sdt.gxTpr_Pointinfowinhtml = value;
			}
		}

		[DataMember(Name="PointStreet", Order=9)]
		public  string gxTpr_Pointstreet
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Pointstreet);

			}
			set { 
				 sdt.gxTpr_Pointstreet = value;
			}
		}

		[DataMember(Name="PointStreetNumber", Order=10)]
		public  string gxTpr_Pointstreetnumber
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Pointstreetnumber);

			}
			set { 
				 sdt.gxTpr_Pointstreetnumber = value;
			}
		}

		[DataMember(Name="PointCrossStreet", Order=11)]
		public  string gxTpr_Pointcrossstreet
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Pointcrossstreet);

			}
			set { 
				 sdt.gxTpr_Pointcrossstreet = value;
			}
		}

		[DataMember(Name="PointInfowinTit", Order=12)]
		public  string gxTpr_Pointinfowintit
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Pointinfowintit);

			}
			set { 
				 sdt.gxTpr_Pointinfowintit = value;
			}
		}

		[DataMember(Name="PointInfowinDesc", Order=13)]
		public  string gxTpr_Pointinfowindesc
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Pointinfowindesc);

			}
			set { 
				 sdt.gxTpr_Pointinfowindesc = value;
			}
		}

		[DataMember(Name="PointInfowinLink", Order=14)]
		public  string gxTpr_Pointinfowinlink
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Pointinfowinlink);

			}
			set { 
				 sdt.gxTpr_Pointinfowinlink = value;
			}
		}

		[DataMember(Name="PointInfowinLinkDsc", Order=15)]
		public  string gxTpr_Pointinfowinlinkdsc
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Pointinfowinlinkdsc);

			}
			set { 
				 sdt.gxTpr_Pointinfowinlinkdsc = value;
			}
		}

		[DataMember(Name="PointInfowinImg", Order=16)]
		public  string gxTpr_Pointinfowinimg
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Pointinfowinimg);

			}
			set { 
				 sdt.gxTpr_Pointinfowinimg = value;
			}
		}


		#endregion

		public SdtGxMap_Point sdt
		{
			get { 
				return (SdtGxMap_Point)Sdt;
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
				sdt = new SdtGxMap_Point() ;
			}
		}
	}
	#endregion
}