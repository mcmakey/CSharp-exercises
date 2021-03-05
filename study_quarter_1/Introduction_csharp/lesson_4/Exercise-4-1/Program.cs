// Введение в C#. Урок 4. Практическое задание 1.
// Написать метод GetFullName(string firstName, string lastName, string patronymic),
// принимающий на вход ФИО в разных аргументах и возвращающий объединённую строку с ФИО.
// Используя метод, написать программу, выводящую в консоль 3–4 разных ФИО.

using System;

namespace Exercise_4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetFullName("Амбросий", "Суслопаров", "Викторович"));
            Console.WriteLine(GetFullName("Мартын", "Трегубов", "Аскольдович"));
            Console.WriteLine(GetFullName("Иннокентий ", "Виноградов", "Савельевич"));
        }

        static string GetFullName(string firstName, string lastName, string patronymic)
        {
            return $"{lastName} {firstName} {patronymic}";
        }
    }
}
