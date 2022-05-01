using System.Collections.Generic;
using Common.Pagination;
using Kruger.Application.DTOs;
using MediatR;

namespace Kruger.Application.Queries.RateQueries
{
    public class GetAllRatesQuery : PaginationQuery, IRequest<PaginatedResponse<RateDto>>
    {
        public string Search { get; set; }
    }
}
