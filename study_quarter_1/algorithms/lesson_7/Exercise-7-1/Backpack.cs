using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_7_1
{
    class Backpack
    {
        public int Capacity { get; }



        public Backpack(int capacity)
        {
            this.Capacity = capacity;
        }

        public List<Thing> GetOptimalSetThings(Thing[] allThings)
        {
            var optimalSetThing = new List<Thing>();

            // Заглушка:
            // optimalSetThing.Add(allThings[0]);
            // optimalSetThing.Add(allThings[2]);

            //for (int i = 0; i < allThings.Length; i++)
            //{
            //    for (int j = 0; j < this.Capacity; j++)
            //    {

            //    }
            //}

            return optimalSetThing;
        }


        // Метод определения максимальной полезности предметов, которые вместятся в рюкзак
        public int GetMaxCost(Thing[] allThings)
        {
            var totalUtility = 0;
            int[,] table = new int[allThings.Length, this.Capacity + 1];

            // Заполнение ячеек первой строки таблицы
            table[1, 0] = 0; // Первый столбец для нулевой вместимости рюкзака
            Console.Write($"{0} ");
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
