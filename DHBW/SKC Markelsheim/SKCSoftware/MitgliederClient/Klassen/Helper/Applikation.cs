using System;
using System.Deployment.Application;
using System.Reflection;

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
