// Введение в C#. Урок 5. Практическое задание 2.
// Написать программу, которая при старте дописывает текущее время в файл «startup.txt».

using System;
using System.IO;

namespace Exercise_5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @$"C:\temp";

            DirectoryInfo dirInfo = new DirectoryInfo(path);

            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            DateTime now = DateTime.Now;

            using (StreamWriter sw = File.AppendText(@$"{path}\startup.txt"))
            {
                sw.WriteLine(now.ToString("HH:mm:ss"));
            }
        }
    }
}
