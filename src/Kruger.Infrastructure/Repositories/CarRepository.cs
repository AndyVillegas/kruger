using Kruger.Core.Entities;
using Kruger.Core.Interfaces.Repositories;
using System;
using System.Linq.Expressions;

namespace Kruger.Infrastructure.Repositories
{
    public class CarRepository : CrudRepository<Car>, ICarRepository
    {
        public CarRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override Expression<Func<Car, bool>> GetAllWhereExpression(string search)
        {
            return car => car.Plate.Contains(search);
        }
    }
}
