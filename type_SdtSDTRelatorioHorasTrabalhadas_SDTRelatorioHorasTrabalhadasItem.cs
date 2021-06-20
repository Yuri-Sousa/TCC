/*
				   File: type_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem
			Description: SDTRelatorioHorasTrabalhadas
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
	[XmlRoot(ElementName="SDTRelatorioHorasTrabalhadasItem")]
	[XmlType(TypeName="SDTRelatorioHorasTrabalhadasItem" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem : GxUserType
	{
		public SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Placa = "";

			gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Datahorainicial = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Datahorafinal = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Tempofuncionamento = "";

			gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Tempoocioso = "";

			gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Nome = "";

		}

		public SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem(IGxContext context)
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
			AddObjectProperty("Placa", gxTpr_Placa, false);


			datetime_STZ = gxTpr_Datahorainicial;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("DataHoraInicial", sDateCnv, false);


			datetime_STZ = gxTpr_Datahorafinal;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("DataHoraFinal", sDateCnv, false);


			AddObjectProperty("TempoFuncionamento", gxTpr_Tempofuncionamento, false);


			AddObjectProperty("TempoOcioso", gxTpr_Tempoocioso, false);


			AddObjectProperty("Nome", gxTpr_Nome, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Placa")]
		[XmlElement(ElementName="Placa")]
		public string gxTpr_Placa
		{
			get { 
				return gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Placa; 
			}
			set { 
				gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Placa = value;
				SetDirty("Placa");
			}
		}



		[SoapElement(ElementName="DataHoraInicial")]
		[XmlElement(ElementName="DataHoraInicial" , IsNullable=true)]
		public string gxTpr_Datahorainicial_Nullable
		{
			get {
				if ( gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Datahorainicial == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Datahorainicial).value ;
			}
			set {
				gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Datahorainicial = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Datahorainicial
		{
			get { 
				return gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Datahorainicial; 
			}
			set { 
				gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Datahorainicial = value;
				SetDirty("Datahorainicial");
			}
		}


		[SoapElement(ElementName="DataHoraFinal")]
		[XmlElement(ElementName="DataHoraFinal" , IsNullable=true)]
		public string gxTpr_Datahorafinal_Nullable
		{
			get {
				if ( gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Datahorafinal == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Datahorafinal).value ;
			}
			set {
				gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Datahorafinal = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Datahorafinal
		{
			get { 
				return gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Datahorafinal; 
			}
			set { 
				gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Datahorafinal = value;
				SetDirty("Datahorafinal");
			}
		}



		[SoapElement(ElementName="TempoFuncionamento")]
		[XmlElement(ElementName="TempoFuncionamento")]
		public string gxTpr_Tempofuncionamento
		{
			get { 
				return gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Tempofuncionamento; 
			}
			set { 
				gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Tempofuncionamento = value;
				SetDirty("Tempofuncionamento");
			}
		}




		[SoapElement(ElementName="TempoOcioso")]
		[XmlElement(ElementName="TempoOcioso")]
		public string gxTpr_Tempoocioso
		{
			get { 
				return gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Tempoocioso; 
			}
			set { 
				gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Tempoocioso = value;
				SetDirty("Tempoocioso");
			}
		}




		[SoapElement(ElementName="Nome")]
		[XmlElement(ElementName="Nome")]
		public string gxTpr_Nome
		{
			get { 
				return gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Nome; 
			}
			set { 
				gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Nome = value;
				SetDirty("Nome");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Placa = "";
			gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Datahorainicial = (DateTime)(DateTime.MinValue);
			gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Datahorafinal = (DateTime)(DateTime.MinValue);
			gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Tempofuncionamento = "";
			gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Tempoocioso = "";
			gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Nome = "";
			datetime_STZ = (DateTime)(DateTime.MinValue);
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected DateTime datetime_STZ ;

		protected string gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Placa;
		 

		protected DateTime gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Datahorainicial;
		 

		protected DateTime gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Datahorafinal;
		 

		protected string gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Tempofuncionamento;
		 

		protected string gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Tempoocioso;
		 

		protected string gxTv_SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_Nome;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SDTRelatorioHorasTrabalhadasItem", Namespace="RastreamentoTCC")]
	public class SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_RESTInterface : GxGenericCollectionItem<SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_RESTInterface( ) : base()
		{
		}

		public SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem_RESTInterface( SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="Placa", Order=0)]
		public  string gxTpr_Placa
		{
			get { 
				return sdt.gxTpr_Placa;

			}
			set { 
				 sdt.gxTpr_Placa = value;
			}
		}

		[DataMember(Name="DataHoraInicial", Order=1)]
		public  string gxTpr_Datahorainicial
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Datahorainicial);

			}
			set { 
				sdt.gxTpr_Datahorainicial = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="DataHoraFinal", Order=2)]
		public  string gxTpr_Datahorafinal
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Datahorafinal);

			}
			set { 
				sdt.gxTpr_Datahorafinal = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="TempoFuncionamento", Order=3)]
		public  string gxTpr_Tempofuncionamento
		{
			get { 
				return sdt.gxTpr_Tempofuncionamento;

			}
			set { 
				 sdt.gxTpr_Tempofuncionamento = value;
			}
		}

		[DataMember(Name="TempoOcioso", Order=4)]
		public  string gxTpr_Tempoocioso
		{
			get { 
				return sdt.gxTpr_Tempoocioso;

			}
			set { 
				 sdt.gxTpr_Tempoocioso = value;
			}
		}

		[DataMember(Name="Nome", Order=5)]
		public  string gxTpr_Nome
		{
			get { 
				return sdt.gxTpr_Nome;

			}
			set { 
				 sdt.gxTpr_Nome = value;
			}
		}


		#endregion

		public SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem sdt
		{
			get { 
				return (SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem)Sdt;
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
				sdt = new SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem() ;
			}
		}
	}
	#endregion
}