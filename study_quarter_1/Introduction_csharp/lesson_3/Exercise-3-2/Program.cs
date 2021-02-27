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
            const int NUMBER_ENTRIES = 5;
            const int NUMBER_FIELDS = 2;

            string[,] phoneBook = CreatePhonebook(NUMBER_ENTRIES, NUMBER_FIELDS);

            ShowPhoneBook(phoneBook);
        }

        static string[,] CreatePhonebook(int entries,  int fields)
        {
            Console.WriteLine("Заполнение телефонной книги");
            string[,] phoneBook = new string[entries, fields];

            for (int i = 0; i < entries; i++)
            {
                Console.WriteLine($"Запись {i + 1}:");
                for (int j = 0; j < fields; j++)
                {
                    if ( j == 0)
                    {
                        Console.WriteLine($"Введите имя");
                        phoneBook[i, j] = Console.ReadLine();
                    } 
                    else if ( j == 1 )
                    {
                        Console.WriteLine($"Введите номер или email");
                        phoneBook[i, j] = Console.ReadLine();
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("Телефонная книга заполнена");
            Console.WriteLine();

            return phoneBook;
        }

        static void ShowPhoneBook(string[,] phoneBook)
        {
            const int OFFSET = 40;

            int entriesNumber = phoneBook.GetUpperBound(0) + 1;
            int fieldsNumber = phoneBook.Length / entriesNumber;

            Console.Write("№ п/п \t");
            Console.Write("Имя".PadRight(OFFSET));
            Console.Write("Телефон/Email");
            Console.WriteLine();

            for (int i = 0; i < entriesNumber; i++)
            {
                Console.Write("{0, 4}. \t", i);
                for (int j = 0; j < fieldsNumber; j++)
                {
                    var offset = j == 0 ? OFFSET : 0;
                    Console.Write(phoneBook[i, j].PadRight(offset));
                }
                Console.WriteLine();
            }
        }
    }
}
