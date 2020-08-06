using System;
using System.Collections.Generic;
using System.Text;
using WIS.WebAPIExt.ClientDataAccess;

namespace WIMS.Tools
{
    public static class ClientDataAccessFactory
    {
        /// <summary>
        /// Stellt ein fertig erstelltes ClientDataAccess-Objekt zur Verfügung
        /// </summary>
        /// <returns></returns>
        public static ClientDataAccessExt GetClientDataAccessExt()
        {
            return new ClientDataAccessExt(null, "xqChgxd5oizvHk1vEDdKQUR9y5UHnl1uCcY", "WIMS");
        }
    }
}
