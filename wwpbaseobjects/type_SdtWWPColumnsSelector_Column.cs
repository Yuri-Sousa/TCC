/*
				   File: type_SdtWWPColumnsSelector_Column
			Description: Columns
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
	[XmlRoot(ElementName="WWPColumnsSelector.Column")]
	[XmlType(TypeName="WWPColumnsSelector.Column" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtWWPColumnsSelector_Column : GxUserType
	{
		public SdtWWPColumnsSelector_Column( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWPColumnsSelector_Column_Columnname = "";

			gxTv_SdtWWPColumnsSelector_Column_Displayname = "";

			gxTv_SdtWWPColumnsSelector_Column_Category = "";

			gxTv_SdtWWPColumnsSelector_Column_Fixed = "";

		}

		public SdtWWPColumnsSelector_Column(IGxContext context)
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
				mapper["C"] = "Columnname";
				mapper["V"] = "Isvisible";
				mapper["D"] = "Displayname";
				mapper["O"] = "Order";
				mapper["G"] = "Category";
				mapper["F"] = "Fixed";

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
			AddObjectProperty("C", gxTpr_Columnname, false);


			AddObjectProperty("V", gxTpr_Isvisible, false);


			AddObjectProperty("D", gxTpr_Displayname, false);


			AddObjectProperty("O", gxTpr_Order, false);


			AddObjectProperty("G", gxTpr_Category, false);


			AddObjectProperty("F", gxTpr_Fixed, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ColumnName")]
		[XmlElement(ElementName="ColumnName")]
		public string gxTpr_Columnname
		{
			get { 
				return gxTv_SdtWWPColumnsSelector_Column_Columnname; 
			}
			set { 
				gxTv_SdtWWPColumnsSelector_Column_Columnname = value;
				SetDirty("Columnname");
			}
		}




		[SoapElement(ElementName="IsVisible")]
		[XmlElement(ElementName="IsVisible")]
		public bool gxTpr_Isvisible
		{
			get { 
				return gxTv_SdtWWPColumnsSelector_Column_Isvisible; 
			}
			set { 
				gxTv_SdtWWPColumnsSelector_Column_Isvisible = value;
				SetDirty("Isvisible");
			}
		}




		[SoapElement(ElementName="DisplayName")]
		[XmlElement(ElementName="DisplayName")]
		public string gxTpr_Displayname
		{
			get { 
				return gxTv_SdtWWPColumnsSelector_Column_Displayname; 
			}
			set { 
				gxTv_SdtWWPColumnsSelector_Column_Displayname = value;
				SetDirty("Displayname");
			}
		}




		[SoapElement(ElementName="Order")]
		[XmlElement(ElementName="Order")]
		public short gxTpr_Order
		{
			get { 
				return gxTv_SdtWWPColumnsSelector_Column_Order; 
			}
			set { 
				gxTv_SdtWWPColumnsSelector_Column_Order = value;
				SetDirty("Order");
			}
		}




		[SoapElement(ElementName="Category")]
		[XmlElement(ElementName="Category")]
		public string gxTpr_Category
		{
			get { 
				return gxTv_SdtWWPColumnsSelector_Column_Category; 
			}
			set { 
				gxTv_SdtWWPColumnsSelector_Column_Category = value;
				SetDirty("Category");
			}
		}




		[SoapElement(ElementName="Fixed")]
		[XmlElement(ElementName="Fixed")]
		public string gxTpr_Fixed
		{
			get { 
				return gxTv_SdtWWPColumnsSelector_Column_Fixed; 
			}
			set { 
				gxTv_SdtWWPColumnsSelector_Column_Fixed = value;
				SetDirty("Fixed");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtWWPColumnsSelector_Column_Columnname = "";

			gxTv_SdtWWPColumnsSelector_Column_Displayname = "";

			gxTv_SdtWWPColumnsSelector_Column_Category = "";
			gxTv_SdtWWPColumnsSelector_Column_Fixed = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWWPColumnsSelector_Column_Columnname;
		 

		protected bool gxTv_SdtWWPColumnsSelector_Column_Isvisible;
		 

		protected string gxTv_SdtWWPColumnsSelector_Column_Displayname;
		 

		protected short gxTv_SdtWWPColumnsSelector_Column_Order;
		 

		protected string gxTv_SdtWWPColumnsSelector_Column_Category;
		 

		protected string gxTv_SdtWWPColumnsSelector_Column_Fixed;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"WWPColumnsSelector.Column", Namespace="RastreamentoTCC")]
	public class SdtWWPColumnsSelector_Column_RESTInterface : GxGenericCollectionItem<SdtWWPColumnsSelector_Column>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWPColumnsSelector_Column_RESTInterface( ) : base()
		{
		}

		public SdtWWPColumnsSelector_Column_RESTInterface( SdtWWPColumnsSelector_Column psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="C", Order=0)]
		public  string gxTpr_Columnname
		{
			get { 
				return sdt.gxTpr_Columnname;

			}
			set { 
				 sdt.gxTpr_Columnname = value;
			}
		}

		[DataMember(Name="V", Order=1)]
		public bool gxTpr_Isvisible
		{
			get { 
				return sdt.gxTpr_Isvisible;

			}
			set { 
				sdt.gxTpr_Isvisible = value;
			}
		}

		[DataMember(Name="D", Order=2)]
		public  string gxTpr_Displayname
		{
			get { 
				return sdt.gxTpr_Displayname;

			}
			set { 
				 sdt.gxTpr_Displayname = value;
			}
		}

		[DataMember(Name="O", Order=3)]
		public short gxTpr_Order
		{
			get { 
				return sdt.gxTpr_Order;

			}
			set { 
				sdt.gxTpr_Order = value;
			}
		}

		[DataMember(Name="G", Order=4)]
		public  string gxTpr_Category
		{
			get { 
				return sdt.gxTpr_Category;

			}
			set { 
				 sdt.gxTpr_Category = value;
			}
		}

		[DataMember(Name="F", Order=5)]
		public  string gxTpr_Fixed
		{
			get { 
				return sdt.gxTpr_Fixed;

			}
			set { 
				 sdt.gxTpr_Fixed = value;
			}
		}


		#endregion

		public SdtWWPColumnsSelector_Column sdt
		{
			get { 
				return (SdtWWPColumnsSelector_Column)Sdt;
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
				sdt = new SdtWWPColumnsSelector_Column() ;
			}
		}
	}
	#endregion
}