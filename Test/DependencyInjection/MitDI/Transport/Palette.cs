using System;

namespace DependencyInjection.MitDI.Transport
{
    public class Palette : ITransportable
    {
        public void WerdeTransportiert()
        {
            Console.WriteLine("Palette wird transportiert");
        }
    }
}