// Введение в C#. Урок 2. Практическое задание 6.

// Для полного закрепления битовых масок, попытайтесь создать универсальную структуру
// расписания недели, к примеру, чтобы описать работу какого либо офиса.
// Явный пример - офис номер 1 работает со вторника до пятницы, офис номер 2 работает
// с понедельника до воскресенья и выведите его на экран консоли.

using System;

namespace exercize_2_6
{
    class Program
    {
        [Flags]
        enum DaysOfWeek
        {
            Monday    = 0b_0000001,
            Tuesday   = 0b_0000010,
            Wednesday = 0b_0000100,
            Thursday  = 0b_0001000,
            Friday    = 0b_0010000,
            Saturday  = 0b_0100000,
            Sunday    = 0b_1000000,
        }
        static void Main(string[] args)
        {

            DaysOfWeek workDaysOfficeOne =
                DaysOfWeek.Monday |
                DaysOfWeek.Tuesday |
                DaysOfWeek.Wednesday |
                DaysOfWeek.Thursday |
                DaysOfWeek.Friday |
                DaysOfWeek.Saturday |
                DaysOfWeek.Sunday;

            DaysOfWeek workDaysOfficeTwo =
                DaysOfWeek.Saturday |
                DaysOfWeek.Sunday;

            DaysOfWeek workDaysOfficeThree =
                DaysOfWeek.Monday |
                DaysOfWeek.Wednesday |
                DaysOfWeek.Friday;

            Console.WriteLine($"Working days of office 1: {workDaysOfficeOne}");
            Console.WriteLine($"Working days of office 2: {workDaysOfficeTwo}");
            Console.WriteLine($"Working days of office 3: {workDaysOfficeThree}");
        }
    }
}
