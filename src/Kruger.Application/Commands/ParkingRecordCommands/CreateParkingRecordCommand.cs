using Kruger.Application.DTOs;
using MediatR;

namespace Kruger.Application.Commands.ParkingRecordCommands
{
    public class CreateParkingRecordCommand : IRequest<ParkingRecordDto>
    {
        public int CarOwnerId { get; set; }
        public int ParkingPlaceId { get; set; }
        public int CarId { get; set; }
    }
}
