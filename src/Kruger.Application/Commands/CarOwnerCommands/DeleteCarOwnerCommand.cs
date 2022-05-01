using MediatR;

namespace Kruger.Application.Commands.CarOwnerCommands
{
    public class DeleteCarOwnerCommand : INotification
    {
        public int Id { get; set; }
    }
}
