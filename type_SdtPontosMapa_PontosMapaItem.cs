/*
				   File: type_SdtPontosMapa_PontosMapaItem
			Description: PontosMapa
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
	[XmlRoot(ElementName="PontosMapaItem")]
	[XmlType(TypeName="PontosMapaItem" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtPontosMapa_PontosMapaItem : GxUserType
	{
		public SdtPontosMapa_PontosMapaItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtPontosMapa_PontosMapaItem_Ident = "";

			gxTv_SdtPontosMapa_PontosMapaItem_Pontoslatitude = "";

			gxTv_SdtPontosMapa_PontosMapaItem_Pontoslongitude = "";

			gxTv_SdtPontosMapa_PontosMapaItem_Pontostitulo = "";

			gxTv_SdtPontosMapa_PontosMapaItem_Veiculoplaca = "";

			gxTv_SdtPontosMapa_PontosMapaItem_Urlicone = "";

			gxTv_SdtPontosMapa_PontosMapaItem_Ignicao = "";

			gxTv_SdtPontosMapa_PontosMapaItem_Velocidade = "";

			gxTv_SdtPontosMapa_PontosMapaItem_Datahoraposicao = "";

			gxTv_SdtPontosMapa_PontosMapaItem_Endereco = "";

			gxTv_SdtPontosMapa_PontosMapaItem_Tensaobateria = "";

			gxTv_SdtPontosMapa_PontosMapaItem_Modelorastreador = "";

			gxTv_SdtPontosMapa_PontosMapaItem_Veiculoroubado = "";

			gxTv_SdtPontosMapa_PontosMapaItem_Motorista = "";

			gxTv_SdtPontosMapa_PontosMapaItem_Conteudobalaohtml = "";

		}

		public SdtPontosMapa_PontosMapaItem(IGxContext context)
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
			AddObjectProperty("PontosId", gxTpr_Pontosid, false);


			AddObjectProperty("ident", gxTpr_Ident, false);


			AddObjectProperty("PontosLatitude", gxTpr_Pontoslatitude, false);


			AddObjectProperty("PontosLongitude", gxTpr_Pontoslongitude, false);


			AddObjectProperty("PontosTitulo", gxTpr_Pontostitulo, false);


			AddObjectProperty("VeiculoPlaca", gxTpr_Veiculoplaca, false);


			AddObjectProperty("URLIcone", gxTpr_Urlicone, false);


			AddObjectProperty("Ignicao", gxTpr_Ignicao, false);


			AddObjectProperty("Velocidade", gxTpr_Velocidade, false);


			AddObjectProperty("DataHoraPosicao", gxTpr_Datahoraposicao, false);


			AddObjectProperty("Endereco", gxTpr_Endereco, false);


			AddObjectProperty("TensaoBateria", gxTpr_Tensaobateria, false);


			AddObjectProperty("ModeloRastreador", gxTpr_Modelorastreador, false);


			AddObjectProperty("RastreadorId", gxTpr_Rastreadorid, false);


			AddObjectProperty("MostrarEnvioComandos", gxTpr_Mostrarenviocomandos, false);


			AddObjectProperty("VeiculoRoubado", gxTpr_Veiculoroubado, false);


			AddObjectProperty("Motorista", gxTpr_Motorista, false);


			AddObjectProperty("VeiculoId", gxTpr_Veiculoid, false);


			AddObjectProperty("UtilizarConteudoBalaoHTML", gxTpr_Utilizarconteudobalaohtml, false);


			AddObjectProperty("ConteudoBalaoHTML", gxTpr_Conteudobalaohtml, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PontosId")]
		[XmlElement(ElementName="PontosId")]
		public long gxTpr_Pontosid
		{
			get { 
				return gxTv_SdtPontosMapa_PontosMapaItem_Pontosid; 
			}
			set { 
				gxTv_SdtPontosMapa_PontosMapaItem_Pontosid = value;
				SetDirty("Pontosid");
			}
		}




		[SoapElement(ElementName="ident")]
		[XmlElement(ElementName="ident")]
		public string gxTpr_Ident
		{
			get { 
				return gxTv_SdtPontosMapa_PontosMapaItem_Ident; 
			}
			set { 
				gxTv_SdtPontosMapa_PontosMapaItem_Ident = value;
				SetDirty("Ident");
			}
		}




		[SoapElement(ElementName="PontosLatitude")]
		[XmlElement(ElementName="PontosLatitude")]
		public string gxTpr_Pontoslatitude
		{
			get { 
				return gxTv_SdtPontosMapa_PontosMapaItem_Pontoslatitude; 
			}
			set { 
				gxTv_SdtPontosMapa_PontosMapaItem_Pontoslatitude = value;
				SetDirty("Pontoslatitude");
			}
		}




		[SoapElement(ElementName="PontosLongitude")]
		[XmlElement(ElementName="PontosLongitude")]
		public string gxTpr_Pontoslongitude
		{
			get { 
				return gxTv_SdtPontosMapa_PontosMapaItem_Pontoslongitude; 
			}
			set { 
				gxTv_SdtPontosMapa_PontosMapaItem_Pontoslongitude = value;
				SetDirty("Pontoslongitude");
			}
		}




		[SoapElement(ElementName="PontosTitulo")]
		[XmlElement(ElementName="PontosTitulo")]
		public string gxTpr_Pontostitulo
		{
			get { 
				return gxTv_SdtPontosMapa_PontosMapaItem_Pontostitulo; 
			}
			set { 
				gxTv_SdtPontosMapa_PontosMapaItem_Pontostitulo = value;
				SetDirty("Pontostitulo");
			}
		}




		[SoapElement(ElementName="VeiculoPlaca")]
		[XmlElement(ElementName="VeiculoPlaca")]
		public string gxTpr_Veiculoplaca
		{
			get { 
				return gxTv_SdtPontosMapa_PontosMapaItem_Veiculoplaca; 
			}
			set { 
				gxTv_SdtPontosMapa_PontosMapaItem_Veiculoplaca = value;
				SetDirty("Veiculoplaca");
			}
		}




		[SoapElement(ElementName="URLIcone")]
		[XmlElement(ElementName="URLIcone")]
		public string gxTpr_Urlicone
		{
			get { 
				return gxTv_SdtPontosMapa_PontosMapaItem_Urlicone; 
			}
			set { 
				gxTv_SdtPontosMapa_PontosMapaItem_Urlicone = value;
				SetDirty("Urlicone");
			}
		}




		[SoapElement(ElementName="Ignicao")]
		[XmlElement(ElementName="Ignicao")]
		public string gxTpr_Ignicao
		{
			get { 
				return gxTv_SdtPontosMapa_PontosMapaItem_Ignicao; 
			}
			set { 
				gxTv_SdtPontosMapa_PontosMapaItem_Ignicao = value;
				SetDirty("Ignicao");
			}
		}




		[SoapElement(ElementName="Velocidade")]
		[XmlElement(ElementName="Velocidade")]
		public string gxTpr_Velocidade
		{
			get { 
				return gxTv_SdtPontosMapa_PontosMapaItem_Velocidade; 
			}
			set { 
				gxTv_SdtPontosMapa_PontosMapaItem_Velocidade = value;
				SetDirty("Velocidade");
			}
		}




		[SoapElement(ElementName="DataHoraPosicao")]
		[XmlElement(ElementName="DataHoraPosicao")]
		public string gxTpr_Datahoraposicao
		{
			get { 
				return gxTv_SdtPontosMapa_PontosMapaItem_Datahoraposicao; 
			}
			set { 
				gxTv_SdtPontosMapa_PontosMapaItem_Datahoraposicao = value;
				SetDirty("Datahoraposicao");
			}
		}




		[SoapElement(ElementName="Endereco")]
		[XmlElement(ElementName="Endereco")]
		public string gxTpr_Endereco
		{
			get { 
				return gxTv_SdtPontosMapa_PontosMapaItem_Endereco; 
			}
			set { 
				gxTv_SdtPontosMapa_PontosMapaItem_Endereco = value;
				SetDirty("Endereco");
			}
		}




		[SoapElement(ElementName="TensaoBateria")]
		[XmlElement(ElementName="TensaoBateria")]
		public string gxTpr_Tensaobateria
		{
			get { 
				return gxTv_SdtPontosMapa_PontosMapaItem_Tensaobateria; 
			}
			set { 
				gxTv_SdtPontosMapa_PontosMapaItem_Tensaobateria = value;
				SetDirty("Tensaobateria");
			}
		}




		[SoapElement(ElementName="ModeloRastreador")]
		[XmlElement(ElementName="ModeloRastreador")]
		public string gxTpr_Modelorastreador
		{
			get { 
				return gxTv_SdtPontosMapa_PontosMapaItem_Modelorastreador; 
			}
			set { 
				gxTv_SdtPontosMapa_PontosMapaItem_Modelorastreador = value;
				SetDirty("Modelorastreador");
			}
		}




		[SoapElement(ElementName="RastreadorId")]
		[XmlElement(ElementName="RastreadorId")]
		public int gxTpr_Rastreadorid
		{
			get { 
				return gxTv_SdtPontosMapa_PontosMapaItem_Rastreadorid; 
			}
			set { 
				gxTv_SdtPontosMapa_PontosMapaItem_Rastreadorid = value;
				SetDirty("Rastreadorid");
			}
		}




		[SoapElement(ElementName="MostrarEnvioComandos")]
		[XmlElement(ElementName="MostrarEnvioComandos")]
		public bool gxTpr_Mostrarenviocomandos
		{
			get { 
				return gxTv_SdtPontosMapa_PontosMapaItem_Mostrarenviocomandos; 
			}
			set { 
				gxTv_SdtPontosMapa_PontosMapaItem_Mostrarenviocomandos = value;
				SetDirty("Mostrarenviocomandos");
			}
		}




		[SoapElement(ElementName="VeiculoRoubado")]
		[XmlElement(ElementName="VeiculoRoubado")]
		public string gxTpr_Veiculoroubado
		{
			get { 
				return gxTv_SdtPontosMapa_PontosMapaItem_Veiculoroubado; 
			}
			set { 
				gxTv_SdtPontosMapa_PontosMapaItem_Veiculoroubado = value;
				SetDirty("Veiculoroubado");
			}
		}




		[SoapElement(ElementName="Motorista")]
		[XmlElement(ElementName="Motorista")]
		public string gxTpr_Motorista
		{
			get { 
				return gxTv_SdtPontosMapa_PontosMapaItem_Motorista; 
			}
			set { 
				gxTv_SdtPontosMapa_PontosMapaItem_Motorista = value;
				SetDirty("Motorista");
			}
		}




		[SoapElement(ElementName="VeiculoId")]
		[XmlElement(ElementName="VeiculoId")]
		public int gxTpr_Veiculoid
		{
			get { 
				return gxTv_SdtPontosMapa_PontosMapaItem_Veiculoid; 
			}
			set { 
				gxTv_SdtPontosMapa_PontosMapaItem_Veiculoid = value;
				SetDirty("Veiculoid");
			}
		}




		[SoapElement(ElementName="UtilizarConteudoBalaoHTML")]
		[XmlElement(ElementName="UtilizarConteudoBalaoHTML")]
		public bool gxTpr_Utilizarconteudobalaohtml
		{
			get { 
				return gxTv_SdtPontosMapa_PontosMapaItem_Utilizarconteudobalaohtml; 
			}
			set { 
				gxTv_SdtPontosMapa_PontosMapaItem_Utilizarconteudobalaohtml = value;
				SetDirty("Utilizarconteudobalaohtml");
			}
		}




		[SoapElement(ElementName="ConteudoBalaoHTML")]
		[XmlElement(ElementName="ConteudoBalaoHTML")]
		public string gxTpr_Conteudobalaohtml
		{
			get { 
				return gxTv_SdtPontosMapa_PontosMapaItem_Conteudobalaohtml; 
			}
			set { 
				gxTv_SdtPontosMapa_PontosMapaItem_Conteudobalaohtml = value;
				SetDirty("Conteudobalaohtml");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtPontosMapa_PontosMapaItem_Ident = "";
			gxTv_SdtPontosMapa_PontosMapaItem_Pontoslatitude = "";
			gxTv_SdtPontosMapa_PontosMapaItem_Pontoslongitude = "";
			gxTv_SdtPontosMapa_PontosMapaItem_Pontostitulo = "";
			gxTv_SdtPontosMapa_PontosMapaItem_Veiculoplaca = "";
			gxTv_SdtPontosMapa_PontosMapaItem_Urlicone = "";
			gxTv_SdtPontosMapa_PontosMapaItem_Ignicao = "";
			gxTv_SdtPontosMapa_PontosMapaItem_Velocidade = "";
			gxTv_SdtPontosMapa_PontosMapaItem_Datahoraposicao = "";
			gxTv_SdtPontosMapa_PontosMapaItem_Endereco = "";
			gxTv_SdtPontosMapa_PontosMapaItem_Tensaobateria = "";
			gxTv_SdtPontosMapa_PontosMapaItem_Modelorastreador = "";


			gxTv_SdtPontosMapa_PontosMapaItem_Veiculoroubado = "";
			gxTv_SdtPontosMapa_PontosMapaItem_Motorista = "";


			gxTv_SdtPontosMapa_PontosMapaItem_Conteudobalaohtml = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtPontosMapa_PontosMapaItem_Pontosid;
		 

		protected string gxTv_SdtPontosMapa_PontosMapaItem_Ident;
		 

		protected string gxTv_SdtPontosMapa_PontosMapaItem_Pontoslatitude;
		 

		protected string gxTv_SdtPontosMapa_PontosMapaItem_Pontoslongitude;
		 

		protected string gxTv_SdtPontosMapa_PontosMapaItem_Pontostitulo;
		 

		protected string gxTv_SdtPontosMapa_PontosMapaItem_Veiculoplaca;
		 

		protected string gxTv_SdtPontosMapa_PontosMapaItem_Urlicone;
		 

		protected string gxTv_SdtPontosMapa_PontosMapaItem_Ignicao;
		 

		protected string gxTv_SdtPontosMapa_PontosMapaItem_Velocidade;
		 

		protected string gxTv_SdtPontosMapa_PontosMapaItem_Datahoraposicao;
		 

		protected string gxTv_SdtPontosMapa_PontosMapaItem_Endereco;
		 

		protected string gxTv_SdtPontosMapa_PontosMapaItem_Tensaobateria;
		 

		protected string gxTv_SdtPontosMapa_PontosMapaItem_Modelorastreador;
		 

		protected int gxTv_SdtPontosMapa_PontosMapaItem_Rastreadorid;
		 

		protected bool gxTv_SdtPontosMapa_PontosMapaItem_Mostrarenviocomandos;
		 

		protected string gxTv_SdtPontosMapa_PontosMapaItem_Veiculoroubado;
		 

		protected string gxTv_SdtPontosMapa_PontosMapaItem_Motorista;
		 

		protected int gxTv_SdtPontosMapa_PontosMapaItem_Veiculoid;
		 

		protected bool gxTv_SdtPontosMapa_PontosMapaItem_Utilizarconteudobalaohtml;
		 

		protected string gxTv_SdtPontosMapa_PontosMapaItem_Conteudobalaohtml;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"PontosMapaItem", Namespace="RastreamentoTCC")]
	public class SdtPontosMapa_PontosMapaItem_RESTInterface : GxGenericCollectionItem<SdtPontosMapa_PontosMapaItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtPontosMapa_PontosMapaItem_RESTInterface( ) : base()
		{
		}

		public SdtPontosMapa_PontosMapaItem_RESTInterface( SdtPontosMapa_PontosMapaItem psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="PontosId", Order=0)]
		public  string gxTpr_Pontosid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Pontosid, 10, 0));

			}
			set { 
				sdt.gxTpr_Pontosid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ident", Order=1)]
		public  string gxTpr_Ident
		{
			get { 
				return sdt.gxTpr_Ident;

			}
			set { 
				 sdt.gxTpr_Ident = value;
			}
		}

		[DataMember(Name="PontosLatitude", Order=2)]
		public  string gxTpr_Pontoslatitude
		{
			get { 
				return sdt.gxTpr_Pontoslatitude;

			}
			set { 
				 sdt.gxTpr_Pontoslatitude = value;
			}
		}

		[DataMember(Name="PontosLongitude", Order=3)]
		public  string gxTpr_Pontoslongitude
		{
			get { 
				return sdt.gxTpr_Pontoslongitude;

			}
			set { 
				 sdt.gxTpr_Pontoslongitude = value;
			}
		}

		[DataMember(Name="PontosTitulo", Order=4)]
		public  string gxTpr_Pontostitulo
		{
			get { 
				return sdt.gxTpr_Pontostitulo;

			}
			set { 
				 sdt.gxTpr_Pontostitulo = value;
			}
		}

		[DataMember(Name="VeiculoPlaca", Order=5)]
		public  string gxTpr_Veiculoplaca
		{
			get { 
				return sdt.gxTpr_Veiculoplaca;

			}
			set { 
				 sdt.gxTpr_Veiculoplaca = value;
			}
		}

		[DataMember(Name="URLIcone", Order=6)]
		public  string gxTpr_Urlicone
		{
			get { 
				return sdt.gxTpr_Urlicone;

			}
			set { 
				 sdt.gxTpr_Urlicone = value;
			}
		}

		[DataMember(Name="Ignicao", Order=7)]
		public  string gxTpr_Ignicao
		{
			get { 
				return sdt.gxTpr_Ignicao;

			}
			set { 
				 sdt.gxTpr_Ignicao = value;
			}
		}

		[DataMember(Name="Velocidade", Order=8)]
		public  string gxTpr_Velocidade
		{
			get { 
				return sdt.gxTpr_Velocidade;

			}
			set { 
				 sdt.gxTpr_Velocidade = value;
			}
		}

		[DataMember(Name="DataHoraPosicao", Order=9)]
		public  string gxTpr_Datahoraposicao
		{
			get { 
				return sdt.gxTpr_Datahoraposicao;

			}
			set { 
				 sdt.gxTpr_Datahoraposicao = value;
			}
		}

		[DataMember(Name="Endereco", Order=10)]
		public  string gxTpr_Endereco
		{
			get { 
				return sdt.gxTpr_Endereco;

			}
			set { 
				 sdt.gxTpr_Endereco = value;
			}
		}

		[DataMember(Name="TensaoBateria", Order=11)]
		public  string gxTpr_Tensaobateria
		{
			get { 
				return sdt.gxTpr_Tensaobateria;

			}
			set { 
				 sdt.gxTpr_Tensaobateria = value;
			}
		}

		[DataMember(Name="ModeloRastreador", Order=12)]
		public  string gxTpr_Modelorastreador
		{
			get { 
				return sdt.gxTpr_Modelorastreador;

			}
			set { 
				 sdt.gxTpr_Modelorastreador = value;
			}
		}

		[DataMember(Name="RastreadorId", Order=13)]
		public  string gxTpr_Rastreadorid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Rastreadorid, 8, 0));

			}
			set { 
				sdt.gxTpr_Rastreadorid = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MostrarEnvioComandos", Order=14)]
		public bool gxTpr_Mostrarenviocomandos
		{
			get { 
				return sdt.gxTpr_Mostrarenviocomandos;

			}
			set { 
				sdt.gxTpr_Mostrarenviocomandos = value;
			}
		}

		[DataMember(Name="VeiculoRoubado", Order=15)]
		public  string gxTpr_Veiculoroubado
		{
			get { 
				return sdt.gxTpr_Veiculoroubado;

			}
			set { 
				 sdt.gxTpr_Veiculoroubado = value;
			}
		}

		[DataMember(Name="Motorista", Order=16)]
		public  string gxTpr_Motorista
		{
			get { 
				return sdt.gxTpr_Motorista;

			}
			set { 
				 sdt.gxTpr_Motorista = value;
			}
		}

		[DataMember(Name="VeiculoId", Order=17)]
		public  string gxTpr_Veiculoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Veiculoid, 8, 0));

			}
			set { 
				sdt.gxTpr_Veiculoid = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="UtilizarConteudoBalaoHTML", Order=18)]
		public bool gxTpr_Utilizarconteudobalaohtml
		{
			get { 
				return sdt.gxTpr_Utilizarconteudobalaohtml;

			}
			set { 
				sdt.gxTpr_Utilizarconteudobalaohtml = value;
			}
		}

		[DataMember(Name="ConteudoBalaoHTML", Order=19)]
		public  string gxTpr_Conteudobalaohtml
		{
			get { 
				return sdt.gxTpr_Conteudobalaohtml;

			}
			set { 
				 sdt.gxTpr_Conteudobalaohtml = value;
			}
		}


		#endregion

		public SdtPontosMapa_PontosMapaItem sdt
		{
			get { 
				return (SdtPontosMapa_PontosMapaItem)Sdt;
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
				sdt = new SdtPontosMapa_PontosMapaItem() ;
			}
		}
	}
	#endregion
}