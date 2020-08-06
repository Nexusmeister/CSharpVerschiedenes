using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    abstract class Shape // Abstrakte Klasse -> Keine Objekte werden aus dieser Klasse erzeugt
    {
        // Attribute
        public int Top { get; set; }
        public int Left { get; set; }
        public ConsoleColor Color { get; set; }
        public virtual int Height {get; set;}

        public virtual int Width { get; set; }

        public bool IsCollision(Shape s)
        {
            return (s.Top < this.Top && s.Top + s.Height > this.Top || this.Top < s.Top && this.Top + this.Height > s.Top) && 
                (s.Left < this.Left && s.Left + s.Width > this.Left || this.Left < s.Left && this.Left + this.Width > s.Left);
        }
        public void DrawShapeBeforeMe(Shape s)
        {
            s.Draw();
            this.Draw();
        }

        


        // Methoden
        public abstract void Draw();

        // In dieser Klasse werden gemeinsame Eigenschaften der Formen zusammengefasst, die die Klassen beziehen können
    }

}
