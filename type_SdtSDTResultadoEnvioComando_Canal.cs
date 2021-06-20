/*
				   File: type_SdtSDTResultadoEnvioComando_Canal
			Description: SDTResultadoEnvioComando_Canal
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
	[XmlRoot(ElementName="SDTResultadoEnvioComando_Canal")]
	[XmlType(TypeName="SDTResultadoEnvioComando_Canal" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtSDTResultadoEnvioComando_Canal : GxUserType
	{
		public SdtSDTResultadoEnvioComando_Canal( )
		{
			/* Constructor for serialization */
		}

		public SdtSDTResultadoEnvioComando_Canal(IGxContext context)
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
			if (gxTv_SdtSDTResultadoEnvioComando_Canal_Result != null)
			{
				AddObjectProperty("result", gxTv_SdtSDTResultadoEnvioComando_Canal_Result, false);  
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="result" )]
		[XmlArray(ElementName="result"  )]
		[XmlArrayItemAttribute(ElementName="resultItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDTResultadoEnvioComando_Canal_resultItem> gxTpr_Result
		{
			get {
				if ( gxTv_SdtSDTResultadoEnvioComando_Canal_Result == null )
				{
					gxTv_SdtSDTResultadoEnvioComando_Canal_Result = new GXBaseCollection<SdtSDTResultadoEnvioComando_Canal_resultItem>( context, "SDTResultadoEnvioComando_Canal.resultItem", "");
				}
				return gxTv_SdtSDTResultadoEnvioComando_Canal_Result;
			}
			set {
				if ( gxTv_SdtSDTResultadoEnvioComando_Canal_Result == null )
				{
					gxTv_SdtSDTResultadoEnvioComando_Canal_Result = new GXBaseCollection<SdtSDTResultadoEnvioComando_Canal_resultItem>( context, "SDTResultadoEnvioComando_Canal.resultItem", "");
				}
				gxTv_SdtSDTResultadoEnvioComando_Canal_Result_N = 0;

				gxTv_SdtSDTResultadoEnvioComando_Canal_Result = value;
				SetDirty("Result");
			}
		}

		public void gxTv_SdtSDTResultadoEnvioComando_Canal_Result_SetNull()
		{
			gxTv_SdtSDTResultadoEnvioComando_Canal_Result_N = 1;

			gxTv_SdtSDTResultadoEnvioComando_Canal_Result = null;
			return  ;
		}

		public bool gxTv_SdtSDTResultadoEnvioComando_Canal_Result_IsNull()
		{
			if (gxTv_SdtSDTResultadoEnvioComando_Canal_Result == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Result_GxSimpleCollection_Json()
		{
				return gxTv_SdtSDTResultadoEnvioComando_Canal_Result != null && gxTv_SdtSDTResultadoEnvioComando_Canal_Result.Count > 0;

		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSDTResultadoEnvioComando_Canal_Result_N = 1;

			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtSDTResultadoEnvioComando_Canal_Result_N;
		protected GXBaseCollection<SdtSDTResultadoEnvioComando_Canal_resultItem> gxTv_SdtSDTResultadoEnvioComando_Canal_Result = null; 



		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SDTResultadoEnvioComando_Canal", Namespace="RastreamentoTCC")]
	public class SdtSDTResultadoEnvioComando_Canal_RESTInterface : GxGenericCollectionItem<SdtSDTResultadoEnvioComando_Canal>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTResultadoEnvioComando_Canal_RESTInterface( ) : base()
		{
		}

		public SdtSDTResultadoEnvioComando_Canal_RESTInterface( SdtSDTResultadoEnvioComando_Canal psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="result", Order=0, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTResultadoEnvioComando_Canal_resultItem_RESTInterface> gxTpr_Result
		{
			get {
				if (sdt.ShouldSerializegxTpr_Result_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTResultadoEnvioComando_Canal_resultItem_RESTInterface>(sdt.gxTpr_Result);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Result);
			}
		}


		#endregion

		public SdtSDTResultadoEnvioComando_Canal sdt
		{
			get { 
				return (SdtSDTResultadoEnvioComando_Canal)Sdt;
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
				sdt = new SdtSDTResultadoEnvioComando_Canal() ;
			}
		}
	}
	#endregion
}