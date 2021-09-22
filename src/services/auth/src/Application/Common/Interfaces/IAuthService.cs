using Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IAuthService
    {
        Task<ApplicationUser> CreateUserAsync(string userName, string password, CancellationToken cancellationToken);
        Task<ApplicationUser> DeleteUserAsync(Guid id, CancellationToken cancellationToken);
        Task<ApplicationUser> GetUserAsync(Guid id);

        Task<ApplicationUser> AddRolesAsync(Guid id, CancellationToken cancellationToken, params string[] roles);

    }
}
