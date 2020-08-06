using System;
using System.IO;
using System.Windows.Forms;

namespace Ergebnisanzeige.Tools
{
    public class Logger
    {
        private static readonly string logPath = Application.LocalUserAppDataPath;
        private static readonly string logName = "\\SKCLog.log";
        private static readonly string fullPath = logPath + logName;
        public string FullLogPath
        {
            get
            {
                return fullPath;
            }
        }
        public Logger()
        {

        }

        public Logger(string error)
        {
            WriteLog(error);
        }

        public static void WriteLog(string strLog)
        {
            LogToFile(strLog, null);
        }

        public static void LogToFile(string logNachricht)
        {
            LogToFile(logNachricht, null);
        }

        public static bool LogToFile(string logNachricht1, string lognachricht2)
        {
            try
            {
                using (StreamWriter logger = File.AppendText(fullPath))
                {
                    LoggeMitTimeStamp(logNachricht1, logger);
                    if (!string.IsNullOrWhiteSpace(lognachricht2))
                    {
                        LoggeOhneTimeStamp(lognachricht2, logger);
                    }
                }
            }
            catch (Exception e1)
            {
                EMail.VersendeMail($"Fehler in Logger aufgetaucht! Schnellstmöglich darum kümmern! \n{e1.Message} \n {e1.StackTrace}", "Fehler in Logger!");
                return false;
            }

            return true;
        }

        public static void LogToFileUndVersendeMail(string logString, string betreff)
        {
            LogToFile(logString);
            EMail.VersendeMail(logString, betreff);       
        }

        private static void LoggeOhneTimeStamp(string logNachricht, StreamWriter logger)
        {
            try
            {
                logger.WriteLine($"{logNachricht}");
            }
            catch (Exception)
            {
            }
        }

        private static void LoggeMitTimeStamp(string logNachricht, TextWriter logger)
        {
            try
            {
                var dt = new DateTime();
                dt = DateTime.Now;
                logger.WriteLine($"[{dt.ToLongDateString()} {dt.ToLongTimeString()}]\t {logNachricht}");
            }
            catch (Exception)
            {
            }
        }

    }
}
