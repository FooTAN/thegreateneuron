using Application.Users.Commands.CreateUser;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedUsers(ApplicationDbContext context, IServiceProvider services )
        {
            ISender mediator = services.GetService<ISender>();

            if(!context.Users.Any())
            {
                await mediator.Send(new CreateUserCommand { UserName = "admin", Password = "password", IsAdmin = true });
                await mediator.Send(new CreateUserCommand { UserName = "FooUser", Password = "password", IsAdmin = false });
                await mediator.Send(new CreateUserCommand { UserName = "BarUser", Password = "password", IsAdmin = false });
                await mediator.Send(new CreateUserCommand { UserName = "HelloUser", Password = "password", IsAdmin = false });

            }
        }
    }
}
