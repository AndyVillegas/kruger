using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Kruger.Application.Commands.UserCommands;
using Kruger.Application.DTOs;
using Kruger.Application.Exceptions;
using Kruger.Core.Interfaces.Repositories;
using Kruger.Shared.Encrypt;
using MediatR;

namespace Kruger.Application.Handlers.UserHandlers.CommandHandlers
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public LoginUserHandler(IUserRepository repository, IMapper mapper)
        {
            _userRepository = repository;
            _mapper = mapper;
        }
        public async Task<UserDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUserName(request.Username);
            if (user == null)
                throw new UserNotFoundException(request.Username);
            if (user.Password != EncryptPassword(request.Password))
                throw new WrongPasswordException(request.Username);
            return _mapper.Map<UserDto>(user);
        }

        private string EncryptPassword(string password)
        {
            return Sha256.Encrypt(password);
        }
    }
}
