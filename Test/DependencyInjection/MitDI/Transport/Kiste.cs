using System;

namespace DependencyInjection.MitDI.Transport
{
    public class Kiste : ITransportable
    {
        public void WerdeTransportiert()
        {
            Console.WriteLine("Kiste wird transportiert");
        }
    }
}