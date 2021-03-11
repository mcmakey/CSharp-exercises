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
            Console.WriteLine("Приложение Task Manager");
            TaskManager taskManager = new TaskManager();
            taskManager.ShowTasks();
            taskManager.EndTaskById(100500);
        }
    }
}
