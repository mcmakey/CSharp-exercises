using System;

namespace Exercise_4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetFullName("Амбросий", "Суслопаров", "Викторович"));
            Console.WriteLine(GetFullName("Мартын", "Трегубов", "Аскольдович"));
            Console.WriteLine(GetFullName("Иннокентий ", "Виноградов", "Савельевич"));
        }

        static string GetFullName(string firstName, string lastName, string patronymic)
        {
            return $"{lastName} {firstName} {patronymic}";
        }
    }
}
