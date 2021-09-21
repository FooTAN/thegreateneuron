using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUsers
{
    public class GetAllUsersQuery : IRequest<IEnumerable<AppUserDto>>
    {
    }

    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<AppUserDto>>
    {
        public GetAllUsersQueryHandler(IApplicationDbContext context)
        {
            _context = context;

        }

        private readonly IApplicationDbContext _context;

        public async Task<IEnumerable<AppUserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users.Select(x => new AppUserDto { UserName = x.UserName }).ToListAsync();
        }
    }
}
