using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace KneipenFinder.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("http://kneipenfinder.allyourstuff.de/")));
        }

        public ICommand OpenWebCommand { get; }
    }
}