using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
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
namespace GeneXus.Programs {
   public class wcenviarcomandoloaddvcombo : GXProcedure
   {
      public wcenviarcomandoloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wcenviarcomandoloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( string aP0_ComboName ,
                           string aP1_Cond_ComandoModeloModulo ,
                           string aP2_Cond_ComandoFabricanteModulo ,
                           string aP3_SearchTxt ,
                           out string aP4_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV19Cond_ComandoModeloModulo = aP1_Cond_ComandoModeloModulo;
         this.AV20Cond_ComandoFabricanteModulo = aP2_Cond_ComandoFabricanteModulo;
         this.AV12SearchTxt = aP3_SearchTxt;
         this.AV13Combo_DataJson = "" ;
         initialize();
         executePrivate();
         aP4_Combo_DataJson=this.AV13Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_Cond_ComandoModeloModulo ,
                                string aP2_Cond_ComandoFabricanteModulo ,
                                string aP3_SearchTxt )
      {
         execute(aP0_ComboName, aP1_Cond_ComandoModeloModulo, aP2_Cond_ComandoFabricanteModulo, aP3_SearchTxt, out aP4_Combo_DataJson);
         return AV13Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_Cond_ComandoModeloModulo ,
                                 string aP2_Cond_ComandoFabricanteModulo ,
                                 string aP3_SearchTxt ,
                                 out string aP4_Combo_DataJson )
      {
         wcenviarcomandoloaddvcombo objwcenviarcomandoloaddvcombo;
         objwcenviarcomandoloaddvcombo = new wcenviarcomandoloaddvcombo();
         objwcenviarcomandoloaddvcombo.AV17ComboName = aP0_ComboName;
         objwcenviarcomandoloaddvcombo.AV19Cond_ComandoModeloModulo = aP1_Cond_ComandoModeloModulo;
         objwcenviarcomandoloaddvcombo.AV20Cond_ComandoFabricanteModulo = aP2_Cond_ComandoFabricanteModulo;
         objwcenviarcomandoloaddvcombo.AV12SearchTxt = aP3_SearchTxt;
         objwcenviarcomandoloaddvcombo.AV13Combo_DataJson = "" ;
         objwcenviarcomandoloaddvcombo.context.SetSubmitInitialConfig(context);
         objwcenviarcomandoloaddvcombo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwcenviarcomandoloaddvcombo);
         aP4_Combo_DataJson=this.AV13Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wcenviarcomandoloaddvcombo)stateInfo).executePrivate();
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
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV11MaxItems = 100;
         if ( StringUtil.StrCmp(AV17ComboName, "ComandoId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_COMANDOID' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADCOMBOITEMS_COMANDOID' Routine */
         returnInSub = false;
         /* Using cursor P004A2 */
         pr_default.execute(0, new Object[] {AV20Cond_ComandoFabricanteModulo, AV19Cond_ComandoModeloModulo});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A141ComandoModeloModulo = P004A2_A141ComandoModeloModulo[0];
            A140ComandoFabricanteModulo = P004A2_A140ComandoFabricanteModulo[0];
            A137ComandoId = P004A2_A137ComandoId[0];
            A138ComandoNome = P004A2_A138ComandoNome[0];
            AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV15Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A137ComandoId), 8, 0));
            AV15Combo_DataItem.gxTpr_Title = StringUtil.Trim( A138ComandoNome);
            AV14Combo_Data.Add(AV15Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV14Combo_Data.Sort("Title");
         AV13Combo_DataJson = AV14Combo_Data.ToJSonString(false);
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
         AV13Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         scmdbuf = "";
         P004A2_A141ComandoModeloModulo = new string[] {""} ;
         P004A2_A140ComandoFabricanteModulo = new string[] {""} ;
         P004A2_A137ComandoId = new int[1] ;
         P004A2_A138ComandoNome = new string[] {""} ;
         A141ComandoModeloModulo = "";
         A140ComandoFabricanteModulo = "";
         A138ComandoNome = "";
         AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV14Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wcenviarcomandoloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P004A2_A141ComandoModeloModulo, P004A2_A140ComandoFabricanteModulo, P004A2_A137ComandoId, P004A2_A138ComandoNome
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV11MaxItems ;
      private int A137ComandoId ;
      private string scmdbuf ;
      private bool returnInSub ;
      private string AV13Combo_DataJson ;
      private string AV17ComboName ;
      private string AV19Cond_ComandoModeloModulo ;
      private string AV20Cond_ComandoFabricanteModulo ;
      private string AV12SearchTxt ;
      private string A141ComandoModeloModulo ;
      private string A140ComandoFabricanteModulo ;
      private string A138ComandoNome ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P004A2_A141ComandoModeloModulo ;
      private string[] P004A2_A140ComandoFabricanteModulo ;
      private int[] P004A2_A137ComandoId ;
      private string[] P004A2_A138ComandoNome ;
      private string aP4_Combo_DataJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV15Combo_DataItem ;
   }

   public class wcenviarcomandoloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP004A2;
          prmP004A2 = new Object[] {
          new Object[] {"@AV20Cond_ComandoFabricanteModulo",SqlDbType.NVarChar,40,0} ,
          new Object[] {"@AV19Cond_ComandoModeloModulo",SqlDbType.NVarChar,40,0}
          };
          def= new CursorDef[] {
              new CursorDef("P004A2", "SELECT [ComandoModeloModulo], [ComandoFabricanteModulo], [ComandoId], [ComandoNome] FROM [Comando] WHERE ([ComandoFabricanteModulo] = @AV20Cond_ComandoFabricanteModulo) AND ([ComandoModeloModulo] = @AV19Cond_ComandoModeloModulo) ORDER BY [ComandoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004A2,100, GxCacheFrequency.OFF ,false,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       dynamic table = buf;
       switch ( cursor )
       {
             case 0 :
                table[0][0] = rslt.getVarchar(1);
                table[1][0] = rslt.getVarchar(2);
                table[2][0] = rslt.getInt(3);
                table[3][0] = rslt.getVarchar(4);
                return;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       switch ( cursor )
       {
             case 0 :
                stmt.SetParameter(1, (string)parms[0]);
                stmt.SetParameter(2, (string)parms[1]);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.wcenviarcomandoloaddvcombo_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class wcenviarcomandoloaddvcombo_services : GxRestService
 {
    [OperationContract(Name = "WCEnviarComandoLoadDVCombo" )]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public void execute( string ComboName ,
                         string Cond_ComandoModeloModulo ,
                         string Cond_ComandoFabricanteModulo ,
                         string SearchTxt ,
                         out string Combo_DataJson )
    {
       Combo_DataJson = "" ;
       try
       {
          if ( ! ProcessHeaders("wcenviarcomandoloaddvcombo") )
          {
             return  ;
          }
          wcenviarcomandoloaddvcombo worker = new wcenviarcomandoloaddvcombo(context);
          worker.IsMain = RunAsMain ;
          worker.execute(ComboName,Cond_ComandoModeloModulo,Cond_ComandoFabricanteModulo,SearchTxt,out Combo_DataJson );
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
