using FluentValidation;
using LoudVoice.Application.Common.Behaviours;
using LoudVoice.Domain.Performers.Factories;
using LoudVoice.Domain.Users.Factories;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LoudVoice.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped(
                typeof(IPipelineBehavior<,>), 
                typeof(ValidationBehavior<,>));

            services.AddScoped<IUserFactory, UserFactory>();
            services.AddScoped<IPerformerFactory, PerformerFactory>();

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}