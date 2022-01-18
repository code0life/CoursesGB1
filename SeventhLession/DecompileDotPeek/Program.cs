// Decompiled with JetBrains decompiler
// Type: TestProgramm.Program
// Assembly: TestProgramm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EB16F3B0-E068-47A5-B337-28B7D9E53A79
// Assembly location: D:\GB\CoursesGB1\SeventhLession\TestProgramm\bin\Release\netcoreapp3.1\TestProgramm.dll

using System;

namespace TestProgramm
{
  //Декоипиленное приложение из файла exe и в последствии измененное
  internal class Program
  {
    private static void Main(string[] args)
    {
      string str = "hacker";
      Console.WriteLine("Enter login:");
      string answer = Console.ReadLine();

      if (answer == str)
      {
        Console.WriteLine("\nWELCOME TO HELL, " + answer + "!");
        Console.ReadLine();
      }

      else
      {
        Console.WriteLine("\nERROR! login " + answer + " not found! You are hacked DotPeek!");
        Console.ReadLine();
      }

    }
  }
}
