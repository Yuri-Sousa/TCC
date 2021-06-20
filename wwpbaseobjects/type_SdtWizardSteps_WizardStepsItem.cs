/*
				   File: type_SdtWizardSteps_WizardStepsItem
			Description: WizardSteps
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
	[XmlRoot(ElementName="WizardStepsItem")]
	[XmlType(TypeName="WizardStepsItem" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtWizardSteps_WizardStepsItem : GxUserType
	{
		public SdtWizardSteps_WizardStepsItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtWizardSteps_WizardStepsItem_Code = "";

			gxTv_SdtWizardSteps_WizardStepsItem_Title = "";

			gxTv_SdtWizardSteps_WizardStepsItem_Description = "";

		}

		public SdtWizardSteps_WizardStepsItem(IGxContext context)
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
			AddObjectProperty("Code", gxTpr_Code, false);


			AddObjectProperty("Title", gxTpr_Title, false);


			AddObjectProperty("Description", gxTpr_Description, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Code")]
		[XmlElement(ElementName="Code")]
		public string gxTpr_Code
		{
			get { 
				return gxTv_SdtWizardSteps_WizardStepsItem_Code; 
			}
			set { 
				gxTv_SdtWizardSteps_WizardStepsItem_Code = value;
				SetDirty("Code");
			}
		}




		[SoapElement(ElementName="Title")]
		[XmlElement(ElementName="Title")]
		public string gxTpr_Title
		{
			get { 
				return gxTv_SdtWizardSteps_WizardStepsItem_Title; 
			}
			set { 
				gxTv_SdtWizardSteps_WizardStepsItem_Title = value;
				SetDirty("Title");
			}
		}




		[SoapElement(ElementName="Description")]
		[XmlElement(ElementName="Description")]
		public string gxTpr_Description
		{
			get { 
				return gxTv_SdtWizardSteps_WizardStepsItem_Description; 
			}
			set { 
				gxTv_SdtWizardSteps_WizardStepsItem_Description = value;
				SetDirty("Description");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtWizardSteps_WizardStepsItem_Code = "";
			gxTv_SdtWizardSteps_WizardStepsItem_Title = "";
			gxTv_SdtWizardSteps_WizardStepsItem_Description = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWizardSteps_WizardStepsItem_Code;
		 

		protected string gxTv_SdtWizardSteps_WizardStepsItem_Title;
		 

		protected string gxTv_SdtWizardSteps_WizardStepsItem_Description;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"WizardStepsItem", Namespace="RastreamentoTCC")]
	public class SdtWizardSteps_WizardStepsItem_RESTInterface : GxGenericCollectionItem<SdtWizardSteps_WizardStepsItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWizardSteps_WizardStepsItem_RESTInterface( ) : base()
		{
		}

		public SdtWizardSteps_WizardStepsItem_RESTInterface( SdtWizardSteps_WizardStepsItem psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="Code", Order=0)]
		public  string gxTpr_Code
		{
			get { 
				return sdt.gxTpr_Code;

			}
			set { 
				 sdt.gxTpr_Code = value;
			}
		}

		[DataMember(Name="Title", Order=1)]
		public  string gxTpr_Title
		{
			get { 
				return sdt.gxTpr_Title;

			}
			set { 
				 sdt.gxTpr_Title = value;
			}
		}

		[DataMember(Name="Description", Order=2)]
		public  string gxTpr_Description
		{
			get { 
				return sdt.gxTpr_Description;

			}
			set { 
				 sdt.gxTpr_Description = value;
			}
		}


		#endregion

		public SdtWizardSteps_WizardStepsItem sdt
		{
			get { 
				return (SdtWizardSteps_WizardStepsItem)Sdt;
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
				sdt = new SdtWizardSteps_WizardStepsItem() ;
			}
		}
	}
	#endregion
}