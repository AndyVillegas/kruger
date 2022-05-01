using Kruger.Application.DTOs;
using MediatR;

namespace Kruger.Application.Commands.UserCommands
{
    public class LoginUserCommand : IRequest<UserDto>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
