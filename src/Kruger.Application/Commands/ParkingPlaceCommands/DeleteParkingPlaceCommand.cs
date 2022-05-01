using MediatR;

namespace Kruger.Application.Commands.ParkingPlaceCommands
{
    public class DeleteParkingPlaceCommand : INotification
    {
        public int Id { get; set; }
    }
}
