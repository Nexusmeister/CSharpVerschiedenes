using System.ComponentModel;
using KneipenFinder.Models;
using KneipenFinder.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KneipenFinder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]
    public partial class KneipenFinderPage : ContentPage
    {
        private KneipenFinderViewmodel _vm;
        public KneipenFinderPage()
        {
            BindingContext = _vm = new KneipenFinderViewmodel();
            InitializeComponent();
        }

        private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var kneipe = (Kneipe) ListViewKneipen.SelectedItem;
            await Navigation.PushModalAsync(new NavigationPage(new AngebotsDetailsPage(kneipe)), true);
        }
    }
}