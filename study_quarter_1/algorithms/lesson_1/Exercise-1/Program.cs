// Напишите на C# функцию согласно блок-схеме
// Требуется реализовать на C# функцию согласно блок-схеме. Блок-схема описывает алгоритм проверки,
// простое число или нет.


using System;

namespace Exercise_1
{
    class Program
    {
        // Класс для тестирования
        public class TestCase
        {
            public int Number { get; set; }
            public bool Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }

        // Метод для тестирование
        static void TestCheckingPrimeNumber(TestCase testCase)
        {
            try
            {
                var actual = CheckingPrimeNumber(testCase.Number);
                if (actual == testCase.Expected)
                {
                    Console.WriteLine($"{testCase.Number} VALID TEST");
                }
                else
                {
                    Console.WriteLine($"{testCase.Number} INVALID TEST");
                }
            }
            catch (Exception ex)
            {
                if (testCase.ExpectedException != null)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
        }

        // Метод для проверки числа на простоту (задание)
        static bool CheckingPrimeNumber(int number)
        {

            if (number < 2)
            {
                // Без данного исключения алгоритм считает числа меньше 2 простыми, что не верно
                throw new ArgumentException("Число должно быть больше 1");
            }

            var d = 0;
            var i = 2;

            while (i < number)
            {
                if (number % i == 0)
                {
                    d++;
                }

                i++;
            }

            if (d == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            // positive
            TestCase testCase1 = new TestCase()
            {
                Number = 2, // простое число
                Expected = true,  // ожидаем true
                ExpectedException = null
            };

            TestCase testCase2 = new TestCase()
            {
                Number = 19, // простое число
                Expected = true, // ожидаем true
                ExpectedException = null
            };

            TestCase testCase3 = new TestCase()
            {
                Number = 4, // не простое число
                Expected = false, // ожидаем false
                ExpectedException = null
            };

            // negative
            TestCase testCase4 = new TestCase()
            {
                Number = 10, // не простое число
                Expected = true, //ожидаем true, хотя должно быть false
                ExpectedException = null
            };

            TestCase testCase5 = new TestCase()
            {
                Number = 5, // простое число
                Expected = false, // // ожидаем false, хотя должно быть true
                ExpectedException = null
            };

            // positive and exeption

            TestCase testCase6 = new TestCase()
            {
                Number = 0, // Число попадающее под исключение
                Expected = false, // Ожидаем false
                ExpectedException = new ArgumentException() // ожидаем что будет исключение ArgumentException
            };

            TestCheckingPrimeNumber(testCase1);  // Ожидается valid
            TestCheckingPrimeNumber(testCase2);  // Ожидается valid
            TestCheckingPrimeNumber(testCase3);  // Ожидается valid
            Console.WriteLine();

            TestCheckingPrimeNumber(testCase4);  // Ожидается invalid
            TestCheckingPrimeNumber(testCase5);  // Ожидается invalid
            Console.WriteLine();

            TestCheckingPrimeNumber(testCase6);  // Ожидается valid и исключение
        }
    }
}
