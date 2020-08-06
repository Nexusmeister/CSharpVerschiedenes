using System;
using System.Windows;
using Ergebnisanzeige20.Views;
using Ergebnisanzeige20.AppFunktionen;
using Ergebnisanzeige20.Views.MainWindows;

namespace Ergebnisanzeige20
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DuellView startDuellView;
        private DuellView mittelDuellView;
        private DuellView schlussDuellView;
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                Title = ErgebnisanzeigeHelper.GetAppTitle();
                startDuellView = new DuellView();
                mittelDuellView = new DuellView();
                schlussDuellView = new DuellView();
                frameStartpaar.Content = startDuellView;
                frameMittelpaar.Content = mittelDuellView;
                frameSchlusspaar.Content = schlussDuellView;
            }
            catch (Exception)
            {
            }
        }

        private void BtnAnzeigeOeffnen_Click(object sender, RoutedEventArgs e)
        {
            var anzeige = new frmAnzeige();
            anzeige.DataContext = startDuellView.dvm;
            anzeige.Show();
        }
    }
}
