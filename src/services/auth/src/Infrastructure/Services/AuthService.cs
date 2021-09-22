using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        public AuthService(IApplicationDbContext context)
        {
            _context = context;
        }

        private readonly IApplicationDbContext _context;
        public async Task<ApplicationUser> CreateUserAsync(string userName, string password, CancellationToken cancellationToken)
        {
            if (await UserExist(userName))
                return null;

            ApplicationUser user = null;
            using (var hmac = new HMACSHA512())
            {
                user = new ApplicationUser
                {
                    UserName = userName.ToLower(),
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                    PasswordSalt = hmac.Key
                };
                user.AddRoles("user");
            }

            _context.Users.Add(user);

            await _context.SaveChangesAsync(cancellationToken);

            return user;
        }

        private async Task<bool> UserExist(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }

        public async Task<ApplicationUser> DeleteUserAsync(Guid id, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x=> x.Id == id);
            if (user == null)
                return null;

            _context.Users.Remove(user);

            await _context.SaveChangesAsync(cancellationToken);

            return user;
        }

        public async Task<ApplicationUser> GetUserAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);

            return user;
        }

        public async Task<ApplicationUser> AddRolesAsync(Guid id, CancellationToken cancellationToken, params string[] roles)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return null;

            user.AddRoles(roles);

            await _context.SaveChangesAsync(cancellationToken);

            return user;
        }
    }
}
