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
    }
}
