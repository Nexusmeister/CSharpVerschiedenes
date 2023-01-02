using System.Threading.Tasks;

namespace TripLog.Core.Services
{
    public interface INavService
    {
        bool CanGoBack { get; }
        Task GoBack();
    }
}