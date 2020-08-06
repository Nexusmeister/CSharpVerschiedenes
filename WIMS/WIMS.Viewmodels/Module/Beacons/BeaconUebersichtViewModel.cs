using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Catel.Data;
using Catel.MVVM;
using WIMS.Tools;
using WIS.WebAPI.DTOs.WisVisitorInformation;
using WIS.WebAPIExt.ClientDataAccess;
using Xamarin.Essentials;
using Xamarin.Forms;
using Command = Catel.MVVM.Command;

namespace WIMS.Viewmodels.Module.Beacons
{
    public class BeaconUebersichtViewModel : ViewModelBase
    {
        private readonly IClientDataAccessExt _client;
        private INavigation _navigation;
        public override string Title => "Beacons";

        #region Attribute
        private ObservableCollection<BeaconDTO> _listBeacon;

        public ObservableCollection<BeaconDTO> ListBeacon
        {
            get
            {
                if (_listBeacon == null)
                {
                    SetzeListBeacon();
                }

                return _listBeacon;
            }
            set
            {
                if (value == _listBeacon)
                {
                    return;
                }

                _listBeacon = value;
                OnPropertyChanged(new AdvancedPropertyChangedEventArgs(this, nameof(ListBeacon)));
            }
        }
        
        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(new AdvancedPropertyChangedEventArgs(this, nameof(IsRefreshing)));
            }
        }

        #endregion
        
        public BeaconUebersichtViewModel(INavigation navigation, IClientDataAccessExt clientData) : this()
        {
            _client = clientData;
            
            _navigation = navigation;
        }

        public BeaconUebersichtViewModel()
        {

        }

        #region Commands

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;

                    await GetBeacon();

                    IsRefreshing = false;
                });
            }
        }

        #endregion

        #region Methoden

        public async Task GetBeacon()
        {
            try
            {
                if (!CheckInternetConnectivity())
                {
                    
                    //Toast.MakeText(Application.Context, "Internet ist nicht erreichbar.", ToastLength.Long).Show();
                    return;
                }

                IsRefreshing = true;
                if (_listBeacon != null && _listBeacon.Count > 0)
                {
                    _listBeacon.Clear();
                }
                

                var resultBeacons = await _client.BeaconsRepository.GetAllAsync();
                _listBeacon = resultBeacons.ToObservableCollection();


                IsRefreshing = false;
            }
            catch (Exception e)
            {
                var errorText = e.ToString();
            }
        }

        private async void SetzeListBeacon()
        {
            await GetBeacon();
        }
        
        public bool CheckInternetConnectivity()
        {
            return Connectivity.NetworkAccess == NetworkAccess.Internet;
        }

        #endregion
    }
}
