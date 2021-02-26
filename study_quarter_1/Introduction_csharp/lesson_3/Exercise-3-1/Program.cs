// Введение в C#. Урок 3. Практическое задание 1.
// Написать программу, выводящую элементы двухмерного массива по диагонали.

using System;

namespace Exercise_3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] myMatrix = new int[4, 5] { 
                { 1, 2, 3, 4, 5 },
                { 6, 7, 8, 9, 10 },
                { 11, 12, 13, 14, 15 },
                { 16, 17, 18, 19, 20}
            };
           
            ShowMatrix(myMatrix);
            ShowMembersMainDiagonal(GetMembersMainDiagonal(myMatrix));
        }

        static void ShowMatrix(int[,] matrix)
        {
            int rows = matrix.GetUpperBound(0) + 1;
            int columns = matrix.Length / rows;

            Console.WriteLine("Дан двумерный массив: ");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{matrix[i, j]}\t");
                }
                Console.WriteLine();
            }
        }

        static void ShowMembersMainDiagonal(int[] array)
        {
            Console.WriteLine($"Элементы данного двумерного массива по главной диагонали: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}\t");
            }
        }

        static int[] GetMembersMainDiagonal(int [,] matrix)
        {
            int rows = matrix.GetUpperBound(0) + 1;
            int columns = matrix.Length / rows;

            int numberMembers = rows > columns ? columns : rows;

            int[] membersMainDiagonal = new int[numberMembers];

            for (int i = 0; i < membersMainDiagonal.Length; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if ( i == j)
                    {
                        membersMainDiagonal[i] = matrix[i, j];
                    }
                }
            }

            return membersMainDiagonal;
        }
    }
}
