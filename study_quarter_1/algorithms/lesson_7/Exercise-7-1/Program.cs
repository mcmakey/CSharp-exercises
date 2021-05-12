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

namespace Exercise_7_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Рюкзак
            Backpack backpack = new Backpack(6);

            // Исходный набор предметов
            Thing[] things = {
                new Thing("Вода", 3, 10),
                new Thing("Книга", 1, 3),
                new Thing("Еда", 2, 9),
                new Thing("Куртка", 2, 5),
                new Thing("Камера", 1, 6)
            };

            // Отображение максимальной ценности (с визуализацией таблицы)
            Console.WriteLine($"максимальная возможная общая ценность предметов, которые поместится в рюкзак: {backpack.GetMaxUtility(things)}");
            Console.WriteLine();
            
            // Отображение оптимального по ценности набора предметов, помещающегося в рюкзак
            var optimalSetThings = backpack.GetOptimalSetThings(things);

            Console.WriteLine($"Для рюкзака вместимостью {backpack.Capacity} оптимальным набором предметов (по максимальной общей ценности) будет:");
            foreach (var thing in optimalSetThings.Things)
            {
                Console.WriteLine(thing.Name);
            }
            Console.WriteLine($"Общая ценность - {optimalSetThings.Utility}");
        }
    }
}
