// Алгоритмы. Урок 1. Задание 2
// Реализуйте функцию вычисления числа Фибоначчи
// Требуется реализовать рекурсивную версию и версию без рекурсии (через цикл).


using System;

namespace Exercise_3
{
    class Program
    {
        static void Main(string[] args)
        {
            TestCase testCase1 = new TestCase()
            {
                Number = 1,
                Expected = 1
            };

            TestCase testCase2 = new TestCase()
            {
                Number = 6,
                Expected = 8
            };

            TestCase testCase3 = new TestCase()
            {
                Number = 13,
                Expected = 233
            };

            Console.WriteLine("Тест рекурсивного метода:");
            TestGetFibonaci(GetFibonaciRecursive, testCase1);
            TestGetFibonaci(GetFibonaciRecursive, testCase2);
            TestGetFibonaci(GetFibonaciRecursive, testCase3);

            Console.WriteLine("Тест нерекурсивного метода:");
            TestGetFibonaci(GetFibonaci, testCase1);
            TestGetFibonaci(GetFibonaci, testCase2);
            TestGetFibonaci(GetFibonaci, testCase3);
        }

        // Класс для тестирования
        public class TestCase
        {
            public int Number { get; set; }
            public int Expected { get; set; }
        }

        // Метод для тестирование
        static void TestGetFibonaci(Func<int, int> getFi, TestCase testCase)
        {
            var actual = getFi(testCase.Number);
            if (actual == testCase.Expected)
            {
                Console.WriteLine("VALID TEST");
            }
            else
            {
                Console.WriteLine("INVALID TEST");
            }
        }

        // Метод получения числа фибоначчи рекурсивным способом
        static int GetFibonaciRecursive(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }

            return GetFibonaciRecursive(n - 2) + GetFibonaciRecursive(n - 1);
        }

        // Метод получения числа фибоначчи без рекурсии
        static int GetFibonaci(int n)
        {
            int fi = 0;
            int value0 = 0;
            int value1 = 1;

            var previousNumber1 = value0;
            var previousNumber2 = value1;

            if (n == 0)
            {
                fi = value0;
            } 
            else if (n == 1)
            {
                fi = value1;
            }
            else
            {
                for (int i = 2; i <= n; i++)
                {
                    fi = previousNumber1 + previousNumber2; // Вычисление n-го числа фибоначии

                    // Определение 2 предыдущих чисел фибоначи, для вычисления очередного числа фибоначи в следуюущей итерации цикла
                    previousNumber1 = previousNumber2;
                    previousNumber2 = fi;
                }
            }

            return fi;
        }
    }
}
