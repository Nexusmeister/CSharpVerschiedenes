using System;
using System.IO;

namespace SKCDLL.Tools
{
    public class Logger
    {
        public static string LogPath;

        public static void LogToFile(string logMessage)
        {
            try
            {
                using (StreamWriter logger = File.AppendText(LogPath))
                {
                    var dt = new DateTime();
                    dt = DateTime.Now;
                    logger.WriteLine($"[{dt.ToLongDateString()} {dt.ToLongTimeString()}]\t {logMessage}");
                }
            }
            catch (Exception e1)
            {
                EMail.VersendeMail($"Fehler in Logger aufgetaucht! Schnellstmöglich darum kümmern! \n{e1.Message} \n {e1.StackTrace}", "Fehler in Logger!", "");
            }
        }
    }
}
