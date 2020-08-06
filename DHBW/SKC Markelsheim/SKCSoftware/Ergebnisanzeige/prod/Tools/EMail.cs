using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Reflection;
using System.Windows.Forms;

namespace Ergebnisanzeige.Tools
{
    public class EMail
    {
        private static string _standardEmpfaenger = "robin @cskaltenbach.de";
        public EMail()
        {

        }

        public static void VersendeMailMitLog(string content, string betreff, bool zeigePopup = false)
        {
            if (zeigePopup)
            {
                new EMail().VersendeMail(content, betreff, null, true, _standardEmpfaenger ,true);
            }
            else
            {
                new EMail().VersendeMail(content, betreff, null, true, _standardEmpfaenger);
            }
            
        }

        public static void VersendeMailMitSpielbericht(string dateiname, string empfaenger)
        {
            new EMail().VersendeMail("Automatisch erzeugt und versendet.", $"Spielbericht vom {DateTime.Today.ToShortDateString()}", "", false, empfaenger, false, dateiname);
        }

        public static void VersendeMailMitMehrerenEmpfaengern(string content, string betreff, IEnumerable<string> empfaenger, string dateiname)
        {
            foreach(var empf in empfaenger)
            {
                VersendeMailMitSpielbericht(dateiname, empf);
            }
        }

        public static void VersendeMail(string content)
        {
            new EMail().VersendeMail(content, null, null, false, _standardEmpfaenger);
        }

        public static void VersendeMail(string content, string betreff)
        {
            new EMail().VersendeMail(content, betreff , null, false, _standardEmpfaenger);
        }

        private void VersendeMail(string content, string betreff, string cc, bool versendeLog, string empfaenger, bool zeigePopup = false, string dateiname = "")
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("skcmarkelsheimsoftware@gmail.com");
                mail.To.Add(empfaenger);
                if(!string.IsNullOrWhiteSpace(cc))
                {
                    mail.CC.Add(cc);
                }
                else
                {
                    mail.CC.Add("skcmarkelsheimsoftware@gmail.com");
                }
                
                if(!string.IsNullOrWhiteSpace(betreff))
                {
                    mail.Subject = betreff;
                }
                else
                {
                    mail.Subject = "Fehler in Anwendung";
                }

                if (!string.IsNullOrWhiteSpace(dateiname))
                {                   
                    FileInfo info = new FileInfo(dateiname);
                    if (new ExcelExport().IstDateiBlockiert(info))
                    {
                       var stream = File.Open(dateiname, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);                   
                       mail.Attachments.Add(new Attachment(stream, stream.Name.Remove(0,3)));                       
                    }
                    else
                    {
                        mail.Attachments.Add(new Attachment(dateiname));
                    }
                }
                
                mail.Body = content;

                SmtpServer.Port = 587;
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.Credentials = new System.Net.NetworkCredential("skcmarkelsheimsoftware@gmail.com", "skcmarkelsheim2019");
                SmtpServer.EnableSsl = true;

                if (versendeLog)
                {
                    string logPfad = Path.GetDirectoryName(Application.LocalUserAppDataPath) + "\\";
                    logPfad += Application.ProductVersion;
                    logPfad += "\\SKCLog.log";
                    mail.Attachments.Add(new Attachment(logPfad));
                }

                SmtpServer.Send(mail);
                if (zeigePopup)
                {
                    SKCMessages.ShowInfo("Mail versendet!", "Mail versendet");
                }              
            }
            catch (Exception e1)
            {
                SKCMessages.ShowError($"Fehler beim Versenden einer EMail. {e1.Message}");
                Logger.LogToFile($"Fehler beim eMail versenden in VersendeMail: {e1.Message} {e1.StackTrace}");
            }
        }
    }
}
