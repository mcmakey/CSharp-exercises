// Введение в C#. Урок 3. Практическое задание 3.
// Написать программу, выводящую введенную пользователем строку в обратном порядке (olleH вместо Hello).

using System;

namespace Exercise_3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку");
            string text = Console.ReadLine();

            char[] charactersText = text.ToCharArray();
            Array.Reverse(charactersText);

            Console.WriteLine(String.Join(null, charactersText));

        }
    }
}
