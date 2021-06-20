/*
				   File: type_SdtDVB_SDTDropDownOptionsTitleSettingsIcons
			Description: DVB_SDTDropDownOptionsTitleSettingsIcons
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
	[XmlRoot(ElementName="TitleSettingsIcons")]
	[XmlType(TypeName="TitleSettingsIcons" , Namespace="" )]
	[Serializable]
	public class SdtDVB_SDTDropDownOptionsTitleSettingsIcons : GxUserType
	{
		public SdtDVB_SDTDropDownOptionsTitleSettingsIcons( )
		{
			/* Constructor for serialization */
			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Default_fi = "";

			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Filtered_fi = "";

			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Sortedasc_fi = "";

			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Sorteddsc_fi = "";

			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Filteredsortedasc_fi = "";

			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Filteredsorteddsc_fi = "";

			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Optionsortasc_fi = "";

			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Optionsortdsc_fi = "";

			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Optionapplyfilter_fi = "";

			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Optionfilteringdata_fi = "";

			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Optioncleanfilters_fi = "";

			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Selectedoption_fi = "";

			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Multiseloption_fi = "";

			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Multiselseloption_fi = "";

			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Treeviewcollapse_fi = "";

			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Treeviewexpand_fi = "";

			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Fixleft_fi = "";

			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Fixright_fi = "";

		}

		public SdtDVB_SDTDropDownOptionsTitleSettingsIcons(IGxContext context)
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
				mapper["def"] = "Default_fi";
				mapper["fil"] = "Filtered_fi";
				mapper["asc"] = "Sortedasc_fi";
				mapper["dsc"] = "Sorteddsc_fi";
				mapper["fasc"] = "Filteredsortedasc_fi";
				mapper["fdsc"] = "Filteredsorteddsc_fi";
				mapper["osasc"] = "Optionsortasc_fi";
				mapper["osdsc"] = "Optionsortdsc_fi";
				mapper["app"] = "Optionapplyfilter_fi";
				mapper["fildata"] = "Optionfilteringdata_fi";
				mapper["cle"] = "Optioncleanfilters_fi";
				mapper["selo"] = "Selectedoption_fi";
				mapper["mul"] = "Multiseloption_fi";
				mapper["muls"] = "Multiselseloption_fi";
				mapper["tcol"] = "Treeviewcollapse_fi";
				mapper["texp"] = "Treeviewexpand_fi";
				mapper["fixl"] = "Fixleft_fi";
				mapper["fixr"] = "Fixright_fi";

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
			AddObjectProperty("def", gxTpr_Default_fi, false);


			AddObjectProperty("fil", gxTpr_Filtered_fi, false);


			AddObjectProperty("asc", gxTpr_Sortedasc_fi, false);


			AddObjectProperty("dsc", gxTpr_Sorteddsc_fi, false);


			AddObjectProperty("fasc", gxTpr_Filteredsortedasc_fi, false);


			AddObjectProperty("fdsc", gxTpr_Filteredsorteddsc_fi, false);


			AddObjectProperty("osasc", gxTpr_Optionsortasc_fi, false);


			AddObjectProperty("osdsc", gxTpr_Optionsortdsc_fi, false);


			AddObjectProperty("app", gxTpr_Optionapplyfilter_fi, false);


			AddObjectProperty("fildata", gxTpr_Optionfilteringdata_fi, false);


			AddObjectProperty("cle", gxTpr_Optioncleanfilters_fi, false);


			AddObjectProperty("selo", gxTpr_Selectedoption_fi, false);


			AddObjectProperty("mul", gxTpr_Multiseloption_fi, false);


			AddObjectProperty("muls", gxTpr_Multiselseloption_fi, false);


			AddObjectProperty("tcol", gxTpr_Treeviewcollapse_fi, false);


			AddObjectProperty("texp", gxTpr_Treeviewexpand_fi, false);


			AddObjectProperty("fixl", gxTpr_Fixleft_fi, false);


			AddObjectProperty("fixr", gxTpr_Fixright_fi, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Default_fi")]
		[XmlElement(ElementName="Default_fi")]
		public string gxTpr_Default_fi
		{
			get { 
				return gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Default_fi; 
			}
			set { 
				gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Default_fi = value;
				SetDirty("Default_fi");
			}
		}




		[SoapElement(ElementName="Filtered_fi")]
		[XmlElement(ElementName="Filtered_fi")]
		public string gxTpr_Filtered_fi
		{
			get { 
				return gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Filtered_fi; 
			}
			set { 
				gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Filtered_fi = value;
				SetDirty("Filtered_fi");
			}
		}




		[SoapElement(ElementName="SortedASC_fi")]
		[XmlElement(ElementName="SortedASC_fi")]
		public string gxTpr_Sortedasc_fi
		{
			get { 
				return gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Sortedasc_fi; 
			}
			set { 
				gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Sortedasc_fi = value;
				SetDirty("Sortedasc_fi");
			}
		}




		[SoapElement(ElementName="SortedDSC_fi")]
		[XmlElement(ElementName="SortedDSC_fi")]
		public string gxTpr_Sorteddsc_fi
		{
			get { 
				return gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Sorteddsc_fi; 
			}
			set { 
				gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Sorteddsc_fi = value;
				SetDirty("Sorteddsc_fi");
			}
		}




		[SoapElement(ElementName="FilteredSortedASC_fi")]
		[XmlElement(ElementName="FilteredSortedASC_fi")]
		public string gxTpr_Filteredsortedasc_fi
		{
			get { 
				return gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Filteredsortedasc_fi; 
			}
			set { 
				gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Filteredsortedasc_fi = value;
				SetDirty("Filteredsortedasc_fi");
			}
		}




		[SoapElement(ElementName="FilteredSortedDSC_fi")]
		[XmlElement(ElementName="FilteredSortedDSC_fi")]
		public string gxTpr_Filteredsorteddsc_fi
		{
			get { 
				return gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Filteredsorteddsc_fi; 
			}
			set { 
				gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Filteredsorteddsc_fi = value;
				SetDirty("Filteredsorteddsc_fi");
			}
		}




		[SoapElement(ElementName="OptionSortASC_fi")]
		[XmlElement(ElementName="OptionSortASC_fi")]
		public string gxTpr_Optionsortasc_fi
		{
			get { 
				return gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Optionsortasc_fi; 
			}
			set { 
				gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Optionsortasc_fi = value;
				SetDirty("Optionsortasc_fi");
			}
		}




		[SoapElement(ElementName="OptionSortDSC_fi")]
		[XmlElement(ElementName="OptionSortDSC_fi")]
		public string gxTpr_Optionsortdsc_fi
		{
			get { 
				return gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Optionsortdsc_fi; 
			}
			set { 
				gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Optionsortdsc_fi = value;
				SetDirty("Optionsortdsc_fi");
			}
		}




		[SoapElement(ElementName="OptionApplyFilter_fi")]
		[XmlElement(ElementName="OptionApplyFilter_fi")]
		public string gxTpr_Optionapplyfilter_fi
		{
			get { 
				return gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Optionapplyfilter_fi; 
			}
			set { 
				gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Optionapplyfilter_fi = value;
				SetDirty("Optionapplyfilter_fi");
			}
		}




		[SoapElement(ElementName="OptionFilteringData_fi")]
		[XmlElement(ElementName="OptionFilteringData_fi")]
		public string gxTpr_Optionfilteringdata_fi
		{
			get { 
				return gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Optionfilteringdata_fi; 
			}
			set { 
				gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Optionfilteringdata_fi = value;
				SetDirty("Optionfilteringdata_fi");
			}
		}




		[SoapElement(ElementName="OptionCleanFilters_fi")]
		[XmlElement(ElementName="OptionCleanFilters_fi")]
		public string gxTpr_Optioncleanfilters_fi
		{
			get { 
				return gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Optioncleanfilters_fi; 
			}
			set { 
				gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Optioncleanfilters_fi = value;
				SetDirty("Optioncleanfilters_fi");
			}
		}




		[SoapElement(ElementName="SelectedOption_fi")]
		[XmlElement(ElementName="SelectedOption_fi")]
		public string gxTpr_Selectedoption_fi
		{
			get { 
				return gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Selectedoption_fi; 
			}
			set { 
				gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Selectedoption_fi = value;
				SetDirty("Selectedoption_fi");
			}
		}




		[SoapElement(ElementName="MultiselOption_fi")]
		[XmlElement(ElementName="MultiselOption_fi")]
		public string gxTpr_Multiseloption_fi
		{
			get { 
				return gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Multiseloption_fi; 
			}
			set { 
				gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Multiseloption_fi = value;
				SetDirty("Multiseloption_fi");
			}
		}




		[SoapElement(ElementName="MultiselSelOption_fi")]
		[XmlElement(ElementName="MultiselSelOption_fi")]
		public string gxTpr_Multiselseloption_fi
		{
			get { 
				return gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Multiselseloption_fi; 
			}
			set { 
				gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Multiselseloption_fi = value;
				SetDirty("Multiselseloption_fi");
			}
		}




		[SoapElement(ElementName="TreeviewCollapse_fi")]
		[XmlElement(ElementName="TreeviewCollapse_fi")]
		public string gxTpr_Treeviewcollapse_fi
		{
			get { 
				return gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Treeviewcollapse_fi; 
			}
			set { 
				gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Treeviewcollapse_fi = value;
				SetDirty("Treeviewcollapse_fi");
			}
		}




		[SoapElement(ElementName="TreeviewExpand_fi")]
		[XmlElement(ElementName="TreeviewExpand_fi")]
		public string gxTpr_Treeviewexpand_fi
		{
			get { 
				return gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Treeviewexpand_fi; 
			}
			set { 
				gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Treeviewexpand_fi = value;
				SetDirty("Treeviewexpand_fi");
			}
		}




		[SoapElement(ElementName="FixLeft_fi")]
		[XmlElement(ElementName="FixLeft_fi")]
		public string gxTpr_Fixleft_fi
		{
			get { 
				return gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Fixleft_fi; 
			}
			set { 
				gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Fixleft_fi = value;
				SetDirty("Fixleft_fi");
			}
		}




		[SoapElement(ElementName="FixRight_fi")]
		[XmlElement(ElementName="FixRight_fi")]
		public string gxTpr_Fixright_fi
		{
			get { 
				return gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Fixright_fi; 
			}
			set { 
				gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Fixright_fi = value;
				SetDirty("Fixright_fi");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Default_fi = "";
			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Filtered_fi = "";
			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Sortedasc_fi = "";
			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Sorteddsc_fi = "";
			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Filteredsortedasc_fi = "";
			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Filteredsorteddsc_fi = "";
			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Optionsortasc_fi = "";
			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Optionsortdsc_fi = "";
			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Optionapplyfilter_fi = "";
			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Optionfilteringdata_fi = "";
			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Optioncleanfilters_fi = "";
			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Selectedoption_fi = "";
			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Multiseloption_fi = "";
			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Multiselseloption_fi = "";
			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Treeviewcollapse_fi = "";
			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Treeviewexpand_fi = "";
			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Fixleft_fi = "";
			gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Fixright_fi = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Default_fi;
		 

		protected string gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Filtered_fi;
		 

		protected string gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Sortedasc_fi;
		 

		protected string gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Sorteddsc_fi;
		 

		protected string gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Filteredsortedasc_fi;
		 

		protected string gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Filteredsorteddsc_fi;
		 

		protected string gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Optionsortasc_fi;
		 

		protected string gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Optionsortdsc_fi;
		 

		protected string gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Optionapplyfilter_fi;
		 

		protected string gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Optionfilteringdata_fi;
		 

		protected string gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Optioncleanfilters_fi;
		 

		protected string gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Selectedoption_fi;
		 

		protected string gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Multiseloption_fi;
		 

		protected string gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Multiselseloption_fi;
		 

		protected string gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Treeviewcollapse_fi;
		 

		protected string gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Treeviewexpand_fi;
		 

		protected string gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Fixleft_fi;
		 

		protected string gxTv_SdtDVB_SDTDropDownOptionsTitleSettingsIcons_Fixright_fi;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"TitleSettingsIcons", Namespace="")]
	public class SdtDVB_SDTDropDownOptionsTitleSettingsIcons_RESTInterface : GxGenericCollectionItem<SdtDVB_SDTDropDownOptionsTitleSettingsIcons>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtDVB_SDTDropDownOptionsTitleSettingsIcons_RESTInterface( ) : base()
		{
		}

		public SdtDVB_SDTDropDownOptionsTitleSettingsIcons_RESTInterface( SdtDVB_SDTDropDownOptionsTitleSettingsIcons psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="def", Order=0)]
		public  string gxTpr_Default_fi
		{
			get { 
				return sdt.gxTpr_Default_fi;

			}
			set { 
				 sdt.gxTpr_Default_fi = value;
			}
		}

		[DataMember(Name="fil", Order=1)]
		public  string gxTpr_Filtered_fi
		{
			get { 
				return sdt.gxTpr_Filtered_fi;

			}
			set { 
				 sdt.gxTpr_Filtered_fi = value;
			}
		}

		[DataMember(Name="asc", Order=2)]
		public  string gxTpr_Sortedasc_fi
		{
			get { 
				return sdt.gxTpr_Sortedasc_fi;

			}
			set { 
				 sdt.gxTpr_Sortedasc_fi = value;
			}
		}

		[DataMember(Name="dsc", Order=3)]
		public  string gxTpr_Sorteddsc_fi
		{
			get { 
				return sdt.gxTpr_Sorteddsc_fi;

			}
			set { 
				 sdt.gxTpr_Sorteddsc_fi = value;
			}
		}

		[DataMember(Name="fasc", Order=4)]
		public  string gxTpr_Filteredsortedasc_fi
		{
			get { 
				return sdt.gxTpr_Filteredsortedasc_fi;

			}
			set { 
				 sdt.gxTpr_Filteredsortedasc_fi = value;
			}
		}

		[DataMember(Name="fdsc", Order=5)]
		public  string gxTpr_Filteredsorteddsc_fi
		{
			get { 
				return sdt.gxTpr_Filteredsorteddsc_fi;

			}
			set { 
				 sdt.gxTpr_Filteredsorteddsc_fi = value;
			}
		}

		[DataMember(Name="osasc", Order=6)]
		public  string gxTpr_Optionsortasc_fi
		{
			get { 
				return sdt.gxTpr_Optionsortasc_fi;

			}
			set { 
				 sdt.gxTpr_Optionsortasc_fi = value;
			}
		}

		[DataMember(Name="osdsc", Order=7)]
		public  string gxTpr_Optionsortdsc_fi
		{
			get { 
				return sdt.gxTpr_Optionsortdsc_fi;

			}
			set { 
				 sdt.gxTpr_Optionsortdsc_fi = value;
			}
		}

		[DataMember(Name="app", Order=8)]
		public  string gxTpr_Optionapplyfilter_fi
		{
			get { 
				return sdt.gxTpr_Optionapplyfilter_fi;

			}
			set { 
				 sdt.gxTpr_Optionapplyfilter_fi = value;
			}
		}

		[DataMember(Name="fildata", Order=9)]
		public  string gxTpr_Optionfilteringdata_fi
		{
			get { 
				return sdt.gxTpr_Optionfilteringdata_fi;

			}
			set { 
				 sdt.gxTpr_Optionfilteringdata_fi = value;
			}
		}

		[DataMember(Name="cle", Order=10)]
		public  string gxTpr_Optioncleanfilters_fi
		{
			get { 
				return sdt.gxTpr_Optioncleanfilters_fi;

			}
			set { 
				 sdt.gxTpr_Optioncleanfilters_fi = value;
			}
		}

		[DataMember(Name="selo", Order=11)]
		public  string gxTpr_Selectedoption_fi
		{
			get { 
				return sdt.gxTpr_Selectedoption_fi;

			}
			set { 
				 sdt.gxTpr_Selectedoption_fi = value;
			}
		}

		[DataMember(Name="mul", Order=12)]
		public  string gxTpr_Multiseloption_fi
		{
			get { 
				return sdt.gxTpr_Multiseloption_fi;

			}
			set { 
				 sdt.gxTpr_Multiseloption_fi = value;
			}
		}

		[DataMember(Name="muls", Order=13)]
		public  string gxTpr_Multiselseloption_fi
		{
			get { 
				return sdt.gxTpr_Multiselseloption_fi;

			}
			set { 
				 sdt.gxTpr_Multiselseloption_fi = value;
			}
		}

		[DataMember(Name="tcol", Order=14)]
		public  string gxTpr_Treeviewcollapse_fi
		{
			get { 
				return sdt.gxTpr_Treeviewcollapse_fi;

			}
			set { 
				 sdt.gxTpr_Treeviewcollapse_fi = value;
			}
		}

		[DataMember(Name="texp", Order=15)]
		public  string gxTpr_Treeviewexpand_fi
		{
			get { 
				return sdt.gxTpr_Treeviewexpand_fi;

			}
			set { 
				 sdt.gxTpr_Treeviewexpand_fi = value;
			}
		}

		[DataMember(Name="fixl", Order=16)]
		public  string gxTpr_Fixleft_fi
		{
			get { 
				return sdt.gxTpr_Fixleft_fi;

			}
			set { 
				 sdt.gxTpr_Fixleft_fi = value;
			}
		}

		[DataMember(Name="fixr", Order=17)]
		public  string gxTpr_Fixright_fi
		{
			get { 
				return sdt.gxTpr_Fixright_fi;

			}
			set { 
				 sdt.gxTpr_Fixright_fi = value;
			}
		}


		#endregion

		public SdtDVB_SDTDropDownOptionsTitleSettingsIcons sdt
		{
			get { 
				return (SdtDVB_SDTDropDownOptionsTitleSettingsIcons)Sdt;
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
				sdt = new SdtDVB_SDTDropDownOptionsTitleSettingsIcons() ;
			}
		}
	}
	#endregion
}