using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using KneipenFinder.Models;
using KneipenFinder.Models.APIAntwort;
using KneipenFinder.Services;
using Newtonsoft.Json;
using Xamarin.Forms;
using Location = Android.Locations.Location;

namespace KneipenFinder.ViewModels
{
    public class KneipenFinderViewmodel : BaseViewModel, IKneipenFinder
    {
        private const string BaseUri = "https://api.kneipenfinder.allyourstuff.de/getKneipen";
        private readonly List<string> _listeKategorien = new List<string>();
        private bool _isFailedLabelVisible;
        private bool _isRefreshing = false;
        private ObservableCollection<Kneipe> _kneipen;
        private UserPosition _userposition;
        //https://www.codeproject.com/Tips/876349/WPF-Validation-using-INotifyDataErrorInfo 
        //https://docs.microsoft.com/de-de/dotnet/api/system.componentmodel.inotifydataerrorinfo?view=netframework-4.8 
        //https://rehansaeed.com/model-view-viewmodel-mvvm-part4-inotifydataerrorinfo/ 

        public bool IsFailedLabelVisible
        {
            get => _isFailedLabelVisible;
            set
            {
                _isFailedLabelVisible = value;
                OnPropertyChanged(nameof(IsFailedLabelVisible));
            }
        }

        public ObservableCollection<Kneipe> Kneipen
        {
            get => _kneipen;
            set
            {
                _kneipen = value;
                OnPropertyChanged(nameof(Kneipen));
            }
        }

        public ObservableCollection<Saledata> Angebote { get; set; }

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;
                    //Kneipen.Add(new Kneipe("ARA", "Leichtenstraße", "Markelsheim", 97980, 5.2));
                    //await Task.Delay(5000);

                    UserPos = await UserPosition.GetUserPosition();
                    var ergebnis = await GetKneipen(UserPos, SettingsViewmodel.GetStandardRadius());
                    if (ergebnis != null)
                    {
                        Kneipen = new ObservableCollection<Kneipe>(ergebnis);
                    }

