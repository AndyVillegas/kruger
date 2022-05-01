using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Kruger.Core.Entities;
using Kruger.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kruger.Infrastructure.Repositories
{
    public class CarOwnerRepository : CrudRepository<CarOwner>, ICarOwnerRepository
    {
        public CarOwnerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override Expression<Func<CarOwner, bool>> GetAllWhereExpression(string search)
        {
            return carOwner => carOwner.Name.Contains(search) ||
            carOwner.LastName.Contains(search);
        }

        public async Task<bool> IsTheIdentificationRepeated(string idValue, int? excludedId = null)
        {
            return await Queryable
                .AnyAsync(e => e.IdValue == idValue && e.Id != excludedId);
        }
    }
}
