using System.Threading.Tasks;
using Xamarin.Essentials;

namespace KneipenFinder.Models
{
    public class UserPosition
    {
        public double Altitude { get; set; }
        public double Longitude { get; set; }
        public double Latidude { get; set; }

        //für aufruf lat, long, distance -> Params-Reihenfolge
        public UserPosition(double altitude, double longitude, double latidude)
        {
            Altitude = altitude;
            Longitude = longitude;
            Latidude = latidude;
        }

        public UserPosition(double longitude, double latidude) : this(0.0, longitude, latidude)
        {
        }

        public static async Task<UserPosition> GetUserPosition()
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Default);
            var location = await Geolocation.GetLocationAsync(request);

            return location != null ? new UserPosition(location.Longitude, location.Latitude) : null;
        }
    }
}
