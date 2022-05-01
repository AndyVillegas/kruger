using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Kruger.Application.DTOs;
using Kruger.Application.Exceptions;
using Kruger.Application.Queries.ParkingPlaceQueries;
using Kruger.Core.Interfaces.Repositories;
using MediatR;

namespace Kruger.Application.Handlers.ParkingPlaceHandlers.QueryHandlers
{
    public class GetParkingPlaceByIdHandler : IRequestHandler<GetParkingPlaceByIdQuery, ParkingPlaceDto>
    {
        private readonly IParkingPlaceRepository _repository;
        private readonly IMapper _mapper;

        public GetParkingPlaceByIdHandler(
            IParkingPlaceRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ParkingPlaceDto> Handle(GetParkingPlaceByIdQuery request, CancellationToken cancellationToken)
        {
            var parkingPlaces = await _repository.GetOne(request.Id);
            if (parkingPlaces == null)
                throw new ParkingPlaceNotFoundException();
            return _mapper.Map<ParkingPlaceDto>(parkingPlaces);
        }
    }
}
