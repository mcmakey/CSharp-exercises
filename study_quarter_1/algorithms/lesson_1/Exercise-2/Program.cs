// Алгоритмы. Урок 1. Задание 2
// Вычислите асимптотическую сложность функции из примера ниже.

using System;

namespace Exercise_
{
    class Program
    {
        static void Main(string[] args)
        {

            //
            static int StrangeSum(int[] inputArray)
            {
                int sum = 0;
                for (int i = 0; i < inputArray.Length; i++) // N
                {
                    for (int j = 0; j < inputArray.Length; j++) // N
                    {
                        for (int k = 0; k < inputArray.Length; k++) // N
                        {
                            int y = 0;

                            if (j != 0)
                            {
                                y = k / j;                         
                            }

                            sum += inputArray[i] + i + k + j + y; 
                        }
                    }
                }

                return sum;
            }

            // Решение:
            // по п.4 правил
            // O(N*N*N)
            // O(N^3)

            // Ответ:
            // O(N^3)
        }
    }
}
