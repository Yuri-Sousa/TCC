/*
				   File: type_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem
			Description: SDTRelatorioPosicoes
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
	[XmlRoot(ElementName="SDTRelatorioPosicoesItem")]
	[XmlType(TypeName="SDTRelatorioPosicoesItem" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem : GxUserType
	{
		public SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Datahora = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Placa = "";

			gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Endereco = "";

			gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Latlng = "";

			gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Ignicao = "";

			gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Tensao = "";

			gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Velocidade = "";

			gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Evento = "";

			gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Odometro = "";

			gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Horimetro = "";

		}

		public SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem(IGxContext context)
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
			datetime_STZ = gxTpr_Datahora;
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
			AddObjectProperty("DataHora", sDateCnv, false);


			AddObjectProperty("Placa", gxTpr_Placa, false);


			AddObjectProperty("Endereco", gxTpr_Endereco, false);


			AddObjectProperty("LatLng", gxTpr_Latlng, false);


			AddObjectProperty("Ignicao", gxTpr_Ignicao, false);


			AddObjectProperty("Tensao", gxTpr_Tensao, false);


			AddObjectProperty("TensaoNumeric", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Tensaonumeric, 16, 3)), false);


			AddObjectProperty("Velocidade", gxTpr_Velocidade, false);


			AddObjectProperty("VelocidadeNumeric", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Velocidadenumeric, 16, 0)), false);


			AddObjectProperty("Evento", gxTpr_Evento, false);


			AddObjectProperty("Odometro", gxTpr_Odometro, false);


			AddObjectProperty("Horimetro", gxTpr_Horimetro, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="DataHora")]
		[XmlElement(ElementName="DataHora" , IsNullable=true)]
		public string gxTpr_Datahora_Nullable
		{
			get {
				if ( gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Datahora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Datahora).value ;
			}
			set {
				gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Datahora = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Datahora
		{
			get { 
				return gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Datahora; 
			}
			set { 
				gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Datahora = value;
				SetDirty("Datahora");
			}
		}



		[SoapElement(ElementName="Placa")]
		[XmlElement(ElementName="Placa")]
		public string gxTpr_Placa
		{
			get { 
				return gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Placa; 
			}
			set { 
				gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Placa = value;
				SetDirty("Placa");
			}
		}




		[SoapElement(ElementName="Endereco")]
		[XmlElement(ElementName="Endereco")]
		public string gxTpr_Endereco
		{
			get { 
				return gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Endereco; 
			}
			set { 
				gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Endereco = value;
				SetDirty("Endereco");
			}
		}




		[SoapElement(ElementName="LatLng")]
		[XmlElement(ElementName="LatLng")]
		public string gxTpr_Latlng
		{
			get { 
				return gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Latlng; 
			}
			set { 
				gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Latlng = value;
				SetDirty("Latlng");
			}
		}




		[SoapElement(ElementName="Ignicao")]
		[XmlElement(ElementName="Ignicao")]
		public string gxTpr_Ignicao
		{
			get { 
				return gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Ignicao; 
			}
			set { 
				gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Ignicao = value;
				SetDirty("Ignicao");
			}
		}




		[SoapElement(ElementName="Tensao")]
		[XmlElement(ElementName="Tensao")]
		public string gxTpr_Tensao
		{
			get { 
				return gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Tensao; 
			}
			set { 
				gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Tensao = value;
				SetDirty("Tensao");
			}
		}



		[SoapElement(ElementName="TensaoNumeric")]
		[XmlElement(ElementName="TensaoNumeric")]
		public string gxTpr_Tensaonumeric_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Tensaonumeric, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Tensaonumeric = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Tensaonumeric
		{
			get { 
				return gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Tensaonumeric; 
			}
			set { 
				gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Tensaonumeric = value;
				SetDirty("Tensaonumeric");
			}
		}




		[SoapElement(ElementName="Velocidade")]
		[XmlElement(ElementName="Velocidade")]
		public string gxTpr_Velocidade
		{
			get { 
				return gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Velocidade; 
			}
			set { 
				gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Velocidade = value;
				SetDirty("Velocidade");
			}
		}




		[SoapElement(ElementName="VelocidadeNumeric")]
		[XmlElement(ElementName="VelocidadeNumeric")]
		public long gxTpr_Velocidadenumeric
		{
			get { 
				return gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Velocidadenumeric; 
			}
			set { 
				gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Velocidadenumeric = value;
				SetDirty("Velocidadenumeric");
			}
		}




		[SoapElement(ElementName="Evento")]
		[XmlElement(ElementName="Evento")]
		public string gxTpr_Evento
		{
			get { 
				return gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Evento; 
			}
			set { 
				gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Evento = value;
				SetDirty("Evento");
			}
		}




		[SoapElement(ElementName="Odometro")]
		[XmlElement(ElementName="Odometro")]
		public string gxTpr_Odometro
		{
			get { 
				return gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Odometro; 
			}
			set { 
				gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Odometro = value;
				SetDirty("Odometro");
			}
		}




		[SoapElement(ElementName="Horimetro")]
		[XmlElement(ElementName="Horimetro")]
		public string gxTpr_Horimetro
		{
			get { 
				return gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Horimetro; 
			}
			set { 
				gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Horimetro = value;
				SetDirty("Horimetro");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Datahora = (DateTime)(DateTime.MinValue);
			gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Placa = "";
			gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Endereco = "";
			gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Latlng = "";
			gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Ignicao = "";
			gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Tensao = "";

			gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Velocidade = "";

			gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Evento = "";
			gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Odometro = "";
			gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Horimetro = "";
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

		protected DateTime gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Datahora;
		 

		protected string gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Placa;
		 

		protected string gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Endereco;
		 

		protected string gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Latlng;
		 

		protected string gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Ignicao;
		 

		protected string gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Tensao;
		 

		protected decimal gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Tensaonumeric;
		 

		protected string gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Velocidade;
		 

		protected long gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Velocidadenumeric;
		 

		protected string gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Evento;
		 

		protected string gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Odometro;
		 

		protected string gxTv_SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_Horimetro;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SDTRelatorioPosicoesItem", Namespace="RastreamentoTCC")]
	public class SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_RESTInterface : GxGenericCollectionItem<SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_RESTInterface( ) : base()
		{
		}

		public SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem_RESTInterface( SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="DataHora", Order=0)]
		public  string gxTpr_Datahora
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Datahora);

			}
			set { 
				sdt.gxTpr_Datahora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="Placa", Order=1)]
		public  string gxTpr_Placa
		{
			get { 
				return sdt.gxTpr_Placa;

			}
			set { 
				 sdt.gxTpr_Placa = value;
			}
		}

		[DataMember(Name="Endereco", Order=2)]
		public  string gxTpr_Endereco
		{
			get { 
				return sdt.gxTpr_Endereco;

			}
			set { 
				 sdt.gxTpr_Endereco = value;
			}
		}

		[DataMember(Name="LatLng", Order=3)]
		public  string gxTpr_Latlng
		{
			get { 
				return sdt.gxTpr_Latlng;

			}
			set { 
				 sdt.gxTpr_Latlng = value;
			}
		}

		[DataMember(Name="Ignicao", Order=4)]
		public  string gxTpr_Ignicao
		{
			get { 
				return sdt.gxTpr_Ignicao;

			}
			set { 
				 sdt.gxTpr_Ignicao = value;
			}
		}

		[DataMember(Name="Tensao", Order=5)]
		public  string gxTpr_Tensao
		{
			get { 
				return sdt.gxTpr_Tensao;

			}
			set { 
				 sdt.gxTpr_Tensao = value;
			}
		}

		[DataMember(Name="TensaoNumeric", Order=6)]
		public  string gxTpr_Tensaonumeric
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tensaonumeric, 16, 3));

			}
			set { 
				sdt.gxTpr_Tensaonumeric =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Velocidade", Order=7)]
		public  string gxTpr_Velocidade
		{
			get { 
				return sdt.gxTpr_Velocidade;

			}
			set { 
				 sdt.gxTpr_Velocidade = value;
			}
		}

		[DataMember(Name="VelocidadeNumeric", Order=8)]
		public  string gxTpr_Velocidadenumeric
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Velocidadenumeric, 16, 0));

			}
			set { 
				sdt.gxTpr_Velocidadenumeric = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Evento", Order=9)]
		public  string gxTpr_Evento
		{
			get { 
				return sdt.gxTpr_Evento;

			}
			set { 
				 sdt.gxTpr_Evento = value;
			}
		}

		[DataMember(Name="Odometro", Order=10)]
		public  string gxTpr_Odometro
		{
			get { 
				return sdt.gxTpr_Odometro;

			}
			set { 
				 sdt.gxTpr_Odometro = value;
			}
		}

		[DataMember(Name="Horimetro", Order=11)]
		public  string gxTpr_Horimetro
		{
			get { 
				return sdt.gxTpr_Horimetro;

			}
			set { 
				 sdt.gxTpr_Horimetro = value;
			}
		}


		#endregion

		public SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem sdt
		{
			get { 
				return (SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem)Sdt;
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
				sdt = new SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem() ;
			}
		}
	}
	#endregion
}