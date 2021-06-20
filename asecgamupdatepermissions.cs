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
namespace GeneXus.Programs {
   public class asecgamupdatepermissions : GXProcedure
   {
      public static int Main( string[] args )
      {
         try
         {
            GeneXus.Configuration.Config.ParseArgs(ref args);
            return new asecgamupdatepermissions().executeCmdLine(args); ;
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            Console.WriteLine( e.ToString() );
            return 1 ;
         }
      }

      public int executeCmdLine( string[] args )
      {
         execute();
         return GX.GXRuntime.ExitCode ;
      }

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

      public asecgamupdatepermissions( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public asecgamupdatepermissions( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
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
         asecgamupdatepermissions objasecgamupdatepermissions;
         objasecgamupdatepermissions = new asecgamupdatepermissions();
         objasecgamupdatepermissions.context.SetSubmitInitialConfig(context);
         objasecgamupdatepermissions.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objasecgamupdatepermissions);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((asecgamupdatepermissions)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            Console.WriteLine( e.ToString() );
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV24RoleName = "";
         AV14GAMApplicationId = "";
         context.StatusMessage( StringUtil.Format( "Administrator role: '%1'", AV24RoleName, "", "", "", "", "", "", "", "") );
         context.StatusMessage( StringUtil.Format( "GAM application id: '%1'", AV14GAMApplicationId, "", "", "", "", "", "", "", "") );
         AV13GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getapplicationbyguid(StringUtil.StrToGuid( AV14GAMApplicationId).ToString(), out  AV11Errors);
         GXt_objcol_SdtSecGAMFunctionalitiesToLoad1 = AV27SecGAMFunctionalitiesToLoadCollection;
         new GeneXus.Programs.wwpbaseobjects.secgamgetadvancedsecuritywwpfunctionalities(context ).execute( out  GXt_objcol_SdtSecGAMFunctionalitiesToLoad1) ;
         AV27SecGAMFunctionalitiesToLoadCollection = GXt_objcol_SdtSecGAMFunctionalitiesToLoad1;
         AV23isOK = true;
         AV18GAMApplicationPermissions = AV13GAMApplication.getpermissions(AV16GAMApplicationPermissionFilter, out  AV11Errors);
         AV21GAMRoleFilter.gxTpr_Name = AV24RoleName;
         AV30GXV1 = 1;
         while ( AV30GXV1 <= AV18GAMApplicationPermissions.Count )
         {
            AV15GAMApplicationPermission = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission)AV18GAMApplicationPermissions.Item(AV30GXV1));
            if ( ! ( ( StringUtil.StrCmp(StringUtil.Lower( AV15GAMApplicationPermission.gxTpr_Name), "is_gam_administrator") == 0 ) || StringUtil.Like( StringUtil.Lower( AV15GAMApplicationPermission.gxTpr_Name) , StringUtil.PadR( "%_execute" , 254 , "%"),  ' ' ) || StringUtil.Like( StringUtil.Lower( AV15GAMApplicationPermission.gxTpr_Name) , StringUtil.PadR( "%_insert" , 254 , "%"),  ' ' ) || StringUtil.Like( StringUtil.Lower( AV15GAMApplicationPermission.gxTpr_Name) , StringUtil.PadR( "%_update" , 254 , "%"),  ' ' ) || StringUtil.Like( StringUtil.Lower( AV15GAMApplicationPermission.gxTpr_Name) , StringUtil.PadR( "%_delete" , 254 , "%"),  ' ' ) || StringUtil.Like( StringUtil.Lower( AV15GAMApplicationPermission.gxTpr_Name) , StringUtil.PadR( "%_fullcontrol" , 254 , "%"),  ' ' ) || StringUtil.Like( StringUtil.Lower( AV15GAMApplicationPermission.gxTpr_Name) , StringUtil.PadR( "custom_%" , 254 , "%"),  ' ' ) ) )
            {
               AV17GAMApplicationPermissionName = AV15GAMApplicationPermission.gxTpr_Name;
               /* Execute user subroutine: 'SEARCHPERMISSIONINDATAPROVIDER' */
               S111 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
               if ( ! AV12Exists )
               {
                  AV32GXV3 = 1;
                  AV31GXV2 = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getroles(AV21GAMRoleFilter, out  AV11Errors);
                  while ( AV32GXV3 <= AV31GXV2.Count )
                  {
                     AV20GAMRole = ((GeneXus.Programs.genexussecurity.SdtGAMRole)AV31GXV2.Item(AV32GXV3));
                     AV8GAMPermissionFilter.gxTpr_Applicationid = AV13GAMApplication.gxTpr_Id;
                     AV8GAMPermissionFilter.gxTpr_Name = StringUtil.Trim( AV15GAMApplicationPermission.gxTpr_Name);
                     AV34GXV5 = 1;
                     AV33GXV4 = AV20GAMRole.getpermissions(AV8GAMPermissionFilter, out  AV11Errors);
                     while ( AV34GXV5 <= AV33GXV4.Count )
                     {
                        AV19GAMPermission = ((GeneXus.Programs.genexussecurity.SdtGAMPermission)AV33GXV4.Item(AV34GXV5));
                        context.StatusMessage( StringUtil.Format( "Deleting permission '%1' from role '%2'...", StringUtil.Trim( AV15GAMApplicationPermission.gxTpr_Name), StringUtil.Trim( AV20GAMRole.gxTpr_Name), "", "", "", "", "", "", "") );
                        AV23isOK = AV20GAMRole.deletepermission(AV19GAMPermission, out  AV11Errors);
                        if ( ! AV23isOK )
                        {
                           context.StatusMessage( StringUtil.Format( "The following errors ocurred while deleting permission '%1' from role '%2':", StringUtil.Trim( AV15GAMApplicationPermission.gxTpr_Name), AV20GAMRole.gxTpr_Name, "", "", "", "", "", "", "") );
                           /* Execute user subroutine: 'SHOWERRORMESSAGES' */
                           S131 ();
                           if ( returnInSub )
                           {
                              this.cleanup();
                              if (true) return;
                           }
                        }
                        AV34GXV5 = (int)(AV34GXV5+1);
                     }
                     AV32GXV3 = (int)(AV32GXV3+1);
                  }
                  context.StatusMessage( StringUtil.Format( "Deleting permission '%1' from GAM repository...", StringUtil.Trim( AV15GAMApplicationPermission.gxTpr_Name), "", "", "", "", "", "", "", "") );
                  AV23isOK = AV13GAMApplication.deletepermission(AV15GAMApplicationPermission, out  AV11Errors);
                  if ( ! AV23isOK )
                  {
                     context.StatusMessage( StringUtil.Format( "The following errors ocurred while deleting permission '%1':", AV15GAMApplicationPermission.gxTpr_Name, "", "", "", "", "", "", "", "") );
                     /* Execute user subroutine: 'SHOWERRORMESSAGES' */
                     S131 ();
                     if ( returnInSub )
                     {
                        this.cleanup();
                        if (true) return;
                     }
                  }
               }
            }
            AV30GXV1 = (int)(AV30GXV1+1);
         }
         if ( AV23isOK )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV24RoleName))) )
            {
               context.StatusMessage( StringUtil.Format( "Getting role '%1' from GAM repository...", AV24RoleName, "", "", "", "", "", "", "", "") );
               AV13GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getapplicationbyguid(StringUtil.StrToGuid( AV14GAMApplicationId).ToString(), out  AV11Errors);
               AV36GXV7 = 1;
               AV35GXV6 = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getroles(AV21GAMRoleFilter, out  AV11Errors);
               while ( AV36GXV7 <= AV35GXV6.Count )
               {
                  AV20GAMRole = ((GeneXus.Programs.genexussecurity.SdtGAMRole)AV35GXV6.Item(AV36GXV7));
                  if ( StringUtil.StrCmp(StringUtil.Trim( AV20GAMRole.gxTpr_Name), StringUtil.Trim( AV24RoleName)) == 0 )
                  {
                     AV22Id = AV20GAMRole.gxTpr_Id;
                     if (true) break;
                  }
                  AV36GXV7 = (int)(AV36GXV7+1);
               }
               if ( (0==AV22Id) )
               {
                  context.StatusMessage( StringUtil.Format( "Role '%1' not found", AV24RoleName, "", "", "", "", "", "", "", "") );
                  AV21GAMRoleFilter = new GeneXus.Programs.genexussecurity.SdtGAMRoleFilter(context);
                  AV25RoleNames = "";
                  AV38GXV9 = 1;
                  AV37GXV8 = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getroles(AV21GAMRoleFilter, out  AV11Errors);
                  while ( AV38GXV9 <= AV37GXV8.Count )
                  {
                     AV20GAMRole = ((GeneXus.Programs.genexussecurity.SdtGAMRole)AV37GXV8.Item(AV38GXV9));
                     AV25RoleNames += ", " + StringUtil.Trim( AV20GAMRole.gxTpr_Name);
                     AV38GXV9 = (int)(AV38GXV9+1);
                  }
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25RoleNames)) )
                  {
                     context.StatusMessage( StringUtil.Format( "The available roles are: %1", StringUtil.Substring( AV25RoleNames, 3, StringUtil.Len( AV25RoleNames)-2), "", "", "", "", "", "", "", "") );
                  }
               }
            }
            if ( ! (0==AV22Id) )
            {
               AV20GAMRole.load( AV22Id);
            }
            AV39GXV10 = 1;
            while ( AV39GXV10 <= AV27SecGAMFunctionalitiesToLoadCollection.Count )
            {
               AV26SecGAMFunctionalitiesToLoad = ((GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad)AV27SecGAMFunctionalitiesToLoadCollection.Item(AV39GXV10));
               /* Execute user subroutine: 'SEARCHPERMISSIONALREADYCREATED' */
               S121 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
               if ( ! AV12Exists )
               {
                  AV9ApplicationPermission = new GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission(context);
                  AV9ApplicationPermission.gxTpr_Name = AV26SecGAMFunctionalitiesToLoad.gxTpr_Secgamfunctionalitykey;
                  if ( StringUtil.StrCmp(AV26SecGAMFunctionalitiesToLoad.gxTpr_Secgamfunctionalitydsc, "") != 0 )
                  {
                     AV9ApplicationPermission.gxTpr_Description = AV26SecGAMFunctionalitiesToLoad.gxTpr_Secgamfunctionalitydsc;
                  }
                  else
                  {
                     AV9ApplicationPermission.gxTpr_Description = AV26SecGAMFunctionalitiesToLoad.gxTpr_Secgamfunctionalitykey;
                  }
                  AV9ApplicationPermission.gxTpr_Accesstype = "R";
                  context.StatusMessage( StringUtil.Format( "Adding permission '%1' to GAM repository...", StringUtil.Trim( AV9ApplicationPermission.gxTpr_Name), "", "", "", "", "", "", "", "") );
                  AV23isOK = AV13GAMApplication.addpermission(AV9ApplicationPermission, out  AV11Errors);
                  if ( AV23isOK )
                  {
                     if ( ! (0==AV22Id) )
                     {
                        AV19GAMPermission = new GeneXus.Programs.genexussecurity.SdtGAMPermission(context);
                        AV19GAMPermission.gxTpr_Applicationid = AV13GAMApplication.gxTpr_Id;
                        AV19GAMPermission.gxTpr_Description = AV26SecGAMFunctionalitiesToLoad.gxTpr_Secgamfunctionalitykey;
                        AV19GAMPermission.gxTpr_Name = AV9ApplicationPermission.gxTpr_Name;
                        AV19GAMPermission.gxTpr_Type = "A";
                        AV19GAMPermission.gxTpr_Guid = AV9ApplicationPermission.gxTpr_Guid;
                        context.StatusMessage( StringUtil.Format( "Adding permission '%1' to role '%2'...", StringUtil.Trim( AV9ApplicationPermission.gxTpr_Name), AV24RoleName, "", "", "", "", "", "", "") );
                        AV23isOK = AV20GAMRole.addpermission(AV19GAMPermission, out  AV11Errors);
                        if ( ! AV23isOK )
                        {
                           context.StatusMessage( StringUtil.Format( "The following errors ocurred while adding permission '%1' to role '%2':", StringUtil.Trim( AV9ApplicationPermission.gxTpr_Name), AV24RoleName, "", "", "", "", "", "", "") );
                           /* Execute user subroutine: 'SHOWERRORMESSAGES' */
                           S131 ();
                           if ( returnInSub )
                           {
                              this.cleanup();
                              if (true) return;
                           }
                        }
                     }
                  }
                  else
                  {
                     context.StatusMessage( StringUtil.Format( "The following errors ocurred while adding permission '%1':", StringUtil.Trim( AV9ApplicationPermission.gxTpr_Name), "", "", "", "", "", "", "", "") );
                     /* Execute user subroutine: 'SHOWERRORMESSAGES' */
                     S131 ();
                     if ( returnInSub )
                     {
                        this.cleanup();
                        if (true) return;
                     }
                  }
               }
               AV39GXV10 = (int)(AV39GXV10+1);
            }
         }
         if ( AV23isOK )
         {
            context.CommitDataStores("secgamupdatepermissions",pr_default);
            context.StatusMessage( "The changes were commited" );
         }
         else
         {
            context.StatusMessage( "The changes were not commited" );
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'SEARCHPERMISSIONINDATAPROVIDER' Routine */
         returnInSub = false;
         AV12Exists = false;
         AV40GXV11 = 1;
         while ( AV40GXV11 <= AV27SecGAMFunctionalitiesToLoadCollection.Count )
         {
            AV26SecGAMFunctionalitiesToLoad = ((GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad)AV27SecGAMFunctionalitiesToLoadCollection.Item(AV40GXV11));
            if ( StringUtil.StrCmp(AV26SecGAMFunctionalitiesToLoad.gxTpr_Secgamfunctionalitykey, AV17GAMApplicationPermissionName) == 0 )
            {
               AV12Exists = true;
               if (true) break;
            }
            AV40GXV11 = (int)(AV40GXV11+1);
         }
      }

      protected void S121( )
      {
         /* 'SEARCHPERMISSIONALREADYCREATED' Routine */
         returnInSub = false;
         AV12Exists = false;
         AV41GXV12 = 1;
         while ( AV41GXV12 <= AV18GAMApplicationPermissions.Count )
         {
            AV15GAMApplicationPermission = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission)AV18GAMApplicationPermissions.Item(AV41GXV12));
            if ( StringUtil.StrCmp(AV15GAMApplicationPermission.gxTpr_Name, AV26SecGAMFunctionalitiesToLoad.gxTpr_Secgamfunctionalitykey) == 0 )
            {
               AV12Exists = true;
               if (true) break;
            }
            AV41GXV12 = (int)(AV41GXV12+1);
         }
      }

      protected void S131( )
      {
         /* 'SHOWERRORMESSAGES' Routine */
         returnInSub = false;
         AV42GXV13 = 1;
         while ( AV42GXV13 <= AV11Errors.Count )
         {
            AV10Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV11Errors.Item(AV42GXV13));
            context.StatusMessage( StringUtil.Format( "%1 (GAM%2)", AV10Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV10Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", "") );
            AV42GXV13 = (int)(AV42GXV13+1);
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
         AV24RoleName = "";
         AV14GAMApplicationId = "";
         AV13GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV11Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV27SecGAMFunctionalitiesToLoadCollection = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad>( context, "SecGAMFunctionalitiesToLoad", "RastreamentoTCC");
         GXt_objcol_SdtSecGAMFunctionalitiesToLoad1 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad>( context, "SecGAMFunctionalitiesToLoad", "RastreamentoTCC");
         AV18GAMApplicationPermissions = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission>( context, "GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission", "GeneXus.Programs");
         AV16GAMApplicationPermissionFilter = new GeneXus.Programs.genexussecurity.SdtGAMApplicationPermissionFilter(context);
         AV21GAMRoleFilter = new GeneXus.Programs.genexussecurity.SdtGAMRoleFilter(context);
         AV15GAMApplicationPermission = new GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission(context);
         AV17GAMApplicationPermissionName = "";
         AV31GXV2 = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole>( context, "GeneXus.Programs.genexussecurity.SdtGAMRole", "GeneXus.Programs");
         AV20GAMRole = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV8GAMPermissionFilter = new GeneXus.Programs.genexussecurity.SdtGAMPermissionFilter(context);
         AV33GXV4 = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMPermission>( context, "GeneXus.Programs.genexussecurity.SdtGAMPermission", "GeneXus.Programs");
         AV19GAMPermission = new GeneXus.Programs.genexussecurity.SdtGAMPermission(context);
         AV35GXV6 = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole>( context, "GeneXus.Programs.genexussecurity.SdtGAMRole", "GeneXus.Programs");
         AV25RoleNames = "";
         AV37GXV8 = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole>( context, "GeneXus.Programs.genexussecurity.SdtGAMRole", "GeneXus.Programs");
         AV26SecGAMFunctionalitiesToLoad = new GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad(context);
         AV9ApplicationPermission = new GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission(context);
         AV10Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.asecgamupdatepermissions__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.asecgamupdatepermissions__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV30GXV1 ;
      private int AV32GXV3 ;
      private int AV34GXV5 ;
      private int AV36GXV7 ;
      private int AV38GXV9 ;
      private int AV39GXV10 ;
      private int AV40GXV11 ;
      private int AV41GXV12 ;
      private int AV42GXV13 ;
      private long AV22Id ;
      private string AV14GAMApplicationId ;
      private string AV17GAMApplicationPermissionName ;
      private bool AV23isOK ;
      private bool returnInSub ;
      private bool AV12Exists ;
      private string AV24RoleName ;
      private string AV25RoleNames ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission> AV18GAMApplicationPermissions ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV11Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole> AV31GXV2 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole> AV35GXV6 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole> AV37GXV8 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMPermission> AV33GXV4 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad> AV27SecGAMFunctionalitiesToLoadCollection ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad> GXt_objcol_SdtSecGAMFunctionalitiesToLoad1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMPermissionFilter AV8GAMPermissionFilter ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission AV15GAMApplicationPermission ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission AV9ApplicationPermission ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV10Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV13GAMApplication ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationPermissionFilter AV16GAMApplicationPermissionFilter ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV20GAMRole ;
      private GeneXus.Programs.genexussecurity.SdtGAMRoleFilter AV21GAMRoleFilter ;
      private GeneXus.Programs.genexussecurity.SdtGAMPermission AV19GAMPermission ;
      private GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad AV26SecGAMFunctionalitiesToLoad ;
   }

   public class asecgamupdatepermissions__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
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
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       switch ( cursor )
       {
       }
    }

    public string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class asecgamupdatepermissions__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
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
     }
  }

  public void setParameters( int cursor ,
                             IFieldSetter stmt ,
                             Object[] parms )
  {
     switch ( cursor )
     {
     }
  }

}

}
