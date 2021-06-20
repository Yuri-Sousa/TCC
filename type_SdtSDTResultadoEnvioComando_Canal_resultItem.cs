/*
				   File: type_SdtSDTResultadoEnvioComando_Canal_resultItem
			Description: result
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
	[XmlRoot(ElementName="SDTResultadoEnvioComando_Canal.resultItem")]
	[XmlType(TypeName="SDTResultadoEnvioComando_Canal.resultItem" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtSDTResultadoEnvioComando_Canal_resultItem : GxUserType
	{
		public SdtSDTResultadoEnvioComando_Canal_resultItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Name = "";

		}

		public SdtSDTResultadoEnvioComando_Canal_resultItem(IGxContext context)
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
			if (gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Address != null)
			{
				AddObjectProperty("address", gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Address, false);  
			}

			AddObjectProperty("channel_id", gxTpr_Channel_id, false);


			AddObjectProperty("expires", gxTpr_Expires, false);


			AddObjectProperty("id", gxTpr_Id, false);


			AddObjectProperty("name", gxTpr_Name, false);

			if (gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Properties != null)
			{
				AddObjectProperty("properties", gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Properties, false);  
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="address" )]
		[XmlElement(ElementName="address" )]
		public SdtSDTResultadoEnvioComando_Canal_resultItem_address gxTpr_Address
		{
			get {
				if ( gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Address == null )
				{
					gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Address = new SdtSDTResultadoEnvioComando_Canal_resultItem_address(context);
				}
				gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Address_N = 0;

				return gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Address;
			}
			set {
				gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Address_N = 0;

				gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Address = value;
				SetDirty("Address");
			}

		}

		public void gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Address_SetNull()
		{
			gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Address_N = 1;

			gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Address = null;
			return  ;
		}

		public bool gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Address_IsNull()
		{
			if (gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Address == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Address_Json()
		{
					return gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Address != null;

		}



		[SoapElement(ElementName="channel_id")]
		[XmlElement(ElementName="channel_id")]
		public long gxTpr_Channel_id
		{
			get { 
				return gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Channel_id; 
			}
			set { 
				gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Channel_id = value;
				SetDirty("Channel_id");
			}
		}




		[SoapElement(ElementName="expires")]
		[XmlElement(ElementName="expires")]
		public long gxTpr_Expires
		{
			get { 
				return gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Expires; 
			}
			set { 
				gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Expires = value;
				SetDirty("Expires");
			}
		}




		[SoapElement(ElementName="id")]
		[XmlElement(ElementName="id")]
		public long gxTpr_Id
		{
			get { 
				return gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Id; 
			}
			set { 
				gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="name")]
		[XmlElement(ElementName="name")]
		public string gxTpr_Name
		{
			get { 
				return gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Name; 
			}
			set { 
				gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Name = value;
				SetDirty("Name");
			}
		}



		[SoapElement(ElementName="properties" )]
		[XmlElement(ElementName="properties" )]
		public SdtSDTResultadoEnvioComando_Canal_resultItem_properties gxTpr_Properties
		{
			get {
				if ( gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Properties == null )
				{
					gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Properties = new SdtSDTResultadoEnvioComando_Canal_resultItem_properties(context);
				}
				gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Properties_N = 0;

				return gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Properties;
			}
			set {
				gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Properties_N = 0;

				gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Properties = value;
				SetDirty("Properties");
			}

		}

		public void gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Properties_SetNull()
		{
			gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Properties_N = 1;

			gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Properties = null;
			return  ;
		}

		public bool gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Properties_IsNull()
		{
			if (gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Properties == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Properties_Json()
		{
					return gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Properties != null;

		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Address_N = 1;




			gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Name = "";

			gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Properties_N = 1;

			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Address_N;
		protected SdtSDTResultadoEnvioComando_Canal_resultItem_address gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Address = null; 


		protected long gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Channel_id;
		 

		protected long gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Expires;
		 

		protected long gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Id;
		 

		protected string gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Name;
		 
		protected short gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Properties_N;
		protected SdtSDTResultadoEnvioComando_Canal_resultItem_properties gxTv_SdtSDTResultadoEnvioComando_Canal_resultItem_Properties = null; 



		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SDTResultadoEnvioComando_Canal.resultItem", Namespace="RastreamentoTCC")]
	public class SdtSDTResultadoEnvioComando_Canal_resultItem_RESTInterface : GxGenericCollectionItem<SdtSDTResultadoEnvioComando_Canal_resultItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTResultadoEnvioComando_Canal_resultItem_RESTInterface( ) : base()
		{
		}

		public SdtSDTResultadoEnvioComando_Canal_resultItem_RESTInterface( SdtSDTResultadoEnvioComando_Canal_resultItem psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="address", Order=0, EmitDefaultValue=false)]
		public SdtSDTResultadoEnvioComando_Canal_resultItem_address_RESTInterface gxTpr_Address
		{
			get {
				if (sdt.ShouldSerializegxTpr_Address_Json())
					return new SdtSDTResultadoEnvioComando_Canal_resultItem_address_RESTInterface(sdt.gxTpr_Address);
				else
					return null;

			}

			set {
				sdt.gxTpr_Address = value.sdt;
			}

		}

		[DataMember(Name="channel_id", Order=1)]
		public  string gxTpr_Channel_id
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Channel_id, 15, 0));

			}
			set { 
				sdt.gxTpr_Channel_id = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="expires", Order=2)]
		public  string gxTpr_Expires
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Expires, 15, 0));

			}
			set { 
				sdt.gxTpr_Expires = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="id", Order=3)]
		public  string gxTpr_Id
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Id, 15, 0));

			}
			set { 
				sdt.gxTpr_Id = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="name", Order=4)]
		public  string gxTpr_Name
		{
			get { 
				return sdt.gxTpr_Name;

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[DataMember(Name="properties", Order=5, EmitDefaultValue=false)]
		public SdtSDTResultadoEnvioComando_Canal_resultItem_properties_RESTInterface gxTpr_Properties
		{
			get {
				if (sdt.ShouldSerializegxTpr_Properties_Json())
					return new SdtSDTResultadoEnvioComando_Canal_resultItem_properties_RESTInterface(sdt.gxTpr_Properties);
				else
					return null;

			}

			set {
				sdt.gxTpr_Properties = value.sdt;
			}

		}


		#endregion

		public SdtSDTResultadoEnvioComando_Canal_resultItem sdt
		{
			get { 
				return (SdtSDTResultadoEnvioComando_Canal_resultItem)Sdt;
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
				sdt = new SdtSDTResultadoEnvioComando_Canal_resultItem() ;
			}
		}
	}
	#endregion
}