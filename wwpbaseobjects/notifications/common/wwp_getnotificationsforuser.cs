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
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_getnotificationsforuser : GXProcedure
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
            return "" ;
         }

      }

      public wwp_getnotificationsforuser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_getnotificationsforuser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem>( context, "WWP_SDTNotificationsDataItem", "RastreamentoTCC") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> aP0_Gxm2rootcol )
      {
         wwp_getnotificationsforuser objwwp_getnotificationsforuser;
         objwwp_getnotificationsforuser = new wwp_getnotificationsforuser();
         objwwp_getnotificationsforuser.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem>( context, "WWP_SDTNotificationsDataItem", "RastreamentoTCC") ;
         objwwp_getnotificationsforuser.context.SetSubmitInitialConfig(context);
         objwwp_getnotificationsforuser.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_getnotificationsforuser);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_getnotificationsforuser)stateInfo).executePrivate();
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
         AV11Udparg3 = new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( );
         /* Using cursor P00062 */
         pr_default.execute(0, new Object[] {AV11Udparg3});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1WWPUserExtendedId = P00062_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = P00062_n1WWPUserExtendedId[0];
            A73WWPNotificationIsRead = P00062_A73WWPNotificationIsRead[0];
            A16WWPNotificationId = P00062_A16WWPNotificationId[0];
            A68WWPNotificationIcon = P00062_A68WWPNotificationIcon[0];
            A69WWPNotificationTitle = P00062_A69WWPNotificationTitle[0];
            A70WWPNotificationShortDescription = P00062_A70WWPNotificationShortDescription[0];
            A71WWPNotificationLink = P00062_A71WWPNotificationLink[0];
            A37WWPNotificationCreated = P00062_A37WWPNotificationCreated[0];
            Gxm1wwp_sdtnotificationsdata = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem(context);
            Gxm2rootcol.Add(Gxm1wwp_sdtnotificationsdata, 0);
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationid = (int)(A16WWPNotificationId);
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationiconclass = "NotificationFontIcon"+" "+A68WWPNotificationIcon;
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationtitle = A69WWPNotificationTitle;
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationdescription = A70WWPNotificationShortDescription;
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationdatetime = A37WWPNotificationCreated;
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationlink = A71WWPNotificationLink;
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         AV11Udparg3 = "";
         scmdbuf = "";
         P00062_A1WWPUserExtendedId = new string[] {""} ;
         P00062_n1WWPUserExtendedId = new bool[] {false} ;
         P00062_A73WWPNotificationIsRead = new bool[] {false} ;
         P00062_A16WWPNotificationId = new long[1] ;
         P00062_A68WWPNotificationIcon = new string[] {""} ;
         P00062_A69WWPNotificationTitle = new string[] {""} ;
         P00062_A70WWPNotificationShortDescription = new string[] {""} ;
         P00062_A71WWPNotificationLink = new string[] {""} ;
         P00062_A37WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         A1WWPUserExtendedId = "";
         A68WWPNotificationIcon = "";
         A69WWPNotificationTitle = "";
         A70WWPNotificationShortDescription = "";
         A71WWPNotificationLink = "";
         A37WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Gxm1wwp_sdtnotificationsdata = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_getnotificationsforuser__default(),
            new Object[][] {
                new Object[] {
               P00062_A1WWPUserExtendedId, P00062_n1WWPUserExtendedId, P00062_A73WWPNotificationIsRead, P00062_A16WWPNotificationId, P00062_A68WWPNotificationIcon, P00062_A69WWPNotificationTitle, P00062_A70WWPNotificationShortDescription, P00062_A71WWPNotificationLink, P00062_A37WWPNotificationCreated
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private long A16WWPNotificationId ;
      private string AV11Udparg3 ;
      private string scmdbuf ;
      private string A1WWPUserExtendedId ;
      private DateTime A37WWPNotificationCreated ;
      private bool n1WWPUserExtendedId ;
      private bool A73WWPNotificationIsRead ;
      private string A68WWPNotificationIcon ;
      private string A69WWPNotificationTitle ;
      private string A70WWPNotificationShortDescription ;
      private string A71WWPNotificationLink ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00062_A1WWPUserExtendedId ;
      private bool[] P00062_n1WWPUserExtendedId ;
      private bool[] P00062_A73WWPNotificationIsRead ;
      private long[] P00062_A16WWPNotificationId ;
      private string[] P00062_A68WWPNotificationIcon ;
      private string[] P00062_A69WWPNotificationTitle ;
      private string[] P00062_A70WWPNotificationShortDescription ;
      private string[] P00062_A71WWPNotificationLink ;
      private DateTime[] P00062_A37WWPNotificationCreated ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> Gxm2rootcol ;
      private GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem Gxm1wwp_sdtnotificationsdata ;
   }

   public class wwp_getnotificationsforuser__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00062;
          prmP00062 = new Object[] {
          new Object[] {"@AV11Udparg3",SqlDbType.NChar,40,0}
          };
          def= new CursorDef[] {
              new CursorDef("P00062", "SELECT [WWPUserExtendedId], [WWPNotificationIsRead], [WWPNotificationId], [WWPNotificationIcon], [WWPNotificationTitle], [WWPNotificationShortDescription], [WWPNotificationLink], [WWPNotificationCreated] FROM [WWP_Notification] WHERE (Not [WWPNotificationIsRead] = 1) AND ([WWPUserExtendedId] = @AV11Udparg3) ORDER BY [WWPNotificationCreated] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00062,100, GxCacheFrequency.OFF ,false,false )
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
                table[0][0] = rslt.getString(1, 40);
                table[1][0] = rslt.wasNull(1);
                table[2][0] = rslt.getBool(2);
                table[3][0] = rslt.getLong(3);
                table[4][0] = rslt.getVarchar(4);
                table[5][0] = rslt.getVarchar(5);
                table[6][0] = rslt.getVarchar(6);
                table[7][0] = rslt.getVarchar(7);
                table[8][0] = rslt.getGXDateTime(8, true);
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
       }
    }

 }

}
