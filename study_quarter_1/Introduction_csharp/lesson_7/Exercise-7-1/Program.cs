// Введение в C#. Урок 7. Практическое задание 1.

// Написать любое приложение, произвести его сборку с помощью MSBuild,
// осуществить декомпиляцию с помощью dotPeek, внести правки
// в программный код и пересобрать приложение.

// Пользователь вводит сторону квадрата. Найдите периметр и площадь квадрата.

using System;

namespace Exercise_7_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длинну стороны квадрата:");
            while (true)
            {
                if (float.TryParse(Console.ReadLine(), out float side))
                {
                    Square square = new Square(side);
                    Console.WriteLine($"Периметр квадрата со стороной {side} равен {square.GetPerimeter()}");
                    return;
                }
                else
                {
                    Console.WriteLine("Это не число, попробуйте еще раз");
                }
            }
        }
    }
}
