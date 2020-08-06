using JetBrains.Annotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ergebnisanzeige20.Viewmodels
{
    public class DuellViewmodel : INotifyPropertyChanged
    {
        private int _skcv1lo;
        public int SKCV1LO {
            get
            {
                return _skcv1lo;
            }
            set
            {
                if (_skcv1lo != value)
                {
                    _skcv1lo = value;
                    OnPropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        public void OnPropertyChanged([CallerMemberName] string callerName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
        }
    }
}
