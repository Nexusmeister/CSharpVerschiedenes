using Ergebnisanzeige.Tools;
using System;
using System.IO;
using System.Reflection;
using System.Windows;

namespace Ergebnisanzeige20
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                Logger.LogToFile("Anwendung gestartet.");
                Logger.LogToFile($"Anwendung initalisiert unter: {Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}");          
            }
            catch (Exception e1)
            {
                //SKCMessages.ShowError($"Unbehandelter Fehler in Anwendung aufgetaucht!!! Schnellstmöglich Robin kontaktieren. {e1.Message}");
                //Logger.LogToFile($"Fehler auf oberster Anwendungsebene! Unbehandelter Fehler aufgetaucht. Anwendung schließt sich nun. {e1.Message} {e1.StackTrace}");
                //EMail.VersendeMailMitLog($"Fehler auf oberster Anwendungsebene! Unbehandelter Fehler aufgetaucht. Anwendung schließt sich nun. {e1.Message} {e1.StackTrace}", "Fehler auf oberster Anwendungsebene", true);
            }
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                Logger.LogToFile("Anwendung gestartet.");
                Logger.LogToFile($"Anwendung initalisiert unter: {Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}");

                var app = new App();
                app.InitializeComponent();
                app.Run();
                //Logger.LogToFile("Anwendung beendet.", "------------------------------------------------------------");

                if (!Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Contains(@"bin\Debug"))
                {
                    //EMail.VersendeMailMitLog("Anwendung wurde geschlossen.", "Anwendung beendet.");
                }
            }
            catch (Exception e1)
            {
                //SKCMessages.ShowError($"Unbehandelter Fehler in Anwendung aufgetaucht!!! Schnellstmöglich Robin kontaktieren. {e1.Message}");
                //Logger.LogToFile($"Fehler auf oberster Anwendungsebene! Unbehandelter Fehler aufgetaucht. Anwendung schließt sich nun. {e1.Message} {e1.StackTrace}");
                //EMail.VersendeMailMitLog($"Fehler auf oberster Anwendungsebene! Unbehandelter Fehler aufgetaucht. Anwendung schließt sich nun. {e1.Message} {e1.StackTrace}", "Fehler auf oberster Anwendungsebene", true);
            }
        }
    }
}
