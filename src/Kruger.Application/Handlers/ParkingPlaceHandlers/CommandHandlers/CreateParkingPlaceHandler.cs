using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Kruger.Application.Commands.ParkingPlaceCommands;
using Kruger.Application.DTOs;
using Kruger.Core.Entities;
using Kruger.Core.Interfaces.Repositories;
using MediatR;

namespace Kruger.Application.Handlers.ParkingPlaceHandlers.CommandHandlers
{
    public class CreateParkingPlaceHandler : IRequestHandler<CreateParkingPlaceCommand, ParkingPlaceDto>
    {
        private readonly IParkingPlaceRepository _repository;
        private readonly IMapper _mapper;

        public CreateParkingPlaceHandler(
            IParkingPlaceRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ParkingPlaceDto> Handle(CreateParkingPlaceCommand request, CancellationToken cancellationToken)
        {
            var parkingPlaces = _mapper.Map<ParkingPlace>(request);
            var newModel = await _repository.Create(parkingPlaces);
            await _repository.SaveChanges();
            return _mapper.Map<ParkingPlaceDto>(newModel);
        }
    }
}
