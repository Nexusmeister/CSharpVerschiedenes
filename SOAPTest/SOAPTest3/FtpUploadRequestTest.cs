using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOAPTest3
{
    [Obsolete] //Die Klasse wird nicht gebraucht und war nur für Testzwecke aus dem FTPUpload Tool kopiert
    class FtpUploadRequestTest : AufgabeTest
    {
        //        private readonly FtpUploadDtoTest _dtoTest;
        //        private static object _lockVariableDb;
        //        private static object _lockVariableFile;

        //        public FtpUploadRequestTest(FtpUploadDtoTest dtoTest)
        //        {
        //            _dtoTest = dtoTest;

        //            if (_lockVariableDb == null)
        //            {
        //                _lockVariableDb = new object();
        //            }
        //            if (_lockVariableFile == null)
        //            {
        //                _lockVariableFile = new object();
        //            }
        //        }

        //        public override void Abarbeiten()
        //        {
        //            #region Protokollierung
        //            lock (_lockVariableFile)
        //            {
        //                Logger.LogToFile($"{_dtoTest.VorgangId} ######## PARAMETER - FTPBezeichnung: {_dtoTest.FtpBezeichnung} FTPServer: {_dtoTest.FtpServer} FTPUser: {_dtoTest.Username} " +
        //                                 $"FTPZielVerzeichnis: {_dtoTest.FtpZielVerzeichnis} FTPMode: {_dtoTest.FtpMode} FTPDisablePassive: {_dtoTest.FtpDisablePassive} " +
        //                                 $"iaErweiterungUnterdrucken: {_dtoTest.IaErweiterungUnterdruecken} FTPPort: {_dtoTest.FtpPort} FTPArchivVerzeichnis: {_dtoTest.FtpZielVerzeichnis}");
        //            }

        //            #endregion Protokollierung

        //            #region Übertragung
        //            try
        //            {
        //                var request = (FtpWebRequest)WebRequest.Create(_dtoTest.Ziel);
        //                request.Method = WebRequestMethods.Ftp.UploadFile;
        //                request.Credentials = new NetworkCredential(_dtoTest.Username, _dtoTest.Password);
        //                request.UsePassive = _dtoTest.PassiveFtp;
        //                request.UseBinary = _dtoTest.FtpModeBinary;
        //                request.KeepAlive = false;
        //                request.Proxy = null;
        //                request.Timeout = 120000;

        //                byte[] buffer;
        //                using (var stream = File.OpenRead(_dtoTest.Quelle))
        //                {
        //                    buffer = new byte[stream.Length];
        //                    stream.Read(buffer, 0, buffer.Length);
        //                    stream.Close();
        //                }

        //                using (var reqStream = request.GetRequestStream())
        //                {
        //                    reqStream.Write(buffer, 0, buffer.Length);
        //                    reqStream.Close();
        //                }

        //                string sqlUpdate = "update Ftpausgang set versendet = 1, datumversendet=getdate() where id = @id";
        //                using (var cmdUpdate = new SqlCommand(sqlUpdate, DB.DBCon))
        //                {
        //                    cmdUpdate.Parameters.AddWithValue("@id", _dtoTest.VorgangId, SqlDbType.Int);
        //                    DB.ExecuteCMD(cmdUpdate);
        //                }

        //                #region .ia wieder entfernen
        //                if (_dtoTest.IaErweiterungUnterdruecken != 1)
        //                {
        //                    try
        //                    {
        //                        var renameRequest = (FtpWebRequest)WebRequest.Create(_dtoTest.Ziel);
        //                        renameRequest.UseBinary = _dtoTest.FtpModeBinary;
        //                        renameRequest.UsePassive = _dtoTest.PassiveFtp;
        //                        renameRequest.Credentials = new NetworkCredential(_dtoTest.Username, _dtoTest.Password);
        //                        renameRequest.KeepAlive = true;
        //                        renameRequest.Method = WebRequestMethods.Ftp.Rename;
        //                        renameRequest.Proxy = null;
        //                        renameRequest.RenameTo = Path.GetFileName(_dtoTest.Quelle);
        //                        renameRequest.GetResponse();
        //                    }
        //                    catch (Exception e1)
        //                    {
        //                        lock (_lockVariableFile)
        //                        {
        //                            Logger.LogToFile($"{_dtoTest.VorgangId} Fehler beim Umbenennen: " + e1);
        //                        }
        //                        lock (_lockVariableDb)
        //                        {
        //                            Email.senden("Verteiler-Industrie-KMS-GRUPPE2@wuerth-industrie.com", $"[FTP Upload] Fehler beim Umbenennen, ID:{_dtoTest.VorgangId}", e1.Message);
        //                        }
        //                    }
        //                }
        //                #endregion

        //                lock (_lockVariableFile)
        //                {
        //                    Logger.LogToFile($"{_dtoTest.VorgangId} Übertragung erfolgreich: {_dtoTest.Quelle} ==> {_dtoTest.Ziel}");
        //                }

        //                if (_dtoTest.Archivieren)
        //                {
        //                    FileSystem.archiveFile(_dtoTest.Quelle, _dtoTest.FtpBezeichnung);

        //                    lock (_lockVariableFile)
        //                    {
        //                        Logger.LogToFile($"{_dtoTest.VorgangId} archivierung erfolgreich: " + _dtoTest.Quelle);
        //                    }
        //                }
        //            }
        //            catch (Exception e1)
        //            {
        //                MessageBox.Show(e1.ToString());
        //            }
        //            #endregion Übertragung
    }
}

