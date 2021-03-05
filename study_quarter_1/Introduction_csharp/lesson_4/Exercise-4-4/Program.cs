// Введение в C#. Урок 4. Практическое задание 4.
// Написать программу, вычисляющую число Фибоначчи для заданного значения рекурсивным способом.

using System;

namespace Exercise_4_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое число n для вычисления n-ого числа Фибоначи");
            int n = EnterdNumber();
            Console.WriteLine($"{n}-ое число Фибоначи это {GetFibonaci(n)}");
        }

        static int EnterdNumber()
        {
            while(true)
            {
                if(Int32.TryParse(Console.ReadLine(), out int n))
                {
                    return n;
                }
                else
                {
                    Console.WriteLine("Неверный ввод, попробуйте еще");
                }
            }
        }

        static int GetFibonaci(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }

            return GetFibonaci(n - 2) + GetFibonaci(n - 1);
        }
    }
}
