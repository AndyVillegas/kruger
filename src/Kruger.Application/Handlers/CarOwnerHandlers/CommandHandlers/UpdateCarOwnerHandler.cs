using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Kruger.Application.Commands.CarOwnerCommands;
using Kruger.Application.Exceptions;
using Kruger.Core.Interfaces.Repositories;
using MediatR;

namespace Kruger.Application.Handlers.CarOwnerHandlers.CommandHandlers
{
    public class UpdateCarOwnerHandler : INotificationHandler<UpdateCarOwnerCommand>
    {
        private readonly ICarOwnerRepository _repository;
        private readonly IMapper _mapper;

        public UpdateCarOwnerHandler(
            ICarOwnerRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateCarOwnerCommand notification, CancellationToken cancellationToken)
        {
            var carOwner = await _repository.GetOne(notification.Id);
            if (carOwner == null)
                throw new CarOwnerNotFoundException();
            var updatedCarOwner = _mapper.Map(notification, carOwner);
            _repository.Update(updatedCarOwner);
            await _repository.SaveChanges();
        }
    }
}
