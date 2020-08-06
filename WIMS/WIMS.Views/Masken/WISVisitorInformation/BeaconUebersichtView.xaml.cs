using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIMS.Tools;
using WIMS.Viewmodels.Module.Beacons;
using WIS.WebAPI.DTOs.WisVisitorInformation;
using WIS.WebAPIExt.ClientDataAccess;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WIMS.Views.Masken.WISVisitorInformation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BeaconUebersichtView : ContentPage
    {
        private BeaconUebersichtViewModel _vm;
        public BeaconUebersichtView()
        {
            InitializeComponent();
            BindingContext = _vm = new BeaconUebersichtViewModel(Navigation, ClientDataAccessFactory.GetClientDataAccessExt());
            RufeBeaconsAb();
            
            
        }

        private async void RufeBeaconsAb()
        {
            if (await PruefeVerbindung())
            {
                await _vm.GetBeacon();
            }
        }

        private async Task<bool> PruefeVerbindung()
        {
            if (!_vm.CheckInternetConnectivity())
            {
                await DisplayAlert("Keine Netwerkverbindung", "Prüfen Sie die Verbindung zu Ihrem gewünschten Netzwerk", "OK");
                return false;
            }

            return true;
        }

        private async void ItemsListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new BeaconDetailView(e.SelectedItem as BeaconDTO));
            }
            catch (Exception exception)
            {
                await DisplayAlert("Fehler beim Aufrufen der Detailansicht", exception.Message, "OK");
                
            }
        }
    }
}