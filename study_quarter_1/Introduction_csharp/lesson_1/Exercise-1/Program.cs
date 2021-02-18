using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What's your name?");
            string userName = Console.ReadLine();
            string dateToDisplay = DateTime.Today.ToString("MMMM dd, yyyy, en-US");
            Console.WriteLine($"Hello {userName} today {dateToDisplay}");
        }
    }
}
