using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektProzessLernen
{
    struct Test
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public void Add(Test v)
        {
            this.X += v.X;
            this.Y += v.Y;
            this.Z += v.Z;

        }
    }
}
