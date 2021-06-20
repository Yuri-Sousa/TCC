/*
				   File: type_SdtWWPColumnsSelector
			Description: WWPColumnsSelector
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
	[XmlRoot(ElementName="WWPColumnsSelector")]
	[XmlType(TypeName="WWPColumnsSelector" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtWWPColumnsSelector : GxUserType
	{
		public SdtWWPColumnsSelector( )
		{
			/* Constructor for serialization */
		}

		public SdtWWPColumnsSelector(IGxContext context)
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
			if (gxTv_SdtWWPColumnsSelector_Columns != null)
			{
				AddObjectProperty("Columns", gxTv_SdtWWPColumnsSelector_Columns, false);  
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Columns" )]
		[XmlArray(ElementName="Columns"  )]
		[XmlArrayItemAttribute(ElementName="Column" , IsNullable=false )]
		public GXBaseCollection<SdtWWPColumnsSelector_Column> gxTpr_Columns
		{
			get {
				if ( gxTv_SdtWWPColumnsSelector_Columns == null )
				{
					gxTv_SdtWWPColumnsSelector_Columns = new GXBaseCollection<SdtWWPColumnsSelector_Column>( context, "WWPColumnsSelector.Column", "");
				}
				return gxTv_SdtWWPColumnsSelector_Columns;
			}
			set {
				if ( gxTv_SdtWWPColumnsSelector_Columns == null )
				{
					gxTv_SdtWWPColumnsSelector_Columns = new GXBaseCollection<SdtWWPColumnsSelector_Column>( context, "WWPColumnsSelector.Column", "");
				}
				gxTv_SdtWWPColumnsSelector_Columns_N = 0;

				gxTv_SdtWWPColumnsSelector_Columns = value;
				SetDirty("Columns");
			}
		}

		public void gxTv_SdtWWPColumnsSelector_Columns_SetNull()
		{
			gxTv_SdtWWPColumnsSelector_Columns_N = 1;

			gxTv_SdtWWPColumnsSelector_Columns = null;
			return  ;
		}

		public bool gxTv_SdtWWPColumnsSelector_Columns_IsNull()
		{
			if (gxTv_SdtWWPColumnsSelector_Columns == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Columns_GxSimpleCollection_Json()
		{
				return gxTv_SdtWWPColumnsSelector_Columns != null && gxTv_SdtWWPColumnsSelector_Columns.Count > 0;

		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtWWPColumnsSelector_Columns_N = 1;

			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtWWPColumnsSelector_Columns_N;
		protected GXBaseCollection<SdtWWPColumnsSelector_Column> gxTv_SdtWWPColumnsSelector_Columns = null; 



		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"WWPColumnsSelector", Namespace="RastreamentoTCC")]
	public class SdtWWPColumnsSelector_RESTInterface : GxGenericCollectionItem<SdtWWPColumnsSelector>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWPColumnsSelector_RESTInterface( ) : base()
		{
		}

		public SdtWWPColumnsSelector_RESTInterface( SdtWWPColumnsSelector psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="Columns", Order=0, EmitDefaultValue=false)]
		public GxGenericCollection<SdtWWPColumnsSelector_Column_RESTInterface> gxTpr_Columns
		{
			get {
				if (sdt.ShouldSerializegxTpr_Columns_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtWWPColumnsSelector_Column_RESTInterface>(sdt.gxTpr_Columns);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Columns);
			}
		}


		#endregion

		public SdtWWPColumnsSelector sdt
		{
			get { 
				return (SdtWWPColumnsSelector)Sdt;
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
				sdt = new SdtWWPColumnsSelector() ;
			}
		}
	}
	#endregion
}