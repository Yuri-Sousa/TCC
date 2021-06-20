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
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects.notifications.web {
   public class wwp_registerwebclient : GXProcedure
   {
      public wwp_registerwebclient( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_registerwebclient( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( string aP0_ClientId ,
                           short aP1_BrowserId ,
                           string aP2_BrowserVersion ,
                           string aP3_UserGUID )
      {
         this.AV10ClientId = aP0_ClientId;
         this.AV8BrowserId = aP1_BrowserId;
         this.AV9BrowserVersion = aP2_BrowserVersion;
         this.AV14UserGUID = aP3_UserGUID;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_ClientId ,
                                 short aP1_BrowserId ,
                                 string aP2_BrowserVersion ,
                                 string aP3_UserGUID )
      {
         wwp_registerwebclient objwwp_registerwebclient;
         objwwp_registerwebclient = new wwp_registerwebclient();
         objwwp_registerwebclient.AV10ClientId = aP0_ClientId;
         objwwp_registerwebclient.AV8BrowserId = aP1_BrowserId;
         objwwp_registerwebclient.AV9BrowserVersion = aP2_BrowserVersion;
         objwwp_registerwebclient.AV14UserGUID = aP3_UserGUID;
         objwwp_registerwebclient.context.SetSubmitInitialConfig(context);
         objwwp_registerwebclient.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_registerwebclient);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_registerwebclient)stateInfo).executePrivate();
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
         new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV17Pgmname,  "Begin Web Client Registration") ;
         AV18GXLvl3 = 0;
         /* Using cursor P002H2 */
         pr_default.execute(0, new Object[] {AV10ClientId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A18WWPWebClientId = P002H2_A18WWPWebClientId[0];
            A43WWPWebClientBrowserId = P002H2_A43WWPWebClientBrowserId[0];
            A44WWPWebClientBrowserVersion = P002H2_A44WWPWebClientBrowserVersion[0];
            A46WWPWebClientLastRegistered = P002H2_A46WWPWebClientLastRegistered[0];
            A1WWPUserExtendedId = P002H2_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = P002H2_n1WWPUserExtendedId[0];
            AV18GXLvl3 = 1;
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV17Pgmname,  "Updating Web Client") ;
            A43WWPWebClientBrowserId = AV8BrowserId;
            A44WWPWebClientBrowserVersion = AV9BrowserVersion;
            A46WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
            A1WWPUserExtendedId = AV14UserGUID;
            n1WWPUserExtendedId = false;
            /* Using cursor P002H3 */
            pr_default.execute(1, new Object[] {A43WWPWebClientBrowserId, A44WWPWebClientBrowserVersion, A46WWPWebClientLastRegistered, n1WWPUserExtendedId, A1WWPUserExtendedId, A18WWPWebClientId});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("WWP_WebClient");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV18GXLvl3 == 0 )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV17Pgmname,  "Creating Web Client") ;
            if ( ! new GeneXus.Programs.wwpbaseobjects.wwp_existsuserextended(context).executeUdp(  AV14UserGUID) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV17Pgmname,  StringUtil.Format( "Creating User Extended %1...", AV14UserGUID, "", "", "", "", "", "", "", "")) ;
               new GeneXus.Programs.wwpbaseobjects.wwp_createuserextended(context ).execute(  AV14UserGUID,  "") ;
            }
            /*
               INSERT RECORD ON TABLE WWP_WebClient

            */
            A18WWPWebClientId = AV10ClientId;
            A43WWPWebClientBrowserId = AV8BrowserId;
            A44WWPWebClientBrowserVersion = AV9BrowserVersion;
            A45WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
            A46WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
            A1WWPUserExtendedId = AV14UserGUID;
            n1WWPUserExtendedId = false;
            /* Using cursor P002H4 */
            pr_default.execute(2, new Object[] {A18WWPWebClientId, A43WWPWebClientBrowserId, A44WWPWebClientBrowserVersion, A45WWPWebClientFirstRegistered, A46WWPWebClientLastRegistered, n1WWPUserExtendedId, A1WWPUserExtendedId});
            pr_default.close(2);
            dsDefault.SmartCacheProvider.SetUpdated("WWP_WebClient");
            if ( (pr_default.getStatus(2) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
         }
         new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV17Pgmname,  "Completed Web Client Registration") ;
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("wwpbaseobjects.notifications.web.wwp_registerwebclient",pr_default);
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
         AV17Pgmname = "";
         scmdbuf = "";
         P002H2_A18WWPWebClientId = new string[] {""} ;
         P002H2_A43WWPWebClientBrowserId = new short[1] ;
         P002H2_A44WWPWebClientBrowserVersion = new string[] {""} ;
         P002H2_A46WWPWebClientLastRegistered = new DateTime[] {DateTime.MinValue} ;
         P002H2_A1WWPUserExtendedId = new string[] {""} ;
         P002H2_n1WWPUserExtendedId = new bool[] {false} ;
         A18WWPWebClientId = "";
         A44WWPWebClientBrowserVersion = "";
         A46WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         A1WWPUserExtendedId = "";
         A45WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_registerwebclient__default(),
            new Object[][] {
                new Object[] {
               P002H2_A18WWPWebClientId, P002H2_A43WWPWebClientBrowserId, P002H2_A44WWPWebClientBrowserVersion, P002H2_A46WWPWebClientLastRegistered, P002H2_A1WWPUserExtendedId, P002H2_n1WWPUserExtendedId
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         AV17Pgmname = "WWPBaseObjects.Notifications.Web.WWP_RegisterWebClient";
         /* GeneXus formulas. */
         AV17Pgmname = "WWPBaseObjects.Notifications.Web.WWP_RegisterWebClient";
         context.Gx_err = 0;
      }

      private short AV8BrowserId ;
      private short AV18GXLvl3 ;
      private short A43WWPWebClientBrowserId ;
      private int GX_INS6 ;
      private string AV10ClientId ;
      private string AV14UserGUID ;
      private string AV17Pgmname ;
      private string scmdbuf ;
      private string A18WWPWebClientId ;
      private string A1WWPUserExtendedId ;
      private string Gx_emsg ;
      private DateTime A46WWPWebClientLastRegistered ;
      private DateTime A45WWPWebClientFirstRegistered ;
      private bool n1WWPUserExtendedId ;
      private string AV9BrowserVersion ;
      private string A44WWPWebClientBrowserVersion ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P002H2_A18WWPWebClientId ;
      private short[] P002H2_A43WWPWebClientBrowserId ;
      private string[] P002H2_A44WWPWebClientBrowserVersion ;
      private DateTime[] P002H2_A46WWPWebClientLastRegistered ;
      private string[] P002H2_A1WWPUserExtendedId ;
      private bool[] P002H2_n1WWPUserExtendedId ;
   }

   public class wwp_registerwebclient__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new UpdateCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002H2;
          prmP002H2 = new Object[] {
          new Object[] {"@AV10ClientId",SqlDbType.NChar,100,0}
          };
          Object[] prmP002H3;
          prmP002H3 = new Object[] {
          new Object[] {"@WWPWebClientBrowserId",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@WWPWebClientBrowserVersion",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@WWPWebClientLastRegistered",SqlDbType.DateTime2,10,12} ,
          new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0} ,
          new Object[] {"@WWPWebClientId",SqlDbType.NChar,100,0}
          };
          Object[] prmP002H4;
          prmP002H4 = new Object[] {
          new Object[] {"@WWPWebClientId",SqlDbType.NChar,100,0} ,
          new Object[] {"@WWPWebClientBrowserId",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@WWPWebClientBrowserVersion",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@WWPWebClientFirstRegistered",SqlDbType.DateTime2,10,12} ,
          new Object[] {"@WWPWebClientLastRegistered",SqlDbType.DateTime2,10,12} ,
          new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
          };
          def= new CursorDef[] {
              new CursorDef("P002H2", "SELECT [WWPWebClientId], [WWPWebClientBrowserId], [WWPWebClientBrowserVersion], [WWPWebClientLastRegistered], [WWPUserExtendedId] FROM [WWP_WebClient] WITH (UPDLOCK) WHERE [WWPWebClientId] = @AV10ClientId ORDER BY [WWPWebClientId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002H2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P002H3", "UPDATE [WWP_WebClient] SET [WWPWebClientBrowserId]=@WWPWebClientBrowserId, [WWPWebClientBrowserVersion]=@WWPWebClientBrowserVersion, [WWPWebClientLastRegistered]=@WWPWebClientLastRegistered, [WWPUserExtendedId]=@WWPUserExtendedId  WHERE [WWPWebClientId] = @WWPWebClientId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP002H3)
             ,new CursorDef("P002H4", "INSERT INTO [WWP_WebClient]([WWPWebClientId], [WWPWebClientBrowserId], [WWPWebClientBrowserVersion], [WWPWebClientFirstRegistered], [WWPWebClientLastRegistered], [WWPUserExtendedId]) VALUES(@WWPWebClientId, @WWPWebClientBrowserId, @WWPWebClientBrowserVersion, @WWPWebClientFirstRegistered, @WWPWebClientLastRegistered, @WWPUserExtendedId)", GxErrorMask.GX_NOMASK,prmP002H4)
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
                table[0][0] = rslt.getString(1, 100);
                table[1][0] = rslt.getShort(2);
                table[2][0] = rslt.getLongVarchar(3);
                table[3][0] = rslt.getGXDateTime(4, true);
                table[4][0] = rslt.getString(5, 40);
                table[5][0] = rslt.wasNull(5);
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
                return;
             case 1 :
                stmt.SetParameter(1, (short)parms[0]);
                stmt.SetParameter(2, (string)parms[1]);
                stmt.SetParameterDatetime(3, (DateTime)parms[2], true);
                if ( (bool)parms[3] )
                {
                   stmt.setNull( 4 , SqlDbType.NChar );
                }
                else
                {
                   stmt.SetParameter(4, (string)parms[4]);
                }
                stmt.SetParameter(5, (string)parms[5]);
                return;
             case 2 :
                stmt.SetParameter(1, (string)parms[0]);
                stmt.SetParameter(2, (short)parms[1]);
                stmt.SetParameter(3, (string)parms[2]);
                stmt.SetParameterDatetime(4, (DateTime)parms[3], true);
                stmt.SetParameterDatetime(5, (DateTime)parms[4], true);
                if ( (bool)parms[5] )
                {
                   stmt.setNull( 6 , SqlDbType.NChar );
                }
                else
                {
                   stmt.SetParameter(6, (string)parms[6]);
                }
                return;
       }
    }

 }

}
