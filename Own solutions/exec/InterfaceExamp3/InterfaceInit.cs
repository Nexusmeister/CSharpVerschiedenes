using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExamp3
{
    interface IEmployee
    {
        string Name { get; set; }
        void GetCalled();
        void GetFired();
    }

    interface IFriend
    {
        string Name { get; set; }
        void GetCalled();
        void BeCool();
    }
}
