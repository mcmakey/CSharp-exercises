using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_7_1
{
    class Set
    {
        public Thing[] Things { get; }
        public int Utility 
        {
            get 
            {
                int utility = 0;
                foreach (var thing in Things)
                {
                    utility += thing.Utility;
                }

                return utility;
            }
        }

        public Set(Thing[] things)
        {
            this.Things = things;
        }
        
    }
}
