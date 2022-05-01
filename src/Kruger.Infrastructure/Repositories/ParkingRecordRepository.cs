using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Kruger.Core.Entities;
using Kruger.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kruger.Infrastructure.Repositories
{
    public class ParkingRecordRepository : CrudRepository<ParkingRecord>, IParkingRecordRepository
    {
        public ParkingRecordRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> IsTheParkingPlaceOccupied(int parkingPlaceId)
        {
            return await Queryable.AnyAsync(e => e.ParkingPlaceId == parkingPlaceId &&
                                      !e.EndTime.HasValue);
        }

        public async Task<bool> IsTheCarOwnerOccupied(int carOwnerId)
        {
            return await Queryable.AnyAsync(e => e.CarOwnerId == carOwnerId &&
                                                 !e.EndTime.HasValue);
        }

        public override IQueryable<ParkingRecord> Queryable => base.Queryable
            .Include(e => e.Car)
            .Include(e => e.ParkingPlace)
            .Include(e => e.CarOwner);

        public override Expression<Func<ParkingRecord, bool>> GetAllWhereExpression(string search)
        {
            return parking => parking.Car.Plate.Contains(search) ||
            parking.CarOwner.Name.Contains(search) || 
            parking.CarOwner.Name.Contains(search);
        }

        public async Task<int> GetNumberOfRecordsByOccupiedParkingPlace(int parkingPlaceId)
        {
            return await Queryable.Where(e => e.ParkingPlaceId == parkingPlaceId && !e.EndTime.HasValue).CountAsync();
        }
    }
}
