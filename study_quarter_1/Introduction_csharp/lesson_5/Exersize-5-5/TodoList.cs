using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Exersize_5_5
{
    class TodoList
    {
        public Todo[] Todos { get; set; }

        public TodoList(Todo[] todos)
        {
            Todos = todos;
        }

        public void Show()
        {
            Console.WriteLine("Список задач:");
            for (int i = 0; i < Todos.Length; i++)
            {
                string completeIcon = Todos[i].IsDone ? "X" : " ";
                Console.WriteLine($"{i + 1}. {completeIcon} {Todos[i].Title}");
            }
            Console.WriteLine();
        }

        public void Add()
        {
            Console.WriteLine("Введите наименование новой задачи:");
            string title = Console.ReadLine();
            Todo newTodo = new Todo()
            {
                Title = title,
                IsDone = false
            };
            Todos = Todos.Concat(new Todo[] { newTodo }).ToArray();
            Console.WriteLine();
        }

        public void Remove()
        {
            

            const string endNumber = "0";

            while (true)
            {
                Console.WriteLine();
                this.Show();
                Console.WriteLine("Введите номер удаляемой задачи (для выхода в меню - введите 0):");
                string enteredNumber = Console.ReadLine();

                if (enteredNumber == endNumber)
                {
                    return;
                };

                if (Int32.TryParse(enteredNumber, out int number) && (0 < number && number <= Todos.Length))
                {
                    int selectedTodoIndex = --number;

                    var list = Todos.ToList();
                    list.RemoveAt(selectedTodoIndex);
                    Todos = list.ToArray();
                    
                }
                else
                {
                    Console.WriteLine("Некорректный ввод, попробуйте еще раз");
                }
            }
        }

        public void ToggleTodo()
        {
            const string endNumber = "0";

            while (true)
            {
                Console.WriteLine();
                this.Show();
                Console.WriteLine("Введите номер задачи, чтобы изменить ее состояние (для выхода в меню - введите 0)");
                string enteredNumber = Console.ReadLine();

                if (enteredNumber == endNumber)
                {
                    return;
                };

                if (Int32.TryParse(enteredNumber, out int number) && (0 < number && number <= Todos.Length))
                {
                    int selectedTodoIndex = --number;

                    Todos[selectedTodoIndex].Toggle();
                }
                else
                {
                    Console.WriteLine("Некорректный ввод, попробуйте еще раз");
                }
            }
        }
    }
}
