using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using WuerthIndustryMobileServices.Module.Beacons.Models;
using WuerthIndustryMobileServices.ViewModels;
using Xamarin.Forms;

namespace WuerthIndustryMobileServices.Module.Beacons.Viewmodels
{
    public class OverviewViewmodel : BaseViewModel
    {
        public new event PropertyChangedEventHandler PropertyChanged;

        #region Konstruktor
        public OverviewViewmodel()
        {
            ListBeacon = new ObservableCollection<Beacon>();
            _listBeacon = new ObservableCollection<Beacon>();
            GetBeacon();
        }
        #endregion

        #region Methoden
        public async Task GetBeacon()
        {
            ListBeacon = new ObservableCollection<Beacon>();
            _listBeacon = new ObservableCollection<Beacon>();
            _listBeacon.Clear();
            ListBeacon.Clear();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListBeacon"));

            //Laden der Tabelle aus Datenbank
            //var newListBeacon = DatabaseController.GetTable<BeaconBeaconEstimote>();

            //foreach (var b in newListBeacon)
            //{
            //    ListBeacon.Add(b);
            //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListBeacon"));
            //}
        }

        public void SearchBeacon()
        {
            //NavigationController.NavigateToNewPage(Keys.BeaconSearchView, false);
        }

        public void ShowBeacon(Beacon b)
        {
            GetBeacon();
            //foreach (BeaconEstimote beacon in ListBeacon)
            //{
            //    BeaconEstimote a = b;
            //    if (beacon.UUID == b.UUID && beacon.Major == b.Major && beacon.Minor == b.Minor)
            //    {
            //        NavigationController.NavigateToNewPage(Keys.ViewModeView, false, beacon);
            //    }
            //}
        }
        #endregion

        #region Binding Attribute
        private ObservableCollection<Beacon> _listBeacon;
        public ObservableCollection<Beacon> ListBeacon
        {
            get { return _listBeacon; }
            set
            {
                if (value == _listBeacon)
                {
                    return;
                }
                _listBeacon = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListBeacon"));
            }
        }

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsRefreshing"));
            }
        }
        #endregion

        #region Binding Commands
        public Command SearchBeaconCommand { get => new Command(SearchBeacon); }
        public Command<Beacon> ShowBeaconCommand { get => new Command<Beacon>(ShowBeacon); }

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
    }
}
