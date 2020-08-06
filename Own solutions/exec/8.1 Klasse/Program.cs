using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8._1_Klasse
{
    class Program
    {
        static void Main(string[] args)
        {
            Person newPerson = new Person
            {
                Lastname = "Blöd",
                Size = 179
            };
            string name = newPerson.Lastname;
            Console.WriteLine(newPerson.Lastname);
            //Console.WriteLine(Fullname);
            Console.ReadKey();
        }
        enum Sex1 { Male, Female }
        class Person // Klasse erstellt
        {
            string firstname;
            string lastname;

            public string Firstname
            {
                get
                {
                    return this.firstname;
                }
                set
                {
                    this.firstname = value;
                }
            
            }
            DateTime birthday;
            public DateTime Birthday
            {
                get
                {
                    return this.birthday;
                }
                set
                {
                    if (value <= DateTime.Now)
                        this.birthday = value;
                }
            }                    
                     
            byte size;
            public byte Size
            {
                get
                {
                    return this.size;
                }
                set
                {
                    if (value > 0)
                        this.size = value;
                }
            }
            public string Lastname
            {
                
            get
                {
                    return this.lastname;
                }
                set
                {
                    this.lastname = value;
                }
            }
            public string Fullname
            {
                get
                {
                    return string.Format("{0} {1}", this.firstname, this.lastname);
                }
               
            }
            public Sex1 Sex { get; set; }
           
        }
        // ----------------------------------- Andere Attribute Schreibweise -----------------------------------
        /*  Öffentliche zugreifbare EigenschaftEigenschaften können eingelesen werden und eingestellt werden 
            ODER -> 
         *               public string Lastname { get; set; }
         *               public string Firstname {get; set;} 
                         public DateTime Birthday {get; set; }
                         public byte Height { get; set; }        */
    }
}

