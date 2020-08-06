using System;
using System.IO;
using System.Linq;
using System.Net.Mail;

namespace SKCDLL.Tools
{
    public class EMail
    {
        private static string _standardEmpfaenger = "robin @cskaltenbach.de";
        private static readonly string _ergebnisanzeigeAbsender = "skcmarkelsheimsoftware@gmail.com";

        public EMail()
        {

        }

        public static bool VersendeMailMitLog(string content, string betreff)
        {
            var ergebnis = VersendeMail(content, betreff, "", _standardEmpfaenger, Logger.LogPath);
            return ergebnis;
        }

        public static void VersendeMailMitSpielbericht(string dateiname, string empfaenger)
        {
            VersendeMail("Automatisch erzeugt und versendet.", $"Spielbericht vom {DateTime.Today.ToShortDateString()}", "", empfaenger, dateiname);
        }

        public static bool VersendeMail(string content, string betreff, string cc)
        {
            return VersendeMail(content, betreff, cc, _standardEmpfaenger);
        }

        public static bool VersendeMail(string content, string betreff, string cc, string empfaenger, string dateiname = null)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(_standardEmpfaenger);
                MailMessage msg = new MailMessage();
                SmtpClient client = new SmtpClient("smtp.gmail.com");

                if (!string.IsNullOrWhiteSpace(empfaenger) || empfaenger.Contains(","))
                {
                    char[] splitter = { ',' };
                    var multiEmpfaenger = empfaenger.Split(splitter, StringSplitOptions.RemoveEmptyEntries).ToList();
                    foreach (var adresse in multiEmpfaenger)
                    {
                        msg.To.Add(adresse);
                    }
                }

                msg.From = new MailAddress(_ergebnisanzeigeAbsender, "SKC Markelsheim Ergebnisanzeige");

                if (!string.IsNullOrWhiteSpace(cc))
                {
                    msg.CC.Add(new MailAddress(cc));
                }
                else
                {
                    msg.CC.Add(new MailAddress(_ergebnisanzeigeAbsender));
                }

                if (!string.IsNullOrWhiteSpace(betreff))
                {
                    msg.Subject = betreff;
                }
                else
                {
                    msg.Subject = "Automatisch erzeugt und versendet.";
                }

                if (!string.IsNullOrWhiteSpace(dateiname))
                {
                    FileInfo file = new FileInfo(dateiname);

                    var stream = File.Open(dateiname, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);                 
                    msg.Attachments.Add(new Attachment(stream, stream.Name.Remove(0, 3)));
                }

                msg.Body = content;
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new System.Net.NetworkCredential("skcmarkelsheimsoftware@gmail.com", "skcmarkelsheim2019");
                client.EnableSsl = true;

                Logger.LogToFile($"Mail wird versendet.");
                client.Send(msg);

            }
            catch (Exception e1)
            {
                Logger.LogToFile($"Fehler beim Mail versenden aufgetaucht! {e1}");
            }
            return true;
        }
    }
}
