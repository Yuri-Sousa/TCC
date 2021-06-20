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
   public class dvmessagegetdesktopnotificationmsg : GXProcedure
   {
      public dvmessagegetdesktopnotificationmsg( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public dvmessagegetdesktopnotificationmsg( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( string aP0_Title ,
                           string aP1_Text ,
                           string aP2_DesktopNotificationIconUrl ,
                           string aP3_ClickRedirectURL ,
                           out string aP4_Parms )
      {
         this.AV12Title = aP0_Title;
         this.AV11Text = aP1_Text;
         this.AV9DesktopNotificationIconUrl = aP2_DesktopNotificationIconUrl;
         this.AV8ClickRedirectURL = aP3_ClickRedirectURL;
         this.AV10Parms = "" ;
         initialize();
         executePrivate();
         aP4_Parms=this.AV10Parms;
      }

      public string executeUdp( string aP0_Title ,
                                string aP1_Text ,
                                string aP2_DesktopNotificationIconUrl ,
                                string aP3_ClickRedirectURL )
      {
         execute(aP0_Title, aP1_Text, aP2_DesktopNotificationIconUrl, aP3_ClickRedirectURL, out aP4_Parms);
         return AV10Parms ;
      }

      public void executeSubmit( string aP0_Title ,
                                 string aP1_Text ,
                                 string aP2_DesktopNotificationIconUrl ,
                                 string aP3_ClickRedirectURL ,
                                 out string aP4_Parms )
      {
         dvmessagegetdesktopnotificationmsg objdvmessagegetdesktopnotificationmsg;
         objdvmessagegetdesktopnotificationmsg = new dvmessagegetdesktopnotificationmsg();
         objdvmessagegetdesktopnotificationmsg.AV12Title = aP0_Title;
         objdvmessagegetdesktopnotificationmsg.AV11Text = aP1_Text;
         objdvmessagegetdesktopnotificationmsg.AV9DesktopNotificationIconUrl = aP2_DesktopNotificationIconUrl;
         objdvmessagegetdesktopnotificationmsg.AV8ClickRedirectURL = aP3_ClickRedirectURL;
         objdvmessagegetdesktopnotificationmsg.AV10Parms = "" ;
         objdvmessagegetdesktopnotificationmsg.context.SetSubmitInitialConfig(context);
         objdvmessagegetdesktopnotificationmsg.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objdvmessagegetdesktopnotificationmsg);
         aP4_Parms=this.AV10Parms;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dvmessagegetdesktopnotificationmsg)stateInfo).executePrivate();
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
         GXt_char1 = AV10Parms;
         new GeneXus.Programs.wwpbaseobjects.dvmessagegetadvancednotificationmsg(context ).execute(  AV12Title,  AV11Text,  AV13Type,  "",  "na",  "true",  AV9DesktopNotificationIconUrl,  AV8ClickRedirectURL, out  GXt_char1) ;
         AV10Parms = GXt_char1;
         this.cleanup();
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
         AV10Parms = "";
         GXt_char1 = "";
         AV13Type = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV12Title ;
      private string AV11Text ;
      private string GXt_char1 ;
      private string AV13Type ;
      private string AV9DesktopNotificationIconUrl ;
      private string AV8ClickRedirectURL ;
      private string AV10Parms ;
      private string aP4_Parms ;
   }

}
