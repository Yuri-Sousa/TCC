/*
				   File: type_SdtQueryViewerElements_Element_Format_ConditionalStyle
			Description: ConditionalStyles
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
	[XmlRoot(ElementName="QueryViewerElements.Element.Format.ConditionalStyle")]
	[XmlType(TypeName="QueryViewerElements.Element.Format.ConditionalStyle" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtQueryViewerElements_Element_Format_ConditionalStyle : GxUserType
	{
		public SdtQueryViewerElements_Element_Format_ConditionalStyle( )
		{
			/* Constructor for serialization */
			gxTv_SdtQueryViewerElements_Element_Format_ConditionalStyle_Operator = "";

			gxTv_SdtQueryViewerElements_Element_Format_ConditionalStyle_Value1 = "";

			gxTv_SdtQueryViewerElements_Element_Format_ConditionalStyle_Value2 = "";

			gxTv_SdtQueryViewerElements_Element_Format_ConditionalStyle_Styleorclass = "";

		}

		public SdtQueryViewerElements_Element_Format_ConditionalStyle(IGxContext context)
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
			AddObjectProperty("Operator", gxTpr_Operator, false);


			AddObjectProperty("Value1", gxTpr_Value1, false);


			AddObjectProperty("Value2", gxTpr_Value2, false);


			AddObjectProperty("StyleOrClass", gxTpr_Styleorclass, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Operator")]
		[XmlElement(ElementName="Operator")]
		public string gxTpr_Operator
		{
			get { 
				return gxTv_SdtQueryViewerElements_Element_Format_ConditionalStyle_Operator; 
			}
			set { 
				gxTv_SdtQueryViewerElements_Element_Format_ConditionalStyle_Operator = value;
				SetDirty("Operator");
			}
		}




		[SoapElement(ElementName="Value1")]
		[XmlElement(ElementName="Value1")]
		public string gxTpr_Value1
		{
			get { 
				return gxTv_SdtQueryViewerElements_Element_Format_ConditionalStyle_Value1; 
			}
			set { 
				gxTv_SdtQueryViewerElements_Element_Format_ConditionalStyle_Value1 = value;
				SetDirty("Value1");
			}
		}




		[SoapElement(ElementName="Value2")]
		[XmlElement(ElementName="Value2")]
		public string gxTpr_Value2
		{
			get { 
				return gxTv_SdtQueryViewerElements_Element_Format_ConditionalStyle_Value2; 
			}
			set { 
				gxTv_SdtQueryViewerElements_Element_Format_ConditionalStyle_Value2 = value;
				SetDirty("Value2");
			}
		}




		[SoapElement(ElementName="StyleOrClass")]
		[XmlElement(ElementName="StyleOrClass")]
		public string gxTpr_Styleorclass
		{
			get { 
				return gxTv_SdtQueryViewerElements_Element_Format_ConditionalStyle_Styleorclass; 
			}
			set { 
				gxTv_SdtQueryViewerElements_Element_Format_ConditionalStyle_Styleorclass = value;
				SetDirty("Styleorclass");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtQueryViewerElements_Element_Format_ConditionalStyle_Operator = "";
			gxTv_SdtQueryViewerElements_Element_Format_ConditionalStyle_Value1 = "";
			gxTv_SdtQueryViewerElements_Element_Format_ConditionalStyle_Value2 = "";
			gxTv_SdtQueryViewerElements_Element_Format_ConditionalStyle_Styleorclass = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtQueryViewerElements_Element_Format_ConditionalStyle_Operator;
		 

		protected string gxTv_SdtQueryViewerElements_Element_Format_ConditionalStyle_Value1;
		 

		protected string gxTv_SdtQueryViewerElements_Element_Format_ConditionalStyle_Value2;
		 

		protected string gxTv_SdtQueryViewerElements_Element_Format_ConditionalStyle_Styleorclass;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"QueryViewerElements.Element.Format.ConditionalStyle", Namespace="RastreamentoTCC")]
	public class SdtQueryViewerElements_Element_Format_ConditionalStyle_RESTInterface : GxGenericCollectionItem<SdtQueryViewerElements_Element_Format_ConditionalStyle>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtQueryViewerElements_Element_Format_ConditionalStyle_RESTInterface( ) : base()
		{
		}

		public SdtQueryViewerElements_Element_Format_ConditionalStyle_RESTInterface( SdtQueryViewerElements_Element_Format_ConditionalStyle psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="Operator", Order=0)]
		public  string gxTpr_Operator
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Operator);

			}
			set { 
				 sdt.gxTpr_Operator = value;
			}
		}

		[DataMember(Name="Value1", Order=1)]
		public  string gxTpr_Value1
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Value1);

			}
			set { 
				 sdt.gxTpr_Value1 = value;
			}
		}

		[DataMember(Name="Value2", Order=2)]
		public  string gxTpr_Value2
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Value2);

			}
			set { 
				 sdt.gxTpr_Value2 = value;
			}
		}

		[DataMember(Name="StyleOrClass", Order=3)]
		public  string gxTpr_Styleorclass
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Styleorclass);

			}
			set { 
				 sdt.gxTpr_Styleorclass = value;
			}
		}


		#endregion

		public SdtQueryViewerElements_Element_Format_ConditionalStyle sdt
		{
			get { 
				return (SdtQueryViewerElements_Element_Format_ConditionalStyle)Sdt;
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
				sdt = new SdtQueryViewerElements_Element_Format_ConditionalStyle() ;
			}
		}
	}
	#endregion
}