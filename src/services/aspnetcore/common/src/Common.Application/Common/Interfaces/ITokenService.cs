using Common.Domain.Entities;

namespace Common.Application.Common.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(ApplicationUser user);
    }
}
