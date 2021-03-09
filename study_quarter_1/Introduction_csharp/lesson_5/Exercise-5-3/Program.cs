// Введение в C#. Урок 5. Практическое задание 3.
// Ввести с клавиатуры произвольный набор чисел (0...255) и записать их в бинарный файл.

using System;
using System.IO;

namespace Exercise_5_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\temp";

            DirectoryInfo dirInfo = new DirectoryInfo(path);

            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }


            byte[] numbers = new byte[] { 0, 10, 30, 60, 100, 200, 255, 120, 35, 10, 56, 244 };

            using (BinaryWriter writer = new BinaryWriter(File.Open(@$"{path}\test.bin", FileMode.OpenOrCreate)))
            {
                writer.Write(numbers);
            }

        }
    }
}
