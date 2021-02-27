// Введение в C#. Урок 3. Практическое задание 4.
// «Морской бой» — вывести на экран массив 10х10, состоящий из символов X и O,
// где Х — элементы кораблей, а О — свободные клетки

using System;

namespace Exercise_3_4
{
    class Program
    {
        enum Ships
        {
            OneDeck = 1,
            TwoDeck,
            ThreeDeck,
            FourDeck,
        }

        enum Direction
        {
            T, // top
            R, // right
            B, // bottom
            L  // left
        }

        const string EMPTY_CELL = "O";
        const string FILLED_CELL = "X";

        static void Main(string[] args)
        {

            // Инициализация игрового поля
            string[,] battleField = InitBattleField();

            // Показать пустое игровое поле
            ShowBattleField(battleField);

            // Позиционирование корабля
            Console.WriteLine("Позиционирование четырехпалубного корабля:");
            PositioningShip(battleField, Ships.FourDeck);

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

        static void PositioningShip(string[,] matrix, Ships ship)
        {
            int xStartingPoint = new int();
            int yStartingPoint = new int();
            int shipLength = (int)ship;
            Direction direction;
           
            // Выбрать начальную точку
            Console.WriteLine("Введите координаты начальной точки");
            Console.WriteLine("X:");
            xStartingPoint = GetCoordinate();
            Console.WriteLine("Y:");
            yStartingPoint = GetCoordinate();
            // Проверка на то что хоябы одно направление возможно
            // Выбрать направление
            Console.WriteLine("Введите направление (T,R,B,L)");
            direction = GetDirection();
            // Проверить подходит ли данное направление
            // Заполнить соответстующие ячейки "X"
            Console.Write($"x={xStartingPoint}, y={yStartingPoint}, direction={direction} \n");
            if (direction == Direction.T)
            {
                for (int i = 0; i < shipLength; i++)
                {
                    matrix[(xStartingPoint - 1) - i, (yStartingPoint - 1)] = FILLED_CELL;
                }
            } else if (direction == Direction.R)
            {
                for (int i = 0; i < shipLength; i++)
                {
                    matrix[xStartingPoint - 1, (yStartingPoint - 1) + i] = FILLED_CELL;
                }
            } else if (direction == Direction.B)
            {
                for (int i = 0; i < shipLength; i++)
                {
                    matrix[(xStartingPoint - 1) + i, yStartingPoint - 1] = FILLED_CELL;
                }
            } else if (direction == Direction.L)
            {
                for (int i = 0; i < shipLength; i++)
                {
                    matrix[xStartingPoint - 1, (yStartingPoint - 1) - i] = FILLED_CELL;
                }
            }
        }

        static int GetCoordinate()
        {
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

        static Direction GetDirection()
        {
            while (true)
            {
                if (Direction.TryParse(Console.ReadLine(), out Direction value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод, попробйте еще раз");
                }
            }
        }

    }
}