                    IsRefreshing = false;
                });
            }
        }

        public UserPosition UserPos
        {
            get => _userposition;
            set
            {
                _userposition = value;
                OnPropertyChanged(nameof(UserPos));
            }
        }

        public KneipenFinderViewmodel()
        {
            Title = "KneipenFinder";
            Angebote = new ObservableCollection<Saledata>();
            
            //Kneipe k1 = new Kneipe("Ludwig", "Beispielstraße", "Mosbach", 984561, 1.2);
            //Kneipe k2 = new Kneipe("Brauhaus", "Beispielweg", "Mosbach", 984561, 0.4);
            //Kneipe k3 = new Kneipe("Test", "goldbachstraße", "Igersheim", 97999, 2.8);

            //var kneipen = new ObservableCollection<Kneipe>
            //{
            //    k1,
            //    k2,
            //    k3
            //};

            //Kneipen = kneipen;
            Kneipen = new ObservableCollection<Kneipe>();
            RefreshCommand.Execute(null);
        }

        public async Task<IEnumerable<Kneipe>> GetKneipen(UserPosition position, double radiusInMeter)
        {
            try
            {
                UserPos = await UserPosition.GetUserPosition();
                IsFailedLabelVisible = false;

                UriBuilder builder = new UriBuilder(BaseUri);
                if (radiusInMeter < 0)
                {
                    throw new ArgumentException("Der Radius darf nicht kleiner 0 sein bzw. muss angegeben werden!");
                }

                var latErsetzt = position.Latidude.ToString(CultureInfo.InvariantCulture).Replace(',', '.');
                var longErsetzt = position.Longitude.ToString(CultureInfo.InvariantCulture).Replace(',', '.');
                builder.Query = $"latitude={latErsetzt}&longitude={longErsetzt}&distance={radiusInMeter}";

                HttpClient client = new HttpClient
                {
                    BaseAddress = builder.Uri,
                    Timeout = new TimeSpan(0, 0, 5)
                };

                var response = await client.GetAsync(builder.Uri);

                if (!response.IsSuccessStatusCode)
                {
                    IsFailedLabelVisible = true;

                    return null;
                }
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    IsFailedLabelVisible = true;
                    Kneipen.Clear();
                    List<Kneipe> kTemp = new List<Kneipe> {new Kneipe("Keine Kneipen gefunden!", "", "", 0, 0.0)};
                    return new ObservableCollection<Kneipe>(kTemp);
                }

                if (response.StatusCode == HttpStatusCode.ServiceUnavailable || response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    Kneipen.Clear();
                    List<Kneipe> kTemp = new List<Kneipe>();
                    kTemp.Add(new Kneipe("Server momentan nicht verfügbar!", "", "", 0, 0.0));
                    return new ObservableCollection<Kneipe>(kTemp);
                }

                var text = await response.Content.ReadAsStringAsync();
                var kneipen = JsonConvert.DeserializeObject<Rootobject>(text);
                var listeRawKneipen = kneipen.RequestResult.ToList();

                // STILL THE PROBLEM 
                //var t = listeRawKneipen.FindAll(x => x.Category_List.Where(y => y.Name.Equals(kategorie, StringComparison.OrdinalIgnoreCase)));

                var listeErzeugteKneipen = await ErzeugeKneipen(listeRawKneipen);
                var listePreparedKneipen = new ObservableCollection<Kneipe>(listeErzeugteKneipen);

                //Duplikatetester
                //var c = listePreparedKneipen.Count(x => x.Name.Equals("Amthaisong Thai Restaurant"));

                Kneipen.Clear();
                Kneipen = listePreparedKneipen;

                return listeErzeugteKneipen;
            }
            catch (Exception e)
            {
                var kTemp = new Kneipe("Laden der Kneipen fehlgeschlagen", "", "", 0, 0);
                var kListe = new List<Kneipe> {kTemp};
                return new ObservableCollection<Kneipe>(kListe);
            }
        }

        private async Task<List<Kneipe>> ErzeugeKneipen(List<Requestresult> listeRawKneipen)
        {
            List<Kneipe> listeKneipen = new List<Kneipe>();
            UserPos = await UserPosition.GetUserPosition();

            foreach (var requestResult in listeRawKneipen)
            {
                int.TryParse(requestResult.Location.Zip, out int plz);

                var entfernungUserKneipe = BerechneEntfernungZwischenZweiPunkten(requestResult.Location.Latitude,
                    requestResult.Location.Longitude,
                    UserPos.Latidude, UserPos.Longitude);

                string strasse;
                if (string.IsNullOrWhiteSpace(requestResult.Location.Street))
                {
                    strasse = "Straße unbekannt";
                }
                else
                {
                    strasse = requestResult.Location.Street;
                }

                Kneipe kneipenBuffer;
                if (requestResult.SaleData?.Length > 0)
                {
                    kneipenBuffer = new Kneipe(requestResult.Name, strasse, requestResult.Location.City, plz, entfernungUserKneipe, requestResult.SaleData, requestResult.Id);

                }
                else
                {
                    List<Saledata> keinAngebot = new List<Saledata>();
                    keinAngebot.Add(new Saledata{PlaceId = requestResult.Id, SaleDescription = "Keine Angebote gefunden."});
                    kneipenBuffer = new Kneipe(requestResult.Name, strasse, requestResult.Location.City, plz, entfernungUserKneipe, keinAngebot.ToArray(), requestResult.Id);
                }

                listeKneipen.Add(kneipenBuffer);
            }

            return listeKneipen;
        }

        private static double BerechneEntfernungZwischenZweiPunkten(float kneipenLatitude, float kneipenLongitude, double userLatitude, double userLongitude)
        {
            var kCoord = new Location("kneipenLocation")
            {
                Latitude = kneipenLatitude,
                Longitude = kneipenLongitude
            };

            var uCoord = new Location("userLocation")
            {
                Longitude = userLongitude,
                Latitude = userLatitude
            };

            return kCoord.DistanceTo(uCoord) / 1000;
        }
    }
}
