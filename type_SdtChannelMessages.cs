/*
				   File: type_SdtChannelMessages
			Description: ChannelMessages
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
	[XmlRoot(ElementName="ChannelMessages")]
	[XmlType(TypeName="ChannelMessages" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtChannelMessages : GxUserType
	{
		public SdtChannelMessages( )
		{
			/* Constructor for serialization */
		}

		public SdtChannelMessages(IGxContext context)
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
			if (gxTv_SdtChannelMessages_Result != null)
			{
				AddObjectProperty("result", gxTv_SdtChannelMessages_Result, false);  
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="result" )]
		[XmlArray(ElementName="result"  )]
		[XmlArrayItemAttribute(ElementName="resultItem" , IsNullable=false )]
		public GXBaseCollection<SdtChannelMessages_resultItem> gxTpr_Result
		{
			get {
				if ( gxTv_SdtChannelMessages_Result == null )
				{
					gxTv_SdtChannelMessages_Result = new GXBaseCollection<SdtChannelMessages_resultItem>( context, "ChannelMessages.resultItem", "");
				}
				return gxTv_SdtChannelMessages_Result;
			}
			set {
				if ( gxTv_SdtChannelMessages_Result == null )
				{
					gxTv_SdtChannelMessages_Result = new GXBaseCollection<SdtChannelMessages_resultItem>( context, "ChannelMessages.resultItem", "");
				}
				gxTv_SdtChannelMessages_Result_N = 0;

				gxTv_SdtChannelMessages_Result = value;
				SetDirty("Result");
			}
		}

		public void gxTv_SdtChannelMessages_Result_SetNull()
		{
			gxTv_SdtChannelMessages_Result_N = 1;

			gxTv_SdtChannelMessages_Result = null;
			return  ;
		}

		public bool gxTv_SdtChannelMessages_Result_IsNull()
		{
			if (gxTv_SdtChannelMessages_Result == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Result_GxSimpleCollection_Json()
		{
				return gxTv_SdtChannelMessages_Result != null && gxTv_SdtChannelMessages_Result.Count > 0;

		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtChannelMessages_Result_N = 1;

			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtChannelMessages_Result_N;
		protected GXBaseCollection<SdtChannelMessages_resultItem> gxTv_SdtChannelMessages_Result = null; 



		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"ChannelMessages", Namespace="RastreamentoTCC")]
	public class SdtChannelMessages_RESTInterface : GxGenericCollectionItem<SdtChannelMessages>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtChannelMessages_RESTInterface( ) : base()
		{
		}

		public SdtChannelMessages_RESTInterface( SdtChannelMessages psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="result", Order=0, EmitDefaultValue=false)]
		public GxGenericCollection<SdtChannelMessages_resultItem_RESTInterface> gxTpr_Result
		{
			get {
				if (sdt.ShouldSerializegxTpr_Result_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtChannelMessages_resultItem_RESTInterface>(sdt.gxTpr_Result);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Result);
			}
		}


		#endregion

		public SdtChannelMessages sdt
		{
			get { 
				return (SdtChannelMessages)Sdt;
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
				sdt = new SdtChannelMessages() ;
			}
		}
	}
	#endregion
}