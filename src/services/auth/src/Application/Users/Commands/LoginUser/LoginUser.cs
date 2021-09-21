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


namespace Application.Users.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<UserWithTokenDto>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, UserWithTokenDto>
    {
        public LoginUserCommandHandler(IApplicationDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        private readonly IApplicationDbContext _context;
        private readonly ITokenService _tokenService;

        public async Task<UserWithTokenDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == request.UserName);

            if (user == null)
                throw new UnauthorizedAccessException();


            using(var hmac = new HMACSHA512(user.PasswordSalt))
            {
                var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    if (hashBytes[i] != user.PasswordHash[i])
                        throw new UnauthorizedAccessException();
                }
            }

            return new UserWithTokenDto
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }
    }
}
