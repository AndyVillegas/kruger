using Kruger.Application.DTOs;
using MediatR;

namespace Kruger.Application.Queries.ParkingRecordQueries
{
    public class GetParkingRecordByIdQuery : IRequest<ParkingRecordDto>
    {
        public int Id { get; set; }
        public GetParkingRecordByIdQuery(int id)
        {
            Id = id;
        }
        public GetParkingRecordByIdQuery()
        { }
    }
}
