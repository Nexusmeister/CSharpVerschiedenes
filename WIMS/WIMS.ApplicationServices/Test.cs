using System;
using WIS.WebAPIExt.ClientDataAccess;

namespace WIMS.ApplicationServices
{
    public class Test
    {
        private readonly IClientDataAccessExt _extern;
        public Test(IClientDataAccessExt ext)
        {
            _extern = ext;

            Testen();
            
        }

        private async void Testen()
        {
            var t =  await _extern.ArtikelumschlagRepository.GetArtikelumschlagWisPortalAsync();
        }
    }
}
