using JetBrains.Annotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ergebnisanzeige.Viewmodels
{
    public class CommunicationViewmodel : INotifyPropertyChanged
    {
        private EingabeViewmodel _eingabeViewmodel;
        public EingabeViewmodel EingabeViewmodel {
            get
            {
                return _eingabeViewmodel;
            }
            set
            {
                _eingabeViewmodel = value;
                OnPropertyChanged();
            }
        }

        public CommunicationViewmodel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ErhalteNachricht(EingabeViewmodel eingabeViewmodel)
        {
            EingabeViewmodel = eingabeViewmodel;
        }

        public void SendeNachricht(EingabeViewmodel eingabeViewmodel)
        {
            
        }

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string caller = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));

        }
    }
}
