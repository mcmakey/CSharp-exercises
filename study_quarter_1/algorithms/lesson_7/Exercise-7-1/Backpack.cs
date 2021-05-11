using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise_7_1
{
    class Backpack
    {
        public int Capacity { get; }



        public Backpack(int capacity)
        {
            this.Capacity = capacity;
        }

        public Set GetOptimalSetThings(Thing[] allThings)
        {
            Set[,] table = new Set[allThings.Length, this.Capacity + 1];

            // Заполнение ячеек первой строки таблицы
            table[0, 0] = new Set(new Thing[] { new Thing("zero", 0, 0) }); // Первый столбец для нулевой вместимости рюкзака
            for (int j = 1; j <= Capacity; j++)
            {
                table[0, j] = allThings[0].Weight <= j 
                    ? new Set(new Thing[] { allThings[0] }) 
                    : new Set(new Thing[] { new Thing("zero", 0, 0) });
            }

            // Заполнение ячеек остальных строк таблицы
            for (int i = 1; i < allThings.Length; i++)
            {
                table[i, 0] = new Set(new Thing[] { new Thing("zero", 0, 0)}); // Первый столбец для нулевой вместимости рюкзака
                for (int j = 1; j <= this.Capacity; j++)
                {
                    if (allThings[i].Weight > j)
                    {
                        table[i, j] = new Set(table[i - 1, j].Things);
                    }
                    else
                    {
                        var ttt = new Thing[] { allThings[i] };
                        var ppp = table[i - 1, j - allThings[i].Weight].Things; 
                        var zzz = ttt.Concat<Thing>(ppp).ToArray();
                       
                        if (table[i - 1, j].Utility > allThings[i].Utility + table[i - 1, j - allThings[i].Weight].Utility)
                        {
                            table[i, j] = new Set(table[i - 1, j].Things);
                        }
                        else
                        {
                            table[i, j] = new Set(zzz);
                        }
                    }
                }
            }
            Console.WriteLine();

            return table[allThings.Length - 1, this.Capacity];
        }

        // Метод определения максимальной полезности предметов, которые вместятся в рюкзак
        public int GetMaxCost(Thing[] allThings)
        {
            var totalUtility = 0;
            int[,] table = new int[allThings.Length, this.Capacity + 1];

            // Заполнение ячеек первой строки таблицы
            table[0, 0] = 0; // Первый столбец для нулевой вместимости рюкзака
            totalUtility = table[1, 0]; // 
            Console.Write($"{totalUtility} "); // 
            for (int j = 1; j <= Capacity; j++)
            {
                table[0, j] = allThings[0].Weight <= j ? allThings[0].Utility : 0;
                totalUtility = table[0, j]; // 
                Console.Write($"{totalUtility} "); // 
            }

            // Заполнение ячеек остальных строк таблицы
            for (int i = 1; i < allThings.Length; i++)
            {
                Console.WriteLine(); //
                table[i, 0] = 0; // Первый столбец для нулевой вместимости рюкзака
                Console.Write($"{0} ");
                for (int j = 1; j <= this.Capacity; j++)
                {
                    if (allThings[i].Weight > j)
                    {
                        table[i, j] = table[i - 1, j];
                    }
                    else
                    {
                        table[i, j] = Math.Max(
                            table[i - 1, j],
                            allThings[i].Utility + table[i - 1, j - allThings[i].Weight]
                        );
                    }
                    totalUtility = table[i, j];
                    Console.Write($"{totalUtility} ");
                }
            }
            Console.WriteLine();

            return totalUtility;
        }
    }
}
