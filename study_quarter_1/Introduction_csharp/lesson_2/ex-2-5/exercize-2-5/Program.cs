// Введение в C#. Урок 2. Практическое задание 5.

// Если пользователь указал месяц из зимнего периода,
// а средняя температура > 0, вывести сообщение «Дождливая зима».

using System;

namespace exercize_2_5
{
    class Program
    {
        enum Months
        {
            Январь = 1,
            Февраль,
            Март,
            Апрель,
            Май,
            Июнь,
            Июль,
            Август,
            Сентябрь,
            Октябрь,
            Ноябрь,
            Декабрь
        }
        static void Main(string[] args)
        {
            const int MAX_MONTH_NUMBER = 12;
            const int MIN_MONTH_NUMBER = 1;
            const int FREEZING_POINT_WATER = 0;

            // Температура

            float minTemperature = new float();
            float maxTemperature = new float();

            static float getTemperature()
            {
                float value = new float();

                while (true)
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

            Console.WriteLine("Введите минимальную температуру (дробная часть через запятую)");
            minTemperature = getTemperature();

            Console.WriteLine("Введите максимальную температуру (дробная часть через запятую)");
            maxTemperature = getTemperature();

            float avrTemperature = (minTemperature + maxTemperature) / 2;

            Console.WriteLine($"Средняя температура - {avrTemperature}");

            // месяц

            int getMonthNumber()
            {
               
                string value;
                int number = new int();
                bool isNumber = new bool();

                while (true)
                {
                    value = Console.ReadLine();
                    isNumber = Int32.TryParse(value, out number);

                    if (isNumber && (MIN_MONTH_NUMBER <= number && number <= MAX_MONTH_NUMBER))
                    {
                        return number;
                    }
                    else
                    {
                        Console.WriteLine("Неккоректный ввод, попробуйте еще раз");
                    };
                }
            }

            Console.WriteLine("Введите номер месяца");

            int monthNumber = getMonthNumber();
            string monthName = Enum.GetName(typeof(Months), monthNumber);

            Console.WriteLine($"Месяц с номером {monthNumber} это {monthName}");

            // 

            bool isWinterMonth = (monthNumber < 3 || monthNumber == 12);

            if ( isWinterMonth && avrTemperature > FREEZING_POINT_WATER)
            {
                Console.WriteLine("Дождливая зима");
            }
        }
    }
}
