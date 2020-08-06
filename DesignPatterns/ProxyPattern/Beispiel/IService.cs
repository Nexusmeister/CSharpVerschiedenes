using System.Threading.Tasks;

namespace ProxyPattern.Beispiel
{
    public interface IService
    {
        Task<bool> RufeWebserviceAuf();
    }
}