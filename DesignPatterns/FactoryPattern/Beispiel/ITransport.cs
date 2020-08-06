namespace FactoryPattern.Beispiel
{
    public interface ITransport
    {
        void Fahre();

        bool ErhalteTransportauftrag(int auftrag);
    }
}