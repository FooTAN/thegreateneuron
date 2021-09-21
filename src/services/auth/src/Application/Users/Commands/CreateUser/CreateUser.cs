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
        public bool IsAdmin { get; set; }

    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserWithTokenDto>
    {
        public CreateUserCommandHandler(IApplicationDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        private readonly IApplicationDbContext _context;
        private readonly ITokenService _tokenService;
        public async Task<UserWithTokenDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (await UserExist(request.UserName))
                throw new UserExistException(request.UserName);

            ApplicationUser user = null;
            using (var hmac = new HMACSHA512())
            {
                user = new ApplicationUser
                {
                    UserName = request.UserName.ToLower(),
                    IsAdmin = request.IsAdmin,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password)),
                    PasswordSalt = hmac.Key
                };
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
            return new UserWithTokenDto
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

        public async Task<bool> UserExist(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}
