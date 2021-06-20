/*
				   File: type_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem
			Description: SDTRelatorioUtilizacao
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
	[XmlRoot(ElementName="SDTRelatorioUtilizacaoItem")]
	[XmlType(TypeName="SDTRelatorioUtilizacaoItem" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem : GxUserType
	{
		public SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Placa = "";

			gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Datahorainicial = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Datahorafinal = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Nome = "";

		}

		public SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem(IGxContext context)
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


			AddObjectProperty("DistanciaTotal", gxTpr_Distanciatotal, false);


			AddObjectProperty("ConsumoTotal", gxTpr_Consumototal, false);


			AddObjectProperty("ValorCombustivel", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Valorcombustivel, 16, 2)), false);


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
				return gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Placa; 
			}
			set { 
				gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Placa = value;
				SetDirty("Placa");
			}
		}



		[SoapElement(ElementName="DataHoraInicial")]
		[XmlElement(ElementName="DataHoraInicial" , IsNullable=true)]
		public string gxTpr_Datahorainicial_Nullable
		{
			get {
				if ( gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Datahorainicial == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Datahorainicial).value ;
			}
			set {
				gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Datahorainicial = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Datahorainicial
		{
			get { 
				return gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Datahorainicial; 
			}
			set { 
				gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Datahorainicial = value;
				SetDirty("Datahorainicial");
			}
		}


		[SoapElement(ElementName="DataHoraFinal")]
		[XmlElement(ElementName="DataHoraFinal" , IsNullable=true)]
		public string gxTpr_Datahorafinal_Nullable
		{
			get {
				if ( gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Datahorafinal == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Datahorafinal).value ;
			}
			set {
				gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Datahorafinal = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Datahorafinal
		{
			get { 
				return gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Datahorafinal; 
			}
			set { 
				gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Datahorafinal = value;
				SetDirty("Datahorafinal");
			}
		}


		[SoapElement(ElementName="DistanciaTotal")]
		[XmlElement(ElementName="DistanciaTotal")]
		public string gxTpr_Distanciatotal_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Distanciatotal, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Distanciatotal = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Distanciatotal
		{
			get { 
				return gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Distanciatotal; 
			}
			set { 
				gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Distanciatotal = value;
				SetDirty("Distanciatotal");
			}
		}



		[SoapElement(ElementName="ConsumoTotal")]
		[XmlElement(ElementName="ConsumoTotal")]
		public string gxTpr_Consumototal_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Consumototal, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Consumototal = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Consumototal
		{
			get { 
				return gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Consumototal; 
			}
			set { 
				gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Consumototal = value;
				SetDirty("Consumototal");
			}
		}



		[SoapElement(ElementName="ValorCombustivel")]
		[XmlElement(ElementName="ValorCombustivel")]
		public string gxTpr_Valorcombustivel_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Valorcombustivel, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Valorcombustivel = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Valorcombustivel
		{
			get { 
				return gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Valorcombustivel; 
			}
			set { 
				gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Valorcombustivel = value;
				SetDirty("Valorcombustivel");
			}
		}




		[SoapElement(ElementName="Nome")]
		[XmlElement(ElementName="Nome")]
		public string gxTpr_Nome
		{
			get { 
				return gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Nome; 
			}
			set { 
				gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Nome = value;
				SetDirty("Nome");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Placa = "";
			gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Datahorainicial = (DateTime)(DateTime.MinValue);
			gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Datahorafinal = (DateTime)(DateTime.MinValue);



			gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Nome = "";
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

		protected string gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Placa;
		 

		protected DateTime gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Datahorainicial;
		 

		protected DateTime gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Datahorafinal;
		 

		protected decimal gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Distanciatotal;
		 

		protected decimal gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Consumototal;
		 

		protected decimal gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Valorcombustivel;
		 

		protected string gxTv_SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_Nome;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SDTRelatorioUtilizacaoItem", Namespace="RastreamentoTCC")]
	public class SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_RESTInterface : GxGenericCollectionItem<SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_RESTInterface( ) : base()
		{
		}

		public SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem_RESTInterface( SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem psdt ) : base(psdt)
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

		[DataMember(Name="DistanciaTotal", Order=3)]
		public  string gxTpr_Distanciatotal
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Distanciatotal, 10, 2));

			}
			set { 
				sdt.gxTpr_Distanciatotal =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ConsumoTotal", Order=4)]
		public  string gxTpr_Consumototal
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Consumototal, 10, 2));

			}
			set { 
				sdt.gxTpr_Consumototal =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ValorCombustivel", Order=5)]
		public  string gxTpr_Valorcombustivel
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Valorcombustivel, 16, 2));

			}
			set { 
				sdt.gxTpr_Valorcombustivel =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Nome", Order=6)]
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

		public SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem sdt
		{
			get { 
				return (SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem)Sdt;
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
				sdt = new SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem() ;
			}
		}
	}
	#endregion
}