using System.Threading;
using System.Threading.Tasks;
using Kruger.Application.Commands.RateCommands;
using Kruger.Application.Exceptions;
using Kruger.Core.Interfaces.Repositories;
using MediatR;

namespace Kruger.Application.Handlers.RateHandlers.CommandHandlers
{
    public class DeleteRateHandler : INotificationHandler<DeleteRateCommand>
    {
        private readonly IRateRepository _repository;

        public DeleteRateHandler(IRateRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(DeleteRateCommand notification, CancellationToken cancellationToken)
        {
            var rate = await _repository.GetOne(notification.Id);
            if (rate == null)
                throw new RateNotFoundException();
            _repository.Delete(rate);
            await _repository.SaveChanges();
        }
    }
}
