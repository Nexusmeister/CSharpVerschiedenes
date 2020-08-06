namespace FactoryPattern.Beispiel.Factories
{
    public class WieselFactory : IFactory
    {
        public ITransport CreateFahrzeug()
        {
            return new Wiesel();
        }
    }
}