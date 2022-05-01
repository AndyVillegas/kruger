using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Kruger.Application.DTOs;
using Kruger.Application.Exceptions;
using Kruger.Application.Queries.RateQueries;
using Kruger.Core.Interfaces.Repositories;
using MediatR;

namespace Kruger.Application.Handlers.RateHandlers.QueryHandlers
{
    public class GetRateByIdHandler : IRequestHandler<GetRateByIdQuery, RateDto>
    {
        private readonly IRateRepository _repository;
        private readonly IMapper _mapper;

        public GetRateByIdHandler(
            IRateRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<RateDto> Handle(GetRateByIdQuery request, CancellationToken cancellationToken)
        {
            var rate = await _repository.GetOne(request.Id);
            if (rate == null)
                throw new RateNotFoundException();
            return _mapper.Map<RateDto>(rate);
        }
    }
}
