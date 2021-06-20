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
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects {
   public class ismenuauthorizedoption : GXProcedure
   {
      public ismenuauthorizedoption( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public ismenuauthorizedoption( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item aP0_DVelop_Menu_Item ,
                           out bool aP1_IsAuthorized )
      {
         this.AV9DVelop_Menu_Item = aP0_DVelop_Menu_Item;
         this.AV11IsAuthorized = false ;
         initialize();
         executePrivate();
         aP1_IsAuthorized=this.AV11IsAuthorized;
      }

      public bool executeUdp( GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item aP0_DVelop_Menu_Item )
      {
         execute(aP0_DVelop_Menu_Item, out aP1_IsAuthorized);
         return AV11IsAuthorized ;
      }

      public void executeSubmit( GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item aP0_DVelop_Menu_Item ,
                                 out bool aP1_IsAuthorized )
      {
         ismenuauthorizedoption objismenuauthorizedoption;
         objismenuauthorizedoption = new ismenuauthorizedoption();
         objismenuauthorizedoption.AV9DVelop_Menu_Item = aP0_DVelop_Menu_Item;
         objismenuauthorizedoption.AV11IsAuthorized = false ;
         objismenuauthorizedoption.context.SetSubmitInitialConfig(context);
         objismenuauthorizedoption.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objismenuauthorizedoption);
         aP1_IsAuthorized=this.AV11IsAuthorized;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((ismenuauthorizedoption)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Lower( AV9DVelop_Menu_Item.gxTpr_Authorizationkey), "public") == 0 )
         {
            AV11IsAuthorized = true;
         }
         else if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9DVelop_Menu_Item.gxTpr_Authorizationkey)) )
         {
            GXt_boolean1 = AV11IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  AV9DVelop_Menu_Item.gxTpr_Authorizationkey, out  GXt_boolean1) ;
            AV11IsAuthorized = GXt_boolean1;
         }
         else
         {
            AV13Url = AV9DVelop_Menu_Item.gxTpr_Link;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Url)) )
            {
               /* Execute user subroutine: 'GET AUTHORIZATION KEY FROM URL' */
               S111 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
               GXt_boolean1 = AV11IsAuthorized;
               new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  AV8AuthorizationKey, out  GXt_boolean1) ;
               AV11IsAuthorized = GXt_boolean1;
            }
            else
            {
               AV11IsAuthorized = true;
            }
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'GET AUTHORIZATION KEY FROM URL' Routine */
         returnInSub = false;
         AV8AuthorizationKey = "";
         AV15UrlResourceName = "";
         AV13Url = StringUtil.StringReplace( AV13Url, ".aspx", "");
         AV10i = (short)(StringUtil.StringSearchRev( AV13Url, "/", -1));
         if ( AV10i > 0 )
         {
            AV13Url = StringUtil.Substring( AV13Url, AV10i+1, StringUtil.Len( StringUtil.Trim( AV13Url))-AV10i);
         }
         else
         {
            AV13Url = StringUtil.Trim( AV13Url);
         }
         if ( StringUtil.StringSearchRev( AV13Url, "?", -1) > 0 )
         {
            AV13Url = StringUtil.Substring( AV13Url, 1, StringUtil.StringSearchRev( AV13Url, "?", -1)-1);
         }
         AV10i = (short)(StringUtil.StringSearchRev( AV13Url, ".", -1));
         AV15UrlResourceName = StringUtil.Substring( AV13Url, AV10i+1, StringUtil.Len( AV13Url)-AV10i);
         AV8AuthorizationKey = StringUtil.Lower( StringUtil.Trim( AV15UrlResourceName)) + "_Execute";
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
         AV13Url = "";
         AV8AuthorizationKey = "";
         AV15UrlResourceName = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV10i ;
      private string AV15UrlResourceName ;
      private bool AV11IsAuthorized ;
      private bool returnInSub ;
      private bool GXt_boolean1 ;
      private string AV13Url ;
      private string AV8AuthorizationKey ;
      private bool aP1_IsAuthorized ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item AV9DVelop_Menu_Item ;
   }

}
