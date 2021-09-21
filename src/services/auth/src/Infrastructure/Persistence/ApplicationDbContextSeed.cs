using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedUsers(ApplicationDbContext context)
        {
            if(!context.Users.Any())
            {
                context.Users.Add(new ApplicationUser {Id = Guid.NewGuid(), UserName = "admin"  });
                context.Users.Add(new ApplicationUser { Id = Guid.NewGuid(), UserName = "FooUser" });
                context.Users.Add(new ApplicationUser { Id = Guid.NewGuid(), UserName = "BarUser" });

            }

            await context.SaveChangesAsync();
        }
    }
}
