using MediatR;

namespace Kruger.Application.Commands.CarCommands
{
    public class UpdateCarCommand : INotification
    {
        public int Id { get; set; }
        public string Plate { get; set; }
    }
}
