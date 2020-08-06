namespace KneipenFinder.ViewModels
{
    public class SettingsViewmodel : BaseViewModel
    {
        private double _standardRadius;
        public double StandardRadius {
            get => _standardRadius;
            set
            {
                _standardRadius = value;
                OnPropertyChanged(nameof(StandardRadius));
            }
        }

        public bool DarkMode { get; set; }

        public SettingsViewmodel()
        {
            Title = "Einstellungen";
            StandardRadius = 1500;
        }

        public static double GetStandardRadius()
        {
            return new SettingsViewmodel().StandardRadius;
        }
    }
}
