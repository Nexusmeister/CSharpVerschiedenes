using System.Collections.ObjectModel;

namespace WuerthIndustryMobileServices.Services
{
    public interface IBeacon
    {
        void StartRangingScan();
        ObservableCollection<string> GetList();
    }
}
