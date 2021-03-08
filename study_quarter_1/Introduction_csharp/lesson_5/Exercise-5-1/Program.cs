// Введение в C#. Урок 5. Практическое задание 1.
// Ввести с клавиатуры произвольный набор данных и сохранить его в текстовый файл.

using System;
using System.IO;

namespace Exercise_5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя файла");
            string fileName = Console.ReadLine();
            Console.WriteLine("Укажите дирреторию (путь)");
            string dir = Console.ReadLine();
            string path = $"{dir}/{fileName}";
            Console.WriteLine("Введите текст");
            string text = Console.ReadLine();

            File.WriteAllText(path, text);
        }
    }
}
