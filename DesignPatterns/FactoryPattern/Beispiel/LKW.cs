using System;

namespace FactoryPattern.Beispiel
{
    public class LKW : ITransport
    {
        public void Fahre()
        {
            Console.WriteLine("LKW fährt los.");
        }

        public bool ErhalteTransportauftrag(int auftrag)
        {
            Console.WriteLine($"Auftrag {auftrag} wird bearbeitet...");
            return true;
        }
    }
}