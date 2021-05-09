using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_7_1
{
    class Backpack
    {
        public int Capacity { get; }

        public List<Thing> GetOptimalSetThings(Thing[] allThings)
        {
            var optimalSetThing = new List<Thing>();

            // Заглушка:
            optimalSetThing.Add(allThings[0]);
            optimalSetThing.Add(allThings[2]);

            return optimalSetThing;
        }

        public Backpack(int capacity)
        {
            this.Capacity = capacity;
        }
    }
}
