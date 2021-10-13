using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.API.Extensions
{
    public class Migration<TDBContext> where TDBContext : DbContext
    {
        public Migration(Func<TDBContext, bool> condition, params object[] commands)
        {
            Condition = condition;
            Commands = commands;
        }

        public Func<TDBContext, bool> Condition { get; }
        public object[] Commands { get; }
    }
    public static class HostExtensions
    {
        public static async Task MigrateMysql<TDBContext>(this IHost host, params Migration<TDBContext>[] migrations) where TDBContext : DbContext
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var mediator = services.GetService<ISender>();
                var context = services.GetService<TDBContext>();
                
                try
                {
                    var retry = Policy.Handle<MySqlException>()
                        .WaitAndRetry(new TimeSpan[] 
                        { 
                            TimeSpan.FromSeconds(5),
                            TimeSpan.FromSeconds(10),
                            TimeSpan.FromSeconds(20),
                        });
                    await retry.Execute(()=> InvokeSeeder(context, mediator, migrations));
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<TDBContext>>();
                    logger.LogError(ex, "An error occurred while migrating or seeding the database.");

                    throw;
                }
            }
        }
    
        private static async Task InvokeSeeder<TDBContext>(TDBContext context, ISender mediator, Migration<TDBContext>[] migrations) where TDBContext : DbContext
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            {
                context.Database.Migrate();
            }

            foreach (var migration in migrations)
            {
                if(migration.Condition(context))
                {
                    foreach (var command in migration.Commands)
                    {
                        try
                        {
                            await mediator.Send(command);
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                        
                    }
                }
            }


        }
    }
}
