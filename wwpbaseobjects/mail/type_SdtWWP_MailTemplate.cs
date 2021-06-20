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
   [XmlRoot(ElementName = "WWP_MailTemplate" )]
   [XmlType(TypeName =  "WWP_MailTemplate" , Namespace = "RastreamentoTCC" )]
   [Serializable]
   public class SdtWWP_MailTemplate : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWWP_MailTemplate( )
      {
      }

      public SdtWWP_MailTemplate( IGxContext context )
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

      public void Load( string AV19WWPMailTemplateName )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(string)AV19WWPMailTemplateName});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"WWPMailTemplateName", typeof(string)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "WWPBaseObjects\\Mail\\WWP_MailTemplate");
         metadata.Set("BT", "WWP_MailTemplate");
         metadata.Set("PK", "[ \"WWPMailTemplateName\" ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Wwpmailtemplatename_Z");
         state.Add("gxTpr_Wwpmailtemplatedescription_Z");
         state.Add("gxTpr_Wwpmailtemplatesubject_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate sdt;
         sdt = (GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate)(source);
         gxTv_SdtWWP_MailTemplate_Wwpmailtemplatename = sdt.gxTv_SdtWWP_MailTemplate_Wwpmailtemplatename ;
         gxTv_SdtWWP_MailTemplate_Wwpmailtemplatedescription = sdt.gxTv_SdtWWP_MailTemplate_Wwpmailtemplatedescription ;
         gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesubject = sdt.gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesubject ;
         gxTv_SdtWWP_MailTemplate_Wwpmailtemplatebody = sdt.gxTv_SdtWWP_MailTemplate_Wwpmailtemplatebody ;
         gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesenderaddress = sdt.gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesenderaddress ;
         gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesendername = sdt.gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesendername ;
         gxTv_SdtWWP_MailTemplate_Mode = sdt.gxTv_SdtWWP_MailTemplate_Mode ;
         gxTv_SdtWWP_MailTemplate_Initialized = sdt.gxTv_SdtWWP_MailTemplate_Initialized ;
         gxTv_SdtWWP_MailTemplate_Wwpmailtemplatename_Z = sdt.gxTv_SdtWWP_MailTemplate_Wwpmailtemplatename_Z ;
         gxTv_SdtWWP_MailTemplate_Wwpmailtemplatedescription_Z = sdt.gxTv_SdtWWP_MailTemplate_Wwpmailtemplatedescription_Z ;
         gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesubject_Z = sdt.gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesubject_Z ;
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
         AddObjectProperty("WWPMailTemplateName", gxTv_SdtWWP_MailTemplate_Wwpmailtemplatename, false, includeNonInitialized);
         AddObjectProperty("WWPMailTemplateDescription", gxTv_SdtWWP_MailTemplate_Wwpmailtemplatedescription, false, includeNonInitialized);
         AddObjectProperty("WWPMailTemplateSubject", gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesubject, false, includeNonInitialized);
         AddObjectProperty("WWPMailTemplateBody", gxTv_SdtWWP_MailTemplate_Wwpmailtemplatebody, false, includeNonInitialized);
         AddObjectProperty("WWPMailTemplateSenderAddress", gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesenderaddress, false, includeNonInitialized);
         AddObjectProperty("WWPMailTemplateSenderName", gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesendername, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtWWP_MailTemplate_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtWWP_MailTemplate_Initialized, false, includeNonInitialized);
            AddObjectProperty("WWPMailTemplateName_Z", gxTv_SdtWWP_MailTemplate_Wwpmailtemplatename_Z, false, includeNonInitialized);
            AddObjectProperty("WWPMailTemplateDescription_Z", gxTv_SdtWWP_MailTemplate_Wwpmailtemplatedescription_Z, false, includeNonInitialized);
            AddObjectProperty("WWPMailTemplateSubject_Z", gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesubject_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate sdt )
      {
         if ( sdt.IsDirty("WWPMailTemplateName") )
         {
            gxTv_SdtWWP_MailTemplate_Wwpmailtemplatename = sdt.gxTv_SdtWWP_MailTemplate_Wwpmailtemplatename ;
         }
         if ( sdt.IsDirty("WWPMailTemplateDescription") )
         {
            gxTv_SdtWWP_MailTemplate_Wwpmailtemplatedescription = sdt.gxTv_SdtWWP_MailTemplate_Wwpmailtemplatedescription ;
         }
         if ( sdt.IsDirty("WWPMailTemplateSubject") )
         {
            gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesubject = sdt.gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesubject ;
         }
         if ( sdt.IsDirty("WWPMailTemplateBody") )
         {
            gxTv_SdtWWP_MailTemplate_Wwpmailtemplatebody = sdt.gxTv_SdtWWP_MailTemplate_Wwpmailtemplatebody ;
         }
         if ( sdt.IsDirty("WWPMailTemplateSenderAddress") )
         {
            gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesenderaddress = sdt.gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesenderaddress ;
         }
         if ( sdt.IsDirty("WWPMailTemplateSenderName") )
         {
            gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesendername = sdt.gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesendername ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "WWPMailTemplateName" )]
      [  XmlElement( ElementName = "WWPMailTemplateName"   )]
      public string gxTpr_Wwpmailtemplatename
      {
         get {
            return gxTv_SdtWWP_MailTemplate_Wwpmailtemplatename ;
         }

         set {
            if ( StringUtil.StrCmp(gxTv_SdtWWP_MailTemplate_Wwpmailtemplatename, value) != 0 )
            {
               gxTv_SdtWWP_MailTemplate_Mode = "INS";
               this.gxTv_SdtWWP_MailTemplate_Wwpmailtemplatename_Z_SetNull( );
               this.gxTv_SdtWWP_MailTemplate_Wwpmailtemplatedescription_Z_SetNull( );
               this.gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesubject_Z_SetNull( );
            }
            gxTv_SdtWWP_MailTemplate_Wwpmailtemplatename = value;
            SetDirty("Wwpmailtemplatename");
         }

      }

      [  SoapElement( ElementName = "WWPMailTemplateDescription" )]
      [  XmlElement( ElementName = "WWPMailTemplateDescription"   )]
      public string gxTpr_Wwpmailtemplatedescription
      {
         get {
            return gxTv_SdtWWP_MailTemplate_Wwpmailtemplatedescription ;
         }

         set {
            gxTv_SdtWWP_MailTemplate_Wwpmailtemplatedescription = value;
            SetDirty("Wwpmailtemplatedescription");
         }

      }

      [  SoapElement( ElementName = "WWPMailTemplateSubject" )]
      [  XmlElement( ElementName = "WWPMailTemplateSubject"   )]
      public string gxTpr_Wwpmailtemplatesubject
      {
         get {
            return gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesubject ;
         }

         set {
            gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesubject = value;
            SetDirty("Wwpmailtemplatesubject");
         }

      }

      [  SoapElement( ElementName = "WWPMailTemplateBody" )]
      [  XmlElement( ElementName = "WWPMailTemplateBody"   )]
      public string gxTpr_Wwpmailtemplatebody
      {
         get {
            return gxTv_SdtWWP_MailTemplate_Wwpmailtemplatebody ;
         }

         set {
            gxTv_SdtWWP_MailTemplate_Wwpmailtemplatebody = value;
            SetDirty("Wwpmailtemplatebody");
         }

      }

      [  SoapElement( ElementName = "WWPMailTemplateSenderAddress" )]
      [  XmlElement( ElementName = "WWPMailTemplateSenderAddress"   )]
      public string gxTpr_Wwpmailtemplatesenderaddress
      {
         get {
            return gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesenderaddress ;
         }

         set {
            gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesenderaddress = value;
            SetDirty("Wwpmailtemplatesenderaddress");
         }

      }

      [  SoapElement( ElementName = "WWPMailTemplateSenderName" )]
      [  XmlElement( ElementName = "WWPMailTemplateSenderName"   )]
      public string gxTpr_Wwpmailtemplatesendername
      {
         get {
            return gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesendername ;
         }

         set {
            gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesendername = value;
            SetDirty("Wwpmailtemplatesendername");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtWWP_MailTemplate_Mode ;
         }

         set {
            gxTv_SdtWWP_MailTemplate_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtWWP_MailTemplate_Mode_SetNull( )
      {
         gxTv_SdtWWP_MailTemplate_Mode = "";
         return  ;
      }

      public bool gxTv_SdtWWP_MailTemplate_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtWWP_MailTemplate_Initialized ;
         }

         set {
            gxTv_SdtWWP_MailTemplate_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtWWP_MailTemplate_Initialized_SetNull( )
      {
         gxTv_SdtWWP_MailTemplate_Initialized = 0;
         return  ;
      }

      public bool gxTv_SdtWWP_MailTemplate_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPMailTemplateName_Z" )]
      [  XmlElement( ElementName = "WWPMailTemplateName_Z"   )]
      public string gxTpr_Wwpmailtemplatename_Z
      {
         get {
            return gxTv_SdtWWP_MailTemplate_Wwpmailtemplatename_Z ;
         }

         set {
            gxTv_SdtWWP_MailTemplate_Wwpmailtemplatename_Z = value;
            SetDirty("Wwpmailtemplatename_Z");
         }

      }

      public void gxTv_SdtWWP_MailTemplate_Wwpmailtemplatename_Z_SetNull( )
      {
         gxTv_SdtWWP_MailTemplate_Wwpmailtemplatename_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_MailTemplate_Wwpmailtemplatename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPMailTemplateDescription_Z" )]
      [  XmlElement( ElementName = "WWPMailTemplateDescription_Z"   )]
      public string gxTpr_Wwpmailtemplatedescription_Z
      {
         get {
            return gxTv_SdtWWP_MailTemplate_Wwpmailtemplatedescription_Z ;
         }

         set {
            gxTv_SdtWWP_MailTemplate_Wwpmailtemplatedescription_Z = value;
            SetDirty("Wwpmailtemplatedescription_Z");
         }

      }

      public void gxTv_SdtWWP_MailTemplate_Wwpmailtemplatedescription_Z_SetNull( )
      {
         gxTv_SdtWWP_MailTemplate_Wwpmailtemplatedescription_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_MailTemplate_Wwpmailtemplatedescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPMailTemplateSubject_Z" )]
      [  XmlElement( ElementName = "WWPMailTemplateSubject_Z"   )]
      public string gxTpr_Wwpmailtemplatesubject_Z
      {
         get {
            return gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesubject_Z ;
         }

         set {
            gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesubject_Z = value;
            SetDirty("Wwpmailtemplatesubject_Z");
         }

      }

      public void gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesubject_Z_SetNull( )
      {
         gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesubject_Z = "";
         return  ;
      }

      public bool gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesubject_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtWWP_MailTemplate_Wwpmailtemplatename = "";
         gxTv_SdtWWP_MailTemplate_Wwpmailtemplatedescription = "";
         gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesubject = "";
         gxTv_SdtWWP_MailTemplate_Wwpmailtemplatebody = "";
         gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesenderaddress = "";
         gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesendername = "";
         gxTv_SdtWWP_MailTemplate_Mode = "";
         gxTv_SdtWWP_MailTemplate_Wwpmailtemplatename_Z = "";
         gxTv_SdtWWP_MailTemplate_Wwpmailtemplatedescription_Z = "";
         gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesubject_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "wwpbaseobjects.mail.wwp_mailtemplate", "GeneXus.Programs.wwpbaseobjects.mail.wwp_mailtemplate_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      private short gxTv_SdtWWP_MailTemplate_Initialized ;
      private string gxTv_SdtWWP_MailTemplate_Mode ;
      private string gxTv_SdtWWP_MailTemplate_Wwpmailtemplatebody ;
      private string gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesenderaddress ;
      private string gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesendername ;
      private string gxTv_SdtWWP_MailTemplate_Wwpmailtemplatename ;
      private string gxTv_SdtWWP_MailTemplate_Wwpmailtemplatedescription ;
      private string gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesubject ;
      private string gxTv_SdtWWP_MailTemplate_Wwpmailtemplatename_Z ;
      private string gxTv_SdtWWP_MailTemplate_Wwpmailtemplatedescription_Z ;
      private string gxTv_SdtWWP_MailTemplate_Wwpmailtemplatesubject_Z ;
   }

   [DataContract(Name = @"WWPBaseObjects\Mail\WWP_MailTemplate", Namespace = "RastreamentoTCC")]
   public class SdtWWP_MailTemplate_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWWP_MailTemplate_RESTInterface( ) : base()
      {
      }

      public SdtWWP_MailTemplate_RESTInterface( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WWPMailTemplateName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Wwpmailtemplatename
      {
         get {
            return sdt.gxTpr_Wwpmailtemplatename ;
         }

         set {
            sdt.gxTpr_Wwpmailtemplatename = value;
         }

      }

      [DataMember( Name = "WWPMailTemplateDescription" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Wwpmailtemplatedescription
      {
         get {
            return sdt.gxTpr_Wwpmailtemplatedescription ;
         }

         set {
            sdt.gxTpr_Wwpmailtemplatedescription = value;
         }

      }

      [DataMember( Name = "WWPMailTemplateSubject" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Wwpmailtemplatesubject
      {
         get {
            return sdt.gxTpr_Wwpmailtemplatesubject ;
         }

         set {
            sdt.gxTpr_Wwpmailtemplatesubject = value;
         }

      }

      [DataMember( Name = "WWPMailTemplateBody" , Order = 3 )]
      public string gxTpr_Wwpmailtemplatebody
      {
         get {
            return sdt.gxTpr_Wwpmailtemplatebody ;
         }

         set {
            sdt.gxTpr_Wwpmailtemplatebody = value;
         }

      }

      [DataMember( Name = "WWPMailTemplateSenderAddress" , Order = 4 )]
      public string gxTpr_Wwpmailtemplatesenderaddress
      {
         get {
            return sdt.gxTpr_Wwpmailtemplatesenderaddress ;
         }

         set {
            sdt.gxTpr_Wwpmailtemplatesenderaddress = value;
         }

      }

      [DataMember( Name = "WWPMailTemplateSenderName" , Order = 5 )]
      public string gxTpr_Wwpmailtemplatesendername
      {
         get {
            return sdt.gxTpr_Wwpmailtemplatesendername ;
         }

         set {
            sdt.gxTpr_Wwpmailtemplatesendername = value;
         }

      }

      public GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 6 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"WWPBaseObjects\Mail\WWP_MailTemplate", Namespace = "RastreamentoTCC")]
   public class SdtWWP_MailTemplate_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWWP_MailTemplate_RESTLInterface( ) : base()
      {
      }

      public SdtWWP_MailTemplate_RESTLInterface( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WWPMailTemplateDescription" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Wwpmailtemplatedescription
      {
         get {
            return sdt.gxTpr_Wwpmailtemplatedescription ;
         }

         set {
            sdt.gxTpr_Wwpmailtemplatedescription = value;
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate() ;
         }
      }

   }

}
