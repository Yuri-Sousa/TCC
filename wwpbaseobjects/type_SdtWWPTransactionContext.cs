/*
				   File: type_SdtWWPTransactionContext
			Description: WWPTransactionContext
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
	[XmlRoot(ElementName="WWPTransactionContext")]
	[XmlType(TypeName="WWPTransactionContext" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtWWPTransactionContext : GxUserType
	{
		public SdtWWPTransactionContext( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWPTransactionContext_Callerobject = "";

			gxTv_SdtWWPTransactionContext_Callerurl = "";

			gxTv_SdtWWPTransactionContext_Transactionname = "";

		}

		public SdtWWPTransactionContext(IGxContext context)
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
			AddObjectProperty("CallerObject", gxTpr_Callerobject, false);


			AddObjectProperty("CallerOnDelete", gxTpr_Callerondelete, false);


			AddObjectProperty("CallerURL", gxTpr_Callerurl, false);


			AddObjectProperty("TransactionName", gxTpr_Transactionname, false);

			if (gxTv_SdtWWPTransactionContext_Attributes != null)
			{
				AddObjectProperty("Attributes", gxTv_SdtWWPTransactionContext_Attributes, false);  
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CallerObject")]
		[XmlElement(ElementName="CallerObject")]
		public string gxTpr_Callerobject
		{
			get { 
				return gxTv_SdtWWPTransactionContext_Callerobject; 
			}
			set { 
				gxTv_SdtWWPTransactionContext_Callerobject = value;
				SetDirty("Callerobject");
			}
		}




		[SoapElement(ElementName="CallerOnDelete")]
		[XmlElement(ElementName="CallerOnDelete")]
		public bool gxTpr_Callerondelete
		{
			get { 
				return gxTv_SdtWWPTransactionContext_Callerondelete; 
			}
			set { 
				gxTv_SdtWWPTransactionContext_Callerondelete = value;
				SetDirty("Callerondelete");
			}
		}




		[SoapElement(ElementName="CallerURL")]
		[XmlElement(ElementName="CallerURL")]
		public string gxTpr_Callerurl
		{
			get { 
				return gxTv_SdtWWPTransactionContext_Callerurl; 
			}
			set { 
				gxTv_SdtWWPTransactionContext_Callerurl = value;
				SetDirty("Callerurl");
			}
		}




		[SoapElement(ElementName="TransactionName")]
		[XmlElement(ElementName="TransactionName")]
		public string gxTpr_Transactionname
		{
			get { 
				return gxTv_SdtWWPTransactionContext_Transactionname; 
			}
			set { 
				gxTv_SdtWWPTransactionContext_Transactionname = value;
				SetDirty("Transactionname");
			}
		}




		[SoapElement(ElementName="Attributes" )]
		[XmlArray(ElementName="Attributes"  )]
		[XmlArrayItemAttribute(ElementName="Attribute" , IsNullable=false )]
		public GXBaseCollection<SdtWWPTransactionContext_Attribute> gxTpr_Attributes
		{
			get {
				if ( gxTv_SdtWWPTransactionContext_Attributes == null )
				{
					gxTv_SdtWWPTransactionContext_Attributes = new GXBaseCollection<SdtWWPTransactionContext_Attribute>( context, "WWPTransactionContext.Attribute", "");
				}
				return gxTv_SdtWWPTransactionContext_Attributes;
			}
			set {
				if ( gxTv_SdtWWPTransactionContext_Attributes == null )
				{
					gxTv_SdtWWPTransactionContext_Attributes = new GXBaseCollection<SdtWWPTransactionContext_Attribute>( context, "WWPTransactionContext.Attribute", "");
				}
				gxTv_SdtWWPTransactionContext_Attributes_N = 0;

				gxTv_SdtWWPTransactionContext_Attributes = value;
				SetDirty("Attributes");
			}
		}

		public void gxTv_SdtWWPTransactionContext_Attributes_SetNull()
		{
			gxTv_SdtWWPTransactionContext_Attributes_N = 1;

			gxTv_SdtWWPTransactionContext_Attributes = null;
			return  ;
		}

		public bool gxTv_SdtWWPTransactionContext_Attributes_IsNull()
		{
			if (gxTv_SdtWWPTransactionContext_Attributes == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Attributes_GxSimpleCollection_Json()
		{
				return gxTv_SdtWWPTransactionContext_Attributes != null && gxTv_SdtWWPTransactionContext_Attributes.Count > 0;

		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtWWPTransactionContext_Callerobject = "";

			gxTv_SdtWWPTransactionContext_Callerurl = "";
			gxTv_SdtWWPTransactionContext_Transactionname = "";

			gxTv_SdtWWPTransactionContext_Attributes_N = 1;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWWPTransactionContext_Callerobject;
		 

		protected bool gxTv_SdtWWPTransactionContext_Callerondelete;
		 

		protected string gxTv_SdtWWPTransactionContext_Callerurl;
		 

		protected string gxTv_SdtWWPTransactionContext_Transactionname;
		 
		protected short gxTv_SdtWWPTransactionContext_Attributes_N;
		protected GXBaseCollection<SdtWWPTransactionContext_Attribute> gxTv_SdtWWPTransactionContext_Attributes = null; 



		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"WWPTransactionContext", Namespace="RastreamentoTCC")]
	public class SdtWWPTransactionContext_RESTInterface : GxGenericCollectionItem<SdtWWPTransactionContext>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWPTransactionContext_RESTInterface( ) : base()
		{
		}

		public SdtWWPTransactionContext_RESTInterface( SdtWWPTransactionContext psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="CallerObject", Order=0)]
		public  string gxTpr_Callerobject
		{
			get { 
				return sdt.gxTpr_Callerobject;

			}
			set { 
				 sdt.gxTpr_Callerobject = value;
			}
		}

		[DataMember(Name="CallerOnDelete", Order=1)]
		public bool gxTpr_Callerondelete
		{
			get { 
				return sdt.gxTpr_Callerondelete;

			}
			set { 
				sdt.gxTpr_Callerondelete = value;
			}
		}

		[DataMember(Name="CallerURL", Order=2)]
		public  string gxTpr_Callerurl
		{
			get { 
				return sdt.gxTpr_Callerurl;

			}
			set { 
				 sdt.gxTpr_Callerurl = value;
			}
		}

		[DataMember(Name="TransactionName", Order=3)]
		public  string gxTpr_Transactionname
		{
			get { 
				return sdt.gxTpr_Transactionname;

			}
			set { 
				 sdt.gxTpr_Transactionname = value;
			}
		}

		[DataMember(Name="Attributes", Order=4, EmitDefaultValue=false)]
		public GxGenericCollection<SdtWWPTransactionContext_Attribute_RESTInterface> gxTpr_Attributes
		{
			get {
				if (sdt.ShouldSerializegxTpr_Attributes_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtWWPTransactionContext_Attribute_RESTInterface>(sdt.gxTpr_Attributes);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Attributes);
			}
		}


		#endregion

		public SdtWWPTransactionContext sdt
		{
			get { 
				return (SdtWWPTransactionContext)Sdt;
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
				sdt = new SdtWWPTransactionContext() ;
			}
		}
	}
	#endregion
}