using Ergebnisanzeige20.Viewmodels;
using System.Windows.Controls;

namespace Ergebnisanzeige20.Views
{
    /// <summary>
    /// Interaction logic for DuellView.xaml
    /// </summary>
    public partial class DuellView : Page
    {
        public DuellViewmodel dvm;
        public DuellView()
        {
            InitializeComponent();
            dvm = new DuellViewmodel();

            DataContext = dvm;
        }
    }
}
