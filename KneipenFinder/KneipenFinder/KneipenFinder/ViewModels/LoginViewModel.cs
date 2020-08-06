using KneipenFinder.Models;

namespace KneipenFinder.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _userName;
        private string _password;
        private bool _kneipenButtonAnzeigen;
        private bool _logoutEnabled;

        public User User { get; set; }

        public string Username
        {
            get => _userName;
            set
            {
                if (_userName != value)
                {
                    _userName = value;

                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        public string Password {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;

                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        public bool KneipenButtonAnzeigen
        {
            get => _kneipenButtonAnzeigen;
            set
            {
                _kneipenButtonAnzeigen = value;
                OnPropertyChanged(nameof(KneipenButtonAnzeigen));
            }
        }

        public bool LogoutEnabled
        {
            get => _logoutEnabled;
            set
            {
                _logoutEnabled = value;
                OnPropertyChanged(nameof(LogoutEnabled));
            }
        }

        public LoginViewModel()
        {
            Title = "Login für Redakteure";
            KneipenButtonAnzeigen = false;
        }

        public bool LoggeUserEin()
        {
            User = new User(Username, Password);
            if (User.CheckUsername() && User.CheckPassword())
            {
                KneipenButtonAnzeigen = true;
                return true;
            }

            KneipenButtonAnzeigen = false;
            return false;
        }

        public void Logout()
        {
            User = null;
            KneipenButtonAnzeigen = false;
            Username = string.Empty;
            Password = string.Empty;
        }
    }
}
