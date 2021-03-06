// Введение в C#. Урок 4. Практическое задание 2.
// Написать программу, принимающую на вход строку — набор чисел, разделенных пробелом,
// и возвращающую число — сумму всех чисел в строке. Ввести данные с клавиатуры и вывести результат на экран.

using System;
using System.Text.RegularExpressions;

namespace Exercise_4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringData = GetData();
            Console.WriteLine($"Сумма чисел в строке {stringData}");
            Console.WriteLine($"равна: {GetSumm(stringData)}");
        }

        static string GetData()
        {
            Regex template = new Regex(@"^[0-9 ]+$");
            Console.WriteLine("Введите числа, разделенные пробелом");
            
            while (true)
            {
                string text = Console.ReadLine();
                if (template.IsMatch(text))
                {
                    return text;
                }
                else
                {
                    Console.WriteLine("Введенная строка содержит символы отличающиеся от цифр и пробелов");
                    Console.WriteLine("Попробуйте еще раз");
                }
            }
        }

        static int GetSumm(string data)
        {
            string pattern = "[ ]+";
            string[] numbers = Regex.Split(data, pattern);
            int summ = new int();

            for (int i = 0; i < numbers.Length; i++)
            {
                summ += Convert.ToInt32(numbers[i]);
            }

            return summ;
        }
    }
}
