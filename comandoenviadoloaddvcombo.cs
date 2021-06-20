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
   public class comandoenviadoloaddvcombo : GXProcedure
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
            return "comandoenviado_Services_Execute" ;
         }

      }

      public comandoenviadoloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public comandoenviadoloaddvcombo( IGxContext context )
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
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           int aP3_ComandoEnviadoId ,
                           string aP4_SearchTxt ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV19TrnMode = aP1_TrnMode;
         this.AV21IsDynamicCall = aP2_IsDynamicCall;
         this.AV25ComandoEnviadoId = aP3_ComandoEnviadoId;
         this.AV12SearchTxt = aP4_SearchTxt;
         this.AV16SelectedValue = "" ;
         this.AV22SelectedText = "" ;
         this.AV13Combo_DataJson = "" ;
         initialize();
         executePrivate();
         aP5_SelectedValue=this.AV16SelectedValue;
         aP6_SelectedText=this.AV22SelectedText;
         aP7_Combo_DataJson=this.AV13Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                int aP3_ComandoEnviadoId ,
                                string aP4_SearchTxt ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_ComandoEnviadoId, aP4_SearchTxt, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV13Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 int aP3_ComandoEnviadoId ,
                                 string aP4_SearchTxt ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         comandoenviadoloaddvcombo objcomandoenviadoloaddvcombo;
         objcomandoenviadoloaddvcombo = new comandoenviadoloaddvcombo();
         objcomandoenviadoloaddvcombo.AV17ComboName = aP0_ComboName;
         objcomandoenviadoloaddvcombo.AV19TrnMode = aP1_TrnMode;
         objcomandoenviadoloaddvcombo.AV21IsDynamicCall = aP2_IsDynamicCall;
         objcomandoenviadoloaddvcombo.AV25ComandoEnviadoId = aP3_ComandoEnviadoId;
         objcomandoenviadoloaddvcombo.AV12SearchTxt = aP4_SearchTxt;
         objcomandoenviadoloaddvcombo.AV16SelectedValue = "" ;
         objcomandoenviadoloaddvcombo.AV22SelectedText = "" ;
         objcomandoenviadoloaddvcombo.AV13Combo_DataJson = "" ;
         objcomandoenviadoloaddvcombo.context.SetSubmitInitialConfig(context);
         objcomandoenviadoloaddvcombo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objcomandoenviadoloaddvcombo);
         aP5_SelectedValue=this.AV16SelectedValue;
         aP6_SelectedText=this.AV22SelectedText;
         aP7_Combo_DataJson=this.AV13Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((comandoenviadoloaddvcombo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV17ComboName, "RastreadorId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_RASTREADORID' */
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
         /* 'LOADCOMBOITEMS_RASTREADORID' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV12SearchTxt ,
                                                 A110RastreadorSNumber } ,
                                                 new int[]{
                                                 TypeConstants.LONG
                                                 }
            });
            lV12SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV12SearchTxt), "%", "");
            /* Using cursor P004C2 */
            pr_default.execute(0, new Object[] {lV12SearchTxt});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A110RastreadorSNumber = P004C2_A110RastreadorSNumber[0];
               A106RastreadorId = P004C2_A106RastreadorId[0];
               AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV15Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A106RastreadorId), 8, 0));
               AV15Combo_DataItem.gxTpr_Title = StringUtil.Trim( context.localUtil.Format( (decimal)(A110RastreadorSNumber), "ZZZZZZZZZZZZZZZ9"));
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
         else
         {
            if ( StringUtil.StrCmp(AV19TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV19TrnMode, "GET") != 0 )
               {
                  /* Using cursor P004C3 */
                  pr_default.execute(1, new Object[] {AV25ComandoEnviadoId});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A144ComandoEnviadoId = P004C3_A144ComandoEnviadoId[0];
                     A106RastreadorId = P004C3_A106RastreadorId[0];
                     A110RastreadorSNumber = P004C3_A110RastreadorSNumber[0];
                     A110RastreadorSNumber = P004C3_A110RastreadorSNumber[0];
                     AV16SelectedValue = ((0==A106RastreadorId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A106RastreadorId), 8, 0)));
                     AV22SelectedText = ((0==A110RastreadorSNumber) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(A110RastreadorSNumber), "ZZZZZZZZZZZZZZZ9")));
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV24RastreadorId = (int)(NumberUtil.Val( AV12SearchTxt, "."));
                  /* Using cursor P004C4 */
                  pr_default.execute(2, new Object[] {AV24RastreadorId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A106RastreadorId = P004C4_A106RastreadorId[0];
                     A110RastreadorSNumber = P004C4_A110RastreadorSNumber[0];
                     AV22SelectedText = StringUtil.Trim( context.localUtil.Format( (decimal)(A110RastreadorSNumber), "ZZZZZZZZZZZZZZZ9"));
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(2);
               }
            }
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
         AV16SelectedValue = "";
         AV22SelectedText = "";
         AV13Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         scmdbuf = "";
         lV12SearchTxt = "";
         P004C2_A110RastreadorSNumber = new long[1] ;
         P004C2_A106RastreadorId = new int[1] ;
         AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV14Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P004C3_A144ComandoEnviadoId = new int[1] ;
         P004C3_A106RastreadorId = new int[1] ;
         P004C3_A110RastreadorSNumber = new long[1] ;
         P004C4_A106RastreadorId = new int[1] ;
         P004C4_A110RastreadorSNumber = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comandoenviadoloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P004C2_A110RastreadorSNumber, P004C2_A106RastreadorId
               }
               , new Object[] {
               P004C3_A144ComandoEnviadoId, P004C3_A106RastreadorId, P004C3_A110RastreadorSNumber
               }
               , new Object[] {
               P004C4_A106RastreadorId, P004C4_A110RastreadorSNumber
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV25ComandoEnviadoId ;
      private int AV11MaxItems ;
      private int A106RastreadorId ;
      private int A144ComandoEnviadoId ;
      private int AV24RastreadorId ;
      private long A110RastreadorSNumber ;
      private string AV19TrnMode ;
      private string scmdbuf ;
      private bool AV21IsDynamicCall ;
      private bool returnInSub ;
      private string AV13Combo_DataJson ;
      private string AV17ComboName ;
      private string AV12SearchTxt ;
      private string AV16SelectedValue ;
      private string AV22SelectedText ;
      private string lV12SearchTxt ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P004C2_A110RastreadorSNumber ;
      private int[] P004C2_A106RastreadorId ;
      private int[] P004C3_A144ComandoEnviadoId ;
      private int[] P004C3_A106RastreadorId ;
      private long[] P004C3_A110RastreadorSNumber ;
      private int[] P004C4_A106RastreadorId ;
      private long[] P004C4_A110RastreadorSNumber ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV15Combo_DataItem ;
   }

   public class comandoenviadoloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004C2( IGxContext context ,
                                             string AV12SearchTxt ,
                                             long A110RastreadorSNumber )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [RastreadorSNumber], [RastreadorId] FROM [Rastreador]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12SearchTxt)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(16), CAST([RastreadorSNumber] AS decimal(16,0))) like '%' + @lV12SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [RastreadorSNumber]";
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
                     return conditional_P004C2(context, (string)dynConstraints[0] , (long)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP004C3;
          prmP004C3 = new Object[] {
          new Object[] {"@AV25ComandoEnviadoId",SqlDbType.Int,8,0}
          };
          Object[] prmP004C4;
          prmP004C4 = new Object[] {
          new Object[] {"@AV24RastreadorId",SqlDbType.Int,8,0}
          };
          Object[] prmP004C2;
          prmP004C2 = new Object[] {
          new Object[] {"@lV12SearchTxt",SqlDbType.VarChar,40,0}
          };
          def= new CursorDef[] {
              new CursorDef("P004C2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004C2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P004C3", "SELECT T1.[ComandoEnviadoId], T1.[RastreadorId], T2.[RastreadorSNumber] FROM ([ComandoEnviado] T1 INNER JOIN [Rastreador] T2 ON T2.[RastreadorId] = T1.[RastreadorId]) WHERE T1.[ComandoEnviadoId] = @AV25ComandoEnviadoId ORDER BY T1.[ComandoEnviadoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004C3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P004C4", "SELECT TOP 1 [RastreadorId], [RastreadorSNumber] FROM [Rastreador] WHERE [RastreadorId] = @AV24RastreadorId ORDER BY [RastreadorId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004C4,1, GxCacheFrequency.OFF ,false,true )
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
                table[0][0] = rslt.getLong(1);
                table[1][0] = rslt.getInt(2);
                return;
             case 1 :
                table[0][0] = rslt.getInt(1);
                table[1][0] = rslt.getInt(2);
                table[2][0] = rslt.getLong(3);
                return;
             case 2 :
                table[0][0] = rslt.getInt(1);
                table[1][0] = rslt.getLong(2);
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
                   stmt.SetParameter(sIdx, (string)parms[1]);
                }
                return;
             case 1 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 2 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.comandoenviadoloaddvcombo_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class comandoenviadoloaddvcombo_services : GxRestService
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

    [OperationContract(Name = "ComandoEnviadoLoadDVCombo" )]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public void execute( string ComboName ,
                         string TrnMode ,
                         bool IsDynamicCall ,
                         string ComandoEnviadoId ,
                         string SearchTxt ,
                         out string SelectedValue ,
                         out string SelectedText ,
                         out string Combo_DataJson )
    {
       SelectedValue = "" ;
       SelectedText = "" ;
       Combo_DataJson = "" ;
       try
       {
          permissionPrefix = "comandoenviado_Services_Execute";
          if ( ! IsAuthenticated() )
          {
             return  ;
          }
          if ( ! ProcessHeaders("comandoenviadoloaddvcombo") )
          {
             return  ;
          }
          comandoenviadoloaddvcombo worker = new comandoenviadoloaddvcombo(context);
          worker.IsMain = RunAsMain ;
          int gxrComandoEnviadoId = 0;
          gxrComandoEnviadoId = (int)(NumberUtil.Val( (string)(ComandoEnviadoId), "."));
          worker.execute(ComboName,TrnMode,IsDynamicCall,gxrComandoEnviadoId,SearchTxt,out SelectedValue,out SelectedText,out Combo_DataJson );
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
