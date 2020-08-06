using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using KneipenFinder.Models;
using KneipenFinder.Models.APIAntwort;
using KneipenFinder.Services;
using Newtonsoft.Json;

namespace KneipenFinder.ViewModels
{
    public class NeuesAngebotViewmodel : BaseViewModel, IAngebotErstellen
    {
        private const string BaseUri = "https://api.kneipenfinder.allyourstuff.de/angebot";
        public string Titel { get; set; }
        public string SaleDescription { get; set; }
        public string PlaceId { get; set; }
        public string ErrorString { get; set; }
        public User Benutzer { get; set; }

        public NeuesAngebotViewmodel()
        {
            Title = "Angebot erstellen";
            ErrorString = string.Empty;
        }

        public async Task<bool> AngebotErstellen()
        {
            ErrorString = string.Empty;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                Saledata postAngebot = new Saledata{PlaceId = Benutzer.PlaceId, SaleDescription = SaleDescription};
                var jsonFuerApi = JsonConvert.SerializeObject(postAngebot);

                var result = await client.PostAsync(BaseUri, new StringContent(jsonFuerApi, Encoding.UTF8, "application/json"));
                if (!result.IsSuccessStatusCode)
                {
                    ErrorString = $"Fehler beim Speichern von Angebot {Titel}. Bitte versuchen Sie es erneut.";
                    return false;
                }

                return true;
            }
        }

        public bool PruefeEingabenAufFehler()
        {
            throw new NotImplementedException();
        }
    }
}
