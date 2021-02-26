// Введение в C#. Урок 3. Практическое задание 1.
// Написать программу, выводящую элементы двухмерного массива по диагонали.

using System;

namespace Exercise_3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixRows = GetParamMatrix("Введите количество строк матрицы");
            int matrixColumns = GetParamMatrix("Введите количество столбцов матрицы");
            var myMatrix = CreateMatrix(matrixRows, matrixColumns);
           
            ShowMatrix(myMatrix);
            ShowMembersMainDiagonal(GetMembersMainDiagonal(myMatrix));
        }

        static int GetParamMatrix(string message)
        {
            Console.WriteLine(message);
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод, попробйте еще раз");
                }
            }
        }
 
        static string[,] CreateMatrix(int rows, int columns)
        {
            string[,] matrix = new string[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = $"{i}{j}";
                }
            }

            return matrix;
        }

        static void ShowMatrix(string[,] matrix)
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

        static void ShowMembersMainDiagonal(string[] array)
        {
            Console.WriteLine($"Элементы данного двумерного массива по главной диагонали: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}\t");
            }
        }

        static string[] GetMembersMainDiagonal(string [,] matrix)
        {
            int rows = matrix.GetUpperBound(0) + 1;
            int columns = matrix.Length / rows;

            int numberMembers = rows > columns ? columns : rows;

            string[] membersMainDiagonal = new string[numberMembers];

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
