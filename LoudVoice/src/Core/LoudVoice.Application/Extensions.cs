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
            services.AddSingleton<IUserFactory, UserFactory>();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}