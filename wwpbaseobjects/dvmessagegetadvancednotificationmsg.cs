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
   public class dvmessagegetadvancednotificationmsg : GXProcedure
   {
      public dvmessagegetadvancednotificationmsg( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public dvmessagegetadvancednotificationmsg( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( string aP0_Title ,
                           string aP1_Text ,
                           string aP2_Type ,
                           string aP3_ControlSelector ,
                           string aP4_Hide ,
                           string aP5_IsDesktopNotification ,
                           string aP6_DesktopNotificationIconUrl ,
                           string aP7_ClickRedirectURL ,
                           out string aP8_Parms )
      {
         this.AV36Title = aP0_Title;
         this.AV34Text = aP1_Text;
         this.AV38Type = aP2_Type;
         this.AV18ControlSelector = aP3_ControlSelector;
         this.AV23Hide = aP4_Hide;
         this.AV19IsDesktopNotification = aP5_IsDesktopNotification;
         this.AV21DesktopNotificationIconUrl = aP6_DesktopNotificationIconUrl;
         this.AV40ClickRedirectURL = aP7_ClickRedirectURL;
         this.AV31Parms = "" ;
         initialize();
         executePrivate();
         aP8_Parms=this.AV31Parms;
      }

      public string executeUdp( string aP0_Title ,
                                string aP1_Text ,
                                string aP2_Type ,
                                string aP3_ControlSelector ,
                                string aP4_Hide ,
                                string aP5_IsDesktopNotification ,
                                string aP6_DesktopNotificationIconUrl ,
                                string aP7_ClickRedirectURL )
      {
         execute(aP0_Title, aP1_Text, aP2_Type, aP3_ControlSelector, aP4_Hide, aP5_IsDesktopNotification, aP6_DesktopNotificationIconUrl, aP7_ClickRedirectURL, out aP8_Parms);
         return AV31Parms ;
      }

      public void executeSubmit( string aP0_Title ,
                                 string aP1_Text ,
                                 string aP2_Type ,
                                 string aP3_ControlSelector ,
                                 string aP4_Hide ,
                                 string aP5_IsDesktopNotification ,
                                 string aP6_DesktopNotificationIconUrl ,
                                 string aP7_ClickRedirectURL ,
                                 out string aP8_Parms )
      {
         dvmessagegetadvancednotificationmsg objdvmessagegetadvancednotificationmsg;
         objdvmessagegetadvancednotificationmsg = new dvmessagegetadvancednotificationmsg();
         objdvmessagegetadvancednotificationmsg.AV36Title = aP0_Title;
         objdvmessagegetadvancednotificationmsg.AV34Text = aP1_Text;
         objdvmessagegetadvancednotificationmsg.AV38Type = aP2_Type;
         objdvmessagegetadvancednotificationmsg.AV18ControlSelector = aP3_ControlSelector;
         objdvmessagegetadvancednotificationmsg.AV23Hide = aP4_Hide;
         objdvmessagegetadvancednotificationmsg.AV19IsDesktopNotification = aP5_IsDesktopNotification;
         objdvmessagegetadvancednotificationmsg.AV21DesktopNotificationIconUrl = aP6_DesktopNotificationIconUrl;
         objdvmessagegetadvancednotificationmsg.AV40ClickRedirectURL = aP7_ClickRedirectURL;
         objdvmessagegetadvancednotificationmsg.AV31Parms = "" ;
         objdvmessagegetadvancednotificationmsg.context.SetSubmitInitialConfig(context);
         objdvmessagegetadvancednotificationmsg.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objdvmessagegetadvancednotificationmsg);
         aP8_Parms=this.AV31Parms;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dvmessagegetadvancednotificationmsg)stateInfo).executePrivate();
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
         AV31Parms = "{";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36Title)) )
         {
            AV31Parms += "\"title\":\"" + StringUtil.Trim( StringUtil.StringReplace( AV36Title, "\"", "")) + "\",";
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34Text)) )
         {
            AV31Parms += "\"text\":\"" + StringUtil.Trim( StringUtil.StringReplace( AV34Text, "\"", "")) + "\",";
         }
         if ( StringUtil.StrCmp(AV38Type, "nospecify") != 0 )
         {
            AV31Parms += "\"type\":\"" + AV38Type + "\",";
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18ControlSelector)) )
         {
            AV31Parms += "\"att\":\"" + (StringUtil.StartsWith( StringUtil.Trim( AV18ControlSelector), "#") ? "" : "#") + StringUtil.Trim( StringUtil.StringReplace( AV18ControlSelector, "\"", "")) + "\",";
         }
         if ( StringUtil.StrCmp(AV23Hide, "na") != 0 )
         {
            AV31Parms += "\"hide\":" + StringUtil.Trim( AV23Hide) + ",";
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40ClickRedirectURL)) )
         {
            AV31Parms += "\"clickUrl\":\"" + StringUtil.Trim( AV40ClickRedirectURL) + "\",";
         }
         if ( ( StringUtil.StrCmp(AV19IsDesktopNotification, "na") != 0 ) || ! String.IsNullOrEmpty(StringUtil.RTrim( AV21DesktopNotificationIconUrl)) )
         {
            AV31Parms += "\"desktop\": {";
            if ( StringUtil.StrCmp(AV19IsDesktopNotification, "na") != 0 )
            {
               AV31Parms += "\"desktop\":" + StringUtil.Trim( AV19IsDesktopNotification) + ",";
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21DesktopNotificationIconUrl)) )
            {
               AV31Parms += "\"icon\":\"" + StringUtil.Trim( AV21DesktopNotificationIconUrl) + "\",";
            }
            AV31Parms += "}";
         }
         AV31Parms += "}";
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
         AV31Parms = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV36Title ;
      private string AV34Text ;
      private string AV38Type ;
      private string AV18ControlSelector ;
      private string AV23Hide ;
      private string AV19IsDesktopNotification ;
      private string AV21DesktopNotificationIconUrl ;
      private string AV40ClickRedirectURL ;
      private string AV31Parms ;
      private string aP8_Parms ;
   }

}
