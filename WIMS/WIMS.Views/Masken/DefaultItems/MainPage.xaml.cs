using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using WIMS.Models.Module.DefaultItems;
using WIMS.Views.Masken.WISVisitorInformation;
using Xamarin.Forms;

namespace WIMS.Views.Masken.DefaultItems
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        readonly Dictionary<MenuItemType, NavigationPage> _menuPages = new Dictionary<MenuItemType, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Split;

            _menuPages.Add(MenuItemType.Browse, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(MenuItemType id)
        {
            if (!_menuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case MenuItemType.Browse:
                        _menuPages.TryAdd(id, new NavigationPage(new ItemsPage()));
                        break;
                    case MenuItemType.About:
                        _menuPages.TryAdd(id, new NavigationPage(new AboutPage()));
                        break;
                    case MenuItemType.Beacons:
                        _menuPages.TryAdd(id, new NavigationPage(new BeaconUebersichtView()));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(id), id, "Die angeforderte Seite konnte nicht aufgerufen werden");
                }
            }

            _menuPages.TryGetValue(id, out var newPage);

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}