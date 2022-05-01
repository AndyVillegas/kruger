using System.Threading.Tasks;
using Kruger.Core.Entities;

namespace Kruger.Core.Interfaces.Repositories
{
    public interface IParkingRecordRepository : ICrudRepository<ParkingRecord>
    {
        Task<bool> IsTheParkingPlaceOccupied(int parkingPlaceId);
        Task<bool> IsTheCarOwnerOccupied(int carOwnerId);
        Task<int> GetNumberOfRecordsByOccupiedParkingPlace(int parkingPlaceId);
    }
}
