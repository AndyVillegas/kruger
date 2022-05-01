using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Kruger.Application.DTOs;
using Kruger.Application.Exceptions;
using Kruger.Application.Queries.CarQueries;
using Kruger.Core.Interfaces.Repositories;
using MediatR;

namespace Kruger.Application.Handlers.CarHandlers.QueryHandlers
{
    public class GetCarByIdHandler : IRequestHandler<GetCarByIdQuery, CarDto>
    {
        private readonly ICarRepository _repository;
        private readonly IMapper _mapper;

        public GetCarByIdHandler(
            ICarRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CarDto> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var car = await _repository.GetOne(request.Id);
            if (car == null)
                throw new CarNotFoundException();
            return _mapper.Map<CarDto>(car);
        }
    }
}
