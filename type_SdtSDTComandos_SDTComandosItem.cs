/*
				   File: type_SdtSDTComandos_SDTComandosItem
			Description: SDTComandos
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
	[XmlRoot(ElementName="SDTComandosItem")]
	[XmlType(TypeName="SDTComandosItem" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtSDTComandos_SDTComandosItem : GxUserType
	{
		public SdtSDTComandos_SDTComandosItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTComandos_SDTComandosItem_Name = "";

		}

		public SdtSDTComandos_SDTComandosItem(IGxContext context)
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
			if (gxTv_SdtSDTComandos_SDTComandosItem_Address != null)
			{
				AddObjectProperty("address", gxTv_SdtSDTComandos_SDTComandosItem_Address, false);  
			}

			AddObjectProperty("name", gxTpr_Name, false);

			if (gxTv_SdtSDTComandos_SDTComandosItem_Properties != null)
			{
				AddObjectProperty("properties", gxTv_SdtSDTComandos_SDTComandosItem_Properties, false);  
			}

			AddObjectProperty("ttl", gxTpr_Ttl, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="address" )]
		[XmlElement(ElementName="address" )]
		public SdtSDTComandos_SDTComandosItem_address gxTpr_Address
		{
			get {
				if ( gxTv_SdtSDTComandos_SDTComandosItem_Address == null )
				{
					gxTv_SdtSDTComandos_SDTComandosItem_Address = new SdtSDTComandos_SDTComandosItem_address(context);
				}
				gxTv_SdtSDTComandos_SDTComandosItem_Address_N = 0;

				return gxTv_SdtSDTComandos_SDTComandosItem_Address;
			}
			set {
				gxTv_SdtSDTComandos_SDTComandosItem_Address_N = 0;

				gxTv_SdtSDTComandos_SDTComandosItem_Address = value;
				SetDirty("Address");
			}

		}

		public void gxTv_SdtSDTComandos_SDTComandosItem_Address_SetNull()
		{
			gxTv_SdtSDTComandos_SDTComandosItem_Address_N = 1;

			gxTv_SdtSDTComandos_SDTComandosItem_Address = null;
			return  ;
		}

		public bool gxTv_SdtSDTComandos_SDTComandosItem_Address_IsNull()
		{
			if (gxTv_SdtSDTComandos_SDTComandosItem_Address == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Address_Json()
		{
					return gxTv_SdtSDTComandos_SDTComandosItem_Address != null;

		}



		[SoapElement(ElementName="name")]
		[XmlElement(ElementName="name")]
		public string gxTpr_Name
		{
			get { 
				return gxTv_SdtSDTComandos_SDTComandosItem_Name; 
			}
			set { 
				gxTv_SdtSDTComandos_SDTComandosItem_Name = value;
				SetDirty("Name");
			}
		}



		[SoapElement(ElementName="properties" )]
		[XmlElement(ElementName="properties" )]
		public SdtSDTComandos_SDTComandosItem_properties gxTpr_Properties
		{
			get {
				if ( gxTv_SdtSDTComandos_SDTComandosItem_Properties == null )
				{
					gxTv_SdtSDTComandos_SDTComandosItem_Properties = new SdtSDTComandos_SDTComandosItem_properties(context);
				}
				gxTv_SdtSDTComandos_SDTComandosItem_Properties_N = 0;

				return gxTv_SdtSDTComandos_SDTComandosItem_Properties;
			}
			set {
				gxTv_SdtSDTComandos_SDTComandosItem_Properties_N = 0;

				gxTv_SdtSDTComandos_SDTComandosItem_Properties = value;
				SetDirty("Properties");
			}

		}

		public void gxTv_SdtSDTComandos_SDTComandosItem_Properties_SetNull()
		{
			gxTv_SdtSDTComandos_SDTComandosItem_Properties_N = 1;

			gxTv_SdtSDTComandos_SDTComandosItem_Properties = null;
			return  ;
		}

		public bool gxTv_SdtSDTComandos_SDTComandosItem_Properties_IsNull()
		{
			if (gxTv_SdtSDTComandos_SDTComandosItem_Properties == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Properties_Json()
		{
					return gxTv_SdtSDTComandos_SDTComandosItem_Properties != null;

		}



		[SoapElement(ElementName="ttl")]
		[XmlElement(ElementName="ttl")]
		public long gxTpr_Ttl
		{
			get { 
				return gxTv_SdtSDTComandos_SDTComandosItem_Ttl; 
			}
			set { 
				gxTv_SdtSDTComandos_SDTComandosItem_Ttl = value;
				SetDirty("Ttl");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSDTComandos_SDTComandosItem_Address_N = 1;

			gxTv_SdtSDTComandos_SDTComandosItem_Name = "";

			gxTv_SdtSDTComandos_SDTComandosItem_Properties_N = 1;


			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtSDTComandos_SDTComandosItem_Address_N;
		protected SdtSDTComandos_SDTComandosItem_address gxTv_SdtSDTComandos_SDTComandosItem_Address = null; 


		protected string gxTv_SdtSDTComandos_SDTComandosItem_Name;
		 
		protected short gxTv_SdtSDTComandos_SDTComandosItem_Properties_N;
		protected SdtSDTComandos_SDTComandosItem_properties gxTv_SdtSDTComandos_SDTComandosItem_Properties = null; 


		protected long gxTv_SdtSDTComandos_SDTComandosItem_Ttl;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SDTComandosItem", Namespace="RastreamentoTCC")]
	public class SdtSDTComandos_SDTComandosItem_RESTInterface : GxGenericCollectionItem<SdtSDTComandos_SDTComandosItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTComandos_SDTComandosItem_RESTInterface( ) : base()
		{
		}

		public SdtSDTComandos_SDTComandosItem_RESTInterface( SdtSDTComandos_SDTComandosItem psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="address", Order=0, EmitDefaultValue=false)]
		public SdtSDTComandos_SDTComandosItem_address_RESTInterface gxTpr_Address
		{
			get {
				if (sdt.ShouldSerializegxTpr_Address_Json())
					return new SdtSDTComandos_SDTComandosItem_address_RESTInterface(sdt.gxTpr_Address);
				else
					return null;

			}

			set {
				sdt.gxTpr_Address = value.sdt;
			}

		}

		[DataMember(Name="name", Order=1)]
		public  string gxTpr_Name
		{
			get { 
				return sdt.gxTpr_Name;

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[DataMember(Name="properties", Order=2, EmitDefaultValue=false)]
		public SdtSDTComandos_SDTComandosItem_properties_RESTInterface gxTpr_Properties
		{
			get {
				if (sdt.ShouldSerializegxTpr_Properties_Json())
					return new SdtSDTComandos_SDTComandosItem_properties_RESTInterface(sdt.gxTpr_Properties);
				else
					return null;

			}

			set {
				sdt.gxTpr_Properties = value.sdt;
			}

		}

		[DataMember(Name="ttl", Order=3)]
		public  string gxTpr_Ttl
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Ttl, 10, 0));

			}
			set { 
				sdt.gxTpr_Ttl = (long) NumberUtil.Val( value, ".");
			}
		}


		#endregion

		public SdtSDTComandos_SDTComandosItem sdt
		{
			get { 
				return (SdtSDTComandos_SDTComandosItem)Sdt;
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
				sdt = new SdtSDTComandos_SDTComandosItem() ;
			}
		}
	}
	#endregion
}