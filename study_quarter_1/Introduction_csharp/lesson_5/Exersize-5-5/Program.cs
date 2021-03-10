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
using System.Linq;

namespace Exersize_5_5
{
    class Program
    {

        enum Actions
        {
            Quit,
            Add,
            Remove,
            Toggle
        }
        static void Main(string[] args)
        {

            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string file = @"..\..\..\data\todos.json";
            string path =  Path.Combine(baseDir, file);

            Todo[] todos = JsonSerializer.Deserialize<Todo[]>(File.ReadAllText(path));

            TodoList todoList = new TodoList(todos);

            while (true)
            {
                // ShowTodoList(todos);
                todoList.Show();
                Console.WriteLine();
                Console.WriteLine("Выберете действие:");
                Console.WriteLine("1 - Добавить новую задачу");
                Console.WriteLine("2 - Удалить задачу");
                Console.WriteLine("3 - Изменить статус задачи");
                Console.WriteLine("0 - Закрыть приложение");

                string action = Console.ReadLine();

                if (Int32.TryParse(action, out int actionValue))
                {
                    switch (actionValue)
                    {
                        case (int)Actions.Add:
                            AddTodo(ref todos);
                            break;
                        case (int)Actions.Remove:
                            RemoveTodo(ref todos);
                            break;
                        case (int)Actions.Toggle:
                            EditTodoStatus(todos);
                            break;
                        case 0:
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

        static void ShowTodoList(Todo[] todos)
        {
            Console.WriteLine("Список задач:");
            for (int i = 0; i < todos.Length; i++)
            {
                string completeIcon = todos[i].IsDone ? "X" : " ";
                Console.WriteLine($"{i + 1}. {completeIcon} {todos[i].Title}");
            }
            Console.WriteLine();
        }

        static void AddTodo(ref Todo[] todos)
        {
            Console.WriteLine("Введите наименование новой задачи:");
            string title = Console.ReadLine();
            Todo newTodo = new Todo()
            {
                Title = title,
                IsDone = false
            };
            todos = todos.Concat(new Todo[] { newTodo }).ToArray();
            Console.WriteLine();
            ShowTodoList(todos);
        }

        static void RemoveTodo(ref Todo[] todos)
        {
            Console.WriteLine("Введите номер удаляемой задачи (для завершения введите 0):");

            const string endNumber = "0";

            while (true)
            {
                string enteredNumber = Console.ReadLine();

                if (enteredNumber == endNumber)
                {
                    return;
                };

                if (Int32.TryParse(enteredNumber, out int number) && (0 < number && number <= todos.Length))
                {
                    int selectedTodoIndex = --number;

                    var list = todos.ToList();
                    list.RemoveAt(selectedTodoIndex);
                    todos = list.ToArray();

                    ShowTodoList(todos);
                }
                else
                {
                    Console.WriteLine("Некорректный ввод, попробуйте еще раз");
                }
            }
        }

        static void EditTodoStatus(Todo[] todos)
        {
            Console.WriteLine("Введите номер задачи, чтобы изменить ее состояние (чтобы закончить редактирование нажмите 0)");

            const string endNumber = "0";

            while (true)
            {
                string enteredNumber = Console.ReadLine();

                if (enteredNumber == endNumber)
                {
                    return;
                };

                if (Int32.TryParse(enteredNumber, out int number) && (0 < number  && number  <= todos.Length)) {
                    int selectedTodoIndex = --number;

                    todos[selectedTodoIndex].Toggle();
                    ShowTodoList(todos);
                }
                else
                {
                    Console.WriteLine("Некорректный ввод, попробуйте еще раз");
                }
            }

        }
    }
}
