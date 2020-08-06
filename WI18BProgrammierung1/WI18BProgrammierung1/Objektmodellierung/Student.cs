using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objektmodellierung
{
    class Student
    {
        private static int matrikelNr = 5000000;
        private string Name { get; set; }
        private Studienfach studienfach;

        public Studienfach Studienfach
        {
            get
            {
                return studienfach;
            }
            
        }

        public int MatrikelNr {
            get
            {
                return matrikelNr;
            }
        }

        public Student(String name, Studienfach studienfach)
        {
            matrikelNr++;
            this.Name = name;
            this.studienfach = studienfach;
        }

        
        

    }

    enum Studienfach
    {
        WIRTSCHAFTSINFORMATIK = 1,
        PHYSIK,
        MATHEMATIK,
        FASSADENTECHNIK,
        MASCHINENBAU
    }
}
