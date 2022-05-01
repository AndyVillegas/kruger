using Kruger.Application.DTOs;
using MediatR;

namespace Kruger.Application.Commands.ParkingPlaceCommands
{
    public class CreateParkingPlaceCommand : IRequest<ParkingPlaceDto>
    {
        public string Description { get; set; }
        public int Capacity { get; set; }
        public int RateId { get; set; }
    }
}
