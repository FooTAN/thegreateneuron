using Common.Application.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using Respawn;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Testing
{
    /// <summary>
    /// The base class for application integration testing.
    /// This sets up the infrastructure needed for testing the application functionalities.
    /// ApplicationIntegrationTestBase reads environment variables from appsettings.Test.json
    /// ApplicationIntegrationTestBase Assumes that the Startup code is pretty standard. A constructor with IConfiguration configuration,
    /// and a method called ConfigureServices with IServiceCollection services.
    /// This will fail to initialize if not. Only use when these conditions can be ensured.
    /// </summary>
    /// <typeparam name="TStartup">The startup class of the application to test</typeparam>
    /// <typeparam name="TDBContext">The database context to use</typeparam>
    [TestFixture]
    public class ApplicationIntegrationTestBase<TStartup, TDBContext> where TStartup : class where TDBContext : DbContext
    {
        private static IConfigurationRoot _configuration;
        private static IServiceScopeFactory _scopeFactory;
        private static Checkpoint _checkpoint;
        private static string _currentUserId;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Test.json", true, true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();

            var startup = Activator.CreateInstance(typeof(TStartup), _configuration);
            Console.WriteLine("startup: "+startup);
            var services = new ServiceCollection();

            services.AddSingleton(Mock.Of<IWebHostEnvironment>(w =>
                w.EnvironmentName == "Development" &&
                w.ApplicationName == "API"));

            services.AddLogging();

            startup.GetType().GetMethod("ConfigureServices").Invoke(startup, new object[] { services });

            // Replace service registration for ICurrentUserService
            // Remove existing registration
            var currentUserServiceDescriptor = services.FirstOrDefault(d =>
                d.ServiceType == typeof(ICurrentUserService));

            services.Remove(currentUserServiceDescriptor);

            // Register testing version
            services.AddTransient(provider =>
                Mock.Of<ICurrentUserService>(s => s.UserId == _currentUserId));
            services.AddSingleton<IConfiguration>(x => _configuration);
            _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();

            _checkpoint = new Checkpoint
            {
            };
        }

        /// <summary>
        /// Ensures that the testing state is reset before test run
        /// </summary>
        /// <returns></returns>
        [SetUp]
        public async Task TestSetUp()
        {
            await ResetState();
        }

        /// <summary>
        /// sends request through mediatr
        /// </summary>
        /// <typeparam name="TResponse">the return type expected from request</typeparam>
        /// <param name="request">the mediatr request object</param>
        /// <returns>what the response back from request</returns>
        public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            using var scope = _scopeFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetService<ISender>();

            return await mediator.Send(request);
        }

        /// <summary>
        /// creates a default normal user
        /// </summary>
        /// <returns>The id of user</returns>
        public static async Task<string> RunAsDefaultUserAsync()
        {
            return await RunAsUserAsync("foo", "password", new string[] { });
        }

        /// <summary>
        /// create a user with administrator privileges
        /// </summary>
        /// <returns>The id of user</returns>
        public static async Task<string> RunAsAdministratorAsync()
        {
            return await RunAsUserAsync("admin", "password!", new[] { "Administrator" });
        }

        /// <summary>
        /// creates a user and sets the created user as the current user being acted on
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="roles"></param>
        /// <returns>The id of the user created</returns>
        public static async Task<string> RunAsUserAsync(string userName, string password, string[] roles)
        {
            using var scope = _scopeFactory.CreateScope();

            var authService = scope.ServiceProvider.GetService<IAuthService>();

            var user = await authService.CreateUserAsync(userName, password, CancellationToken.None);

            if (user == null)
                throw new Exception($"Unable to create {userName}");

            if (roles.Any())
            {
                await authService.AddRolesAsync(user.Id, CancellationToken.None, roles);
            }

            _currentUserId = user.Id.ToString();
            return _currentUserId;
        }

        /// <summary>
        /// Resets the state of the current test
        /// </summary>
        /// <returns></returns>
        public static async Task ResetState()
        {
            _currentUserId = null;
        }


        public static async Task<TEntity> FindAsync<TEntity>(params object[] keyValues)
            where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<TDBContext>();

            return await context.FindAsync<TEntity>(keyValues);
        }

        public static async Task AddAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<TDBContext>();

            context.Add(entity);

            await context.SaveChangesAsync();
        }

        public static async Task<int> CountAsync<TEntity>() where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<TDBContext>();

            return await context.Set<TEntity>().CountAsync();
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
        }
    }
}