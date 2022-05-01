using System.Threading;
using System.Threading.Tasks;
using Kruger.Application.Commands.CarOwnerCommands;
using Kruger.Application.Exceptions;
using Kruger.Core.Interfaces.Repositories;
using MediatR;

namespace Kruger.Application.Handlers.CarOwnerHandlers.CommandHandlers
{
    public class DeleteCarOwnerHandler : INotificationHandler<DeleteCarOwnerCommand>
    {
        private readonly ICarOwnerRepository _repository;

        public DeleteCarOwnerHandler(ICarOwnerRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(DeleteCarOwnerCommand notification, CancellationToken cancellationToken)
        {
            var carOwner = await _repository.GetOne(notification.Id);
            if (carOwner == null)
                throw new CarOwnerNotFoundException();
            _repository.Delete(carOwner);
            await _repository.SaveChanges();
        }
    }
}
