/*
				   File: type_SdtTreeNodeCollection_TreeNode
			Description: TreeNodeCollection
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
	[XmlRoot(ElementName="TreeNode")]
	[XmlType(TypeName="TreeNode" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtTreeNodeCollection_TreeNode : GxUserType
	{
		public SdtTreeNodeCollection_TreeNode( )
		{
			/* Constructor for serialization */
			gxTv_SdtTreeNodeCollection_TreeNode_Id = "";

			gxTv_SdtTreeNodeCollection_TreeNode_Name = "";

			gxTv_SdtTreeNodeCollection_TreeNode_Link = "";

			gxTv_SdtTreeNodeCollection_TreeNode_Linktarget = "";

			gxTv_SdtTreeNodeCollection_TreeNode_Icon = "";

			gxTv_SdtTreeNodeCollection_TreeNode_Iconwhenselected = "";

		}

		public SdtTreeNodeCollection_TreeNode(IGxContext context)
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
			AddObjectProperty("Id", gxTpr_Id, false);


			AddObjectProperty("Name", gxTpr_Name, false);


			AddObjectProperty("Link", gxTpr_Link, false);


			AddObjectProperty("LinkTarget", gxTpr_Linktarget, false);


			AddObjectProperty("Expanded", gxTpr_Expanded, false);


			AddObjectProperty("DynamicLoad", gxTpr_Dynamicload, false);


			AddObjectProperty("Icon", gxTpr_Icon, false);


			AddObjectProperty("IconWhenSelected", gxTpr_Iconwhenselected, false);

			if (gxTv_SdtTreeNodeCollection_TreeNode_Nodes != null)
			{
				AddObjectProperty("Nodes", gxTv_SdtTreeNodeCollection_TreeNode_Nodes, false);  
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Id")]
		[XmlElement(ElementName="Id")]
		public string gxTpr_Id
		{
			get { 
				return gxTv_SdtTreeNodeCollection_TreeNode_Id; 
			}
			set { 
				gxTv_SdtTreeNodeCollection_TreeNode_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public string gxTpr_Name
		{
			get { 
				return gxTv_SdtTreeNodeCollection_TreeNode_Name; 
			}
			set { 
				gxTv_SdtTreeNodeCollection_TreeNode_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="Link")]
		[XmlElement(ElementName="Link")]
		public string gxTpr_Link
		{
			get { 
				return gxTv_SdtTreeNodeCollection_TreeNode_Link; 
			}
			set { 
				gxTv_SdtTreeNodeCollection_TreeNode_Link = value;
				SetDirty("Link");
			}
		}




		[SoapElement(ElementName="LinkTarget")]
		[XmlElement(ElementName="LinkTarget")]
		public string gxTpr_Linktarget
		{
			get { 
				return gxTv_SdtTreeNodeCollection_TreeNode_Linktarget; 
			}
			set { 
				gxTv_SdtTreeNodeCollection_TreeNode_Linktarget = value;
				SetDirty("Linktarget");
			}
		}




		[SoapElement(ElementName="Expanded")]
		[XmlElement(ElementName="Expanded")]
		public bool gxTpr_Expanded
		{
			get { 
				return gxTv_SdtTreeNodeCollection_TreeNode_Expanded; 
			}
			set { 
				gxTv_SdtTreeNodeCollection_TreeNode_Expanded = value;
				SetDirty("Expanded");
			}
		}




		[SoapElement(ElementName="DynamicLoad")]
		[XmlElement(ElementName="DynamicLoad")]
		public bool gxTpr_Dynamicload
		{
			get { 
				return gxTv_SdtTreeNodeCollection_TreeNode_Dynamicload; 
			}
			set { 
				gxTv_SdtTreeNodeCollection_TreeNode_Dynamicload = value;
				SetDirty("Dynamicload");
			}
		}




		[SoapElement(ElementName="Icon")]
		[XmlElement(ElementName="Icon")]
		public string gxTpr_Icon
		{
			get { 
				return gxTv_SdtTreeNodeCollection_TreeNode_Icon; 
			}
			set { 
				gxTv_SdtTreeNodeCollection_TreeNode_Icon = value;
				SetDirty("Icon");
			}
		}




		[SoapElement(ElementName="IconWhenSelected")]
		[XmlElement(ElementName="IconWhenSelected")]
		public string gxTpr_Iconwhenselected
		{
			get { 
				return gxTv_SdtTreeNodeCollection_TreeNode_Iconwhenselected; 
			}
			set { 
				gxTv_SdtTreeNodeCollection_TreeNode_Iconwhenselected = value;
				SetDirty("Iconwhenselected");
			}
		}




		[SoapElement(ElementName="Nodes" )]
		[XmlArray(ElementName="Nodes"  )]
		[XmlArrayItemAttribute(ElementName="TreeNode" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtTreeNodeCollection_TreeNode> gxTpr_Nodes_GXBaseCollection
		{
			get {
				if ( gxTv_SdtTreeNodeCollection_TreeNode_Nodes == null )
				{
					gxTv_SdtTreeNodeCollection_TreeNode_Nodes = new GXBaseCollection<GeneXus.Programs.SdtTreeNodeCollection_TreeNode>( context, "TreeNodeCollection", "");
				}
				return gxTv_SdtTreeNodeCollection_TreeNode_Nodes;
			}
			set {
				if ( gxTv_SdtTreeNodeCollection_TreeNode_Nodes == null )
				{
					gxTv_SdtTreeNodeCollection_TreeNode_Nodes = new GXBaseCollection<GeneXus.Programs.SdtTreeNodeCollection_TreeNode>( context, "TreeNodeCollection", "");
				}
				gxTv_SdtTreeNodeCollection_TreeNode_Nodes_N = 0;

				gxTv_SdtTreeNodeCollection_TreeNode_Nodes = value;
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtTreeNodeCollection_TreeNode> gxTpr_Nodes
		{
			get {
				if ( gxTv_SdtTreeNodeCollection_TreeNode_Nodes == null )
				{
					gxTv_SdtTreeNodeCollection_TreeNode_Nodes = new GXBaseCollection<GeneXus.Programs.SdtTreeNodeCollection_TreeNode>( context, "TreeNodeCollection", "");
				}
				gxTv_SdtTreeNodeCollection_TreeNode_Nodes_N = 0;

				return gxTv_SdtTreeNodeCollection_TreeNode_Nodes ;
			}
			set {
				gxTv_SdtTreeNodeCollection_TreeNode_Nodes_N = 0;

				gxTv_SdtTreeNodeCollection_TreeNode_Nodes = value;
				SetDirty("Nodes");
			}
		}

		public void gxTv_SdtTreeNodeCollection_TreeNode_Nodes_SetNull()
		{
			gxTv_SdtTreeNodeCollection_TreeNode_Nodes_N = 1;

			gxTv_SdtTreeNodeCollection_TreeNode_Nodes = null;
			return  ;
		}

		public bool gxTv_SdtTreeNodeCollection_TreeNode_Nodes_IsNull()
		{
			if (gxTv_SdtTreeNodeCollection_TreeNode_Nodes == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Nodes_GXBaseCollection_Json()
		{
				return gxTv_SdtTreeNodeCollection_TreeNode_Nodes != null && gxTv_SdtTreeNodeCollection_TreeNode_Nodes.Count > 0;

		}


		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtTreeNodeCollection_TreeNode_Id = "";
			gxTv_SdtTreeNodeCollection_TreeNode_Name = "";
			gxTv_SdtTreeNodeCollection_TreeNode_Link = "";
			gxTv_SdtTreeNodeCollection_TreeNode_Linktarget = "";


			gxTv_SdtTreeNodeCollection_TreeNode_Icon = "";
			gxTv_SdtTreeNodeCollection_TreeNode_Iconwhenselected = "";

			gxTv_SdtTreeNodeCollection_TreeNode_Nodes_N = 1;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtTreeNodeCollection_TreeNode_Id;
		 

		protected string gxTv_SdtTreeNodeCollection_TreeNode_Name;
		 

		protected string gxTv_SdtTreeNodeCollection_TreeNode_Link;
		 

		protected string gxTv_SdtTreeNodeCollection_TreeNode_Linktarget;
		 

		protected bool gxTv_SdtTreeNodeCollection_TreeNode_Expanded;
		 

		protected bool gxTv_SdtTreeNodeCollection_TreeNode_Dynamicload;
		 

		protected string gxTv_SdtTreeNodeCollection_TreeNode_Icon;
		 

		protected string gxTv_SdtTreeNodeCollection_TreeNode_Iconwhenselected;
		 
		protected short gxTv_SdtTreeNodeCollection_TreeNode_Nodes_N;
		protected GXBaseCollection<GeneXus.Programs.SdtTreeNodeCollection_TreeNode> gxTv_SdtTreeNodeCollection_TreeNode_Nodes = null;  


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"TreeNode", Namespace="RastreamentoTCC")]
	public class SdtTreeNodeCollection_TreeNode_RESTInterface : GxGenericCollectionItem<SdtTreeNodeCollection_TreeNode>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtTreeNodeCollection_TreeNode_RESTInterface( ) : base()
		{
		}

		public SdtTreeNodeCollection_TreeNode_RESTInterface( SdtTreeNodeCollection_TreeNode psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="Id", Order=0)]
		public  string gxTpr_Id
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Id);

			}
			set { 
				 sdt.gxTpr_Id = value;
			}
		}

		[DataMember(Name="Name", Order=1)]
		public  string gxTpr_Name
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Name);

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[DataMember(Name="Link", Order=2)]
		public  string gxTpr_Link
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Link);

			}
			set { 
				 sdt.gxTpr_Link = value;
			}
		}

		[DataMember(Name="LinkTarget", Order=3)]
		public  string gxTpr_Linktarget
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Linktarget);

			}
			set { 
				 sdt.gxTpr_Linktarget = value;
			}
		}

		[DataMember(Name="Expanded", Order=4)]
		public bool gxTpr_Expanded
		{
			get { 
				return sdt.gxTpr_Expanded;

			}
			set { 
				sdt.gxTpr_Expanded = value;
			}
		}

		[DataMember(Name="DynamicLoad", Order=5)]
		public bool gxTpr_Dynamicload
		{
			get { 
				return sdt.gxTpr_Dynamicload;

			}
			set { 
				sdt.gxTpr_Dynamicload = value;
			}
		}

		[DataMember(Name="Icon", Order=6)]
		public  string gxTpr_Icon
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Icon);

			}
			set { 
				 sdt.gxTpr_Icon = value;
			}
		}

		[DataMember(Name="IconWhenSelected", Order=7)]
		public  string gxTpr_Iconwhenselected
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Iconwhenselected);

			}
			set { 
				 sdt.gxTpr_Iconwhenselected = value;
			}
		}

		[DataMember(Name="Nodes", Order=8, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtTreeNodeCollection_TreeNode_RESTInterface> gxTpr_Nodes
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Nodes_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtTreeNodeCollection_TreeNode_RESTInterface>(sdt.gxTpr_Nodes);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Nodes);
			}
		}


		#endregion

		public SdtTreeNodeCollection_TreeNode sdt
		{
			get { 
				return (SdtTreeNodeCollection_TreeNode)Sdt;
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
				sdt = new SdtTreeNodeCollection_TreeNode() ;
			}
		}
	}
	#endregion
}