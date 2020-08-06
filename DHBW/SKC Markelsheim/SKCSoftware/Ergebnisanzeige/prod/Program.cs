using System;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Ergebnisanzeige.Views;
using SKCDLL.Tools;
using Logger = Ergebnisanzeige.Tools.Logger;
using EMail = Ergebnisanzeige.Tools.EMail;

namespace Ergebnisanzeige
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Logger.LogToFile("Anwendung gestartet.");
                Logger.LogToFile($"Anwendung initalisiert unter: {Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmEingabe());
                Logger.LogToFile("Anwendung beendet.", "------------------------------------------------------------");

                if (!Application.StartupPath.Contains(@"bin\Debug"))
                {
                    EMail.VersendeMailMitLog("Anwendung wurde geschlossen.", "Anwendung beendet.");
                }  
                
                
            }
            catch (Exception e1)
            {
                SKCMessages.ShowError($"Unbehandelter Fehler in Anwendung aufgetaucht!!! Schnellstmöglich Robin kontaktieren. {e1.Message}");
                Logger.LogToFile($"Fehler auf oberster Anwendungsebene! Unbehandelter Fehler aufgetaucht. Anwendung schließt sich nun. {e1.Message} {e1.StackTrace}");
                EMail.VersendeMailMitLog($"Fehler auf oberster Anwendungsebene! Unbehandelter Fehler aufgetaucht. Anwendung schließt sich nun. {e1.Message} {e1.StackTrace}", "Fehler auf oberster Anwendungsebene", true);
            }
        }        
    }
}
