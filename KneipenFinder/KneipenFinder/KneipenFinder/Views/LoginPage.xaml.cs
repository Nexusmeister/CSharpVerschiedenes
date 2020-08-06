using System;
using System.ComponentModel;
using KneipenFinder.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KneipenFinder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]
    public partial class LoginPage : ContentPage
    {
        private LoginViewModel _vm;

        public LoginPage()
        {
            InitializeComponent();
            BtnLogout.IsEnabled = false;
            BindingContext = _vm = new LoginViewModel();
        }

        private void OnLoginButtonClicked(object sender, EventArgs e)
        {
       
            var result = _vm.LoggeUserEin();

            if (result)
            {
                MessageLabel.Text = $"Willkommen {_vm.Username}!";
                _vm.LogoutEnabled = true;
                BtnLogout.IsEnabled = _vm.LogoutEnabled;
            }
            else
            {
                DisplayAlert("Login fehlgeschlagen", "Die Kombination aus User und Passwort stimmen nicht überein!",
                    "OK");
            }
            
        }

        private async void BtnAngebote_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NeuesAngebotPage(_vm.User)), true);
        }

        private void BtnLogout_OnClicked(object sender, EventArgs e)
        {
            _vm.Logout();
            _vm.LogoutEnabled = false;
            BtnLogout.IsEnabled = _vm.LogoutEnabled;
            MessageLabel.Text = string.Empty;
        }
    }
}