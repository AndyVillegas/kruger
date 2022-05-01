using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Kruger.Application.Commands.RateCommands;
using Kruger.Application.Exceptions;
using Kruger.Core.Interfaces.Repositories;
using MediatR;

namespace Kruger.Application.Handlers.RateHandlers.CommandHandlers
{
    public class UpdateRateHandler : INotificationHandler<UpdateRateCommand>
    {
        private readonly IRateRepository _repository;
        private readonly IMapper _mapper;

        public UpdateRateHandler(
            IRateRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateRateCommand notification, CancellationToken cancellationToken)
        {
            var rate = await _repository.GetOne(notification.Id);
            if (rate == null)
                throw new RateNotFoundException();
            var updatedRate = _mapper.Map(notification, rate);
            _repository.Update(updatedRate);
            await _repository.SaveChanges();
        }
    }
}
