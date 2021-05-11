// Алгоритмы. Урок 7. Задание 1

// Задача о рюкзаке (решил разобрать эту задачу)
// Емкость рюкзака составляет 6 фунтов,
// Можно взять предметы из следующего списка.
// У каждого предмета имеется стоимость, чем она выше, тем важнее предмет:
// вода, 3 фунта, 10; 
// книга, 1 фунт, 3;
// еда, 2 фунта, 9;
// куртка, 2 фунта, 5;
// камера, 1 фунт, 6 
// Какой оптимальный набор предметов для похода?

using System;
using System.Collections.Generic;

namespace Exercise_7_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Backpack backpack = new Backpack(6);

            Thing[] things = {
                new Thing("Вода", 3, 10),
                new Thing("Книга", 1, 3),
                new Thing("Еда", 2, 9),
                new Thing("Куртка", 2, 5),
                new Thing("Камера", 1, 6)
            };

            

            // Вывод результата
            //Console.WriteLine($"Для рюкзака вместимостью {backpack.Capacity}");
            //Console.WriteLine($"И набора вещей:");
            //foreach (var thing in things)
            //{
            //    Console.WriteLine($"{thing.Name} (вес {thing.Weight}, полезность {thing.Utility})");
            //}
            //Console.WriteLine($"Оптимальным набором будет:");
            //foreach (var thing in optimalSetThings)
            //{
            //    Console.WriteLine(thing.Name);
            //}

            //ttt
            Console.WriteLine($"максимальная возможная ценность: {backpack.GetMaxCost(things)}");
            Console.WriteLine();
            ///

            var optimalSetThings = backpack.GetOptimalSetThings(things);
            Console.WriteLine(optimalSetThings.Utility);

            foreach (var thing in optimalSetThings.Things)
            {
                Console.WriteLine(thing.Name);
            }
        }

        static void DisplayResult(List<Thing> optimalSetThigs)
        {
            
        }
    }
}
