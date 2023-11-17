using FluentValidation;
using LoudVoice.Application.Common.Behaviours;
using LoudVoice.Domain.Users.Factories;
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

            services.AddSingleton<IUserFactory, UserFactory>();

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}