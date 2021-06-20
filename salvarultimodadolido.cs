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
   public class salvarultimodadolido : GXProcedure
   {
      public salvarultimodadolido( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public salvarultimodadolido( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( string aP0_topic ,
                           string aP1_message ,
                           DateTime aP2_messagetimestamp )
      {
         this.AV9topic = aP0_topic;
         this.AV10message = aP1_message;
         this.AV11messagetimestamp = aP2_messagetimestamp;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_topic ,
                                 string aP1_message ,
                                 DateTime aP2_messagetimestamp )
      {
         salvarultimodadolido objsalvarultimodadolido;
         objsalvarultimodadolido = new salvarultimodadolido();
         objsalvarultimodadolido.AV9topic = aP0_topic;
         objsalvarultimodadolido.AV10message = aP1_message;
         objsalvarultimodadolido.AV11messagetimestamp = aP2_messagetimestamp;
         objsalvarultimodadolido.context.SetSubmitInitialConfig(context);
         objsalvarultimodadolido.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objsalvarultimodadolido);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((salvarultimodadolido)stateInfo).executePrivate();
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
         /* User Code */
          try
         /* User Code */
          {
         AV12Properties.FromJSonString(AV10message, null);
         if ( ( ! ( NumberUtil.Val( AV12Properties.Get("position.latitude"), ".") == 0.00000000m ) ) && ( ! ( NumberUtil.Val( AV12Properties.Get("position.longitude"), ".") == 0.00000000m ) ) )
         {
            AV14UltimoDadoLidoIdent = (long)(NumberUtil.Val( AV12Properties.Get("ident"), "."));
            AV19GXLvl11 = 0;
            /* Using cursor P003K2 */
            pr_default.execute(0, new Object[] {AV14UltimoDadoLidoIdent});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A126UltimoDadoLidoIdent = P003K2_A126UltimoDadoLidoIdent[0];
               A118UltimoDadoLidoId = P003K2_A118UltimoDadoLidoId[0];
               A119UltimoDadoLidoDataHoraServidor = P003K2_A119UltimoDadoLidoDataHoraServidor[0];
               A120UltimoDadoLidoDataHoraRastreador = P003K2_A120UltimoDadoLidoDataHoraRastreador[0];
               A122UltimoDadoLidoIgnicao = P003K2_A122UltimoDadoLidoIgnicao[0];
               A125UltimoDadoLidoVelocidade = P003K2_A125UltimoDadoLidoVelocidade[0];
               A123UltimoDadoLidoLatitude = P003K2_A123UltimoDadoLidoLatitude[0];
               A124UltimoDadoLidoLongitude = P003K2_A124UltimoDadoLidoLongitude[0];
               A121UltimoDadoLidoPlaca = P003K2_A121UltimoDadoLidoPlaca[0];
               AV19GXLvl11 = 1;
               AV15UltimoDadoLidoId = A118UltimoDadoLidoId;
               A119UltimoDadoLidoDataHoraServidor = new SdtUtil(context).timestamptodatetime(NumberUtil.Val( AV12Properties.Get("server.timestamp"), "."));
               A120UltimoDadoLidoDataHoraRastreador = new SdtUtil(context).timestamptodatetime(NumberUtil.Val( StringUtil.Trim( AV12Properties.Get("timestamp")), "."));
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12Properties.Get("engine.ignition.status"))) )
               {
                  if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.Lower( AV12Properties.Get("engine.ignition.status"))), "true") == 0 )
                  {
                     A122UltimoDadoLidoIgnicao = 1;
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.Lower( AV12Properties.Get("engine.ignition.status"))), "false") == 0 )
                  {
                     A122UltimoDadoLidoIgnicao = 2;
                  }
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12Properties.Get("position.speed"))) )
               {
                  A125UltimoDadoLidoVelocidade = (short)(NumberUtil.Val( AV12Properties.Get("position.speed"), "."));
               }
               A123UltimoDadoLidoLatitude = StringUtil.Trim( AV12Properties.Get("position.latitude"));
               A124UltimoDadoLidoLongitude = StringUtil.Trim( AV12Properties.Get("position.longitude"));
               if ( String.IsNullOrEmpty(StringUtil.RTrim( A121UltimoDadoLidoPlaca)) )
               {
                  GXt_char1 = A121UltimoDadoLidoPlaca;
                  new buscarplacarastreador(context ).execute(  AV14UltimoDadoLidoIdent, out  GXt_char1) ;
                  A121UltimoDadoLidoPlaca = GXt_char1;
               }
               AV16SDTNovaPosicao = new SdtSDTNovaPosicao(context);
               AV16SDTNovaPosicao.gxTpr_Placa = StringUtil.Trim( A121UltimoDadoLidoPlaca);
               AV16SDTNovaPosicao.gxTpr_Ignicao = gxdomaindomignicao.getDescription(context,A122UltimoDadoLidoIgnicao);
               AV16SDTNovaPosicao.gxTpr_Latitude = A123UltimoDadoLidoLatitude;
               AV16SDTNovaPosicao.gxTpr_Longitude = A124UltimoDadoLidoLongitude;
               AV16SDTNovaPosicao.gxTpr_Latlong = StringUtil.StringReplace( StringUtil.Trim( A123UltimoDadoLidoLatitude), ",", ".")+","+StringUtil.StringReplace( StringUtil.Trim( A124UltimoDadoLidoLongitude), ",", ".");
               AV16SDTNovaPosicao.gxTpr_Ultimodadolidoid = A118UltimoDadoLidoId;
               AV16SDTNovaPosicao.gxTpr_Horagps = A120UltimoDadoLidoDataHoraRastreador;
               /* Using cursor P003K3 */
               pr_default.execute(1, new Object[] {A119UltimoDadoLidoDataHoraServidor, A120UltimoDadoLidoDataHoraRastreador, A122UltimoDadoLidoIgnicao, A125UltimoDadoLidoVelocidade, A123UltimoDadoLidoLatitude, A124UltimoDadoLidoLongitude, A121UltimoDadoLidoPlaca, A118UltimoDadoLidoId});
               pr_default.close(1);
               dsDefault.SmartCacheProvider.SetUpdated("UltimoDadoLido");
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            if ( AV19GXLvl11 == 0 )
            {
               /*
                  INSERT RECORD ON TABLE UltimoDadoLido

               */
               A126UltimoDadoLidoIdent = AV14UltimoDadoLidoIdent;
               A119UltimoDadoLidoDataHoraServidor = new SdtUtil(context).timestamptodatetime(NumberUtil.Val( AV12Properties.Get("server.timestamp"), "."));
               A120UltimoDadoLidoDataHoraRastreador = new SdtUtil(context).timestamptodatetime(NumberUtil.Val( StringUtil.Trim( AV12Properties.Get("timestamp")), "."));
               GXt_char1 = A121UltimoDadoLidoPlaca;
               new buscarplacarastreador(context ).execute(  AV14UltimoDadoLidoIdent, out  GXt_char1) ;
               A121UltimoDadoLidoPlaca = GXt_char1;
               if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.Lower( AV12Properties.Get("engine.ignition.status"))), "true") == 0 )
               {
                  A122UltimoDadoLidoIgnicao = 1;
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.Lower( AV12Properties.Get("engine.ignition.status"))), "false") == 0 )
               {
                  A122UltimoDadoLidoIgnicao = 2;
               }
               A125UltimoDadoLidoVelocidade = (short)(NumberUtil.Val( AV12Properties.Get("position.speed"), "."));
               A123UltimoDadoLidoLatitude = StringUtil.Trim( AV12Properties.Get("position.latitude"));
               A124UltimoDadoLidoLongitude = StringUtil.Trim( AV12Properties.Get("position.longitude"));
               AV16SDTNovaPosicao = new SdtSDTNovaPosicao(context);
               AV16SDTNovaPosicao.gxTpr_Placa = StringUtil.Trim( A121UltimoDadoLidoPlaca);
               AV16SDTNovaPosicao.gxTpr_Ignicao = gxdomaindomignicao.getDescription(context,A122UltimoDadoLidoIgnicao);
               AV16SDTNovaPosicao.gxTpr_Latitude = A123UltimoDadoLidoLatitude;
               AV16SDTNovaPosicao.gxTpr_Longitude = A124UltimoDadoLidoLongitude;
               AV16SDTNovaPosicao.gxTpr_Latlong = StringUtil.StringReplace( StringUtil.Trim( A123UltimoDadoLidoLatitude), ",", ".")+","+StringUtil.StringReplace( StringUtil.Trim( A124UltimoDadoLidoLongitude), ",", ".");
               AV16SDTNovaPosicao.gxTpr_Horagps = A120UltimoDadoLidoDataHoraRastreador;
               /* Using cursor P003K4 */
               pr_default.execute(2, new Object[] {A119UltimoDadoLidoDataHoraServidor, A120UltimoDadoLidoDataHoraRastreador, A121UltimoDadoLidoPlaca, A122UltimoDadoLidoIgnicao, A123UltimoDadoLidoLatitude, A124UltimoDadoLidoLongitude, A125UltimoDadoLidoVelocidade, A126UltimoDadoLidoIdent});
               A118UltimoDadoLidoId = P003K4_A118UltimoDadoLidoId[0];
               pr_default.close(2);
               dsDefault.SmartCacheProvider.SetUpdated("UltimoDadoLido");
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
               /* Using cursor P003K6 */
               pr_default.execute(3);
               if ( (pr_default.getStatus(3) != 101) )
               {
                  A40000GXC1 = P003K6_A40000GXC1[0];
                  n40000GXC1 = P003K6_n40000GXC1[0];
               }
               else
               {
                  A40000GXC1 = 0;
                  n40000GXC1 = false;
               }
               pr_default.close(3);
               AV15UltimoDadoLidoId = A40000GXC1;
               AV16SDTNovaPosicao.gxTpr_Ultimodadolidoid = AV15UltimoDadoLidoId;
            }
            context.CommitDataStores("salvarultimodadolido",pr_default);
            new enviarnotificacaowebsocketdistribui(context).executeSubmit(  AV16SDTNovaPosicao) ;
         }
         /* User Code */
          }
         /* User Code */
          catch (Exception e)
         /* User Code */
          {
         /* User Code */
          AV8Exception = e.ToString();
         new GeneXus.Core.genexus.common.SdtLog(context).error(AV8Exception, AV20Pgmname) ;
         /* User Code */
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
         AV12Properties = new GXProperties();
         scmdbuf = "";
         P003K2_A126UltimoDadoLidoIdent = new long[1] ;
         P003K2_A118UltimoDadoLidoId = new int[1] ;
         P003K2_A119UltimoDadoLidoDataHoraServidor = new DateTime[] {DateTime.MinValue} ;
         P003K2_A120UltimoDadoLidoDataHoraRastreador = new DateTime[] {DateTime.MinValue} ;
         P003K2_A122UltimoDadoLidoIgnicao = new short[1] ;
         P003K2_A125UltimoDadoLidoVelocidade = new short[1] ;
         P003K2_A123UltimoDadoLidoLatitude = new string[] {""} ;
         P003K2_A124UltimoDadoLidoLongitude = new string[] {""} ;
         P003K2_A121UltimoDadoLidoPlaca = new string[] {""} ;
         A119UltimoDadoLidoDataHoraServidor = (DateTime)(DateTime.MinValue);
         A120UltimoDadoLidoDataHoraRastreador = (DateTime)(DateTime.MinValue);
         A123UltimoDadoLidoLatitude = "";
         A124UltimoDadoLidoLongitude = "";
         A121UltimoDadoLidoPlaca = "";
         AV16SDTNovaPosicao = new SdtSDTNovaPosicao(context);
         GXt_char1 = "";
         P003K4_A118UltimoDadoLidoId = new int[1] ;
         Gx_emsg = "";
         P003K6_A40000GXC1 = new int[1] ;
         P003K6_n40000GXC1 = new bool[] {false} ;
         AV8Exception = "";
         AV20Pgmname = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.salvarultimodadolido__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.salvarultimodadolido__default(),
            new Object[][] {
                new Object[] {
               P003K2_A126UltimoDadoLidoIdent, P003K2_A118UltimoDadoLidoId, P003K2_A119UltimoDadoLidoDataHoraServidor, P003K2_A120UltimoDadoLidoDataHoraRastreador, P003K2_A122UltimoDadoLidoIgnicao, P003K2_A125UltimoDadoLidoVelocidade, P003K2_A123UltimoDadoLidoLatitude, P003K2_A124UltimoDadoLidoLongitude, P003K2_A121UltimoDadoLidoPlaca
               }
               , new Object[] {
               }
               , new Object[] {
               P003K4_A118UltimoDadoLidoId
               }
               , new Object[] {
               P003K6_A40000GXC1, P003K6_n40000GXC1
               }
            }
         );
         AV20Pgmname = "SalvarUltimoDadoLido";
         /* GeneXus formulas. */
         AV20Pgmname = "SalvarUltimoDadoLido";
         context.Gx_err = 0;
      }

      private short AV19GXLvl11 ;
      private short A122UltimoDadoLidoIgnicao ;
      private short A125UltimoDadoLidoVelocidade ;
      private int A118UltimoDadoLidoId ;
      private int AV15UltimoDadoLidoId ;
      private int GX_INS20 ;
      private int A40000GXC1 ;
      private long AV14UltimoDadoLidoIdent ;
      private long A126UltimoDadoLidoIdent ;
      private string scmdbuf ;
      private string GXt_char1 ;
      private string Gx_emsg ;
      private string AV20Pgmname ;
      private DateTime AV11messagetimestamp ;
      private DateTime A119UltimoDadoLidoDataHoraServidor ;
      private DateTime A120UltimoDadoLidoDataHoraRastreador ;
      private bool n40000GXC1 ;
      private string AV9topic ;
      private string AV10message ;
      private string AV8Exception ;
      private string A123UltimoDadoLidoLatitude ;
      private string A124UltimoDadoLidoLongitude ;
      private string A121UltimoDadoLidoPlaca ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P003K2_A126UltimoDadoLidoIdent ;
      private int[] P003K2_A118UltimoDadoLidoId ;
      private DateTime[] P003K2_A119UltimoDadoLidoDataHoraServidor ;
      private DateTime[] P003K2_A120UltimoDadoLidoDataHoraRastreador ;
      private short[] P003K2_A122UltimoDadoLidoIgnicao ;
      private short[] P003K2_A125UltimoDadoLidoVelocidade ;
      private string[] P003K2_A123UltimoDadoLidoLatitude ;
      private string[] P003K2_A124UltimoDadoLidoLongitude ;
      private string[] P003K2_A121UltimoDadoLidoPlaca ;
      private int[] P003K4_A118UltimoDadoLidoId ;
      private int[] P003K6_A40000GXC1 ;
      private bool[] P003K6_n40000GXC1 ;
      private IDataStoreProvider pr_gam ;
      private GXProperties AV12Properties ;
      private SdtSDTNovaPosicao AV16SDTNovaPosicao ;
   }

   public class salvarultimodadolido__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class salvarultimodadolido__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new UpdateCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP003K2;
        prmP003K2 = new Object[] {
        new Object[] {"@AV14UltimoDadoLidoIdent",SqlDbType.Decimal,16,0}
        };
        Object[] prmP003K3;
        prmP003K3 = new Object[] {
        new Object[] {"@UltimoDadoLidoDataHoraServidor",SqlDbType.DateTime,8,5} ,
        new Object[] {"@UltimoDadoLidoDataHoraRastreador",SqlDbType.DateTime,8,5} ,
        new Object[] {"@UltimoDadoLidoIgnicao",SqlDbType.SmallInt,1,0} ,
        new Object[] {"@UltimoDadoLidoVelocidade",SqlDbType.SmallInt,3,0} ,
        new Object[] {"@UltimoDadoLidoLatitude",SqlDbType.NVarChar,50,0} ,
        new Object[] {"@UltimoDadoLidoLongitude",SqlDbType.NVarChar,50,0} ,
        new Object[] {"@UltimoDadoLidoPlaca",SqlDbType.NVarChar,7,0} ,
        new Object[] {"@UltimoDadoLidoId",SqlDbType.Int,8,0}
        };
        Object[] prmP003K4;
        prmP003K4 = new Object[] {
        new Object[] {"@UltimoDadoLidoDataHoraServidor",SqlDbType.DateTime,8,5} ,
        new Object[] {"@UltimoDadoLidoDataHoraRastreador",SqlDbType.DateTime,8,5} ,
        new Object[] {"@UltimoDadoLidoPlaca",SqlDbType.NVarChar,7,0} ,
        new Object[] {"@UltimoDadoLidoIgnicao",SqlDbType.SmallInt,1,0} ,
        new Object[] {"@UltimoDadoLidoLatitude",SqlDbType.NVarChar,50,0} ,
        new Object[] {"@UltimoDadoLidoLongitude",SqlDbType.NVarChar,50,0} ,
        new Object[] {"@UltimoDadoLidoVelocidade",SqlDbType.SmallInt,3,0} ,
        new Object[] {"@UltimoDadoLidoIdent",SqlDbType.Decimal,16,0}
        };
        Object[] prmP003K6;
        prmP003K6 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("P003K2", "SELECT [UltimoDadoLidoIdent], [UltimoDadoLidoId], [UltimoDadoLidoDataHoraServidor], [UltimoDadoLidoDataHoraRastreador], [UltimoDadoLidoIgnicao], [UltimoDadoLidoVelocidade], [UltimoDadoLidoLatitude], [UltimoDadoLidoLongitude], [UltimoDadoLidoPlaca] FROM [UltimoDadoLido] WITH (UPDLOCK) WHERE [UltimoDadoLidoIdent] = @AV14UltimoDadoLidoIdent ORDER BY [UltimoDadoLidoIdent] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003K2,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P003K3", "UPDATE [UltimoDadoLido] SET [UltimoDadoLidoDataHoraServidor]=@UltimoDadoLidoDataHoraServidor, [UltimoDadoLidoDataHoraRastreador]=@UltimoDadoLidoDataHoraRastreador, [UltimoDadoLidoIgnicao]=@UltimoDadoLidoIgnicao, [UltimoDadoLidoVelocidade]=@UltimoDadoLidoVelocidade, [UltimoDadoLidoLatitude]=@UltimoDadoLidoLatitude, [UltimoDadoLidoLongitude]=@UltimoDadoLidoLongitude, [UltimoDadoLidoPlaca]=@UltimoDadoLidoPlaca  WHERE [UltimoDadoLidoId] = @UltimoDadoLidoId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP003K3)
           ,new CursorDef("P003K4", "INSERT INTO [UltimoDadoLido]([UltimoDadoLidoDataHoraServidor], [UltimoDadoLidoDataHoraRastreador], [UltimoDadoLidoPlaca], [UltimoDadoLidoIgnicao], [UltimoDadoLidoLatitude], [UltimoDadoLidoLongitude], [UltimoDadoLidoVelocidade], [UltimoDadoLidoIdent]) VALUES(@UltimoDadoLidoDataHoraServidor, @UltimoDadoLidoDataHoraRastreador, @UltimoDadoLidoPlaca, @UltimoDadoLidoIgnicao, @UltimoDadoLidoLatitude, @UltimoDadoLidoLongitude, @UltimoDadoLidoVelocidade, @UltimoDadoLidoIdent); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmP003K4)
           ,new CursorDef("P003K6", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT MAX([UltimoDadoLidoId]) AS GXC1 FROM [UltimoDadoLido] ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003K6,1, GxCacheFrequency.OFF ,true,true )
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
              table[2][0] = rslt.getGXDateTime(3);
              table[3][0] = rslt.getGXDateTime(4);
              table[4][0] = rslt.getShort(5);
              table[5][0] = rslt.getShort(6);
              table[6][0] = rslt.getVarchar(7);
              table[7][0] = rslt.getVarchar(8);
              table[8][0] = rslt.getVarchar(9);
              return;
           case 2 :
              table[0][0] = rslt.getInt(1);
              return;
           case 3 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.wasNull(1);
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
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 1 :
              stmt.SetParameterDatetime(1, (DateTime)parms[0]);
              stmt.SetParameterDatetime(2, (DateTime)parms[1]);
              stmt.SetParameter(3, (short)parms[2]);
              stmt.SetParameter(4, (short)parms[3]);
              stmt.SetParameter(5, (string)parms[4]);
              stmt.SetParameter(6, (string)parms[5]);
              stmt.SetParameter(7, (string)parms[6]);
              stmt.SetParameter(8, (int)parms[7]);
              return;
           case 2 :
              stmt.SetParameterDatetime(1, (DateTime)parms[0]);
              stmt.SetParameterDatetime(2, (DateTime)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (short)parms[3]);
              stmt.SetParameter(5, (string)parms[4]);
              stmt.SetParameter(6, (string)parms[5]);
              stmt.SetParameter(7, (short)parms[6]);
              stmt.SetParameter(8, (long)parms[7]);
              return;
     }
  }

}

}
