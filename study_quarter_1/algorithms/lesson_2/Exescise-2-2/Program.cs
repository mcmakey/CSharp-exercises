// Алгоритмы. Урок 2. Задание 2
// Требуется написать функцию бинарного поиска, посчитать его асимптотическую сложность
// и проверить работоспособность функции

using System;

namespace Exescise_2_2
{
    

    class Program
    {
        static void Main(string[] args)
        {
            // positive
            TestCase testCase1 = new TestCase()
            {
                Array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                Value = 4,
                Expected = 3
            };

            TestCase testCase2 = new TestCase()
            {
                Array = new int[] { 4, 7, 10, 18, 19, 35, 90, 123, 456, 10000 },
                Value = 123,
                Expected = 7
            };

            TestCase testCase3 = new TestCase()
            {
                Array = new int[] { 4, 7, 10, 18, 19, 35, 90, 123, 456, 10000 },
                Value = 33,
                Expected = -1
            };

            // negative
            TestCase testCase4 = new TestCase()
            {
                Array = new int[] { 4, 7, 10, 18, 19, 35, 90, 123, 456, 10000 },
                Value = 18,
                Expected = 4
            };

            TestBynarySearch(testCase1);
            TestBynarySearch(testCase2);
            TestBynarySearch(testCase3);
            TestBynarySearch(testCase4);
        }

        public class TestCase
        {
            public int[] Array { get; set; }
            public int Value { get; set; }
            public int Expected { get; set; }
        }

        public static void TestBynarySearch(TestCase testCase)
        {
            var actual = BynarySearch(testCase.Array, testCase.Value);
            
            if (actual == testCase.Expected)
            {
                Console.WriteLine("VALID TEST");
            } 
            else
            {
                Console.WriteLine("INVALID TEST");
            }
        }

        static int BynarySearch(int[] array, int value)
        {
            var minIndex = 0;
            var maxIndex = array.Length - 1;

            while (minIndex <= maxIndex) // N/2
            {
                int midIndex = (minIndex + maxIndex) / 2;
                if (value == array[midIndex])
                {
                    return midIndex;
                }
                else if (value < array[midIndex])
                {
                    maxIndex = midIndex - 1;
                }
                else
                {
                    minIndex = midIndex + 1;
                }
            }

            // Целевого элемента в массиве нет
            return -1;
        }
    }
}

// Вычисление асимптотической сложности:
// [N]/2 + [(N/2)]/2 + [((N/2)/2)]/2...
// или
// N/2^1 + N/2^2 + N/2^3 +..... + N/2^x
// Худший случай - N/2:x , где x таково, что 2^x = N
// Тогда 
// 2 x = N
//=> log2(2^x) = log2(N)
//=> x*log2(2) = log2(N)
//=> x * 1 = log2(N) 

// T.e асимптотическая сложность -  O(logN)