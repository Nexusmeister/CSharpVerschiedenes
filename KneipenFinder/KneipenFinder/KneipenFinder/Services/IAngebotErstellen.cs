using System.Threading.Tasks;

namespace KneipenFinder.Services
{
    public interface IAngebotErstellen
    {
        Task<bool> AngebotErstellen();
        bool PruefeEingabenAufFehler();
    }
}
