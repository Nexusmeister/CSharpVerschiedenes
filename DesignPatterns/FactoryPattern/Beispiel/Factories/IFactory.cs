namespace FactoryPattern.Beispiel.Factories
{
    public interface IFactory
    {
        ITransport CreateFahrzeug();
    }
}