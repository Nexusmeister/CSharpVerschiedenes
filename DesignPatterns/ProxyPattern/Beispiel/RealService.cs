using System;
using System.Threading.Tasks;

namespace ProxyPattern.Beispiel
{
    public class RealService : IService
    {
        public async Task<bool> RufeWebserviceAuf()
        {
            Console.WriteLine("Es werden verrückte Dinge getan");
            return true;
        }
    }
}