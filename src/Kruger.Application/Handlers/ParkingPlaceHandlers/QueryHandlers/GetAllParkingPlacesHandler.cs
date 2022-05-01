using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Common.Pagination;
using Kruger.Application.DTOs;
using Kruger.Application.Queries.ParkingPlaceQueries;
using Kruger.Core.Interfaces.Repositories;
using MediatR;

namespace Kruger.Application.Handlers.ParkingPlaceHandlers.QueryHandlers
{
    public class GetAllParkingPlacesHandler : IRequestHandler<GetAllParkingPlacesQuery, PaginatedResponse<ParkingPlaceDto>>
    {
        private readonly IParkingPlaceRepository _repository;
        private readonly IMapper _mapper;

        public GetAllParkingPlacesHandler(
            IParkingPlaceRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PaginatedResponse<ParkingPlaceDto>> Handle(GetAllParkingPlacesQuery request, CancellationToken cancellationToken)
        {
            var parkingPlaces = await _repository.GetAll(request.Search, request);
            return _mapper.Map<PaginatedResponse<ParkingPlaceDto>>(parkingPlaces);
        }
    }
}
