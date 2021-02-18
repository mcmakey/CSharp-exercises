// Введение в C#. Урок 1. Практическое задание 1.
// Написать программу, выводящую в консоль текст: «Привет, %имя пользователя%, сегодня %дата%».
// Имя пользователя сохранить из консоли в промежуточную переменную.

using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var usCulture = new System.Globalization.CultureInfo("en-US");

            Console.WriteLine("What's your name?");

            string userName = Console.ReadLine();
            string dateToDisplay = DateTime.Today.ToString("MMMM dd, yyyy", usCulture.DateTimeFormat);

            Console.WriteLine($"Hi {userName} today {dateToDisplay}");
        }
    }
}
