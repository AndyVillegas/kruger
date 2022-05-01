using Kruger.Application.DTOs;
using MediatR;

namespace Kruger.Application.Queries.ParkingPlaceQueries
{
    public class GetParkingPlaceByIdQuery : IRequest<ParkingPlaceDto>
    {
        public int Id { get; set; }
        public GetParkingPlaceByIdQuery(int id)
        {
            Id = id;
        }
        public GetParkingPlaceByIdQuery()
        { }
    }
}
