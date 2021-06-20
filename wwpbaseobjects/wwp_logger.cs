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
   public class wwp_logger : GXProcedure
   {
      public wwp_logger( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_logger( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         wwp_logger objwwp_logger;
         objwwp_logger = new wwp_logger();
         objwwp_logger.context.SetSubmitInitialConfig(context);
         objwwp_logger.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_logger);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_logger)stateInfo).executePrivate();
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
         this.cleanup();
      }

      public void gxep_debug( string aP0_Topic ,
                              string aP1_Message )
      {
         this.AV10Topic = aP0_Topic;
         this.AV9Message = aP1_Message;
         initialize();
         initialized = 1;
         /* Debug Constructor */
         /* Execute user subroutine: 'FORMATMESSAGE' */
         S111 ();
         if ( returnInSub )
         {
            returnInSub = true;
            this.cleanup();
            if (true) return;
         }
         new GeneXus.Core.genexus.common.SdtLog(context).debug(AV8FormattedMessage, StringUtil.Trim( AV10Topic)) ;
         executePrivate();
         this.cleanup();
      }

      public void gxep_info( string aP0_Topic ,
                             string aP1_Message )
      {
         this.AV10Topic = aP0_Topic;
         this.AV9Message = aP1_Message;
         initialize();
         initialized = 1;
         /* Info Constructor */
         /* Execute user subroutine: 'FORMATMESSAGE' */
         S111 ();
         if ( returnInSub )
         {
            returnInSub = true;
            this.cleanup();
            if (true) return;
         }
         new GeneXus.Core.genexus.common.SdtLog(context).info(AV8FormattedMessage, StringUtil.Trim( AV10Topic)) ;
         executePrivate();
         this.cleanup();
      }

      public void gxep_warning( string aP0_Topic ,
                                string aP1_Message )
      {
         this.AV10Topic = aP0_Topic;
         this.AV9Message = aP1_Message;
         initialize();
         initialized = 1;
         /* Warning Constructor */
         /* Execute user subroutine: 'FORMATMESSAGE' */
         S111 ();
         if ( returnInSub )
         {
            returnInSub = true;
            this.cleanup();
            if (true) return;
         }
         new GeneXus.Core.genexus.common.SdtLog(context).warning(AV8FormattedMessage, StringUtil.Trim( AV10Topic)) ;
         executePrivate();
         this.cleanup();
      }

      public void gxep_error( string aP0_Topic ,
                              string aP1_Message )
      {
         this.AV10Topic = aP0_Topic;
         this.AV9Message = aP1_Message;
         initialize();
         initialized = 1;
         /* Error Constructor */
         /* Execute user subroutine: 'FORMATMESSAGE' */
         S111 ();
         if ( returnInSub )
         {
            returnInSub = true;
            this.cleanup();
            if (true) return;
         }
         new GeneXus.Core.genexus.common.SdtLog(context).error(AV8FormattedMessage, StringUtil.Trim( AV10Topic)) ;
         executePrivate();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'FORMATMESSAGE' Routine */
         returnInSub = false;
         AV8FormattedMessage = "";
         GXt_char1 = AV11WWPUserExtendedId;
         new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context ).execute( out  GXt_char1) ;
         AV11WWPUserExtendedId = GXt_char1;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11WWPUserExtendedId)) )
         {
            AV8FormattedMessage += StringUtil.Format( "[UserGUID: %1] ", StringUtil.Trim( AV11WWPUserExtendedId), "", "", "", "", "", "", "", "");
         }
         else
         {
            AV8FormattedMessage += StringUtil.Format( "[UserGUID: %1] ", "N/A", "", "", "", "", "", "", "", "");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11WWPUserExtendedId)) )
         {
            AV8FormattedMessage += StringUtil.Format( "[UserName: %1] ", StringUtil.Trim( AV11WWPUserExtendedId), "", "", "", "", "", "", "", "");
         }
         else
         {
            AV8FormattedMessage += StringUtil.Format( "[UserName: %1] ", "N/A", "", "", "", "", "", "", "", "");
         }
         AV8FormattedMessage += StringUtil.Trim( AV9Message);
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
         AV8FormattedMessage = "";
         AV11WWPUserExtendedId = "";
         GXt_char1 = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short initialized ;
      private string AV11WWPUserExtendedId ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private string AV10Topic ;
      private string AV9Message ;
      private string AV8FormattedMessage ;
   }

}
