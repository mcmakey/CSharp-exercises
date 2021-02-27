// Введение в C#. Урок 3. Практическое задание 4.
// «Морской бой» — вывести на экран массив 10х10, состоящий из символов X и O,
// где Х — элементы кораблей, а О — свободные клетки

using System;

namespace Exercise_3_4
{
    class Program
    {
        static void Main(string[] args)
        {

            // Инициализация игрового поля
            string[,] battleField = InitBattleField();

            // Показать пустое игровое поле
            ShowBattleField(battleField);
        }

        static string[,] InitBattleField()
        {
            string[,] matrix = new string[10, 10];
            int rows = matrix.GetUpperBound(0) + 1;
            int columns = matrix.Length / rows;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = "O";
                }
            }

            return matrix;
        }

        static void ShowBattleField(string[,] matrix)
        {
            string[] xСoordinateNames = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };

            int rows = matrix.GetUpperBound(0) + 1;
            int columns = matrix.Length / rows;

            for (int i = 0; i < xСoordinateNames.Length; i++)
            {
                Console.Write(xСoordinateNames[i].PadLeft(i == 0 ? 4 : 2));
            }

            Console.WriteLine();

            for (int i = 0; i < rows; i++)
            {
                Console.Write($"{i + 1}".PadLeft(2));
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(matrix[i, j].PadLeft(2));
                }
                Console.WriteLine();
            }
        }

    }
}
