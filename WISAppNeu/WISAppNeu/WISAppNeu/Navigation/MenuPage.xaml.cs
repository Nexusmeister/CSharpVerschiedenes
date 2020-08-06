using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace WuerthIndustryMobileServices.Navigation
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            try
            {
                InitializeComponent();
                LadeMenue();
                menuItems = new List<HomeMenuItem>
                {
                    new HomeMenuItem {Id = MenuItemType.Browse, Title="Browse" },
                    new HomeMenuItem {Id = MenuItemType.About, Title="About" },
                    new HomeMenuItem
                    {
                        Id = MenuItemType.Notizen,
                        Title = "Notizen",
                    }
                };

                ListViewMenu.ItemsSource = menuItems;

                ListViewMenu.SelectedItem = menuItems[0];
                ListViewMenu.ItemSelected += async (sender, e) =>
                {
                    if (e.SelectedItem == null)
                        return;
                    if (e.SelectedItem is HomeMenuItem h)
                    {
                        var t = h.Id.GetHashCode();
                        await RootPage.NavigateFromMenu(t);
                    }
                    var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                    await RootPage.NavigateFromMenu(id);
                };
            }
            catch (Exception e)
            {
               
            }
            
        }

        private void LadeMenue()
        {
            //throw new NotImplementedException();
        }
    }
}