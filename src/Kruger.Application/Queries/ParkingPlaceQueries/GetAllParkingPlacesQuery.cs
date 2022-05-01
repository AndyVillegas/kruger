using Common.Pagination;
using Kruger.Application.DTOs;
using MediatR;

namespace Kruger.Application.Queries.ParkingPlaceQueries
{
    public class GetAllParkingPlacesQuery : PaginationQuery, IRequest<PaginatedResponse<ParkingPlaceDto>>
    {
        public string Search { get; set; }
    }
}
