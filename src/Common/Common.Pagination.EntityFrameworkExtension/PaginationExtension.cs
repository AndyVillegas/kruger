using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Pagination.EntityFrameworkExtension
{
    public static class PaginationExtension
    {
        public static async Task<PaginatedResponse<T>> GetPaginatedResponseAsync<T>(this IQueryable<T> query, PaginationQuery paginationQuery = null) where T : class
        {
            paginationQuery ??= new PaginationQuery
            {
                PageIndex = 1,
                PageSize = 10
            };
            var paginatedResponse = new PaginatedResponse<T>
            {
                PageIndex = paginationQuery.PageIndex,
                PageSize = paginationQuery.PageSize,
                Count = await query.CountAsync(),
                Items = await query.Skip((paginationQuery.PageIndex - 1) * paginationQuery.PageSize).Take(paginationQuery.PageSize).ToListAsync()
            };
            return paginatedResponse;
        }
    }
}
