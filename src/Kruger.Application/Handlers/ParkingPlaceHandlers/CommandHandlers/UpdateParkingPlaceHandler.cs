using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Kruger.Application.Commands.ParkingPlaceCommands;
using Kruger.Application.Exceptions;
using Kruger.Core.Interfaces.Repositories;
using MediatR;

namespace Kruger.Application.Handlers.ParkingPlaceHandlers.CommandHandlers
{
    public class UpdateParkingPlaceHandler : INotificationHandler<UpdateParkingPlaceCommand>
    {
        private readonly IParkingPlaceRepository _repository;
        private readonly IMapper _mapper;

        public UpdateParkingPlaceHandler(
            IParkingPlaceRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateParkingPlaceCommand notification, CancellationToken cancellationToken)
        {
            var parkingPlaces = await _repository.GetOne(notification.Id);
            if (parkingPlaces == null)
                throw new ParkingPlaceNotFoundException();
            var updatedParkingPlace = _mapper.Map(notification, parkingPlaces);
            _repository.Update(updatedParkingPlace);
            await _repository.SaveChanges();
        }
    }
}
