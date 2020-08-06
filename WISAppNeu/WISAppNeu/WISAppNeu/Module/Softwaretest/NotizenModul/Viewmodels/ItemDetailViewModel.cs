using WuerthIndustryMobileServices.Module.Softwaretest.NotizenModul.Models;
using WuerthIndustryMobileServices.ViewModels;

namespace WuerthIndustryMobileServices.Module.Softwaretest.NotizenModul.Viewmodels
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
