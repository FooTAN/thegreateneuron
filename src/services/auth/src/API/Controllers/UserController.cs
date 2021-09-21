using Application.Users;
using Application.Users.Queries.GetUser;
using Application.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class UsersController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<AppUserDto>> GetUsers()
        {
            return await Mediator.Send(new GetAllUsersQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUserDto>> GetUser(Guid id)
        {
            return await Mediator.Send(new GetUserQuery { Id = id });
        }
    }
}
