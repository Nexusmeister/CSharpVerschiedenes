using WuerthIndustryMobileServices.Module.Softwaretest.Module.Notizen.Models;
using WuerthIndustryMobileServices.ViewModels;

namespace WuerthIndustryMobileServices.Module.Softwaretest.Module.Notizen.Viewmodels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
