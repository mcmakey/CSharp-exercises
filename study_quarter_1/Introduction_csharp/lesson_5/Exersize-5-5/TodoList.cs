using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
