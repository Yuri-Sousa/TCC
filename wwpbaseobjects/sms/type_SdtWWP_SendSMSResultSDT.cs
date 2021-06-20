/*
				   File: type_SdtWWP_SendSMSResultSDT
			Description: WWP_SendSMSResultSDT
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
namespace GeneXus.Programs.wwpbaseobjects.sms
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="WWP_SendSMSResultSDT")]
	[XmlType(TypeName="WWP_SendSMSResultSDT" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtWWP_SendSMSResultSDT : GxUserType
	{
		public SdtWWP_SendSMSResultSDT( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWP_SendSMSResultSDT_Id = "";

			gxTv_SdtWWP_SendSMSResultSDT_From = "";

			gxTv_SdtWWP_SendSMSResultSDT_Body = "";

			gxTv_SdtWWP_SendSMSResultSDT_Type = "";

			gxTv_SdtWWP_SendSMSResultSDT_Created_at = (DateTime)(DateTime.MinValue);

			gxTv_SdtWWP_SendSMSResultSDT_Modified_at = (DateTime)(DateTime.MinValue);

			gxTv_SdtWWP_SendSMSResultSDT_Delivery_report = "";

			gxTv_SdtWWP_SendSMSResultSDT_Expire_at = (DateTime)(DateTime.MinValue);

			gxTv_SdtWWP_SendSMSResultSDT_Code = "";

			gxTv_SdtWWP_SendSMSResultSDT_Text = "";

		}

		public SdtWWP_SendSMSResultSDT(IGxContext context)
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

			if (gxTv_SdtWWP_SendSMSResultSDT_To != null)
			{
				AddObjectProperty("to", gxTv_SdtWWP_SendSMSResultSDT_To, false);  
			}

			AddObjectProperty("from", gxTpr_From, false);


			AddObjectProperty("canceled", gxTpr_Canceled, false);


			AddObjectProperty("body", gxTpr_Body, false);


			AddObjectProperty("type", gxTpr_Type, false);


			datetime_STZ = gxTpr_Created_at;
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
			AddObjectProperty("created_at", sDateCnv, false);


			datetime_STZ = gxTpr_Modified_at;
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
			AddObjectProperty("modified_at", sDateCnv, false);


			AddObjectProperty("delivery_report", gxTpr_Delivery_report, false);


			datetime_STZ = gxTpr_Expire_at;
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
			AddObjectProperty("expire_at", sDateCnv, false);


			AddObjectProperty("flash_message", gxTpr_Flash_message, false);


			AddObjectProperty("code", gxTpr_Code, false);


			AddObjectProperty("text", gxTpr_Text, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="id")]
		[XmlElement(ElementName="id")]
		public string gxTpr_Id
		{
			get { 
				return gxTv_SdtWWP_SendSMSResultSDT_Id; 
			}
			set { 
				gxTv_SdtWWP_SendSMSResultSDT_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="to" )]
		[XmlArray(ElementName="to"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GxSimpleCollection<string> gxTpr_To_GxSimpleCollection
		{
			get {
				if ( gxTv_SdtWWP_SendSMSResultSDT_To == null )
				{
					gxTv_SdtWWP_SendSMSResultSDT_To = new GxSimpleCollection<string>( );
				}
				return gxTv_SdtWWP_SendSMSResultSDT_To;
			}
			set {
				if ( gxTv_SdtWWP_SendSMSResultSDT_To == null )
				{
					gxTv_SdtWWP_SendSMSResultSDT_To = new GxSimpleCollection<string>( );
				}
				gxTv_SdtWWP_SendSMSResultSDT_To_N = 0;

				gxTv_SdtWWP_SendSMSResultSDT_To = value;
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public GxSimpleCollection<string> gxTpr_To
		{
			get {
				if ( gxTv_SdtWWP_SendSMSResultSDT_To == null )
				{
					gxTv_SdtWWP_SendSMSResultSDT_To = new GxSimpleCollection<string>();
				}
				gxTv_SdtWWP_SendSMSResultSDT_To_N = 0;

				return gxTv_SdtWWP_SendSMSResultSDT_To ;
			}
			set {
				gxTv_SdtWWP_SendSMSResultSDT_To_N = 0;

				gxTv_SdtWWP_SendSMSResultSDT_To = value;
				SetDirty("To");
			}
		}

		public void gxTv_SdtWWP_SendSMSResultSDT_To_SetNull()
		{
			gxTv_SdtWWP_SendSMSResultSDT_To_N = 1;

			gxTv_SdtWWP_SendSMSResultSDT_To = null;
			return  ;
		}

		public bool gxTv_SdtWWP_SendSMSResultSDT_To_IsNull()
		{
			if (gxTv_SdtWWP_SendSMSResultSDT_To == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_To_GxSimpleCollection_Json()
		{
				return gxTv_SdtWWP_SendSMSResultSDT_To != null && gxTv_SdtWWP_SendSMSResultSDT_To.Count > 0;

		}


		[SoapElement(ElementName="from")]
		[XmlElement(ElementName="from")]
		public string gxTpr_From
		{
			get { 
				return gxTv_SdtWWP_SendSMSResultSDT_From; 
			}
			set { 
				gxTv_SdtWWP_SendSMSResultSDT_From = value;
				SetDirty("From");
			}
		}




		[SoapElement(ElementName="canceled")]
		[XmlElement(ElementName="canceled")]
		public bool gxTpr_Canceled
		{
			get { 
				return gxTv_SdtWWP_SendSMSResultSDT_Canceled; 
			}
			set { 
				gxTv_SdtWWP_SendSMSResultSDT_Canceled = value;
				SetDirty("Canceled");
			}
		}




		[SoapElement(ElementName="body")]
		[XmlElement(ElementName="body")]
		public string gxTpr_Body
		{
			get { 
				return gxTv_SdtWWP_SendSMSResultSDT_Body; 
			}
			set { 
				gxTv_SdtWWP_SendSMSResultSDT_Body = value;
				SetDirty("Body");
			}
		}




		[SoapElement(ElementName="type")]
		[XmlElement(ElementName="type")]
		public string gxTpr_Type
		{
			get { 
				return gxTv_SdtWWP_SendSMSResultSDT_Type; 
			}
			set { 
				gxTv_SdtWWP_SendSMSResultSDT_Type = value;
				SetDirty("Type");
			}
		}



		[SoapElement(ElementName="created_at")]
		[XmlElement(ElementName="created_at" , IsNullable=true)]
		public string gxTpr_Created_at_Nullable
		{
			get {
				if ( gxTv_SdtWWP_SendSMSResultSDT_Created_at == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtWWP_SendSMSResultSDT_Created_at).value ;
			}
			set {
				gxTv_SdtWWP_SendSMSResultSDT_Created_at = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Created_at
		{
			get { 
				return gxTv_SdtWWP_SendSMSResultSDT_Created_at; 
			}
			set { 
				gxTv_SdtWWP_SendSMSResultSDT_Created_at = value;
				SetDirty("Created_at");
			}
		}


		[SoapElement(ElementName="modified_at")]
		[XmlElement(ElementName="modified_at" , IsNullable=true)]
		public string gxTpr_Modified_at_Nullable
		{
			get {
				if ( gxTv_SdtWWP_SendSMSResultSDT_Modified_at == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtWWP_SendSMSResultSDT_Modified_at).value ;
			}
			set {
				gxTv_SdtWWP_SendSMSResultSDT_Modified_at = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Modified_at
		{
			get { 
				return gxTv_SdtWWP_SendSMSResultSDT_Modified_at; 
			}
			set { 
				gxTv_SdtWWP_SendSMSResultSDT_Modified_at = value;
				SetDirty("Modified_at");
			}
		}



		[SoapElement(ElementName="delivery_report")]
		[XmlElement(ElementName="delivery_report")]
		public string gxTpr_Delivery_report
		{
			get { 
				return gxTv_SdtWWP_SendSMSResultSDT_Delivery_report; 
			}
			set { 
				gxTv_SdtWWP_SendSMSResultSDT_Delivery_report = value;
				SetDirty("Delivery_report");
			}
		}



		[SoapElement(ElementName="expire_at")]
		[XmlElement(ElementName="expire_at" , IsNullable=true)]
		public string gxTpr_Expire_at_Nullable
		{
			get {
				if ( gxTv_SdtWWP_SendSMSResultSDT_Expire_at == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtWWP_SendSMSResultSDT_Expire_at).value ;
			}
			set {
				gxTv_SdtWWP_SendSMSResultSDT_Expire_at = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Expire_at
		{
			get { 
				return gxTv_SdtWWP_SendSMSResultSDT_Expire_at; 
			}
			set { 
				gxTv_SdtWWP_SendSMSResultSDT_Expire_at = value;
				SetDirty("Expire_at");
			}
		}



		[SoapElement(ElementName="flash_message")]
		[XmlElement(ElementName="flash_message")]
		public bool gxTpr_Flash_message
		{
			get { 
				return gxTv_SdtWWP_SendSMSResultSDT_Flash_message; 
			}
			set { 
				gxTv_SdtWWP_SendSMSResultSDT_Flash_message = value;
				SetDirty("Flash_message");
			}
		}




		[SoapElement(ElementName="code")]
		[XmlElement(ElementName="code")]
		public string gxTpr_Code
		{
			get { 
				return gxTv_SdtWWP_SendSMSResultSDT_Code; 
			}
			set { 
				gxTv_SdtWWP_SendSMSResultSDT_Code = value;
				SetDirty("Code");
			}
		}




		[SoapElement(ElementName="text")]
		[XmlElement(ElementName="text")]
		public string gxTpr_Text
		{
			get { 
				return gxTv_SdtWWP_SendSMSResultSDT_Text; 
			}
			set { 
				gxTv_SdtWWP_SendSMSResultSDT_Text = value;
				SetDirty("Text");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtWWP_SendSMSResultSDT_Id = "";

			gxTv_SdtWWP_SendSMSResultSDT_To_N = 1;

			gxTv_SdtWWP_SendSMSResultSDT_From = "";

			gxTv_SdtWWP_SendSMSResultSDT_Body = "";
			gxTv_SdtWWP_SendSMSResultSDT_Type = "";
			gxTv_SdtWWP_SendSMSResultSDT_Created_at = (DateTime)(DateTime.MinValue);
			gxTv_SdtWWP_SendSMSResultSDT_Modified_at = (DateTime)(DateTime.MinValue);
			gxTv_SdtWWP_SendSMSResultSDT_Delivery_report = "";
			gxTv_SdtWWP_SendSMSResultSDT_Expire_at = (DateTime)(DateTime.MinValue);

			gxTv_SdtWWP_SendSMSResultSDT_Code = "";
			gxTv_SdtWWP_SendSMSResultSDT_Text = "";
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

		protected string gxTv_SdtWWP_SendSMSResultSDT_Id;
		 
		protected short gxTv_SdtWWP_SendSMSResultSDT_To_N;
		protected GxSimpleCollection<string> gxTv_SdtWWP_SendSMSResultSDT_To = null;  

		protected string gxTv_SdtWWP_SendSMSResultSDT_From;
		 

		protected bool gxTv_SdtWWP_SendSMSResultSDT_Canceled;
		 

		protected string gxTv_SdtWWP_SendSMSResultSDT_Body;
		 

		protected string gxTv_SdtWWP_SendSMSResultSDT_Type;
		 

		protected DateTime gxTv_SdtWWP_SendSMSResultSDT_Created_at;
		 

		protected DateTime gxTv_SdtWWP_SendSMSResultSDT_Modified_at;
		 

		protected string gxTv_SdtWWP_SendSMSResultSDT_Delivery_report;
		 

		protected DateTime gxTv_SdtWWP_SendSMSResultSDT_Expire_at;
		 

		protected bool gxTv_SdtWWP_SendSMSResultSDT_Flash_message;
		 

		protected string gxTv_SdtWWP_SendSMSResultSDT_Code;
		 

		protected string gxTv_SdtWWP_SendSMSResultSDT_Text;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"WWP_SendSMSResultSDT", Namespace="RastreamentoTCC")]
	public class SdtWWP_SendSMSResultSDT_RESTInterface : GxGenericCollectionItem<SdtWWP_SendSMSResultSDT>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWP_SendSMSResultSDT_RESTInterface( ) : base()
		{
		}

		public SdtWWP_SendSMSResultSDT_RESTInterface( SdtWWP_SendSMSResultSDT psdt ) : base(psdt)
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

		[DataMember(Name="to", Order=1, EmitDefaultValue=false)]
		public  GxSimpleCollection<string> gxTpr_To
		{
			get { 
				if (sdt.ShouldSerializegxTpr_To_GxSimpleCollection_Json())
					return sdt.gxTpr_To;
				else
					return null;

			}
			set { 
				sdt.gxTpr_To = value ;
			}
		}

		[DataMember(Name="from", Order=2)]
		public  string gxTpr_From
		{
			get { 
				return sdt.gxTpr_From;

			}
			set { 
				 sdt.gxTpr_From = value;
			}
		}

		[DataMember(Name="canceled", Order=3)]
		public bool gxTpr_Canceled
		{
			get { 
				return sdt.gxTpr_Canceled;

			}
			set { 
				sdt.gxTpr_Canceled = value;
			}
		}

		[DataMember(Name="body", Order=4)]
		public  string gxTpr_Body
		{
			get { 
				return sdt.gxTpr_Body;

			}
			set { 
				 sdt.gxTpr_Body = value;
			}
		}

		[DataMember(Name="type", Order=5)]
		public  string gxTpr_Type
		{
			get { 
				return sdt.gxTpr_Type;

			}
			set { 
				 sdt.gxTpr_Type = value;
			}
		}

		[DataMember(Name="created_at", Order=6)]
		public  string gxTpr_Created_at
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Created_at);

			}
			set { 
				sdt.gxTpr_Created_at = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="modified_at", Order=7)]
		public  string gxTpr_Modified_at
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Modified_at);

			}
			set { 
				sdt.gxTpr_Modified_at = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="delivery_report", Order=8)]
		public  string gxTpr_Delivery_report
		{
			get { 
				return sdt.gxTpr_Delivery_report;

			}
			set { 
				 sdt.gxTpr_Delivery_report = value;
			}
		}

		[DataMember(Name="expire_at", Order=9)]
		public  string gxTpr_Expire_at
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Expire_at);

			}
			set { 
				sdt.gxTpr_Expire_at = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="flash_message", Order=10)]
		public bool gxTpr_Flash_message
		{
			get { 
				return sdt.gxTpr_Flash_message;

			}
			set { 
				sdt.gxTpr_Flash_message = value;
			}
		}

		[DataMember(Name="code", Order=11)]
		public  string gxTpr_Code
		{
			get { 
				return sdt.gxTpr_Code;

			}
			set { 
				 sdt.gxTpr_Code = value;
			}
		}

		[DataMember(Name="text", Order=12)]
		public  string gxTpr_Text
		{
			get { 
				return sdt.gxTpr_Text;

			}
			set { 
				 sdt.gxTpr_Text = value;
			}
		}


		#endregion

		public SdtWWP_SendSMSResultSDT sdt
		{
			get { 
				return (SdtWWP_SendSMSResultSDT)Sdt;
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
				sdt = new SdtWWP_SendSMSResultSDT() ;
			}
		}
	}
	#endregion
}