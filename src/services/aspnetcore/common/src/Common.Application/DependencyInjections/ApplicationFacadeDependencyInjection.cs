using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Common.Application.DependencyInjections
{
    public static class ApplicationFacadeDependencyInjection
    {
        public static IServiceCollection AddApplicationFacade(this IServiceCollection services, Assembly executingAssembly)
        {
            services.AddAutoMapper(executingAssembly);
            services.AddValidatorsFromAssembly(executingAssembly);
            services.AddMediatR(executingAssembly);
            services.AddPipelineBehaviour();

            return services;
        }
    }
}

