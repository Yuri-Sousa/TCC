using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Web.Services.Protocols;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects.mail {
   [XmlSerializerFormat]
   [XmlRoot(ElementName = "WWP_Mail.Attachments" )]
   [XmlType(TypeName =  "WWP_Mail.Attachments" , Namespace = "RastreamentoTCC" )]
   [Serializable]
   public class SdtWWP_Mail_Attachments : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtWWP_Mail_Attachments( )
      {
      }

      public SdtWWP_Mail_Attachments( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetCallingAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"WWPMailAttachmentName", typeof(string)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Attachments");
         metadata.Set("BT", "WWP_MailAttachments");
         metadata.Set("PK", "[ \"WWPMailAttachmentName\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"WWPMailId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Modified");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Wwpmailattachmentname_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments sdt;
         sdt = (GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments)(source);
         gxTv_SdtWWP_Mail_Attachments_Wwpmailattachmentname = sdt.gxTv_SdtWWP_Mail_Attachments_Wwpmailattachmentname ;
         gxTv_SdtWWP_Mail_Attachments_Wwpmailattachmentfile = sdt.gxTv_SdtWWP_Mail_Attachments_Wwpmailattachmentfile ;
         gxTv_SdtWWP_Mail_Attachments_Mode = sdt.gxTv_SdtWWP_Mail_Attachments_Mode ;
         gxTv_SdtWWP_Mail_Attachments_Modified = sdt.gxTv_SdtWWP_Mail_Attachments_Modified ;
         gxTv_SdtWWP_Mail_Attachments_Initialized = sdt.gxTv_SdtWWP_Mail_Attachments_Initialized ;
         gxTv_SdtWWP_Mail_Attachments_Wwpmailattachmentname_Z = sdt.gxTv_SdtWWP_Mail_Attachments_Wwpmailattachmentname_Z ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("WWPMailAttachmentName", gxTv_SdtWWP_Mail_Attachments_Wwpmailattachmentname, false, includeNonInitialized);
         AddObjectProperty("WWPMailAttachmentFile", gxTv_SdtWWP_Mail_Attachments_Wwpmailattachmentfile, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtWWP_Mail_Attachments_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtWWP_Mail_Attachments_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtWWP_Mail_Attachments_Initialized, false, includeNonInitialized);
            AddObjectProperty("WWPMailAttachmentName_Z", gxTv_SdtWWP_Mail_Attachments_Wwpmailattachmentname_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments sdt )
      {
         if ( sdt.IsDirty("WWPMailAttachmentName") )
         {
            gxTv_SdtWWP_Mail_Attachments_Wwpmailattachmentname = sdt.gxTv_SdtWWP_Mail_Attachments_Wwpmailattachmentname ;
         }
         if ( sdt.IsDirty("WWPMailAttachmentFile") )
         {
            gxTv_SdtWWP_Mail_Attachments_Wwpmailattachmentfile = sdt.gxTv_SdtWWP_Mail_Attachments_Wwpmailattachmentfile ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "WWPMailAttachmentName" )]
      [  XmlElement( ElementName = "WWPMailAttachmentName"   )]
      public string gxTpr_Wwpmailattachmentname
      {
         get {
            return gxTv_SdtWWP_Mail_Attachments_Wwpmailattachmentname ;
         }

         set {
            gxTv_SdtWWP_Mail_Attachments_Wwpmailattachmentname = value;
            gxTv_SdtWWP_Mail_Attachments_Modified = 1;
            SetDirty("Wwpmailattachmentname");
         }

      }

      [  SoapElement( ElementName = "WWPMailAttachmentFile" )]
      [  XmlElement( ElementName = "WWPMailAttachmentFile"   )]
      public string gxTpr_Wwpmailattachmentfile
      {
         get {
            return gxTv_SdtWWP_Mail_Attachments_Wwpmailattachmentfile ;
         }

         set {
            gxTv_SdtWWP_Mail_Attachments_Wwpmailattachmentfile = value;
            gxTv_SdtWWP_Mail_Attachments_Modified = 1;
            SetDirty("Wwpmailattachmentfile");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtWWP_Mail_Attachments_Mode ;
         }

         set {
            gxTv_SdtWWP_Mail_Attachments_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtWWP_Mail_Attachments_Mode_SetNull( )
      {
         gxTv_SdtWWP_Mail_Attachments_Mode = "";
         return  ;
      }

      public bool gxTv_SdtWWP_Mail_Attachments_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtWWP_Mail_Attachments_Modified ;
         }

         set {
            gxTv_SdtWWP_Mail_Attachments_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtWWP_Mail_Attachments_Modified_SetNull( )
      {
         gxTv_SdtWWP_Mail_Attachments_Modified = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_Mail_Attachments_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtWWP_Mail_Attachments_Initialized ;
         }

         set {
            gxTv_SdtWWP_Mail_Attachments_Initialized = value;
            gxTv_SdtWWP_Mail_Attachments_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtWWP_Mail_Attachments_Initialized_SetNull( )
      {
         gxTv_SdtWWP_Mail_Attachments_Initialized = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_Mail_Attachments_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPMailAttachmentName_Z" )]
      [  XmlElement( ElementName = "WWPMailAttachmentName_Z"   )]
      public string gxTpr_Wwpmailattachmentname_Z
      {
         get {
            return gxTv_SdtWWP_Mail_Attachments_Wwpmailattachmentname_Z ;
         }

         set {
            gxTv_SdtWWP_Mail_Attachments_Wwpmailattachmentname_Z = value;
            gxTv_SdtWWP_Mail_Attachments_Modified = 1;
            SetDirty("Wwpmailattachmentname_Z");
         }

      }

      public void gxTv_SdtWWP_Mail_Attachments_Wwpmailattachmentname_Z_SetNull( )
      {
         gxTv_SdtWWP_Mail_Attachments_Wwpmailattachmentname_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_Mail_Attachments_Wwpmailattachmentname_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtWWP_Mail_Attachments_Wwpmailattachmentname = "";
         gxTv_SdtWWP_Mail_Attachments_Wwpmailattachmentfile = "";
         gxTv_SdtWWP_Mail_Attachments_Mode = "";
         gxTv_SdtWWP_Mail_Attachments_Wwpmailattachmentname_Z = "";
         return  ;
      }

      private short gxTv_SdtWWP_Mail_Attachments_Modified ;
      private short gxTv_SdtWWP_Mail_Attachments_Initialized ;
      private string gxTv_SdtWWP_Mail_Attachments_Mode ;
      private string gxTv_SdtWWP_Mail_Attachments_Wwpmailattachmentfile ;
      private string gxTv_SdtWWP_Mail_Attachments_Wwpmailattachmentname ;
      private string gxTv_SdtWWP_Mail_Attachments_Wwpmailattachmentname_Z ;
   }

   [DataContract(Name = @"WWPBaseObjects\Mail\WWP_Mail.Attachments", Namespace = "RastreamentoTCC")]
   public class SdtWWP_Mail_Attachments_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWWP_Mail_Attachments_RESTInterface( ) : base()
      {
      }

      public SdtWWP_Mail_Attachments_RESTInterface( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WWPMailAttachmentName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Wwpmailattachmentname
      {
         get {
            return sdt.gxTpr_Wwpmailattachmentname ;
         }

         set {
            sdt.gxTpr_Wwpmailattachmentname = value;
         }

      }

      [DataMember( Name = "WWPMailAttachmentFile" , Order = 1 )]
      public string gxTpr_Wwpmailattachmentfile
      {
         get {
            return sdt.gxTpr_Wwpmailattachmentfile ;
         }

         set {
            sdt.gxTpr_Wwpmailattachmentfile = value;
         }

      }

      public GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments() ;
         }
      }

   }

   [DataContract(Name = @"WWPBaseObjects\Mail\WWP_Mail.Attachments", Namespace = "RastreamentoTCC")]
   public class SdtWWP_Mail_Attachments_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWWP_Mail_Attachments_RESTLInterface( ) : base()
      {
      }

      public SdtWWP_Mail_Attachments_RESTLInterface( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments psdt ) : base(psdt)
      {
      }

      public GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments() ;
         }
      }

   }

}
