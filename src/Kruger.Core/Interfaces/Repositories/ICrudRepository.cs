using Common.Pagination;
using Kruger.Core.Entities;
using System.Threading.Tasks;

namespace Kruger.Core.Interfaces.Repositories
{
    public interface ICrudRepository<T> where T : BaseEntity
    {
        Task<PaginatedResponse<T>> GetAll(string search, PaginationQuery pagination = null);
        Task<T> GetOne(int id);
        Task<T> Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveChanges();
    }
}
