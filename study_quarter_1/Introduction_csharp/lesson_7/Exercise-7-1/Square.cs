using System;

namespace Exercise_7_1
{
    class Square
    {
        public float side { get; set; }

        public Square(float side)
        {
            this.side = side;
        }

        public float GetPerimeter()
        {
            return side * 4;
        }
    }
}
