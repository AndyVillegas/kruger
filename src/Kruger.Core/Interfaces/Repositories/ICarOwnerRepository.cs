using System.Threading.Tasks;
using Kruger.Core.Entities;

namespace Kruger.Core.Interfaces.Repositories
{
    public interface ICarOwnerRepository : ICrudRepository<CarOwner>
    {
        Task<bool> IsTheIdentificationRepeated(string idValue, int? excludedId = null);
    }
}
