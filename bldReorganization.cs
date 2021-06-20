using System;
using GeneXus.Builder;
using System.IO;
public class bldReorganization : GxBaseBuilder
{
   string cs_path = "." ;
   public bldReorganization( ) : base()
   {
   }

   public override int BeforeCompile( )
   {
      return 0 ;
   }

   public override int AfterCompile( )
   {
      int ErrCode;
      ErrCode = 0;
      if ( ! File.Exists(@"bin\client.exe.config") || checkTime(@"bin\client.exe.config",cs_path + @"\client.exe.config") )
      {
         File.Copy( cs_path + @"\client.exe.config", @"bin\client.exe.config", true);
      }
      this.CreateExeConfig( @"bin\reor.exe.config");
      this.CreateExeConfig( @"bin\Runx86.exe.config");
      return ErrCode ;
   }

   static public int Main( string[] args )
   {
      bldReorganization x = new bldReorganization() ;
      x.SetMainSourceFile( "");
      x.LoadVariables( args);
      return x.CompileAll( );
   }

   public override ItemCollection GetSortedBuildList( )
   {
      ItemCollection sc = new ItemCollection() ;
      sc.Add( @"bin\Reorganization.dll", cs_path + @"\reorganization.rsp");
      return sc ;
   }

   public override TargetCollection GetRuntimeBuildList( )
   {
      TargetCollection sc = new TargetCollection() ;
      return sc ;
   }

   public override ItemCollection GetResBuildList( )
   {
      ItemCollection sc = new ItemCollection() ;
      sc.Add( @"bin\messages.por.dll", cs_path + @"\messages.por.txt");
      return sc ;
   }

   public override bool ToBuild( string obj )
   {
      if (checkTime(obj, cs_path + @"\bin\GxClasses.dll" ))
         return true;
      if ( obj == @"bin\Reorganization.dll" )
      {
         if (checkTime(obj, cs_path + @"\Reorganization.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\reorg.cs" ))
            return true;
      }
      if ( obj == @"bin\messages.por.dll" )
      {
         if (checkTime(obj, cs_path + @"\messages.por.txt" ))
            return true;
      }
      return false ;
   }

}

