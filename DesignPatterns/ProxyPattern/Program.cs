using System;
using System.Threading.Tasks;
using ProxyPattern.Beispiel;

namespace ProxyPattern
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IService serviceCall = new RealService();
            var x = await serviceCall.RufeWebserviceAuf();

            serviceCall = new ServiceProxy();
            x = await serviceCall.RufeWebserviceAuf();
        }
    }
}
