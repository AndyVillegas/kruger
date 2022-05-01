using MediatR;

namespace Kruger.Application.Commands.ParkingPlaceCommands
{
    public class UpdateParkingPlaceCommand : INotification
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public int RateId { get; set; }
    }
}
