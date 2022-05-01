using MediatR;

namespace Kruger.Application.Commands.CarCommands
{
    public class DeleteCarCommand : INotification
    {
        public int Id { get; set; }
    }
}
