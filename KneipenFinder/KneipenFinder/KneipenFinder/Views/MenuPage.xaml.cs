using KneipenFinder.Models;
using System.Collections.Generic;
using System.ComponentModel;
using KneipenFinder.Enums;
using Xamarin.Forms;

namespace KneipenFinder.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        private MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        private List<HomeMenuItem> _menuItems;

        public MenuPage()
        {
            InitializeComponent();

            _menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Home, Title= "Home" },
                //new HomeMenuItem {Id = MenuItemType.Kneipen, Title = "Kneipenfinder"},
                new HomeMenuItem {Id = MenuItemType.Settings, Title = "Einstellungen"},
                new HomeMenuItem
                {
                    Id = MenuItemType.UserLogin,
                    Title = "Userlogin"
                },
                new HomeMenuItem {Id = MenuItemType.About, Title= "About" }
            };

            ListViewMenu.ItemsSource = _menuItems;
            if (_menuItems.Count > 0)
            {
                ListViewMenu.SelectedItem = _menuItems[0];
                ListViewMenu.ItemSelected += async (sender, e) =>
                {
                    if (e.SelectedItem == null)
                    {
                        return;
                    }

                    if (e.SelectedItem is HomeMenuItem homeMenuItem)
                    {
                        var idnew = homeMenuItem.Id;
                        await RootPage.NavigateFromMenu(idnew);
                    }
                };
            }
        }
    }
}