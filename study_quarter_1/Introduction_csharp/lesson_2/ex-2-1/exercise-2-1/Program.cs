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
            float minTemperature = 0;
            float maxTemperature = 0;

            static float getTemperature()
            {
                float value;

                while(true)
                {
                    if (float.TryParse(Console.ReadLine(), out value))
                    {
                        return value;
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод, попробйте еще раз");
                    }
                }
            }

            Console.WriteLine("Введите минимальную температуру за сутки (дробная часть через запятую)");
            minTemperature = getTemperature();

            Console.WriteLine("Введите максимальную температуру за сутки (дробная часть через запятую)");
            maxTemperature = getTemperature();

            float avrTemperature = (minTemperature + maxTemperature) / 2;

            Console.WriteLine($"Средняя температура за сутки - {avrTemperature}");
        }
    }
}
