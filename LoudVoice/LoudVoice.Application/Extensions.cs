using LoudVoice.Domain.Users.Entities;
using LoudVoice.Domain.Users.Factories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserFactory, UserFactory>();

            return services;
        }
    }
}
