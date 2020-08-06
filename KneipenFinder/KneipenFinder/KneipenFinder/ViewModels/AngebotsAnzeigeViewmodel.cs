using System.Collections.ObjectModel;
using KneipenFinder.Models.APIAntwort;

namespace KneipenFinder.ViewModels
{
    public class AngebotsAnzeigeViewmodel : BaseViewModel
    {
        private ObservableCollection<Saledata> _angebote;

        public ObservableCollection<Saledata> Angebote
        {
            get => _angebote;
            set
            {
                _angebote = value;
                OnPropertyChanged(nameof(Angebote));
            }
        }

        public AngebotsAnzeigeViewmodel()
        {
            Title = "Angebot anzeigen";
        }
    }
}
