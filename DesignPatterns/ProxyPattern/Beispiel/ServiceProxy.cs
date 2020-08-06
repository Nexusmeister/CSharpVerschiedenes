using System;
using System.Threading.Tasks;

namespace ProxyPattern.Beispiel
{
    public class ServiceProxy : IService
    {
        private IService _service;

        public async Task<bool> RufeWebserviceAuf()
        {
            Console.WriteLine("Proxy startet");
            if (_service == null)
            {
                _service = new RealService();
            } 
            
            return await _service.RufeWebserviceAuf();
        }
    }
}