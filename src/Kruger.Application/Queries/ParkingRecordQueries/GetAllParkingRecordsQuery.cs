using Common.Pagination;
using Kruger.Application.DTOs;
using MediatR;

namespace Kruger.Application.Queries.ParkingRecordQueries
{
    public class GetAllParkingRecordsQuery : PaginationQuery, IRequest<PaginatedResponse<ParkingRecordDto>>
    {
        public string Search { get; set; }
    }
}
