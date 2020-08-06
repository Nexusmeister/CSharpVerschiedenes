using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    class Program
    {
        static void Main(string[] args)
        {                        

            Shape myShape = ShapeFactory.GetShape(); // Aufruf der Factory-Methode 
            myShape.Draw();

            Shape[] shapes = new Shape[3]; // array mit den jeweiligen Formen -> Anzahl tatsächlicher Datensätze wirklich angeben
            shapes[0] = new Square();
            shapes[1] = new Circle();   // Aber Einträge werden fortlaufend nummeriert und beginnen mit 0
            shapes[2] = new Triangle();



            foreach (Shape shape in shapes) // durchlauf der ganzen Formen 
            {
                shape.Draw();       // Bei jedem Shape wird die Methode Draw aufgerufen
            }

            Console.ReadKey();
        }
    }
}
