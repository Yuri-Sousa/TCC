/*
				   File: type_SdtCountryInfo_Country
			Description: Countries
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
	[XmlRoot(ElementName="CountryInfo.Country")]
	[XmlType(TypeName="CountryInfo.Country" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtCountryInfo_Country : GxUserType
	{
		public SdtCountryInfo_Country( )
		{
			/* Constructor for serialization */
			gxTv_SdtCountryInfo_Country_Countryiso = "";

		}

		public SdtCountryInfo_Country(IGxContext context)
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
			AddObjectProperty("CountryISO", gxTpr_Countryiso, false);

			if (gxTv_SdtCountryInfo_Country_Values != null)
			{
				AddObjectProperty("Values", gxTv_SdtCountryInfo_Country_Values, false);  
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CountryISO")]
		[XmlElement(ElementName="CountryISO")]
		public string gxTpr_Countryiso
		{
			get { 
				return gxTv_SdtCountryInfo_Country_Countryiso; 
			}
			set { 
				gxTv_SdtCountryInfo_Country_Countryiso = value;
				SetDirty("Countryiso");
			}
		}




		[SoapElement(ElementName="Values" )]
		[XmlArray(ElementName="Values"  )]
		[XmlArrayItemAttribute(ElementName="Value" , IsNullable=false )]
		public GxSimpleCollection<decimal> gxTpr_Values_GxSimpleCollection
		{
			get {
				if ( gxTv_SdtCountryInfo_Country_Values == null )
				{
					gxTv_SdtCountryInfo_Country_Values = new GxSimpleCollection<decimal>( );
				}
				return gxTv_SdtCountryInfo_Country_Values;
			}
			set {
				if ( gxTv_SdtCountryInfo_Country_Values == null )
				{
					gxTv_SdtCountryInfo_Country_Values = new GxSimpleCollection<decimal>( );
				}
				gxTv_SdtCountryInfo_Country_Values_N = 0;

				gxTv_SdtCountryInfo_Country_Values = value;
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public GxSimpleCollection<decimal> gxTpr_Values
		{
			get {
				if ( gxTv_SdtCountryInfo_Country_Values == null )
				{
					gxTv_SdtCountryInfo_Country_Values = new GxSimpleCollection<decimal>();
				}
				gxTv_SdtCountryInfo_Country_Values_N = 0;

				return gxTv_SdtCountryInfo_Country_Values ;
			}
			set {
				gxTv_SdtCountryInfo_Country_Values_N = 0;

				gxTv_SdtCountryInfo_Country_Values = value;
				SetDirty("Values");
			}
		}

		public void gxTv_SdtCountryInfo_Country_Values_SetNull()
		{
			gxTv_SdtCountryInfo_Country_Values_N = 1;

			gxTv_SdtCountryInfo_Country_Values = null;
			return  ;
		}

		public bool gxTv_SdtCountryInfo_Country_Values_IsNull()
		{
			if (gxTv_SdtCountryInfo_Country_Values == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Values_GxSimpleCollection_Json()
		{
				return gxTv_SdtCountryInfo_Country_Values != null && gxTv_SdtCountryInfo_Country_Values.Count > 0;

		}


		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtCountryInfo_Country_Countryiso = "";

			gxTv_SdtCountryInfo_Country_Values_N = 1;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtCountryInfo_Country_Countryiso;
		 
		protected short gxTv_SdtCountryInfo_Country_Values_N;
		protected GxSimpleCollection<decimal> gxTv_SdtCountryInfo_Country_Values = null;  


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"CountryInfo.Country", Namespace="RastreamentoTCC")]
	public class SdtCountryInfo_Country_RESTInterface : GxGenericCollectionItem<SdtCountryInfo_Country>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtCountryInfo_Country_RESTInterface( ) : base()
		{
		}

		public SdtCountryInfo_Country_RESTInterface( SdtCountryInfo_Country psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="CountryISO", Order=0)]
		public  string gxTpr_Countryiso
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Countryiso);

			}
			set { 
				 sdt.gxTpr_Countryiso = value;
			}
		}

		[DataMember(Name="Values", Order=1, EmitDefaultValue=false)]
		public  GxSimpleCollection<string> gxTpr_Values
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Values_GxSimpleCollection_Json())
					return sdt.gxTpr_Values.ToStringCollection(10, 0);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Values.FromStringCollection(value);
			}
		}


		#endregion

		public SdtCountryInfo_Country sdt
		{
			get { 
				return (SdtCountryInfo_Country)Sdt;
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
				sdt = new SdtCountryInfo_Country() ;
			}
		}
	}
	#endregion
}