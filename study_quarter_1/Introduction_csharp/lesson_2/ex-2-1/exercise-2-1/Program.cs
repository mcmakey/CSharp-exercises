// Введение в C#. Урок 2. Практическое задание 1.
// Запросить у пользователя минимальную и максимальную температуру
// за сутки и вывести среднесуточную температуру.

using System;

namespace exercise_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            float enteredValue;
            float minTemperature = 0;
            float maxTemperature = 0;

            Console.WriteLine("Введите минимальную температуру за сутки (дробная часть через запятую)");

            if (float.TryParse(Console.ReadLine(), out enteredValue))
            {
                minTemperature = enteredValue;
            }
            else
            {
                Console.WriteLine("Некорректный ввод");
                Environment.Exit(0);
            }


            Console.WriteLine("Введите максимальную температуру за сутки (дробная часть через запятую)");

            if (float.TryParse(Console.ReadLine(), out enteredValue))
            {
                maxTemperature = enteredValue;
            }
            else
            {
                Console.WriteLine("Некорректный ввод");
                Environment.Exit(0);
            }


            float avrTemperature = (minTemperature + maxTemperature) / 2;

            Console.WriteLine($"Средняя температура за сутки - {avrTemperature}");
        }
    }
}
