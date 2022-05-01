using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Kruger.Application.DTOs;
using Kruger.Application.Exceptions;
using Kruger.Application.Queries.CarOwnerQueries;
using Kruger.Core.Interfaces.Repositories;
using MediatR;

namespace Kruger.Application.Handlers.CarOwnerHandlers.QueryHandlers
{
    public class GetCarOwnerByIdHandler : IRequestHandler<GetCarOwnerByIdQuery, CarOwnerDto>
    {
        private readonly ICarOwnerRepository _repository;
        private readonly IMapper _mapper;

        public GetCarOwnerByIdHandler(
            ICarOwnerRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CarOwnerDto> Handle(GetCarOwnerByIdQuery request, CancellationToken cancellationToken)
        {
            var carOwner = await _repository.GetOne(request.Id);
            if (carOwner == null)
                throw new CarOwnerNotFoundException();
            return _mapper.Map<CarOwnerDto>(carOwner);
        }
    }
}
