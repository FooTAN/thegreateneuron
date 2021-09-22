using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Application.Users.Queries.GetUser
{
    public class GetUserQuery : IRequest<AppUserDto>
    {
        public Guid Id { get; set; }
    }

    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, AppUserDto>
    {
        public GetUserQueryHandler(IAuthService authService)
        {
            _authService = authService;

        }

        private readonly IAuthService _authService;

        public async Task<AppUserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _authService.GetUserAsync(request.Id);
            if (user == null)
                throw new UnauthorizedAccessException();

            return new AppUserDto { UserName = user.UserName, Roles = user.Roles };
        }
    }
}
