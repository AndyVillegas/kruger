using Kruger.Application.DTOs;
using Kruger.Core.Enums;
using MediatR;

namespace Kruger.Application.Commands.CarOwnerCommands
{
    public class UpdateCarOwnerCommand : INotification, IRequest<CarOwnerDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public IdType IdType { get; set; }
        public string IdValue { get; set; }
    }
}
