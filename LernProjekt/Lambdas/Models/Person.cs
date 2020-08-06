using System;
using System.Collections.Generic;
using System.Text;

namespace Lambdas.Models
{
    public class Person
    {
        public int Alter { get; set; }
        public Person()
        {

        }

        public bool KannLaufen(int alter)
        {
            if (alter > 2)
            {
                return true;
            }

            return false;
        }
    }
}
