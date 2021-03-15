// Decompiled with JetBrains decompiler
// Type: Exercise_7_1.Square
// Assembly: Exercise-7-1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C112FAA2-EEAC-4BBF-B131-1798553B6F00
// Assembly location: Introduction_csharp\lesson_7\Exercise-7-1\bin\Debug\netcoreapp3.1\Exercise-7-1.dll

using System;

namespace Exercise_7_1
{
  internal class Square
  {
    public float side { get; set; }

    public Square(float side) => this.side = side;

    public float GetPerimeter() => this.side * 4f;

    public double GetArea() => Math.Pow(this.side, 2);

  }
}
