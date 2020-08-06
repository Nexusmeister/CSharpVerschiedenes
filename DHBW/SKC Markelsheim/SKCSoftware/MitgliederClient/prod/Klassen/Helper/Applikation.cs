using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MitgliederClient.Klassen.Helper
{
    class Applikation
    {
        /// <summary>
        /// Erhalte VersionsNr der Anwendung
        /// </summary>
        /// <returns></returns>
        public static string GetVersion()
        {
            try
            {
                return ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            catch (Exception)
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
    }
}
