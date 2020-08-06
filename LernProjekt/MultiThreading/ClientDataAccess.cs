using System;
using System.Collections.Generic;
using System.Text;

namespace MultiThreading
{
    public class ClientDataAccess
    {
        public string Art { get; set; }
        public ClientDataAccess(string value)
        {
            Art = DecideValue(value);
        }


        public string DecideValue(string value)
        {
            if (value.Equals("prod"))
            {
                return "Prod";
            }
            else
            {
                return "Test";
            }
        }
    }
}
