// Введение в C#. Урок 5. Практическое задание 3.
// Ввести с клавиатуры произвольный набор чисел (0...255) и записать их в бинарный файл.

using System;
using System.IO;
using System.Text.RegularExpressions;

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


            byte[] numbers = GetNumbers();

            using (BinaryWriter writer = new BinaryWriter(File.Open(@$"{path}\test.bin", FileMode.OpenOrCreate)))
            {
                writer.Write(numbers);
            }

            Console.WriteLine(@"Результаты записаны в файл C:\temp\test.bin");
        }

        static byte[] GetNumbers()
        {
            string delimiter = "[,]+";
            Regex template = new Regex(@"^[0-9,]+$");
            Console.WriteLine("Введите произвольный набор чисел от 0 до 255, разделенные запятой");

            while (true)
            {
                string entered = Console.ReadLine();
                if (template.IsMatch(entered))
                {
                    string[] numbers = Regex.Split(entered, delimiter);

                    if (Array.TrueForAll(numbers, CheckToByte))
                    {
                        return Array.ConvertAll(numbers, byte.Parse);
                    }
                    else
                    {
                        Console.WriteLine("Есть числа не входящие в диапазон 0-255");
                    };
                }
                else
                {
                    Console.WriteLine("Введенная строка содержит символы отличающиеся от цифр и запятых");
                }
                Console.WriteLine("Попробуйте еще раз");
            }
        }

        static bool CheckToByte(string value)
        {
            return byte.TryParse(value, out byte result);
        }
    }
}
