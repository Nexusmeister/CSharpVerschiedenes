using WIMS.Models.Module.DefaultItems;

namespace WIMS.Viewmodels.Module.DefaultItems
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
