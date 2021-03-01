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

            // Трехпалубные корабли
            // Первый трехпалубный корабль
            string[][] threeDeck_1 = new string[3][];
            threeDeck_1[0] = new string[2] { "B", "6" };
            threeDeck_1[1] = new string[2] { "B", "7" };
            threeDeck_1[2] = new string[2] { "B", "8" };
            // Второй трехпалубный корабль
            string[][] threeDeck_2 = new string[3][];
            threeDeck_2[0] = new string[2] { "G", "2" };
            threeDeck_2[1] = new string[2] { "H", "2" };
            threeDeck_2[2] = new string[2] { "I", "2" };
            // Группа трехпалубных кораблей (2)
            string[][][] threeDeckCollection = new string[2][][];
            threeDeckCollection[0] = threeDeck_1;
            threeDeckCollection[1] = threeDeck_2;

            // Двухпалубные корабли
            // Первый Двухпалубный корабль
            string[][] twoDeck_1 = new string[2][];
            twoDeck_1[0] = new string[2] { "B", "2" };
            twoDeck_1[1] = new string[2] { "C", "2" };
            // Второй Двухпалубный корабль
            string[][] twoDeck_2 = new string[2][];
            twoDeck_2[0] = new string[2] { "G", "6" };
            twoDeck_2[1] = new string[2] { "G", "7" };
            // Третий Двухпалубный корабль
            string[][] twoDeck_3 = new string[2][];
            twoDeck_3[0] = new string[2] { "I", "10" };
            twoDeck_3[1] = new string[2] { "J", "10" };
            // Группа двухпалубных кораблей (3)
            string[][][] twoDeckCollection = new string[3][][];
            twoDeckCollection[0] = twoDeck_1;
            twoDeckCollection[1] = twoDeck_2;
            twoDeckCollection[2] = twoDeck_3;

            // Однопалубные корабли
            // Первый однопалубный корабль
            //string[][] oneDeck_1 = new string[2][];
            //oneDeck_1[0] = new string[2] { "A", "4" };
            // Второй однопалубный корабль
            //string[][] oneDeck_2 = new string[2][];
            //oneDeck_2[0] = new string[2] { "D", "7" };
            // Третий однопалубный корабль
            //string[][] oneDeck_3 = new string[2][];
            //oneDeck_3[0] = new string[2] { "E", "10" };
            // Четвертый однопалубный корабль
            //string[][] oneDeck_4 = new string[2][];
            //oneDeck_4[0] = new string[2] { "J", "4" };
            // Группа однопалубных кораблей (3)
            //string[][][] oneDeckCollection = new string[4][][];
            //oneDeckCollection[0] = oneDeck_1;
            //oneDeckCollection[1] = oneDeck_2;
            //oneDeckCollection[2] = oneDeck_3;
            //oneDeckCollection[2] = oneDeck_4;

            // Инициализация игрового поля
            string[,] battleField = InitBattleField();

            // Показать пустое игровое поле
            ShowBattleField(battleField);

            // Позиционирование 4-х палубного корабля (1)
            Console.WriteLine("Позиционирование четырехпалубного корабля:");
            PositioningShip(battleField, fourDeckCollection);
            ShowBattleField(battleField);

            // Позиционирование 3-х палубных кораблей 
            Console.WriteLine("Позиционирование 3-х палубных кораблей:");
            PositioningShip(battleField, threeDeckCollection);
            ShowBattleField(battleField);

            // Позиционирование 2-х палубных кораблей 
            Console.WriteLine("Позиционирование 2-х палубных кораблей:");
            PositioningShip(battleField, twoDeckCollection);
            ShowBattleField(battleField);

            // Позиционирование 1-х палубных кораблей 
            //Console.WriteLine("Позиционирование 1-х палубных кораблей:");
            //PositioningShip(battleField, oneDeckCollection);
            //ShowBattleField(battleField);

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

                    int column = new int();
                    int row = new int();

                    if (Enum.TryParse(xCoord, out XCoordinates xValue)) {
                        column = (int)xValue - 1;
                    } else
                    {
                        Console.WriteLine($"Задан неверный формат координат для {deckNumber}-х палубных кораблей (корабль {i}, координата {j})");
                    };

                    if (Int32.TryParse(yCoord, out int yValue))
                    {
                        row = yValue - 1;
                    }
                    else
                    {
                        Console.WriteLine($"Задан неверный формат координат для {deckNumber}-х палубных кораблей (корабль {i}, координата {j})");
                    };

                    matrix[row, column] = FILLED_CELL;
                }
            }

        }
    }
}
