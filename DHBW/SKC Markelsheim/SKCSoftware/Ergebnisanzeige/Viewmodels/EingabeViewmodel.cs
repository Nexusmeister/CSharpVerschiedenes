using JetBrains.Annotations;
using SKCDLL.Entities.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ergebnisanzeige.Viewmodels
{
    public class EingabeViewmodel : INotifyPropertyChanged
    {
        private Partie _partie;
        private string _skcMarkelsheimName;
        private CommunicationViewmodel communicationViewmodel;

        #region Eigenschaften
        public string SKCMarkelsheimName
        {
            get
            {
                return _skcMarkelsheimName;
            }
            set
            {
                _skcMarkelsheimName = "SKC Markelsheim";
                _skcMarkelsheimName += value;
                _partie.SKCMarkelsheimName = _skcMarkelsheimName;
                OnPropertyChanged();
                NotifyAnzeige();
            }
        }

        #endregion

        public EingabeViewmodel(Partie partie)
        {
            _partie = partie;
            communicationViewmodel = new CommunicationViewmodel();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void NotifyAnzeige()
        {
            communicationViewmodel.ErhalteNachricht(this);
        }
    }
}
