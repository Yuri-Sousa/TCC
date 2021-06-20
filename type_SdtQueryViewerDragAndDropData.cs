/*
				   File: type_SdtQueryViewerDragAndDropData
			Description: QueryViewerDragAndDropData
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
	[XmlRoot(ElementName="QueryViewerDragAndDropData")]
	[XmlType(TypeName="QueryViewerDragAndDropData" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtQueryViewerDragAndDropData : GxUserType
	{
		public SdtQueryViewerDragAndDropData( )
		{
			/* Constructor for serialization */
			gxTv_SdtQueryViewerDragAndDropData_Name = "";

			gxTv_SdtQueryViewerDragAndDropData_Type = "";

			gxTv_SdtQueryViewerDragAndDropData_Axis = "";

		}

		public SdtQueryViewerDragAndDropData(IGxContext context)
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
			AddObjectProperty("Name", gxTpr_Name, false);


			AddObjectProperty("Type", gxTpr_Type, false);


			AddObjectProperty("Axis", gxTpr_Axis, false);


			AddObjectProperty("Position", gxTpr_Position, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public string gxTpr_Name
		{
			get { 
				return gxTv_SdtQueryViewerDragAndDropData_Name; 
			}
			set { 
				gxTv_SdtQueryViewerDragAndDropData_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="Type")]
		[XmlElement(ElementName="Type")]
		public string gxTpr_Type
		{
			get { 
				return gxTv_SdtQueryViewerDragAndDropData_Type; 
			}
			set { 
				gxTv_SdtQueryViewerDragAndDropData_Type = value;
				SetDirty("Type");
			}
		}




		[SoapElement(ElementName="Axis")]
		[XmlElement(ElementName="Axis")]
		public string gxTpr_Axis
		{
			get { 
				return gxTv_SdtQueryViewerDragAndDropData_Axis; 
			}
			set { 
				gxTv_SdtQueryViewerDragAndDropData_Axis = value;
				SetDirty("Axis");
			}
		}




		[SoapElement(ElementName="Position")]
		[XmlElement(ElementName="Position")]
		public short gxTpr_Position
		{
			get { 
				return gxTv_SdtQueryViewerDragAndDropData_Position; 
			}
			set { 
				gxTv_SdtQueryViewerDragAndDropData_Position = value;
				SetDirty("Position");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtQueryViewerDragAndDropData_Name = "";
			gxTv_SdtQueryViewerDragAndDropData_Type = "";
			gxTv_SdtQueryViewerDragAndDropData_Axis = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtQueryViewerDragAndDropData_Name;
		 

		protected string gxTv_SdtQueryViewerDragAndDropData_Type;
		 

		protected string gxTv_SdtQueryViewerDragAndDropData_Axis;
		 

		protected short gxTv_SdtQueryViewerDragAndDropData_Position;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"QueryViewerDragAndDropData", Namespace="RastreamentoTCC")]
	public class SdtQueryViewerDragAndDropData_RESTInterface : GxGenericCollectionItem<SdtQueryViewerDragAndDropData>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtQueryViewerDragAndDropData_RESTInterface( ) : base()
		{
		}

		public SdtQueryViewerDragAndDropData_RESTInterface( SdtQueryViewerDragAndDropData psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="Name", Order=0)]
		public  string gxTpr_Name
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Name);

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[DataMember(Name="Type", Order=1)]
		public  string gxTpr_Type
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Type);

			}
			set { 
				 sdt.gxTpr_Type = value;
			}
		}

		[DataMember(Name="Axis", Order=2)]
		public  string gxTpr_Axis
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Axis);

			}
			set { 
				 sdt.gxTpr_Axis = value;
			}
		}

		[DataMember(Name="Position", Order=3)]
		public short gxTpr_Position
		{
			get { 
				return sdt.gxTpr_Position;

			}
			set { 
				sdt.gxTpr_Position = value;
			}
		}


		#endregion

		public SdtQueryViewerDragAndDropData sdt
		{
			get { 
				return (SdtQueryViewerDragAndDropData)Sdt;
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
				sdt = new SdtQueryViewerDragAndDropData() ;
			}
		}
	}
	#endregion
}