using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Kruger.Application.Commands.CarCommands;
using Kruger.Application.DTOs;
using Kruger.Core.Entities;
using Kruger.Core.Interfaces.Repositories;
using MediatR;

namespace Kruger.Application.Handlers.CarHandlers.CommandHandlers
{
    public class CreateCarHandler : IRequestHandler<CreateCarCommand, CarDto>
    {
        private readonly ICarRepository _repository;
        private readonly IMapper _mapper;

        public CreateCarHandler(
            ICarRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CarDto> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var car = _mapper.Map<Car>(request);
            var newModel = await _repository.Create(car);
            await _repository.SaveChanges();
            return _mapper.Map<CarDto>(newModel);
        }
    }
}
