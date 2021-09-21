using Application.Users;
using Application.Users.Commands.CreateUser;
using Application.Users.Commands.LoginUser;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AccountController : ApiControllerBase
    {
        [HttpPost("createuser")]
        public async Task<ActionResult<UserWithTokenDto>> CreateUser([FromBody]CreateUserDto createUserDto)
        {
            var userWithToken = await Mediator.Send(new CreateUserCommand { UserName = createUserDto.UserName, Password = createUserDto.Password, IsAdmin = false });
            HttpContext.Response.Cookies.Append("tgn-auth-token", userWithToken.Token);
            return userWithToken;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserWithTokenDto>> Login([FromBody]LoginDto loginDto)
        {
            var userWithToken = await Mediator.Send(new LoginUserCommand { UserName = loginDto.UserName, Password = loginDto.Password });
            HttpContext.Response.Cookies.Append("tgn-auth-token", userWithToken.Token);
            return userWithToken;
        }

    }
}
 