using System;
using WIMS.Viewmodels.Module.DefaultItems.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WIMS.Views;
using WIMS.Views.Masken.DefaultItems;

namespace WIMS
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
