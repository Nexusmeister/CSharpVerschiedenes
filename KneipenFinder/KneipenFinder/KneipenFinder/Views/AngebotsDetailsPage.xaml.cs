using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using KneipenFinder.Models;
using KneipenFinder.Models.APIAntwort;
using KneipenFinder.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KneipenFinder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]
    public partial class AngebotsDetailsPage : ContentPage
    {
        private AngebotsAnzeigeViewmodel _vm;

        /// <summary>
        /// Gets or Sets the Back button click overriden custom action
        /// </summary>
        public Action CustomBackButtonAction { get; set; }

        /// <summary>
        /// Gets or Sets Custom Back button overriding state
        /// </summary>
        public bool EnableBackButtonOverride
        {
            get => (bool)GetValue(EnableBackButtonOverrideProperty);
            set => SetValue(EnableBackButtonOverrideProperty, value);
        }

        public static readonly BindableProperty EnableBackButtonOverrideProperty =
            BindableProperty.Create(
                nameof(EnableBackButtonOverride),
                typeof(bool),
                typeof(AngebotsDetailsPage),
                false);

        public Kneipe SelectedKneipe { get; set; }

        public AngebotsDetailsPage()
        {
            InitializeComponent();
            BindingContext = _vm = new AngebotsAnzeigeViewmodel();
        }

        public AngebotsDetailsPage(Kneipe kneipe) :this()
        {
            SelectedKneipe = kneipe;
            if (kneipe.Angebote != null && kneipe.Angebote.Count > 0)
            {
                _vm.Angebote = new ObservableCollection<Saledata>(kneipe.Angebote);
                //_vm.Angebote.Add(new Saledata { PlaceId = kneipe.KneipenId, SaleDescription = "Dies soll eine ganz lange Beschreibung darstellen, um die Größenanpassung anzupassen." });
                lvAngebote.HasUnevenRows = true;
            }
            else
            {
                _vm.Angebote = new ObservableCollection<Saledata>();
                _vm.Angebote.Add(new Saledata{PlaceId = SelectedKneipe.KneipenId, SaleDescription = "Kein Angebot gefunden."});
            }
            
        }
    }
}