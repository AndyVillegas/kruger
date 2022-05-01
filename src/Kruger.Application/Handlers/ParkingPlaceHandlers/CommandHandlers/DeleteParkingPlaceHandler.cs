using System.Threading;
using System.Threading.Tasks;
using Kruger.Application.Commands.ParkingPlaceCommands;
using Kruger.Application.Exceptions;
using Kruger.Core.Interfaces.Repositories;
using MediatR;

namespace Kruger.Application.Handlers.ParkingPlaceHandlers.CommandHandlers
{
    public class DeleteParkingPlaceHandler : INotificationHandler<DeleteParkingPlaceCommand>
    {
        private readonly IParkingPlaceRepository _repository;

        public DeleteParkingPlaceHandler(IParkingPlaceRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(DeleteParkingPlaceCommand notification, CancellationToken cancellationToken)
        {
            var parkingPlaces = await _repository.GetOne(notification.Id);
            if (parkingPlaces == null)
                throw new ParkingPlaceNotFoundException();
            _repository.Delete(parkingPlaces);
            await _repository.SaveChanges();
        }
    }
}
