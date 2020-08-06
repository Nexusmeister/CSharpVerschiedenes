using System;
using KneipenFinder.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KneipenFinder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        private SettingsViewmodel _vm;

        public SettingsPage()
        {
            InitializeComponent();
            BindingContext = _vm = new SettingsViewmodel();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {

        }
    }
}