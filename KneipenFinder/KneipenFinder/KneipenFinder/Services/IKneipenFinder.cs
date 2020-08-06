using System.Collections.Generic;
using System.Threading.Tasks;
using KneipenFinder.Models;

namespace KneipenFinder.Services
{
    public interface IKneipenFinder
    {
        Task<IEnumerable<Kneipe>> GetKneipen(UserPosition position, double radiusInMeter);
    }
}
