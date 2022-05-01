using Kruger.Core.Entities;
using Kruger.Core.Interfaces.Repositories;
using System;
using System.Linq.Expressions;

namespace Kruger.Infrastructure.Repositories
{
    public class RateRepository : CrudRepository<Rate>, IRateRepository
    {
        public RateRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override Expression<Func<Rate, bool>> GetAllWhereExpression(string search)
        {
            return rate => rate.Description.Contains(search);
        }
    }
}
