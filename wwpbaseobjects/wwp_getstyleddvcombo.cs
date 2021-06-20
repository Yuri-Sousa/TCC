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
   public class wwp_getstyleddvcombo : GXProcedure
   {
      public wwp_getstyleddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_getstyleddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( string aP0_Style ,
                           out string aP1_html )
      {
         this.AV9Style = aP0_Style;
         this.AV8html = "" ;
         initialize();
         executePrivate();
         aP1_html=this.AV8html;
      }

      public string executeUdp( string aP0_Style )
      {
         execute(aP0_Style, out aP1_html);
         return AV8html ;
      }

      public void executeSubmit( string aP0_Style ,
                                 out string aP1_html )
      {
         wwp_getstyleddvcombo objwwp_getstyleddvcombo;
         objwwp_getstyleddvcombo = new wwp_getstyleddvcombo();
         objwwp_getstyleddvcombo.AV9Style = aP0_Style;
         objwwp_getstyleddvcombo.AV8html = "" ;
         objwwp_getstyleddvcombo.context.SetSubmitInitialConfig(context);
         objwwp_getstyleddvcombo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_getstyleddvcombo);
         aP1_html=this.AV8html;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_getstyleddvcombo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV9Style, "Title and subtitle") == 0 )
         {
            AV8html = "<div class=\"StyleTitleAndSubtitle\"><span>%1</span><span>%2</span></div>";
         }
         else if ( StringUtil.StrCmp(AV9Style, "Title, subtitle and image") == 0 )
         {
            AV8html = "<div class=\"StyleImageAndData StyleImageTitleAndSubtitle\"><div><img src=\"%3\" /></div><div><span>%1</span><span>%2</span></div></div>";
         }
         else if ( StringUtil.StrCmp(AV9Style, "Title and image") == 0 )
         {
            AV8html = "<div class=\"StyleImageAndData StyleImageAndTitle\"><div><img src=\"%2\" /></div><div><span>%1</span></div></div>";
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
         AV8html = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV9Style ;
      private string AV8html ;
      private string aP1_html ;
   }

}
