// Введение в C#. Урок 2. Практическое задание 3.
// Определить, является ли введённое пользователем число чётным.

using System;

namespace exercize_2_3
{
    class Program
    {
        static void Main(string[] args)
        {

            int number;

            Console.WriteLine("Введите чило");

            if (Int32.TryParse(Console.ReadLine(), out number) && number % 2 == 0 )
            {
                Console.WriteLine("Число четное");
            }
            else
            {
                Console.WriteLine("Число не четное");
            }
        }
    }
}
