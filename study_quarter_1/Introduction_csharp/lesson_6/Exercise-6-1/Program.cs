// Введение в C#. Урок 6. Практическое задание 1.
// Написать консольное приложение Task Manager, которое выводит на экран
// запущенные процессы и позволяет завершить указанный процесс.
// Предусмотреть возможность завершения процессов с помощью указания его ID или имени процесса

using System;
using System.Diagnostics;

namespace Exercise_6_1
{
    class Program
    {
        static void Main(string[] args)
        {
            const char exitApp = '0';
            const char showProcesses = '1';
            const char еndProcessById = '2';
            const char еndPocessesByName = '3';

            ConsoleKeyInfo keyInfo;

            TaskManager taskManager = new TaskManager();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Выберите действие:");
                Console.WriteLine();
                Console.WriteLine($"{showProcesses} - показать активные процессы");
                Console.WriteLine($"{еndProcessById} - завершить процесс по id");
                Console.WriteLine($"{еndPocessesByName} - завершить процесс по имени");
                Console.WriteLine($"{exitApp} - выйти из приложения");
                Console.WriteLine();

                keyInfo = Console.ReadKey();
                Console.WriteLine();

                switch (keyInfo.KeyChar)
                {
                    case exitApp:
                        Console.WriteLine("Выход из приложения");
                        return;
                    case showProcesses:
                        taskManager.ShowProcesses();
                        break;
                    case еndProcessById:
                        taskManager.EndProcessById(GetProcessId());
                        break;
                    case еndPocessesByName:
                        taskManager.EndProcessesByName(GetProcessName());
                        break;
                    default:
                        Console.WriteLine("Проверьте правильность ввода");
                        break;
                }
            }
        }

        static int GetProcessId()
        {
            Console.WriteLine("Введите id процесса:");
            while (true)
            {
                string stringId = Console.ReadLine();
                if(Int32.TryParse(stringId, out int id))
                {
                    return id;
                }
                else
                {
                    Console.WriteLine("Некоректный ввод, попробуйте еще раз");
                }
            }
        }

        static string GetProcessName()
        {
            Console.WriteLine("Введите имя удаляемого процесса:");
            return Console.ReadLine();
        }
    }
}
