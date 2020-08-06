using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExamp3
{
    class Person : IEmployee, IFriend  //Klasse erweitert mit zwei Interfaces
    {
        public string Name { get; set; }
        void IEmployee.GetCalled()
        {
            Console.WriteLine("Ja, Chef?");
        }
        void IFriend.GetCalled()
        {
            Console.WriteLine("Was gibt's?");
        }

        public void GetCalled()
        {
            Console.WriteLine("Waddup?");
        }

        public void BeCool()
        {

        }

        public void GetFired ()
        {

        }
    }
}
