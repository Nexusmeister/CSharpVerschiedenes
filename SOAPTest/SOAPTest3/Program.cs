using SOAPTest3.SeeburgerService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web.Services;
using System.Web.Services.Description;

namespace SOAPTest3
{
    class Program
    {
        private static bool success;
        static void Main()
        {

            try
            {
                //var doSomething = new Funktion();
                //success = doSomething.CallWebService();

                //if (Convert.ToBoolean(success))
                //{
                //    Console.WriteLine("Success");
                //}
                //else
                //{
                //    throw new Exception();
                //}
                ExecuteFtpRequestTesting();

                var success = UploadFileToFtp();

                if (success)
                {
                    // Be happy
                }
                else
                {
                    // Be sad
                    throw new Exception("Upload nicht erfolgreich");
                }

            }
            catch (Exception e1)
            {
                Console.WriteLine($"Fehler in der Anwendung: \n {e1.Message}");
            }

            Console.ReadKey();

        }

        #region Test 1
        /// <summary>
        /// Der erste Versuch eines FTP WebService Aufrufs
        /// </summary>
        /// <returns></returns>
        [Obsolete] //Test 3 ist die richtige Herangehensweise
        private static async Task DieAllmaechtigeFtpMethode()
        {
            /* Anlage eines FTP Dummys
             * Die richtigen Daten für den FTP Server:
             *      Kommunikation per SFTP
             *      Password = "ZwEh9g8B",
             *      Path = "/PFAD EINGEBEN",
             *      Port = 22,
             *      Type = ftpModeType.PASSIVE,
             *      URL =  "wendell-test.wuerth.com",
             *      User = "step-ws"
             *      
             */
            FtpParamsType ftpTest = new FtpParamsType
            {
                Password = "Test",
                Path = "/Test",
                Port = 22,
                Type = ftpModeType.PASSIVE,
                URL = "Test.de",
                User = "DerTester"
            };


            var files = new List<string>();
            var item = "Teste Den Spatz";

            // Request an den FTP Server, um Daten, die in einem Array stecken, zu schicken
            var request = new WebServiceToFtpRequest(files.ToArray(), ftpTest);

            MailParamsType mailTest = new MailParamsType();
            var client = new MFTWebServiceMFTPortTypeClient(" ", " ");
            //var response = await client.WebServiceToFtpAsync(request);



            SoapTest soapTestObjekt = new SoapTest();

            var buffer = soapTestObjekt.SessionId;
        }

        #endregion

        /*
         * ####################################################################################################################################################################################
         */

        #region Test 2
        [WebMethod]
        private static void ExecuteFtpRequestTesting()
        {
            //TestServer Objekt, für den WebService
            FtpParamsType ftpServer = new FtpParamsType
            {
                Password = "9OcKq2P7",
                Path = "",
                Port = 21,
                Type = ftpModeType.PASSIVE,
                URL =  "wendell.wuerth.com",
                User = "rK88bUVZ"
            };

            //Dateien, die an den FTP Server geschickt werden sollen, müssen übergeben werden
            //TODO Wie bekomme ich eine Datei in die Liste?

            //var ws12 = SeeburgerService.WebServiceToFtpRequest("")
            
            List<string> fileListe = new List<string>();

            fileListe.Add(@"Test.txt");

            using (var leser = new StreamReader("D:\\Development\\SOAP\\Test.txt"))
            {
                string text = leser.ReadLine();
                fileListe.Add(text);
            }

            //var http = new FtpWebRequest();

            List<string> readFile = File.ReadAllLines(@"D:\Development\\SOAP\Test.txt").ToList();

            //WebService Request Objekt -> DateiListe wird in Array gepackt und bekommt sein Ziel angesagt
            //var requestToFtp = new WebServiceToFtpRequest(fileListe.ToArray(), ftpServer);


            //var test = new EndpointAddress("", EndpointIdentity.CreateDnsIdentity())
            var testFiles = fileListe.ToArray();
            //Client
            var client = new MFTWebServiceMFTPortTypeClient("wendell-test.wuerth.com", "http://wendell-test.wuerth.com/ws/MFT-WebServiceMFTPort?ls=200");
            WebServiceToFtpRequest ws = new WebServiceToFtpRequest();

            client.WebServiceToFtp(ref testFiles, ftpServer, out var test);

            //Ende: Auf antwort warten...
            //client.WebServiceToFtp(fileListe.ToArray(), ftpServer);

            //EndpointIdentity ident = new 

            //client.
        }
        #endregion

        /* ##########################################################################################################
         * # Ich denke mal von der Struktur her, sind die Methoden unterhalb relativ gut modularisiert.             #
         * # Da kann man bestimmt etwas basteln.                                                                    #
         * # Kritischste Frage bleibt: Wie können wir dem Server sagen, dass wir berechtigt sind...?                #
         * ##########################################################################################################
         */

        #region Test 3 Modularisiert
        /// <summary>
        /// Generiere eine Files-Liste, die gegen den Server geworfen wird
        /// </summary>
        /// <returns></returns>
        private static List<string> PrepareFileForUpload()
        {
            List<string> file = new List<string>();
            file.Add("Test.txt");
            return file;
        }

        /// <summary>
        /// Die zentrale Upload Methode, die alles aufruft, um theoretisch eine WebService-FTP-Transaktion aufzurufen
        /// </summary>
        /// <returns></returns>
        static bool UploadFileToFtp()
        {
            var server = ErzeugeServer();
            var file = PrepareFileForUpload();
            var client = CreateClientFtp();
            var request = RequestToFtp(file, server);

            return success;
        }

        // Dieser Client muss irgendwie gefüllt werden
        private static MFTWebServiceMFTPortTypeClient CreateClientFtp()
        {
            SoapBinding soapBinding = new SoapBinding();
            BasicHttpBinding httpbinding = new BasicHttpBinding("SoapBinding");
            Binding binding = new Binding();
            //Dieses Klasse bzw. der Konstruktor übernimmt auch ein Objekt vom Typ Binding -> erkennt es aber nicht an.
            var client = new MFTWebServiceMFTPortTypeClient();
            return client;
        }

        // ########## SERVER OBJEKT ##########
        /// <summary>
        /// Server-Objekt, das die benötigten Credentials besitzt
        /// </summary>
        /// <returns></returns>
        private static FtpParamsType ErzeugeServer()
        {
            //TestServer Objekt, für den WebService
            FtpParamsType ftpServer = new FtpParamsType
            {
                Password = "9OcKq2P7",
                Path = "",
                Port = 22,
                Type = ftpModeType.PASSIVE,
                URL = "wendell.wuerth.com",
                User = "rK88bUVZ"
            };

            return ftpServer;
        }

        /// <summary>
        /// Erzeuge ein Request-Objekt, um ein WS aufzurufen
        /// </summary>
        /// <param name="file"></param>
        /// <param name="server"></param>
        /// <returns></returns>
        private static WebServiceToFtpRequest RequestToFtp(List<string> file, FtpParamsType server)
        {
            //Hier wird ein neues Objekt erzeugt, das die Daten hat, um einen WebService theoretisch aufzurufen
            //Der Server und die Files
            return new WebServiceToFtpRequest(file.ToArray(), server);

        }

        #endregion
    }
}
