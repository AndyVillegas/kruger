using MediatR;

namespace Kruger.Application.Commands.RateCommands
{
    public class DeleteRateCommand : INotification
    {
        public int Id { get; set; }
    }
}
