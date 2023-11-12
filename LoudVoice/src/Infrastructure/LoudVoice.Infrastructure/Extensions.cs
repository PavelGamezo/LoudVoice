using LoudVoice.Application.Common.Authentications;
using LoudVoice.Application.Common.Persistance;
using LoudVoice.Application.Common.Services;
using LoudVoice.Infrastructure.Authentications;
using LoudVoice.Infrastructure.EF.Repositories;
using LoudVoice.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LoudVoice.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}