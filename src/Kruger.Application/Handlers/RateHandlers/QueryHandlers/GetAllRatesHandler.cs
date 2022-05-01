using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Common.Pagination;
using Kruger.Application.DTOs;
using Kruger.Application.Queries.RateQueries;
using Kruger.Core.Interfaces.Repositories;
using MediatR;

namespace Kruger.Application.Handlers.RateHandlers.QueryHandlers
{
    public class GetAllRatesHandler : IRequestHandler<GetAllRatesQuery, PaginatedResponse<RateDto>>
    {
        private readonly IRateRepository _repository;
        private readonly IMapper _mapper;

        public GetAllRatesHandler(
            IRateRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PaginatedResponse<RateDto>> Handle(GetAllRatesQuery request, CancellationToken cancellationToken)
        {
            var rates = await _repository.GetAll(request.Search, request);
            return _mapper.Map<PaginatedResponse<RateDto>>(rates);
        }
    }
}
