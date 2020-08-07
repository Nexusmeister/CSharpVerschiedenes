using DependencyInjection.MitDI.Transport;

namespace DependencyInjection.MitDI
{
    public class TransporterDi
    {
        private readonly ITransportable _transport;

        public TransporterDi(ITransportable transport)
        {
            _transport = transport;
        }

        public void Start()
        {
            _transport.WerdeTransportiert();
        }
    }
}