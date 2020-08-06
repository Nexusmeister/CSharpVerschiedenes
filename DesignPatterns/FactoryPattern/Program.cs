using System;
using FactoryPattern.Beispiel;
using FactoryPattern.Beispiel.Factories;

namespace FactoryPattern
{
    class Program
    {
        private static IFactory _factory;
        static void Main(string[] args)
        {
            Console.WriteLine("Suche nach einem passenden Transport...");
            _factory = new WieselFactory();
            SucheNachTransport(_factory);
            Console.ReadKey();

            _factory = new LkwFactory();
            SucheNachTransport(_factory);
        }

        private static void SucheNachTransport(IFactory factory)
        {
            var fahrzeug = factory.CreateFahrzeug();
            Console.WriteLine($"Ein {fahrzeug.GetType().Name} ist verfügbar.");
            fahrzeug.ErhalteTransportauftrag(33333);
            fahrzeug.Fahre();
        }

        /// <summary>
        /// Ohne Factory -> Code wird doppelt geschrieben
        /// </summary>
        private static void SucheNachTransportOhneFactory()
        {
            ITransport fahrzeug = new LKW();
            fahrzeug.ErhalteTransportauftrag(33333);
            fahrzeug.Fahre();

            ITransport fahrzeug2 = new Wiesel();
            fahrzeug2.ErhalteTransportauftrag(33333);
            fahrzeug2.Fahre();
        }
    }
}
