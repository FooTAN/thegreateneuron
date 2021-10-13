
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Common.Infrastructure.DependencyInjections
{
    public static class DatabaseDependencyInjection
    {
        public static IServiceCollection AddMySQLDatabase<TDBContextKey, TDBContext>(this IServiceCollection services, IConfiguration configuration)where TDBContextKey : class where TDBContext : DbContext, TDBContextKey
        {
            if (!configuration.GetValue<bool>("HasSQLDatabase"))
                return services;

            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<TDBContext>(options =>
                    options.UseInMemoryDatabase("MemoryDb"));
            }
            else
            {
                services.AddDbContext<TDBContext>(options => {
                    options.UseMySQL(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(TDBContext).Assembly.FullName));
                });
            }

            services.AddScoped<TDBContextKey>(provider => provider.GetService<TDBContext>());

            return services;

        }
    }
}
