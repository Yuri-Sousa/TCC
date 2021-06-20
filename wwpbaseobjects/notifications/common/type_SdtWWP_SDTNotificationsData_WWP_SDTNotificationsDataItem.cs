/*
				   File: type_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem
			Description: WWP_SDTNotificationsData
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
using GeneXus.Programs.wwpbaseobjects;
using GeneXus.Programs.wwpbaseobjects.notifications;
namespace GeneXus.Programs.wwpbaseobjects.notifications.common
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="WWP_SDTNotificationsDataItem")]
	[XmlType(TypeName="WWP_SDTNotificationsDataItem" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem : GxUserType
	{
		public SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem_Notificationiconclass = "";

			gxTv_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem_Notificationtitle = "";

			gxTv_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem_Notificationdescription = "";

			gxTv_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem_Notificationdatetime = (DateTime)(DateTime.MinValue);

			gxTv_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem_Notificationlink = "";

		}

		public SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem(IGxContext context)
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
			AddObjectProperty("NotificationId", gxTpr_Notificationid, false);


			AddObjectProperty("NotificationIconClass", gxTpr_Notificationiconclass, false);


			AddObjectProperty("NotificationTitle", gxTpr_Notificationtitle, false);


			AddObjectProperty("NotificationDescription", gxTpr_Notificationdescription, false);


			datetime_STZ = gxTpr_Notificationdatetime;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("NotificationDatetime", sDateCnv, false);


			AddObjectProperty("NotificationLink", gxTpr_Notificationlink, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="NotificationId")]
		[XmlElement(ElementName="NotificationId")]
		public int gxTpr_Notificationid
		{
			get { 
				return gxTv_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem_Notificationid; 
			}
			set { 
				gxTv_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem_Notificationid = value;
				SetDirty("Notificationid");
			}
		}




		[SoapElement(ElementName="NotificationIconClass")]
		[XmlElement(ElementName="NotificationIconClass")]
		public string gxTpr_Notificationiconclass
		{
			get { 
				return gxTv_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem_Notificationiconclass; 
			}
			set { 
				gxTv_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem_Notificationiconclass = value;
				SetDirty("Notificationiconclass");
			}
		}




		[SoapElement(ElementName="NotificationTitle")]
		[XmlElement(ElementName="NotificationTitle")]
		public string gxTpr_Notificationtitle
		{
			get { 
				return gxTv_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem_Notificationtitle; 
			}
			set { 
				gxTv_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem_Notificationtitle = value;
				SetDirty("Notificationtitle");
			}
		}




		[SoapElement(ElementName="NotificationDescription")]
		[XmlElement(ElementName="NotificationDescription")]
		public string gxTpr_Notificationdescription
		{
			get { 
				return gxTv_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem_Notificationdescription; 
			}
			set { 
				gxTv_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem_Notificationdescription = value;
				SetDirty("Notificationdescription");
			}
		}



		[SoapElement(ElementName="NotificationDatetime")]
		[XmlElement(ElementName="NotificationDatetime" , IsNullable=true)]
		public string gxTpr_Notificationdatetime_Nullable
		{
			get {
				if ( gxTv_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem_Notificationdatetime == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem_Notificationdatetime).value ;
			}
			set {
				gxTv_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem_Notificationdatetime = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Notificationdatetime
		{
			get { 
				return gxTv_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem_Notificationdatetime; 
			}
			set { 
				gxTv_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem_Notificationdatetime = value;
				SetDirty("Notificationdatetime");
			}
		}



		[SoapElement(ElementName="NotificationLink")]
		[XmlElement(ElementName="NotificationLink")]
		public string gxTpr_Notificationlink
		{
			get { 
				return gxTv_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem_Notificationlink; 
			}
			set { 
				gxTv_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem_Notificationlink = value;
				SetDirty("Notificationlink");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem_Notificationiconclass = "";
			gxTv_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem_Notificationtitle = "";
			gxTv_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem_Notificationdescription = "";
			gxTv_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem_Notificationdatetime = (DateTime)(DateTime.MinValue);
			gxTv_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem_Notificationlink = "";
			datetime_STZ = (DateTime)(DateTime.MinValue);
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected DateTime datetime_STZ ;

		protected int gxTv_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem_Notificationid;
		 

		protected string gxTv_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem_Notificationiconclass;
		 

		protected string gxTv_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem_Notificationtitle;
		 

		protected string gxTv_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem_Notificationdescription;
		 

		protected DateTime gxTv_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem_Notificationdatetime;
		 

		protected string gxTv_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem_Notificationlink;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"WWP_SDTNotificationsDataItem", Namespace="RastreamentoTCC")]
	public class SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem_RESTInterface : GxGenericCollectionItem<SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem_RESTInterface( ) : base()
		{
		}

		public SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem_RESTInterface( SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="NotificationId", Order=0)]
		public int gxTpr_Notificationid
		{
			get { 
				return sdt.gxTpr_Notificationid;

			}
			set { 
				sdt.gxTpr_Notificationid = value;
			}
		}

		[DataMember(Name="NotificationIconClass", Order=1)]
		public  string gxTpr_Notificationiconclass
		{
			get { 
				return sdt.gxTpr_Notificationiconclass;

			}
			set { 
				 sdt.gxTpr_Notificationiconclass = value;
			}
		}

		[DataMember(Name="NotificationTitle", Order=2)]
		public  string gxTpr_Notificationtitle
		{
			get { 
				return sdt.gxTpr_Notificationtitle;

			}
			set { 
				 sdt.gxTpr_Notificationtitle = value;
			}
		}

		[DataMember(Name="NotificationDescription", Order=3)]
		public  string gxTpr_Notificationdescription
		{
			get { 
				return sdt.gxTpr_Notificationdescription;

			}
			set { 
				 sdt.gxTpr_Notificationdescription = value;
			}
		}

		[DataMember(Name="NotificationDatetime", Order=4)]
		public  string gxTpr_Notificationdatetime
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Notificationdatetime);

			}
			set { 
				sdt.gxTpr_Notificationdatetime = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="NotificationLink", Order=5)]
		public  string gxTpr_Notificationlink
		{
			get { 
				return sdt.gxTpr_Notificationlink;

			}
			set { 
				 sdt.gxTpr_Notificationlink = value;
			}
		}


		#endregion

		public SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem sdt
		{
			get { 
				return (SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)Sdt;
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
				sdt = new SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem() ;
			}
		}
	}
	#endregion
}