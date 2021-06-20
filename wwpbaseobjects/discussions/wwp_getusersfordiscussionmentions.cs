using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects.discussions {
   public class wwp_getusersfordiscussionmentions : GXProcedure
   {
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "wwp_getusersfordiscussionmentions_Services_Execute" ;
         }

      }

      public wwp_getusersfordiscussionmentions( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_getusersfordiscussionmentions( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( string aP0_SearchTxt ,
                           out string aP1_OptionsJson )
      {
         this.AV11SearchTxt = aP0_SearchTxt;
         this.AV10OptionsJson = "" ;
         initialize();
         executePrivate();
         aP1_OptionsJson=this.AV10OptionsJson;
      }

      public string executeUdp( string aP0_SearchTxt )
      {
         execute(aP0_SearchTxt, out aP1_OptionsJson);
         return AV10OptionsJson ;
      }

      public void executeSubmit( string aP0_SearchTxt ,
                                 out string aP1_OptionsJson )
      {
         wwp_getusersfordiscussionmentions objwwp_getusersfordiscussionmentions;
         objwwp_getusersfordiscussionmentions = new wwp_getusersfordiscussionmentions();
         objwwp_getusersfordiscussionmentions.AV11SearchTxt = aP0_SearchTxt;
         objwwp_getusersfordiscussionmentions.AV10OptionsJson = "" ;
         objwwp_getusersfordiscussionmentions.context.SetSubmitInitialConfig(context);
         objwwp_getusersfordiscussionmentions.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_getusersfordiscussionmentions);
         aP1_OptionsJson=this.AV10OptionsJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_getusersfordiscussionmentions)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw e ;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9Options = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWPSuggestDataItem>( context, "WWPSuggestDataItem", "RastreamentoTCC");
         AV18MaxOptions = 5;
         AV12GAMUserFilter.gxTpr_Names = "%"+AV11SearchTxt;
         AV14GAMUserCollection = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getusers(AV12GAMUserFilter, out  AV13GAMErrorCollection);
         AV19CheckDuplicated = false;
         /* Execute user subroutine: 'SEARCH USERS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( AV9Options.Count < AV18MaxOptions )
         {
            AV12GAMUserFilter = new GeneXus.Programs.genexussecurity.SdtGAMUserFilter(context);
            AV12GAMUserFilter.gxTpr_Email = "%"+AV11SearchTxt;
            AV19CheckDuplicated = true;
            /* Execute user subroutine: 'SEARCH USERS' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV10OptionsJson = AV9Options.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'SEARCH USERS' Routine */
         returnInSub = false;
         AV14GAMUserCollection = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getusers(AV12GAMUserFilter, out  AV13GAMErrorCollection);
         AV22GXV1 = 1;
         while ( AV22GXV1 <= AV14GAMUserCollection.Count )
         {
            AV15GAMUser = ((GeneXus.Programs.genexussecurity.SdtGAMUser)AV14GAMUserCollection.Item(AV22GXV1));
            AV16WWPUserExtended.Load(AV15GAMUser.gxTpr_Guid);
            AV17WWPUserExtendedFullName = (String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV15GAMUser.gxTpr_Firstname))) ? AV15GAMUser.gxTpr_Name : StringUtil.Trim( AV15GAMUser.gxTpr_Firstname)+" "+StringUtil.Trim( AV15GAMUser.gxTpr_Lastname));
            AV8Option = new GeneXus.Programs.wwpbaseobjects.SdtWWPSuggestDataItem(context);
            AV8Option.gxTpr_Id = AV16WWPUserExtended.gxTpr_Wwpuserextendedid;
            AV8Option.gxTpr_Displayname = AV17WWPUserExtendedFullName;
            AV8Option.gxTpr_Text.Add(AV17WWPUserExtendedFullName, 0);
            AV8Option.gxTpr_Text.Add(AV15GAMUser.gxTpr_Email, 0);
            AV8Option.gxTpr_Text.Add(AV16WWPUserExtended.gxTpr_Wwpuserextendedphoto_gxi, 0);
            if ( ! AV19CheckDuplicated || ! StringUtil.Contains( AV9Options.ToJSonString(false), AV8Option.ToJSonString(false, true)) )
            {
               AV9Options.Add(AV8Option, 0);
            }
            if ( AV9Options.Count > AV18MaxOptions )
            {
               if (true) break;
            }
            AV22GXV1 = (int)(AV22GXV1+1);
         }
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         exitApplication();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV10OptionsJson = "";
         AV9Options = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWPSuggestDataItem>( context, "WWPSuggestDataItem", "RastreamentoTCC");
         AV12GAMUserFilter = new GeneXus.Programs.genexussecurity.SdtGAMUserFilter(context);
         AV14GAMUserCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMUser>( context, "GeneXus.Programs.genexussecurity.SdtGAMUser", "GeneXus.Programs");
         AV13GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV15GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV16WWPUserExtended = new GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended(context);
         AV17WWPUserExtendedFullName = "";
         AV8Option = new GeneXus.Programs.wwpbaseobjects.SdtWWPSuggestDataItem(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV18MaxOptions ;
      private int AV22GXV1 ;
      private bool AV19CheckDuplicated ;
      private bool returnInSub ;
      private string AV10OptionsJson ;
      private string AV11SearchTxt ;
      private string AV17WWPUserExtendedFullName ;
      private string aP1_OptionsJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWPSuggestDataItem> AV9Options ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV13GAMErrorCollection ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMUser> AV14GAMUserCollection ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPSuggestDataItem AV8Option ;
      private GeneXus.Programs.genexussecurity.SdtGAMUserFilter AV12GAMUserFilter ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV15GAMUser ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended AV16WWPUserExtended ;
   }

   [ServiceContract(Namespace = "GeneXus.Programs.wwpbaseobjects.discussions.wwp_getusersfordiscussionmentions_services")]
   [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   public class wwp_getusersfordiscussionmentions_services : GxRestService
   {
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      [OperationContract(Name = "WWP_GetUsersForDiscussionMentions" )]
      [WebInvoke(Method =  "POST" ,
      	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
      	ResponseFormat = WebMessageFormat.Json,
      	UriTemplate = "/")]
      public void execute( string SearchTxt ,
                           out string OptionsJson )
      {
         OptionsJson = "" ;
         try
         {
            permissionPrefix = "wwp_getusersfordiscussionmentions_Services_Execute";
            if ( ! IsAuthenticated() )
            {
               return  ;
            }
            if ( ! ProcessHeaders("wwp_getusersfordiscussionmentions") )
            {
               return  ;
            }
            wwp_getusersfordiscussionmentions worker = new wwp_getusersfordiscussionmentions(context);
            worker.IsMain = RunAsMain ;
            worker.execute(SearchTxt,out OptionsJson );
            worker.cleanup( );
         }
         catch ( Exception e )
         {
            WebException(e);
         }
         finally
         {
            Cleanup();
         }
      }

   }

}
