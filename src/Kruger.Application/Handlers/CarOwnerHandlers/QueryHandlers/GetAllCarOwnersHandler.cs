using AutoMapper;
using Common.Pagination;
using Kruger.Application.DTOs;
using Kruger.Application.Queries.CarOwnerQueries;
using Kruger.Core.Interfaces.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kruger.Application.Handlers.CarOwnerHandlers.QueryHandlers
{
    public class GetAllCarOwnersHandler : IRequestHandler<GetAllCarOwnersQuery, PaginatedResponse<CarOwnerDto>>
    {
        private readonly ICarOwnerRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCarOwnersHandler(
            ICarOwnerRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PaginatedResponse<CarOwnerDto>> Handle(GetAllCarOwnersQuery request, CancellationToken cancellationToken)
        {
            var paginaredCarOwners = await _repository.GetAll(request.Search, request);
            return _mapper.Map<PaginatedResponse<CarOwnerDto>>(paginaredCarOwners);
        }
    }
}
