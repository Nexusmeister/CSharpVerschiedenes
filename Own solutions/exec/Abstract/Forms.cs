using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    class Triangle : Shape
    {
        public override void Draw()
        {
            // Simulate Draw
            Console.WriteLine("Zeichne Dreieck");
        }
    }
   class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Zeichne Kreis");
        }
    }

    class Square : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Zeichne Quadrat");
        }
    }
    
}
