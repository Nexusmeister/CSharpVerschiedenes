using System;

namespace SOAPTest3
{

    [Obsolete] //Die Klasse wird nicht gebraucht und war nur für Testzwecke aus dem FTPUpload Tool kopiert
    public class FtpUploadDtoTest
    {


        public int VorgangId { get; set; }
        public string FtpServer { get; set; }
        public string FtpBezeichnung { get; set; }
        public string Quelle { get; set; }
        public string FtpZielVerzeichnis { get; set; }
        public bool Archivieren { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FtpMode { get; set; }
        public bool FtpModeBinary { get; set; }
        public string FtpDisablePassive { get; set; }
        public bool PassiveFtp { get; set; }
        public int IaErweiterungUnterdruecken { get; set; }
        public string Ziel { get; set; }
        public string FtpPort { get; set; }
        public string FtpArchivVerzeichnis { get; set; }
    }
}