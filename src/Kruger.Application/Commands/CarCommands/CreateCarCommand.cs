using Kruger.Application.DTOs;
using MediatR;

namespace Kruger.Application.Commands.CarCommands
{
    public class CreateCarCommand : IRequest<CarDto>
    {
        public string Plate { get; set; }
    }
}
