using Kruger.Application.DTOs;
using MediatR;

namespace Kruger.Application.Commands.ParkingRecordCommands
{
    public class FinishParkingRecordCommand : IRequest<FinishedParkingRecordDto>
    {
        public int Id { get; set; }
        public string Note { get; set; }
    }
}
