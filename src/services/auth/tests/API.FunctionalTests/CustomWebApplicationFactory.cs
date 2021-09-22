using System;
using System.IO;
using System.Linq;
using auth;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API.FunctionalTests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<Startup>
    { 
        /// <summary>
        /// Overriding CreateHost to avoid creating a separate ServiceProvider per this thread:
        /// https://github.com/dotnet-architecture/eShopOnWeb/issues/465
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureAppConfiguration((context, builder) => {
                builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Testing.json", true, true)
                .AddEnvironmentVariables();
            });

            var host = builder.Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();

                    ApplicationDbContextSeed.SeedUsers(context, services);
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

                    logger.LogError(ex, "An error occurred while migrating or seeding the database.");

                    throw;
                }
            }

            host.Start();
            return host;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseSolutionRelativeContentRoot("src/API");
        }
    }
}