// Введение в C#. Урок 2. Практическое задание 2.
// Запросить у пользователя порядковый номер текущего месяца и вывести его название.

using System;

namespace exercize_2_2
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
            int getMonthNumber()
            {
                const int MAX_VALUE = 12;
                const int MIN_VALUE = 1;
                string value;
                int number;
                bool isNumber;

                while(true)
                {
                    value = Console.ReadLine();
                    isNumber = Int32.TryParse(value, out number);

                    if (isNumber && MIN_VALUE <= number && number <= MAX_VALUE)
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
        }
    }
}
