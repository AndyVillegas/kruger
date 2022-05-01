using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Kruger.Application.Commands.RateCommands;
using Kruger.Application.DTOs;
using Kruger.Core.Entities;
using Kruger.Core.Interfaces.Repositories;
using MediatR;

namespace Kruger.Application.Handlers.RateHandlers.CommandHandlers
{
    public class CreateRateHandler : IRequestHandler<CreateRateCommand, RateDto>
    {
        private readonly IRateRepository _repository;
        private readonly IMapper _mapper;

        public CreateRateHandler(
            IRateRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RateDto> Handle(CreateRateCommand request, CancellationToken cancellationToken)
        {
            var rate = _mapper.Map<Rate>(request);
            var newModel = await _repository.Create(rate);
            await _repository.SaveChanges();
            return _mapper.Map<RateDto>(newModel);
        }
    }
}
