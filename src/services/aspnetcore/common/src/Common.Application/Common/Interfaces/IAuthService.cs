using Common.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Application.Common.Interfaces
{
    public interface IAuthService
    {
        Task<ApplicationUser> CreateUserAsync(string userName, string password, CancellationToken cancellationToken);
        Task<ApplicationUser> DeleteUserAsync(Guid id, CancellationToken cancellationToken);
        Task<ApplicationUser> GetUserAsync(Guid id);
        Task<ApplicationUser> AddRolesAsync(Guid id, CancellationToken cancellationToken, params string[] roles);
    }
}
