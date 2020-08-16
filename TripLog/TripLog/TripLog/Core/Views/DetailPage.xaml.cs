using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripLog.Core.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace TripLog.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public DetailPage()
        {
            InitializeComponent();
        }

        public DetailPage(TripLogEntry entry) : this()
        {
            InitMap(entry);
            InitEntryInfos(entry);
        }

        private void InitEntryInfos(TripLogEntry entry)
        {
            Title.Text = entry.Title;
            Date.Text = entry.Date.ToShortDateString();
            Rating.Text = $"{entry.Rating} Sterne";
            Notes.Text = entry.Notes;
        }

        private void InitMap(TripLogEntry entry)
        {
            Map.MoveToRegion(MapSpan.FromCenterAndRadius(
                new Position(entry.Latitude, entry.Longitude), Distance.FromKilometers(5)));

            Map.Pins.Add(new Pin
            {
                Type = PinType.Place,
                Label = entry.Title,
                Position = new Position(entry.Latitude, entry.Longitude)
            });
        }
    }
}