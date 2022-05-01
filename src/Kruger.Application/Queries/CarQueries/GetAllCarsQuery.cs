using System.Collections.Generic;
using Common.Pagination;
using Kruger.Application.DTOs;
using MediatR;

namespace Kruger.Application.Queries.CarQueries
{
    public class GetAllCarsQuery : PaginationQuery, IRequest<PaginatedResponse<CarDto>>
    {
        public string Search { get; set; }
    }
}
