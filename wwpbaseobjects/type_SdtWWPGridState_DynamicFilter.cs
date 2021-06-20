/*
				   File: type_SdtWWPGridState_DynamicFilter
			Description: DynamicFilters
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
	[XmlRoot(ElementName="WWPGridState.DynamicFilter")]
	[XmlType(TypeName="WWPGridState.DynamicFilter" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtWWPGridState_DynamicFilter : GxUserType
	{
		public SdtWWPGridState_DynamicFilter( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWPGridState_DynamicFilter_Selected = "";

			gxTv_SdtWWPGridState_DynamicFilter_Dsc = "";

			gxTv_SdtWWPGridState_DynamicFilter_Value = "";

			gxTv_SdtWWPGridState_DynamicFilter_Valueto = "";

		}

		public SdtWWPGridState_DynamicFilter(IGxContext context)
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
				mapper["d"] = "Dsc";

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
			AddObjectProperty("Selected", gxTpr_Selected, false);


			AddObjectProperty("d", gxTpr_Dsc, false);


			AddObjectProperty("Value", gxTpr_Value, false);


			AddObjectProperty("Operator", gxTpr_Operator, false);


			AddObjectProperty("ValueTo", gxTpr_Valueto, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Selected")]
		[XmlElement(ElementName="Selected")]
		public string gxTpr_Selected
		{
			get { 
				return gxTv_SdtWWPGridState_DynamicFilter_Selected; 
			}
			set { 
				gxTv_SdtWWPGridState_DynamicFilter_Selected = value;
				SetDirty("Selected");
			}
		}




		[SoapElement(ElementName="Dsc")]
		[XmlElement(ElementName="Dsc")]
		public string gxTpr_Dsc
		{
			get { 
				return gxTv_SdtWWPGridState_DynamicFilter_Dsc; 
			}
			set { 
				gxTv_SdtWWPGridState_DynamicFilter_Dsc_N = 0;

				gxTv_SdtWWPGridState_DynamicFilter_Dsc = value;
				SetDirty("Dsc");
			}
		}

		public bool ShouldSerializegxTpr_Dsc()

		{
				return gxTv_SdtWWPGridState_DynamicFilter_Dsc_N == 0;

		}



		[SoapElement(ElementName="Value")]
		[XmlElement(ElementName="Value")]
		public string gxTpr_Value
		{
			get { 
				return gxTv_SdtWWPGridState_DynamicFilter_Value; 
			}
			set { 
				gxTv_SdtWWPGridState_DynamicFilter_Value = value;
				SetDirty("Value");
			}
		}




		[SoapElement(ElementName="Operator")]
		[XmlElement(ElementName="Operator")]
		public short gxTpr_Operator
		{
			get { 
				return gxTv_SdtWWPGridState_DynamicFilter_Operator; 
			}
			set { 
				gxTv_SdtWWPGridState_DynamicFilter_Operator = value;
				SetDirty("Operator");
			}
		}




		[SoapElement(ElementName="ValueTo")]
		[XmlElement(ElementName="ValueTo")]
		public string gxTpr_Valueto
		{
			get { 
				return gxTv_SdtWWPGridState_DynamicFilter_Valueto; 
			}
			set { 
				gxTv_SdtWWPGridState_DynamicFilter_Valueto = value;
				SetDirty("Valueto");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtWWPGridState_DynamicFilter_Selected = "";
			gxTv_SdtWWPGridState_DynamicFilter_Dsc = "";
			gxTv_SdtWWPGridState_DynamicFilter_Dsc_N = 1;

			gxTv_SdtWWPGridState_DynamicFilter_Value = "";

			gxTv_SdtWWPGridState_DynamicFilter_Valueto = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWWPGridState_DynamicFilter_Selected;
		 

		protected string gxTv_SdtWWPGridState_DynamicFilter_Dsc;
		protected short gxTv_SdtWWPGridState_DynamicFilter_Dsc_N;
		 

		protected string gxTv_SdtWWPGridState_DynamicFilter_Value;
		 

		protected short gxTv_SdtWWPGridState_DynamicFilter_Operator;
		 

		protected string gxTv_SdtWWPGridState_DynamicFilter_Valueto;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"WWPGridState.DynamicFilter", Namespace="RastreamentoTCC")]
	public class SdtWWPGridState_DynamicFilter_RESTInterface : GxGenericCollectionItem<SdtWWPGridState_DynamicFilter>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWPGridState_DynamicFilter_RESTInterface( ) : base()
		{
		}

		public SdtWWPGridState_DynamicFilter_RESTInterface( SdtWWPGridState_DynamicFilter psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="Selected", Order=0)]
		public  string gxTpr_Selected
		{
			get { 
				return sdt.gxTpr_Selected;

			}
			set { 
				 sdt.gxTpr_Selected = value;
			}
		}

		[DataMember(Name="d", Order=1)]
		public  string gxTpr_Dsc
		{
			get { 
				return sdt.gxTpr_Dsc;

			}
			set { 
				 sdt.gxTpr_Dsc = value;
			}
		}

		[DataMember(Name="Value", Order=2)]
		public  string gxTpr_Value
		{
			get { 
				return sdt.gxTpr_Value;

			}
			set { 
				 sdt.gxTpr_Value = value;
			}
		}

		[DataMember(Name="Operator", Order=3)]
		public short gxTpr_Operator
		{
			get { 
				return sdt.gxTpr_Operator;

			}
			set { 
				sdt.gxTpr_Operator = value;
			}
		}

		[DataMember(Name="ValueTo", Order=4)]
		public  string gxTpr_Valueto
		{
			get { 
				return sdt.gxTpr_Valueto;

			}
			set { 
				 sdt.gxTpr_Valueto = value;
			}
		}


		#endregion

		public SdtWWPGridState_DynamicFilter sdt
		{
			get { 
				return (SdtWWPGridState_DynamicFilter)Sdt;
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
				sdt = new SdtWWPGridState_DynamicFilter() ;
			}
		}
	}
	#endregion
}