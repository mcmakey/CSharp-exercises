// Введение в C#. Урок 3. Практическое задание 2.
// Написать программу — телефонный справочник — создать двумерный массив 5*2,
// хранящий список телефонных контактов: первый элемент хранит имя контакта, второй — номер телефона/e-mail.

using System;

namespace Exercise_3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] phoneBook = new string[5, 2];
            FillPhoneBook(phoneBook);
        }

        static void FillPhoneBook(string[,] phonebook)
        {
            int numberEntries = phonebook.GetUpperBound(0) + 1;
            Console.WriteLine(numberEntries);
        }
    }
}
