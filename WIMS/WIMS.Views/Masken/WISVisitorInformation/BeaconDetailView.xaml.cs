using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIMS.Tools;
using WIMS.Viewmodels.Module.Beacons;
using WIS.WebAPI.DTOs.WisVisitorInformation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WIMS.Views.Masken.WISVisitorInformation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BeaconDetailView : ContentPage
    {
        private BeaconDetailViewModel _vm;
        public BeaconDetailView()
        {
            InitializeComponent();

            
        }

        public BeaconDetailView(BeaconDTO beacon) : this()
        {
            BindingContext = _vm = new BeaconDetailViewModel(null, beacon);
        }
    }
}