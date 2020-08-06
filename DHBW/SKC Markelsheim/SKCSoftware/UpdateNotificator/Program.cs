using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Mail;

namespace UpdateNotificator
{
    public class Program
    {
        private static string basePfad = @"F:\OneDrive\Kegeln\SKC Admin\Ergebnisanzeige\";
        static void Main(string[] args)
        {
            try
            {
                //Logger.LogToFile("UpdateNotificator gestartet.");
                DirectoryInfo directoryInfo = new DirectoryInfo(basePfad);
                var listeDir = directoryInfo.GetDirectories().ToList().Where(x => !x.Name.Equals("Archiv", StringComparison.OrdinalIgnoreCase));
                var neuesterOrdner = listeDir.OrderByDescending(x => x.LastWriteTime).FirstOrDefault();
                var archivpfad = $@"{basePfad}Archiv\{neuesterOrdner.Name}.zip";
                if (new FileInfo(archivpfad).Exists)
                {
                    VersendeMail("Automatisch erzeugt und versendet.", "Neue Version verfügbar!", "skcmarkelsheimsoftware@gmail.com", "robin@cskaltenbach.de", archivpfad);
                }
                else
                {
                    ZipFile.CreateFromDirectory(neuesterOrdner.FullName, archivpfad, CompressionLevel.Optimal, false);
                    
                    //EMail.VersendeMailMitSpielbericht(archivpfad, "robin@cskaltenbach.de");
                }
            }
            catch (Exception e1)
            {
                VersendeMail($"Fehler in UpdateNotificator aufgetaucht! {e1}", "Fehler in UpdateNotificator aufgetaucht!", string.Empty, "robin@cskaltenbach.de");
            }
        }

        private static void VersendeMail(string content, string betreff, string cc, string empfaenger, string dateiname = "")
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("skcmarkelsheimsoftware@gmail.com");
                mail.To.Add(empfaenger);
                if (!string.IsNullOrWhiteSpace(cc))
                {
                    mail.CC.Add(cc);
                }
                else
                {
                    mail.CC.Add("skcmarkelsheimsoftware@gmail.com");
                }

                if (!string.IsNullOrWhiteSpace(betreff))
                {
                    mail.Subject = betreff;
                }
                else
                {
                    mail.Subject = "Fehler in Anwendung";
                }

                if (!string.IsNullOrWhiteSpace(dateiname))
                {
                    //FileInfo info = new FileInfo(dateiname);
                    //if (new ExcelExportOld().IstDateiBlockiert(info))
                    //{
                    //    var stream = File.Open(dateiname, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    //    mail.Attachments.Add(new Attachment(stream, stream.Name.Remove(0, 3)));
                    //}
                    //else
                    //{
                    //    mail.Attachments.Add(new Attachment(dateiname));
                    //}
                }

                mail.Body = content;
                
                SmtpServer.Port = 587;
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.Credentials = new System.Net.NetworkCredential("skcmarkelsheimsoftware@gmail.com", "skcmarkelsheim2019");
                SmtpServer.EnableSsl = true;
                

                SmtpServer.Send(mail);
            }
            catch (Exception)
            {

            }
        }
    }
}
