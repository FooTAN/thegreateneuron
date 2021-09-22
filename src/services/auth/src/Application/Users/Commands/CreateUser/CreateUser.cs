using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<UserWithTokenDto>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserWithTokenDto>
    {
        public CreateUserCommandHandler(ITokenService tokenService, IAuthService authService)
        {
            _tokenService = tokenService;
            _authService = authService;
        }

        private readonly ITokenService _tokenService;
        private readonly IAuthService _authService;
        public async Task<UserWithTokenDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine("One");
            var user = await _authService.CreateUserAsync(request.UserName, request.Password, cancellationToken);
            Console.WriteLine("Two");

            if (user == null)
                throw new UnauthorizedAccessException();

            return new UserWithTokenDto
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }
    }
}
