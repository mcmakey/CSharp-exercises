using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Exercise_6_1
{
    class TaskManager
    {
        public Process[] Tasks { get; set; }

        public TaskManager(Process[] tasks)
        {
            Tasks = tasks;
        }

        public void ShowTasks()
        {
            Console.WriteLine();
            Console.WriteLine("Список процессов:");
            Console.WriteLine();
            for (int i = 0; i < Tasks.Length; i++)
            {
                Console.WriteLine($"{i + 1}   process id: {Tasks[i].Id}   process name: {Tasks[i].ProcessName}");
            }
            Console.WriteLine();
        }
    }
}
