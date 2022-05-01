using System;
using System.Linq;
using System.Linq.Expressions;
using Kruger.Core.Entities;
using Kruger.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kruger.Infrastructure.Repositories
{
    public class ParkingPlaceRepository : CrudRepository<ParkingPlace>, IParkingPlaceRepository
    {
        public ParkingPlaceRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override IQueryable<ParkingPlace> Queryable 
            => base.Queryable.Include(e => e.Rate);

        public override Expression<Func<ParkingPlace, bool>> GetAllWhereExpression(string search)
        {
            return parking => parking.Description.Contains(search);
        }
    }
}
