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
   public class relatorioutilizacaoloaddvcombo : GXProcedure
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
            return "relatorioutilizacao_Services_Execute" ;
         }

      }

      public relatorioutilizacaoloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public relatorioutilizacaoloaddvcombo( IGxContext context )
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
                           string aP1_SearchTxt ,
                           out string aP2_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV12SearchTxt = aP1_SearchTxt;
         this.AV13Combo_DataJson = "" ;
         initialize();
         executePrivate();
         aP2_Combo_DataJson=this.AV13Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_SearchTxt )
      {
         execute(aP0_ComboName, aP1_SearchTxt, out aP2_Combo_DataJson);
         return AV13Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_SearchTxt ,
                                 out string aP2_Combo_DataJson )
      {
         relatorioutilizacaoloaddvcombo objrelatorioutilizacaoloaddvcombo;
         objrelatorioutilizacaoloaddvcombo = new relatorioutilizacaoloaddvcombo();
         objrelatorioutilizacaoloaddvcombo.AV17ComboName = aP0_ComboName;
         objrelatorioutilizacaoloaddvcombo.AV12SearchTxt = aP1_SearchTxt;
         objrelatorioutilizacaoloaddvcombo.AV13Combo_DataJson = "" ;
         objrelatorioutilizacaoloaddvcombo.context.SetSubmitInitialConfig(context);
         objrelatorioutilizacaoloaddvcombo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrelatorioutilizacaoloaddvcombo);
         aP2_Combo_DataJson=this.AV13Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((relatorioutilizacaoloaddvcombo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV17ComboName, "VeiculoId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_VEICULOID' */
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
         /* 'LOADCOMBOITEMS_VEICULOID' Routine */
         returnInSub = false;
         AV21Udparg1 = new buscargamguidusuariologado(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV12SearchTxt ,
                                              A105VeiculoGAMGUID ,
                                              AV21Udparg1 ,
                                              A100VeiculoPlaca } ,
                                              new int[]{
                                              }
         });
         lV12SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV12SearchTxt), "%", "");
         /* Using cursor P00462 */
         pr_default.execute(0, new Object[] {AV21Udparg1, lV12SearchTxt});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A100VeiculoPlaca = P00462_A100VeiculoPlaca[0];
            A105VeiculoGAMGUID = P00462_A105VeiculoGAMGUID[0];
            A98VeiculoId = P00462_A98VeiculoId[0];
            AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV15Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A98VeiculoId), 8, 0));
            AV15Combo_DataItem.gxTpr_Title = A100VeiculoPlaca;
            AV14Combo_Data.Add(AV15Combo_DataItem, 0);
            if ( AV14Combo_Data.Count > AV11MaxItems )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         AV21Udparg1 = "";
         scmdbuf = "";
         lV12SearchTxt = "";
         A105VeiculoGAMGUID = "";
         A100VeiculoPlaca = "";
         P00462_A100VeiculoPlaca = new string[] {""} ;
         P00462_A105VeiculoGAMGUID = new string[] {""} ;
         P00462_A98VeiculoId = new int[1] ;
         AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV14Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.relatorioutilizacaoloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00462_A100VeiculoPlaca, P00462_A105VeiculoGAMGUID, P00462_A98VeiculoId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV11MaxItems ;
      private int A98VeiculoId ;
      private string AV21Udparg1 ;
      private string scmdbuf ;
      private string A105VeiculoGAMGUID ;
      private bool returnInSub ;
      private string AV13Combo_DataJson ;
      private string AV17ComboName ;
      private string AV12SearchTxt ;
      private string lV12SearchTxt ;
      private string A100VeiculoPlaca ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00462_A100VeiculoPlaca ;
      private string[] P00462_A105VeiculoGAMGUID ;
      private int[] P00462_A98VeiculoId ;
      private string aP2_Combo_DataJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV15Combo_DataItem ;
   }

   public class relatorioutilizacaoloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00462( IGxContext context ,
                                             string AV12SearchTxt ,
                                             string A105VeiculoGAMGUID ,
                                             string AV21Udparg1 ,
                                             string A100VeiculoPlaca )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[2];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [VeiculoPlaca], [VeiculoGAMGUID], [VeiculoId] FROM [Veiculo]";
         if ( ! new verificaradministrador(context).executeUdp( ) )
         {
            AddWhere(sWhereString, "([VeiculoGAMGUID] = @AV21Udparg1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12SearchTxt)) )
         {
            AddWhere(sWhereString, "([VeiculoPlaca] like '%' + @lV12SearchTxt)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [VeiculoPlaca]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00462(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP00462;
          prmP00462 = new Object[] {
          new Object[] {"@AV21Udparg1",SqlDbType.NChar,40,0} ,
          new Object[] {"@lV12SearchTxt",SqlDbType.NVarChar,40,0}
          };
          def= new CursorDef[] {
              new CursorDef("P00462", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00462,100, GxCacheFrequency.OFF ,false,false )
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
                table[1][0] = rslt.getString(2, 40);
                table[2][0] = rslt.getInt(3);
                return;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       short sIdx;
       switch ( cursor )
       {
             case 0 :
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (string)parms[2]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (string)parms[3]);
                }
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.relatorioutilizacaoloaddvcombo_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class relatorioutilizacaoloaddvcombo_services : GxRestService
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

    [OperationContract(Name = "RelatorioUtilizacaoLoadDVCombo" )]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public void execute( string ComboName ,
                         string SearchTxt ,
                         out string Combo_DataJson )
    {
       Combo_DataJson = "" ;
       try
       {
          permissionPrefix = "relatorioutilizacao_Services_Execute";
          if ( ! IsAuthenticated() )
          {
             return  ;
          }
          if ( ! ProcessHeaders("relatorioutilizacaoloaddvcombo") )
          {
             return  ;
          }
          relatorioutilizacaoloaddvcombo worker = new relatorioutilizacaoloaddvcombo(context);
          worker.IsMain = RunAsMain ;
          worker.execute(ComboName,SearchTxt,out Combo_DataJson );
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
