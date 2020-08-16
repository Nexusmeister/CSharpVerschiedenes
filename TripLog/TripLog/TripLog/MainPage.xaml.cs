using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripLog.Core.Models;
using TripLog.Core.Views;
using Xamarin.Forms;

namespace TripLog
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var items = new List<TripLogEntry>
            {
                new TripLogEntry
                {
                    Date = new DateTime(2020, 2, 23),
                    Title = "Washington Monument",
                    Notes = "Amazing!",
                    Latitude = 38.8895,
                    Longitude = -77.0352,
                    Rating = 3
                },
                new TripLogEntry
                {
                    Date = new DateTime(2019, 5, 12),
                    Title = "Statue of Liberty",
                    Notes = "Inspiring!",
                    Latitude = 40.6892,
                    Longitude = -74.0444,
                    Rating = 4
                },
                new TripLogEntry
                {
                    Date = new DateTime(2019, 4, 26),
                    Title = "Golden Gate Bridge",
                    Notes = "Foggy, but beautiful!",
                    Latitude = 37.8268,
                    Longitude = -122.4798,
                    Rating = 5
                }
            };

            Trips.ItemsSource = items;
        }

        private async void NewItem_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewEntryPage());
        }

        private async void Trips_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var trip = (TripLogEntry) e.CurrentSelection.FirstOrDefault();
            if (trip != null)
            {
                await Navigation.PushAsync(new DetailPage(trip));
            }

            Trips.SelectedItem = null;
        }
    }
}
