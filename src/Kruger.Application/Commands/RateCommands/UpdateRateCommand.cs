using MediatR;

namespace Kruger.Application.Commands.RateCommands
{
    public class UpdateRateCommand : INotification
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal HourlyCost { get; set; }
        public decimal MinimumCost { get; set; }
    }
}
