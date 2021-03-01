// Введение в C#. Урок 3. Практическое задание 4.
// «Морской бой» — вывести на экран массив 10х10, состоящий из символов X и O,
// где Х — элементы кораблей, а О — свободные клетки

using System;

namespace Exercise_3_4
{
    class Program
    {

        enum XCoordinates { A = 1, B, C, D, E, F, G, H, I, J}

        const string EMPTY_CELL = "O";
        const string FILLED_CELL = "X";

        static void Main(string[] args)
        {
            // Четырехпалубный корабль
            string[][] fourDeck_1 = new string[4][];
            fourDeck_1[0] = new string[2] { "D", "4"};
            fourDeck_1[1] = new string[2] { "E", "4"};
            fourDeck_1[2] = new string[2] { "F", "4"};
            fourDeck_1[3] = new string[2] { "G", "4"};

            // Группа четырехпалубных кораблей (1)
            string[][][] fourDeckCollection = new string[1][][];
            fourDeckCollection[0] = fourDeck_1;

            // Инициализация игрового поля
            string[,] battleField = InitBattleField();

            // Показать пустое игровое поле
            ShowBattleField(battleField);

            // Позиционирование корабля
            Console.WriteLine("Позиционирование четырехпалубного корабля:");
            PositioningShip(battleField, fourDeckCollection);

            // Показать игровое поле
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
                    matrix[i, j] = EMPTY_CELL;
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

        static void PositioningShip(string[,] matrix, string[][][] shipCollections)
        {
            int shipNumber = shipCollections.Length;
            int deckNumber = shipCollections[0].Length;

            for (int i = 0; i < shipNumber; i++)
            {
                for (int j = 0; j < deckNumber; j++)
                {
                    var xCoord = shipCollections[i][j][0];
                    var yCoord = shipCollections[i][j][1];

                    int xCoordMatrix = new int();
                    int yCoordMatrix = new int();

                    if (Enum.TryParse(xCoord, out XCoordinates xValue)) {
                        xCoordMatrix = (int)xValue - 1;
                    } else
                    {
                        Console.WriteLine($"Задан неверный формат координат для {deckNumber}-х палубных кораблей (корабль {i}, координата {j})");
                    };

                    if (Int32.TryParse(yCoord, out int yValue))
                    {
                        yCoordMatrix = yValue - 1;
                    }
                    else
                    {
                        Console.WriteLine($"Задан неверный формат координат для {deckNumber}-х палубных кораблей (корабль {i}, координата {j})");
                    };

                    matrix[xCoordMatrix, yCoordMatrix] = FILLED_CELL;
                }
            }

        }
    }
}
