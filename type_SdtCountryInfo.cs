/*
				   File: type_SdtCountryInfo
			Description: CountryInfo
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
	[XmlRoot(ElementName="CountryInfo")]
	[XmlType(TypeName="CountryInfo" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtCountryInfo : GxUserType
	{
		public SdtCountryInfo( )
		{
			/* Constructor for serialization */
		}

		public SdtCountryInfo(IGxContext context)
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
			if (gxTv_SdtCountryInfo_Info != null)
			{
				AddObjectProperty("Info", gxTv_SdtCountryInfo_Info, false);  
			}
			if (gxTv_SdtCountryInfo_Countries != null)
			{
				AddObjectProperty("Countries", gxTv_SdtCountryInfo_Countries, false);  
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Info" )]
		[XmlArray(ElementName="Info"  )]
		[XmlArrayItemAttribute(ElementName="Name" , IsNullable=false )]
		public GxSimpleCollection<string> gxTpr_Info_GxSimpleCollection
		{
			get {
				if ( gxTv_SdtCountryInfo_Info == null )
				{
					gxTv_SdtCountryInfo_Info = new GxSimpleCollection<string>( );
				}
				return gxTv_SdtCountryInfo_Info;
			}
			set {
				if ( gxTv_SdtCountryInfo_Info == null )
				{
					gxTv_SdtCountryInfo_Info = new GxSimpleCollection<string>( );
				}
				gxTv_SdtCountryInfo_Info_N = 0;

				gxTv_SdtCountryInfo_Info = value;
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public GxSimpleCollection<string> gxTpr_Info
		{
			get {
				if ( gxTv_SdtCountryInfo_Info == null )
				{
					gxTv_SdtCountryInfo_Info = new GxSimpleCollection<string>();
				}
				gxTv_SdtCountryInfo_Info_N = 0;

				return gxTv_SdtCountryInfo_Info ;
			}
			set {
				gxTv_SdtCountryInfo_Info_N = 0;

				gxTv_SdtCountryInfo_Info = value;
				SetDirty("Info");
			}
		}

		public void gxTv_SdtCountryInfo_Info_SetNull()
		{
			gxTv_SdtCountryInfo_Info_N = 1;

			gxTv_SdtCountryInfo_Info = null;
			return  ;
		}

		public bool gxTv_SdtCountryInfo_Info_IsNull()
		{
			if (gxTv_SdtCountryInfo_Info == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Info_GxSimpleCollection_Json()
		{
				return gxTv_SdtCountryInfo_Info != null && gxTv_SdtCountryInfo_Info.Count > 0;

		}


		[SoapElement(ElementName="Countries" )]
		[XmlArray(ElementName="Countries"  )]
		[XmlArrayItemAttribute(ElementName="Country" , IsNullable=false )]
		public GXBaseCollection<SdtCountryInfo_Country> gxTpr_Countries
		{
			get {
				if ( gxTv_SdtCountryInfo_Countries == null )
				{
					gxTv_SdtCountryInfo_Countries = new GXBaseCollection<SdtCountryInfo_Country>( context, "CountryInfo.Country", "");
				}
				return gxTv_SdtCountryInfo_Countries;
			}
			set {
				if ( gxTv_SdtCountryInfo_Countries == null )
				{
					gxTv_SdtCountryInfo_Countries = new GXBaseCollection<SdtCountryInfo_Country>( context, "CountryInfo.Country", "");
				}
				gxTv_SdtCountryInfo_Countries_N = 0;

				gxTv_SdtCountryInfo_Countries = value;
				SetDirty("Countries");
			}
		}

		public void gxTv_SdtCountryInfo_Countries_SetNull()
		{
			gxTv_SdtCountryInfo_Countries_N = 1;

			gxTv_SdtCountryInfo_Countries = null;
			return  ;
		}

		public bool gxTv_SdtCountryInfo_Countries_IsNull()
		{
			if (gxTv_SdtCountryInfo_Countries == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Countries_GxSimpleCollection_Json()
		{
				return gxTv_SdtCountryInfo_Countries != null && gxTv_SdtCountryInfo_Countries.Count > 0;

		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtCountryInfo_Info_N = 1;


			gxTv_SdtCountryInfo_Countries_N = 1;

			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtCountryInfo_Info_N;
		protected GxSimpleCollection<string> gxTv_SdtCountryInfo_Info = null;  
		protected short gxTv_SdtCountryInfo_Countries_N;
		protected GXBaseCollection<SdtCountryInfo_Country> gxTv_SdtCountryInfo_Countries = null; 



		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"CountryInfo", Namespace="RastreamentoTCC")]
	public class SdtCountryInfo_RESTInterface : GxGenericCollectionItem<SdtCountryInfo>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtCountryInfo_RESTInterface( ) : base()
		{
		}

		public SdtCountryInfo_RESTInterface( SdtCountryInfo psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="Info", Order=0, EmitDefaultValue=false)]
		public  GxSimpleCollection<string> gxTpr_Info
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Info_GxSimpleCollection_Json())
					return sdt.gxTpr_Info;
				else
					return null;

			}
			set { 
				sdt.gxTpr_Info = value ;
			}
		}

		[DataMember(Name="Countries", Order=1, EmitDefaultValue=false)]
		public GxGenericCollection<SdtCountryInfo_Country_RESTInterface> gxTpr_Countries
		{
			get {
				if (sdt.ShouldSerializegxTpr_Countries_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtCountryInfo_Country_RESTInterface>(sdt.gxTpr_Countries);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Countries);
			}
		}


		#endregion

		public SdtCountryInfo sdt
		{
			get { 
				return (SdtCountryInfo)Sdt;
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
				sdt = new SdtCountryInfo() ;
			}
		}
	}
	#endregion
}