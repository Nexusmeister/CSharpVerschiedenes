using System;
using System.Collections.Generic;
using System.Text;

namespace Lambdas.Models
{
    public class Student : Person
    {
        public int MatrikelNr { get; set; }
        public double GPA { get; set; }
        public Student()
        {

        }

        public bool BestehtKlausuren(int matrikelNr)
        {
            if (GPA < 4.0)
            {
                return true;
            }

            return false;
        }
    }
}
