using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Kruger.Application.Commands.CarCommands;
using Kruger.Application.Exceptions;
using Kruger.Core.Interfaces.Repositories;
using MediatR;

namespace Kruger.Application.Handlers.CarHandlers.CommandHandlers
{
    public class UpdateCarHandler : INotificationHandler<UpdateCarCommand>
    {
        private readonly ICarRepository _repository;
        private readonly IMapper _mapper;

        public UpdateCarHandler(
            ICarRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateCarCommand notification, CancellationToken cancellationToken)
        {
            var car = await _repository.GetOne(notification.Id);
            if (car == null)
                throw new CarNotFoundException();
            var updatedCar = _mapper.Map(notification, car);
            _repository.Update(updatedCar);
            await _repository.SaveChanges();
        }
    }
}
