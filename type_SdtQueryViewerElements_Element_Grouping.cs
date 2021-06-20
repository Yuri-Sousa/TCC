/*
				   File: type_SdtQueryViewerElements_Element_Grouping
			Description: Grouping
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
	[XmlRoot(ElementName="QueryViewerElements.Element.Grouping")]
	[XmlType(TypeName="QueryViewerElements.Element.Grouping" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtQueryViewerElements_Element_Grouping : GxUserType
	{
		public SdtQueryViewerElements_Element_Grouping( )
		{
			/* Constructor for serialization */
			gxTv_SdtQueryViewerElements_Element_Grouping_Yeartitle = "";

			gxTv_SdtQueryViewerElements_Element_Grouping_Semestertitle = "";

			gxTv_SdtQueryViewerElements_Element_Grouping_Quartertitle = "";

			gxTv_SdtQueryViewerElements_Element_Grouping_Monthtitle = "";

			gxTv_SdtQueryViewerElements_Element_Grouping_Dayofweektitle = "";

		}

		public SdtQueryViewerElements_Element_Grouping(IGxContext context)
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
			AddObjectProperty("GroupByYear", gxTpr_Groupbyyear, false);


			AddObjectProperty("YearTitle", gxTpr_Yeartitle, false);


			AddObjectProperty("GroupBySemester", gxTpr_Groupbysemester, false);


			AddObjectProperty("SemesterTitle", gxTpr_Semestertitle, false);


			AddObjectProperty("GroupByQuarter", gxTpr_Groupbyquarter, false);


			AddObjectProperty("QuarterTitle", gxTpr_Quartertitle, false);


			AddObjectProperty("GroupByMonth", gxTpr_Groupbymonth, false);


			AddObjectProperty("MonthTitle", gxTpr_Monthtitle, false);


			AddObjectProperty("GroupByDayOfWeek", gxTpr_Groupbydayofweek, false);


			AddObjectProperty("DayOfWeekTitle", gxTpr_Dayofweektitle, false);


			AddObjectProperty("HideValue", gxTpr_Hidevalue, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="GroupByYear")]
		[XmlElement(ElementName="GroupByYear")]
		public bool gxTpr_Groupbyyear
		{
			get { 
				return gxTv_SdtQueryViewerElements_Element_Grouping_Groupbyyear; 
			}
			set { 
				gxTv_SdtQueryViewerElements_Element_Grouping_Groupbyyear = value;
				SetDirty("Groupbyyear");
			}
		}




		[SoapElement(ElementName="YearTitle")]
		[XmlElement(ElementName="YearTitle")]
		public string gxTpr_Yeartitle
		{
			get { 
				return gxTv_SdtQueryViewerElements_Element_Grouping_Yeartitle; 
			}
			set { 
				gxTv_SdtQueryViewerElements_Element_Grouping_Yeartitle = value;
				SetDirty("Yeartitle");
			}
		}




		[SoapElement(ElementName="GroupBySemester")]
		[XmlElement(ElementName="GroupBySemester")]
		public bool gxTpr_Groupbysemester
		{
			get { 
				return gxTv_SdtQueryViewerElements_Element_Grouping_Groupbysemester; 
			}
			set { 
				gxTv_SdtQueryViewerElements_Element_Grouping_Groupbysemester = value;
				SetDirty("Groupbysemester");
			}
		}




		[SoapElement(ElementName="SemesterTitle")]
		[XmlElement(ElementName="SemesterTitle")]
		public string gxTpr_Semestertitle
		{
			get { 
				return gxTv_SdtQueryViewerElements_Element_Grouping_Semestertitle; 
			}
			set { 
				gxTv_SdtQueryViewerElements_Element_Grouping_Semestertitle = value;
				SetDirty("Semestertitle");
			}
		}




		[SoapElement(ElementName="GroupByQuarter")]
		[XmlElement(ElementName="GroupByQuarter")]
		public bool gxTpr_Groupbyquarter
		{
			get { 
				return gxTv_SdtQueryViewerElements_Element_Grouping_Groupbyquarter; 
			}
			set { 
				gxTv_SdtQueryViewerElements_Element_Grouping_Groupbyquarter = value;
				SetDirty("Groupbyquarter");
			}
		}




		[SoapElement(ElementName="QuarterTitle")]
		[XmlElement(ElementName="QuarterTitle")]
		public string gxTpr_Quartertitle
		{
			get { 
				return gxTv_SdtQueryViewerElements_Element_Grouping_Quartertitle; 
			}
			set { 
				gxTv_SdtQueryViewerElements_Element_Grouping_Quartertitle = value;
				SetDirty("Quartertitle");
			}
		}




		[SoapElement(ElementName="GroupByMonth")]
		[XmlElement(ElementName="GroupByMonth")]
		public bool gxTpr_Groupbymonth
		{
			get { 
				return gxTv_SdtQueryViewerElements_Element_Grouping_Groupbymonth; 
			}
			set { 
				gxTv_SdtQueryViewerElements_Element_Grouping_Groupbymonth = value;
				SetDirty("Groupbymonth");
			}
		}




		[SoapElement(ElementName="MonthTitle")]
		[XmlElement(ElementName="MonthTitle")]
		public string gxTpr_Monthtitle
		{
			get { 
				return gxTv_SdtQueryViewerElements_Element_Grouping_Monthtitle; 
			}
			set { 
				gxTv_SdtQueryViewerElements_Element_Grouping_Monthtitle = value;
				SetDirty("Monthtitle");
			}
		}




		[SoapElement(ElementName="GroupByDayOfWeek")]
		[XmlElement(ElementName="GroupByDayOfWeek")]
		public bool gxTpr_Groupbydayofweek
		{
			get { 
				return gxTv_SdtQueryViewerElements_Element_Grouping_Groupbydayofweek; 
			}
			set { 
				gxTv_SdtQueryViewerElements_Element_Grouping_Groupbydayofweek = value;
				SetDirty("Groupbydayofweek");
			}
		}




		[SoapElement(ElementName="DayOfWeekTitle")]
		[XmlElement(ElementName="DayOfWeekTitle")]
		public string gxTpr_Dayofweektitle
		{
			get { 
				return gxTv_SdtQueryViewerElements_Element_Grouping_Dayofweektitle; 
			}
			set { 
				gxTv_SdtQueryViewerElements_Element_Grouping_Dayofweektitle = value;
				SetDirty("Dayofweektitle");
			}
		}




		[SoapElement(ElementName="HideValue")]
		[XmlElement(ElementName="HideValue")]
		public bool gxTpr_Hidevalue
		{
			get { 
				return gxTv_SdtQueryViewerElements_Element_Grouping_Hidevalue; 
			}
			set { 
				gxTv_SdtQueryViewerElements_Element_Grouping_Hidevalue = value;
				SetDirty("Hidevalue");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtQueryViewerElements_Element_Grouping_Yeartitle = "";

			gxTv_SdtQueryViewerElements_Element_Grouping_Semestertitle = "";

			gxTv_SdtQueryViewerElements_Element_Grouping_Quartertitle = "";

			gxTv_SdtQueryViewerElements_Element_Grouping_Monthtitle = "";

			gxTv_SdtQueryViewerElements_Element_Grouping_Dayofweektitle = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtQueryViewerElements_Element_Grouping_Groupbyyear;
		 

		protected string gxTv_SdtQueryViewerElements_Element_Grouping_Yeartitle;
		 

		protected bool gxTv_SdtQueryViewerElements_Element_Grouping_Groupbysemester;
		 

		protected string gxTv_SdtQueryViewerElements_Element_Grouping_Semestertitle;
		 

		protected bool gxTv_SdtQueryViewerElements_Element_Grouping_Groupbyquarter;
		 

		protected string gxTv_SdtQueryViewerElements_Element_Grouping_Quartertitle;
		 

		protected bool gxTv_SdtQueryViewerElements_Element_Grouping_Groupbymonth;
		 

		protected string gxTv_SdtQueryViewerElements_Element_Grouping_Monthtitle;
		 

		protected bool gxTv_SdtQueryViewerElements_Element_Grouping_Groupbydayofweek;
		 

		protected string gxTv_SdtQueryViewerElements_Element_Grouping_Dayofweektitle;
		 

		protected bool gxTv_SdtQueryViewerElements_Element_Grouping_Hidevalue;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"QueryViewerElements.Element.Grouping", Namespace="RastreamentoTCC")]
	public class SdtQueryViewerElements_Element_Grouping_RESTInterface : GxGenericCollectionItem<SdtQueryViewerElements_Element_Grouping>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtQueryViewerElements_Element_Grouping_RESTInterface( ) : base()
		{
		}

		public SdtQueryViewerElements_Element_Grouping_RESTInterface( SdtQueryViewerElements_Element_Grouping psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="GroupByYear", Order=0)]
		public bool gxTpr_Groupbyyear
		{
			get { 
				return sdt.gxTpr_Groupbyyear;

			}
			set { 
				sdt.gxTpr_Groupbyyear = value;
			}
		}

		[DataMember(Name="YearTitle", Order=1)]
		public  string gxTpr_Yeartitle
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Yeartitle);

			}
			set { 
				 sdt.gxTpr_Yeartitle = value;
			}
		}

		[DataMember(Name="GroupBySemester", Order=2)]
		public bool gxTpr_Groupbysemester
		{
			get { 
				return sdt.gxTpr_Groupbysemester;

			}
			set { 
				sdt.gxTpr_Groupbysemester = value;
			}
		}

		[DataMember(Name="SemesterTitle", Order=3)]
		public  string gxTpr_Semestertitle
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Semestertitle);

			}
			set { 
				 sdt.gxTpr_Semestertitle = value;
			}
		}

		[DataMember(Name="GroupByQuarter", Order=4)]
		public bool gxTpr_Groupbyquarter
		{
			get { 
				return sdt.gxTpr_Groupbyquarter;

			}
			set { 
				sdt.gxTpr_Groupbyquarter = value;
			}
		}

		[DataMember(Name="QuarterTitle", Order=5)]
		public  string gxTpr_Quartertitle
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Quartertitle);

			}
			set { 
				 sdt.gxTpr_Quartertitle = value;
			}
		}

		[DataMember(Name="GroupByMonth", Order=6)]
		public bool gxTpr_Groupbymonth
		{
			get { 
				return sdt.gxTpr_Groupbymonth;

			}
			set { 
				sdt.gxTpr_Groupbymonth = value;
			}
		}

		[DataMember(Name="MonthTitle", Order=7)]
		public  string gxTpr_Monthtitle
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Monthtitle);

			}
			set { 
				 sdt.gxTpr_Monthtitle = value;
			}
		}

		[DataMember(Name="GroupByDayOfWeek", Order=8)]
		public bool gxTpr_Groupbydayofweek
		{
			get { 
				return sdt.gxTpr_Groupbydayofweek;

			}
			set { 
				sdt.gxTpr_Groupbydayofweek = value;
			}
		}

		[DataMember(Name="DayOfWeekTitle", Order=9)]
		public  string gxTpr_Dayofweektitle
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Dayofweektitle);

			}
			set { 
				 sdt.gxTpr_Dayofweektitle = value;
			}
		}

		[DataMember(Name="HideValue", Order=10)]
		public bool gxTpr_Hidevalue
		{
			get { 
				return sdt.gxTpr_Hidevalue;

			}
			set { 
				sdt.gxTpr_Hidevalue = value;
			}
		}


		#endregion

		public SdtQueryViewerElements_Element_Grouping sdt
		{
			get { 
				return (SdtQueryViewerElements_Element_Grouping)Sdt;
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
				sdt = new SdtQueryViewerElements_Element_Grouping() ;
			}
		}
	}
	#endregion
}