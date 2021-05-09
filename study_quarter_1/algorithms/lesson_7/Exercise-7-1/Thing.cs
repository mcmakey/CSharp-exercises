using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_7_1
{
    class Thing
    {
        public string Name { get; }
        public int Weight { get; }
        public int Utility { get; }

        public Thing(string name, int weight, int utility)
        {
            this.Name = name;
            this.Weight = weight;
            this.Utility = utility;
        }
    }
}
