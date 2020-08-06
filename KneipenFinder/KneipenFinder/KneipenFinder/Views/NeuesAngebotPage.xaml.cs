using System;
using System.ComponentModel;
using KneipenFinder.Models;
using KneipenFinder.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KneipenFinder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]
    public partial class NeuesAngebotPage : ContentPage
    {
        private NeuesAngebotViewmodel _vm;
        public NeuesAngebotPage()
        {
            InitializeComponent();

            BindingContext = _vm = new NeuesAngebotViewmodel();
        }

        public NeuesAngebotPage(User benutzer) : this()
        {
            _vm.Benutzer = benutzer;
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync(true);
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            var success = await _vm.AngebotErstellen();
            if (success)
            {
                await Navigation.PopModalAsync(true);
            }
        }
    }
}