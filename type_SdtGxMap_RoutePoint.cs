/*
				   File: type_SdtGxMap_RoutePoint
			Description: Routing
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
	[XmlRoot(ElementName="GxMap.RoutePoint")]
	[XmlType(TypeName="GxMap.RoutePoint" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtGxMap_RoutePoint : GxUserType
	{
		public SdtGxMap_RoutePoint( )
		{
			/* Constructor for serialization */
			gxTv_SdtGxMap_RoutePoint_Latitude = "";

			gxTv_SdtGxMap_RoutePoint_Longitude = "";

			gxTv_SdtGxMap_RoutePoint_Pin = "";

			gxTv_SdtGxMap_RoutePoint_Description = "";

		}

		public SdtGxMap_RoutePoint(IGxContext context)
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
			AddObjectProperty("Latitude", gxTpr_Latitude, false);


			AddObjectProperty("Longitude", gxTpr_Longitude, false);


			AddObjectProperty("Pin", gxTpr_Pin, false);


			AddObjectProperty("Description", gxTpr_Description, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Latitude")]
		[XmlElement(ElementName="Latitude")]
		public string gxTpr_Latitude
		{
			get { 
				return gxTv_SdtGxMap_RoutePoint_Latitude; 
			}
			set { 
				gxTv_SdtGxMap_RoutePoint_Latitude = value;
				SetDirty("Latitude");
			}
		}




		[SoapElement(ElementName="Longitude")]
		[XmlElement(ElementName="Longitude")]
		public string gxTpr_Longitude
		{
			get { 
				return gxTv_SdtGxMap_RoutePoint_Longitude; 
			}
			set { 
				gxTv_SdtGxMap_RoutePoint_Longitude = value;
				SetDirty("Longitude");
			}
		}




		[SoapElement(ElementName="Pin")]
		[XmlElement(ElementName="Pin")]
		public string gxTpr_Pin
		{
			get { 
				return gxTv_SdtGxMap_RoutePoint_Pin; 
			}
			set { 
				gxTv_SdtGxMap_RoutePoint_Pin = value;
				SetDirty("Pin");
			}
		}




		[SoapElement(ElementName="Description")]
		[XmlElement(ElementName="Description")]
		public string gxTpr_Description
		{
			get { 
				return gxTv_SdtGxMap_RoutePoint_Description; 
			}
			set { 
				gxTv_SdtGxMap_RoutePoint_Description = value;
				SetDirty("Description");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtGxMap_RoutePoint_Latitude = "";
			gxTv_SdtGxMap_RoutePoint_Longitude = "";
			gxTv_SdtGxMap_RoutePoint_Pin = "";
			gxTv_SdtGxMap_RoutePoint_Description = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtGxMap_RoutePoint_Latitude;
		 

		protected string gxTv_SdtGxMap_RoutePoint_Longitude;
		 

		protected string gxTv_SdtGxMap_RoutePoint_Pin;
		 

		protected string gxTv_SdtGxMap_RoutePoint_Description;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"GxMap.RoutePoint", Namespace="RastreamentoTCC")]
	public class SdtGxMap_RoutePoint_RESTInterface : GxGenericCollectionItem<SdtGxMap_RoutePoint>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtGxMap_RoutePoint_RESTInterface( ) : base()
		{
		}

		public SdtGxMap_RoutePoint_RESTInterface( SdtGxMap_RoutePoint psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="Latitude", Order=0)]
		public  string gxTpr_Latitude
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Latitude);

			}
			set { 
				 sdt.gxTpr_Latitude = value;
			}
		}

		[DataMember(Name="Longitude", Order=1)]
		public  string gxTpr_Longitude
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Longitude);

			}
			set { 
				 sdt.gxTpr_Longitude = value;
			}
		}

		[DataMember(Name="Pin", Order=2)]
		public  string gxTpr_Pin
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Pin);

			}
			set { 
				 sdt.gxTpr_Pin = value;
			}
		}

		[DataMember(Name="Description", Order=3)]
		public  string gxTpr_Description
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Description);

			}
			set { 
				 sdt.gxTpr_Description = value;
			}
		}


		#endregion

		public SdtGxMap_RoutePoint sdt
		{
			get { 
				return (SdtGxMap_RoutePoint)Sdt;
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
				sdt = new SdtGxMap_RoutePoint() ;
			}
		}
	}
	#endregion
}