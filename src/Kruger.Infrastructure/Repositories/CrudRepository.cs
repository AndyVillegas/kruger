using System;
using Kruger.Core.Entities;
using Kruger.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Common.Pagination;
using Common.Pagination.EntityFrameworkExtension;

namespace Kruger.Infrastructure.Repositories
{
    public abstract class CrudRepository<T> : ICrudRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        public CrudRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<T> Create(T entity)
        {
            await _context.AddAsync(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            entity.DeletedAt = DateTime.Now;
            _context.Update(entity);
        }

        public async Task<T> GetOne(int id)
        {
            return await Queryable.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            entity.UpdatedAt = DateTime.Now;
            _context.Update(entity);
        }

        public async Task<PaginatedResponse<T>> GetAll(string search, PaginationQuery pagination = null)
        {
            var query = Queryable;
            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(GetAllWhereExpression(search));
            return await query.GetPaginatedResponseAsync(pagination);
        }

        public abstract System.Linq.Expressions.Expression<Func<T, bool>> GetAllWhereExpression(string search);

        public virtual IQueryable<T> Queryable => _context.Set<T>().AsQueryable();
    }
}
