using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BilderAbrufen
{
    class Program
    {
        private static readonly HttpClientHandler Handler = new HttpClientHandler
        {
            Credentials = new NetworkCredential("ASSET_WIS", "ASSET_WIS")
        };
        private static readonly HttpClient Client = new HttpClient(Handler);

        static async Task Main(string[] args)
        {
            var response = await Client.GetAsync("https://step-test.wgn.wuerth.com/restapi/products/PR01_005510_20?context=1543_de");

            string antwort = string.Empty;

            if (response.IsSuccessStatusCode)
            {
                antwort = await response.Content.ReadAsStringAsync();
            }

            //await File.WriteAllTextAsync($@"{Environment.CurrentDirectory}data.xml", antwort);

            Console.WriteLine(antwort);

            Console.WriteLine("Ende");

            XmlSerializer serializer = new XmlSerializer(typeof(TestXML.Product));
            MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(antwort));
            TestXML.Product resultingMessage = (TestXML.Product)serializer.Deserialize(memStream);

            Console.ReadKey();

            //
            //So machst du aus dem Abgerufenen XML Klassen, damit die die zukünftig verwenden kannst
            //

            //
            //https://stackoverflow.com/questions/19612215/how-to-convert-xml-json-file-to-c-sharp-class
            //


            

        }
    }
}
