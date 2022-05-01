using Common.Pagination;
using Kruger.Application.DTOs;
using MediatR;

namespace Kruger.Application.Queries.CarOwnerQueries
{
    public class GetAllCarOwnersQuery : PaginationQuery, IRequest<PaginatedResponse<CarOwnerDto>>
    {
        public string Search { get; set; }
    }
}
