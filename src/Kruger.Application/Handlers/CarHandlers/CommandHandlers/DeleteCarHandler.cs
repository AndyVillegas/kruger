using System.Threading;
using System.Threading.Tasks;
using Kruger.Application.Commands.CarCommands;
using Kruger.Application.Exceptions;
using Kruger.Core.Interfaces.Repositories;
using MediatR;

namespace Kruger.Application.Handlers.CarHandlers.CommandHandlers
{
    public class DeleteCarHandler : INotificationHandler<DeleteCarCommand>
    {
        private readonly ICarRepository _repository;

        public DeleteCarHandler(ICarRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(DeleteCarCommand notification, CancellationToken cancellationToken)
        {
            var car = await _repository.GetOne(notification.Id);
            if (car == null)
                throw new CarNotFoundException();
            _repository.Delete(car);
            await _repository.SaveChanges();
        }
    }
}
