using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExamp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();

            ((IFriend)p).GetCalled();
                Console.ReadKey();

            ((IEmployee)p).GetCalled();
                Console.ReadKey();

            p.GetCalled();
                Console.ReadKey();
        }
    }
}
