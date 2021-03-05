// Введение в C#. Урок 4. Практическое задание 3.
// Написать метод по определению времени года. На вход подаётся число – порядковый номер месяца.
// На выходе — значение из перечисления (enum) — Winter, Spring, Summer, Autumn.
// Написать метод, принимающий на вход значение из этого перечисления и возвращающий название времени года
// (зима, весна, лето, осень). Используя эти методы, ввести с клавиатуры номер месяца и вывести
// название времени года. Если введено некорректное число, вывести в консоль текст «Ошибка: введите число от 1 до 12»

using System;

namespace Exercise_4_3
{
    class Program
    {
        enum Seasons
        {
            Winter,
            Spring,
            Summer,
            Autumn
        };

        const int MAX_NUMBER_MONTH = 12;
        const int MIN_NUMBER_MONTH = 1;
        const int NUMBER_MONTH_SEASON = 3;

        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер месяца");
            int numberMonth = EnteredNumberMonth();
            string season = GetSeason(numberMonth);

        }

        static int EnteredNumberMonth()
        {
            while(true)
            {
                if( Int32.TryParse(Console.ReadLine(), out int number) && 
                    (MIN_NUMBER_MONTH <= number && number <= MAX_NUMBER_MONTH)
                  )
                {
                    return number;
                } else
                {
                    Console.WriteLine("Ошибка: введите число от 1 до 12");
                }
            }
        }

        static string GetSeason(int numberMonth)
        {
            int indexOfSeason = numberMonth / NUMBER_MONTH_SEASON;
            if (indexOfSeason == MAX_NUMBER_MONTH / NUMBER_MONTH_SEASON)
            {
                indexOfSeason = 0;
            }

            return Enum.GetName(typeof(Seasons), indexOfSeason);
        }

        static string GetSeasonName(string season)
        {
            string seasonName;

            if (Enum.TryParse(season, out Seasons value))
            {
                switch (value)
                {
                    case Seasons.Winter:
                        seasonName = "Зима";
                        break;
                    case Seasons.Spring:
                        seasonName = "Весна";
                        break;
                    case Seasons.Summer:
                        seasonName = "Лето";
                        break;
                    case Seasons.Autumn:
                        seasonName = "Осень";
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ошибка");
            }

            return seasonName; 
        }
    }
}
