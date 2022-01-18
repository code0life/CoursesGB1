
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.6.1055.0




// Metadata version: v4.0.30319
.assembly extern System.Runtime
{
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )                         // .?_....:
  .ver 4:2:2:0
}
.assembly extern System.Console
{
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )                         // .?_....:
  .ver 4:1:2:0
}
.assembly TestProgramm
{
  .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [System.Runtime]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                                   63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- Следующий настраиваемый атрибут добавлен автоматически, не следует отменять преобразование в комментарий -------
  //  .custom instance void [System.Runtime]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [System.Runtime]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 02 00 00 00 00 00 ) 

  .custom instance void [System.Runtime]System.Runtime.Versioning.TargetFrameworkAttribute::.ctor(string) = ( 01 00 18 2E 4E 45 54 43 6F 72 65 41 70 70 2C 56   // ....NETCoreApp,V
                                                                                                              65 72 73 69 6F 6E 3D 76 33 2E 31 01 00 54 0E 14   // ersion=v3.1..T..
                                                                                                              46 72 61 6D 65 77 6F 72 6B 44 69 73 70 6C 61 79   // FrameworkDisplay
                                                                                                              4E 61 6D 65 00 )                                  // Name.
  .custom instance void [System.Runtime]System.Reflection.AssemblyCompanyAttribute::.ctor(string) = ( 01 00 0C 54 65 73 74 50 72 6F 67 72 61 6D 6D 00   // ...TestProgramm.
                                                                                                      00 ) 
  .custom instance void [System.Runtime]System.Reflection.AssemblyConfigurationAttribute::.ctor(string) = ( 01 00 07 52 65 6C 65 61 73 65 00 00 )             // ...Release..
  .custom instance void [System.Runtime]System.Reflection.AssemblyFileVersionAttribute::.ctor(string) = ( 01 00 07 31 2E 30 2E 30 2E 30 00 00 )             // ...1.0.0.0..
  .custom instance void [System.Runtime]System.Reflection.AssemblyInformationalVersionAttribute::.ctor(string) = ( 01 00 05 31 2E 30 2E 30 00 00 )                   // ...1.0.0..
  .custom instance void [System.Runtime]System.Reflection.AssemblyProductAttribute::.ctor(string) = ( 01 00 0C 54 65 73 74 50 72 6F 67 72 61 6D 6D 00   // ...TestProgramm.
                                                                                                      00 ) 
  .custom instance void [System.Runtime]System.Reflection.AssemblyTitleAttribute::.ctor(string) = ( 01 00 0C 54 65 73 74 50 72 6F 67 72 61 6D 6D 00   // ...TestProgramm.
                                                                                                    00 ) 
  .hash algorithm 0x00008004
  .ver 1:0:0:0
}
.module TestProgramm.dll
// MVID: {A0C1C94C-8331-4038-914E-FEE6CDD2AD84}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x057A0000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi beforefieldinit TestProgramm.Program
       extends [System.Runtime]System.Object
{
  .method private hidebysig static void  Main(string[] args) cil managed
  {
    .entrypoint
    // Размер кода:       85 (0x55)
    .maxstack  3
    .locals init (string V_0)
    IL_0000:  ldstr      "hacker"
    IL_0005:  stloc.0
    IL_0006:  ldstr      "Enter login:"
    IL_000b:  call       void [System.Console]System.Console::WriteLine(string)
    IL_0010:  call       string [System.Console]System.Console::ReadLine()
    IL_0015:  ldloc.0
    IL_0016:  call       bool [System.Runtime]System.String::op_Equality(string,
                                                                         string)
    IL_001b:  brfalse.s  IL_0039

    IL_001d:  ldstr      "\nWELCOME TO HELL, "
    IL_0022:  ldloc.0
    IL_0023:  ldstr      "!"
    IL_0028:  call       string [System.Runtime]System.String::Concat(string,
                                                                      string,
                                                                      string)
    IL_002d:  call       void [System.Console]System.Console::WriteLine(string)
    IL_0032:  call       string [System.Console]System.Console::ReadLine()
    IL_0037:  pop
    IL_0038:  ret

    IL_0039:  ldstr      "\nERROR! login "
    IL_003e:  ldloc.0
    IL_003f:  ldstr      " not found!"
    IL_0044:  call       string [System.Runtime]System.String::Concat(string,
                                                                      string,
                                                                      string)
    IL_0049:  call       void [System.Console]System.Console::WriteLine(string)
    IL_004e:  call       string [System.Console]System.Console::ReadLine()
    IL_0053:  pop
    IL_0054:  ret
  } // end of method Program::Main

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Размер кода:       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [System.Runtime]System.Object::.ctor()
    IL_0006:  ret
  } // end of method Program::.ctor

} // end of class TestProgramm.Program


// =============================================================

// *********** ДИЗАССЕМБЛИРОВАНИЕ ЗАВЕРШЕНО ***********************
// ВНИМАНИЕ: создан файл ресурсов Win32 D:\GB\CoursesGB1\SeventhLession\TestProgramm\bin\Release\netcoreapp3.1\Dump.res
