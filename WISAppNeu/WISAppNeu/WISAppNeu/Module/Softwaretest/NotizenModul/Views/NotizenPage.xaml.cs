using System;
using WuerthIndustryMobileServices.Module.Softwaretest.NotizenModul.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WuerthIndustryMobileServices.Module.Softwaretest.NotizenModul.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotizenPage : ContentPage
    {
        public Item Item { get; set; }

        public NotizenPage()
        {
            InitializeComponent();

            Item = new Item
            {
                Text = "Item name",
                Description = "Beschreibung."
            };

            BindingContext = this;
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            
        }
    }
}