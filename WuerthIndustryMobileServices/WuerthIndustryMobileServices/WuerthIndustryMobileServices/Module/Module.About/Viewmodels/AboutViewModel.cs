using System;
using System.Windows.Input;
using WuerthIndustryMobileServices.ViewModels;
using Xamarin.Forms;

namespace WuerthIndustryMobileServices.Module.Module.About.Viewmodels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        public ICommand OpenWebCommand { get; }
    }
}