using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TripLog.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewEntryPage : ContentPage
    {
        public NewEntryPage()
        {
            InitializeComponent();
        }

        private async void Speichern_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(true);
        }
    }
}