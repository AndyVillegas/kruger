using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Common.Pagination;
using Kruger.Application.DTOs;
using Kruger.Application.Queries.CarQueries;
using Kruger.Core.Interfaces.Repositories;
using MediatR;

namespace Kruger.Application.Handlers.CarHandlers.QueryHandlers
{
    public class GetAllCarsHandler : IRequestHandler<GetAllCarsQuery, PaginatedResponse<CarDto>>
    {
        private readonly ICarRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCarsHandler(
            ICarRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PaginatedResponse<CarDto>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            var cars = await _repository.GetAll(request.Search, request);
            return _mapper.Map<PaginatedResponse<CarDto>>(cars);
        }
    }
}
