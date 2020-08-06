using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Catel;
using Catel.Data;
using Catel.MVVM;
using WIS.WebAPI.DTOs.WisVisitorInformation;
using WIS.WebAPIExt.ClientDataAccess;
using Xamarin.Forms;

namespace WIMS.Viewmodels.Module.Beacons
{
    public class BeaconDetailViewModel : ViewModelBase
    {
        private INavigation _navigation;

        [Model]
        public BeaconDTO Beacon
        {
            get => GetValue<BeaconDTO>(BeaconData);
            set => SetValue(BeaconData, value);
        }

        public BeaconDetailViewModel(INavigation navigation, BeaconDTO beacon) : this()
        {
            _navigation = navigation;

            Argument.IsNotNull(() => beacon);
            Beacon = beacon;
        }

        public BeaconDetailViewModel()
        {
            
        }

        public static readonly PropertyData BeaconData = RegisterProperty("Beacon", typeof(BeaconDTO));

        
    }
}
