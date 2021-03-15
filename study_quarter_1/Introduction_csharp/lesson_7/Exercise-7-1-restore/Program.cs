// Decompiled with JetBrains decompiler
// Type: Exercise_7_1.Program
// Assembly: Exercise-7-1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C112FAA2-EEAC-4BBF-B131-1798553B6F00
// Assembly location: Introduction_csharp\lesson_7\Exercise-7-1\bin\Debug\netcoreapp3.1\Exercise-7-1.dll

using System;

namespace Exercise_7_1
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      Console.WriteLine("Введите длинну стороны квадрата:");
      float result;
      while (true)
      {
        if (!float.TryParse(Console.ReadLine(), out result))
          Console.WriteLine("Это не число, попробуйте еще раз");
        else
          break;
      }
      Square square = new Square(result);
      Console.WriteLine(string.Format("Периметр квадрата со стороной {0} равен {1}", (object) result, (object) square.GetPerimeter()));
    }
  }
}
