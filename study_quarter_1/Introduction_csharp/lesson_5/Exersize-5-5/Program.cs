// Введение в C#. Урок 5. Практическое задание 5.

// Список задач(ToDo-list):
// - написать приложение для ввода списка задач;
// - задачу описать классом ToDo с полями Title и IsDone;
// - на старте, если есть файл tasks.json/xml/bin (выбрать формат),
//   загрузить из него массив имеющихся задач и вывести их на экран;
// - если задача выполнена, вывести перед её названием строку «[x]»;
// - вывести порядковый номер для каждой задачи;
// - при вводе пользователем порядкового номера задачи отметить задачу с этим порядковым номером как выполненную;
// - записать актуальный массив задач в файл tasks.json/xml/bin.


using System;
using System.Text.Json;
using System.IO;

namespace Exersize_5_5
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Список задач(ToDo-list)"); // 


            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string file = @"..\..\..\data\todos.json";
            string path =  Path.Combine(baseDir, file);

            Todo[] todos = JsonSerializer.Deserialize<Todo[]>(File.ReadAllText(path));

            showTodoList(todos);

        }

        static void showTodoList(Todo[] todos)
        {
            for (int i = 0; i < todos.Length; i++)
            {
                string completeIcon = todos[i].IsDone ? "X" : "";
                Console.WriteLine($"{i + 1}. {completeIcon} {todos[i].Title}");
            }
        }
    }
}
