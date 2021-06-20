/*
				   File: type_SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem
			Description: SDTSubscribersMQTT
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
	[XmlRoot(ElementName="SDTSubscribersMQTTItem")]
	[XmlType(TypeName="SDTSubscribersMQTTItem" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem : GxUserType
	{
		public SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem( )
		{
			/* Constructor for serialization */
		}

		public SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem(IGxContext context)
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
			AddObjectProperty("RastreadorId", gxTpr_Rastreadorid, false);


			AddObjectProperty("RastreadorSNumber", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Rastreadorsnumber, 16, 0)), false);


			AddObjectProperty("RastreadorDeviceIdFlespi", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Rastreadordeviceidflespi, 16, 0)), false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="RastreadorId")]
		[XmlElement(ElementName="RastreadorId")]
		public int gxTpr_Rastreadorid
		{
			get { 
				return gxTv_SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem_Rastreadorid; 
			}
			set { 
				gxTv_SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem_Rastreadorid = value;
				SetDirty("Rastreadorid");
			}
		}




		[SoapElement(ElementName="RastreadorSNumber")]
		[XmlElement(ElementName="RastreadorSNumber")]
		public long gxTpr_Rastreadorsnumber
		{
			get { 
				return gxTv_SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem_Rastreadorsnumber; 
			}
			set { 
				gxTv_SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem_Rastreadorsnumber = value;
				SetDirty("Rastreadorsnumber");
			}
		}




		[SoapElement(ElementName="RastreadorDeviceIdFlespi")]
		[XmlElement(ElementName="RastreadorDeviceIdFlespi")]
		public long gxTpr_Rastreadordeviceidflespi
		{
			get { 
				return gxTv_SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem_Rastreadordeviceidflespi; 
			}
			set { 
				gxTv_SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem_Rastreadordeviceidflespi = value;
				SetDirty("Rastreadordeviceidflespi");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem_Rastreadorid;
		 

		protected long gxTv_SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem_Rastreadorsnumber;
		 

		protected long gxTv_SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem_Rastreadordeviceidflespi;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SDTSubscribersMQTTItem", Namespace="RastreamentoTCC")]
	public class SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem_RESTInterface : GxGenericCollectionItem<SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem_RESTInterface( ) : base()
		{
		}

		public SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem_RESTInterface( SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="RastreadorId", Order=0)]
		public  string gxTpr_Rastreadorid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Rastreadorid, 8, 0));

			}
			set { 
				sdt.gxTpr_Rastreadorid = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="RastreadorSNumber", Order=1)]
		public  string gxTpr_Rastreadorsnumber
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Rastreadorsnumber, 16, 0));

			}
			set { 
				sdt.gxTpr_Rastreadorsnumber = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="RastreadorDeviceIdFlespi", Order=2)]
		public  string gxTpr_Rastreadordeviceidflespi
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Rastreadordeviceidflespi, 16, 0));

			}
			set { 
				sdt.gxTpr_Rastreadordeviceidflespi = (long) NumberUtil.Val( value, ".");
			}
		}


		#endregion

		public SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem sdt
		{
			get { 
				return (SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem)Sdt;
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
				sdt = new SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem() ;
			}
		}
	}
	#endregion
}