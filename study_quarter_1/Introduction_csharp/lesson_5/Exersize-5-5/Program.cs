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

        enum Actions
        {
            Quit,
            Add,
            Remove,
            ToggleTodo
        }
        static void Main(string[] args)
        {
            TodoList todoList = getTodoList();

            while (true)
            {
                Console.WriteLine();
                todoList.Show();
                Console.WriteLine();

                Console.WriteLine("Выберете действие:");
                Console.WriteLine("1 - Добавить новую задачу");
                Console.WriteLine("2 - Удалить задачу");
                Console.WriteLine("3 - Изменить статус задачи");
                Console.WriteLine("0 - Закрыть приложение");
                Console.WriteLine();

                string action = Console.ReadLine();

                if (Int32.TryParse(action, out int actionValue))
                {
                    switch (actionValue)
                    {
                        case (int)Actions.Add:
                            todoList.Add();
                            break;
                        case (int)Actions.Remove:
                            todoList.Remove();
                            break;
                        case (int)Actions.ToggleTodo:
                            todoList.ToggleTodo();
                            break;
                        case 0:
                            SaveChanges(todoList.Todos);
                            return;
                        default:
                            Console.WriteLine("Нет такого действия");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод, попробуйте еще раз");
                };
            };
        }

        static string GetPath()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string file = @"..\..\..\data\todos.json";
            return Path.Combine(baseDir, file);
        }

        static TodoList getTodoList()
        {
            string path = GetPath();
            Todo[] todos = JsonSerializer.Deserialize<Todo[]>(File.ReadAllText(path));
            return new TodoList(todos);
        }

        static void SaveChanges(Todo[] todos)
        {
            string path = GetPath();
            string todosJson = JsonSerializer.Serialize(todos);
            File.WriteAllText(path, todosJson);
        }
    }
}
