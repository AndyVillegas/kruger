using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Kruger.Application.Commands.CarOwnerCommands;
using Kruger.Application.DTOs;
using Kruger.Application.Exceptions;
using Kruger.Core.Entities;
using Kruger.Core.Interfaces.Repositories;
using MediatR;

namespace Kruger.Application.Handlers.CarOwnerHandlers.CommandHandlers
{
    public class CreateCarOwnerHandler : IRequestHandler<CreateCarOwnerCommand, CarOwnerDto>
    {
        private readonly ICarOwnerRepository _repository;
        private readonly IMapper _mapper;

        public CreateCarOwnerHandler(
            ICarOwnerRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CarOwnerDto> Handle(CreateCarOwnerCommand request, CancellationToken cancellationToken)
        {
            var isTheIdentificationRepeated = await _repository.IsTheIdentificationRepeated(request.IdValue);
            if (isTheIdentificationRepeated)
                throw new IdentificationRepeatedException();
            var carOwner = _mapper.Map<CarOwner>(request);
            var newModel = await _repository.Create(carOwner);
            await _repository.SaveChanges();
            return _mapper.Map<CarOwnerDto>(newModel);
        }
    }
}
