using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ApiTestRaw
{
    class Program
    {
        static string _baseAdress = "https://kmswebapiext.daff.wuerth-industrie.com:443/api/";
        //static string _baseAdress = "http://localhost:45879/api/";

        private static  HttpClient httpClient = new HttpClient();
        private static object locker = new object();

        private static int timeout = 36000;

        static void Main(string[] args)
        {
            httpClient.Timeout = TimeSpan.FromSeconds(timeout);

            var durchlaeufe = 1;

            var custNr = "726795";

            var listeAdressen = new List<string>();
            var listePoc = new List<string>();
            var listeBefuellungsdatum = new List<string>();
            var listeAktiveBehaelter = new List<string>();
            var listeGelieferteBehaelter = new List<string>();

            Stopwatch sw = new Stopwatch();

            List<Task> tasks = new List<Task>();

            sw.Start();
            for (int i = 0; i < durchlaeufe; i++)
            {
                tasks.Add(QueueAdress(custNr, listeAdressen, i));
                tasks.Add(QueuePoc(custNr, listePoc, i));
                tasks.Add(QueueNextFillingDate(custNr, listeBefuellungsdatum, i));
                tasks.Add(QueueActiveBinsForPlants(custNr, listeAktiveBehaelter, i));
                tasks.Add(QueueDeliveredBinInformationBySapCustomerNosAsync(custNr, listeGelieferteBehaelter, i));

                //Task.Delay(TimeSpan.FromSeconds(1));
            }
            
            Task.WaitAll(tasks.ToArray(),TimeSpan.FromMinutes(10));

            sw.Stop();

            //OK
            var adresse = listeAdressen.FirstOrDefault();
            if (adresse == null)
            {
                Console.WriteLine("Adresse fehlgeschlagen");
            }
            else
            {
                Console.WriteLine($"Adresse: {adresse}");

                if (listeAdressen.Any(x => !x.Equals(adresse)))
                {
                    Console.WriteLine("Adressen nicht ok");
                }
                else
                {
                    Console.WriteLine("Adressen ok");
                }
                Console.WriteLine($"Ergebnismenge: {listeAdressen.Count}");

            }

            //OK
            var poc = listePoc.FirstOrDefault();
            if (poc == null)
            {
                Console.WriteLine("Poc fehlgeschlagen");
            }
            else
            {
                Console.WriteLine($"Poc: {poc}");

                if (listePoc.Any(x => !x.Equals(poc)))
                {
                    Console.WriteLine("Poc nicht ok");
                }
                else
                {
                    Console.WriteLine("Poc ok");
                }
                Console.WriteLine($"Ergebnismenge: {listePoc.Count}");
            }

            //OK
            var befuellungsdatum = listeBefuellungsdatum.FirstOrDefault();
            if (befuellungsdatum == null)
            {
                Console.WriteLine("Befuellungsdatum fehlgeschlagen");
            }
            else
            {
                Console.WriteLine($"Befuellungsdatum: {befuellungsdatum}");

                if (listeBefuellungsdatum.Any(x => !x.Equals(befuellungsdatum)))
                {
                    Console.WriteLine("Befuellungsdatum nicht ok");
                }
                else
                {
                    Console.WriteLine("Befuellungsdatum ok");
                }
                Console.WriteLine($"Ergebnismenge: {listeBefuellungsdatum.Count}");
            }

            //OK
            var aktiveBehaelter = listeAktiveBehaelter.FirstOrDefault();
            if (aktiveBehaelter == null)
            {
                Console.WriteLine("AktiveBehaelter fehlgeschlagen");
            }
            else
            {
                Console.WriteLine($"AktiveBehaelter: {aktiveBehaelter}");

                if (listeAktiveBehaelter.Any(x => !x.Equals(aktiveBehaelter)))
                {
                    Console.WriteLine("AktiveBehaelter nicht ok");
                }
                else
                {
                    Console.WriteLine("AktiveBehaelter ok");
                }
                Console.WriteLine($"Ergebnismenge: {listeAktiveBehaelter.Count}");
            }

            //OK
            var gelieferteBehaelter = listeGelieferteBehaelter.FirstOrDefault();
            if (gelieferteBehaelter == null)
            {
                Console.WriteLine("GelieferteBehälter fehlgeschlagen");
            }
            else
            {
                Console.WriteLine($"GelieferteBehälter: {gelieferteBehaelter}");

                if (listeGelieferteBehaelter.Any(x => !x.Equals(gelieferteBehaelter)))
                {
                    Console.WriteLine("GelieferteBehälter nicht ok");
                }
                else
                {
                    Console.WriteLine("GelieferteBehälter ok");
                }
                Console.WriteLine($"Ergebnismenge: {listeGelieferteBehaelter.Count}");
            }

            Console.WriteLine($"{sw.Elapsed.Minutes}:{sw.Elapsed.Seconds}");

            Console.ReadKey();
        }


        private static HttpRequestMessage GetHttpRequestMessage(string uri, HttpMethod httpMethod)
        {
            var msg = new HttpRequestMessage();

            msg.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //msg.Headers.Add("Authorization", "Bearer ");
            msg.Headers.Add("X-User-ID", "");
            msg.Headers.Add("X-Application", "WISPortal");
            msg.Headers.Add("X-Workstation", Environment.MachineName);
            msg.Headers.Add("X-Correlation-ID", new Guid().ToString());
            msg.Headers.Add("X-Timestamp", DateTime.UtcNow.ToString());

            msg.Method = httpMethod;

            msg.RequestUri = new Uri(uri);

            return msg;
        }

        private static async Task QueueAdress(string custNr, List<string> test1, int i)
        {
            var response = await GetAddressBySapCustomerNo(custNr);
            lock (locker)
            {
                test1.Add(response);
                Console.WriteLine($"GetAddressBySapCustomerNo {i}");
            }
        }

        private static async Task<string> GetAddressBySapCustomerNo(string customerNo)
        {
            try
            {
                var msg = GetHttpRequestMessage(_baseAdress + $"Stammdaten/SapKundenadresse/?kundenNr=" + customerNo, HttpMethod.Get);
                HttpResponseMessage response = await httpClient.SendAsync(msg);

                if (!response.IsSuccessStatusCode)
                {
                    return string.Empty;
                }
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static async Task QueuePoc(string custNr, List<string> test1, int i)
        {
            var response = await GetPocWuerth(custNr);
            lock (locker)
            {
                test1.Add(response);
                Console.WriteLine($"GetPocWuerth {i}");
            }
        }

        private static async Task<string> GetPocWuerth(string customerNo)
        {
            try
            {
                var msg = GetHttpRequestMessage(_baseAdress + $"Stammdaten/KmsKundenansprechpartnerWuerth/?kundenNr=" + customerNo, HttpMethod.Get);
                HttpResponseMessage response = await httpClient.SendAsync(msg);

                if (!response.IsSuccessStatusCode)
                {
                    return string.Empty;
                }
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static async Task QueueNextFillingDate(string custNr, List<string> test1, int i)
        {
            var response = await GetNextFillingDate(custNr);
            lock (locker)
            {
                test1.Add(response);
                Console.WriteLine($"GetNextFillingDate {i}");
            }
        }

        private static async Task<string> GetNextFillingDate(string customerNo)
        {
            try
            {
                var msg = GetHttpRequestMessage(_baseAdress + $"Warenausgang/NaechstesBefuellungsdatum/?sapKundenNr=" + customerNo, HttpMethod.Get);
                HttpResponseMessage response = await httpClient.SendAsync(msg);

                if (!response.IsSuccessStatusCode)
                {
                    return string.Empty;
                }
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static async Task QueueActiveBinsForPlants(string custNr, List<string> test1, int i)
        {
            var response = await GetActiveBinsForPlants(custNr);
            lock (locker)
            {
                test1.Add(response);
                Console.WriteLine($"GetActiveBinsForPlants {i}");
            }
        }

        private static async Task<string> GetActiveBinsForPlants(string customerNo)
        {
            try
            {
                    var msg = GetHttpRequestMessage(_baseAdress + $"Stammdaten/AktiveBehaelter/?sapKundenNrs=" + customerNo, HttpMethod.Get);
                HttpResponseMessage response = await httpClient.SendAsync(msg);

                if (!response.IsSuccessStatusCode)
                {
                    return string.Empty;
                }
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static async Task QueueDeliveredBinInformationBySapCustomerNosAsync(string custNr, List<string> test1, int i)
        {
            var response = await GetDeliveredBinInformationBySapCustomerNosAsync(custNr);
            lock (locker)
            {
                test1.Add(response);
                Console.WriteLine($"GetDeliveredBinInformationBySapCustomerNosAsync {i}");
            }
        }

        private static async Task<string> GetDeliveredBinInformationBySapCustomerNosAsync(string customerNo)
        {
            try
            {
                var msg = GetHttpRequestMessage(_baseAdress + $"Berichtswesen/BehaelterGeliefertMonatsebene/?sapKundenNrs=" + customerNo, HttpMethod.Get);
                var response = await httpClient.SendAsync(msg);
                if (!response.IsSuccessStatusCode)
                {
                    return string.Empty;
                }
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
