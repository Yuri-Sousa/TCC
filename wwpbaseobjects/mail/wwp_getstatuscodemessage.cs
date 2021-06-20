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
namespace GeneXus.Programs.wwpbaseobjects.mail {
   public class wwp_getstatuscodemessage : GXProcedure
   {
      public wwp_getstatuscodemessage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_getstatuscodemessage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( short aP0_StatusCode ,
                           out string aP1_Message )
      {
         this.AV10StatusCode = aP0_StatusCode;
         this.AV9Message = "" ;
         initialize();
         executePrivate();
         aP1_Message=this.AV9Message;
      }

      public string executeUdp( short aP0_StatusCode )
      {
         execute(aP0_StatusCode, out aP1_Message);
         return AV9Message ;
      }

      public void executeSubmit( short aP0_StatusCode ,
                                 out string aP1_Message )
      {
         wwp_getstatuscodemessage objwwp_getstatuscodemessage;
         objwwp_getstatuscodemessage = new wwp_getstatuscodemessage();
         objwwp_getstatuscodemessage.AV10StatusCode = aP0_StatusCode;
         objwwp_getstatuscodemessage.AV9Message = "" ;
         objwwp_getstatuscodemessage.context.SetSubmitInitialConfig(context);
         objwwp_getstatuscodemessage.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_getstatuscodemessage);
         aP1_Message=this.AV9Message;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_getstatuscodemessage)stateInfo).executePrivate();
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
         if ( AV10StatusCode == 0 )
         {
            AV9Message = "OK";
         }
         else if ( AV10StatusCode == 1 )
         {
            AV9Message = "Already logged in";
         }
         else if ( AV10StatusCode == 2 )
         {
            AV9Message = "Not logged in";
         }
         else if ( AV10StatusCode == 3 )
         {
            AV9Message = "Could not complete login";
         }
         else if ( AV10StatusCode == 6 )
         {
            AV9Message = "Invalid sender name";
         }
         else if ( AV10StatusCode == 7 )
         {
            AV9Message = "Invalid sender address";
         }
         else if ( AV10StatusCode == 8 )
         {
            AV9Message = "Invalid user name";
         }
         else if ( AV10StatusCode == 9 )
         {
            AV9Message = "Invalid password";
         }
         else if ( AV10StatusCode == 10 )
         {
            AV9Message = "Could not send message";
         }
         else if ( AV10StatusCode == 11 )
         {
            AV9Message = "No messages to receive";
         }
         else if ( AV10StatusCode == 12 )
         {
            AV9Message = "Could not delete message";
         }
         else if ( AV10StatusCode == 13 )
         {
            AV9Message = "No main recipient specified";
         }
         else if ( AV10StatusCode == 14 )
         {
            AV9Message = "Invalid recipient";
         }
         else if ( AV10StatusCode == 15 )
         {
            AV9Message = "Invalid attachment";
         }
         else if ( AV10StatusCode == 16 )
         {
            AV9Message = "Could not save attachment";
         }
         else if ( AV10StatusCode == 17 )
         {
            AV9Message = "Invalid Authentication value";
         }
         else if ( AV10StatusCode == 18 )
         {
            AV9Message = "Not enough memory";
         }
         else if ( AV10StatusCode == 19 )
         {
            AV9Message = "Connection lost";
         }
         else if ( AV10StatusCode == 20 )
         {
            AV9Message = "Timeout exceeded";
         }
         else if ( AV10StatusCode == 21 )
         {
            AV9Message = "Memory allocation error";
         }
         else if ( AV10StatusCode == 23 )
         {
            AV9Message = "The server does not recognize any of the supported authentication methods";
         }
         else if ( AV10StatusCode == 24 )
         {
            AV9Message = "Authentication error";
         }
         else if ( AV10StatusCode == 25 )
         {
            AV9Message = "User or password refused";
         }
         else if ( AV10StatusCode == 26 )
         {
            AV9Message = "No current message";
         }
         else if ( AV10StatusCode == 27 )
         {
            AV9Message = "Invalid NewMessages value";
         }
         else
         {
            AV9Message = "Unknown error";
         }
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
         AV9Message = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV10StatusCode ;
      private string AV9Message ;
      private string aP1_Message ;
   }

}
