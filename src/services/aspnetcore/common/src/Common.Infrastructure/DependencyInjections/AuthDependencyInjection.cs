using Common.Application.Common.Interfaces;
using Common.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Common.Infrastructure.DependencyInjections
{
    public static class AuthDependencyInjection
    {
        public static IServiceCollection AddAuth<TAuthService>(this IServiceCollection services) where TAuthService : class, IAuthService
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, TAuthService>();

            return services;

        }
    }
}
