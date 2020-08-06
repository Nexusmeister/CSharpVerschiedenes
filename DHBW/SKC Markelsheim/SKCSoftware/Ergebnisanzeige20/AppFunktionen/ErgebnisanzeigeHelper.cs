using System;
using System.Deployment.Application;
using System.Reflection;

namespace Ergebnisanzeige20.AppFunktionen
{
    public class ErgebnisanzeigeHelper
    {
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

        public static string GetAppName()
        {
            try
            {
                return Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyTitleAttribute>().Title;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static string GetAppTitle()
        {
            string appName = GetAppName();
            appName += " [Eingabe] v";
            appName += GetVersion();
            return appName;
        }
    }
}
