using Kruger.Application.DTOs;
using MediatR;

namespace Kruger.Application.Commands.RateCommands
{
    public class CreateRateCommand : IRequest<RateDto>
    {
        public string Description { get; set; }
        public decimal HourlyCost { get; set; }
        public decimal MinimumCost { get; set; }
    }
}
