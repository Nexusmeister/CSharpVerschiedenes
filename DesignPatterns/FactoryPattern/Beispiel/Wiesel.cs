using System;

namespace FactoryPattern.Beispiel
{
    public class Wiesel : ITransport
    {
        public void Fahre()
        {
            Console.WriteLine("Wiesel fährt los.");
        }

        public bool ErhalteTransportauftrag(int auftrag)
        {
            Console.WriteLine($"Auftrag {auftrag} wird von Wiesel bearbeitet...");
            return true;
        }
    }
}