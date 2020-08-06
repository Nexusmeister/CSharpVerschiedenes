namespace FactoryPattern.Beispiel.Factories
{
    public class LkwFactory : IFactory
    {
        public ITransport CreateFahrzeug()
        {
            return new LKW();
        }
    }
}